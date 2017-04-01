using System;
using System.Windows.Forms;

namespace k8asd {
    public partial class CooldownView : UserControl {
        ICooldownModel model;

        public CooldownView() {
            InitializeComponent();
        }

        public void SetModel(ICooldownModel model) {
            this.model = model;
            model.ImposeCooldownChanged += OnImposeCooldownChange;
            model.GuideCooldownChanged += OnGuideCooldownChange;
            model.UpgradeCooldownChanged += OnUpgradeCooldownChanged;
            model.AppointCooldownChanged += OnAppointCooldownChanged;
            model.TechCooldownChanged += OnTechCooldownChanged;
            model.WeaveCooldownChanged += OnWeaveCooldownChanged;
            model.DrillCooldownChanged += OnDrillCooldownChanged;
        }

        private void OnImposeCooldownChange(object sender, int milliseconds) {
            imposeCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void OnGuideCooldownChange(object sender, int milliseconds) {
            guideCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void OnUpgradeCooldownChanged(object sender, int milliseconds) {
            upgradeCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void OnAppointCooldownChanged(object sender, int milliseconds) {
            appointCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void OnTechCooldownChanged(object sender, int milliseconds) {
            techCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void OnWeaveCooldownChanged(object sender, int milliseconds) {
            weaveCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }

        private void OnDrillCooldownChanged(object sender, int milliseconds) {
            drillCooldownLabel.Text = Utils.FormatDuration(milliseconds);
        }
    }
}
