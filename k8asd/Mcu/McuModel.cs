using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    class McuModel : IMcuModel, IPacketReader {
        int mcu;
        int maxMcu;
        int mcuCooldown;
        bool extraZhengzhan;
        bool extraGongji;
        bool extraZhengfu;
        bool extraNongtian;
        bool extraYinkuang;

        public event EventHandler<int> MaxMcuChanged;
        public event EventHandler<int> McuChanged;
        public event EventHandler<int> McuCooldownChanged;
        public event EventHandler<bool> ExtraGongjiChanged;
        public event EventHandler<bool> ExtraNongtianChanged;
        public event EventHandler<bool> ExtraYinkuangChanged;
        public event EventHandler<bool> ExtraZhengfuChanged;
        public event EventHandler<bool> ExtraZhengzhanChanged;

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
            get { return mcuCooldown; }
            private set {
                mcuCooldown = value;
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

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "11102") {
                var token = JToken.Parse(packet.Message);
                var player = token["player"];
                if (player != null) {
                    ParseMcu(player);
                }
            }
            if (packet.CommandId == "11103") {
                var token = JToken.Parse(packet.Message);
                var playerupdateinfo = token["playerupdateinfo"];
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
        }
    }
}
