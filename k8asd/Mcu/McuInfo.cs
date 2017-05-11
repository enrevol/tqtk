using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;

namespace k8asd {
    public class McuModel : IMcuInfo {
        public event EventHandler MaxMcuChanged;
        public event EventHandler McuChanged;
        public event EventHandler McuCooldownChanged;
        public event EventHandler ExtraGongjiChanged;
        public event EventHandler ExtraNongtianChanged;
        public event EventHandler ExtraYinkuangChanged;
        public event EventHandler ExtraZhengfuChanged;
        public event EventHandler ExtraZhengzhanChanged;
        public event EventHandler TokencdusableChanged;

        private IClient client;

        private int mcu;
        private int maxMcu;
        private bool extraZhengzhan;
        private bool extraGongji;
        private bool extraZhengfu;
        private bool extraNongtian;
        private bool extraYinkuang;
        private bool tokencdusable;

        private Cooldown mcuCooldown;
        private Timer oneSecondTimer;

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

        public int Mcu {
            get { return mcu; }
            private set {
                mcu = value;
                McuChanged.Raise(this);
            }
        }

        public int MaxMcu {
            get { return maxMcu; }
            private set {
                maxMcu = value;
                MaxMcuChanged.Raise(this);
            }
        }

        public int McuCooldown {
            get { return mcuCooldown.RemainingMilliseconds; }
            private set {
                mcuCooldown.RemainingMilliseconds = value;
                McuCooldownChanged.Raise(this);
            }
        }

        public bool ExtraZhengzhan {
            get { return extraZhengzhan; }
            private set {
                extraZhengzhan = value;
                ExtraZhengzhanChanged.Raise(this);
            }
        }

        public bool ExtraGongji {
            get { return extraGongji; }
            private set {
                extraGongji = value;
                ExtraGongjiChanged.Raise(this);
            }
        }

        public bool ExtraNongtian {
            get { return extraNongtian; }
            private set {
                extraNongtian = value;
                ExtraNongtianChanged.Raise(this);
            }
        }

        public bool ExtraYinkuang {
            get { return extraYinkuang; }
            private set {
                extraYinkuang = value;
                ExtraYinkuangChanged.Raise(this);
            }
        }

        public bool ExtraZhengfu {
            get { return extraZhengfu; }
            private set {
                extraZhengfu = value;
                ExtraZhengfuChanged.Raise(this);
            }
        }

        public bool Tokencdusable {
            get { return tokencdusable; }
            private set {
                tokencdusable = value;
                TokencdusableChanged.Raise(this);
            }
        }

        public McuModel() {
            mcuCooldown = new Cooldown();
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.Id == 11102 ||
                packet.Id == 11104) {
                var token = JToken.Parse(packet.Message);
                var player = token["player"];
                if (player != null) {
                    ParseMcu(player);
                }
            }
            if (packet.Id == 11103 ||
                packet.Id == 11301) {
                var token = JToken.Parse(packet.Message);
                var playerupdateinfo = token["playerupdateinfo"];
                if (packet.Id == 11301) {
                    McuCooldown = 0;
                }
                if (playerupdateinfo != null) {
                    ParseMcu(playerupdateinfo);
                }
            }
            if (packet.Id == 34108) {
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
            Tokencdusable = (bool?) token["tokencdusable"] ?? Tokencdusable;
        }
    }
}
