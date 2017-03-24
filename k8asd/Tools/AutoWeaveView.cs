using System;
using System.Collections.Generic;
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

        private Dictionary<int, IClient> clients;
        private Dictionary<int, WeaveInfo> infos;
        private List<int> playerIds;

        private int hostingTeamId;
        private bool isRefreshing;
        private bool isWeaving;
        private bool timerLocking;

        public AutoWeaveView() {
            InitializeComponent();

            clients = new Dictionary<int, IClient>();
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

        public void LogInfo(string newMessage) {
            if (logBox.Text.Length > 0) {
                logBox.Text += Environment.NewLine;
            }
            logBox.Text += String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
        }

        private List<IClient> FindConnectedClients() {
            var clients = ClientManager.Instance.Clients;
            var connectedClients = new List<IClient>();
            foreach (var client in clients) {
                if (client.ConnectionStatus == ConnectionStatus.Connected) {
                    connectedClients.Add(client);
                }
            }
            return connectedClients;
        }

        private async Task<bool> RefreshPlayersAsync(List<IClient> connectedClients) {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể làm mới!");
                return false;
            }
            if (isWeaving) {
                LogInfo("Đang dệt, không thể làm mới!");
                return false;
            }
            LogInfo("Bắt đầu làm mới...");
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

            LogInfo("Làm mới hoàn thành!");
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

        private void RemovePlayer(int playerId) {
            playerIds.Remove(playerId);
            clients.Remove(playerId);
            infos.Remove(playerId);
            playerList.SetObjects(playerIds);
        }

        private async Task<bool> WeaveAsync(int hostId, params int[] memberIds) {
            var members = memberIds.Select(id => clients[id]).ToArray();
            return await WeaveAsync(clients[hostId], WeaveMode.PullLevel, members);
        }

        private async Task<bool> WeaveAsync(IPacketWriter host, WeaveMode mode, params IPacketWriter[] members) {
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
                var tasks = new List<Task<Packet>>();
                foreach (var member in members) {
                    tasks.Add(member.JoinWeaveAsync(hostingTeamId));
                }

                // Gia nhập tổ đội.
                var p2s = await Task.WhenAll(tasks);
                foreach (var p in p2s) {
                    if (p == null) {
                        // Lỗi gia nhập.
                        // Huỷ tổ đội.
                        await host.DisbandWeaveAsync(hostingTeamId);
                        return false;
                    }
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

        private List<int> FindWeaveMemberIds(List<int> memberIds) {
            var result = new List<int>();
            if (memberIds.Count == 0) {
                // Không có ai.
                return result;
            }

            if (memberIds.Count == 1) {
                if (infos[memberIds[0]].Cooldown > 0) {
                    return result;
                }

                // Chỉ có 1 người.
                result.Add(memberIds[0]);
                return result;
            }

            // Ưu tiên dệt người chơi có nhiều lượt nhất trước.
            var orderedMembers = memberIds.OrderByDescending(id => infos[id].Turns).
                ThenBy(id => infos[id].Cooldown).ToList();
            if (infos[orderedMembers[0]].Cooldown > 0 && infos[orderedMembers[1]].Cooldown > 0) {
                return result;
            }
            result.Add(orderedMembers[0]);
            result.Add(orderedMembers[1]);
            return result;
        }

        private async void weaveTimer_Tick(object sender, EventArgs e) {
            if (timerLocking) {
                return;
            }

            foreach (var id in playerIds) {
                var client = clients[id];
                if (client.ConnectionStatus == ConnectionStatus.Disconnected) {
                    LogInfo(String.Format("Tài khoản {0} mất kết nối!", client.PlayerName));
                    RemovePlayer(id);
                    return;
                }
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

                if (hostInput.Text.Length == 0) {
                    LogInfo("Tên chủ tổ đội chưa nhập!");
                    autoWeave.Checked = false;
                    return;
                }

                var hostId = playerIds.FirstOrDefault(id => clients[id].PlayerName == hostInput.Text);
                if (hostId == 0) {
                    LogInfo("Không tìm thấy chủ tổ đội có tên được nhập!");
                    autoWeave.Checked = false;
                    return;
                }

                var memberIds = playerIds.Where(id => id != hostId).ToList();
                if (memberIds.Count == 0) {
                    LogInfo("Không có thành viên để dệt.");
                    autoWeave.Checked = false;
                    return;
                }

                int maxTurns = memberIds.Max(id => infos[id].Turns);
                if (maxTurns == 0) {
                    LogInfo("Đã hết lượt dệt.");
                    autoWeave.Checked = false;
                    return;
                }

                var weaveMemberIds = FindWeaveMemberIds(memberIds);
                if (weaveMemberIds.Count == 0) {
                    return;
                }

                // Kiểm tra lại thời gian đóng băng của chủ tổ đội.
                if (!await RefreshPlayerAsync(hostId)) {
                    // Mất kết nối.
                    RemovePlayer(hostId);
                    return;
                }
                if (infos[hostId].Cooldown > 0) {
                    return;
                }

                // Kiểm tra lại thời gian đóng băng của thành viên.
                foreach (var memberId in weaveMemberIds) {
                    if (!await RefreshPlayerAsync(memberId)) {
                        // Mất kết nối.
                        RemovePlayer(memberId);
                        return;
                    }
                    if (infos[memberId].Cooldown > 0) {
                        return;
                    }
                }

                if (weaveMemberIds.Count == 1) {
                    LogInfo(String.Format("Tiến hành dệt với: {0}", clients[weaveMemberIds[0]].PlayerName));
                } else {
                    LogInfo(String.Format("Tiến hành dệt với: {0}, {1}",
                        clients[weaveMemberIds[0]].PlayerName, clients[weaveMemberIds[1]].PlayerName));
                }
                await WeaveAsync(hostId, weaveMemberIds.ToArray());
            } finally {
                timerLocking = false;
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "45300") {
                var token = JToken.Parse(packet.Message);
                var teamId = (int) token["teamObject"]["teamid"];
                hostingTeamId = teamId;
            }
        }
    }
}
