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
    public partial class HeroTrainingView : UserControl, IPacketReader {
        private class Hero {
            private int id;
            private string name;
            private int level;
            private int exp;
            private int nextExp;
            private int trainFlag;
            private int trainModel;
            private DateTime trainEndTime;
            private int expPerMin;
            private int honorCost;
            private int honorExp;

            public int Id { get { return id; } }
            public string Name { get { return name; } }
            public int Level { get { return level; } }
            public int Exp { get { return exp; } }
            public int NextExp { get { return nextExp; } }

            public bool IsTraining {
                get { return RemainingTime > 0; }
            }

            public int RemainingTime {
                get {
                    if (trainFlag == 0) {
                        return 0;
                    }
                    return trainEndTime.RemainingMilliseconds();
                }
            }

            public int ExpPerMin { get { return expPerMin; } }
            public int HonorCost { get { return honorCost; } }
            public int HonorExp { get { return honorExp; } }

            public Hero(int id, string name, int level, int exp, int nextExp) {
                this.id = id;
                this.name = name;
                this.level = level;
                this.exp = exp;
                this.nextExp = nextExp;
                trainFlag = trainModel = 0;
                trainEndTime = DateTime.Now;
                expPerMin = honorCost = honorExp = 0;
            }

            public Hero(int id, string name, int level, int exp, int nextExp,
                int trainModel, int remainingTime, int expPerMin, int honorCost, int honorExp) {
                this.id = id;
                this.name = name;
                this.level = level;
                this.exp = exp;
                this.nextExp = nextExp;
                trainFlag = 1;
                this.trainModel = trainModel;
                trainEndTime = DateTime.Now.AddMilliseconds(remainingTime);
                this.expPerMin = expPerMin;
                this.honorCost = honorCost;
                this.honorExp = honorExp;
            }

            public static Hero Parse(JToken token) {
                var id = (int) token["generalid"];
                var name = (string) token["generalname"];
                var level = (int) token["generallevel"];
                var exp = (int) token["generalexp"];
                var nextlevelexp = (int) token["nextlevelexp"];
                var trainflag = (int) token["trainflag"];
                if (trainflag == 0) {
                    return new Hero(id, name, level, exp, nextlevelexp);
                }
                var trainmodel = (int) token["trainmodel"];
                var remainingtime = (int) token["remainingtime"];
                var exppermin = (int) token["exppermin"];
                var jyungong = (int) token["jyungong"];
                var jyungongexp = (int) token["jyungongexp"];
                return new Hero(id, name, level, exp, nextlevelexp,
                    trainmodel, remainingtime, exppermin, jyungong, jyungongexp);
            }

            public override string ToString() {
                if (trainFlag == 0) {
                    return String.Format("{0} Lv. {1}", name, level);
                }
                return String.Format("{0} Lv. {1} (T)", name, level);
            }
        }

        private class TimeModel {
            private int id;
            private int time;
            private string timeUnit;
            private string cost;

            public int Id { get { return id; } }

            public TimeModel(int id, int time, string timeUnit, string cost) {
                this.id = id;
                this.time = time;
                this.timeUnit = timeUnit;
                this.cost = cost;
            }

            public static TimeModel Parse(JToken token) {
                var id = (int) token["id"];
                var time = (int) token["time"];
                var timeunit = (string) token["timeunit"];
                var cost = (string) token["cost"];
                return new TimeModel(id, time, timeunit, cost);
            }

            public override string ToString() {
                return String.Format("{0} {1} - {2}", time, timeUnit, cost);
            }
        }

        private int maxTrainingSlots;

        private BindingList<Hero> heroes;
        private BindingList<TimeModel> timeModels;
        private IPacketWriter packetWriter;

        public HeroTrainingView() {
            InitializeComponent();

            heroes = new BindingList<Hero>();
            heroList.DataSource = heroes;

            timeModels = new BindingList<TimeModel>();
            timeModelList.DataSource = timeModels;
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        private void DisableDetailPanels() {
            infoBox.Enabled = false;
            trainBox.Enabled = false;
            guideBox.Enabled = false;
        }

        private void EnableDetailPanels() {
            infoBox.Enabled = true;
            trainBox.Enabled = true;
            guideBox.Enabled = true;
        }

        /// <summary>
        /// Attempts to refresh all heroes.
        /// </summary>
        private void RefreshHeroes() {
            if (packetWriter.SendCommand("41100", "0")) {
                Enabled = false;
            }
        }

        /// <summary>
        /// Attempts to refresh the selected hero.
        /// </summary>
        private void RefreshSelectedHero() {
            var item = heroList.SelectedItem;
            if (item != null) {
                var heroItem = (Hero) item;
                if (packetWriter.SendCommand("41107", heroItem.Id.ToString())) {
                    DisableDetailPanels();
                }
            }
        }

        /// <summary>
        /// Attempts to train (huấn luyện) the selected hero.
        /// </summary>
        private void Train() {
            var item0 = heroList.SelectedItem;
            if (item0 == null) {
                return;
            }
            var item1 = timeModelList.SelectedItem;
            if (item1 == null) {
                return;
            }
            var heroItem = (Hero) item0;
            var timeModelItem = (TimeModel) item1;
            if (packetWriter.SendCommand("41101", heroItem.Id.ToString(), timeModelItem.Id.ToString())) {
                // model.LogDebug(String.Format("Bắt đầu huấn luyện tướng {0} - LV {1} - Exp {2}/{3}",
                //    heroItem.Name, heroItem.Level, heroItem.Exp, heroItem.NextExp));
                DisableDetailPanels();
            }
        }

        /// <summary>
        /// Attempts to guide (mãnh tiến) the selected hero.
        /// </summary>
        private void Guide() {
            var item = heroList.SelectedItem;
            var heroItem = (Hero) item;
            if (packetWriter.SendCommand("41102", heroItem.Id.ToString(), "1", "1")) {
                // model.LogDebug(String.Format("Mãnh tiến tướng {0} - LV {1} - Exp {2}/{3}",
                //     heroItem.Name, heroItem.Level, heroItem.Exp, heroItem.NextExp));
                DisableDetailPanels();
            }
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "41100") {
                Enabled = true;
                Parse41100(packet);
            }
            if (packet.CommandId == "41101") {
                EnableDetailPanels();
                Parse41101(packet);
            }
            if (packet.CommandId == "41102") {
                EnableDetailPanels();
                Parse41102(packet);
            }
            if (packet.CommandId == "41107") {
                EnableDetailPanels();
                Parse41107(packet);
            }
        }

        private void Parse41100(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var generaldto = token["generaldto"];
            var selectedHeroId = ParseSelectedHero(generaldto);

            heroes.Clear();
            var general = token["general"];
            foreach (var obj in general) {
                heroes.Add(Hero.Parse(obj));
            }

            timeModels.Clear();
            var timemodel = token["timemodel"];
            foreach (var obj in timemodel) {
                timeModels.Add(TimeModel.Parse(obj));
            }

            var currentnum = (int) token["currentnum"];
            var maxnum = (int) token["maxnum"];
            UpdateTrainingSlots(currentnum, maxnum);

            var tufeiTokenCount = (int) token["tufeiTokenCount"];
            UpdateGuideTokens(tufeiTokenCount);

            heroList.SelectedIndexChanged -= heroList_SelectedIndexChanged;
            for (var i = 0; i < heroes.Count; ++i) {
                if (selectedHeroId == heroes[i].Id) {
                    heroList.SelectedIndex = i;
                    break;
                }
            }
            heroList.SelectedIndexChanged += heroList_SelectedIndexChanged;
        }

        private void Parse41101(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var message = (string) token["message"];
            if (message != null) {
                // model.LogDebug(message);
                return;
            }
            Parse41100(packet);
        }

        private void Parse41102(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var message = (string) token["message"];
            if (message != null) {
                // model.LogDebug(message);
                return;
            }
            Parse41100(packet);
        }

        private void Parse41107(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var generaldto = token["generaldto"];
            ParseSelectedHero(generaldto);
            UpdateGuidePanel();
        }

        private int ParseSelectedHero(JToken token) {
            var forces = (int) token["forces"];
            var generalexp = (int) token["generalexp"];
            var generallevel = (int) token["generallevel"];
            var generalname = (string) token["generalname"];
            var intelligence = (int) token["intelligence"];
            var leader = (int) token["leader"];
            var maxsolidernum = (int) token["maxsolidernum"];
            var nextlevelexp = (int) token["nextlevelexp"];
            var shiftlv = (int) token["shiftlv"];
            var skillname = (string) token["skillname"];
            var soliderlevel = (int) token["soliderLevel"];
            var solidernum = (int) token["solidernum"];
            var trooplevel = (int) token["trooplevel"];
            var troopstagename = (string) token["troopstagename"];
            var troopname = (string) token["troopname"];

            infoBox.Text = String.Format("{0} Lv. {1}", generalname, generallevel);
            info0Label.Text = String.Format("{0}/{1}", solidernum, maxsolidernum);
            info1Label.Text = String.Format("D{0} K{1} T{2}", forces, leader, intelligence);
            info2Label.Text = troopname;
            info3Label.Text = String.Format("{0} - {1}", troopstagename, trooplevel);
            info4Label.Text = skillname;
            info5Label.Text = String.Format("Tướng Lv.{0} trở lên", shiftlv);
            info6Label.Text = String.Format("{0}/{1}", generalexp, nextlevelexp);

            return (int) token["generalid"];
        }

        private void UpdateTrainingSlots(int currentSlots, int maxSlots) {
            maxTrainingSlots = maxSlots;
            slotLabel.Text = String.Format("Vị trí huấn luyện: {0}/{1}", currentSlots, maxSlots);
        }

        private void UpdateGuideTokens(int tokens) {
            tokenLabel.Text = String.Format("Mãnh tiến lệnh: {0}", tokens);
        }

        private void UpdateGuidePanel() {
            var item = heroList.SelectedItem;
            if (item == null) {
                return;
            }
            var hero = (Hero) item;
            if (hero.IsTraining) {
                guideBox.Visible = true;
                remainingTimeLabel.Text = String.Format("Thời gian còn lại: {0}", Utils.FormatDuration(hero.RemainingTime));
                expPerMinLabel.Text = String.Format("Kinh nghiệm mỗi phút: {0}", hero.ExpPerMin);
                honorExpLabel.Text = String.Format("{0} C.Tích - {1} Exp", hero.HonorCost, hero.HonorExp);
            } else {
                guideBox.Visible = false;
            }
        }

        private void trainButton_Click(object sender, EventArgs e) {
            Train();
        }

        private void heroList_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshSelectedHero();
        }

        private void addButton_Click(object sender, EventArgs e) {
            var item = heroList.SelectedItem;
            if (item == null) {
                return;
            }
            if (selectedHeroList.Items.Count >= maxTrainingSlots) {
                return;
            }
            if (selectedHeroList.Items.Contains(item)) {
                return;
            }
            selectedHeroList.Items.Add(item);
        }

        private void removeButton_Click(object sender, EventArgs e) {
            var item = selectedHeroList.SelectedItem;
            if (item == null) {
                return;
            }
            selectedHeroList.Items.Remove(item);
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            RefreshHeroes();
        }

        private void guideButton_Click(object sender, EventArgs e) {
            Guide();
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e) {
            UpdateGuidePanel();
        }

        private void HeroTrainingView_Load(object sender, EventArgs e) {
            selectedHeroList.Items.Clear();
        }
    }
}
