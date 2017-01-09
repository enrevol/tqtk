using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    class CooldownModel : ICooldownModel, IPacketReader {
        private DateTime imposeCooldownEndTime;
        private DateTime guideCooldownEndTime;
        private DateTime upgradeCooldownEndTime;
        private DateTime appointCooldownEndTime;
        private DateTime techCooldownEndTime;
        private DateTime weaveCooldownEndTime;
        private Timer oneSecondTimer;

        public event EventHandler<int> ImposeCooldownChanged;
        public event EventHandler<int> GuideCooldownChanged;
        public event EventHandler<int> UpgradeCooldownChanged;
        public event EventHandler<int> AppointCooldownChanged;
        public event EventHandler<int> TechCooldownChanged;
        public event EventHandler<int> WeaveCooldownChanged;

        public CooldownModel() {
            oneSecondTimer = new Timer();
            oneSecondTimer.Interval = 1000;
            oneSecondTimer.Tick += OneSecondTimer_Tick;
            oneSecondTimer.Start();
        }

        private void OneSecondTimer_Tick(object sender, EventArgs e) {
            UpdateCooldowns();
        }

        private void UpdateCooldowns() {
            ImposeCooldownChanged(this, ImposeCooldown);
            GuideCooldownChanged(this, GuideCooldown);
            UpgradeCooldownChanged(this, UpgradeCooldown);
            AppointCooldownChanged(this, AppointCooldown);
            TechCooldownChanged(this, TechCooldown);
            WeaveCooldownChanged(this, WeaveCooldown);
        }

        public int ImposeCooldown {
            get { return imposeCooldownEndTime.RemainingMilliseconds(); }
            set {
                imposeCooldownEndTime = DateTime.Now.AddMilliseconds(value);
                UpdateCooldowns();
            }
        }

        public int GuideCooldown {
            get { return guideCooldownEndTime.RemainingMilliseconds(); }
            set {
                guideCooldownEndTime = DateTime.Now.AddMilliseconds(value);
                UpdateCooldowns();

            }
        }

        public int UpgradeCooldown {
            get { return upgradeCooldownEndTime.RemainingMilliseconds(); }
            set {
                upgradeCooldownEndTime = DateTime.Now.AddMilliseconds(value);
                UpdateCooldowns();
            }
        }

        public int AppointCooldown {
            get { return appointCooldownEndTime.RemainingMilliseconds(); }
            set {
                appointCooldownEndTime = DateTime.Now.AddMilliseconds(value);
                UpdateCooldowns();
            }
        }

        public int TechCooldown {
            get { return techCooldownEndTime.RemainingMilliseconds(); }
            set {
                techCooldownEndTime = DateTime.Now.AddMilliseconds(value);
                UpdateCooldowns();
            }
        }

        public int WeaveCooldown {
            get { return weaveCooldownEndTime.RemainingMilliseconds(); }
            set {
                weaveCooldownEndTime = DateTime.Now.AddMilliseconds(value);
                UpdateCooldowns();
            }
        }

        public void OnPacketReceived(Packet packet) {
            var token = JToken.Parse(packet.Message);
            if (packet.CommandId == "11102") {
                // techcdusable = (string) player["techcdusable"];
                // tokencdusable = (string) player["tokencdusable"];
                // imposecdusable = (string) player["imposecdusable"];
                // guidecdusable = (string) player["guidecdusable"];
                var player = token["player"];
                ImposeCooldown = (int) player["imposecd"];
                GuideCooldown = (int) player["guidecd"];
                TechCooldown = (int) player["techcd"];
            }
            if (packet.CommandId == "41100" ||
                packet.CommandId == "41101" ||
                packet.CommandId == "41102") {
                if (token["message"] == null) {
                    var cd = (int) token["cd"];
                    GuideCooldown = cd;
                }
            }
        }
    }
}
