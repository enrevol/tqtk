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
using BrightIdeasSoftware;

namespace k8asd {
    public partial class ArmyView : UserControl, IPacketReader {
        private enum TeamLimit {
            /// <summary>
            /// Không giới hạn.
            /// </summary>
            None = 1,

            /// <summary>
            /// Giới hạn quốc gia.
            /// </summary>
            Nation = 2,

            /// <summary>
            /// Giới hạn bang hội.
            /// </summary>
            Legion = 3,
        }

        private enum ArmyType {
            /// <summary>
            /// NPC thường.
            /// </summary>
            Normal,

            /// <summary>
            /// NCP tinh anh (rớt đồ).
            /// </summary>
            Elite,

            /// <summary>
            /// NPC tướng (đánh 1 lần).
            /// </summary>
            Hero,

            /// <summary>
            /// Quân đoàn.
            /// </summary>
            Army
        }

        private class Army {
            private int armyId;
            private int armyLevel;
            private string armyName;
            private int armyLimit;
            private int armyMaxLimit;
            private bool attackable;
            private bool completed;
            private string intro;
            private string droppedItemName;
            private int honor;
            private ArmyType armyType;

            public int Id { get { return armyId; } }
            public int Level { get { return armyLevel; } }
            public string Name { get { return armyName; } }
            public int Limit { get { return armyLimit; } }
            public int MaxLimit { get { return armyMaxLimit; } }
            public bool Attackable { get { return attackable; } }
            public string ItemName { get { return droppedItemName; } }
            public int Honor { get { return honor; } }
            public ArmyType Type { get { return armyType; } }

            public static Army Parse(JToken token) {
                var result = new Army();
                result.armyId = (int) token["armyid"];
                result.armyLevel = (int) token["armylevel"];
                result.armyName = (string) token["armyname"];
                result.armyLimit = (int) token["armynum"];
                result.armyMaxLimit = (int) token["armymaxnum"];
                result.attackable = (bool) token["attackable"];
                result.completed = (bool) token["complete"];
                result.intro = (string) token["intro"];
                result.droppedItemName = (string) token["itemname"];
                result.honor = (int) token["jyungong"];
                var type = (int) token["type"];
                if (type == 1) {
                    result.armyType = ArmyType.Normal;
                } else if (type == 2) {
                    result.armyType = ArmyType.Elite;
                } else if (type == 3) {
                    result.armyType = ArmyType.Hero;
                } else if (type == 5) {
                    result.armyType = ArmyType.Army;
                } else {
                    Debug.Assert(false);
                }
                return result;
            }

            public override string ToString() {
                return String.Format("{0} Lv. {1}", Name, Level);
            }
        }

        private class Team {
            private int teamId;
            private string teamName;
            private string condition;
            private int playerCount;
            private int maxPlayerCount;
            private Cooldown cooldown;

            public int Id { get { return teamId; } }
            public string Name { get { return teamName; } }
            public string Condition { get { return condition; } }
            public int PlayerCount { get { return playerCount; } }
            public int MaxPlayerCount { get { return maxPlayerCount; } }
            public int RemainingTime { get { return cooldown.RemainingMilliseconds; } }

            public static Team Parse(JToken token, DateTime serverTime) {
                var result = new Team();
                result.teamId = (int) token["teamid"];
                result.teamName = (string) token["teamname"];
                result.condition = (string) token["condition"];
                result.playerCount = (int) token["currentnum"];
                result.maxPlayerCount = (int) token["maxnum"];
                var endtime = (long) token["endtime"];
                var serverTimeOffset = serverTime - DateTime.Now;
                var endDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    .ToLocalTime().AddMilliseconds(endtime).Add(-serverTimeOffset);
                result.cooldown = new Cooldown((endDateTime - DateTime.Now).Milliseconds);
                return result;
            }

            public string Description() {
                return String.Format("{0} {1} ({2}/{3}) [{4}]",
                    Name, Condition, PlayerCount, MaxPlayerCount,
                    Utils.FormatDuration(cooldown.RemainingMilliseconds));
            }
        }

        private class Member {
            private int playerId;
            private int playerLevel;
            private string playerName;

            public int Id { get { return playerId; } }
            public int Level { get { return playerLevel; } }
            public string Name { get { return playerName; } }

            public static Member Parse(JToken token) {
                var result = new Member();
                result.playerId = (int) token["playerid"];
                result.playerLevel = (int) token["playerlevel"];
                result.playerName = (string) token["playername"];
                return result;
            }

            public string Description() {
                return String.Format("{0} Lv. {1}", Name, Level);
            }
        }

        private BindingList<Army> armies;
        private BindingList<Team> teams;
        private BindingList<Member> members;
        private IPacketWriter packetWriter;
        private IInfoModel infoModel;

        public ArmyView() {
            InitializeComponent();

            armies = new BindingList<Army>();
            armyList.DataSource = armies;

            teams = new BindingList<Team>();
            members = new BindingList<Member>();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
        }

        private void RefreshArmies() {
            Action<Packet> callback = (Packet packet) => {
                Debug.Assert(packet.CommandId == "33201");
                var powerIds = new Queue<int>(Parse33201(packet));

                Action updater;
                Action<Packet> callback_ = null;

                updater = () => {
                    if (powerIds.Count > 0) {
                        var powerId = powerIds.Dequeue();
                        if (packetWriter.SendCommand(callback_, "33100", powerId.ToString())) {
                            // OK.
                        } else {
                            Enabled = true;
                        }
                    } else {
                        Enabled = true;
                    }
                };

                callback_ = (Packet packet_) => {
                    Debug.Assert(packet_.CommandId == "33100");
                    Parse33100(packet_);
                    updater();
                };

                updater();
            };
            if (packetWriter.SendCommand(callback, "33201", "1")) {
                armies.Clear();
                Enabled = false;
            }
        }

        private void RefreshSelectedArmy() {
            var item = armyList.SelectedItem;
            if (item != null) {
                var army = (Army) item;
                RefreshArmy(army.Id);
            }
        }

        private void RefreshArmy(int armyId) {
            packetWriter.SendCommand((Packet packet) => {
                Debug.Assert(packet.CommandId == "34100");
                Parse34100(packet);
            }, "34100", armyId.ToString());
        }

        private void refreshArmyButton_Click(object sender, EventArgs e) {
            RefreshArmies();
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "34108") {
                Parse34108(packet);
            }
        }

        private List<int> Parse33201(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var powerIds = new List<int>();
            var powerList = token["powerList"];
            foreach (var power in powerList) {
                var powerId = (int) power["powerId"];
                powerIds.Add(powerId);
            }
            return powerIds;
        }

        private void Parse33100(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var armiesToken = token["army"];
            foreach (var armyToken in armiesToken) {
                var army = Army.Parse(armyToken);
                if (army.Type == ArmyType.Army) {
                    armies.Add(army);
                }
            }
        }

        private void Parse34100(Packet packet) {
            var token = JToken.Parse(packet.Message);

            var armies = token["armies"];
            UpdateArmyPanel(armies);

            var team = token["team"];
            ParseTeams(team);

            var member = token["member"];
            ParseMembers(member);
        }

        private void Parse34108(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var battlereport = token["battlereport"];
            var report = battlereport["report"];
            var fieldreport = report["fieldreport"];
            var gains = (string) report["gains"];
            if (gains.Length == 0) {
                // Failed.
            } else {
                // Succeeded.
            }
        }

        private void ParseTeams(JToken token) {
            teams.Clear();
            foreach (var teamToken in token) {
                var team = Team.Parse(teamToken, infoModel.ServerTime);
                teams.Add(team);
            }
            var oldSelectedIndex = teamList.SelectedIndex;
            teamList.SetObjects(teams, true);
            teamList.SelectedIndex = oldSelectedIndex;
        }

        private void ParseMembers(JToken token) {
            members.Clear();
            foreach (var memberToken in token) {
                var member = Member.Parse(memberToken);
                members.Add(member);
            }
            var oldSelectedIndex = memberList.SelectedIndex;
            memberList.SetObjects(members, true);
            memberList.SelectedIndex = oldSelectedIndex;
        }

        private void UpdateArmyPanel(JToken token) {
            var armynum = (int) token["armynum"];
            var honor = (int) token["honor"];
            var minplayer = (int) token["minplayer"];
            var maxplayer = (int) token["maxplayer"];
            armyNumLabel.Text = String.Format("Đội quân: {0}", armynum);
            playerNumLabel.Text = String.Format("Người tham gia: {0} - {1}", minplayer, maxplayer);
            baseHonorLabel.Text = String.Format("Chiến tích cơ bản: {0}", honor);
        }

        private void radArmy2_CheckedChanged(object sender, EventArgs e) {
            //radArmy1.Checked = !radArmy2.Checked;
        }

        private void radArmy1_CheckedChanged(object sender, EventArgs e) {
            // radArmy2.Checked = !radArmy1.Checked;
        }

        private void Create(int armyId, int minimumLevel, TeamLimit limit) {
            packetWriter.SendCommand("34101", armyId.ToString(),
                String.Format("4:{0};{1}", minimumLevel, (int) limit), "0");
        }

        private void Join(int teamId) {
            packetWriter.SendCommand("34102", teamId.ToString());
        }

        private void MovePlayerUp(int playerId) {
            packetWriter.SendCommand("34103", playerId.ToString(), "0");
        }

        private void MovePlayerDown(int playerId) {
            packetWriter.SendCommand("34103", playerId.ToString(), "1");
        }

        private void KickPlayer(int playerId) {
            packetWriter.SendCommand("34104", playerId.ToString());
        }

        private void Disband() {
            packetWriter.SendCommand("34105");
        }

        private void Quit() {
            packetWriter.SendCommand("34106");
        }

        private void Attack() {
            packetWriter.SendCommand("34107", "0");
        }

        private void ForceAttack() {
            // Tạo quân đoàn đổng trác.
            Create(900001, 0, TeamLimit.None);

            // Tấn công.
            Attack();

            // Giải tán quân đoàn đổng trác.
            Disband();
        }

        /*
         * FIXME.
        private void btnArmyInvite_Click(object sender, EventArgs e) {
            int cnum = Convert.ToInt32(r34100.currentnum);
            int mnum = Convert.ToInt32(r34100.maxnum);
            if (cnum > 0 && cnum < mnum)
                SendMsg("10103", r11102.playername,
                "Tổ đội đánh " + r34100.name
                + " đã được lập, còn " + (mnum - cnum).ToString() + " vị trí, hãy mau chóng đến "
                + "<a href='event:teamBattle|" + r34100.listmember[0].playerid
                + "|" + (cbbArmy1.SelectedIndex + 1).ToString()
                + "|" + r34100.id
                + "|" + r34100.id
                + "'>[Gia nhập]</a>",
                (cbbChat.SelectedIndex + 1).ToString(), " ");
        }
        */

        private void armyList_SelectedIndexChanged(object sender, EventArgs e) {
            var item = armyList.SelectedItem;
            if (item == null) {
                return;
            }

            var army = (Army) item;
            itemLabel.Text = army.ItemName;
            limitLabel.Text = String.Format("Giới hạn: {0}/{1}", army.Limit, army.MaxLimit);
            honorLabel.Text = String.Format("Chiến tích: {0}", army.Honor);
        }

        private void refreshTeamTimer_Tick(object sender, EventArgs e) {
            if (autoRefreshTeamBox.Checked) {
                RefreshSelectedArmy();
            }
        }

        private void refreshTeamButton_Click(object sender, EventArgs e) {
            RefreshSelectedArmy();
        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void teamList_ButtonClick(object sender, CellClickEventArgs e) {
            var item = e.Item;
            var team = (Team) item.RowObject;
            Join(team.Id);
        }

        private void joinX10Button_Click(object sender, EventArgs e) {
            var item = teamList.SelectedItem;
            if (item != null) {
                var team = (Team) item.RowObject;
                for (int i = 0; i < 10; ++i) {
                    Join(team.Id);
                }
            }
        }

        private void attackButton_Click(object sender, EventArgs e) {
            Attack();
        }

        private void disbandButton_Click(object sender, EventArgs e) {
            Disband();
        }

        private void quitButton_Click(object sender, EventArgs e) {
            Quit();
        }

        private void forceAttackButton_Click(object sender, EventArgs e) {
            ForceAttack();
        }

        private void memberList_ButtonClick(object sender, CellClickEventArgs e) {
            var item = e.Item;
            var member = (Member) item.RowObject;
            if (e.ColumnIndex == 1) {
                KickPlayer(member.Id);
            } else if (e.ColumnIndex == 2) {
                MovePlayerUp(member.Id);
            } else if (e.ColumnIndex == 3) {
                MovePlayerDown(member.Id);
            }
        }

        private void createButton_Click(object sender, EventArgs e) {
            var item = armyList.SelectedItem;
            if (item != null) {
                var army = (Army) item;
                Create(army.Id, 0, TeamLimit.None);
            }
        }

        private void createLegionButton_Click(object sender, EventArgs e) {
            var item = armyList.SelectedItem;
            if (item != null) {
                var army = (Army) item;
                Create(army.Id, 0, TeamLimit.Legion);
            }
        }

        private void refreshTeamInterval_ValueChanged(object sender, EventArgs e) {
            refreshTeamTimer.Interval = (int) refreshTeamInterval.Value;
        }

        private void autoRefreshTeamBox_CheckedChanged(object sender, EventArgs e) {
            if (autoRefreshTeamBox.Checked) {
                RefreshSelectedArmy();
            }
        }
    }


    /*

#region 33101
case "33101":
    /// FIXME.
    /*
    R33101 r33101 = new R33101(cdata);
    if (r33101.m == null) {
        lblExtraYinkuang.Visible = r33101.extrayinkuang.Equals("1");
        lblExtraNongtian.Visible = r33101.extranongtian.Equals("1");
        lblExtraZhengzhan.Visible = r33101.extrazhengzhan.Equals("1");
        lblExtraZhengfu.Visible = r33101.extrazhengfu.Equals("1");
        lblExtraGongji.Visible = r33101.extragongji.Equals("1");
        sysgold = r33101.sys_gold;
        usergold = r33101.user_gold;
        txtGold.Text = (Convert.ToInt32(sysgold) + Convert.ToInt32(usergold)).ToString();
        tokencd = Convert.ToInt32(r33101.tokencd);
        tokencdusable = r33101.tokencdusable;
        forces = r33101.forces;
        txtForces.Text = forces + "/" + maxforces;
        lblToken.Text = "Lượt: " + r33101.token + "/" + r11102.maxtoken;
        txtJyungong.Text = r33101.jyungong;
        LogText("[Chiến] Tỉ lệ: " + r33101.winp + ": " + r33101.message);
        if (r33101.items != "")
            txtLogs.AppendText(". Nhận được:" + r33101.items);
        txtLogs.AppendText(" ");
        //txtLogs.InsertLink("[Chiến báo]", r33101.id);
    } else
        LogText("[Chiến] " + r33101.m);
    armynext = true;
    armyok = true;
    break;
#endregion


#region 34100
case "34100":
    r34100 = new R34100(cdata);
    if (r34100.m == null) {
        if (chkArmy.Checked) {
            if (r34100.listmember.Count == 0)
                switch (cbbArmyMode.SelectedIndex) {
                case 0:
                    LogText("[Chiến] Lập tổ đội " + r34100.name);
                    SendMsg("34101", ((TagItem) lstArmyList.Items[armycycle]).tag, "4:0;2", "0");
                    break;
                case 1:
                    bool join = false;
                    foreach (RTeam.Team dt in r34100.listteam)
                        if ((dt.condition.Contains(r11102.legionname)
                            || dt.condition.Contains(V.listnation[Convert.ToInt32(r11102.nation)]))
                            && Convert.ToInt32(dt.currentnum) < Convert.ToInt32(r34100.maxplayer)) {
                            join = true;
                            LogText("[Chiến] Gia nhập tổ đội " + r34100.name
                                + " (" + dt.currentnum + "/" + r34100.maxplayer
                                + ") của " + dt.teamname);
                            SendMsg("34102", dt.teamid);
                            break;
                        }
                    if (!join)
                        if (cbbArmyMode.SelectedIndex == 2)
                            goto case 0;
                        else {
                            armynext = true;
                            armyok = true;
                        }
                    break;
                case 2:
                    goto case 1;
                } else
                if (chkArmyAttack.Checked
                    && r34100.listmember.Count >= numArmyAttack.Value
                    && Convert.ToInt32(r34100.currentnum)
                    >= Convert.ToInt32(r34100.minplayer)) {
                if (r11102.playername == r34100.listmember[0].playername)
                    SendMsg("34107", "0");
                else {
                    SendMsg("34101", "900001", "4:0;1", "0");
                    SendMsg("34107", "0");
                    SendMsg("34105");
                }
            } else
                armyok = true;
        } else {
            btnArmyTeam.Text = r34100.listteam.Count.ToString() + " tổ đội";
            KryptonContextMenu context = new KryptonContextMenu();
KryptonContextMenuItems items = new KryptonContextMenuItems();
            foreach (RTeam.Team tm in r34100.listteam) {
                KryptonContextMenuItem item = new KryptonContextMenuItem();
item.Text = tm.teamname + " ["
                    + tm.condition + "] ("
                    + tm.currentnum + "/"
                    + tm.maxnum + ")";
                item.Tag = tm.teamid;
                item.Click += btnArmyTeam_Click;
                // item.Enabled = r34100.listmember.Count == 0;
                items.Items.Add(item);
            }
            if (items.Items.Count > 0) {
                context.Items.Add(items);
                btnArmyTeam.KryptonContextMenu = context;
            } else
                btnArmyTeam.KryptonContextMenu = null;
            lstArmyMember.Items.Clear();
            foreach (RTeam.Member mem in r34100.listmember)
                lstArmyMember.Items.Add(mem.playername + " (" + mem.playerlevel + ")");
            if (r34100.listmember.Count == 0) {
                // btnArmyInfo.Enabled = true;
                // btnArmyCreate.Enabled = true;
                // btnArmyAttack.Enabled = false;
                // btnArmyDisband.Enabled = false;
                // btnArmyQuit.Enabled = false;
                // btnArmyInvite.Enabled = false;
            } else {
                // btnArmyInfo.Enabled = false;
                // btnArmyCreate.Enabled = false;
                // btnArmyAttack.Enabled = true;
                if (r34100.listmember[0].playername == r11102.playername) {
                    // btnArmyDisband.Enabled = true;
                    // btnArmyQuit.Enabled = false;
                } else {
                    // btnArmyDisband.Enabled = false;
                    // btnArmyQuit.Enabled = true;
                }
                btnArmyInvite.Enabled = r34100.listmember.Count<Convert.ToInt32(r34100.maxplayer);
                // if (r34100.listmember.Count < Convert.ToInt32(r34100.minplayer))
                // btnArmyAttack.Enabled = false;
            }
            armyok2 = true;
        }
    } else
        LogText("[Chiến] " + r34100.m);
    break;
#endregion    

private void chkArmyAll_CheckedChanged(object sender, EventArgs e) {
for (int i = 0; i < lstArmyList.Items.Count; i++)
lstArmyList.SetItemChecked(i, chkArmyAll.Checked);
}

private void chkArmy_CheckedChanged(object sender, EventArgs e) {
armyok = chkArmy.Checked;
cbbArmyMode.Enabled = !chkArmy.Checked;
cbbArmy1.Enabled = !chkArmy.Checked;
cbbArmy2.Enabled = !chkArmy.Checked;
grpArmyInfo.Enabled = !chkArmy.Checked;
grpArmyList.Enabled = !chkArmy.Checked;
if (!chkArmy.Checked) {
btnArmyQuit_Click(null, null);
btnArmyDisband_Click(null, null);
} else
armycycle = 0;
}

private void cbbArmy1_SelectedIndexChanged(object sender, EventArgs e) {
for (int i = 0; i < listpower.Length; i++)
if (listpower[i] == cbbArmy1.SelectedItem.ToString()) {
SendMsg("33100", (i + 1).ToString());
break;
}
}

private void cbbArmy2_SelectedIndexChanged(object sender, EventArgs e) {
R33100.Army am = r33100.listarmy[cbbArmy2.SelectedIndex];
grpArmyInfo.Text = am.armyname + " Lv." + am.armylevel;
if (am.armymaxnum == "0")
txtArmyInfo1.Text = "Không";
else
txtArmyInfo1.Text = am.armynum + "/" + am.armymaxnum;
txtArmyInfo2.Text = am.jyungong;
txtArmyInfo3.Text = am.itemname;
btnArmyInfo.Enabled = am.attackable == "1" && (am.complete == "0" || am.type != "3"
&& (am.armynum != "0" || am.armymaxnum == "0" || am.type == "5"));
btnArmyAdd.Enabled = am.attackable == "1" && (am.complete != "1" || am.type != "3");
}
*/
}
