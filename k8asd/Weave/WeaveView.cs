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
    public partial class WeaveView : UserControl, IPacketReader {
        private const int NoTeam = -1;

        private enum TeamLimit {
            Nation = 1,
            Legion = 2,
        }

        private class Team {
            private string baojirate;
            private int cost;
            private string desc;
            private int legion; // ???
            private int level;
            private int limit; // ???
            private int limitlv; // ??
            private int maxnum;
            private int mnation; // ???
            private int nation; // ???
            private int num;
            private int price;
            private string product;
            private string succrate;
            private int teamid;
            private string teamname;

            public int Id { get { return teamid; } }
            public string Name { get { return teamname; } }
            public int Level { get { return level; } }
            public int PlayerCount { get { return num; } }
            public int MaxPlayerCount { get { return maxnum; } }
            public int Cost { get { return cost; } }
            public int Price { get { return price; } }
            public string SuccessRate { get { return succrate; } }
            public string CriticalRate { get { return baojirate; } }

            public static Team Parse(JToken token) {
                var result = new Team();
                result.baojirate = (string) token["baojirate"];
                result.cost = (int) token["cost"];
                result.desc = (string) token["desc"];
                result.legion = (int) token["legion"];
                result.level = (int) token["level"];
                result.limit = (int) token["limit"];
                result.limitlv = (int) token["limitlv"];
                result.maxnum = (int) token["maxnum"];
                result.mnation = (int) token["mnation"];
                result.nation = (int) token["nation"];
                result.num = (int) token["num"];
                result.price = (int) token["price"];
                result.product = (string) token["product"];
                result.succrate = (string) token["succrate"];
                result.teamid = (int) token["teamid"];
                result.teamname = (string) token["teamname"];
                return result;
            }

            public string Description() {
                return String.Format("{0} Lv. {1} ({2}/{3}) [{4} - {5}] [{6} - {7}]",
                    Name, Level, PlayerCount, MaxPlayerCount, Cost, Price, SuccessRate, CriticalRate);
            }
        }

        private class Member {
            private int level;
            private string name;
            private int playerid;
            private int price;
            private int spinnerTotalLevel;

            public int Id { get { return playerid; } }
            public string Name { get { return name; } }
            public int Level { get { return level; } }
            public int SpinnerLevel { get { return spinnerTotalLevel; } }

            public static Member Parse(JToken token) {
                var result = new Member();
                result.level = (int) token["level"];
                result.name = (string) token["name"];
                result.playerid = (int) token["playerid"];
                result.price = (int) token["price"];
                result.spinnerTotalLevel = (int) token["spinnerTotalLevel"];
                return result;
            }

            public string Description() {
                return String.Format("{0} Lv. {1} - Công nhân {2}", Name, Level, SpinnerLevel);
            }
        }

        private class Product {
            private string baojirate;
            private int cost;
            private string desc;
            private int level;
            private string name;
            private int price;
            private int prodid;
            private string succrate;

            public int Id { get { return prodid; } }
            public int Level { get { return level; } }
            public int Cost { get { return cost; } }
            public int Price { get { return price; } }
            public string SuccessRate { get { return succrate; } }
            public string CriticalRate { get { return baojirate; } }

            public static Product Parse(JToken token) {
                var result = new Product();
                result.baojirate = (string) token["baojirate"];
                result.cost = (int) token["cost"];
                result.desc = (string) token["desc"];
                result.level = (int) token["level"];
                result.name = (string) token["name"];
                result.price = (int) token["price"];
                result.prodid = (int) token["prodid"];
                result.succrate = (string) token["succrate"];
                return result;
            }

            public string Description() {
                return String.Format("Lv. {0} [{1} - {2}] [{3} - {4}]",
                    Level, Cost, Price, SuccessRate, CriticalRate);
            }
        }

        private int currentTeamId;
        private int currentTextilePrice;
        private int currentTurnCount;

        private BindingList<Team> teams;
        private BindingList<Member> members;

        private ICooldownModel cooldown;
        private IPacketWriter packetWriter;

        public WeaveView() {
            InitializeComponent();

            teams = new BindingList<Team>();
            members = new BindingList<Member>();

            currentTeamId = NoTeam;
            currentTextilePrice = 999;
            currentTurnCount = 0;

            memberBox.Enabled = false;
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetCooldownModel(ICooldownModel cooldown) {
            this.cooldown = cooldown;
        }

        private void RefreshTeams() {
            Action<Packet> callback = (Packet packet) => {
                Parse45200(packet);
                CheckAutoCreate();
                CheckAutoMake();
                CheckAutoQuitAndMake();
            };

            if (packetWriter.SendCommand(callback, "45200")) {
                //
            }
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "45300") {
                Parse45300(packet);
            }
            if (packet.CommandId == "60603") {
                // int x = 1;
            }
        }

        private void Parse45200(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var message = token["message"];
            if (message != null) {
                // Chưa đủ lv 82.
                baseInfoBox.Enabled = false;
                teamBox.Enabled = false;
                return;
            }
            baseInfoBox.Enabled = true;
            teamBox.Enabled = true;

            var baseinfo = token["baseinfo"];
            ParseBaseInfo(baseinfo);

            var teamList = token["teamList"];
            ParseTeams(teamList);

            /*
            makecd = Convert.ToInt32(r45200.makecd);
            btnWeaveTeam.Text = r45200.listteam.Count.ToString() + " tổ đội";
            
            if (weaveautoupdate)
                switch (cbbWeaveMode.SelectedIndex) {
                case 1:
                    /*
                    foreach (R45200.Team tm in r45200.listteam)
                        if (((tm.nation == r11102.nation
                            && tm.legion == "0")
                            || tm.legion == r11102.legionid)
                            && Convert.ToInt32(tm.limitlv)
                            <= Convert.ToInt32(r45200.info.totallevel)
                            && Convert.ToInt32(tm.num) < 3) {
                            LogText("[Dệt] Gia nhập tổ đội dệt (" + tm.num + "/3) của " + tm.teamname);
                            SendMsg("45209", tm.teamid);
                            break;
                        }
                    break;
                case 2:
                    /*
                    foreach (R45200.Team tm in r45200.listteam)
                        if (tm.teamname == r11102.playername) {
                            if (Convert.ToInt32(tm.num) >= numWeaveLimit.Value
                                && chkWeaveMake.Checked)
                                btnWeaveMake_Click(null, null);
                            break;
                        }
                    break;
                }
            weaveok = true;
            break;
        #endregion
        */
        }

        private void Parse45300(Packet packet) {
            var token = JToken.Parse(packet.Message);
            var teamObject = token["teamObject"];
            if (teamObject != null) {
                ParseTeamInfo(teamObject);
                memberBox.Enabled = true;
                CheckAutoMake();
                CheckAutoQuitAndMake();
            } else {
                // teamId = 0;
                memberBox.Enabled = false;
            }
        }

        private void ParseBaseInfo(JToken token) {
            var num = (int) token["num"];
            var price = (int) token["price"];
            var maxnum = (int) token["maxnum"];
            var succrate = (int) token["succrate"];
            var gold = (int) token["gold"]; // ???
            var totallevel = (int) token["totallevel"];
            var baojirate = (int) token["baojirate"];
            var priceway = (int) token["priceway"];

            spinnerLevelLabel.Text = String.Format("Công nhân: Lv. {0}", totallevel);
            spinnerRateLabel.Text = String.Format("Tỉ lệ: {0} - {1}", succrate, baojirate);
            priceLabel.Text = String.Format("Giá bán: {0} {1} {2}", price,
                priceway == 1 ? "▲" : "▼",
                priceway == 1 ? "(Lên)" : "(Xuống)");
            numLabel.Text = String.Format("Lượt: {0}/{1}", num, maxnum);

            currentTurnCount = num;
        }

        private void ParseTeams(JToken token) {
            teams.Clear();
            foreach (var teamToken in token) {
                var team = Team.Parse(teamToken);
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

        private void ParseTeamInfo(JToken token) {
            var memberlist = token["memberlist"];
            ParseMembers(memberlist);

            var baojirate = (string) token["baojirate"];
            var cost = (int) token["cost"];
            var level = (int) token["level"];
            var price = (int) token["price"];
            var succrate = (string) token["succrate"];
            currentTeamId = (int) token["teamid"];
            teamLevelLabel.Text = String.Format("Cấp: {0}", level);
            teamPriceLabel.Text = String.Format("Giá: {0} - {1}", cost, price);
            teamRateLabel.Text = String.Format("Tỉ lệ: {0} - {1}", succrate, baojirate);
        }

        private void refreshTeamButton_Click(object sender, EventArgs e) {
            RefreshTeams();
        }

        private void autoRefreshTeamBox_CheckedChanged(object sender, EventArgs e) {
            CheckAutoRefresh();
        }

        private void refreshTeamInterval_ValueChanged(object sender, EventArgs e) {
            refreshTeamTimer.Interval = (int) refreshTeamInterval.Value;
        }

        private void refreshTeamTimer_Tick(object sender, EventArgs e) {
            UpdateAuto();
        }

        private void teamList_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void teamList_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e) {
            var item = e.Item;
            var team = (Team) item.RowObject;
            Join(team.Id);
        }

        private void Create(int productId, TeamLimit limit) {
            packetWriter.SendCommand("45202", productId.ToString(), "0", ((int) limit).ToString());
        }

        private void Make(int teamId) {
            packetWriter.SendCommand("45208", teamId.ToString());
        }

        private void Disband(int teamId) {
            packetWriter.SendCommand("45207", teamId.ToString());
        }

        private void Join(int teamId) {
            /*
           KryptonContextMenuItem item = (KryptonContextMenuItem) sender;
           if (r45300 == null
               || (r45300.type == "3"
               && item.Text.Contains(r11102.playername)))
               SendMsg("45209", item.Tag.ToString());
               */
            packetWriter.SendCommand("45209", teamId.ToString());
        }

        private void Quit(int teamId) {
            packetWriter.SendCommand("45210", teamId.ToString());
        }

        private void Kick(int teamId, int playerId) {
            packetWriter.SendCommand("45206", teamId.ToString(), playerId.ToString());
        }

        private void disbandButton_Click(object sender, EventArgs e) {
            if (currentTeamId != NoTeam) {
                Disband(currentTeamId);
            }
        }

        private void makeButton_Click(object sender, EventArgs e) {
            if (currentTeamId != NoTeam) {
                Make(currentTeamId);
            }
        }

        private void forceAttackButton_Click(object sender, EventArgs e) {
            packetWriter.SendCommand("45201");
        }

        private void createButton_Click(object sender, EventArgs e) {
            // Create(20, TeamLimit.Nation);
        }

        private void createLegionButton_Click(object sender, EventArgs e) {
            Create((int) textileLevelInput.Value, TeamLimit.Legion);
        }

        private void memberList_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e) {
            if (currentTeamId != NoTeam) {
                var item = e.Item;
                var member = (Member) item.RowObject;
                Kick(currentTeamId, member.Id);
            }
        }

        private void quitButton_Click(object sender, EventArgs e) {
            if (currentTeamId != NoTeam) {
                Quit(currentTeamId);
            } else {
                // packetWriter.SendCommand("60603", "12", "0", "200200", "200");
            }
        }

        private void autoCreate_CheckedChanged(object sender, EventArgs e) {
            CheckAutoCreate();
        }

        /// <summary>
        /// Checks whether the current player is hosting any weaving party.
        /// </summary>
        /// <returns>True if the the current player is hosting a weaving party, false otherwise</returns>
        private bool IsHosting() {
            foreach (var team in teams) {
                if (team.Id == currentTeamId) {
                    return true;
                }
            }
            return false;
        }

        private void UpdateAuto() {
            CheckAutoRefresh();
        }

        private void CheckAutoRefresh() {
            if (!autoRefreshTeamBox.Checked) {
                return;
            }
            RefreshTeams();
        }

        private void CheckAutoCreate() {
            if (!autoCreate.Checked) {
                return;
            }
            if (cooldown.WeaveCooldown > 0) {
                return;
            }
            if (IsHosting()) {
                return;
            }
            var textileLevel = (int) textileLevelInput.Value;
            Create(textileLevel, TeamLimit.Legion);
        }

        private void CheckAutoMake() {
            if (!autoMake.Checked) {
                return;
            }
            var textilePrice = (int) textilePriceInput.Value;
            if (currentTextilePrice < textilePrice) {
                return;
            }
            if (!IsHosting()) {
                return;
            }
            if (members.Count < 3) {
                return;
            }
            if (autoQuitAndMake.Checked && currentTurnCount <= 1) {
                return;
            }
            Make(currentTeamId);
        }

        private void CheckAutoQuitAndMake() {
            if (!autoQuitAndMake.Checked) {
                return;
            }
            if (!IsHosting()) {
                return;
            }
            if (members.Count < 3) {
                return;
            }
            if (autoMake.Checked && currentTurnCount > 1) {
                return;
            }
            Quit(currentTeamId);
            Make(currentTeamId);
        }

        private void autoMake_CheckedChanged(object sender, EventArgs e) {

        }

        private void autoQuitAndMake_CheckedChanged(object sender, EventArgs e) {

        }
    }


    /*
    private void btnWeaveInvite_Click(object sender, EventArgs e) {
    int cnum = Convert.ToInt32(r45300.num);
    int mnum = Convert.ToInt32(r45300.maxnum);
    /*
    if (cnum <= mnum)
        SendMsg("10103", r11102.playername,
            "Tổ đội dệt vải cấp " + r45300.level
            + " đã được lập "
            + "<a href='event:textile|" + r45300.teamid
            + "'>[Gia nhập]</a>",
            (cbbChat.SelectedIndex + 1).ToString(), " ");
    }    
    */
}
