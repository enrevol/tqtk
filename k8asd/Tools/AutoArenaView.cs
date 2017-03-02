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
            RefreshPlayers(() => {
                // Nothing.
            });
        }

        private void RefreshPlayers(Action callback) {
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
            Action<Packet> updateCallback = null;

            updateCallback = (packet) => {
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

            //lay hang vo dai tat ca cac acc
            updater = () => {
                if (queue.Count > 0) {
                    var client = queue.Peek();
                    client.SendCommand(updateCallback, "64005");
                } else {
                    isRefreshing = false;
                    LogInfo("Làm mới hoàn thành!");
                    callback();
                }
            };

            updater();
        }

        private bool canDuel(ArenaInfo lower, ArenaInfo upper) {
            return upper.Players.Any(player => player.Id == lower.CurrentPlayer.Id);
        }

        private void duelButton_Click(object sender, EventArgs e) {
            DuelAndRefresh(() => {
                DuelAndRefresh(() => {
                    // Nothing.
                });
            });
        }

        private void DuelAndRefresh(Action callback) {
            Duel(() => {
                RefreshPlayers(callback);
            });
        }

        private void Duel(Action callback) {
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
                    if (matchingPlayer != null && player.CurrentPlayer.RemainTimes > 0 && player.Cooldown == 0) {
                        matched = true;
                        availablePlayers.Remove(matchingPlayer);
                        LogInfo(String.Format("Tiến hành khiêu chiến: {0} vs. {1}",
                            player.CurrentPlayer.Name, matchingPlayer.CurrentPlayer.Name));
                        ++duelCounter;
                        Action duelCallback = () => {
                            --duelCounter;
                            if (duelCounter == 0) {
                                LogInfo("Khiêu chiến hoàn thành!");
                                callback();
                            }
                        };
                        Duel(duelCallback, mappedClients[matchingPlayer], mappedClients[player],
                            matchingPlayer.CurrentPlayer.Id, matchingPlayer.CurrentPlayer.Rank);
                    }
                }
                if (!matched) {
                    availablePlayers.Add(player);
                }
            }

            if (duelCounter == 0) {
                LogInfo("Không có cặp khiêu chiến!");
                //callback();
                if(chkAutoArena.Checked)
                {
                    count++;
                    this.lbArena.Text = "905";
                    checkAuto = false;
                    if (count == 5)
                    {
                        this.timerArena.Stop();
                    }
                }
            }
        }

        private void Duel(Action callback, IPacketWriter lower, IPacketWriter upper,
            int lowerId, int lowerRank) {
            Action<Packet> selectEmptyFormationCallback = null;
            Action<Packet> removeAllHeroesCallback = null;
            Action<Packet> selectNonEmptyFormationCallback = null;
            Action<Packet> duelCallback = null;
            Action<Packet> restoreFormationCallback = null;

            selectEmptyFormationCallback = (packet) => {
                Debug.Assert(packet.CommandId == "42104");

                // Gỡ bỏ toàn bộ tướng.
                lower.SendCommand(removeAllHeroesCallback, "42107", "9");
            };

            removeAllHeroesCallback = (packet) => {
                Debug.Assert(packet.CommandId == "42107");

                // Chọn trận truỳ hình (không trống).
                upper.SendCommand(selectNonEmptyFormationCallback, "42104", "13");
            };

            selectNonEmptyFormationCallback = (packet) => {
                Debug.Assert(packet.CommandId == "42104");

                // Khiêu chiến.
                upper.SendCommand(duelCallback,
                    "64007", lowerId.ToString(), lowerRank.ToString());
            };

            duelCallback = (packet) => {
                Debug.Assert(packet.CommandId == "64007");

                // Chọn lại trận truỳ hình.
                lower.SendCommand(restoreFormationCallback, "42104", "13");
            };

            restoreFormationCallback = (packet) => {
                Debug.Assert(packet.CommandId == "42104");
                callback();
            };

            // Chọn trận ngư lân.
            lower.SendCommand(selectEmptyFormationCallback, "42104", "9");
        }

        private void chkAutoArena_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAutoArena.Checked)
            {
                this.timerArena.Start();
            }
            else
            {
                this.timerArena.Stop();
            }
        }

        private string convertTime(string gio)
        {
            int dem = int.Parse(gio);
            dem--;
            if (dem <= -1)
                dem = 0;
            return dem + "";
        }
        private int count = 0;
        private bool checkAuto = false;
        private void timerArena_Tick(object sender, EventArgs e)
        {
            this.lbArena.Text = convertTime(this.lbArena.Text);
            if (this.lbArena.Text == "0" && !checkAuto)
            {
                checkAuto = true;
                AutoDuel(() =>
                {
                    DuelAndRefresh(() =>
                    {
                        DuelAndRefresh(() =>
                        {
                            Duel(() =>
                            {
                                count++;
                                checkAuto = false;
                                this.lbArena.Text = "905";
                                if (count == 5)
                                {
                                    this.timerArena.Stop();
                                }
                            });
                        });
                    });
                });
            }
        }

        private void AutoDuel(Action callback)
        {
            RefreshPlayers(() =>
            {
                Duel(() =>
                {
                    RefreshPlayers(callback);
                });
            });
        }
    }
}
