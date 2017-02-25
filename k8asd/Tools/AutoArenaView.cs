using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class AutoArenaView : Form {
        private Dictionary<ArenaInfo, ClientView> mappedClients;
        private List<ArenaInfo> players;

        private bool isRefreshing;
        private int duelCounter;

        public AutoArenaView() {
            InitializeComponent();

            mappedClients = new Dictionary<ArenaInfo, ClientView>();
            players = new List<ArenaInfo>();

            isRefreshing = false;
            duelCounter = 0;
        }

        public void LogInfo(string newMessage) {
            if (logBox.Text.Length > 0) {
                logBox.Text += Environment.NewLine;
            }
            logBox.Text += String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể làm mới!");
                return;
            }
            if (duelCounter > 0) {
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
            var queue = new Queue<ClientView>(connectedClients);

            Action updater = null;
            Action<Packet> callback = null;

            callback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "64005");

                var token = JToken.Parse(packet.Message);
                var player = ArenaInfo.Parse(token);
                mappedClients.Add(player, queue.Dequeue());
                players.Add(player);
                players.Sort((lhs, rhs)
                    => lhs.CurrentPlayer.Rank.CompareTo(rhs.CurrentPlayer.Rank));

                playerList.SetObjects(players, true);

                updater();
            };

            updater = () => {
                if (queue.Count > 0) {
                    var client = queue.Peek();
                    client.SendCommand(callback, "64005");
                } else {
                    isRefreshing = false;
                    LogInfo("Làm mới hoàn thành!");
                }
            };

            updater();
        }

        private bool canDuel(ArenaInfo lower, ArenaInfo upper) {
            return upper.Players.Any(player => player.Id == lower.CurrentPlayer.Id);
        }

        private void duelButton_Click(object sender, EventArgs e) {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể khiêu chiến!");
                return;
            }
            if (duelCounter > 0) {
                LogInfo("Đang khiêu chiến, không thể khiêu chiến!");
                return;
            }
            LogInfo("Bắt đầu khiêu chiến...");

            var availablePlayers = new List<ArenaInfo>();
            foreach (var player in players) {
                bool matched = false;
                if (availablePlayers.Count > 0) {
                    var matchingPlayer = availablePlayers.FirstOrDefault(
                        availablePlayer => canDuel(availablePlayer, player));
                    if (matchingPlayer != null && player.CurrentPlayer.RemainTimes > 0) {
                        matched = true;
                        availablePlayers.Remove(matchingPlayer);
                        LogInfo(String.Format("Tiến hành khiêu chiến: {0} vs. {1}",
                            player.CurrentPlayer.Name, matchingPlayer.CurrentPlayer.Name));
                        ++duelCounter;
                        Action callback = () => {
                            --duelCounter;
                            if (duelCounter == 0) {
                                LogInfo("Khiêu chiến hoàn thành!");
                            }
                        };
                        Duel(callback, mappedClients[matchingPlayer], mappedClients[player],
                            matchingPlayer.CurrentPlayer.Id, matchingPlayer.CurrentPlayer.Rank);
                    }
                }
                if (!matched) {
                    availablePlayers.Add(player);
                }
            }

            if (duelCounter == 0) {
                LogInfo("Không có cặp khiêu chiến!");
            }
        }

        private void Duel(Action callback, IPacketWriter lower, IPacketWriter upper,
            int lowerId, int lowerRank) {
            // Chọn trận ngư lân (trống).
            Action<Packet> selectEmptyFormationCallback = null;

            // Gỡ bỏ toàn bộ tướng.
            Action<Packet> removeAllHeroesCallback = null;

            // Chọn trận truỳ hình (không trống).
            Action<Packet> selectNonEmptyFormationCallback = null;

            // Khiêu chiến.
            Action<Packet> duelCallback = null;

            selectEmptyFormationCallback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "42106");
                lower.SendCommand(removeAllHeroesCallback, "42107", "9");
            };

            removeAllHeroesCallback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "42107");
                upper.SendCommand(selectNonEmptyFormationCallback, "42106", "13");
            };

            selectNonEmptyFormationCallback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "42106");
                upper.SendCommand(duelCallback,
                    "64007", lowerId.ToString(), lowerRank.ToString());
            };

            duelCallback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "64007");
                callback();
            };

            lower.SendCommand(selectEmptyFormationCallback, "42106", "9");
        }
    }
}
