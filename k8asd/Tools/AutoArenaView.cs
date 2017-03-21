using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class AutoArenaView : Form {
        /// <summary>
        /// Ánh xạ từ ID sang Client (để gửi/nhận gói tin).
        /// </summary>
        private Dictionary<int, ClientView> clients;

        /// <summary>
        /// Ánh xạ từ ID sang thông tin võ đài (64005).
        /// </summary>
        private Dictionary<int, ArenaInfo> infos;

        /// <summary>
        /// Danh sách ID của người chơi để tự động đánh võ đài.
        /// </summary>
        private List<int> playerIds;

        /// <summary>
        /// Có đang làm mới thông tin võ đài không?
        /// </summary>
        private bool isRefreshing;

        /// <summary>
        /// Có đang khiêu chiên võ đài không?
        /// </summary>
        private bool isDueling;

        private bool timerLocking;

        public AutoArenaView() {
            InitializeComponent();

            clients = new Dictionary<int, ClientView>();
            infos = new Dictionary<int, ArenaInfo>();
            playerIds = new List<int>();

            isRefreshing = false;
            isDueling = false;

            rankColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return String.Format("{0} / {1}", info.CurrentPlayer.Rank, info.CurrentPlayer.TopRank);
            };
            cascadeColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return String.Format("{0} / {1}", info.CurrentPlayer.Cascade, info.CurrentPlayer.TopCascade);
            };
            timesColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return info.CurrentPlayer.RemainTimes;
            };
            nationColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return info.CurrentPlayer.Nation;
            };
            nameColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return info.CurrentPlayer.Name;
            };
            levelColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return info.CurrentPlayer.Level;
            };
            cooldownColumn.AspectGetter = obj => {
                var info = infos[(int) obj];
                return Utils.FormatDuration(info.Cooldown);
            };

            timerLocking = false;
            timerArena.Start();
            timerArena.Interval = 1000; // 1 giây.
        }

        public void LogInfo(string newMessage) {
            if (logBox.Text.Length > 0) {
                logBox.Text += Environment.NewLine;
            }
            logBox.Text += String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshPlayersAsync(FindConnectedClients());
        }

        private List<ClientView> FindConnectedClients() {
            var clients = ClientManager.Instance.Clients;
            var connectedClients = new List<ClientView>();
            foreach (var client in clients) {
                if (client.ConnectionStatus == ConnectionStatus.Connected) {
                    connectedClients.Add(client);
                }
            }
            return connectedClients;
        }

        /// <summary>
        /// Cập nhật võ đài tất cả các tài khoản đang kết nối.
        /// </summary>
        private async Task<bool> RefreshPlayersAsync(List<ClientView> connectedClients) {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể làm mới!");
                return false;
            }
            if (isDueling) {
                LogInfo("Đang khiêu chiến, không thể làm mới!");
                return false;
            }
            LogInfo("Bắt đầu làm mới...");
            isRefreshing = true;

            clients.Clear();
            infos.Clear();
            playerIds.Clear();
            playerList.Items.Clear();

            foreach (var client in connectedClients) {
                var packet = await client.RefreshArenaAsync();
                if (packet == null) {
                    continue;
                }
                Debug.Assert(packet.CommandId == "64005");
                var token = JToken.Parse(packet.Message);

                var errmessage = token["errmessage"];
                if (errmessage != null) {
                    // { "errmessage": "A system error occurred! code:64005" }
                    continue;
                }

                var info = ArenaInfo.Parse(token);
                var playerId = client.PlayerId;
                playerIds.Add(playerId);
                clients.Add(playerId, client);
                infos.Add(playerId, info);

                playerIds.Sort((lhs, rhs) => {
                    var lhsRank = infos[lhs].CurrentPlayer.Rank;
                    var rhsRank = infos[rhs].CurrentPlayer.Rank;
                    return lhsRank.CompareTo(rhsRank);
                });

                playerList.SetObjects(playerIds, true);
            }

            LogInfo("Làm mới hoàn thành!");
            isRefreshing = false;
            return true;
        }

        /// <summary>
        /// Kiểm tra xem người chơi upper có đánh được người chơi lower không?
        /// </summary>
        private bool canDuel(int lowerId, int upperId) {
            var lowerInfo = infos[lowerId];
            Debug.Assert(lowerInfo.CurrentPlayer.Id == lowerId);
            var upperInfo = infos[upperId];
            return upperInfo.Players.Any(player => player.Id == lowerInfo.CurrentPlayer.Id);
        }

        private async void duelButton_Click(object sender, EventArgs e) {
            while (await DuelAndRefreshAsync()) {
                //
            }
        }

        private async Task<bool> DuelAndRefreshAsync() {
            var pairs = FindDuelPairs();
            if (await DuelAsync(pairs)) {
                var clients = FindConnectedClients();
                await RefreshPlayersAsync(clients);
                return true;
            }
            return false;
        }

        private class DuelPair {
            public int Lower { get; private set; }
            public int Upper { get; private set; }

            public DuelPair(int lower, int upper) {
                Lower = lower;
                Upper = upper;
            }
        }

        /// <summary>
        /// Tìm danh sách các cặp có thể đấu.
        /// </summary>
        private List<DuelPair> FindDuelPairs() {
            // Danh sách các người chơi chưa có cặp.
            var availablePlayerIds = new List<int>();

            var result = new List<DuelPair>();

            foreach (var playerId in playerIds) {
                // Đã cặp đươc chưa?
                bool matched = false;
                do {
                    var info = infos[playerId];
                    if (info.CurrentPlayer.RemainTimes == 0) {
                        // Hết lượt.
                        break;
                    }
                    if (info.Cooldown > 0) {
                        // Chưa hết thời gian đóng băng.
                        break;
                    }
                    if (availablePlayerIds.Count == 0) {
                        // Không có ai.
                        break;
                    }
                    // Tìm người có thể cặp.
                    var matchingPlayer = availablePlayerIds.FirstOrDefault(
                        availablePlayer => canDuel(availablePlayer, playerId));

                    if (matchingPlayer == 0) {
                        // Không tìm được ai.
                        break;
                    }

                    // OK.
                    matched = true;
                    availablePlayerIds.Remove(matchingPlayer);

                    result.Add(new DuelPair(matchingPlayer, playerId));
                } while (false);

                if (!matched) {
                    // Không cặp được, thêm vào danh sách chưa cặp.
                    availablePlayerIds.Add(playerId);
                }
            }
            return result;
        }

        /// <summary>
        /// Khiêu chiến tất cả các tài khoản.
        /// </summary>
        /// <returns>True nếu có cặp khiêu chiến.</returns>
        private async Task<bool> DuelAsync(List<DuelPair> pairs) {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể khiêu chiến!");
                return false;
            }
            if (isDueling) {
                LogInfo("Đang khiêu chiến, không thể khiêu chiến!");
                return false;
            }
            if (pairs.Count == 0) {
                LogInfo("Không có cặp khiêu chiến!");
                return false;
            }
            LogInfo("Bắt đầu khiêu chiến...");
            isDueling = true;

            var duelTasks = new List<Task>();
            foreach (var pair in pairs) {
                var lowerId = pair.Lower;
                var upperId = pair.Upper;
                var lowerPlayer = infos[lowerId].CurrentPlayer;
                var upperPlayer = infos[upperId].CurrentPlayer;
                duelTasks.Add(Task.Factory.StartNew(async () => {
                    LogInfo(String.Format("Tiến hành khiêu chiến: {0} vs. {1}", upperPlayer.Name, lowerPlayer.Name));
                    await DuelAsync(clients[lowerId], clients[upperId], lowerPlayer.Id, lowerPlayer.Rank);
                }, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.FromCurrentSynchronizationContext()).Unwrap());
            }
            await Task.WhenAll(duelTasks);

            LogInfo("Khiêu chiến hoàn thành!");
            isDueling = false;
            return true;
        }

        /// <summary>
        /// Tiến hành khiêu chiến giữa 2 người.
        /// </summary>
        /// <param name="lower">Người chơi có thứ hạng cao hơn (số nhỏ hơn).</param>
        /// <param name="upper">Người chơi có thứ hạng thấp hơn (số lớn hơn).</param>
        /// <param name="lowerId">ID của người chơi thứ hạng cao.</param>
        /// <param name="lowerRank">Thứ hạng của người chơi thứ hạng cao.</param>
        /// <returns>True nếu khiêu chiến thành công.</returns>
        private async Task<bool> DuelAsync(IPacketWriter lower, IPacketWriter upper, int lowerId, int lowerRank) {
            // Chọn trận ngư lân.
            var p0 = await lower.SetDefaultFormationAsync(10);
            if (p0 == null) {
                return false;
            }
            Debug.Assert(p0.CommandId == "42104");

            // Gỡ bỏ toàn bộ tướng.
            var p1 = await lower.RemoveAllHeroesFromFormationAsync(10);
            if (p1 == null) {
                return false;
            }
            Debug.Assert(p1.CommandId == "42107");

            // Chọn trận truỳ hình (không trống).
            var p2 = await upper.SetDefaultFormationAsync(13);
            if (p2 == null) {
                return false;
            }
            Debug.Assert(p2.CommandId == "42104");

            // Khiêu chiến.
            var p3 = await upper.DuelArenaAsync(lowerId, lowerRank);
            if (p3 == null) {
                return false;
            }
            Debug.Assert(p3.CommandId == "64007");
            // FIXME: kiểm tra trận có tướng không?
            // FIXME: kiểm tra thứ hạng thay đổi không?

            // Chọn lại trận truỳ hình.
            var p4 = await lower.SetDefaultFormationAsync(13);
            if (p4 == null) {
                return false;
            }
            Debug.Assert(p4.CommandId == "42104");
            return true;
        }

        /// <summary>
        /// Cập nhật thời gian đóng băng.
        /// </summary>
        /// <returns>Thời gian đóng băng lâu nhất.</returns>
        private int UpdateCooldown() {
            int maxCooldown = playerIds.Count == 0 ? 0 : playerIds.Max(id => infos[id].Cooldown);
            cooldownLabel.Text = String.Format("Đóng băng: {0}", Utils.FormatDuration(maxCooldown));
            return maxCooldown;
        }

        private async void timerArena_Tick(object sender, EventArgs e) {
            var maxCooldown = UpdateCooldown();

            if (timerLocking) {
                return;
            }
            timerLocking = true;

            try {
                if (!autoDuelCheck.Checked) {
                    return;
                }

                if (playerIds.Count == 0) {
                    // Lazily refresh players.
                    await RefreshPlayersAsync(FindConnectedClients());
                    if (playerIds.Count == 0) {
                        LogInfo("Không có tài khoản để khiêu chiến.");
                        autoDuelCheck.Checked = false;
                    }
                    return;
                }

                if (isRefreshing || isDueling) {
                    return;
                }

                int maxRemainTimes = playerIds.Max(id => infos[id].CurrentPlayer.RemainTimes);
                if (maxRemainTimes == 0) {
                    LogInfo("Hết số lần khiêu chiến.");
                    autoDuelCheck.Checked = false;
                    return;
                }

                if (maxCooldown > 0) {
                    return;
                }

                // Kiểm tra lại thời gian đóng băng có thật sự là hết chưa.
                await RefreshPlayersAsync(FindConnectedClients());
                if (playerIds.Count == 0) {
                    LogInfo("Không có tài khoản để khiêu chiến.");
                    autoDuelCheck.Checked = false;
                    return;
                }

                int recheckedMaxCooldown = playerIds.Max(id => infos[id].Cooldown);
                if (recheckedMaxCooldown > 0) {
                    // Kiểm tra lại.
                    return;
                }

                int times = 0;
                while (await DuelAndRefreshAsync()) {
                    ++times;
                }

                if (times == 0) {
                    // Không đánh lượt nào vì không có cặp.
                    autoDuelCheck.Checked = false;
                }
            } finally {
                timerLocking = false;
            }
        }

        private void autoDuelCheck_CheckedChanged(object sender, EventArgs e) {

        }
    }
}