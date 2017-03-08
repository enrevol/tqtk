using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class McuView : UserControl {
        private IMcuModel model;

        public McuView() {
            InitializeComponent();
        }

        public void SetModel(IMcuModel model) {
            this.model = model;

            UpdateMcu(model.Mcu, model.MaxMcu);
            UpdateMcuCooldown(model.McuCooldown);
            UpdateExtraZhengzhan(model.ExtraZhengzhan);
            UpdateExtraGongji(model.ExtraGongji);
            UpdateExtraZhengfu(model.ExtraZhengfu);
            UpdateExtraNongtian(model.ExtraNongtian);
            UpdateExtraYinkuang(model.ExtraYinkuang);

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
            UpdateMcu(mcu, model.MaxMcu);
        }

        private void OnMaxMcuChanged(object sender, int maxMcu) {
            UpdateMcu(model.Mcu, maxMcu);
        }

        private void OnMcuCooldownChanged(object sender, int milliseconds) {
            UpdateMcuCooldown(milliseconds);
        }

        private void OnExtraZhengzhanChanged(object sender, bool available) {
            UpdateExtraZhengzhan(available);
        }

        private void OnExtraGongjiChanged(object sender, bool available) {
            UpdateExtraGongji(available);
        }

        private void OnExtraZhengfuChanged(object sender, bool available) {
            UpdateExtraZhengfu(available);
        }

        private void OnExtraNongtianChanged(object sender, bool available) {
            UpdateExtraNongtian(available);
        }

        private void OnExtraYinkuangChanged(object sender, bool available) {
            UpdateExtraYinkuang(available);
        }

        private void UpdateMcu(int mcu, int maxMcu) {
            mcuLabel.Text = String.Format("Lượt: {0}/{1}", mcu, maxMcu);
        }

        private void UpdateMcuCooldown(int milliseconds) {
            mcuCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void UpdateExtraZhengzhan(bool available) {
            extraZhengzhanLabel.Visible = available;
        }

        private void UpdateExtraGongji(bool available) {
            extraGongjiLabel.Visible = available;
        }

        private void UpdateExtraZhengfu(bool available) {
            extraZhengfuLabel.Visible = available;
        }

        private void UpdateExtraNongtian(bool available) {
            extraNongtianLabel.Visible = available;
        }

        private void UpdateExtraYinkuang(bool available) {
            extraYinkuangLabel.Visible = available;
        }

        private IPacketWriter packetWriter;
        public void SetPacketWriter(IPacketWriter writer)
        {
            packetWriter = writer;
        }

        private async void btnPhaBangQD_Click(object sender, EventArgs e)
        {
            await packetWriter.SendCommandAsync("11301", "4", "0");
        }
    }
}
