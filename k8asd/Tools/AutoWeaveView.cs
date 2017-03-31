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
        private int LineLimit = 500;

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

        private async Task<bool> WeaveAsync(int hostId, WeaveMode mode, params int[] memberIds) {
            var members = memberIds.Select(id => clients[id]).ToArray();
            return await WeaveAsync(clients[hostId], mode, members);
        }

        private async Task<bool> WeaveAsync(IClient host, WeaveMode mode, params IClient[] members) {
            // Lập tổ đội.
            var textileLevel = (int) textileLevelInput.Value;
            try {
                host.PacketReceived += OnPacketReceived;
                var limit = (hostLegionButton.Checked ? WeaveTeamLimit.Legion : WeaveTeamLimit.None);
                var p0 = await host.CreateWeaveAsync(textileLevel, limit);
                if (p0 == null) {
                    return false;
                }
                var state = StatePacket.Parse(p0);
                if (!state.Ok) {
                    LogInfo(String.Format("{0}: {1}", host.PlayerName, state.Message));
                    return false;
                }
            } finally {
                host.PacketReceived -= OnPacketReceived;
            }

            if (hostingTeamId == NoTeam) {
                // Host is in parallel login mode.
                var p = await host.RefreshWeaveAsync();
                if (p == null) {
                    return false;
                }
                var info = WeaveInfo.Parse(JToken.Parse(p.Message));
                var hostingTeam = info.Teams.Find(team => team.Name == host.PlayerName);
                hostingTeamId = hostingTeam.Id;
            }

            try {
                Debug.Assert(hostingTeamId != NoTeam);
                var tasks = new List<Task<Packet>>();
                foreach (var member in members) {
                    tasks.Add(member.JoinWeaveAsync(hostingTeamId));
                }

                // Gia nhập tổ đội.
                var p2s = await Task.WhenAll(tasks);
                int memberIndex = 0;
                foreach (var p in p2s) {
                    if (p == null) {
                        // Mất kết nối.
                        // Huỷ tổ đội.
                        await host.DisbandWeaveAsync(hostingTeamId);
                        return false;
                    }

                    var state = StatePacket.Parse(p);
                    if (!state.Ok) {
                        // Lỗi gia nhập.
                        LogInfo(String.Format("{0}: {1}", members[memberIndex].PlayerName, state.Message));
                        // Huỷ tổ đội.
                        await host.DisbandWeaveAsync(hostingTeamId);
                        return false;
                    }

                    ++memberIndex;
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
            Debug.Assert(memberIds.Count > 0);

            var result = new List<int>();
            if (memberIds.Count == 1) {
                // Chỉ còn 1 thành viên.
                var id = memberIds[0];
                if (infos[id].Cooldown == 0) {
                    // OK.
                    result.Add(id);
                }
                return result;
            }
            
            // Còn >= 2 thành viên.
            int totalTurns = 0;
            foreach (int id in memberIds) {
                totalTurns += infos[id].Turns;
            }

            // Thành viên trong trạng thái phải ưu tiên dệt trước.
            var hurryMemberIds = new List<int>();
            var nonHurryMemberIds = new List<int>();
            foreach (int id in memberIds) {
                int turns = infos[id].Turns;
                int otherTurns = totalTurns - turns;
                if (turns + 1 >= otherTurns) {
                    hurryMemberIds.Add(id);
                } else {
                    if (infos[id].Cooldown == 0 && infos[id].Turns > 0) {
                        nonHurryMemberIds.Add(id);
                    }
                }
            }

            if (hurryMemberIds.Count >= 2) {
                if (hurryMemberIds.Count == 3) {
                    // Case: 1 1 1.
                    // Select any two members.
                } else {
                    // Case: x x 1, e.g. 2 2 1, 3 3 1.
                    // Select the two members.
                }
                hurryMemberIds = hurryMemberIds.Where(id => infos[id].Cooldown == 0).ToList();
                if (hurryMemberIds.Count >= 2) {
                    // Two hurry members.
                    result.Add(hurryMemberIds[0]);
                    result.Add(hurryMemberIds[1]);
                }
                return result;
            }

            if (hurryMemberIds.Count == 1) {
                var id = hurryMemberIds[0];
                if (infos[id].Cooldown == 0) {
                    if (nonHurryMemberIds.Count > 0) {
                        // OK.
                        // One hurry member and one non-hurry member.
                        result.Add(id);
                        result.Add(nonHurryMemberIds[0]);
                    }
                }
                return result;
            }

            Debug.Assert(hurryMemberIds.Count == 0);

            if (nonHurryMemberIds.Count >= 2) {
                // Two non-hurry members.
                result.Add(nonHurryMemberIds[0]);
                result.Add(nonHurryMemberIds[1]);
            }
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

                if (infos[hostId].Turns == 0) {
                    LogInfo("Chủ tổ đội đã hết lượt dệt.");
                    autoWeave.Checked = false;
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

                var partyMemberIds = new List<int>();
                partyMemberIds.AddRange(weaveMemberIds);

                var mode = WeaveMode.PullLevel;
                if (makeTogetherBox.Checked && infos[hostId].Turns > 1) {
                    mode = WeaveMode.WeaveTogether;
                    partyMemberIds.Add(hostId);
                }

                LogInfo(String.Format("Tiến hành dệt với: {0}",
                    String.Join(", ", partyMemberIds.Select(id => clients[id].PlayerName))));
                await WeaveAsync(hostId, mode, weaveMemberIds.ToArray());
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
