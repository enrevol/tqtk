using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace k8asd {
    public partial class HeroTrainingView : UserControl, IConfigHandler {
        private Barracks barracks;
        private List<HeroDetail> heroDetails;
        private Dictionary<int, bool> autoTrainStates;
        private Dictionary<int, bool> autoGuideStates;

        private int guidingIndex;
        private int trainingIndex;

        private bool asyncLock;
        private bool timerLock;

        private IMessageLogModel logModel;
        private ICooldownModel cooldownModel;
        private IPacketWriter packetWriter;

        public HeroTrainingView() {
            InitializeComponent();

            barracks = null;
            heroDetails = null;

            asyncLock = false;
            timerLock = false;

            guidingIndex = 0;
            trainingIndex = 0;

            autoTrainStates = new Dictionary<int, bool>();
            autoGuideStates = new Dictionary<int, bool>();

            nameColumn.AspectGetter = obj => {
                return heroDetails.Find(item => item.Id == (int) obj).Name;
            };
            levelColumn.AspectGetter = obj => {
                return heroDetails.Find(item => item.Id == (int) obj).Level;
            };
            shiftLevelColumn.AspectGetter = obj => {
                return heroDetails.Find(item => item.Id == (int) obj).ShiftLevel;
            };
            autoTrainColumn.AspectGetter = obj => {
                return IsHeroAutoTrain((int) obj);
            };
            autoTrainColumn.AspectPutter = (obj, value) => {
                autoTrainStates[(int) obj] = (bool) value;
            };
            autoGuideColumn.AspectGetter = obj => {
                return IsHeroAutoGuide((int) obj);
            };
            autoGuideColumn.AspectPutter = (obj, value) => {
                autoGuideStates[(int) obj] = (bool) value;
            };
        }

        public bool LoadConfig(IConfig config) {
            autoTrainCheck.Checked = Boolean.Parse(
                config.Get("barracks_auto_enabled") ?? Boolean.FalseString);
            autoTrainStates = config.GetArray("barracks_auto_train_hero_ids")
                .ToDictionary(item => Int32.Parse(item), item => true);
            autoGuideStates = config.GetArray("barracks_auto_guide_hero_ids")
                .ToDictionary(item => Int32.Parse(item), item => true);
            return true;
        }

        public void SaveConfig(IConfig config) {
            config.Put("barracks_auto_enabled", autoTrainCheck.Checked);
            config.PutArray("barracks_auto_train_hero_ids",
                autoTrainStates
                    .Where(item => item.Value)
                    .Select(item => item.Key).ToList());
            config.PutArray("barracks_auto_guide_hero_ids",
                autoGuideStates
                    .Where(item => item.Value)
                    .Select(item => item.Key).ToList());
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        public void SetLogModel(IMessageLogModel model) {
            logModel = model;
        }

        public void SetCooldownModel(ICooldownModel model) {
            cooldownModel = model;
            trainingTimer.Start();
        }

        private bool IsHeroAutoTrain(int heroId) {
            bool result;
            autoTrainStates.TryGetValue(heroId, out result);
            return result;
        }

        private bool IsHeroAutoGuide(int heroId) {
            bool result;
            autoGuideStates.TryGetValue(heroId, out result);
            return result;
        }

        /// <summary>
        /// Attempts to refresh all heroes.
        /// </summary>
        private async Task<bool> RefreshHeroesAsync() {
            if (asyncLock) {
                return false;
            }
            try {
                asyncLock = true;
                var packet = await packetWriter.SendCommandAsync("41100", "0");
                if (packet == null) {
                    return false;
                }

                barracks = Barracks.Parse(JToken.Parse(packet.Message));
                var details = new List<HeroDetail>();
                var heroIds = new List<int>();
                foreach (var hero in barracks.Heroes) {
                    heroIds.Add(hero.Id);
                    var p1 = await packetWriter.SendCommandAsync("41107", hero.Id.ToString());
                    if (p1 == null) {
                        return false;
                    }
                    var detail = HeroDetail.Parse(JToken.Parse(p1.Message));
                    details.Add(detail);
                }

                heroDetails = details;
                heroList.SetObjects(heroIds, true);
                return true;
            } finally {
                asyncLock = false;
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            //
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshHeroesAsync();
        }

        private void HeroTrainingView_Load(object sender, EventArgs e) {
            // selectedHeroList.Items.Clear();
        }

        private async Task TrainNextHero() {
            var index = trainingIndex % barracks.Heroes.Count;
            ++trainingIndex;

            // Tướng đang được duyệt.
            var hero = barracks.Heroes[index];
            if (!IsHeroAutoTrain(hero.Id)) {
                // Không được đánh dấu.
                return;
            }

            if (hero.IsTraining) {
                // Đang được huấn luyện.
                return;
            }

            if (barracks.CurrentSlots == barracks.MaxSlots) {
                // Hết vị trí huấn luyện.
                if (barracks.Heroes.Count(item => item.IsTraining) < barracks.CurrentSlots) {
                    // Có vị trí nào đó hết thời gian huấn luyện.
                    // Cập nhật lại thao trường.
                    await RefreshHeroesAsync();
                    return;
                }
            } else {
                logModel.LogInfo(String.Format("Bắt đầu huấn luyện tướng {0} Lv. {1} Exp {2}/{3}",
                    hero.Name, hero.Level, hero.Exp, hero.NextExp));
                await packetWriter.TrainHeroAsync(hero.Id);
                await RefreshHeroesAsync();
            }
        }

        private async Task GuideNextHero() {
            var index = guidingIndex % barracks.Heroes.Count;
            ++guidingIndex;

            // Tướng đang được duyệt.
            var hero = barracks.Heroes[index];

            if (!IsHeroAutoGuide(hero.Id)) {
                // Không được đánh dấu.
                return;
            }

            if (!hero.IsTraining) {
                // Chưa được huấn luyện.
                return;
            }

            if (!barracks.CanGuide) {
                // Đang bị đóng băng.
                return;
            }

            if (barracks.GuideCooldown > 0) {
                // Chưa hết thời gian đóng băng.
                return;
            }

            logModel.LogInfo(String.Format("Mãnh tiến tướng {0} Lv. {1} Exp {2}/{3}",
                hero.Name, hero.Level, hero.Exp, hero.NextExp));
            await packetWriter.SendCommandAsync("41102", hero.Id.ToString(), "1", "1");
            await RefreshHeroesAsync();
        }

        private async void trainingTimer_Tick(object sender, EventArgs e) {
            if (!autoTrainCheck.Checked) {
                return;
            }
            if (timerLock) {
                return;
            }
            try {
                timerLock = true;

                if (barracks == null) {
                    await RefreshHeroesAsync();
                    return;
                }

                await TrainNextHero();
                await GuideNextHero();
            } finally {
                timerLock = false;
            }
        }
    }
}
