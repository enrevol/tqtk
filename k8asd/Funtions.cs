using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace k8asd
{
    /*
    public partial class ClientView : UserControl
    {
        
        
        private void CheckFoodTrade(string trade)
        {
            int m = Convert.ToInt32(r13100.maxtrade) - Convert.ToInt32(trade);
            if (m == 0)
            {
                barFoodBuy.Enabled = false;
                barFoodSell.Enabled = false;
                btnFoodBuy.Enabled = false;
                btnFoodSell.Enabled = false;
                lblFoodSell.Text = "Số lượng lúa mỗi lần bán ra phải lớn hơn 100";
                lblFoodBuy.Text = "Số lượng lúa mỗi lần giao dịch phải từ 100 trở lên";
            }
            else
            {
                barFoodBuy.Maximum = m;
                barFoodSell.Maximum = m;
                barFoodSell_Scroll(null, null);
                barFoodBuy_Scroll(null, null);
            }
        }

        private void UpdateComplete()
        {
            updateflag = 1;
            for (int i = 0; i < listpower.Length; i++)
                if (listpower[i] != null)
                    cbbArmy1.Items.Add(listpower[i]);

            LogText("[Cập nhật] Thông tin hoàn tất");

            txtLogs.Dock = DockStyle.None;

            this.Size = new Size(700, 550);
            Point offset = new Point(349, 113);
            
            navPower.Location = offset;
            navWorkshop.Location = offset;
            navOthers.Location = offset;
            navShop.Location = offset;
            navMsg.Location = offset;                 
            grpWeaveCreate.Location = grpWeaveParty.Location;
            grpArmyParty.Location = grpArmyList.Location;
            navPower.Visible = false;
            navWorkshop.Visible = false;
            navOthers.Visible = false;
            navShop.Visible = false;
            navMsg.Visible = false;

            pnlAcc.AutoScroll = true;

            Dock = DockStyle.Fill;

            string s = txtServer.Text;
           // AccInfoChanged(s + " - " + r11102.playername + "(" + r11102.playerlevel + ")#" + num.ToString(), new EventArgs());

            /*
            if (r11102.id != "")
                LogText("[Chiến dịch] Nhân vật đang trong chiến dịch");
            if (r11102.map != "0")
            {
                LogText("[Chiến dịch] Còn tàng bảo đồ chưa mở. Mở tàng bảo đồ...");
                SendMsg("47100", "1");
            }

            tmrReq.Start();
        }

        private void SaveConfig()
        {
            string svname = txtServer.Text;
            string filename = svname + "_" + txtUsername.Text;
            StreamWriter writer = new StreamWriter(Environment.CurrentDirectory + "\\" + filename + ".txt");
            JObject save = new JObject();
            JObject obj = new JObject();
            JObject obj2;
            save.Add("update", Convert.ToInt32(numUpdate.Value));
            obj.Add("user", txtUsername.Text);
            obj.Add("pass", F.EncryptPass(txtPassword.Text));
            save.Add("player", obj);
            obj = new JObject();
            obj.Add("check", chkImpose.Checked);
            obj.Add("prior", cbbImposePrior.SelectedIndex);
            save.Add("impose", obj);
            obj = new JObject();
            obj.Add("check", chkTrain.Checked);
            JArray array = new JArray();
            for (int i = 0; i < lstGuide.Items.Count; i++)
            {
                obj2 = new JObject();
                obj2.Add("check", lstGuide.CheckedIndices.Contains(i));
                TagItem it = (TagItem)lstGuide.Items[i];
                obj2.Add("general", it.text);
                obj2.Add("id", it.tag);
                array.Add(obj2);
            }
            obj.Add("list", array);
            save.Add("train", obj);
            obj = new JObject();
            obj.Add("check", chkArmy.Checked);
            obj.Add("mode", cbbArmyMode.SelectedIndex);
            obj.Add("wait", chkArmyCd.Checked);
            obj.Add("limit", Convert.ToInt32(numArmyAttack.Value));
            obj.Add("limitcheck", chkArmyAttack.Checked);
            obj.Add("refresh", Convert.ToInt32(numArmyRefresh.Value));
            obj.Add("refreshcheck", chkArmyRefresh.Checked);
            array = new JArray();
            for (int i = 0; i < lstArmyList.Items.Count; i++)
            {
                obj2 = new JObject();
                obj2.Add("check", lstArmyList.CheckedIndices.Contains(i));
                TagItem it = (TagItem)lstArmyList.Items[i];
                obj2.Add("army", it.text);
                obj2.Add("id", it.tag);
                array.Add(obj2);
            }
            obj.Add("list", array);
            save.Add("army", obj);
            obj = new JObject();
            obj.Add("forcecheck", chkForces.Checked);
            obj.Add("forcenum", Convert.ToInt32(numForces.Value));
            obj.Add("forcefree", chkForcesFree.Checked);
            save.Add("forces", obj);
            writer.Write(save.ToString());
            writer.Flush();
            writer.Close();
        }

        
    }   
*/
}