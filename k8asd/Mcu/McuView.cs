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
    public partial class McuView : UserControl {
        private IMcuModel model;

        public McuView() {
            InitializeComponent();
        }

        public void SetModel(IMcuModel model) {
            this.model = model;
            model.McuChanged += OnMcuChanged;
            model.MaxMcuChanged += OnMaxMcuChanged;
            model.McuCooldownChanged += OnMcuCooldownChanged;
            model.ExtraZhengzhanChanged += OnExtraZhengzhanChanged;
            model.ExtraGongjiChanged += OnExtraGongjiChanged;
            model.ExtraZhengfuChanged += OnExtraZhengfuChanged;
            model.ExtraNongtianChanged += OnExtraNongtianChanged;
            model.ExtraYinkuangChanged += OnExtraYinkuangChanged;
        }

        private void OnMcuChanged(object sender, int mcu) {
            mcuLabel.Text = String.Format("Lượt: {0}/{1}", mcu, model.MaxMcu);
        }

        private void OnMaxMcuChanged(object sender, int maxMcu) {
            mcuLabel.Text = String.Format("Lượt: {0}/{1}", model.Mcu, maxMcu);
        }

        private void OnMcuCooldownChanged(object sender, int milliseconds) {
            mcuCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void OnExtraZhengzhanChanged(object sender, bool available) {
            extraZhengzhanLabel.Visible = available;
        }

        private void OnExtraGongjiChanged(object sender, bool available) {
            extraGongjiLabel.Visible = available;
        }

        private void OnExtraZhengfuChanged(object sender, bool available) {
            extraZhengfuLabel.Visible = available;
        }

        private void OnExtraNongtianChanged(object sender, bool available) {
            extraNongtianLabel.Visible = available;
        }

        private void OnExtraYinkuangChanged(object sender, bool available) {
            extraYinkuangLabel.Visible = available;
        }
    }
}
