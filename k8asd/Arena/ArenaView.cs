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
        private class Player {
            /// <summary>
            /// Cấp độ phần thưởng, ví dụ: 2k bạc là lv1, 15k bạc là lv4.
            /// </summary>
            private int awardLevel;

            /// <summary>
            /// Tên phần thưởng, ví dụ: bạc, lúa, lượt.
            /// </summary>
            private string awardName;

            /// <summary>
            /// Số lượng tương ứng của phần thưởng, ví dụ: 15k bạc thì là 15k.
            /// </summary>
            private int awardnum;

            /// <summary>
            /// Liên thắng hiện tại.
            /// </summary>
            private int cascade;

            /// <summary>
            /// ???
            /// </summary>
            private int cascadeRewards;

            /// <summary>
            /// Thời gian còn lại để nhận phần thưởng.
            /// </summary>
            private int countDownRemain;

            /// <summary>
            /// Cấp độ người chơi.
            /// </summary>
            private int level;

            /// <summary>
            /// Quốc gia.
            /// </summary>
            private string nation;

            /// <summary>
            /// ID người chơi.
            /// </summary>
            private int playerId;

            /// <summary>
            /// Tên người chơi.
            /// </summary>
            private string playerName;

            /// <summary>
            /// Hạng.
            /// </summary>
            private int rank;

            /// <summary>
            /// ??? Có thể là lượt đánh còn lại.
            /// </summary>
            private int remainTimes;

            /// <summary>
            /// Liên thắng cao nhất.
            /// </summary>
            private int topestCascade;

            /// <summary>
            /// ??? Hạng cao nhất.
            /// </summary>
            private int topestRank;

            public int Rank { get { return rank; } }
            public int TopRank { get { return topestRank; } }
            public int Cascade { get { return cascade; } }
            public int TopCascade { get { return topestCascade; } }
            public int RemainTimes { get { return remainTimes; } }
            public int Id { get { return playerId; } }
            public string Name { get { return playerName; } }
            public int Level { get { return level; } }
            public string Nation { get { return nation; } }

            public static Player Parse(JToken token) {
                var result = new Player();
                result.awardLevel = (int) token["awardLevel"];
                result.awardName = (string) token["awardName"];
                result.awardnum = (int) token["awardnum"];
                result.cascade = (int) token["cascade"];
                result.cascadeRewards = (int) token["cascadeRewards"];
                result.countDownRemain = (int) token["countDownRemain"];
                result.level = (int) token["level"];
                result.nation = (string) token["nation"];
                result.playerId = (int) token["playerId"];
                result.playerName = (string) token["playerName"];
                result.rank = (int) token["rank"];
                result.remainTimes = (int) token["remainTimes"];
                result.topestCascade = (int) token["topestCascade"];
                result.topestRank = (int) token["topestRank"];
                return result;
            }

            public string RankDescription {
                get { return String.Format("{0}/{1}", Rank, TopRank); }
            }

            public string CascadeDescription {
                get { return String.Format("{0}/{1}", Cascade, TopCascade); }
            }
        }

        private List<Player> players;
        private DateTime cooldownEndTime;            

        private IPacketWriter packetWriter;
        private IMessageLogModel messageLog;

        public ArenaView() {
            InitializeComponent();

            players = new List<Player>();
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
            var rankList = token["rankList"];
            players.Clear();
            foreach (var rank in rankList) {
                var player = Player.Parse(rank);
                players.Add(player);
            }

            var oldSelectedIndex = playerList.SelectedIndex;
            playerList.SetObjects(players, true);
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
            var player = (Player) item.RowObject;
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
