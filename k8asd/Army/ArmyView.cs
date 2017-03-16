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

        private BindingList<Army> armies;
        private BindingList<ArmyTeam> teams;
        private BindingList<ArmyMember> members;
        private IPacketWriter packetWriter;
        private IInfoModel infoModel;
        private IMcuModel mcuModel;

        public ArmyView() {
            InitializeComponent();

            armies = new BindingList<Army>();
            armyList.DataSource = armies;

            teams = new BindingList<ArmyTeam>();
            members = new BindingList<ArmyMember>();

            teamColumn.AspectGetter = (obj) => {
                var team = (ArmyTeam) obj;
                return String.Format("{0} {1} ({2}/{3}) [{4}]",
                    team.Name, team.Condition, team.PlayerCount, team.MaxPlayerCount,
                    Utils.FormatDuration(team.RemainingTime));
            };

            memberColumn.AspectGetter = (obj) => {
                var member = (ArmyMember) obj;
                return String.Format("{0} Lv. {1}", member.Name, member.Level);
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
            try { 
                Enabled = false;
                armies.Clear();

                var packet = await packetWriter.RefreshPowerAreaAsync(1);
                if (packet == null) {
                    return;
                }
                Debug.Assert(packet.CommandId == "33201");

                var powerIds = Parse33201(packet);
                foreach (var powerId in powerIds) {
                    var powerPacket = await packetWriter.RefreshPowerAsync(powerId);
                    if (powerPacket == null) {
                        return;
                    }
                    Debug.Assert(powerPacket.CommandId == "33100");

                    var army = Parse33100(powerPacket);
                    if (army != null) {
                        armies.Add(army);
                    }
                }
            } finally {
                Enabled = true;
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
            var packet = await packetWriter.RefreshArmyAsync(armyId);
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
                }   
            }
            if (packet.CommandId == "34105" || packet.CommandId == "34106" || packet.CommandId == "34107")
            {
                isCreating = false;
                isJoinning = false;
            }
            if (packet.CommandId == "34102")
            {
                if (!packet.Message.ToLower().Contains("ngài đã đánh bại bang hội này") &&
                    !packet.Message.ToLower().Contains("lượt vẫn đang đóng băng"))
                {
                    isJoinning = true;
                }
            }

            if (packet.CommandId == "34104")
            {
                isJoinning = true;
                if (!packet.Message.ToLower().Equals(""))
                {
                    isJoinning = false;
                }
            }
            Console.WriteLine("packet.CommandId " + packet.CommandId);
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
                var team = ArmyTeam.Parse(teamToken, infoModel.ServerTime);
                teams.Add(team);
                if (!findInList(team.Name))
                {
                    if (team.Condition.Equals(" cấp 0 trở lên") && this.chkAutoJoin.Checked &&
                    !isJoinning && team.PlayerCount < 8 && mcuModel.Tokencdusable == true)
                    {
                        await packetWriter.JoinArmyAsync(team.Id);
                    }
                }
            }

            if (this.chkAutoPt.Checked && !isCreating && mcuModel.Tokencdusable == true)
            {
                createArmy();
            }

            var oldSelectedIndex = teamList.SelectedIndex;
            teamList.SetObjects(teams, true);
            teamList.SelectedIndex = oldSelectedIndex;
        }

        private async void ParseMembers(JToken token) {
            members.Clear();
            foreach (var memberToken in token) {
                var member = ArmyMember.Parse(memberToken);
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
            Console.WriteLine("test join: " + isJoinning);
            //auto kick
            if (this.chkKick.Checked)
            {
                for (int i = 0; i < members.Count; i++)
                {
                    if (!findInList(members[i].Name))
                    {
                        await packetWriter.KickArmyPlayerAsync(members[i].Id);
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

        /// <summary>
        /// Tạo tổ đội quân đoàn.
        /// </summary>
        /// <param name="armyId">ID của quân đoàn.</param>
        /// <param name="minimumLevel">Giới hạn cấp độ tối thiểu.</param>
        /// <param name="limit">Giới hạn chung</param>
        private async Task CreateAsync(int armyId, int minimumLevel, ArmyTeamLimit limit) {
            if (!isCreating)
            {
                await packetWriter.SendCommandAsync("34101", armyId.ToString(), String.Format("4:{0};{1}", minimumLevel, (int)limit), "0");
            }
        }        

        /// <summary>
        /// Ép tấn công.
        /// </summary>
        private async Task ForceAttackAsync() {
            // Tạo quân đoàn đổng trác.
            var t1 = CreateAsync(900001, 0, ArmyTeamLimit.None);

            // Tấn công.
            var t2 = packetWriter.AttackArmyAsync();

            // Giải tán quân đoàn đổng trác.
            var t3 = packetWriter.DisbandArmyAsync();

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
            var team = (ArmyTeam) item.RowObject;
            await packetWriter.JoinArmyAsync(team.Id);
        }

        private async void joinX10Button_Click(object sender, EventArgs e) {
            var item = teamList.SelectedItem;
            if (item != null) {
                var team = (ArmyTeam) item.RowObject;
                for (int i = 0; i < 10; ++i) {
                    await packetWriter.JoinArmyAsync(team.Id);
                }
            }
        }

        private async void attackButton_Click(object sender, EventArgs e) {
            await packetWriter.AttackArmyAsync();
        }

        private async void disbandButton_Click(object sender, EventArgs e) {
            await packetWriter.DisbandArmyAsync();
        }

        private async void quitButton_Click(object sender, EventArgs e) {
            await packetWriter.QuitArmyAsync();
        }

        private async void forceAttackButton_Click(object sender, EventArgs e) {
            await ForceAttackAsync();
        }

        private async void memberList_ButtonClick(object sender, CellClickEventArgs e) {
            var item = e.Item;
            var member = (ArmyMember) item.RowObject;
            if (e.ColumnIndex == 1) {
                await packetWriter.KickArmyPlayerAsync(member.Id);
            } else if (e.ColumnIndex == 2) {
                await packetWriter.MoveArmyPlayerUpAsync(member.Id);
            } else if (e.ColumnIndex == 3) {
                await packetWriter.MoveArmyPlayerDownAsync(member.Id);
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
                await CreateAsync(army.Id, 0, ArmyTeamLimit.None);
            }
        }

        private async void createLegionButton_Click(object sender, EventArgs e) {
            var item = armyList.SelectedItem;
            if (item != null) {
                var army = (Army) item;
                await CreateAsync(army.Id, 0, ArmyTeamLimit.Legion);
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
