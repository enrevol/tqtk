using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd.Campaign {
    public partial class CampaignView : UserControl {
        public CampaignView() {
            InitializeComponent();
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
