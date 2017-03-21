using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace k8asd {
    class McuModel : IMcuModel {
        private IPacketWriter packetWriter;

        int mcu;
        int maxMcu;
        int mcuCooldown;
        bool extraZhengzhan;
        bool extraGongji;
        bool extraZhengfu;
        bool extraNongtian;
        bool extraYinkuang;
        bool tokencdusable;

        public event EventHandler<int> MaxMcuChanged;
        public event EventHandler<int> McuChanged;
        public event EventHandler<int> McuCooldownChanged;
        public event EventHandler<bool> ExtraGongjiChanged;
        public event EventHandler<bool> ExtraNongtianChanged;
        public event EventHandler<bool> ExtraYinkuangChanged;
        public event EventHandler<bool> ExtraZhengfuChanged;
        public event EventHandler<bool> ExtraZhengzhanChanged;
        public event EventHandler<bool> TokencdusableChanged;

        private Cooldown qdCooldown;
        private Timer oneSecondTimer;

        public McuModel()
        {
            qdCooldown = new Cooldown();

            oneSecondTimer = new Timer();
            oneSecondTimer.Interval = 1000;
            oneSecondTimer.Tick += OneSecondTimer_Tick;
            oneSecondTimer.Start();
        }
        private void OneSecondTimer_Tick(object sender, EventArgs e)
        {
            UpdateCooldowns();
        }

        private void UpdateCooldowns()
        {
            McuCooldownChanged.Raise(this, McuCooldown);
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        public int Mcu {
            get { return mcu; }
            private set {
                mcu = value;
                McuChanged.Raise(this, value);
            }
        }

        public int MaxMcu {
            get { return maxMcu; }
            private set {
                maxMcu = value;
                MaxMcuChanged.Raise(this, value);
            }
        }

        public int McuCooldown {
            get { return qdCooldown.RemainingMilliseconds; }
            private set {
                //mcuCooldown = value;
                qdCooldown.RemainingMilliseconds = value;
                McuCooldownChanged.Raise(this, value);
            }
        }

        public bool ExtraZhengzhan {
            get { return extraZhengzhan; }
            private set {
                extraZhengzhan = value;
                ExtraZhengzhanChanged.Raise(this, value);
            }
        }

        public bool ExtraGongji {
            get { return extraGongji; }
            private set {
                extraGongji = value;
                ExtraGongjiChanged.Raise(this, value);
            }
        }

        public bool ExtraNongtian {
            get { return extraNongtian; }
            private set {
                extraNongtian = value;
                ExtraNongtianChanged.Raise(this, value);
            }
        }

        public bool ExtraYinkuang {
            get { return extraYinkuang; }
            private set {
                extraYinkuang = value;
                ExtraYinkuangChanged.Raise(this, value);
            }
        }

        public bool ExtraZhengfu {
            get { return extraZhengfu; }
            private set {
                extraZhengfu = value;
                ExtraZhengfuChanged.Raise(this, value);
            }
        }
        public bool Tokencdusable
        {
            get { return tokencdusable; }
            private set
            {
                tokencdusable = value;
                TokencdusableChanged.Raise(this, value);
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "11102") {
                var token = JToken.Parse(packet.Message);
                var player = token["player"];
                if (player != null) {
                    ParseMcu(player);
                }
            }
            if (packet.CommandId == "11103" || packet.CommandId == "11301") {
                var token = JToken.Parse(packet.Message);
                var playerupdateinfo = token["playerupdateinfo"];
                if (packet.CommandId == "11301")
                {
                    McuCooldown = 0;
                }
                if (playerupdateinfo != null) {
                    ParseMcu(playerupdateinfo);
                }
            }
            if (packet.CommandId == "34108") {
                var token = JToken.Parse(packet.Message);
                var playerbattleinfo = token["playerbattleinfo"];
                ParseMcu(playerbattleinfo);
            }
        }

        private void ParseMcu(JToken token) {
            Mcu = (int?) token["token"] ?? Mcu;
            MaxMcu = (int?) token["maxtoken"] ?? MaxMcu;
            McuCooldown = (int?) token["tokencd"] ?? McuCooldown;
            ExtraZhengzhan = (bool?) token["extrazhengzhan"] ?? ExtraZhengzhan;
            ExtraGongji = (bool?) token["extragongji"] ?? ExtraGongji;
            ExtraZhengfu = (bool?) token["extrazhengfu"] ?? ExtraZhengfu;
            ExtraNongtian = (bool?) token["extranongtian"] ?? ExtraNongtian;
            ExtraYinkuang = (bool?) token["extrayinkuang"] ?? ExtraYinkuang;
            Tokencdusable = (bool?)token["tokencdusable"] ?? Tokencdusable;
        }
    }
}
