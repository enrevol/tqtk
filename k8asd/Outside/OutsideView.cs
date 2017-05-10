using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class OutsideView : UserControl, IConfigHandler {
        private IPacketWriter packetWriter;
        private IPlayerInfo infoModel;
        private ICooldownModel cooldownModel;
        private ISystemLog messageLogModel;

        private bool miningLocking;

        public OutsideView() {
            InitializeComponent();

            miningLocking = false;

            miningTimer.Start();
        }

        public bool LoadConfig(IConfig config) {
            autoDrillBox.Checked = Boolean.Parse(
                config.Get("outside_auto_drill_enabled") ?? Boolean.FalseString);
            return true;
        }

        public void SaveConfig(IConfig config) {
            config.Put("outside_auto_drill_enabled", autoDrillBox.Checked);
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        public void SetInfoModel(IPlayerInfo model) {
            infoModel = model;
        }

        public void SetCooldownModel(ICooldownModel model) {
            cooldownModel = model;
        }

        public void SetLogModel(ISystemLog model) {
            messageLogModel = model;
        }

        private async void miningTimer_Tick(object sender, EventArgs e) {
            if (miningLocking) {
                return;
            }

            if (autoDrillBox.Checked) {
                try {
                    miningLocking = true;
                    if (cooldownModel.DrillCooldown > 0) {
                        return;
                    }

                    // Kiểm tra lại đóng băng.
                    var packet = await packetWriter.RefreshOutsideAsync(infoModel.PlayerId);
                    if (packet == null) {
                        return;
                    }

                    if (cooldownModel.DrillCooldown > 0) {
                        return;
                    }

                    var token = JToken.Parse(packet.Message);
                    var extraBaseInfo = (JArray) token["extraBaseInfo"];
                    if (extraBaseInfo.Count == 0) {
                        messageLogModel.Log("[Khoan] Chưa mở ngoại thành!");
                        autoDrillBox.Checked = false;
                        return;
                    }

                    var drillToken = extraBaseInfo[extraBaseInfo.Count - 3];
                    var axeDtoList = (JArray) drillToken["axeDtoList"];
                    var normalMining = axeDtoList[0];
                    var rewardTime = (long) normalMining["rewardTime"];
                    if (rewardTime != 0) {
                        // Có quà chưa nhận.
                        var p1 = await packetWriter.GetDrillResultAsync();
                        if (p1 == null) {
                            return;
                        }

                        messageLogModel.Log(String.Format("[Khoan] Tiến hành mở kết quả khoan."));
                        var result = DrillResult.Parse(JToken.Parse(p1.Message));
                        if (result == null) {
                            return;
                        }
                        foreach (var reward in result.Rewards) {
                            messageLogModel.Log(String.Format("[Khoan] Nhận được {0} {1}.", reward.Award, reward.Name));
                        }
                    }

                    messageLogModel.Log("[Khoan] Bắt đầu khoan...");
                    await packetWriter.DrillAsync();
                } finally {
                    miningLocking = false;
                }
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            //
        }
    }
}
