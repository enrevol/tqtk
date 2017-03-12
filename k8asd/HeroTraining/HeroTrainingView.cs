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
using System.Diagnostics;

namespace k8asd {
    public partial class HeroTrainingView : UserControl, IPacketReader {
        private class Hero {
            private int trainFlag;
            private int trainModel;
            private Cooldown trainCooldown;

            /// <summary>
            /// ID của tướng.
            /// </summary>
            public int Id { get; private set; }

            /// <summary>
            /// Tên tướng.
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Cấp độ của tướng.
            /// </summary>
            public int Level { get; private set; }

            /// <summary>
            /// Kinh nghiệm hiện tại của tướng.
            /// </summary>
            public int Exp { get; private set; }

            /// <summary>
            /// Tổng kinh nghiệm cần của cấp độ hiện tại.
            /// </summary>
            public int NextExp { get; private set; }

            /// <summary>
            /// Tướng có đang trong trạng thái huấn luyện không?
            /// </summary>
            public bool IsTraining {
                get { return RemainingTime > 0; }
            }

            /// <summary>
            /// Thời gian huấn luyện còn lại (mi-li-giây).
            /// </summary>
            public int RemainingTime {
                get {
                    if (trainFlag == 0) {
                        return 0;
                    }
                    return trainCooldown.RemainingMilliseconds;
                }
            }

            /// <summary>
            /// Kinh nghiệm huấn luyện mối phút.
            /// </summary>
            public int ExpPerMin { get; private set; }

            /// <summary>
            /// Chiến tích cần cho mỗi lần mãnh tiến.
            /// </summary>
            public int HonorCost { get; private set; }

            /// <summary>
            /// Kinh nghiệm đạt được cho mỗi lần mãnh tiến.
            /// </summary>
            public int HonorExp { get; private set; }

            public static Hero Parse(JToken token) {
                var result = new Hero();
                result.Id = (int) token["generalid"];
                result.Name = (string) token["generalname"];
                result.Level = (int) token["generallevel"];
                result.Exp = (int) token["generalexp"];
                result.NextExp = (int) token["nextlevelexp"];
                result.trainFlag = (int) token["trainflag"];
                if (result.trainFlag == 0) {
                    result.trainCooldown = new Cooldown();
                    result.trainModel = result.ExpPerMin = result.HonorCost = result.HonorExp = 0;
                } else {
                    result.trainModel = (int) token["trainmodel"];
                    result.trainCooldown = new Cooldown((int) token["remainingtime"]);
                    result.ExpPerMin = (int) token["exppermin"];
                    result.HonorCost = (int) token["jyungong"];
                    result.HonorExp = (int) token["jyungongexp"];
                }
                return result;
            }

            public override string ToString() {
                if (trainFlag == 0) {
                    return String.Format("{0} Lv. {1}", Name, Level);
                }
                return String.Format("{0} Lv. {1} (T)", Name, Level);
            }
        }

        /// <summary>
        /// Kiểu huấn luyện, ví dụ: 20 phút, 2 tiếng, 8 tiếng.
        /// </summary>
        private class TimeModel {
            private int time;
            private string timeUnit;
            private string cost;

            public int Id { get; private set; }

            public static TimeModel Parse(JToken token) {
                var result = new TimeModel();
                result.Id = (int) token["id"];
                result.time = (int) token["time"];
                result.timeUnit = (string) token["timeunit"];
                result.cost = (string) token["cost"];
                return result;
            }

            public override string ToString() {
                return String.Format("{0} {1} - {2}", time, timeUnit, cost);
            }
        }

        /// <summary>
        /// Số lượng vị trí huấn luyện.
        /// </summary>
        private int maxTrainingSlots;

        /// <summary>
        /// Dùng cho tự động luyện.
        /// </summary>
        private int guidingIndex;

        private BindingList<Hero> heroes;
        private BindingList<TimeModel> timeModels;
        private IMessageLogModel logModel;
        private ICooldownModel cooldownModel;
        private IPacketWriter packetWriter;

        public HeroTrainingView() {
            InitializeComponent();

            heroes = new BindingList<Hero>();
            heroList.DataSource = heroes;

            timeModels = new BindingList<TimeModel>();
            timeModelList.DataSource = timeModels;

            maxTrainingSlots = 0;
            guidingIndex = 0;
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetLogModel(IMessageLogModel model) {
            logModel = model;
        }

        public void SetCooldownModel(ICooldownModel model) {
            cooldownModel = model;
            trainingTimer.Start();
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
        private async Task RefreshHeroesAsync() {
            try {
                Enabled = false;
                var packet = await packetWriter.SendCommandAsync("41100", "0");
                if (packet == null) {
                    return;
                }
                Debug.Assert(packet.CommandId == "41100");
                Parse41100(packet);
            } finally {
                Enabled = true;
            }
        }

        /// <summary>
        /// Attempts to refresh the selected hero.
        /// </summary>
        private async Task RefreshSelectedHeroAsync() {
            var item = heroList.SelectedItem;
            if (item == null) {
                return;
            }

            var heroItem = (Hero) item;
            try {
                DisableDetailPanels();

                var packet = await packetWriter.SendCommandAsync("41107", heroItem.Id.ToString());
                if (packet == null) {
                    return;
                }

                Debug.Assert(packet.CommandId == "41107");
                Parse41107(packet);
            } finally {
                EnableDetailPanels();
            }
        }

        /// <summary>
        /// Attempts to train (huấn luyện) the selected hero.
        /// </summary>
        private async Task TrainSelectedHeroAsync() {
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
            await TrainAsync(heroItem, timeModelItem.Id);
        }

        private async Task TrainAsync(Hero hero, int timeModelId) {
            try {
                DisableDetailPanels();

                var packet = await packetWriter.SendCommandAsync("41101", hero.Id.ToString(), timeModelId.ToString());
                if (packet == null) {
                    return;
                }

                logModel.LogInfo(String.Format("Bắt đầu huấn luyện tướng {0} Lv. {1} Exp {2}/{3}",
                    hero.Name, hero.Level, hero.Exp, hero.NextExp));

                Debug.Assert(packet.CommandId == "41101");
                Parse41101(packet);
            } finally {
                EnableDetailPanels();
            }
        }

        /// <summary>
        /// Attempts to guide (mãnh tiến) the selected hero.
        /// </summary>
        private async Task GuideSelectedHeroAsync() {
            var item = heroList.SelectedItem;
            var heroItem = (Hero) item;
            await GuideAsync(heroItem);
        }

        private async Task GuideAsync(Hero hero) {
            try {
                DisableDetailPanels();

                var packet = await packetWriter.SendCommandAsync("41102", hero.Id.ToString(), "1", "1");
                if (packet == null) {
                    return;
                }

                logModel.LogInfo(String.Format("Mãnh tiến tướng {0} Lv. {1} Exp {2}/{3}",
                        hero.Name, hero.Level, hero.Exp, hero.NextExp));

                Debug.Assert(packet.CommandId == "41102");
                Parse41102(packet);
            } finally {
                EnableDetailPanels();
            }
        }

        public void OnPacketReceived(Packet packet) {
            //
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
                return;
            }
            Parse41100(packet);
            UpdateGuidePanel();
        }

        private void Parse41102(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var message = (string) token["message"];
            if (message != null) {
                return;
            }
            Parse41100(packet);
            UpdateGuidePanel();
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

        private async void trainButton_Click(object sender, EventArgs e) {
            await TrainSelectedHeroAsync();
        }

        private async void heroList_SelectedIndexChanged(object sender, EventArgs e) {
            await RefreshSelectedHeroAsync();
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

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshHeroesAsync();
        }

        private async void guideButton_Click(object sender, EventArgs e) {
            await GuideSelectedHeroAsync();
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e) {
            UpdateGuidePanel();
        }

        private void HeroTrainingView_Load(object sender, EventArgs e) {
            selectedHeroList.Items.Clear();
        }

        private async void trainingTimer_Tick(object sender, EventArgs e) {
            if (autoTrainCheck.Checked) {
                await TrainUntrainedHeroAsync();
                await GuideNextHeroAsync();
            }
        }

        private Hero FindHeroById(int id) {
            foreach (var hero in heroes) {
                if (hero.Id == id) {
                    return hero;
                }
            }
            return null;
        }

        private async Task TrainUntrainedHeroAsync() {
            foreach (var item in selectedHeroList.Items) {
                var selectedHero = (Hero) item;
                var hero = FindHeroById(selectedHero.Id);
                if (hero != null && !hero.IsTraining) {
                    await TrainAsync(hero, timeModels[0].Id);
                    break;
                }
            }
        }

        private async Task GuideNextHeroAsync() {
            if (cooldownModel.GuideCooldown == 0) {
                if (selectedHeroList.Items.Count > 0) {
                    if (guidingIndex >= selectedHeroList.Items.Count) {
                        guidingIndex = 0;
                    }
                    var selectedHero = (Hero) selectedHeroList.Items[guidingIndex];
                    var hero = FindHeroById(selectedHero.Id);
                    if (hero != null && hero.IsTraining) {
                        await GuideAsync(hero);
                    }
                    ++guidingIndex;
                }
            }
        }
    }
}
