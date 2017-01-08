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
}
