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
    public partial class HeroImproveView : UserControl {
        public HeroImproveView() {
            InitializeComponent();
        }
    }

    /*
       private void chkPlus_CheckedChanged(object sender, EventArgs e) {
           plusok = chkPlus.Checked;
           pnlPlusAtt.Enabled = !chkPlus.Checked;
           btnPower.Enabled = !chkPlus.Checked;
           lstPlus.Enabled = !chkPlus.Checked;
           pagTrain.Visible = !chkPlus.Checked;
           pnlNav.Enabled = !chkPlus.Checked;
       }
       */

    /*
    private void lstPlus_SelectedIndexChanged(object sender, EventArgs e) {
        SendMsg("41302", r41300.listgeneral[lstPlus.SelectedIndex].generalid);
    }

    private void btnPlusPlus_Click(object sender, EventArgs e) {
        SendMsg("41301", r41300.listgeneral[lstPlus.SelectedIndex].generalid, cbbPlusMode.SelectedIndex.ToString());
    }

    private void btnPlusKeep_Click(object sender, EventArgs e) {
        SendMsg("41303", r41300.listgeneral[lstPlus.SelectedIndex].generalid, "0");
    }

    private void btnPlusChange_Click(object sender, EventArgs e) {
        SendMsg("41303", r41300.listgeneral[lstPlus.SelectedIndex].generalid, "1");
    }

    private void btnShift_Click(object sender, EventArgs e) {
        SendMsg("41304", r41300.listgeneral[lstPlus.SelectedIndex].generalid, cbbShift.SelectedIndex.ToString());
    }
    */

    /*
    private void cbbPlusAtt1_SelectedIndexChanged(object sender, EventArgs e) {
    cbbPlusAtt2.Items.Clear();
    switch (cbbPlusAtt1.SelectedIndex) {
    case 0:
        cbbPlusAtt2.Items.AddRange(new string[] { "Kỹ", "Trí" });
        break;
    case 1:
        cbbPlusAtt2.Items.AddRange(new string[] { "Dũng", "Trí" });
        break;
    case 2:
        cbbPlusAtt2.Items.AddRange(new string[] { "Dũng", "Kỹ" });
        break;
    }
    cbbPlusAtt2.SelectedIndex = 0;
    }
    */

    /*
     * 

            #region 41100
            case "41100":
            /// FIXME
            /// Parse guide cd + guidecdusable.
            #endregion

            #region 41301
            case "41301": {
                    break;
                }

            /*
            R41301 r41301 = new R41301(cdata);
            if (r41301.m == null) {
                lblPlusNew.Text = "D: " + r41302.baseleader + " + " + r41301.plusleader
                        + "\nK: " + r41302.baseforces + " + " + r41301.plusforces
                        + "\nT: " + r41302.baseintelligence + " + " + r41301.plusintelligence;
                pnlPlusNew.Visible = true;
                btnPlusKeep.Enabled = true;
                btnPlusPlus.Enabled = false;
                if (chkPlus.Checked) {
                    LogText("[Cải tiến] " + r41300.listgeneral[lstPlus.SelectedIndex].generalname
                        + ": D" + r41301.plusleader
                        + " K" + r41301.plusforces
                        + " T" + r41301.plusintelligence);
                    int att1 = cbbPlusAtt1.SelectedIndex;
                    int att2 = cbbPlusAtt2.SelectedIndex;
                    int[] org =
                    {
                                Convert.ToInt32(r41302.originalattr.plusleader),
                                Convert.ToInt32(r41302.originalattr.plusforces),
                                Convert.ToInt32(r41302.originalattr.plusintelligence)
                            };
                    int[] bs =
                    {
                                Convert.ToInt32(r41301.plusleader),
                                Convert.ToInt32(r41301.plusforces),
                                Convert.ToInt32(r41301.plusintelligence)
                            };
                    if ((!chkPlusAtt2.Checked && org[att1] < bs[att1])
                        || (chkPlusAtt2.Checked
                        && bs[att1] + 5 >= bs[F.AttPlus(att1, att2)]
                        && (org[att1] + org[F.AttPlus(att1, att2)]
                        < bs[att1] + bs[F.AttPlus(att1, att2)]
                        || (org[att1] + org[F.AttPlus(att1, att2)]
                        == bs[att1] + bs[F.AttPlus(att1, att2)]
                        && Math.Abs(org[att1] - org[F.AttPlus(att1, att2)])
                        > Math.Abs(bs[att1] - bs[F.AttPlus(att1, att2)]))))) {
                        txtLogs.AppendText(" -> Thay");
                        btnPlusChange_Click(null, null);
                    } else {
                        txtLogs.AppendText(" -> Giữ");
                        btnPlusKeep_Click(null, null);
                    }
                }
                goto case "11103";
            } else {
                LogText("[Cải tiến] " + r41301.m);
                chkPlus.Checked = false;
            }
            break;
            #endregion

            #region 41302
            case "41302":
                // FIXME 

                /*
                r41302 = new R41302(cdata);
                grpPlusInfo.Text = r41302.generalname + " Lv." + r41302.generallevel;
                lstPlus.SelectedIndexChanged -= lstPlus_SelectedIndexChanged;
                lstPlus.Items[lstPlus.SelectedIndex] = r41302.generalname + " (" + r41302.generallevel + ")";
                lstPlus.SelectedIndexChanged += lstPlus_SelectedIndexChanged;
                txtPlusInfo1.Text = r41302.solidernum + "/" + r41302.maxsolidernum;
                txtPlusInfo2.Text = "D" + r41302.leader + " K" + r41302.forces + " T" + r41302.intelligence;
                txtPlusInfo3.Text = r41302.troopname;
                txtPlusInfo4.Text = r41302.troopstagename + " - " + r41302.trooplevel;
                txtPlusInfo5.Text = r41302.skillname;
                txtPlusInfo6.Text = "Tướng Lv. " + r41302.shiftlv + " trở lên";
                btnShift.Enabled = Convert.ToInt32(r41302.shiftlv) <= Convert.ToInt32(r41302.generallevel);
                lblPlusOrigin.Text = "D: " + r41302.baseleader + " + " + r41302.originalattr.plusleader
                    + "\nK: " + r41302.baseforces + " + " + r41302.originalattr.plusforces
                    + "\nT: " + r41302.baseintelligence + " + " + r41302.originalattr.plusintelligence;
                if (r41302.refreshable == "0") {
                    lblPlusNew.Text = "D: " + r41302.baseleader + " + " + r41302.newattr.plusleader
                        + "\nK: " + r41302.baseforces + " + " + r41302.newattr.plusforces
                        + "\nT: " + r41302.baseintelligence + " + " + r41302.newattr.plusintelligence;
                    pnlPlusNew.Visible = true;
                    btnPlusKeep.Enabled = true;
                    btnPlusPlus.Enabled = false;
                } else {
                    pnlPlusNew.Visible = false;
                    btnPlusKeep.Enabled = false;
                    btnPlusPlus.Enabled = true;
                }
                plusok = true;
                break;
            #endregion

            #region 41304
            case "41304":
                // c41304 = true;
                // goto case "11103";
                break;
            #endregion
*/
}
