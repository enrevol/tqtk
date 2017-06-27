using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    public class PlayerInfo : IPlayerInfo {
        public event EventHandler PlayerIdChanged;
        public event EventHandler PlayerNameChanged;
        public event EventHandler PlayerLevelChanged;
        public event EventHandler LegionNameChanged;
        public event EventHandler GoldChanged;
        public event EventHandler ReputationChanged;
        public event EventHandler HonorChanged;
        public event EventHandler FoodChanged;
        public event EventHandler MaxFoodChanged;
        public event EventHandler ForceChanged;
        public event EventHandler MaxForceChanged;
        public event EventHandler SilverChanged;
        public event EventHandler MaxSilverChanged;

        private IClient client;

        private long playerId;
        private string playerName;
        private int playerLevel;
        private string legionName;
        private TimeSpan serverTimeOffset;
        private int systemGold;
        private int userGold;
        private int reputation;
        private int honor;
        private int food;
        private int maxFood;
        private int forces;
        private int maxForces;
        private int silver;
        private int maxSilver;

        public IClient Client {
            get { return client; }
            set {
                if (client != null) {
                    client.PacketReceived -= OnPacketReceived;
                }
                client = value;
                if (client != null) {
                    client.PacketReceived += OnPacketReceived;
                }
            }
        }

        public long PlayerId {
            get { return playerId; }
            private set {
                playerId = value;
                PlayerIdChanged.Raise(this);
            }
        }

        public string PlayerName {
            get { return playerName; }
            private set {
                playerName = value;
                PlayerNameChanged.Raise(this);
            }
        }

        public int PlayerLevel {
            get { return playerLevel; }
            private set {
                playerLevel = value;
                PlayerLevelChanged.Raise(this);
            }
        }

        public string LegionName {
            get { return legionName; }
            private set {
                legionName = value;
                LegionNameChanged.Raise(this);
            }
        }

        public DateTime ServerTime {
            get { return DateTime.Now + serverTimeOffset; }
        }

        public int SystemGold {
            get { return systemGold; }
            private set {
                systemGold = value;
                GoldChanged.Raise(this);
            }
        }

        public int UserGold {
            get { return userGold; }
            private set {
                userGold = value;
                GoldChanged.Raise(this);
            }
        }

        public int Gold {
            get { return userGold + systemGold; }
        }

        public int Reputation {
            get { return reputation; }
            private set {
                reputation = value;
                ReputationChanged.Raise(this);
            }
        }

        public int Honor {
            get { return honor; }
            private set {
                honor = value;
                HonorChanged.Raise(this);
            }
        }

        public int Food {
            get { return food; }
            private set {
                food = value;
                FoodChanged.Raise(this);
            }
        }

        public int MaxFood {
            get { return maxFood; }
            private set {
                maxFood = value;
                MaxFoodChanged.Raise(this);
            }
        }

        public int Force {
            get { return forces; }
            private set {
                forces = value;
                ForceChanged.Raise(this);
            }
        }

        public int MaxForce {
            get { return maxForces; }
            private set {
                maxForces = value;
                MaxForceChanged.Raise(this);
            }
        }

        public int Silver {
            get { return silver; }
            private set {
                silver = value;
                SilverChanged.Raise(this);
            }
        }

        public int MaxSilver {
            get { return maxSilver; }
            private set {
                maxSilver = value;
                MaxSilverChanged.Raise(this);
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.Id == 11102) {
                // Vừa đăng nhập xong.
                var token = JToken.Parse(packet.Message);
                var player = token["player"];

                var systime = (string) player["systime"];
                var serverTime = DateTime.Parse(systime);
                serverTimeOffset = serverTime - DateTime.Now;

                PlayerId = packet.UserId;
                PlayerName = (string) player["playername"];
                PlayerLevel = (int) player["playerlevel"];
                LegionName = (string) player["legionname"];
                ParseInfo0(player);

                var limitvalue = token["limitvalue"];
                ParseInfo1(limitvalue);
            }
            if (packet.Id == 11103
                || packet.Id == 11104 // Cập nhật từng phút.
                || packet.Id == 14102 // Tuyển/đào tạo lính.
                || packet.Id == 41102 // Cải tiến.
                ) {
                var token = JToken.Parse(packet.Message);
                var playerupdateinfo = token["playerupdateinfo"];
                if (playerupdateinfo != null) {
                    ParseInfo0(playerupdateinfo);
                    ParseInfo1(playerupdateinfo);
                } else {
                    //
                }
            }
            if (packet.Id == 34108) {
                // Đánh xong NPC.
                var token = JToken.Parse(packet.Message);
                var playerbattleinfo = token["playerbattleinfo"];
                if (playerbattleinfo != null) {
                    ParseInfo0(playerbattleinfo);
                }
            }
            // FIXME.
            /*
            R11103 r11103 = new R11103(cdata);
            if (r11103.contents != null)
                LogText("[" + r11103.title + "] " + r11103.contents);

            if (r11103.tokencdusable != null)
                tokencdusable = r11103.tokencdusable;

            if (r11103.year != null)
                grpCd.Text = r11103.year + V.listseason[Convert.ToInt32(r11103.season) - 1];

            if (r11103.isimposelimit != null)
                isimposelimit = r11103.isimposelimit;

            if (c41304)
                goto case "41302";

            if (c41100s)
                goto case "41100s";
                */
        }

        private void ParseInfo0(JToken token) {
            SystemGold = (int?) token["sys_gold"] ?? SystemGold;
            UserGold = (int?) token["user_gold"] ?? UserGold;
            Reputation = (int?) token["prestige"] ?? Reputation;
            Honor = (int?) token["jyungong"] ?? Honor;
            Food = (int?) token["food"] ?? Food;
            Force = (int?) token["forces"] ?? Force;
            Silver = (int?) token["copper"] ?? Silver;
        }

        private void ParseInfo1(JToken token) {
            MaxFood = (int?) token["maxfood"] ?? MaxFood;
            MaxForce = (int?) token["maxforce"] ?? MaxForce;
            MaxSilver = (int?) token["maxcoin"] ?? MaxSilver;
        }
    }
}
