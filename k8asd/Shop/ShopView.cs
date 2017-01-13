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
    public partial class ShopView : UserControl {
        public ShopView() {
            InitializeComponent();
        }
    }


    /*
     

     #region 39100
            case "39100":
                r39100 = new R39100(cdata);
                lblBag.Text = "Số ô: " + r39100.usesize + "/" + r39100.storesize;
                cbbBag.Items.Clear();
                for (int i = 0; i < r39100.listitem.Count; i++) {
                    R39100.Item it = r39100.listitem[i];
                    string s = it.name;
                    if (it.goodsnum != "-1")
                        s += " (" + it.goodsnum + "/" + it.fnum + ")";
                    cbbBag.Items.Add(s);
                    bindcd[i] = Convert.ToInt32(it.bindTime);
                }
                if (r39100.listitem.Count > 0) {
                    grpBag.Visible = true;
                    cbbBag.SelectedIndex = lastbagindex;
                } else
                    grpBag.Visible = false;
                break;
            #endregion

            #region 39101
            case "39101": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] == null) {
                        lastbagindex = 0;
                        SendMsg("39100", "0", "60");
                        goto case "11103";
                    } else
                        LogText("[Cửa tiệm] " + token["message"].ToString().Replace("\"", ""));
                    break;
                }
            #endregion

            #region 39103
            case "39103": {
                    JToken token = JObject.Parse(cdata)["m"];
                    if (token["message"] == null) {
                        if (navShop.SelectedIndex == 0) {
                            lastbagindex = cbbBag.SelectedIndex;
                            SendMsg("39100", "0", "60");
                        } else if (navShop.SelectedIndex == 1) {
                            lastupgindex = cbbUpg2.SelectedIndex;
                            SendMsg("39301", V.attribredirect[cbbUpg1.SelectedIndex].ToString(), "0", "20");
                        }
                        goto case "11103";
                    } else
                        LogText("[Cửa tiệm] " + token["message"].ToString().Replace("\"", ""));
                    break;
                }
            #endregion

            /*
        #region 39301
        case "39301":
            r39301 = new R39301(cdata);
            magic = "Ma lực: " + r39301.magic + V.arrow[Convert.ToInt32(r39301.magicstate)];
            upgradecd = Convert.ToInt32(r39301.cd);
            upgradeusable = r39301.upgradecdusable;
            cbbUpg2.Items.Clear();
            for (int i = 0; i < r39301.listitem.Count; i++) {
                R39301.Item it = r39301.listitem[i];
                string s = it.equipname + " (" + it.equipstagename + " - " + it.equiplevel + ")";
                cbbUpg2.Items.Add(s);
                //bindcd[i] = Convert.ToInt32(it.bindTime);
            }
            if (r39301.listitem.Count > 0) {
                grpUpg.Visible = true;
                cbbUpg2.SelectedIndex = lastupgindex;
            } else
                grpUpg.Visible = false;
            if (updateflag == 0) {
                LogText("[Cập nhật] Thông tin giao dịch lúa...");
                SendMsg("13100");
            }
            // grpCd.Values.Description = "Lúa: " + foodprice + " - " + magic;
            break;
        #endregion
        */

    /*
    #region 39302
    case "39302":
        R39302 r39302 = new R39302(cdata);
        if (r39302.m == null) {
            if (r39302.message != null)
                LogText("[Cửa tiệm] " + r39302.message);
            if (r39302.replaySilver != null)
                LogText("[Cửa tiệm] Nhận lại " + r39302.replaySilver + " Bạc");
            grpCd.Values.Description = "Ma lực: " + r39302.magic + V.arrow[Convert.ToInt32(r39302.magicstate)];
            upgradecd = Convert.ToInt32(r39302.cd);
            upgradeusable = r39302.upgradecdusable;
            lastupgindex = cbbUpg2.SelectedIndex;
            SendMsg("39301", V.attribredirect[cbbUpg1.SelectedIndex].ToString(), "0", "20");
            goto case "11103";
        } else
            LogText("[Cửa tiệm] " + r39302.m);
        break;
    #endregion

    #region 39306
    case "39306": {
            lastbagindex = cbbBag.SelectedIndex;
            SendMsg("39100", "0", "60");
}
        break;
    #endregion

    #region 39307
    case "39307": {
            lastbagindex = cbbBag.SelectedIndex;
            SendMsg("39100", "0", "60");
        }
        break;
    #endregion

    #region 39308
    case "39308": {
            lastbagindex = cbbBag.SelectedIndex;
            SendMsg("39100", "0", "60");
        }
        break;
    #endregion


#region Shop

private void navShop_SelectedPageChanged(object sender, EventArgs e) {
    switch (navShop.SelectedIndex) {
    case 0:
        lastbagindex = 0;
        SendMsg("39100", "0", "60");
        break;
    case 1:
        cbbUpg1_SelectedIndexChanged(null, null);
        break;
    }
}

#region Bag

private void cbbBag_SelectedIndexChanged(object sender, EventArgs e) {
    R39100.Item it = r39100.listitem[cbbBag.SelectedIndex];
    txtBagInfo1.Text = V.listattribute[Convert.ToInt32(it.type) - 1] + " +" + it.attribute;
    txtBagInfo2.Text = "+" + it.hp;
    txtBagInfo3.Text = it.equipstagename + " - " + it.equiplevel;
    txtBagInfo4.Text = "Tướng Lv." + it.lv;
    btnBagSell.Enabled = it.bindstatus == "0";
    btnBagBind.Text = V.listbindstatus[Convert.ToInt32(it.bindstatus)];
    lblBagBindCd.Visible = txtBagBindCd.Visible = it.bindstatus == "2";
    txtBagSell.Text = it.value + " Bạc";
    txtBagDegrade.Text = it.degradecoppercost;
    btnBagDegrade.Enabled = it.degradeable == "1" && it.bindstatus == "0";
}

private void btnBagBind_Click(object sender, EventArgs e) {
    switch (btnBagBind.Text) {
    case "Khoá":
        SendMsg("39306", r39100.listitem[cbbBag.SelectedIndex].id);
        break;
    case "Mở khoá":
        SendMsg("39307", r39100.listitem[cbbBag.SelectedIndex].id);
        break;
    case "Huỷ":
        SendMsg("39308", r39100.listitem[cbbBag.SelectedIndex].id);
        break;
    }
}

private void btnBagSell_Click(object sender, EventArgs e) {
    SendMsg("39101", r39100.listitem[cbbBag.SelectedIndex].id, "-1");
}

#endregion

#region Upg

private void cbbUpg1_SelectedIndexChanged(object sender, EventArgs e) {
    lastupgindex = 0;
    SendMsg("39301", V.attribredirect[cbbUpg1.SelectedIndex].ToString(), "0", "20");
}

private void cbbUpg2_SelectedIndexChanged(object sender, EventArgs e) {
    R39301.Item it = r39301.listitem[cbbUpg2.SelectedIndex];
    txtUpgInfo1.Text = V.listattribute[Convert.ToInt32(it.equiptype) - 1] + " +" + it.attribute;
    txtUpgInfo2.Text = "+" + it.hp;
    txtUpgInfo3.Text = it.equipstagename + " - " + it.equiplevel;
    txtUpgInfo4.Text = "Yêu cầu cấp " + it.equiplimitlv;
    //btnBagBind.Text = listbindstatus[Convert.ToInt32(it.bindstatus)];
    //lblBagBindCd.Visible = txtBagBindCd.Visible = it.bindstatus == "2";
    txtUpgUp.Text = it.coppercost + " Bạc";
    txtUpgDe.Text = it.degradecoppercost + " Bạc";
    btnUpgDe.Enabled = it.degradeable == "1" && it.bindstatus == "0";
}

private void btnUpgUp_Click(object sender, EventArgs e) {
    SendMsg("39302", r39301.listitem[cbbUpg2.SelectedIndex].storeid, "0", r39301.magic);
}

private void btnUpgDe_Click(object sender, EventArgs e) {
    SendMsg("39103", r39301.listitem[cbbUpg2.SelectedIndex].storeid, "0", r39301.magic);
}

private void btnBagDegrade_Click(object sender, EventArgs e) {
    SendMsg("39103", r39100.listitem[cbbBag.SelectedIndex].id, "0", "100");
}

#endregion



#endregion
*/
}
