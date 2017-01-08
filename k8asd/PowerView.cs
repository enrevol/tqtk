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
    public partial class PowerView : UserControl {
        public PowerView() {
            InitializeComponent();
        }
    }


    /*
    #region 33201
            case "33201":
                r33201 = new R33201(cdata);

                cbbArmy1.Items.Clear();
                for (int i = 0; i < r33201.listpower.Count; i++)
                    listpower[i] = r33201.listpower[i].powerName;

                nextpower = false;
                if (r33201.listpower.Count > 15)
                    for (curpower = 15; curpower <= 17; curpower++)
                        if (r33201.listpower[curpower].powerState == "1") {
                            SendMsg("33100", (4 + curpower++).ToString());
                            nextpower = true;
                            break;
                        }
                //if (!nextpower)
                //    UpdateComplete();

                if (loadtoken != null) {
                    JObject obj = (JObject) loadtoken["army"];
                    chkArmy.Checked = Convert.ToBoolean(obj["check"].ToString());
                    cbbArmyMode.SelectedIndex = Convert.ToInt32(obj["mode"].ToString());
                    numArmyAttack.Value = Convert.ToInt32(obj["limit"].ToString());
                    chkArmyAttack.Checked = Convert.ToBoolean(obj["limitcheck"].ToString());
                    numArmyRefresh.Value = Convert.ToInt32(obj["refresh"].ToString());
                    chkArmyRefresh.Checked = Convert.ToBoolean(obj["refreshcheck"].ToString());
                    chkArmyCd.Checked = Convert.ToBoolean(obj["wait"].ToString());
                    JArray array = (JArray) obj["list"];
                    for (int i = 0; i < array.Count; i++) {
                        obj = (JObject) array[i];
                        lstArmyList.Items.Add(new TagItem(
                            obj["army"].ToString().Replace("\"", ""),
                            obj["id"].ToString().Replace("\"", "")));
                        lstArmyList.SetItemChecked(i, Convert.ToBoolean(obj["check"].ToString()));
                    }
                    obj = (JObject) loadtoken["forces"];
                    chkForces.Checked = Convert.ToBoolean(obj["forcecheck"].ToString());
                    numForces.Value = Convert.ToInt32(obj["forcenum"].ToString());
                    chkForcesFree.Checked = Convert.ToBoolean(obj["forcefree"].ToString());
                    loadtoken = null;
                }
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

            #region 34101
            case "34101": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"") {
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                        armynext = true;
                    }
                    armyok = true;
                }
                break;
            #endregion

            #region 34102
            case "34102": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"")
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                    armyok = true;
                }
                break;
            #endregion

            #region 34104
            case "34104": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"")
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 34105
            case "34105": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token.ToString() != "\"\"")
                        LogText("[Chiến] " + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 34106
            case "34106": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Chiến]" + token["message"].ToString().Replace("\"", ""));
                }
                break;
            #endregion

            #region 34107
            case "34107": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] != null)
                        LogText("[Chiến]" + token["message"].ToString().Replace("\"", ""));
                    armyok = true;
                }
                break;
            #endregion

            #region 34108
            case "34108":
                R34108 r34108 = new R34108(cdata); {
                    lstArmyMember.Items.Clear();
                    lblExtraYinkuang.Visible = r34108.extrayinkuang.Equals("1");
                    lblExtraNongtian.Visible = r34108.extranongtian.Equals("1");
                    lblExtraZhengzhan.Visible = r34108.extrazhengzhan.Equals("1");
                    lblExtraZhengfu.Visible = r34108.extrazhengfu.Equals("1");
                    lblExtraGongji.Visible = r34108.extragongji.Equals("1");
                    sysgold = r34108.sys_gold;
                    usergold = r34108.user_gold;
                    txtGold.Text = (Convert.ToInt32(sysgold) + Convert.ToInt32(usergold)).ToString();
                    tokencd = Convert.ToInt32(r34108.tokencd);
                    tokencdusable = r34108.tokencdusable;
                    forces = r34108.forces;
                    txtForces.Text = forces + "/" + maxforces;
                    lblToken.Text = "Lượt: " + r34108.token + "/" + r11102.maxtoken;
                    txtJyungong.Text = r34108.jyungong;
                    if (r34108.gains == "")
                        LogText("[Chiến] Tấn công thất bại");
                    else
                        LogText("[Chiến] Nhận được " + r34108.gains + " chiến tích");
                }
                armynext = true;
                armyok = true;
                break;
            #endregion


     #region Power

        private void navPower_SelectedPageChanged(object sender, EventArgs e) {
            switch (navPower.SelectedIndex) {
            case 1:
                if (r11102.id != "") {
                    SendMsg("47101", "1", r11102.id);
                    r11102.id = "";
                }
                break;
            }
        }

        #region Armys
         
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

private void btnArmyInfo_Click(object sender, EventArgs e) {
    if (btnArmyInfo.Text == "Thoát") {
        btnArmyInfo.Text = "Tấn công";
        grpArmyParty.Visible = false;
        cbbArmy1.Enabled = true;
        cbbArmy2.Enabled = true;
        chkArmy.Enabled = true;
        btnAuto.Enabled = true;
        armyok = false;
    } else {
        int index = cbbArmy2.SelectedIndex;
        if (index >= 0) {
            int id = Convert.ToInt32(r33100.listarmy[index].armyid);
            if (id >= 900000) {
                armyok2 = true;
                grpArmyParty.Visible = true;
                btnArmyInfo.Text = "Thoát";
                cbbArmy1.Enabled = false;
                cbbArmy2.Enabled = false;
                chkArmy.Enabled = false;
                btnAuto.Enabled = false;
            } else
                SendMsg("33101", id.ToString(), "0");
        }
    }
}

private void radArmy2_CheckedChanged(object sender, EventArgs e) {
    radArmy1.Checked = !radArmy2.Checked;
}

private void radArmy1_CheckedChanged(object sender, EventArgs e) {
    radArmy2.Checked = !radArmy1.Checked;
}

private void btnArmyCreate_Click(object sender, EventArgs e) {
    SendMsg("34101", r33100.listarmy[cbbArmy2.SelectedIndex].armyid,
        "4:0;" + (radArmy2.Checked ? "2" : "3"), "0");
}

private void btnArmyTeam_Click(object sender, EventArgs e) {
    // if (r34100.listmember.Count == 0) {
    KryptonContextMenuItem item = (KryptonContextMenuItem) sender;
    SendMsg("34102", item.Tag.ToString());
    // }
}

private void lstArmyMember_SelectedValueChanged(object sender, EventArgs e) {
    int index = lstArmyMember.SelectedIndex;
    if (index != -1) {
        SendMsg("34104", r34100.listmember[index].playerid);
    }
}

private void btnArmyAttack_Click(object sender, EventArgs e) {
    int cnum = Convert.ToInt32(r34100.currentnum);
    int mnum = Convert.ToInt32(r34100.minplayer);
    if (cnum >= mnum)
        if (r11102.playername == r34100.listmember[0].playername)
            SendMsg("34107", "0");
        else {
            SendMsg("34101", "900001", "4:0;1", "0");
            SendMsg("34107", "0");
            SendMsg("34105");
        }
}

private void btnArmyDisband_Click(object sender, EventArgs e) {
    SendMsg("34105");
}

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

private void btnArmyQuit_Click(object sender, EventArgs e) {
    SendMsg("34106");
}

private void btnArmyAdd_Click(object sender, EventArgs e) {
    int id = cbbArmy2.SelectedIndex;
    if (id >= 0) {
        R33100.Army am = r33100.listarmy[id];

        bool ex = false;
        foreach (TagItem it in lstArmyList.Items)
            if (it.tag == am.armyid) {
                ex = true;
                break;
            }

        if (!ex)
            lstArmyList.Items.Add(new TagItem(am.armyname, am.armyid));
    }
}

private void btnArmyDel_Click(object sender, EventArgs e) {
    if (lstArmyList.SelectedItems.Count > 0)
        lstArmyList.Items.RemoveAt(lstArmyList.SelectedIndex);
}

private void btnArmyUp_Click(object sender, EventArgs e) {
    int id = lstArmyList.SelectedIndex;
    if (id - 1 >= 0) {
        object obj = lstArmyList.Items[id];
        lstArmyList.Items[id] = lstArmyList.Items[id - 1];
        lstArmyList.Items[id - 1] = obj;
        lstArmyList.SelectedIndex = id - 1;
    }
}

private void btnArmyDown_Click(object sender, EventArgs e) {
    int id = lstArmyList.SelectedIndex;
    if (id + 1 < lstArmyList.Items.Count && id >= 0) {
        object obj = lstArmyList.Items[id];
        lstArmyList.Items[id] = lstArmyList.Items[id + 1];
        lstArmyList.Items[id + 1] = obj;
        lstArmyList.SelectedIndex = id + 1;
    }
}

        #endregion

     #region Campaign

        private void btnCampCreate_Click(object sender, EventArgs e) {
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

        #endregion
    */
}
