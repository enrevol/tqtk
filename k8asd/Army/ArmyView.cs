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
using System.IO;

namespace k8asd {
    public partial class ArmyView : UserControl, IPacketReader {
        private string FILE_DS = "dsacc.data";
        private static List<string> listAcc = new List<string>();

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
            private bool completed;
            private string intro;

            /// <summary>
            /// ID của NPC.
            /// </summary>
            public int Id { get; private set; }

            /// <summary>
            /// Cấp độ của NPC.
            /// </summary>
            public int Level { get; private set; }

            /// <summary>
            /// Tên NPC.
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Số lượt đánh còn lại.
            /// </summary>
            public int Limit { get; private set; }

            /// <summary>
            /// Số lượt đánh tối đa.
            /// </summary>
            public int MaxLimit { get; private set; }

            /// <summary>
            /// Có thể tấn công không?
            /// </summary>
            public bool Attackable { get; private set; }

            /// <summary>
            /// Vật phẩm có thể rớt.
            /// </summary>
            public string ItemName { get; private set; }

            /// <summary>
            /// Chiến tích.
            /// </summary>
            public int Honor { get; private set; }

            /// <summary>
            /// Thể loại NPC.
            /// </summary>
            public ArmyType Type { get; private set; }

            public static Army Parse(JToken token) {
                var result = new Army();
                result.Id = (int) token["armyid"];
                result.Level = (int) token["armylevel"];
                result.Name = (string) token["armyname"];
                result.Limit = (int) token["armynum"];
                result.MaxLimit = (int) token["armymaxnum"];
                result.Attackable = (bool) token["attackable"];
                result.completed = (bool) token["complete"];
                result.intro = (string) token["intro"];
                result.ItemName = (string) token["itemname"];
                result.Honor = (int) token["jyungong"];
                var type = (int) token["type"];
                if (type == 1) {
                    result.Type = ArmyType.Normal;
                } else if (type == 2) {
                    result.Type = ArmyType.Elite;
                } else if (type == 3) {
                    result.Type = ArmyType.Hero;
                } else if (type == 5) {
                    result.Type = ArmyType.Army;
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
            private Cooldown cooldown;

            /// <summary>
            /// ID của tổ đội.
            /// </summary>
            public int Id { get; private set; }

            /// <summary>
            /// Tên tổ đội.
            /// </summary>
            public string Name { get; private set; }

            /// <summary>
            /// Điều kiện tham gia của tổ đội.
            /// </summary>
            public string Condition { get; private set; }

            /// <summary>
            /// Số lượng người chơi có trong tổ đội.
            /// </summary>
            public int PlayerCount { get; private set; }

            /// <summary>
            /// Số lượng người chơi tối đa trong tổ đội.
            /// </summary>
            public int MaxPlayerCount { get; private set; }

            /// <summary>
            /// Thời gian chờ còn lại.
            /// </summary>
            public int RemainingTime { get { return cooldown.RemainingMilliseconds; } }

            public static Team Parse(JToken token, DateTime serverTime) {
                var result = new Team();
                result.Id = (int) token["teamid"];
                result.Name = (string) token["teamname"];
                result.Condition = (string) token["condition"];
                result.PlayerCount = (int) token["currentnum"];
                result.MaxPlayerCount = (int) token["maxnum"];
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
            public int Id { get; private set; }
            public int Level { get; private set; }
            public string Name { get; private set; }

            public static Member Parse(JToken token) {
                var result = new Member();
                result.Id = (int) token["playerid"];
                result.Level = (int) token["playerlevel"];
                result.Name = (string) token["playername"];
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

            loadClones();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
        }

        private async Task RefreshArmiesAsync() {
            using (var guard = new ScopeGuard(() => Enabled = true)) {
                Enabled = false;
                armies.Clear();

                var packet = await packetWriter.SendCommandAsync("33201", "1");
                if (packet == null) {
                    return;
                }
                Debug.Assert(packet.CommandId == "33201");

                var powerIds = Parse33201(packet);
                foreach (var powerId in powerIds) {
                    var powerPacket = await packetWriter.SendCommandAsync("33100", powerId.ToString());
                    if (powerPacket == null) {
                        return;
                    }
                    Debug.Assert(powerPacket.CommandId == "33100");

                    var army = Parse33100(powerPacket);
                    if (army != null) {
                        armies.Add(army);
                    }
                }
            }
        }

        private async Task RefreshSelectedArmyAsync() {
            var item = armyList.SelectedItem;
            if (item != null) {
                var army = (Army) item;
                await RefreshArmyAsync(army.Id);
            }
        }

        private async Task RefreshArmyAsync(int armyId) {
            var packet = await packetWriter.SendCommandAsync("34100", armyId.ToString());
            if (packet == null) {
                return;
            }
            Debug.Assert(packet.CommandId == "34100");
            Parse34100(packet);
        }

        private async void refreshArmyButton_Click(object sender, EventArgs e) {
            await RefreshArmiesAsync();
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

        private Army Parse33100(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var armiesToken = token["army"];
            foreach (var armyToken in armiesToken) {
                var army = Army.Parse(armyToken);
                if (army.Type == ArmyType.Army) {
                    return army;
                }
            }
            return null;
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

        private async void ParseMembers(JToken token) {
            members.Clear();
            foreach (var memberToken in token) {
                var member = Member.Parse(memberToken);
                members.Add(member);
            }
            var oldSelectedIndex = memberList.SelectedIndex;
            memberList.SetObjects(members, true);
            memberList.SelectedIndex = oldSelectedIndex;

            //auto kick
            if (this.chkKick.Checked)
            {
                for (int i = 0; i < members.Count; i++)
                {
                    if (!findInList(members[i].Name))
                    {
                        await KickPlayerAsync(members[i].Id);
                    }
                }
            }
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

        /// <summary>
        /// Tạo tổ đội quân đoàn.
        /// </summary>
        /// <param name="armyId">ID của quân đoàn.</param>
        /// <param name="minimumLevel">Giới hạn cấp độ tối thiểu.</param>
        /// <param name="limit">Giới hạn chung</param>
        private async Task CreateAsync(int armyId, int minimumLevel, TeamLimit limit) {
            await packetWriter.SendCommandAsync("34101", armyId.ToString(),
                String.Format("4:{0};{1}", minimumLevel, (int) limit), "0");
        }

        /// <summary>
        /// Gia nhập tổ đội.
        /// </summary>
        private async Task JoinAsync(int teamId) {
            await packetWriter.SendCommandAsync("34102", teamId.ToString());
        }

        /// <summary>
        /// Di chuyển người chơi lên 1 vị trí trong tổ đội.
        /// </summary>
        private async Task MovePlayerUpAsync(int playerId) {
            await packetWriter.SendCommandAsync("34103", playerId.ToString(), "0");
        }

        /// <summary>
        /// Di chuyển người chơi xuống 1 vị trí trong tổ đội.
        /// </summary>
        private async Task MovePlayerDownAsync(int playerId) {
            await packetWriter.SendCommandAsync("34103", playerId.ToString(), "1");
        }

        /// <summary>
        /// Kick người chơi ta khỏi tổ đội.
        /// </summary>
        private async Task KickPlayerAsync(int playerId) {
            await packetWriter.SendCommandAsync("34104", playerId.ToString());
        }

        /// <summary>
        /// Giải tán tổ đội.
        /// </summary>
        private async Task DisbandAsync() {
            await packetWriter.SendCommandAsync("34105");
        }

        /// <summary>
        /// Thoát khỏi tổ đội.
        /// </summary>
        private async Task QuitAsync() {
            await packetWriter.SendCommandAsync("34106");
        }

        /// <summary>
        /// Tấn công tổ đội.
        /// </summary>
        private async Task AttackAsync() {
            await packetWriter.SendCommandAsync("34107", "0");
        }

        /// <summary>
        /// Ép tấn công.
        /// </summary>
        private async Task ForceAttackAsync() {
            // Tạo quân đoàn đổng trác.
            var t1 = CreateAsync(900001, 0, TeamLimit.None);

            // Tấn công.
            var t2 = AttackAsync();

            // Giải tán quân đoàn đổng trác.
            var t3 = DisbandAsync();

            await Task.WhenAll(t1, t2, t3);
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

        private async void refreshTeamTimer_Tick(object sender, EventArgs e) {
            if (autoRefreshTeamBox.Checked) {
                await RefreshSelectedArmyAsync();
            }
        }

        private async void refreshTeamButton_Click(object sender, EventArgs e) {
            await RefreshSelectedArmyAsync();
        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private async void teamList_ButtonClick(object sender, CellClickEventArgs e) {
            var item = e.Item;
            var team = (Team) item.RowObject;
            await JoinAsync(team.Id);
        }

        private async void joinX10Button_Click(object sender, EventArgs e) {
            var item = teamList.SelectedItem;
            if (item != null) {
                var team = (Team) item.RowObject;
                for (int i = 0; i < 10; ++i) {
                    await JoinAsync(team.Id);
                }
            }
        }

        private async void attackButton_Click(object sender, EventArgs e) {
            await AttackAsync();
        }

        private async void disbandButton_Click(object sender, EventArgs e) {
            await DisbandAsync();
        }

        private async void quitButton_Click(object sender, EventArgs e) {
            await QuitAsync();
        }

        private async void forceAttackButton_Click(object sender, EventArgs e) {
            await ForceAttackAsync();
        }

        private async void memberList_ButtonClick(object sender, CellClickEventArgs e) {
            var item = e.Item;
            var member = (Member) item.RowObject;
            if (e.ColumnIndex == 1) {
                await KickPlayerAsync(member.Id);
            } else if (e.ColumnIndex == 2) {
                await MovePlayerUpAsync(member.Id);
            } else if (e.ColumnIndex == 3) {
                await MovePlayerDownAsync(member.Id);
            }
        }

        private async void createButton_Click(object sender, EventArgs e) {
            var item = armyList.SelectedItem;
            if (item != null) {
                var army = (Army) item;
                await CreateAsync(army.Id, 0, TeamLimit.None);
            }
        }

        private async void createLegionButton_Click(object sender, EventArgs e) {
            var item = armyList.SelectedItem;
            if (item != null) {
                var army = (Army) item;
                await CreateAsync(army.Id, 0, TeamLimit.Legion);
            }
        }

        private void refreshTeamInterval_ValueChanged(object sender, EventArgs e) {
            refreshTeamTimer.Interval = (int) refreshTeamInterval.Value;
        }

        private async void autoRefreshTeamBox_CheckedChanged(object sender, EventArgs e) {
            if (autoRefreshTeamBox.Checked) {
                await RefreshSelectedArmyAsync();
            }
        }

        #region Add clone vao listbox
        public void addClone(string name)
        {
            this.lbList.Items.Add(name);
            listAcc.Add(name);
        }
        #endregion

        #region Remove clone vao listbox
        public void removeClone(string name)
        {
            this.lbList.Items.Remove(name);
            listAcc.Remove(name);
        }
        #endregion

        public void loadClones()
        {
            listAcc = new List<string>();
            if (File.Exists(FILE_DS))
            {
                string[] lines = System.IO.File.ReadAllLines(FILE_DS);

                foreach (string line in lines)
                {
                    this.lbList.Items.Add(line);
                    listAcc.Add(line);
                }
            }
        }

        public bool findInList(string name)
        {
            for (int i = 0; i < listAcc.Count; i++)
            {
                if (name == listAcc[i].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        private void btnAddAccClone_Click(object sender, EventArgs e)
        {
            addClone(txtNameAccClone.Text);
            using (System.IO.StreamWriter listDef = new System.IO.StreamWriter(FILE_DS, true))
            {
                listDef.WriteLine(txtNameAccClone.Text);
            }
        }

        private void btnRemoveAccClone_Click(object sender, EventArgs e)
        {
            if (this.lbList.SelectedItem != null)
            {
                string curItem = this.lbList.SelectedItem.ToString();
                removeClone(curItem);
            }
            using (System.IO.StreamWriter listDef = new System.IO.StreamWriter(FILE_DS, false))
            {
                for (int i = 0; i < this.lbList.Items.Count; i++)
                {
                    listDef.WriteLine(this.lbList.Items[i].ToString());
                }
            }
        }

        private void btnLoadAccClone_Click(object sender, EventArgs e)
        {
            loadClones();
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
