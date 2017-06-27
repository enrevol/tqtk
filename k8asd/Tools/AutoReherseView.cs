using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class AutoReherseView : Form {
        private int LineLimit = 500;

        /// <summary>
        /// Ánh xạ từ ID sang Client (để gửi/nhận gói tin).
        /// </summary>
        private Dictionary<long, IClient> clients;

        /// <summary>
        /// Ánh xạ từ ID sang thông tin võ đài (64005).
        /// </summary>
        private Dictionary<long, ReherseInfo> infos;

        /// <summary>
        /// Danh sách ID của người chơi để tự động đánh võ đài.
        /// </summary>
        private List<long> playerIds;

        /// <summary>
        /// Có đang làm mới thông tin võ đài không?
        /// </summary>
        private bool isRefreshing;

        /// <summary>
        /// Có đang khiêu chiên võ đài không?
        /// </summary>
        private bool isDueling;


        public AutoReherseView() {
            InitializeComponent();

            clients = new Dictionary<long, IClient>();
            infos = new Dictionary<long, ReherseInfo>();
            playerIds = new List<long>();

            isRefreshing = false;
            isDueling = false;

            rankColumn.AspectGetter = obj => {
                var info = infos[(long) obj];
                return String.Format("{0}", info.top);
            };
           
            nameColumn.AspectGetter = obj => {
                var info = infos[(long) obj];
                return info.playername;
            };
            levelColumn.AspectGetter = obj => {
                var info = infos[(long) obj];
                return info.playerlv;
            };

        }

        private void RemovePlayer(long playerId) {
            playerIds.Remove(playerId);
            clients.Remove(playerId);
            infos.Remove(playerId);
            playerList.SetObjects(playerIds);
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshPlayersAsync();
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
        /// Cập nhật võ đài tất cả các tài khoản đang kết nối.
        /// </summary>
        private async Task<bool> RefreshPlayersAsync() {
            if (isRefreshing) {
                return false;
            }
            if (isDueling) {
                return false;
            }
            isRefreshing = true;

            clients.Clear();
            infos.Clear();
            playerIds.Clear();
            playerList.Items.Clear();

            //tim trang dau tien
            //tim client co ket noi dau tien
            var listClient = ClientManager.Instance.Clients;
            Packet packet = new Packet();
            foreach (var client in listClient)
            {
                if (client.State == ClientState.Connected)
                {
                    packet = await client.RefreshListMemberAsync((int)numericUpDown1.Value);
                    break;
                }
            }
            List<ReherseInfo> list = Parse32101(packet);

            foreach (var client in list)
            {
                var playerId = client.playerid;
                playerIds.Add(playerId);
               // clients.Add(playerId, client);
                infos.Add(playerId, client);

                playerList.SetObjects(playerIds, true);
            }

            isRefreshing = false;
            return true;
        }

        private List<ReherseInfo> Parse32101(Packet packet)
        {
            List<ReherseInfo> list = new List<ReherseInfo>();
            var token = JToken.Parse(packet.Message);
            JArray array = (JArray)token["legion_memberdto"];

            foreach (var item in array)
            {
                list.Add(ReherseInfo.Parse(item));
            }
            return list;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!"".Equals(this.textBox1.Text))
            {
                long playerid = 0;
                foreach (var playerId in playerIds)
                {
                    var info = infos[playerId];
                    if (this.textBox1.Text.Equals(info.playername))
                    {
                        playerid = info.playerid;
                        break;
                    }
                }
                if (playerid != 0)
                {
                    var clients = ClientManager.Instance.Clients;
                    this.lbState.Text = "Đang tập trận";
                    foreach (var client in clients)
                    {
                        if (client.State == ClientState.Connected)
                        {
                            await client.ReherseAsync(playerid);
                        }
                    }
                    this.lbState.Text = "Tập trận xong";
                }
            }
        }       
    }
}