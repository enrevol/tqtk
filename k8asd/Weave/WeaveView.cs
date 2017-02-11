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
                return String.Format("{0} - Lv. {1} ({2}/{3}) [{4} - {5}] [{6} - {7}]",
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

        private BindingList<Team> teams;
        private BindingList<Member> members;
        private IPacketWriter packetWriter;
        private int teamId;

        public WeaveView() {
            InitializeComponent();

            teams = new BindingList<Team>();
            members = new BindingList<Member>();

            teamId = NoTeam;
            memberBox.Enabled = false;
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        private void RefreshTeams() {
            if (packetWriter.SendCommand("45200")) {

            }
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "45200") {
                Parse45200(packet);
            }
            if (packet.CommandId == "45300") {
                Parse45300(packet);
            }
        }

        private void Parse45200(Packet packet) {
            var token = JToken.Parse(packet.Message);

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
            teamId = (int) token["teamid"];
            teamLevelLabel.Text = String.Format("Cấp: {0}", level);
            teamPriceLabel.Text = String.Format("Giá: {0} - {1}", cost, price);
            teamRateLabel.Text = String.Format("Tỉ lệ: {0} - {1}", succrate, baojirate);
        }

        private void refreshTeamButton_Click(object sender, EventArgs e) {
            RefreshTeams();
        }

        private void autoRefreshTeamBox_CheckedChanged(object sender, EventArgs e) {
            if (autoRefreshTeamBox.Checked) {
                RefreshTeams();
            }
        }

        private void refreshTeamInterval_ValueChanged(object sender, EventArgs e) {
            refreshTeamTimer.Interval = (int) refreshTeamInterval.Value;
        }

        private void refreshTeamTimer_Tick(object sender, EventArgs e) {
            if (autoRefreshTeamBox.Checked) {
                RefreshTeams();
            }
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
            if (teamId != NoTeam) {
                Disband(teamId);
            }
        }

        private void makeButton_Click(object sender, EventArgs e) {
            if (teamId != NoTeam) {
                Make(teamId);
            }
        }

        private void forceAttackButton_Click(object sender, EventArgs e) {
            packetWriter.SendCommand("45201");
        }

        private void createButton_Click(object sender, EventArgs e) {

        }

        private void createLegionButton_Click(object sender, EventArgs e) {
            Create(21, TeamLimit.Legion);
        }

        private void memberList_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e) {
            if (teamId != NoTeam) {
                var item = e.Item;
                var member = (Member) item.RowObject;
                Kick(teamId, member.Id);
            }
        }

        private void quitButton_Click(object sender, EventArgs e) {
            if (teamId != NoTeam) {
                Quit(teamId);
            }
        }
    }


    /*



            #region 45201
            case "45201":
                r45201 = new R45201(cdata);
                if (r45201.m == null) {
                    cbbWeaveProduct.Items.Clear();
                    foreach (R45201.Product pr in r45201.listproduct)
                        cbbWeaveProduct.Items.Add("(" + pr.level + ") " + pr.name);
                    cbbWeaveProduct.SelectedIndex = 0;

                    cbbWeaveWorker.Items.Clear();
                    foreach (R45201.Worker wk in r45201.listworker)
                        cbbWeaveWorker.Items.Add("(" + wk.level + ") " + wk.name);
                    cbbWeaveWorker.SelectedIndex = 0;

                    grpWeaveCreate.Visible = true;
                    if (weavecreate) {
                        int a = r45201.listproduct.Count;
    int b = Convert.ToInt32(numWeaveProduct.Value);
    int n = Math.Max(a - b, 0);
    cbbWeaveProduct.SelectedIndex = n;
                        LogText("[Dệt] Lập tổ đội dệt vải cấp " + Math.Min(a, b));
                        btnWeaveCreate1_Click(null, null);
                    }
                } else
                    LogText("[Dệt] " + r45201.m);
                break;
            #endregion

            #region 45202
            case "45202": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                    grpWeaveParty.Enabled = true;
                    if (weavecreate) {
                        weavecreate = false;
                        weaveok = true;
                    }
                }
                break;
            #endregion

            #region 45206
            case "45206": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 45207
            case "45207": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 45208
            case "45208": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Dệt] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion
            #region 45210
            case "45210":
                break;
            #endregion

            #region 45300
            case "45300":
                r45300 = new R45300(cdata);

    lstWeaveMember.Items.Clear();

                if (r45300.type == "0") {
                    makecd = Convert.ToInt32(r45300.makecd) * 1000;
                    LogText("[Dệt] " + r45300.msg);
    r45300 = null;
                } else if (r45300.type == "1")
                    r45300 = null;
                else if (r45300.type == "2") {
                    txtWeaveInfo5.Text = r45300.level;
                    txtWeaveInfo6.Text = r45300.succrate + " - " + r45300.baojirate;
                    txtWeaveInfo7.Text = r45300.cost + " - " + r45300.price;

                    grpWeaveInfo2.Enabled = true;
                    lstWeaveMember.Enabled = true;
                    btnWeaveCreate.Enabled = false;

                    foreach (R45300.Member mem in r45300.listmember)
                        lstWeaveMember.Items.Add("(" + mem.spinnerTotalLevel + ") "
                            + mem.name + " (" + mem.level + ") ["
                            + mem.price + "]");

                    if (r45300.leaderid == loginHelper.Session.UserId) {
                        btnWeaveQuit.Enabled = false;
                        btnWeaveMake.Enabled = true;
                        btnWeaveDisband.Enabled = true;
                    } else {
                        btnWeaveQuit.Enabled = true;
                        btnWeaveMake.Enabled = false;
                        btnWeaveDisband.Enabled = false;
                    }

                    btnWeaveInvite.Enabled = r45300.listmember.Count< 3;
                    if (chkWeave.Checked)
                        switch (cbbWeaveMode.SelectedIndex) {
                        case 0:
                            if (r45300.listmember.Count >= numWeaveLimit.Value
                                && chkWeaveMake.Checked)
                                btnWeaveMake_Click(null, null);
                            break;
                        case 2:
                            SendMsg("45206", r45300.teamid, loginHelper.Session.UserId);
                            break;
                        }
                } else if (r45300.type == "3") {
                    bool playerishost = false;
                    /*
                    foreach (R45200.Team tm in r45200.listteam)
                        if (tm.teamname == r11102.playername) {
                            playerishost = true;
                            break;
                        }

                    if (playerishost) {
                        btnWeaveDisband.Enabled = true;
                        btnWeaveMake.Enabled = true;
                        btnWeaveInvite.Enabled = true;
                    } else
                        r45300 = null;
                }
                break;
            #endregion


    private void chkWeave_CheckedChanged(object sender, EventArgs e) {
            //weaveok = chkWeave.Checked;
        }


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

    private void btnWeaveCreate1_Click(object sender, EventArgs e) {
    // grpWeaveCreate.Visible = false;
    //  SendMsg("45202", (cbbWeaveProduct.Items.Count - cbbWeaveProduct.SelectedIndex).ToString(), "0", "2");
    }

    private void btnWeaveCreate2_Click(object sender, EventArgs e) {
    // grpWeaveCreate.Visible = false;
    //  grpWeaveParty.Enabled = true;
    }

    /*
    private void lstWeaveMember_SelectedValueChanged(object sender, EventArgs e) {
    int index = lstWeaveMember.SelectedIndex;
    if (lstWeaveMember.Items.Count >= 1
        && r45300.leaderid == loginHelper.Session.UserId)
        SendMsg("45206", r45300.teamid, r45300.listmember[index].playerid);
    }

    private void cbbWeaveProduct_SelectedIndexChanged(object sender, EventArgs e) {
    int index = cbbWeaveProduct.SelectedIndex;
    if (index >= 0) {
        R45201.Product pr = r45201.listproduct[index];
        txtWeaveInfo8.Text = pr.succrate + " - " + pr.baojirate;
        txtWeaveInfo9.Text = pr.cost + " - " + pr.price;
    }
    }

    private void cbbWeaveWorker_SelectedIndexChanged(object sender, EventArgs e) {
    int index = cbbWeaveWorker.SelectedIndex;
    if (index >= 0) {
        R45201.Worker wk = r45201.listworker[index];
        txtWeaveExp.Text = wk.exp + "%";
        lblWeaveSkill1.Text = "";
        lblWeaveSkill2.Text = "";
        KryptonLabel[] lblskill =
        {
            lblWeaveSkill1,
            lblWeaveSkill2
        };
        int i = 0;
        string[] skill = wk.skill.Split('|');
        foreach (string s in skill)
            if (s != "")
                lblskill[i++].Text = s;
    }
    }

    private void btnWeaveQuit_Click(object sender, EventArgs e) {
    SendMsg("45210", r45300.teamid);
    }
    */
}
