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
    public partial class InfoView : UserControl {
        private IInfoModel model;

        public InfoView() {
            InitializeComponent();
        }

        public void SetModel(IInfoModel model) {
            this.model = model;
            serverTimer.Start();
            model.PlayerNameChanged += OnPlayerNameChanged;
            model.PlayerLevelChanged += OnPlayerLevelChanged;
            model.GoldChanged += OnGoldChanged;
            model.ReputationChanged += OnReputationChanged;
            model.HonorChanged += OnHonorChanged;
            model.FoodChanged += OnFoodChanged;
            model.MaxFoodChanged += OnMaxFoodChanged;
            model.ForceChanged += OnForceChanged;
            model.MaxForceChanged += OnMaxForceChanged;
            model.SilverChanged += OnSilverChanged;
            model.MaxSilverChanged += OnMaxSilverChanged;
        }

        private void OnPlayerNameChanged(object sender, string playerName) {
            infoBox.Text = String.Format("{0} Lv. {1}", playerName, model.PlayerLevel);
        }

        private void OnPlayerLevelChanged(object sender, int playerLevel) {
            infoBox.Text = String.Format("{0} Lv. {1} - {0}",
                model.PlayerName, playerLevel, Utils.FormatDuration(model.ServerTime));
        }

        private void OnGoldChanged(object sender, int gold) {
            goldLabel.Text = gold.ToString();
        }

        private void OnReputationChanged(object sender, int reputation) {
            reputationLabel.Text = reputation.ToString();
        }

        private void OnHonorChanged(object sender, int honor) {
            honorLabel.Text = honor.ToString();
        }

        private void OnFoodChanged(object sender, int food) {
            foodLabel.Text = String.Format("{0}/{1}", food, model.MaxFood);
        }

        private void OnMaxFoodChanged(object sender, int maxFood) {
            foodLabel.Text = String.Format("{0}/{1}", model.Food, maxFood);
        }

        private void OnForceChanged(object sender, int force) {
            forcesLabel.Text = String.Format("{0}/{1}", force, model.MaxForce);
        }

        private void OnMaxForceChanged(object sender, int maxForce) {
            forcesLabel.Text = String.Format("{0}/{1}", model.Force, maxForce);
        }

        private void OnSilverChanged(object sender, int silver) {
            silverLabel.Text = String.Format("{0}/{1}", silver, model.MaxSilver);
        }

        private void OnMaxSilverChanged(object sender, int maxSilver) {
            silverLabel.Text = String.Format("{0}/{1}", model.Silver, maxSilver);
        }

        private void serverTimer_Tick(object sender, EventArgs e) {
            infoBox.Text = String.Format("{0} Lv. {1} - {0}",
                model.PlayerName, model.PlayerLevel, Utils.FormatDuration(model.ServerTime));
        }
    }
}
