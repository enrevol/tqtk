using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace k8asd {
    class CooldownModel : ICooldownModel, IPacketReader {
        private Cooldown imposeCooldown;
        private Cooldown guideCooldown;
        private Cooldown upgradeCooldown;
        private Cooldown appointCooldown;
        private Cooldown techCooldown;
        private Cooldown weaveCooldown;
        private Timer oneSecondTimer;

        public event EventHandler<int> ImposeCooldownChanged;
        public event EventHandler<int> GuideCooldownChanged;
        public event EventHandler<int> UpgradeCooldownChanged;
        public event EventHandler<int> AppointCooldownChanged;
        public event EventHandler<int> TechCooldownChanged;
        public event EventHandler<int> WeaveCooldownChanged;

        public CooldownModel() {
            imposeCooldown = new Cooldown();
            guideCooldown = new Cooldown();
            upgradeCooldown = new Cooldown();
            appointCooldown = new Cooldown();
            techCooldown = new Cooldown();
            weaveCooldown = new Cooldown();

            oneSecondTimer = new Timer();
            oneSecondTimer.Interval = 1000;
            oneSecondTimer.Tick += OneSecondTimer_Tick;
            oneSecondTimer.Start();
        }

        private void OneSecondTimer_Tick(object sender, EventArgs e) {
            UpdateCooldowns();
        }

        private void UpdateCooldowns() {
            ImposeCooldownChanged.Raise(this, ImposeCooldown);
            GuideCooldownChanged.Raise(this, GuideCooldown);
            UpgradeCooldownChanged.Raise(this, UpgradeCooldown);
            AppointCooldownChanged.Raise(this, AppointCooldown);
            TechCooldownChanged.Raise(this, TechCooldown);
            WeaveCooldownChanged.Raise(this, WeaveCooldown);
        }

        public int ImposeCooldown {
            get { return imposeCooldown.RemainingMilliseconds; }
            private set {
                imposeCooldown.RemainingMilliseconds = value;
                UpdateCooldowns();
            }
        }

        public int GuideCooldown {
            get { return guideCooldown.RemainingMilliseconds; }
            private set {
                guideCooldown.RemainingMilliseconds = value;
                UpdateCooldowns();

            }
        }

        public int UpgradeCooldown {
            get { return upgradeCooldown.RemainingMilliseconds; }
            private set {
                upgradeCooldown.RemainingMilliseconds = value;
                UpdateCooldowns();
            }
        }

        public int AppointCooldown {
            get { return appointCooldown.RemainingMilliseconds; }
            private set {
                appointCooldown.RemainingMilliseconds = value;
                UpdateCooldowns();
            }
        }

        public int TechCooldown {
            get { return techCooldown.RemainingMilliseconds; }
            private set {
                techCooldown.RemainingMilliseconds = value;
                UpdateCooldowns();
            }
        }

        public int WeaveCooldown {
            get { return weaveCooldown.RemainingMilliseconds; }
            private set {
                weaveCooldown.RemainingMilliseconds = value;
                UpdateCooldowns();
            }
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "11102") {
                var token = JToken.Parse(packet.Message);
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
                var token = JToken.Parse(packet.Message);
                if (token["message"] == null) {
                    var cd = (int) token["cd"];
                    GuideCooldown = cd;
                }
            }
            if (packet.CommandId == "45200") {
                var token = JToken.Parse(packet.Message);
                // {{ "message": "Ngài vẫn chưa có Xưởng Dệt hoặc cấp độ không đủ" }}
                if (token["message"] == null) {
                    var makecd = (int) token["makecd"];
                    WeaveCooldown = makecd;
                }
            }
        }
    }
}
