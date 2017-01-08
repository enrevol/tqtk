using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void OnImposeCooldownChange(object sender, int seconds) {
            imposeCooldownLabel.Text = Utils.FormatDuration(seconds);
        }

        private void OnGuideCooldownChange(object sender, int seconds) {
            guideCooldownLabel.Text = Utils.FormatDuration(seconds);
        }

        private void OnUpgradeCooldownChanged(object sender, int seconds) {
            upgradeCooldownLabel.Text = Utils.FormatDuration(seconds);
        }

        private void OnAppointCooldownChanged(object sender, int seconds) {
            appointCooldownLabel.Text = Utils.FormatDuration(seconds);
        }

        private void OnTechCooldownChanged(object sender, int seconds) {
            techCooldownLabel.Text = Utils.FormatDuration(seconds);
        }

        private void OnWeaveCooldownChanged(object sender, int seconds) {
            weaveCooldownLabel.Text = Utils.FormatDuration(seconds);
        }
    }
}
