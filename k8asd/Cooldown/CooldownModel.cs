using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace k8asd {
    class CooldownModel : ICooldownModel {
        private IInfoModel infoModel;
        private IPacketWriter packetWriter;

        private Cooldown imposeCooldown;
        private Cooldown guideCooldown;
        private Cooldown upgradeCooldown;
        private Cooldown appointCooldown;
        private Cooldown techCooldown;
        private Cooldown weaveCooldown;
        private Cooldown drillCooldown;
        private Timer oneSecondTimer;

        public event EventHandler<int> ImposeCooldownChanged;
        public event EventHandler<int> GuideCooldownChanged;
        public event EventHandler<int> UpgradeCooldownChanged;
        public event EventHandler<int> AppointCooldownChanged;
        public event EventHandler<int> TechCooldownChanged;
        public event EventHandler<int> WeaveCooldownChanged;
        public event EventHandler<int> DrillCooldownChanged;

        public CooldownModel() {
            imposeCooldown = new Cooldown();
            guideCooldown = new Cooldown();
            upgradeCooldown = new Cooldown();
            appointCooldown = new Cooldown();
            techCooldown = new Cooldown();
            weaveCooldown = new Cooldown();
            drillCooldown = new Cooldown();

            oneSecondTimer = new Timer();
            oneSecondTimer.Interval = 1000;
            oneSecondTimer.Tick += OneSecondTimer_Tick;
            oneSecondTimer.Start();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
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
            DrillCooldownChanged.Raise(this, DrillCooldown);
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

        public int DrillCooldown {
            get { return drillCooldown.RemainingMilliseconds; }
            private set {
                drillCooldown.RemainingMilliseconds = value;
                UpdateCooldowns();
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
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
            if (packet.CommandId == "62002") {
                var token = JToken.Parse(packet.Message);
                var extraBaseInfo = (JArray) token["extraBaseInfo"];
                if (extraBaseInfo.Count > 0) {
                    var drillToken = extraBaseInfo[extraBaseInfo.Count - 3];
                    var axeDtoList = (JArray) drillToken["axeDtoList"];
                    var normalMining = axeDtoList[0];
                    var rewardTime = (long) normalMining["rewardTime"];
                    DrillCooldown = (int) (Utils.ConvertToLocalTime(infoModel.ServerTime, rewardTime) - DateTime.Now).TotalMilliseconds;
                }
            }
        }
    }
}
