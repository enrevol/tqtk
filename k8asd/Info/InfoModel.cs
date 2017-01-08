using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class InfoModel : IInfoModel, IPacketReader {
        private string playerName;
        private int playerLevel;
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
            set {
                playerName = value;
                PlayerNameChanged(this, value);
            }
        }

        public int PlayerLevel {
            get { return playerLevel; }
            set {
                playerLevel = value;
                PlayerLevelChanged(this, value);
            }
        }

        public int SystemGold {
            get { return systemGold; }
            set {
                systemGold = value;
                GoldChanged(this, Gold);
            }
        }

        public int UserGold {
            get { return userGold; }
            set {
                userGold = value;
                GoldChanged(this, Gold);
            }
        }

        public int Gold {
            get { return userGold + systemGold; }
        }

        public int Reputation {
            get { return reputation; }
            set {
                reputation = value;
                ReputationChanged(this, value);
            }
        }

        public int Honor {
            get { return honor; }
            set {
                honor = value;
                HonorChanged(this, value);
            }
        }

        public int Food {
            get { return food; }
            set {
                food = value;
                FoodChanged(this, value);
            }
        }

        public int MaxFood {
            get { return maxFood; }
            set {
                maxFood = value;
                MaxFoodChanged(this, value);
            }
        }

        public int Force {
            get { return forces; }
            set {
                forces = value;
                ForceChanged(this, value);
            }
        }

        public int MaxForce {
            get { return maxForces; }
            set {
                maxForces = value;
                MaxForceChanged(this, value);
            }
        }

        public int Silver {
            get { return silver; }
            set {
                silver = value;
                SilverChanged(this, value);
            }
        }

        public int MaxSilver {
            get { return maxSilver; }
            set {
                maxSilver = value;
                MaxSilverChanged(this, value);
            }
        }

        public void OnPacketReceived(Packet packet) {
            var token = JToken.Parse(packet.Message);
            if (packet.CommandId == "11102") {
                var player = token["player"];
                PlayerName = (string) player["playername"];
                PlayerLevel = (int) player["playerlevel"];
                SystemGold = (int) player["sys_gold"];
                UserGold = (int) player["user_gold"];
                Reputation = (int) player["prestige"];
                Honor = (int) player["jyungong"];
                Food = (int) player["food"];
                Force = (int) player["forces"];
                Silver = (int) player["copper"];

                var limitvalue = token["limitvalue"];
                MaxFood = (int) limitvalue["maxfood"];
                MaxForce = (int) limitvalue["maxforce"];
                MaxSilver = (int) limitvalue["maxcoin"];
            }
            if (packet.CommandId == "11103") {
                var playerupdateinfo = token["playerupdateinfo"];
                if (playerupdateinfo != null) {
                    SystemGold = (int?) playerupdateinfo["sys_gold"] ?? SystemGold;
                    UserGold = (int?) playerupdateinfo["user_gold"] ?? UserGold;
                    if (playerupdateinfo["prestige"] != null) {
                        Reputation = (int) playerupdateinfo["prestige"];
                    }
                    if (playerupdateinfo["jyungong"] != null) {
                        Honor = (int) playerupdateinfo["jyungong"];
                    }
                    if (playerupdateinfo["food"] != null) {
                        Food = (int) playerupdateinfo["food"];
                    }
                    if (playerupdateinfo["maxfood"] != null) {
                        MaxFood = (int) playerupdateinfo["maxfood"];
                    }
                    if (playerupdateinfo["forces"] != null) {
                        Force = (int) playerupdateinfo["forces"];
                    }
                    if (playerupdateinfo["maxforce"] != null) {
                        MaxForce = (int) playerupdateinfo["maxforces"];
                    }
                    if (playerupdateinfo["copper"] != null) {
                        Silver = (int) playerupdateinfo["copper"];
                    }
                    if (playerupdateinfo["maxcoin"] != null) {
                        MaxSilver = (int) playerupdateinfo["maxcoin"];
                    }
                } else {
                    //
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
    }
}
