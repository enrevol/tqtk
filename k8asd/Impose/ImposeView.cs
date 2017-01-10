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
    public partial class ImposeView : UserControl {
        public ImposeView() {
            InitializeComponent();
        }

        /*
        #region 12400
            case "12400":
                r12400 = new R12400(cdata);
        txtImposeHouse.Text = r12400.houseslv;
                txtImposeArea.Text = r12400.areaprosper + "(" + r12400.occupancy + "%)";
                txtImposeLegion.Text = r12400.legionimposetech + " cấp";
                txtImposeCounting.Text = r12400.countinglv;
                txtImposeFactory.Text = r12400.moneyfactorylv;
                txtImposeOffice.Text = r12400.officelv;
                txtImposeCopper.Text = r12400.copper;
                txtImposeNum.Text = r12400.imposenum + "/" + r12400.imposemaxnum;
                txtImposeLoyalty.Text = r12400.loyalty;
                btnImposeForce.Text = "Tăng cường - " + r12400.forceimposecost + " xu";

                imposecdusable = r12400.imposecdusable;
                imposecd = Convert.ToInt32(r12400.lastimposetime);
                break;
            #endregion

         #region 12401
            case "12401":
                R12401 r12401 = new R12401(cdata);
                if (r12401.m == null) {
                    LogText("[Thu thuế] Nhận được " + r12401.cooperdis + " bạc");
                    if (r12401.golddis != "0")
                        txtLogs.AppendText(" và " + r12401.golddis + " xu");

                    txtImposeCopper.Text = r12401.copper;
                    txtImposeLoyalty.Text = r12401.loyalty;
                    txtImposeNum.Text = r12401.imposenum + "/" + r12400.imposemaxnum;
                    btnImposeForce.Text = "Tăng cường - " + r12401.cost + " xu";

                    imposecd = Convert.ToInt32(r12401.imposecd);
                    imposecdusable = r12401.imposecdusable;

                    if (r12401.optdisc1 != null) {
                        grpImposeQuest.Visible = true;
                        lblImposeQuest.Text = r12401.name + ": " + r12401.disc;
                        btnImposeAnswer1.Text = r12401.optdisc1;
                        btnImposeAnswer2.Text = r12401.optdisc2;
                        if (chkImpose.Checked
                            && btnAuto.Text == "Dừng") {
                            bool impose = false;
                            foreach (string s in V.listimposequest[cbbImposePrior.SelectedIndex])
                                if (r12401.optdisc1.Contains(s)) {
                                    impose = true;
                                    break;
                                }
                            if (impose)
                                SendMsg("12406", "1");
                            else
                                SendMsg("12406", "2");
                        }
                    }
                    goto case "11103";
                } else
                    LogText("[Thu thuế] " + r12401.m);
                break;
            #endregion

            #region 12406
            case "12406":
                R12406 r12406 = new R12406(cdata);
                if (r12406.m == null) {
                    LogText("[Thu thuế] Trả lời câu hỏi:");
                    if (r12406.s != "0")
                        txtLogs.AppendText(" " + r12406.s + " Bạc");
                    if (r12406.l != "0")
                        txtLogs.AppendText(" " + r12406.l + " Dân tâm");
                    if (r12406.t != "0")
                        txtLogs.AppendText(" " + r12406.t + " Lượt thu thuế");
                    if (r12406.f != "0")
                        txtLogs.AppendText(" " + r12406.f + " Uy danh");
                    if (r12406.g != "0")
                        txtLogs.AppendText(" " + r12406.g + " Xu");
                    if (r12406.c != "0")
                        txtLogs.AppendText(" " + r12406.f + " Thời gian đóng băng");
                    if (r12406.lnum != null)
                        txtImposeLoyalty.Text = r12406.lnum;
                    if (r12406.cooperdis != "0")
                        txtImposeCopper.Text = r12406.cooperdis;
                    if (r12406.tnum != null)
                        txtImposeNum.Text = r12406.tnum + "/" + r12400.imposemaxnum;
                    if (r12406.cnum != null)
                        imposecd = Convert.ToInt32(r12406.cnum);
                    grpImposeQuest.Visible = false;
                    goto case "11103";
                } else
                    LogText("[Thu thuế] " + r12406.m);
                break;
            #endregion

        

        private void navOffice_SelectedPageChanged(object sender, EventArgs e) {
            switch (navOffice.SelectedIndex) {
            case 0:
                SendMsg("12400");
                break;
            case 1:
                SendMsg("14103");
                break;
            case 2:
                SendMsg("12300");
                break;
            case 3:
                SendMsg("13100");
                break;
            }
        }
            */


    }
}
