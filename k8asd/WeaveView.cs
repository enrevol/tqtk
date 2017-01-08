using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class WeaveView : UserControl {
        public WeaveView() {
            InitializeComponent();
        }
    }


    /*
      
      #region 45200
            case "45200":
                r45200 = new R45200(cdata);

                txtWeaveInfo1.Text = r45200.info.totallevel + " Cấp";
                txtWeaveInfo2.Text = r45200.info.price + V.arrow[Convert.ToInt32(r45200.info.priceway)];
                txtWeaveInfo3.Text = r45200.info.succrate + " - " + r45200.info.baojirate;
                txtWeaveInfo4.Text = r45200.info.num + "/10";

                makecd = Convert.ToInt32(r45200.makecd);
                btnWeaveTeam.Text = r45200.listteam.Count.ToString() + " tổ đội"; {
                    bool playerishost = false;

                    KryptonContextMenu context = new KryptonContextMenu();
                    KryptonContextMenuItems items = new KryptonContextMenuItems();

                    foreach (R45200.Team tm in r45200.listteam) {
                        KryptonContextMenuItem item = new KryptonContextMenuItem();

                        item.Text = tm.teamname + " ["
                            + V.listnation[Convert.ToInt32(tm.nation)] + "] ("
                            + tm.num + "/"
                            + tm.maxnum + ") - Hạn chế cấp: "
                            + tm.limitlv
                            + " - Vải: " + tm.level
                            + " - Giá: " + tm.cost + " / " + tm.price
                            + " - Tỉ lệ: " + tm.succrate + " / " + tm.baojirate;
                        item.Tag = tm.teamid;
                        
                        if (r45300 == null)
                            item.Enabled = makecd == 0 && r45200.info.num != "0";
                        else
                            item.Enabled = r45300.type == "3" && tm.teamname == r11102.playername;

    item.Click += btnWeaveTeam_Click;

                        items.Items.Add(item);
                        if (tm.teamname == r11102.playername)
                            playerishost = true;
                    }
context.Items.Add(items);
                    if (items.Items.Count > 0)
                        btnWeaveTeam.KryptonContextMenu = context;
                    else
                        btnWeaveTeam.KryptonContextMenu = null;

                    if (r45300 == null) {
                        btnWeaveCreate.Enabled = makecd == 0 && r45200.info.num != "0";
                        lstWeaveMember.Items.Clear();
                        txtWeaveInfo5.Text = "";
                        txtWeaveInfo6.Text = "";
                        txtWeaveInfo7.Text = "";
                        btnWeaveDisband.Enabled = false;
                        btnWeaveMake.Enabled = false;
                        btnWeaveInvite.Enabled = false;
                        btnWeaveQuit.Enabled = false;
                        grpWeaveInfo2.Enabled = false;
                        lstWeaveMember.Enabled = false;
                    } else if (!playerishost && r45300.type == "3")
                        r45300 = null;
                }
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

            #region 45209
            case "45209": {
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

        private void btnWeaveTeam_Click(object sender, EventArgs e) {
            /*
            KryptonContextMenuItem item = (KryptonContextMenuItem) sender;
            if (r45300 == null
                || (r45300.type == "3"
                && item.Text.Contains(r11102.playername)))
                SendMsg("45209", item.Tag.ToString());
}

private void btnWeaveCreate_Click(object sender, EventArgs e) {
    //   grpWeaveParty.Enabled = false;
    SendMsg("45201");
}

private void btnWeaveMake_Click(object sender, EventArgs e) {
    SendMsg("45208", r45300.teamid);
}

private void btnWeaveDisband_Click(object sender, EventArgs e) {
    SendMsg("45207", r45300.teamid);
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
