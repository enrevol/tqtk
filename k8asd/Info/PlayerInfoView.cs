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
    public partial class PlayerInfoView : UserControl, IClientComponentView<IPlayerInfo> {
        private List<IPlayerInfo> models;

        public PlayerInfoView() {
            InitializeComponent();
            models = null;
        }

        public List<IPlayerInfo> Models {
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
                model.PlayerIdChanged += OnPlayerIdChanged;
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
            UpdateHeader();
            UpdateGold();
            UpdateReputation();
            UpdateHonor();
            UpdateFood();
            UpdateForce();
            UpdateSilver();
            serverTimer.Start();
        }

        public void UnbindModels() {
            serverTimer.Stop();
            if (models == null || models.Count == 0) {
                return;
            }
            foreach (var model in models) {
                model.PlayerIdChanged -= OnPlayerIdChanged;
                model.PlayerNameChanged -= OnPlayerNameChanged;
                model.PlayerLevelChanged -= OnPlayerLevelChanged;
                model.GoldChanged -= OnGoldChanged;
                model.ReputationChanged -= OnReputationChanged;
                model.HonorChanged -= OnHonorChanged;
                model.FoodChanged -= OnFoodChanged;
                model.MaxFoodChanged -= OnMaxFoodChanged;
                model.ForceChanged -= OnForceChanged;
                model.MaxForceChanged -= OnMaxForceChanged;
                model.SilverChanged -= OnSilverChanged;
                model.MaxSilverChanged -= OnMaxSilverChanged;
            }
        }

        private void UpdateHeader() {
            var playerName = (models.Count > 1 ? "???" : models[0].PlayerName);
            var minPlayerLevel = models.Min(item => item.PlayerLevel);
            var maxPlayerLevel = models.Max(item => item.PlayerLevel);
            var playerLevel = (minPlayerLevel == maxPlayerLevel
                ? minPlayerLevel.ToString()
                : String.Format("{0} - {1}", minPlayerLevel, maxPlayerLevel));
            var playerId = (models.Count > 1 ? "???" : models[0].PlayerId.ToString());
            var minTicks = models.Min(item => item.ServerTime.Ticks);
            var maxTicks = models.Max(item => item.ServerTime.Ticks);
            var serverTime = new DateTime((minTicks + maxTicks) / 2).ToString("hh:mm:ss");
            infoBox.Text = String.Format("{0} Lv. {1} - ID: {2} - {3}", playerName, playerLevel, playerId, serverTime);
        }

        private void UpdateFood() {
            var avgFood = (int) models.Average(item => item.Food);
            var avgMaxFood = (int) models.Average(item => item.MaxFood);
            foodLabel.Text = String.Format("{0}/{1}", avgFood, avgMaxFood);
        }

        private void UpdateForce() {
            var avgForce = (int) models.Average(item => item.Force);
            var avgMaxForce = (int) models.Average(item => item.MaxForce);
            forcesLabel.Text = String.Format("{0}/{1}", avgForce, avgMaxForce);
        }

        private void UpdateSilver() {
            var avgSilver = (int) models.Average(item => item.Silver);
            var avgMaxSilver = (int) models.Average(item => item.MaxSilver);
            silverLabel.Text = String.Format("{0}/{1}", avgSilver, avgMaxSilver);
        }

        private void UpdateGold() {
            var avgGold = (int) models.Average(item => item.Gold);
            goldLabel.Text = avgGold.ToString();
        }

        private void UpdateReputation() {
            var avgReputation = (int) models.Average(item => item.Reputation);
            reputationLabel.Text = avgReputation.ToString();
        }

        private void UpdateHonor() {
            var avgHonor = (int) models.Average(item => item.Honor);
            honorLabel.Text = avgHonor.ToString();
        }

        private void OnPlayerIdChanged(object sender, EventArgs e) {
            UpdateHeader();
        }

        private void OnPlayerNameChanged(object sender, EventArgs e) {
            UpdateHeader();
        }

        private void OnPlayerLevelChanged(object sender, EventArgs e) {
            UpdateHeader();
        }

        private void OnGoldChanged(object sender, EventArgs e) {
            UpdateGold();
        }

        private void OnReputationChanged(object sender, EventArgs e) {
            UpdateReputation();
        }

        private void OnHonorChanged(object sender, EventArgs e) {
            UpdateHonor();
        }

        private void OnFoodChanged(object sender, EventArgs e) {
            UpdateFood();
        }

        private void OnMaxFoodChanged(object sender, EventArgs e) {
            UpdateFood();
        }

        private void OnForceChanged(object sender, EventArgs e) {
            UpdateForce();
        }

        private void OnMaxForceChanged(object sender, EventArgs e) {
            UpdateForce();
        }

        private void OnSilverChanged(object sender, EventArgs e) {
            UpdateSilver();
        }

        private void OnMaxSilverChanged(object sender, EventArgs e) {
            UpdateSilver();
        }

        private void serverTimer_Tick(object sender, EventArgs e) {
            UpdateHeader();
        }
    }
}
