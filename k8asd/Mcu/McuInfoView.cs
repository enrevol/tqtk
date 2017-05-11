using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class McuInfoView : UserControl, IMcuInfoView {
        private List<IMcuInfo> models;

        public List<IMcuInfo> Models {
            get { return models; }
            set {
                if (models != null) {
                    foreach (var model in models) {
                        model.McuChanged -= OnMcuChanged;
                        model.MaxMcuChanged -= OnMaxMcuChanged;
                        model.McuCooldownChanged -= OnMcuCooldownChanged;
                        model.ExtraZhengzhanChanged -= OnExtraZhengzhanChanged;
                        model.ExtraGongjiChanged -= OnExtraGongjiChanged;
                        model.ExtraZhengfuChanged -= OnExtraZhengfuChanged;
                        model.ExtraNongtianChanged -= OnExtraNongtianChanged;
                        model.ExtraYinkuangChanged -= OnExtraYinkuangChanged;
                    }
                }
                models = value;
                if (models != null && models.Count > 0) {
                    foreach (var model in models) {
                        model.McuChanged += OnMcuChanged;
                        model.MaxMcuChanged += OnMaxMcuChanged;
                        model.McuCooldownChanged += OnMcuCooldownChanged;
                        model.ExtraZhengzhanChanged += OnExtraZhengzhanChanged;
                        model.ExtraGongjiChanged += OnExtraGongjiChanged;
                        model.ExtraZhengfuChanged += OnExtraZhengfuChanged;
                        model.ExtraNongtianChanged += OnExtraNongtianChanged;
                        model.ExtraYinkuangChanged += OnExtraYinkuangChanged;
                    }
                    UpdateMcu();
                    UpdateMcuCooldown();
                    UpdateExtraTurns();
                }
            }
        }

        public McuInfoView() {
            InitializeComponent();
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
            mcuCooldownLabel.Text = Utils.FormatDuration(minCooldown);
        }

        private void OnMcuChanged(object sender, EventArgs e) {
            UpdateMcu();
        }

        private void OnMaxMcuChanged(object sender, EventArgs e) {
            UpdateMcu();
        }

        private void OnMcuCooldownChanged(object sender, EventArgs e) {
            // UpdateMcuCooldown(milliseconds);
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
    }
}
