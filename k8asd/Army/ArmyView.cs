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
        private bool isCreating = false;
        private bool isJoinning = false;

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
                result.cooldown = new Cooldown((int) (endDateTime - DateTime.Now).TotalMilliseconds);
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
        private IMcuModel mcuModel;

        public ArmyView() {
            InitializeComponent();

            armies = new BindingList<Army>();
            armyList.DataSource = armies;

            teams = new BindingList<Team>();
            members = new BindingList<Member>();

            teamColumn.AspectGetter = (obj) => {
                var team = (Team) obj;
                return String.Format("{0} {1} ({2}/{3}) [{4}]",
                    team.Name, team.Condition, team.PlayerCount, team.MaxPlayerCount,
                    Utils.FormatDuration(team.RemainingTime));
            };

            loadClones();
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
        }

        public void SetMcuModel(IMcuModel model)
        {
            mcuModel = model;
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

            if (packet.CommandId == "34101")
            {
                if (!packet.Message.ToLower().Contains("ngài đã đánh bại bang hội này") &&
                    !packet.Message.ToLower().Contains("lượt vẫn đang đóng băng"))
                {
                    isCreating = true;
                    isJoinning = true;
                }   
            }
            if (packet.CommandId == "34105" || packet.CommandId == "34106" || packet.CommandId == "34107")
            {
                isCreating = false;
                isJoinning = false;
            }
            if (packet.CommandId == "34102")
            {
                isJoinning = true;
            }
            if (packet.CommandId == "34104")
            {
                isJoinning = true;
                if (!packet.Message.ToLower().Equals(""))
                {
                    isJoinning = false;
                }
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
            //fix chua the lam moi quan doan nay
            if (armies != null)
            {
                UpdateArmyPanel(armies);

                var team = token["team"];
                ParseTeams(team);

                var member = token["member"];
                ParseMembers(member);
            }
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

        private async void ParseTeams(JToken token) {
            teams.Clear();
            foreach (var teamToken in token) {
                var team = Team.Parse(teamToken, infoModel.ServerTime);
                teams.Add(team);
                if (!findInList(team.Name))
                {
                    if (team.Condition.Equals(" cấp 0 trở lên") && this.chkAutoJoin.Checked &&
                    !isJoinning && team.PlayerCount < 8 && mcuModel.Tokencdusable == true)
                    {
                        await JoinAsync(team.Id);
                    }
                }
            }

            //auto create
            Console.WriteLine("test: " + isCreating);
            if (this.chkAutoPt.Checked && !isCreating && mcuModel.Tokencdusable == true)
            {
                //this.createButton.PerformClick();
                createArmy();
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

            //kiem tra co con trong to doi hay ko
            if (members.Count == 0)
            {
                isJoinning = false;
                isCreating = false;
            }

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
            if (!isCreating)
            {
                await packetWriter.SendCommandAsync("34101", armyId.ToString(), String.Format("4:{0};{1}", minimumLevel, (int)limit), "0");
            }
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
            this.autoRefreshTeamBox.Checked = true;
            if (isCreating)
            {
                this.disbandButton.PerformClick();
            }
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

        private void createButton_Click(object sender, EventArgs e) {
            createArmy();
            //var item = armyList.SelectedItem;
            //if (item != null) {
            //    var army = (Army) item;
            //    await CreateAsync(army.Id, 0, TeamLimit.None);
            //}
        }

        public async void createArmy()
        {
            var item = armyList.SelectedItem;
            if (item != null)
            {
                var army = (Army)item;
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
            this.lbList.Items.Clear();
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
}
