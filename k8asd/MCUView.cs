using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace k8asd {
    /// <summary>
    /// MCU = Millitary call-up points.
    /// </summary>
    public partial class MCUView : UserControl, IPacketReader {
        private int maxMcu;

        public MCUView() {
            InitializeComponent();
        }

        public void SetMCU(int mcu) {
            mcuLabel.Text = String.Format("Lượt: {0}/{1}", mcu, maxMcu);
        }

        public void SetExtraZhengzhan(bool available) {
            extraZhengzhanLabel.Visible = available;
        }

        public void SetExtraGongji(bool available) {
            extraGongjiLabel.Visible = available;
        }

        public void SetExtraZhengfu(bool available) {
            extraZhengfuLabel.Visible = available;
        }

        public void SetExtraNongtian(bool available) {
            extraNongtianLabel.Visible = available;
        }

        public void SetExtraYinkuang(bool available) {
            extraYinkuangLabel.Visible = available;
        }

        public void SetMCUCooldown(int seconds) {
            var span = TimeSpan.FromSeconds(seconds);
            mcuCooldownLabel.Text = String.Format("{0:00}:{1:00}:{2:00}",
                span.Hours, span.Minutes, span.Seconds);
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "11102") {
                var token = JToken.Parse(packet.Message);
                var player = token["player"];
                maxMcu = (int) player["maxtoken"];
                ParseExtraMCU(player);
            }
            if (packet.CommandId == "11103") {
                var token = JToken.Parse(packet.Message);
                var playerupdateinfo = token["playerupdateinfo"];
                ParseExtraMCU(playerupdateinfo);
            }
        }

        private void ParseExtraMCU(JToken token) {
            extraZhengzhanLabel.Visible = (bool) token["extrazhengzhan"];
            extraGongjiLabel.Visible = (bool) token["extragongji"];
            extraZhengfuLabel.Visible = (bool) token["extrazhengfu"];
            extraNongtianLabel.Visible = (bool) token["extranongtian"];
            extraYinkuangLabel.Visible = (bool) token["extrayinkuang"];
        }
    }
}
