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
    public partial class CampaignView : UserControl {
        private IPacketWriter packetWriter;
        private IPlayerInfo infoModel;

        public CampaignView() {
            InitializeComponent();
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


        private async void testButton_Click(object sender, EventArgs e) {
            await packetWriter.CreateCampaignAsync(1, 0, CampaignTeamLimit.None);
            await packetWriter.AttackCampaignAsync();
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "11102") {
                var token = JToken.Parse(packet.Message);
                var player = token["player"];
                var id = (string) player["id"];
                if (id.Length > 0) {
                    // Đang trong chiến dịch.
                    // FIXME.
                    int test = 1;
                }
            }
            if (packet.CommandId == "47108") {
                int test = 1;
            }
        }
    }

    /*
     * 
     * 
     * private void btnCampCreate_Click(object sender, EventArgs e) {
SendMsg("47001", V.listcampid[cbbCamp.SelectedIndex].ToString(), "4:0;" + (radCamp1.Checked ? "2" : "3"));
}

private void btnCampAttack_Click(object sender, EventArgs e) {
int cnum = Convert.ToInt32(r47008.currentnum);
int mnum = Convert.ToInt32(r47008.minplayer);
if (cnum >= mnum)
    SendMsg("47007");
}

private void btnCampMap_Click(object sender, EventArgs e) {
KryptonButton bt = (KryptonButton) sender;
string s = bt.Tag.ToString();
SendMsg(bt.Text == "■" ? "47103" : "47102",
    s.Substring(s.IndexOf(".") + 1),
    s.Remove(s.IndexOf(".")),
    r47107.id);
}

private void btnCampInfo_Click(object sender, EventArgs e) {
if (btnCampInfo.Text == "Tấn công") {
    cbbCamp.Enabled = false;
    btnCampInfo.Text = "Thoát";
    grpCampParty.Visible = true;
} else {
    cbbCamp.Enabled = true;
    btnCampInfo.Text = "Tấn công";
    grpCampParty.Visible = false;
}
}

private void btnCampTeam_Click(object sender, EventArgs e) {
if (r47008.listmember.Count == 0) {
    KryptonContextMenuItem item = (KryptonContextMenuItem) sender;
    SendMsg("47002", item.Tag.ToString());
}
}

private void btnCampInvite_Click(object sender, EventArgs e) {
int cnum = Convert.ToInt32(r47008.currentnum);
int mnum = Convert.ToInt32(r47008.maxnum);
/*
if (cnum > 0 && cnum < mnum)
    SendMsg("10103", r11102.playername,
        "Tổ đội đánh " + r47008.name
        + " đã được lập, còn " + (mnum - cnum).ToString() + " vị trí, hãy mau chóng đến "
        + "<a href='event:campaignBattle|" + r47008.listmember[0].playerid
        + "|" + (cbbCamp.SelectedIndex + 8).ToString()
        + "|" + r47008.id
        + "|" + r47008.id
        + "'>[Gia nhập]</a>",
        (cbbChat.SelectedIndex + 1).ToString(), " ");
}

private void btnCampQuitIn_Click(object sender, EventArgs e) {
SendMsg("47106", r47107.id);
}

private void btnCampDisband_Click(object sender, EventArgs e) {
SendMsg("47006");
}

private void btnCampQuit_Click(object sender, EventArgs e) {
SendMsg("47005");
}
*/
}


/*
 * 
 * 

            #region 47001
            case "47001":
                break;
            #endregion

            #region 47007
            case "47007": {
                    JToken token = JObject.Parse(cdata)["m"];
                    var campaignId = (string) token["campaignId"];
                    var id = (string) token["id"];
                    SendCommand("47101", "1", id);
                }
                break;
                #endregion

            /*
        #region 47008
        case "47008":
            r47008 = new R47008(cdata);

            if (r47008.m == null) {
                btnCampTeam.Text = r47008.listteam.Count.ToString() + " tổ đội";

                KryptonContextMenu context = new KryptonContextMenu();
                KryptonContextMenuItems items = new KryptonContextMenuItems();

                foreach (RTeam.Team tm in r47008.listteam) {
                    KryptonContextMenuItem item = new KryptonContextMenuItem();
                    item.Text = tm.teamname + " ["
                        + tm.condition + "] ("
                        + tm.currentnum + "/"
                        + tm.maxnum + ")";
                    item.Tag = tm.teamid;
                    item.Click += btnCampTeam_Click;

                    item.Enabled = r47008.listmember.Count == 0;
                    items.Items.Add(item);
                }

                if (items.Items.Count > 0) {
                    context.Items.Add(items);
                    btnCampTeam.KryptonContextMenu = context;
                } else
                    btnCampTeam.KryptonContextMenu = null;

                lstCampMember.Items.Clear();
                foreach (RTeam.Member mem in r47008.listmember)
                    lstCampMember.Items.Add(mem.playername + " (" + mem.playerlevel + ")");

                if (r47008.listmember.Count == 0) {
                    btnCampInfo.Enabled = true && campid == null;
                    btnCampCreate.Enabled = true;
                    btnCampAttack.Enabled = false;
                    btnCampDisband.Enabled = false;
                    btnCampQuit.Enabled = false;
                    btnCampInvite.Enabled = false;
                } else {
                    btnCampInfo.Enabled = false;
                    btnCampCreate.Enabled = false;

                    /*
                    if (r47008.listmember[0].playername == r11102.playername) {
                        btnCampAttack.Enabled = true;
                        btnCampDisband.Enabled = true;
                        btnCampQuit.Enabled = false;
                    } else {
                        btnCampAttack.Enabled = false;
                        btnCampDisband.Enabled = false;
                        btnCampQuit.Enabled = true;
                    }

                    btnCampInvite.Enabled = r47008.listmember.Count < Convert.ToInt32(r47008.maxplayer);
                    if (r47008.listmember.Count < Convert.ToInt32(r47008.minplayer))
                        btnCampAttack.Enabled = false;
                }
            } else
                LogText("[Chiến dịch] " + r47008.m);
            break;
        #endregion

        #region 47100
        case "47100":
            R47100 r47100 = new R47100(cdata);
            foreach (R47100.Reward rw in r47100.listreward)
                LogText("[Chiến dịch] Nhận được " + rw.award + " " + rw.name);
            break;
        #endregion

        #region 47101
        case "47101": {
                JToken token = JObject.Parse(cdata)["m"];
                campcd = Convert.ToInt32(token["cd"].ToString());
                campid = (string) token["id"];
                SendMsg("47107", campid, "1");
            }
            break;
        #endregion

        #region 47102
        case "47102": {
                JToken token = JObject.Parse(cdata)["m"];
                if (token["message"] != null)
                    LogText("[Chiến dịch] " + token["message"].ToString().Replace("\"", ""));
            }
            break;
        #endregion

        #region 47103
        case "47103": {
                JToken token = JObject.Parse(cdata)["m"];
                if (token["message"] != null)
                    LogText("[Chiến dịch] " + token["message"].ToString().Replace("\"", ""));
            }
            break;
        #endregion

        #region 47106
        case "47106":
            lblCampCd.Text = "";
            pnlCampMap.SendToBack();
            btnCampQuitIn.Visible = false;
            grpCampInfo.Visible = false;
            btnCampInfo.Enabled = true;
            campend = true;
            break;
        #endregion

        #region 47107
        case "47107":
            r47107 = new R47107(cdata);
            if (btnCampInfo.Text == "Thoát")
                btnCampInfo_Click(null, null);
            btnCampInfo.Enabled = false;
            for (int i = 0; i < 18; i++)
                for (int j = 0; j < 18; j++) {
                    btnCampMap[i, j].Visible = false;
                    btnCampMap[i, j].Text = "";
                }
            campmap = false;
            campend = false;
            goto case "47107s";
        #endregion

        #region 47107s
        case "47107s": {
                int w = Convert.ToInt32(r47107.width);
                int h = Convert.ToInt32(r47107.height);

                for (int i = 0; i < r47107.listblock.Count; i++) {
                    R47107.Block bl = r47107.listblock[i];

                    Point p = new Point(Convert.ToInt32(bl.x), Convert.ToInt32(bl.y));

                    KryptonButton bt = btnCampMap[p.Y, p.X];

                    Color color = Color.AliceBlue;

                    bt.Text = "";
                    //bt.Tooltip = "";
                    if (bl.solider != null) {
                        //bt.Tooltip = bl.solider.name + " (" + bl.solider.level + ")"
                        //+ "\r\nBinh lực: " + bl.solider.currforcesnum + "/" + bl.solider.maxforcesnum;
                        /*bt.Tooltip +=
                               + "\r\neffects: " + bl.solider.effects
                               + "\r\nfiretime: " + bl.solider.firetime
                               + "\r\nfx: " + bl.solider.fx
                               + "\r\nhit: " + bl.solider.hit
                               + "\r\nskill: " + bl.solider.skill;

        }

        if (bl.dx != "0") {
            if (bl.dx == "2")
                if (bl.solider.id == loginHelper.Session.UserId) {
                    color = Color.Yellow;
                    campxy = p;
                    campbl = bl;
                    if (!campmap)
                        foreach (WayPoint.Player player in HDVS.listplayer)
                            if (player.player.Equals(campxy))
                                camppl = player;
                    //bt.Tooltip += "\r\nTấn công: " + bl.solider.konum;
                } else
                    color = Color.Blue;
            else if (bl.dx == "1")
                color = Color.DarkRed;
        } else
            color = Color.FromArgb(150, 150, 150);

        F.CampBt(ref bt, color);

        //bt.Tooltip += "\r\nflag: " + bl.flag
        //    + "\r\nmap: " + bl.map
        //    + "\r\ntoken: " + bl.token;
    }

                if (!campmap) {
                    btnCampMap[campxy.Y, campxy.X].Visible = true;
                    F.CampMap(campbl.moveInfo, campxy, ref btnCampMap, r47107);
                    campmap = true;
                }

                for (int k = 0; k< 4; k++)
                    if (campbl.moveInfo[k] == '1') {
                        int m = campxy.Y + (k - 1) % 2;
    int n = campxy.X + (k - 2) % 2;

                        if (0 <= n && n<w
                            && 0 <= m && m<h) {
                            btnCampMap[m, n].Text = "▲";
                            int[] orient = { 2, 0, 3, 1 };

    btnCampMap[m, n].Orientation = (VisualOrientation) orient[k];
                            if (r47107.listblock[m * w + n].solider != null)
                                btnCampMap[m, n].Text = "■";
                        }
                    }

                txtCampInfo1.Text = r47107.info.armynum + "/" + r47107.maxarmynum;
                campactcd = Convert.ToInt32(r47107.info.nextactiontime);
                camprecd = Convert.ToInt32(r47107.info.remaintime);

                /*btnCampaign.Tooltip =
                    "interval: " + dt_47107.info.interval
                    + "\r\nmapCount: " + dt_47107.info.mapCount
                    + "\r\nreducetime: " + dt_47107.info.reducetime
                    + "r\nreduceusetime: " + dt_47107.info.reduceusetime;
        }
        break;
        #endregion

        #region 47108
        case "47108":
            R47107 r47108 = new R47107(cdata);
        {
            int w = Convert.ToInt32(r47108.width);
            int h = Convert.ToInt32(r47108.height);

            foreach (R47107.Block bl in r47108.listblock) {
                if (bl.dx == "2" && bl.solider == null)
                    bl.dx = "0";
                r47107.listblock[Convert.ToInt32(bl.y) * w + Convert.ToInt32(bl.x)] = bl;
            }

            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++) {
                    R47107.Block bl2 = r47107.listblock[i * w + j];
                    if (bl2.dx == "1")
                        bl2 = new R47107.Block("0", "0", "0", null, bl2.moveInfo, "0", bl2.x, bl2.y);
                }

            r47107.info = r47108.info;
        }
        goto case "47107s";
        #endregion

        #region 47109
        case "47109":
            R47109 r47109 = new R47109(cdata);
        LogText("[Chiến dịch] " + r47109.result);

        TimeSpan span = new TimeSpan(0, 0, 0, 0, Convert.ToInt32(r47109.time));
        txtLogs.AppendText(". Thời gian: " + F.GetTimewH(span));

        if (r47109.rank != "-1") {
            txtLogs.AppendText(" [" + V.listcamprank[Convert.ToInt32(r47109.rank) - 1] + "]");
            LogText("[Chiến dịch] Mở tàng bảo đồ...");

            SendMsg("47100", "1");
        }
        goto case "47106";
        #endregion

    */
#region Campaign

/*
    if (chkCamp.Checked
        && campactcd == 0
        && !campend) {
        int w = Convert.ToInt32(r47107.width);
        int h = Convert.ToInt32(r47107.height);

        int[,] xfinCost = new int[w, h];
        List<Point>[,] xfinPath = new List<Point>[w, h];
        {
            List<Point> curPath = new List<Point>();
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                    xfinCost[i, j] = -1;
            F.SearchPath(campbl.moveInfo, campxy, curPath, 0, camppl.listmap, r47107, ref xfinCost, ref xfinPath);
        }

        List<PointW> listmap = new List<PointW>();
        for (int i = 0; i < r47107.listblock.Count; i++) {
            R47107.Block bl = r47107.listblock[i];
            if (bl.dx == "1") {
                Point p = new Point(Convert.ToInt32(bl.x), Convert.ToInt32(bl.y));
                foreach (Point p2 in camppl.listmap)
                    if (p2.Equals(p)) {
                        int[,] finCost = new int[w, h];
                        List<Point> curPath = new List<Point>();
                        List<Point>[,] finPath = new List<Point>[w, h];
                        for (int k = 0; k < w; k++)
                            for (int j = 0; j < h; j++)
                                finCost[k, j] = -1;
                        F.SearchPath(bl.moveInfo, p, curPath, 0, camppl.listmap, r47107, ref finCost, ref finPath);
                        listmap.Add(new PointW(p, finCost, r47107));
                        break;
                    }
            }
        }

        List<int> listmapint = new List<int>();

        int num = 0;
        foreach (PointW pw in listmap)
            listmapint.Add(num++);

        if (num != 0) {
            Permutation pm = new Permutation(listmapint);

            int first = -1;
            int costlowest = 99999999;

            foreach (List<int> list in pm.result) {
                int tempcost = 99999999;

                F.TotalCost(list, listmap, 0, xfinCost[listmap[list[0]].p.X, listmap[list[0]].p.Y], ref tempcost);
                if (tempcost <= costlowest) {
                    costlowest = tempcost;
                    first = list[0];
                }
            }

            Point nPoint = listmap[first].p;
            Point nPath = xfinPath[nPoint.X, nPoint.Y][0];

            R47107.Block nbl = r47107.listblock[nPath.Y * w + nPath.X];
            if (nbl.dx != "2")
                SendMsg(nbl.dx == "1" ? "47103" : "47102",
                    nPath.X.ToString(),
                    nPath.Y.ToString(),
                    r47107.id);

            LogText("[Chiến dịch] Di chuyển đến toạ độ (" + nPath.X.ToString() + "," + nPath.Y.ToString() + ")");
        }
    }
    */

#endregion