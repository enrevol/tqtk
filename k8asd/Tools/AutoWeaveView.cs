using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace k8asd {
    public partial class AutoWeaveView : Form {
        private int NoTeam = -1;

        private enum WeaveMode {
            /// <summary>
            /// Dệt chung.
            /// </summary>
            WeaveTogether,

            /// <summary>
            /// Kéo vải.
            /// </summary>
            PullLevel,
        }

        private Dictionary<int, ClientView> clients;
        private Dictionary<int, WeaveInfo> infos;
        private List<int> playerIds;

        private int hostingTeamId;
        private bool isRefreshing;
        private bool isWeaving;
        private bool timerLocking;

        public AutoWeaveView() {
            InitializeComponent();

            clients = new Dictionary<int, ClientView>();
            infos = new Dictionary<int, WeaveInfo>();
            playerIds = new List<int>();

            hostingTeamId = NoTeam;
            isRefreshing = false;
            isWeaving = false;
            timerLocking = false;

            spinnerLevelColumn.AspectGetter = obj => infos[(int) obj].Level;
            successRateColumn.AspectGetter = obj => infos[(int) obj].SuccessRate;
            criticalRateColumn.AspectGetter = obj => infos[(int) obj].CriticalRate;
            priceColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return String.Format("{0} {1}", info.Price,
                    (info.PriceWay == WeavePriceWay.Up ? "▲" : "▼"));
            };
            turnColumn.AspectGetter = obj => infos[(int) obj].Turns;
            nameColumn.AspectGetter = obj => clients[(int) obj].PlayerName;
            cooldownColumn.AspectGetter = obj => Utils.FormatDuration(infos[(int) obj].Cooldown);

            weaveTimer.Start();
            weaveTimer.Interval = 1000; // 1 giây.
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshPlayersAsync(FindConnectedClients());
        }

        private List<ClientView> FindConnectedClients() {
            var clients = ClientManager.Instance.Clients;
            var connectedClients = new List<ClientView>();
            foreach (var client in clients) {
                if (client.Connected) {
                    connectedClients.Add(client);
                }
            }
            return connectedClients;
        }

        private async Task<bool> RefreshPlayersAsync(List<ClientView> connectedClients) {
            if (isRefreshing) {
                return false;
            }
            isRefreshing = true;

            clients.Clear();
            infos.Clear();
            playerIds.Clear();
            playerList.Items.Clear();

            foreach (var client in connectedClients) {
                var packet = await client.RefreshWeaveAsync();
                if (packet == null) {
                    continue;
                }
                Debug.Assert(packet.CommandId == "45200");
                var token = JToken.Parse(packet.Message);

                var info = WeaveInfo.Parse(token);
                if (info == null) {
                    continue;
                }

                var playerId = client.PlayerId;
                playerIds.Add(playerId);
                clients.Add(playerId, client);
                infos.Add(playerId, info);
                playerList.SetObjects(playerIds);
            }

            isRefreshing = false;
            return true;
        }

        private async Task<bool> RefreshPlayerAsync(int playerId) {
            if (isRefreshing) {
                return false;
            }
            isRefreshing = true;
            try {
                var client = clients[playerId];
                var packet = await client.RefreshWeaveAsync();
                if (packet == null) {
                    return false;
                }

                var token = JToken.Parse(packet.Message);
                infos[playerId] = WeaveInfo.Parse(token);
                playerList.RefreshObject(playerId);
            } finally {
                isRefreshing = false;
            }
            return true;
        }

        private async Task<bool> WeaveAsync(IPacketWriter host, string hostName, WeaveMode mode,
            IPacketWriter slot1, IPacketWriter slot2) {
            // Lập tổ đội.
            var textileLevel = (int) textileLevelInput.Value;
            try {
                host.PacketReceived += OnPacketReceived;
                var p0 = await host.CreateWeaveAsync(textileLevel, WeaveTeamLimit.Nation);
                if (p0 == null) {
                    return false;
                }
            } finally {
                host.PacketReceived -= OnPacketReceived;
            }
            // FIXME: Kiểm tra có tạo được không?

            try {
                Debug.Assert(hostingTeamId != NoTeam);

                // Gia nhập tổ đội.
                var p2s = await Task.WhenAll(slot1.JoinWeaveAsync(hostingTeamId), slot2.JoinWeaveAsync(hostingTeamId));
                if (p2s[0] == null || p2s[1] == null) {
                    return false;
                }

                if (mode == WeaveMode.WeaveTogether) {
                    var p3 = await host.MakeWeaveAsync(hostingTeamId);
                    if (p3 == null) {
                        return false;
                    }
                } else {
                    var p4 = await host.QuitAndMakeWeaveAsync(hostingTeamId);
                    if (p4 == null) {
                        return false;
                    }
                }
                return true;
            } finally {
                hostingTeamId = NoTeam;
            }
        }

        private class WeaveTeamInfo {
            public int HostId { get; private set; }
            public int Slot1Id { get; private set; }
            public int Slot2Id { get; private set; }

            public WeaveTeamInfo(int host, int slot1) {
                HostId = host;
                Slot1Id = slot1;
                Slot2Id = 0;
            }

            public WeaveTeamInfo(int host, int slot1, int slot2) {
                HostId = host;
                Slot1Id = slot1;
                Slot2Id = slot2;
            }
        }

        private WeaveTeamInfo FindWeaveTeam(int hostId, List<int> memberIds) {
            if (infos[hostId].Cooldown > 0) {
                return null;
            }
            if (memberIds.Count == 0) {
                return null;
            }
            if (memberIds.Count == 1) {
                if (infos[memberIds[0]].Cooldown > 0) {
                    return null;
                }
                return new WeaveTeamInfo(hostId, memberIds[0]);
            }
            var orderedMembers = memberIds.OrderBy(id => infos[id].Cooldown);
            if (infos[memberIds[0]].Cooldown > 0 && infos[memberIds[1]].Cooldown > 0) {
                return null;
            }
            return new WeaveTeamInfo(hostId, memberIds[0], memberIds[1]);
        }

        private async Task<bool> WeaveAsync(int hostId, List<int> memberIds) {
            if (isRefreshing) {
                return false;
            }
            if (isWeaving) {
                return false;
            }
            isWeaving = true;

            if (memberIds.Count == 1) {
                // Chỉ có 1 thành viên.
                if (infos[hostId].Turns > 1 && autoMake.Checked) {

                } else {

                }
            }
            var orderedMembers = memberIds.OrderBy(id => infos[id].Cooldown);

            isWeaving = false;
            return true;
        }

        /// <summary>
        /// Cập nhật thời gian đóng băng.
        /// </summary>
        /// <returns>Thời gian đóng băng tất cả các tài khoản.</returns>
        private void UpdateCooldown() {
            int maxCooldown = playerIds.Count == 0 ? 0 : playerIds.Max(id => infos[id].Cooldown);
            cooldownLabel.Text = String.Format("Đóng băng: {0}", Utils.FormatDuration(maxCooldown));
        }

        private async void weaveTimer_Tick(object sender, EventArgs e) {
            UpdateCooldown();

            if (timerLocking) {
                return;
            }
            timerLocking = true;
            try {
                if (!autoWeave.Checked) {
                    return;
                }

                if (playerIds.Count == 0) {
                    // Làm mới thông tin tất cả tài khoản.
                    await RefreshPlayersAsync(FindConnectedClients());
                    if (playerIds.Count == 0) {
                        // Không có tài khoản được kết nối.
                        autoWeave.Checked = false;
                    }
                    return;
                }

                if (isRefreshing || isWeaving) {
                    return;
                }

                var hostId = playerIds.FirstOrDefault(id => clients[id].PlayerName == hostInput.Text);
                if (hostId == 0) {
                    // Không tìm thấy chủ tổ đội có tên được nhập.
                    return;
                }

                var memberIds = playerIds.Where(id => id != hostId).ToList();
                if (memberIds.Count == 0) {
                    // Không có thành viên nào.
                    autoWeave.Checked = false;
                    return;
                }

                int maxTurns = memberIds.Max(id => infos[id].Turns);
                if (maxTurns == 0) {
                    // Các tài khoản khác hết lượt dệt.
                    autoWeave.Checked = false;
                    return;
                }

                var team = FindWeaveTeam(hostId, memberIds);
                if (team == null) {
                    return;
                }

                // Kiểm tra lại đóng băng.
                await RefreshPlayerAsync(hostId);

                await WeaveAsync(hostId, memberIds);
            } finally {
                timerLocking = false;
            }
        }

        public void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "45300") {
                var token = JToken.Parse(packet.Message);
                var teamId = (int) token["teamObject"]["teamid"];
                hostingTeamId = teamId;
            }
        }
    }
}
