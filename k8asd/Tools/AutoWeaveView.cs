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

        private Dictionary<WeaveInfo, ClientView> mappedClients;
        private List<WeaveInfo> infos;

        private int hostingTeamId;
        private bool isRefreshing;
        private bool isWeaving;
        private bool timerLocking;

        public AutoWeaveView() {
            InitializeComponent();

            mappedClients = new Dictionary<WeaveInfo, ClientView>();
            infos = new List<WeaveInfo>();

            hostingTeamId = NoTeam;
            isRefreshing = false;
            isWeaving = false;
            timerLocking = false;

            spinnerLevelColumn.AspectGetter = obj => ((WeaveInfo) obj).Level;
            successRateColumn.AspectGetter = obj => ((WeaveInfo) obj).SuccessRate;
            criticalRateColumn.AspectGetter = obj => ((WeaveInfo) obj).CriticalRate;
            priceColumn.AspectGetter = obj => {
                var info = (WeaveInfo) obj;
                return String.Format("{0} {1}", info.Price,
                    (info.PriceWay == WeavePriceWay.Up ? "▲" : "▼"));
            };
            turnColumn.AspectGetter = obj => ((WeaveInfo) obj).Turns;
            nameColumn.AspectGetter = obj => mappedClients[(WeaveInfo) obj].PlayerName;
            cooldownColumn.AspectGetter = obj => Utils.FormatDuration(((WeaveInfo) obj).Cooldown);

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

            mappedClients.Clear();
            infos.Clear();
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

                mappedClients.Add(info, client);
                infos.Add(info);
                playerList.SetObjects(infos);
            }

            isRefreshing = false;
            return true;
        }

        private async Task<bool> RefreshPlayerAsync(WeaveInfo weaveInfo) {
            if (isRefreshing) {
                return false;
            }
            isRefreshing = true;
            try {
                var index = infos.FindIndex(info => info == weaveInfo);
                Debug.Assert(index != -1);

                var client = mappedClients[weaveInfo];
                var packet = await client.RefreshWeaveAsync();
                if (packet == null) {
                    return false;
                }

                var token = JToken.Parse(packet.Message);
                infos[index] = WeaveInfo.Parse(token);
                playerList.SetObjects(infos);
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
            public WeaveInfo Host { get; private set; }
            public WeaveInfo Slot1 { get; private set; }
            public WeaveInfo Slot2 { get; private set; }

            public WeaveTeamInfo(WeaveInfo host, WeaveInfo slot1) {
                Host = host;
                Slot1 = slot1;
                Slot2 = null;
            }

            public WeaveTeamInfo(WeaveInfo host, WeaveInfo slot1, WeaveInfo slot2) {
                Host = host;
                Slot1 = slot1;
                Slot2 = slot2;
            }
        }

        private WeaveTeamInfo FindWeaveTeam(WeaveInfo host, List<WeaveInfo> members) {
            if (host.Cooldown > 0) {
                return null;
            }
            if (members.Count == 0) {
                return null;
            }
            if (members.Count == 1) {
                if (members[0].Cooldown > 0) {
                    return null;
                }
                return new WeaveTeamInfo(host, members[0]);
            }
            var orderedMembers = members.OrderBy(info => info.Cooldown);
            if (members[0].Cooldown > 0 && members[1].Cooldown > 0) {
                return null;
            }
            return new WeaveTeamInfo(host, members[0], members[1]);
        }

        private async Task<bool> RecheckCooldown(WeaveInfo info) {
            var client = mappedClients[info];
            var ok = await RefreshPlayerAsync(info);
            return ok;
        }

        private async Task<bool> WeaveAsync(WeaveInfo host, List<WeaveInfo> members) {
            if (isRefreshing) {
                return false;
            }
            if (isWeaving) {
                return false;
            }
            isWeaving = true;

            if (members.Count == 1) {
                // Chỉ có 1 thành viên.
                if (host.Turns > 1 && autoMake.Checked) {

                } else {

                }
            }
            var orderedMembers = members.OrderBy(info => info.Cooldown);

            isWeaving = false;
            return true;
        }

        /// <summary>
        /// Cập nhật thời gian đóng băng.
        /// </summary>
        /// <returns>Thời gian đóng băng tất cả các tài khoản.</returns>
        private void UpdateCooldown() {
            int maxCooldown = infos.Count == 0 ? 0 : infos.Max(info => info.Cooldown);
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

                if (infos.Count == 0) {
                    // Làm mới thông tin tất cả tài khoản.
                    await RefreshPlayersAsync(FindConnectedClients());
                    if (infos.Count == 0) {
                        // Không có tài khoản được kết nối.
                        autoWeave.Checked = false;
                        return;
                    }
                }

                if (isRefreshing || isWeaving) {
                    return;
                }

                var hostInfo = infos.FirstOrDefault(info => mappedClients[info].PlayerName == hostInput.Text);
                if (hostInfo == null) {
                    // Không tìm thấy chủ tổ đội có tên được nhập.
                    return;
                }

                var memberInfos = infos.Where(info => info != hostInfo).ToList();
                if (memberInfos.Count == 0) {
                    // Không có tài khoản thành viên nào.
                    autoWeave.Checked = false;
                    return;
                }

                int maxTurns = memberInfos.Max(info => info.Turns);
                if (maxTurns == 0) {
                    // Các tài khoản khác hết lượt dệt.
                    autoWeave.Checked = false;
                    return;
                }

                var team = FindWeaveTeam(hostInfo, memberInfos);
                if (team == null) {
                    return;
                }

                // Kiểm tra lại đóng băng.
                await RefreshPlayerAsync(hostInfo);

                await WeaveAsync(hostInfo, memberInfos);
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
