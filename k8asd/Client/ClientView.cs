using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net;

namespace k8asd {
    public partial class ClientView : UserControl {
        private InfoModel infoModel;
        private CooldownModel cooldownModel;
        private McuModel mcuModel;
        private SystemLog messageLogModel;

        private ClientConfig config;

        public ClientConfig Config {
            get {
                heroTrainingView.SaveConfig(config);
                outsideView.SaveConfig(config);
                return config;
            }
            set {
                config = new ClientConfig(value.Data);
                heroTrainingView.LoadConfig(config);
                outsideView.LoadConfig(config);
            }
        }        

        public ClientView() {
            InitializeComponent();

            disconnectedLocking = false;
            state = ClientState.Disconnected;

            infoModel = new InfoModel();
            cooldownModel = new CooldownModel();
            mcuModel = new McuModel();
            messageLogModel = new SystemLog();

            cooldownModel.SetInfoModel(infoModel);
            taskView.SetInfoModel(infoModel);

            infoView.SetModel(infoModel);
            cooldownView.SetModel(cooldownModel);

            mcuView.SetModel(mcuModel);
            taskView.SetMcuModel(mcuModel);

            messageLogView.SetModel(messageLogModel);
            taskView.SetMessageModel(messageLogModel);

            weaveView.SetCooldownModel(cooldownModel);
            weaveView.SetInfoModel(infoModel);
            campaignView.SetInfoModel(infoModel);
            armyView.SetInfoModel(infoModel);
            armyView.SetMessageLogModel(messageLogModel);
            armyView.SetMcuModel(mcuModel);
            outsideView.SetInfoModel(infoModel);
            outsideView.SetCooldownModel(cooldownModel);
            raiseBirdView.SetInfoModel(infoModel);
            raiseBirdView.SetMessageLogModel(messageLogModel);
            instituteView.SetInfoModel(infoModel);
            instituteView.SetMessageLogModel(messageLogModel);

            heroTrainingView.SetCooldownModel(cooldownModel);
            heroTrainingView.SetLogModel(messageLogModel);
            arenaView.SetLogModel(messageLogModel);
            outsideView.SetLogModel(messageLogModel);

            infoModel.SetPacketWriter(this);
            cooldownModel.SetPacketWriter(this);
            mcuView.SetPacketWriter(this);
            mcuModel.SetPacketWriter(this);
            heroTrainingView.SetPacketWriter(this);
            armyView.SetPacketWriter(this);
            messageLogModel.SetPacketWriter(this);
            weaveView.SetPacketWriter(this);
            arenaView.SetPacketWriter(this);
            campaignView.SetPacketWriter(this);
            packetView.SetPacketWriter(this);
            outsideView.SetPacketWriter(this);
            raiseBirdView.SetPacketWriter(this);
            instituteView.SetPacketWriter(this);
            taskView.SetPacketWriter(this);

            chatLogModel.Client = this;
        }

        private void ClientView_Load(object sender, EventArgs e) {
            //
        }

        public void EnableAutoQuest() {
            taskView.EnableAutoQuest();
        }

        public void ReportAutoQuest() {
            taskView.ReportQuest(Config.Username, PlayerName);
        }

        public void UseGoldDaily() {
            this.UseGoldDailyAsync();
        }
    }
}

/*
            if (packet.CommandId == "10100") {

            }

            var cmd = packet.CommandId;
            var cdata = packet.Raw;

            switch (cmd) {
            #region 11102
            case "11102": {
                    var token = JToken.Parse(cdata);

                    /*                    
                    avoidWarStatus = (string) token["avoidWarStatus"];
                    protectcd = (string) player["protectcd"];
                    legionkey = (string) player["legionkey"];
                    guidestep = (string) player["guidestep"];
                    techcdusable = (string) player["techcdusable"];
                    vip = (string) player["vip"];
                    tokencdusable = (string) player["tokencdusable"];
                    trainnum = (string) player["trainnum"];                    
                    year = (string) player["year"];
                    imposecdusable = (string) player["imposecdusable"];
                    guidecdusable = (string) player["guidecdusable"];
                    isimposelimit = (string) player["isimposelimit"];
                    arealevel = (string) player["arealevel"];
                    nation = (string) player["nation"];
                    newmail = (string) player["newmail"];
                    season = (string) player["season"];
                    id = (string) player["id"];
                    legionid = (string) player["legionid"];
                    */

// FIXME: handle case character not yet created.


/*
    // FIXME.
    // characterBox.Text = r11102.playername + " Lv." + r11102.playerlevel + " [" + V.listnation[Convert.ToInt32(r11102.nation)] + "]";
    grpCd.Text = r11102.year + V.listseason[Convert.ToInt32(r11102.season) - 1];

    numForces.Maximum = Convert.ToInt32(maxforces);

    lblToken.Text = "Lượt: " + r11102.token + "/" + r11102.maxtoken;

    isimposelimit = r11102.isimposelimit;
    imposecd = Convert.ToInt32(r11102.imposecd);
    tokencd = Convert.ToInt32(r11102.tokencd);
    guidecd = Convert.ToInt32(r11102.guidecd);
    techcd = Convert.ToInt32(r11102.techcd);

    tokencdusable = r11102.tokencdusable;
    techcdusable = r11102.techcdusable;

    if (updateflag == 0) {
        LogText("[Cập nhật] Thông tin bang hội...");
        SendMsg("32121");
    }
} else
    LogText("[Kết nối] Nhân vật không tồn tại");
break;
}
#endregion

#region 11104
case "11104":
R11104 r11104 = new R11104(cdata);

//   refreshcd = 50000;
// if (r11104.message == null)
//  goto case "11103";

break;
#endregion

#region 12200
case "12200":
//r12200 = new R12200(cdata);
//lstBuild.Items.Clear();

//forcefreecd = Convert.ToInt32(r12200.rightcd);

//foreach (R12200.Main dt in dt_12200.listmain)
//    if (dt != null)
//        lstBuild.Items.Add(dt.buildname + " (" + dt.buildlevel + ")");
//lstBuild.SelectedIndex = 0;
//for (int i = 0; i < dt_12200.listconstruct.Count; i++)
//    buildcd[i] = Convert.ToInt32(dt_12200.listconstruct[i].ctime);

// btnWorkshop.Enabled = r12200.listmain[24] != null;

//if (updateflag == 0) {
//    LogText("[Cập nhật] Thông tin thu thuế...");
//    SendCommand("12400");
// }
// goto case "11103";
break;
#endregion

/*
#region 13100
case "13100":
r13100 = new R13100(cdata);
foodprice = r13100.price + V.arrow[Convert.ToInt32(Convert.ToBoolean(r13100.isup))];
txtFoodPrice.Text = foodprice;
txtFoodTrade.Text = r13100.crutrade + "/" + r13100.maxtrade;
barFoodBuy.Value = barFoodSell.Value = 1;
CheckFoodTrade(r13100.crutrade);
if (updateflag == 0) {
LogText("[Cập nhật] Thông tin thành trì...");
SendMsg("12200", "1");
}
grpCd.Values.Description = "Lúa: " + foodprice + " - " + magic;
break;
#endregion
*/

/*
#region 13101
case "13101":
    R13101 r13101 = new R13101(cdata);
    if (r13101.m == null) {
        txtFoodTrade.Text = r13101.cde + "/" + r13100.maxtrade;
        CheckFoodTrade(r13101.cde);
        goto case "11103";
    } else
        LogText("[Giao dịch lúa] " + r13101.m);
    break;
#endregion

#region 14100
case "14100": {
        /*
        JToken token = JObject.Parse(cdata)["m"];
        if (token["cde"] != null) {
            forcefreecd = Convert.ToInt32(token["cde"].ToString());
            // goto case "11103";
        } else {
            LogText("[Lính] " + token["message"].ToString().Replace("\"", ""));
            if (forcefreecd == 0)
                forcefreecd += 600000;
        }
    }
    break;
#endregion

#region 14101
case "14101":
    //  r14101 = new R14101(cdata);
    // numForcesRecruit.Maximum = Convert.ToInt32(r14101.forcemax);
    //  if (updateflag == 0) {
    //     LogText("[Cập nhật] Thông tin cửa tiệm...");
    //     SendCommand("39301", "0", "0", "0");
    // }
    break;
#endregion

#region 14102
case "14102": {
        JToken token = JObject.Parse(cdata)["m"];
        //if (token["playerupdateinfo"] != null)
        //  goto case "11103";
    }
    break;
#endregion

#region 32101
case "32101":
    // R32101 r32101 = new R32101(cdata);
    //if (updateflag == 0) {
    ///    LogText("[Cập nhật] Thông tin binh doanh...");
    //    SendCommand("14101");
    //}
    break;
#endregion

default:
    break;
}
}

#region Timer

private void tmrCd_Tick(object sender, EventArgs e) {

if (sys.Seconds == 1 && (sys.Minutes == 0 || sys.Minutes == 30)) {
    SendMsg("39301", "0", "0", "0");
    SendMsg("13100");
}

if (btnAuto.Text == "Dừng") {
    if (chkArmy.Checked)
        armyok = true;
    if (chkWeave.Checked)
        weaveok = true;
}

for (int i = 0; i < 60; i++) {
    F.DecTime(ref bindcd[i]);
    if (i == cbbBag.SelectedIndex)
        F.ShowTimemH(txtBagBindCd, bindcd[i]);
}

for (int i = 0; i < 4; i++)
    F.DecTime(ref chatcd[i]);

F.DecTime(ref forcefreecd);

F.DecTime(ref refreshcd);

/*
#region TrainCd

{
    for (int i = 0; i < 8; i++)
        F.DecTime(ref traincd[i]);

    int index = lstTrain.SelectedIndex;
    if (index >= 0)
        F.ShowTime(txtTrainTime, traincd[index]);
}

#endregion


#region CampaignOpenCd

if (campcd == 0) {
lblCampCd.Text = "";

if (campid != null) {
    lblCampCd.SendToBack();
    grpCampInfo.Visible = true;
    btnCampQuitIn.Visible = true;
    campid = null;
}
} else {
TimeSpan span = new TimeSpan(0, 0, 0, 0, campcd);
lblCampCd.Text = "Chiến dịch bắt đầu sau " + span.Seconds.ToString() + " giây...";
}

F.DecTime(ref campcd);

#endregion

#region CampaignInnerCd

if (r47107 != null) {
int elapsed = Convert.ToInt32(r47107.info.interval) - camprecd;

F.ShowTime(txtCampInfo2, elapsed);

string[] slice = r47107.slice.Split(',');
for (int i = 0; i < slice.Length; i++) {
    int elapsedr = Convert.ToInt32(slice[i]) * 1000;
    if (elapsed < elapsedr) {
        int campslcd = elapsedr - elapsed;

        TimeSpan span = new TimeSpan(0, 0, 0, 0, campslcd);
        txtCampInfo4.Text = V.listcamprank[4 - i] + " " + F.GetTimewH(span);
        break;
    }
}
}

#endregion

if (updateflag != 0) {
btnImpose.Enabled = isimposelimit == "1" && imposecdusable == "1";
btnGuide.Enabled = guidecdusable == "1";
if (cbbUpg2.SelectedIndex >= 0) {
    R39301.Item it = r39301.listitem[cbbUpg2.SelectedIndex];
    btnUpgUp.Enabled = it.upgradeable == "1"
        && Convert.ToInt32(it.coppercost)
        <= Convert.ToInt32(copper)
        && upgradeusable == "1";
}
}
}

private void tmrReq_Tick(object sender, EventArgs e) {
tmrReq.Interval = Convert.ToInt32(numUpdate.Value);

#region Refresh

if (refreshcd == 0)
SendMsg("11104");

#endregion

/*
if (btnArmyInfo.Text == "Thoát"
&& armyok2) {
armyok2 = false;
SendMsg("34100", r33100.listarmy[cbbArmy2.SelectedIndex].armyid);
}

if (btnCampInfo.Text == "Thoát")
SendMsg("47008", V.listcampid[cbbCamp.SelectedIndex].ToString());

if (btnAuto.Text == "Dừng") {

#region Impose

{
/*
string s = txtImposeNum.Text;
if (chkImpose.Checked
    && isimposelimit == "1"
    && imposecdusable == "1"
    && Convert.ToInt32(copper)
    + Convert.ToInt32(txtImposeCopper.Text)
    <= Convert.ToInt32(maxcopper)
    && Convert.ToInt32(s.Remove(s.IndexOf("/"))) > 0)
    SendMsg("12401", "0");
}

#endregion

#region Forces

/*
        {
            if (chkForcesFree.Checked
                && forcefreecd == 0)
                SendMsg("14100");

            int diff = Convert.ToInt32(numForces.Value) - Convert.ToInt32(forces);
            double cost = diff * Convert.ToDouble(r14101.recruits);

            if (chkForces.Checked
                && diff > 0
                && cost <= Convert.ToInt32(food)) {
                SendMsg("14102", diff.ToString(), "0");
                LogText("[Lính] Đào tạo " + diff + " lính");
            }
        }

#endregion

}                        

}

#region Impose

/*
private void btnImpose_Click(object sender, EventArgs e) {
SendMsg("12401", "0");
}

private void btnImposeForce_Click(object sender, EventArgs e) {
SendMsg("12401", "1");
}

private void btnImposeAnswer1_Click(object sender, EventArgs e) {
SendMsg("12406", "1");
}

private void btnImposeAnswer2_Click(object sender, EventArgs e) {
SendMsg("12406", "2");
}

#region Food

private void btnFoodBuy_Click(object sender, EventArgs e) {
SendCommand("13101", "0", barFoodBuy.Value.ToString());
}

private void btnFoodSell_Click(object sender, EventArgs e) {
SendCommand("13101", "1", barFoodSell.Value.ToString());
}

private void barFoodBuy_Scroll(object sender, EventArgs e) {
//lblFoodBuy.Text = "Tiêu tốn " + barFoodBuy.Value * Convert.ToDouble(r13100.price)
//   + " Bạc để mua " + barFoodBuy.Value + " lúa";
}

private void barFoodSell_Scroll(object sender, EventArgs e) {
//  lblFoodSell.Text = "Bán " + barFoodSell.Value + " lúa, nhận được "
//     + barFoodSell.Value * Convert.ToDouble(r13100.price) + " Bạc";
}

#endregion


#region Forces

private void btnForcesRecruit_Click(object sender, EventArgs e) {
//  SendMsg("14102", numForcesRecruit.Value.ToString(), "0");
}

private void btnForcesFree_Click(object sender, EventArgs e) {
SendCommand("14100");
}

#endregion


}
}

* private WayPoint HDVS = new WayPoint();
* 
for (int i = 0; i < 6; i++)
   cbbChat.Items.Add(V.listchat[i]);
cbbChat.SelectedIndex = 3;

for (int i = 0; i < 7; i++) {
   pagChat[i] = new KryptonPage();
   txtChatBox[i] = new RichTextBoxEx();
   txtChatBox[i].Dock = DockStyle.Fill;
   txtChatBox[i].BackColor = Color.Black;
   txtChatBox[i].ForeColor = V.listcolorchat[i];
   txtChatBox[i].Font = new Font("Sogue", 9.25f);
   txtChatBox[i].ReadOnly = true;
   txtChatBox[i].ScrollBars = RichTextBoxScrollBars.ForcedVertical;
   pagChat[i].Controls.Add(txtChatBox[i]);
   pagChat[i].Text = V.listchat[i];
   navChat.Pages.Add(pagChat[i]);
}
navChat.SelectedIndex = 6;

cbbArmyMode.Items.AddRange(V.listarmymode);
cbbArmyMode.SelectedIndex = 0;

cbbWeaveMode.Items.AddRange(V.listweavemode);
cbbWeaveMode.SelectedIndex = 0;

int asz = 18;
int sz = 30;
int dist = 1;
btnCampMap = new KryptonButton[asz, asz];
for (int i = 0; i < asz; i++)
   for (int j = 0; j < asz; j++) {
       btnCampMap[i, j] = new KryptonButton();
       btnCampMap[i, j].Size = new Size(sz, sz);
       btnCampMap[i, j].Location = new Point(dist + i * (sz + dist), dist + j * (sz + dist));
       btnCampMap[i, j].Tag = i.ToString() + "." + j.ToString();
       btnCampMap[i, j].Click += btnCampMap_Click;
       pnlCampMap.Controls.Add(btnCampMap[i, j]);
   }
cbbCamp.Items.AddRange(V.listcamp);
cbbCamp.SelectedIndex = 0;

WayPoint.Player player = new WayPoint.Player(new Point(0, 1));

player.Add(new Point(0, 0), new Point(3, 6));
HDVS.listplayer.Add(player);

player = new WayPoint.Player(new Point(0, 8));
player.Add(new Point(0, 7), new Point(2, 14));
HDVS.listplayer.Add(player);

player = new WayPoint.Player(new Point(0, 17));
player.Add(new Point(0, 15), new Point(7, 17));
player.Add(new Point(3, 12), new Point(7, 14));
HDVS.listplayer.Add(player);

player = new WayPoint.Player(new Point(7, 0));
player.Add(new Point(4, 0), new Point(7, 5));
HDVS.listplayer.Add(player);

player = new WayPoint.Player(new Point(7, 5));
player.Add(new Point(5, 6), new Point(7, 17));
HDVS.listplayer.Add(player);

cbbUpg1.SelectedIndexChanged -= cbbUpg2_SelectedIndexChanged;
cbbUpg1.Items.AddRange(V.listequiptype);
cbbUpg1.SelectedIndex = 0;
cbbUpg1.SelectedIndexChanged += cbbUpg2_SelectedIndexChanged;
*/
