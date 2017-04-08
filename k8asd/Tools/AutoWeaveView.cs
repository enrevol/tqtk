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

        /// <summary>
        /// Làm mới tất cả các tài khoản.
        /// </summary>
        /// <param name="connectedClients">Danh sách tài khoản để làm mới.</param>
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

        /// <summary>
        /// Làm mới một người chơi.
        /// </summary>
        /// <param name="playerId">ID của người chơi cần làm mới.</param>
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
                var p = await host.CreateWeaveAsync(textileLevel, limit);
                if (p == null) {
                    return false;
                }
                if (!p.Ok) {
                    LogInfo(String.Format("{0}: {1}", host.PlayerName, p.Message));
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
                var tasks = new List<Task<StatePacket>>();
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

                    if (!p.Ok) {
                        // Lỗi gia nhập.
                        LogInfo(String.Format("{0}: {1}", members[memberIndex].PlayerName, p.Message));
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

        private class WeaveData {
            public int Id { get; set; }
            public int Turns { get; set; }
            public int Cooldown { get; set; }
        };

        private WeaveData MakeData(int id) {
            var data = new WeaveData();
            data.Id = id;
            data.Turns = infos[id].Turns;
            data.Cooldown = infos[id].Cooldown;
            return data;
        }

        private static List<int> FindWeaveMemberIds(List<WeaveData> memberData) {
            var partyIds = new List<int>();
            if (memberData.Count == 0) {
                return partyIds;
            }

            if (memberData.Count <= 2) {
                // Còn 1 hoặc 2 thành viên.
                // Chờ hết đóng băng rồi dệt.
                if (memberData.All(data => data.Cooldown == 0)) {
                    // Nếu tất cả đều hết đóng băng.
                    partyIds.AddRange(memberData.Select(data => data.Id));
                }
                return partyIds;
            }

            // Còn > 2 thành viên.
            // Tổng số lượt tất cả thành viên.
            int totalTurns = memberData.Sum(data => data.Turns);

            // Thành viên trong trạng thái phải ưu tiên dệt trước.
            var hurryMemberIds = new List<int>();

            // Thành viên trong trạng thái không ưu tiên.
            var nonHurryMemberIds = new List<int>();

            foreach (var data in memberData) {
                Debug.Assert(data.Turns > 0);
                int turns = data.Turns;
                int otherTurns = totalTurns - turns;
                if (turns + 1 >= otherTurns) {
                    hurryMemberIds.Add(data.Id);
                } else {
                    if (data.Cooldown == 0) {
                        nonHurryMemberIds.Add(data.Id);
                    }
                }
            }

            // Ưu tiên ai nhiều lượt dệt trước.
            nonHurryMemberIds = nonHurryMemberIds.OrderByDescending(
                id => memberData.Find(data => data.Id == id).Turns).ToList();

            if (hurryMemberIds.Count >= 2) {
                if (hurryMemberIds.Count == 3) {
                    // Case: 1 1 1.
                    // Select any two members.
                } else {
                    // Case: x x 1, e.g. 2 2 1, 3 3 1.
                    // Select the two members.
                }
                hurryMemberIds = hurryMemberIds.Where(id => memberData.Find(data => data.Id == id).Cooldown == 0).ToList();
                if (hurryMemberIds.Count >= 2) {
                    // Two hurry members.
                    partyIds.Add(hurryMemberIds[0]);
                    partyIds.Add(hurryMemberIds[1]);
                }
                return partyIds;
            }

            if (hurryMemberIds.Count == 1) {
                var id = hurryMemberIds[0];
                if (memberData.Find(data => data.Id == id).Cooldown == 0) {
                    if (nonHurryMemberIds.Count > 0) {
                        // OK.
                        // One hurry member and one non-hurry member.
                        partyIds.Add(id);
                        partyIds.Add(nonHurryMemberIds[0]);
                    }
                }
                return partyIds;
            }

            Debug.Assert(hurryMemberIds.Count == 0);

            if (nonHurryMemberIds.Count >= 2) {
                // Two non-hurry members.
                partyIds.Add(nonHurryMemberIds[0]);
                partyIds.Add(nonHurryMemberIds[1]);
            }
            return partyIds;
        }

        private static List<int> FindWeaveMemberIds(WeaveData hostData, List<WeaveData> memberData) {
            Debug.Assert(memberData.Count > 0);
            Debug.Assert(hostData.Cooldown == 0);
            Debug.Assert(hostData.Turns > 1);

            var partyIds = FindWeaveMemberIds(memberData);
            if (partyIds.Count > 0) {
                // Found.
                // Check if host is in hurry state.
                int hostTurns = hostData.Turns - 1;
                var minMemberTurns = ComputeMimimumTurns(memberData.Select(data => data.Turns).ToList());

                if (hostTurns >= minMemberTurns) {
                    // Hurry.
                    partyIds.Add(hostData.Id);
                } else {
                    // Not hurry.
                    // Predict the next party.
                    foreach (var id in partyIds) {
                        var dt = memberData.Find(data => data.Id == id);
                        --dt.Turns;
                        dt.Cooldown = 1;
                    }

                    memberData = memberData.Where(data => data.Turns > 0).ToList();
                    var nextPartyIds = FindWeaveMemberIds(memberData);
                    if (nextPartyIds.Count == 0) {
                        // Can not find the next party.
                        // The host will be in the current party.
                        partyIds.Add(hostData.Id);
                    }
                }
            }
            return partyIds;
        }

        private static int ComputeMimimumTurns(List<int> memberTurns) {
            int totalTurns = memberTurns.Sum();
            int result = totalTurns / 2;
            foreach (var turn in memberTurns) {
                var otherTurns = totalTurns - turn;
                if (turn > otherTurns) {
                    result = otherTurns;
                    break;
                }
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

                if (infos[hostId].Turns == 0) {
                    LogInfo("Chủ tổ đội đã hết lượt dệt!");
                    autoWeave.Checked = false;
                    return;
                }

                var memberIds = playerIds.Where(id => id != hostId && infos[id].Turns > 0).ToList();
                if (memberIds.Count == 0) {
                    LogInfo("Không có thành viên để dệt.");
                    autoWeave.Checked = false;
                    return;
                }

                if (infos[hostId].Cooldown > 0) {
                    return;
                }

                var memberData = new List<WeaveData>();
                foreach (var id in memberIds) {
                    var data = MakeData(id);
                    memberData.Add(data);
                }

                var findingMode = WeaveMode.PullLevel;
                if (makeTogetherBox.Checked && infos[hostId].Turns > 1) {
                    findingMode = WeaveMode.WeaveTogether;
                }

                var partyIds = (findingMode == WeaveMode.PullLevel ?
                    FindWeaveMemberIds(memberData) :
                    FindWeaveMemberIds(MakeData(hostId), memberData));
                if (partyIds.Count == 0) {
                    return;
                }

                var partyMemberIds = partyIds.Where(id => id != hostId).ToList();

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
                foreach (var memberId in partyMemberIds) {
                    if (!await RefreshPlayerAsync(memberId)) {
                        // Mất kết nối.
                        RemovePlayer(memberId);
                        return;
                    }
                    if (infos[memberId].Cooldown > 0) {
                        return;
                    }
                }

                var partyNames = partyIds.Select(id => clients[id].PlayerName).ToList();
                LogInfo(String.Format("Tiến hành dệt với: {0}", String.Join(", ", partyNames)));

                var weavingMode = (partyIds.Contains(hostId) ? WeaveMode.WeaveTogether : WeaveMode.PullLevel);
                if (await WeaveAsync(hostId, weavingMode, partyMemberIds.ToArray())) {
                    // Làm mới thành viên vừa dệt xong.
                    foreach (var id in partyIds) {
                        await RefreshPlayerAsync(id);
                    }
                }
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
