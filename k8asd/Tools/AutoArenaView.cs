using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class AutoArenaView : Form {
        private Dictionary<ArenaInfo, ClientView> mappedClients;
        private List<ArenaInfo> players;

        private bool isRefreshing;
        private bool isDueling;

        public AutoArenaView() {
            InitializeComponent();

            mappedClients = new Dictionary<ArenaInfo, ClientView>();
            players = new List<ArenaInfo>();

            isRefreshing = false;
            isDueling = false;

            rankColumn.AspectGetter = (object obj) => {
                var player = (ArenaInfo) obj;
                return String.Format("{0} / {1}", player.CurrentPlayer.Rank, player.CurrentPlayer.TopRank);
            };
            cascadeColumn.AspectGetter = (object obj) => {
                var player = (ArenaInfo) obj;
                return String.Format("{0} / {1}", player.CurrentPlayer.Cascade, player.CurrentPlayer.TopCascade);
            };
            cooldownColumn.AspectGetter = (object obj) => {
                var player = (ArenaInfo) obj;
                return Utils.FormatDuration(player.Cooldown);
            };

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
            await RefreshPlayersAsync();
        }

        /// <summary>
        /// Cập nhật võ đài tất cả các tài khoản đang kết nối.
        /// </summary>
        private async Task RefreshPlayersAsync() {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể làm mới!");
                return;
            }
            if (isDueling) {
                LogInfo("Đang khiêu chiến, không thể làm mới!");
                return;
            }
            LogInfo("Bắt đầu làm mới...");
            isRefreshing = true;

            var clients = ClientManager.Instance.Clients;
            var connectedClients = new List<ClientView>();
            foreach (var client in clients) {
                if (client.Connected) {
                    connectedClients.Add(client);
                }
            }

            mappedClients.Clear();
            players.Clear();
            playerList.Items.Clear();

            foreach (var client in connectedClients) {
                var packet = await client.RefreshArenaAsync();
                if (packet != null) {
                    Debug.Assert(packet.CommandId == "64005");

                    var token = JToken.Parse(packet.Message);
                    var player = ArenaInfo.Parse(token);
                    mappedClients.Add(player, client);
                    players.Add(player);
                    players.Sort((lhs, rhs)
                        => lhs.CurrentPlayer.Rank.CompareTo(rhs.CurrentPlayer.Rank));
                    playerList.SetObjects(players, true);
                }
            }

            LogInfo("Làm mới hoàn thành!");
            isRefreshing = false;
        }

        /// <summary>
        /// Kiểm tra xem người chơi upper có đánh được người chơi lower không?
        /// </summary>
        private bool canDuel(ArenaInfo lower, ArenaInfo upper) {
            return upper.Players.Any(player => player.Id == lower.CurrentPlayer.Id);
        }

        private async void duelButton_Click(object sender, EventArgs e) {
            await DuelAndRefreshAsync();
            await DuelAndRefreshAsync();
            await DuelAndRefreshAsync();
        }

        private async Task DuelAndRefreshAsync() {
            await DuelAsync();
            await RefreshPlayersAsync();
        }

        /// <summary>
        /// Khiêu chiến tất cả các tài khoản.
        /// </summary>
        private async Task DuelAsync() {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể khiêu chiến!");
                return;
            }
            if (isDueling) {
                LogInfo("Đang khiêu chiến, không thể khiêu chiến!");
                return;
            }
            LogInfo("Bắt đầu khiêu chiến...");
            isDueling = true;

            // Danh sách các người chơi chưa có cặp.
            var availablePlayers = new List<ArenaInfo>();

            var duelTasks = new List<Task<bool>>();

            foreach (var player in players) {
                // Đã cặp đươc chưa?
                bool matched = false;
                if (availablePlayers.Count > 0) {
                    // Tìm người có thể cặp.
                    var matchingPlayer = availablePlayers.FirstOrDefault(
                        availablePlayer => canDuel(availablePlayer, player));
                    if (matchingPlayer != null && player.CurrentPlayer.RemainTimes > 0 && player.Cooldown == 0) {
                        matched = true;
                        availablePlayers.Remove(matchingPlayer);
                        LogInfo(String.Format("Tiến hành khiêu chiến: {0} vs. {1}",
                            player.CurrentPlayer.Name, matchingPlayer.CurrentPlayer.Name));
                        duelTasks.Add(DuelAsync(mappedClients[matchingPlayer], mappedClients[player],
                            matchingPlayer.CurrentPlayer.Id, matchingPlayer.CurrentPlayer.Rank));
                    }
                }
                if (!matched) {
                    // Không cặp được, thêm vào danh sách chưa cặp.
                    availablePlayers.Add(player);
                }
            }

            if (duelTasks.Count == 0) {
                LogInfo("Không có cặp khiêu chiến!");
            } else {
                await Task.WhenAll(duelTasks);
                LogInfo("Khiêu chiến hoàn thành!");
            }
            isDueling = false;
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
            var p0 = await lower.SetDefaultFormationAsync(9);
            if (p0 == null) {
                return false;
            }
            Debug.Assert(p0.CommandId == "42104");

            // Gỡ bỏ toàn bộ tướng.
            var p1 = await lower.RemoveAllHeroesFromFormationAsync(9);
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

        private async void autoDuelCheck_CheckedChanged(object sender, EventArgs e) {
            if (autoDuelCheck.Checked) {
                await RefreshPlayersAsync();
            }
        }

        private async void timerArena_Tick(object sender, EventArgs e) {
            if (players.Count == 0) {
                LogInfo("Không có tài khoản để khiêu chiến.");
                autoDuelCheck.Checked = false;
                return;
            }

            int maxCooldown = players.Max(player => player.Cooldown);
            cooldownLabel.Text = String.Format("Đóng băng: {0}", Utils.FormatDuration(maxCooldown));

            if (!autoDuelCheck.Checked) {
                return;
            }

            if (isRefreshing || isDueling) {
                return;
            }

            int maxRemainTimes = players.Max(player => player.CurrentPlayer.RemainTimes);
            if (maxRemainTimes == 0) {
                LogInfo("Hết số lần khiêu chiến.");
                autoDuelCheck.Checked = false;
                return;
            }

            if (maxCooldown > 0) {
                return;
            }

            await RefreshPlayersAsync();
            int recheckedMaxCooldown = players.Max(player => player.Cooldown);
            if (recheckedMaxCooldown > 0) {
                // Kiểm tra lại.
                return;
            }

            await DuelAndRefreshAsync();
            await DuelAndRefreshAsync();
            await DuelAndRefreshAsync();
            await DuelAndRefreshAsync();
        }
    }
}