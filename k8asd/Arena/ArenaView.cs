using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace k8asd {
    public partial class ArenaView : UserControl, IPacketReader {
        private ArenaInfo arenaInfo;
        private DateTime cooldownEndTime;

        private IPacketWriter packetWriter;
        private IMessageLogModel messageLog;

        public ArenaView() {
            InitializeComponent();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetLogModel(IMessageLogModel log) {
            messageLog = log;
        }

        public void OnPacketReceived(Packet packet) {
            //
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            Action<Packet> callback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "64005");
                Parse64005(packet);
            };

            if (packetWriter.SendCommand(callback, "64005")) {
                //
            }
        }

        private void Parse64005(Packet packet) {
            var token = JToken.Parse(packet.Message);
            arenaInfo = ArenaInfo.Parse(token);

            timesLabel.Text = String.Format("Số lần: {0}/5", arenaInfo.CurrentPlayer.RemainTimes);
            cascadeLabel.Text = String.Format("Liên thắng hiện tại: {0}", arenaInfo.CurrentPlayer.Cascade);
            topRankLabel.Text = String.Format("Hạng cao nhất: {0}", arenaInfo.CurrentPlayer.TopRank);

            var oldSelectedIndex = playerList.SelectedIndex;
            playerList.SetObjects(arenaInfo.Players, true);
            playerList.SelectedIndex = oldSelectedIndex;
        }

        private void Duel(int playerId, int rank) {
            Action<Packet> callback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "64007");
                Parse64007(packet);
            };
            if (packetWriter.SendCommand(callback, "64007", playerId.ToString(), rank.ToString())) {
                //
            }
        }

        private void playerList_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e) {
            var item = e.Item;
            var player = (ArenaPlayer) item.RowObject;
            messageLog.LogInfo(String.Format("[Võ đài] Khiêu chiến với {0} Lv. {1}",
                player.Name, player.Level));
            Duel(player.Id, player.Rank);
        }

        private void Parse64007(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var battlereport = token["battlereport"];
            if (battlereport == null) {
                // Lỗi.
                return;
            }

            var message = (string) battlereport["message"];
            var winp = (string) battlereport["winp"];
            messageLog.LogInfo(String.Format("[Võ đài] {0} ({1})", message, winp));
        }
    }
}
