using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set {
                mcu = value;
                McuChanged(this, value);
            }
        }

        public int MaxMcu {
            get { return maxMcu; }
            set {
                maxMcu = value;
                MaxMcuChanged(this, value);
            }
        }

        public int McuCooldown {
            get { return mcuCooldown; }
            set {
                mcuCooldown = value;
                McuCooldownChanged(this, value);
            }
        }

        public bool ExtraZhengzhan {
            get { return extraZhengzhan; }
            set {
                extraZhengzhan = value;
                ExtraZhengzhanChanged(this, value);
            }
        }

        public bool ExtraGongji {
            get { return extraGongji; }
            set {
                extraGongji = value;
                ExtraGongjiChanged(this, value);
            }
        }

        public bool ExtraNongtian {
            get { return extraNongtian; }
            set {
                extraNongtian = value;
                ExtraNongtianChanged(this, value);
            }
        }

        public bool ExtraYinkuang {
            get { return extraYinkuang; }
            set {
                extraYinkuang = value;
                ExtraYinkuangChanged(this, value);
            }
        }

        public bool ExtraZhengfu {
            get { return extraZhengfu; }
            set {
                extraZhengfu = value;
                ExtraZhengfuChanged(this, value);
            }
        }

        public void OnPacketReceived(Packet packet) {
            var token = JToken.Parse(packet.Message);
            if (packet.CommandId == "11102") {
                var player = token["player"];
                if (player != null) {
                    ParseMcu(player);
                }
            }
            if (packet.CommandId == "11103") {
                var playerupdateinfo = token["playerupdateinfo"];
                if (playerupdateinfo != null) {
                    ParseMcu(playerupdateinfo);
                }
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
