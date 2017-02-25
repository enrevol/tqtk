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
        private class Player {
            private ArenaView.Player player;
            private Cooldown cooldown;

            public ClientView Client { get; set; }

            public static Player Parse(JToken token) {
                var result = new Player();
                result.cooldown = new Cooldown((int) token["cd"]);
                result.player = ArenaView.Player.Parse(token["playerInfo"]);
                return result;
            }

            public int Id { get { return player.Id; } }
            public int Rank { get { return player.Rank; } }
            public string Nation { get { return player.Nation; } }
            public string Name { get { return player.Name; } }
            public int Level { get { return player.Level; } }
            public string RankDescription { get { return player.RankDescription; } }
            public string CascadeDescription { get { return player.CascadeDescription; } }
            public string Cooldown { get { return Utils.FormatDuration(cooldown.RemainingMilliseconds); } }
        };

        private List<ClientView> connectedClients;
        private List<Player> players;

        private bool isRefreshing;
        private int duelCounter;

        public AutoArenaView() {
            InitializeComponent();

            connectedClients = new List<ClientView>();
            players = new List<Player>();

            isRefreshing = false;
            duelCounter = 0;
        }

        private ClientView FindClient(int playerId) {
            foreach (var client in connectedClients) {
                if (client.PlayerId == playerId) {
                    return client;
                }
            }
            return null;
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            if (isRefreshing) {
                return;
            }
            if (duelCounter > 0) {
                return;
            }
            isRefreshing = true;

            var clients = ClientManager.Instance.Clients;
            connectedClients.Clear();
            foreach (var client in clients) {
                if (client.Connected) {
                    connectedClients.Add(client);
                }
            }

            players.Clear();
            playerList.Items.Clear();
            var queue = new Queue<ClientView>(connectedClients);

            Action updater = null;
            Action<Packet> callback = null;

            callback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "64005");

                var token = JToken.Parse(packet.Message);
                var player = Player.Parse(token);
                player.Client = queue.Dequeue();
                players.Add(player);
                players.Sort((lhs, rhs) => lhs.Rank.CompareTo(rhs.Rank));

                playerList.SetObjects(players, true);

                updater();
            };

            updater = () => {
                if (queue.Count > 0) {
                    var client = queue.Peek();
                    client.SendCommand(callback, "64005");
                } else {
                    isRefreshing = false;
                }
            };

            updater();
        }

        private void duelButton_Click(object sender, EventArgs e) {
            if (isRefreshing) {
                return;
            }
            if (duelCounter > 0) {
                return;
            }

            var previousPlayers = new Player[10];
            foreach (var player in players) {
                var ending = player.Rank % 10;
                if (previousPlayers[ending] != null) {
                    var previousRank = previousPlayers[ending].Rank;
                    if (previousRank + 90 >= player.Rank) {
                        duelCounter += 2;
                        Duel(() => {
                            --duelCounter;
                            Duel(() => {
                                --duelCounter;
                            }, player, previousPlayers[ending]);
                        }, previousPlayers[ending], player);
                    } else {
                        previousPlayers[ending] = player;
                    }
                } else {
                    previousPlayers[ending] = player;
                }
            }
        }

        private void Duel(Action callback, Player lower, Player upper) {
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
                lower.Client.SendCommand(removeAllHeroesCallback, "42107", "9");
            };

            removeAllHeroesCallback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "42107");
                upper.Client.SendCommand(selectNonEmptyFormationCallback, "42106", "13");
            };

            selectNonEmptyFormationCallback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "42106");
                upper.Client.SendCommand(duelCallback,
                    "64007", lower.Id.ToString(), lower.Rank.ToString());
            };

            duelCallback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "64007");
                if (callback != null) {
                    callback();
                }
            };

            lower.Client.SendCommand(selectEmptyFormationCallback, "42106", "9");
        }
    }
}
