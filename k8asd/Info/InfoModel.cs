using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class InfoModel : IInfoModel {
        private IPacketWriter packetWriter;

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

        public event EventHandler<string> PlayerNameChanged;
        public event EventHandler<int> PlayerLevelChanged;
        public event EventHandler<string> LegionNameChanged;
        public event EventHandler<int> GoldChanged;
        public event EventHandler<int> ReputationChanged;
        public event EventHandler<int> HonorChanged;
        public event EventHandler<int> FoodChanged;
        public event EventHandler<int> MaxFoodChanged;
        public event EventHandler<int> ForceChanged;
        public event EventHandler<int> MaxForceChanged;
        public event EventHandler<int> SilverChanged;
        public event EventHandler<int> MaxSilverChanged;

        public string PlayerName {
            get { return playerName; }
            private set {
                playerName = value;
                PlayerNameChanged.Raise(this, value);
            }
        }

        public int PlayerLevel {
            get { return playerLevel; }
            private set {
                playerLevel = value;
                PlayerLevelChanged.Raise(this, value);
            }
        }

        public string LegionName {
            get { return legionName; }
            private set {
                legionName = value;
                LegionNameChanged.Raise(this, value);
            }
        }

        public DateTime ServerTime {
            get { return DateTime.Now + serverTimeOffset; }
        }

        public int SystemGold {
            get { return systemGold; }
            private set {
                systemGold = value;
                GoldChanged.Raise(this, Gold);
            }
        }

        public int UserGold {
            get { return userGold; }
            private set {
                userGold = value;
                GoldChanged.Raise(this, Gold);
            }
        }

        public int Gold {
            get { return userGold + systemGold; }
        }

        public int Reputation {
            get { return reputation; }
            private set {
                reputation = value;
                ReputationChanged.Raise(this, value);
            }
        }

        public int Honor {
            get { return honor; }
            private set {
                honor = value;
                HonorChanged.Raise(this, value);
            }
        }

        public int Food {
            get { return food; }
            private set {
                food = value;
                FoodChanged.Raise(this, value);
            }
        }

        public int MaxFood {
            get { return maxFood; }
            private set {
                maxFood = value;
                MaxFoodChanged.Raise(this, value);
            }
        }

        public int Force {
            get { return forces; }
            private set {
                forces = value;
                ForceChanged.Raise(this, value);
            }
        }

        public int MaxForce {
            get { return maxForces; }
            private set {
                maxForces = value;
                MaxForceChanged.Raise(this, value);
            }
        }

        public int Silver {
            get { return silver; }
            private set {
                silver = value;
                SilverChanged.Raise(this, value);
            }
        }

        public int MaxSilver {
            get { return maxSilver; }
            private set {
                maxSilver = value;
                MaxSilverChanged.Raise(this, value);
            }
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "11102") {
                // Vừa đăng nhập xong.
                var token = JToken.Parse(packet.Message);
                var player = token["player"];

                var systime = (string) player["systime"];
                var serverTime = DateTime.Parse(systime);
                serverTimeOffset = serverTime - DateTime.Now;

                PlayerName = (string) player["playername"];
                PlayerLevel = (int) player["playerlevel"];
                LegionName = (string) player["legionname"];
                ParseInfo0(player);

                var limitvalue = token["limitvalue"];
                ParseInfo1(limitvalue);
            }
            if (packet.CommandId == "11103"
                || packet.CommandId == "14102" // Tuyển/đào tạo lính.
                || packet.CommandId == "41102" // Cải tiến
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
            if (packet.CommandId == "34108") {
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
