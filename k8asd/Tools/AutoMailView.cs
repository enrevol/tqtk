using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class AutoMailView : Form {
        private int LineLimit = 500;

        /// <summary>
        /// Hàng đợi danh sách client để chuyển mỏ.
        /// </summary>
        private List<IClient> clients;


        public AutoMailView() {
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


        private async void autoLT_CheckedChanged(object sender, EventArgs e) {
            if (autoLT.Checked) {
                List<IClient> connectedClients = FindConnectedClients();
                int yearLT = (int)numYearLT.Value;
                int LT = (int)numLT.Value;
                LogInfo(String.Format("[MAIL] Bắt đầu nhận thư liên thắng"));
                foreach (var client in connectedClients) {
                    var packet = await client.GetMailLTAsync(yearLT, LT);
                    if (packet == null) {
                        return;
                    }
                    LogInfo(String.Format("[MAIL] Nhận liên thắng {0} của {1}", LT, client.PlayerName));
                    await Task.Delay(2000);
                }
                LogInfo(String.Format("[MAIL] Nhận thư liên thắng hoàn thành"));
                autoLT.Checked = false;
            }
        }

        private async void autoTTC_CheckedChanged(object sender, EventArgs e) {
            if (autoTTC.Checked)
            {
                List<IClient> connectedClients = FindConnectedClients();
                int yearLT = (int)numYearTTC.Value;
                int TTC = (int)numYearTTC.Value;
                LogInfo(String.Format("[MAIL] Bắt đầu nhận thư thần thú chiến"));
                foreach (var client in connectedClients)
                {
                    var packet = await client.GetMailTTCAsync(yearLT, TTC);
                    if (packet == null)
                    {
                        return;
                    }
                    LogInfo(String.Format("[MAIL] Nhận thư thần thú chiến của {0}", client.PlayerName));
                    await Task.Delay(2000);
                }
                LogInfo(String.Format("[MAIL] Nhận thư thần thú chiến hoàn thành"));
                autoTTC.Checked = false;
            }
        }

        private async void chkGetNewSkill_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGetNewSkill.Checked)
            {
                List<IClient> connectedClients = FindConnectedClients();
                LogInfo(String.Format("[SKILL] Bắt đầu làm mới kỹ năng"));
                foreach (var client in connectedClients)
                {
                    var packet = await client.GetNewSkillAsync();
                    if (packet == null)
                    {
                        return;
                    }
                    LogInfo(String.Format("[SKILL] Làm mới kỹ năng của {0}", client.PlayerName));
                    await Task.Delay(2000);
                }
                LogInfo(String.Format("[SKILL] Làm mới hoàn thành"));
                autoTTC.Checked = false;
            }
        }
    }
}