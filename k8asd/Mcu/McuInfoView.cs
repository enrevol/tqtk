using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class McuInfoView : UserControl, IClientComponentView<IMcuInfo> {
        private List<IMcuInfo> models;

        public McuInfoView() {
            InitializeComponent();
        }

        public List<IMcuInfo> Models {
            get { return models; }
            set {
                UnbindModels();
                models = value;
                BindModels();
            }
        }

        public void BindModels() {
            if (models == null || models.Count == 0) {
                return;
            }
            foreach (var model in models) {
                model.McuChanged += OnMcuChanged;
                model.MaxMcuChanged += OnMaxMcuChanged;
                model.ExtraZhengzhanChanged += OnExtraZhengzhanChanged;
                model.ExtraGongjiChanged += OnExtraGongjiChanged;
                model.ExtraZhengfuChanged += OnExtraZhengfuChanged;
                model.ExtraNongtianChanged += OnExtraNongtianChanged;
                model.ExtraYinkuangChanged += OnExtraYinkuangChanged;
            }
            UpdateMcu();
            UpdateMcuCooldown();
            UpdateExtraTurns();
            cooldownTimer.Start();
        }

        public void UnbindModels() {
            cooldownTimer.Stop();
            if (models == null || models.Count == 0) {
                return;
            }
            foreach (var model in models) {
                model.McuChanged -= OnMcuChanged;
                model.MaxMcuChanged -= OnMaxMcuChanged;
                model.ExtraZhengzhanChanged -= OnExtraZhengzhanChanged;
                model.ExtraGongjiChanged -= OnExtraGongjiChanged;
                model.ExtraZhengfuChanged -= OnExtraZhengfuChanged;
                model.ExtraNongtianChanged -= OnExtraNongtianChanged;
                model.ExtraYinkuangChanged -= OnExtraYinkuangChanged;
            }
        }

        private void UpdateMcu() {
            var minMcu = models.Min(item => item.Mcu);
            var minMaxMcu = models.Min(item => item.MaxMcu);
            mcuLabel.Text = String.Format("Lượt: {0}/{1}", minMcu, minMaxMcu);
        }

        private void UpdateExtraTurn(Label label, string text, Func<IMcuInfo, bool> func) {
            var allTrue = models.All(func);
            var allFalse = !models.Any(func);
            label.Text = text;
            if (allTrue) {
                label.Visible = true;
            } else if (allFalse) {
                label.Visible = false;
            } else {
                label.Visible = true;
                label.Text = "?";
            }
        }

        private void UpdateExtraTurns() {
            UpdateExtraTurn(extraZhengzhanLabel, "Đ", item => item.ExtraZhengzhan);
            UpdateExtraTurn(extraGongjiLabel, "T", item => item.ExtraGongji);
            UpdateExtraTurn(extraZhengfuLabel, "C", item => item.ExtraZhengfu);
            UpdateExtraTurn(extraNongtianLabel, "R", item => item.ExtraNongtian);
            UpdateExtraTurn(extraYinkuangLabel, "M", item => item.ExtraYinkuang);
        }

        private void UpdateMcuCooldown() {
            var minCooldown = models.Min(item => item.McuCooldown);
            var usable = models.Any(item => item.Tokencdusable);
            mcuCooldownLabel.Text = Utils.FormatDuration(minCooldown);
            if (usable) {
                mcuCooldownLabel.ForeColor = default(Color);
            } else {
                mcuCooldownLabel.ForeColor = Color.Red;
            }
        }

        private void OnMcuChanged(object sender, EventArgs e) {
            UpdateMcu();
        }

        private void OnMaxMcuChanged(object sender, EventArgs e) {
            UpdateMcu();
        }

        private void OnExtraZhengzhanChanged(object sender, EventArgs e) {
            UpdateExtraTurns();
        }

        private void OnExtraGongjiChanged(object sender, EventArgs e) {
            UpdateExtraTurns();
        }

        private void OnExtraZhengfuChanged(object sender, EventArgs e) {
            UpdateExtraTurns();
        }

        private void OnExtraNongtianChanged(object sender, EventArgs e) {
            UpdateExtraTurns();
        }

        private void OnExtraYinkuangChanged(object sender, EventArgs e) {
            UpdateExtraTurns();
        }

        private async void btnPhaBangQD_Click(object sender, EventArgs e) {
            // await packetWriter.SendCommandAsync("11301", "4", "0");
        }

        private void cooldownTimer_Tick(object sender, EventArgs e) {
            UpdateMcuCooldown();
        }
    }
}
