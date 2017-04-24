using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class AutoSnoutView : Form {
        private int LineLimit = 500;

        /// <summary>
        /// Hàng đợi danh sách client để chuyển mỏ.
        /// </summary>
        private List<IClient> clients;


        public AutoSnoutView() {
            InitializeComponent();

            clients = new List<IClient>();
        }

        public void LogInfo(string newMessage) {
            if (logBox.Text.Length > 0) {
                logBox.Text += Environment.NewLine;
            }
            logBox.Text += String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            if (logBox.Lines.Length > LineLimit) {
                logBox.Text = logBox.Text.Remove(0, logBox.Lines[0].Length + Environment.NewLine.Length);
            }
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshPlayersAsync(FindConnectedClients());
        }

        private List<IClient> FindConnectedClients() {
            var clients = ClientManager.Instance.Clients;
            var connectedClients = new List<IClient>();
            foreach (var client in clients) {
                if (client.State == ClientState.Connected) {
                    connectedClients.Add(client);
                }
            }
            return connectedClients;
        }

        /// <summary>
        /// Tìm acc nào đang chiếm mỏ.
        /// </summary>
        private async Task<string> RefreshPlayersAsync(List<IClient> connectedClients) {
            try {
                LogInfo("Bắt đầu làm mới...");

                //tim id khu vuc
                foreach (IClient client in connectedClients)
                {
                    var packet = await client.RefreshAreaAsync();
                    if (packet == null)
                    {
                        return "";
                    }
                    JToken token = JToken.Parse(packet.Message);
                    if (token["area"]!= null)
                    {
                        LogInfo(String.Format("Khu vực hiện tại: {0} tên là: {1}", token["area"]["areaid"].ToString(), token["area"]["areaname"].ToString()));
                        return token["area"]["areaid"].ToString();
                    }
                    break;
                }

            } finally {
                LogInfo("Làm mới hoàn thành!");
            }
            return "";
        }

        private async void autoSnoutCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSnoutCheck.Checked)
            {
                List<IClient> connectedClients = FindConnectedClients();
                string areaid = await RefreshPlayersAsync(connectedClients);
                //tim trong danh sach acc, acc nao dang chiem mo thi remove ra
                IClient currentClient = null;
                string index = ""; //mo dang chiem
                foreach (var client in connectedClients)
                {
                    var packet = await client.FindSnoutAsync(areaid);
                    if (packet == null)
                    {
                        return;
                    }
                    JToken token = JToken.Parse(packet.Message);
                    JArray arrcity = (JArray)token["city"];
                    for (int i = 0; i < arrcity.Count; i++)
                    {
                        JObject objCur = (JObject)arrcity[i];
                        if (objCur["playername"].ToString() == client.PlayerName)
                        {
                            currentClient = client;
                            index = objCur["index"].ToString();
                            connectedClients.Remove(client);
                            break;
                        }
                    }
                    if(currentClient!= null)
                        break;
                }
                //chuyen mo cho danh sach acc con lai               
                if (currentClient != null)
                {
                    LogInfo(String.Format("Bắt đầu chuyển mỏ"));
                    SwapSnout(currentClient, connectedClients, areaid, index);
                    autoSnoutCheck.Checked = false;
                }
                else
                {
                    autoSnoutCheck.Checked = false;
                }
            }
        }

        private async void SwapSnout(IClient currentClient, List<IClient> connectedClients, string areaid, string index)
        {
            if (connectedClients.Count == 0)
            {
                LogInfo(String.Format("Chuyển mỏ hoàn thành"));
                return;
            }

            IClient obClient = connectedClients[0];
            //tim kiem acc trong danh sach ma dang co mo thi bo qua lam acc khac
            bool check = false;
            var packet = await obClient.FindSnoutAsync(areaid);
            if (packet == null)
            {
                return;
            }

            JToken token = JToken.Parse(packet.Message);
            JArray arrcity = (JArray)token["city"];
            for (int i = 0; i < arrcity.Count; i++)
            {
                JObject objCur = (JObject)arrcity[i];
                if (objCur["playername"].ToString() == obClient.PlayerName)
                {
                    check = true;
                    break;
                }
            }

            if (check)
            {
                connectedClients.RemoveAt(0);
                SwapSnout(currentClient, connectedClients, areaid, index);
            }
            else
            {
                ////chon tran truong xa cho client hien tai
                //var p0 = await currentClient.SetDefaultFormationAsync(10);
                //if (p0 == null)
                //{
                //    return;
                //}

                //// Gỡ bỏ toàn bộ tướng.
                //var p1 = await currentClient.RemoveAllHeroesFromFormationAsync(10);
                //if (p1 == null)
                //{
                //    return;
                //}

                //Bỏ mỏ
                var p2 = await currentClient.BreakSnoutAsync(index);
                if (p2 == null)
                {
                    return;
                }

                // Chọn trận truỳ hình (không trống).
                var p3 = await obClient.SetDefaultFormationAsync(13);
                if (p3 == null)
                {
                    return;
                }

                // Chiếm mỏ.
                var p4 = await obClient.AttackSnoutAsync(areaid, index);
                if (p4 == null)
                {
                    return;
                }

                ////chon lai tran truy hinh
                //var p5 = await currentClient.SetDefaultFormationAsync(13);
                //if (p5 == null)
                //{
                //    return;
                //}

                LogInfo(String.Format("Chuyển mỏ từ: {0} sang {1}", currentClient.PlayerName, obClient.PlayerName));

                connectedClients.RemoveAt(0);
                currentClient = obClient;

                //ngung tranh treo acc
                await Task.Delay(100);
                SwapSnout(currentClient, connectedClients, areaid, index);
            }
            
        }
    }
}