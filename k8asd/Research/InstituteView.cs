using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace k8asd
{
    public partial class InstituteView : UserControl
    {
        private int indexCombo = 0;

        private IPacketWriter packetWriter;
        private IMessageLogModel messageLogModel;
        private IInfoModel infoModel;

        public InstituteView()
        {
            InitializeComponent();

            List<ComboboxResearch> listRe = initListResearch();

            for (int i = 0; i < listRe.Count; i++)
            {
                this.comboBox1.Items.Add(listRe[i]);
            }

            //this.comboBox1.SelectedIndex = 0;
        }

        public List<ComboboxResearch> initListResearch()
        {
            List<ComboboxResearch> listRe = new List<ComboboxResearch>();
            ComboboxResearch re = new ComboboxResearch("1", "Công - 359");
            listRe.Add(re);
            re = new ComboboxResearch("2", "Phép - 833");
            listRe.Add(re);
            re = new ComboboxResearch("3", "Mưu - 183");
            listRe.Add(re);
            re = new ComboboxResearch("4", "Thủ công - 269");
            listRe.Add(re);
            re = new ComboboxResearch("5", "Thủ phép - 594");
            listRe.Add(re);
            re = new ComboboxResearch("6", "Thủ mưu - 153");
            listRe.Add(re);
            re = new ComboboxResearch("7", "Né - 20%");
            listRe.Add(re);
            re = new ComboboxResearch("8", "Bạo kích - 20%");
            listRe.Add(re);
            re = new ComboboxResearch("9", "Chính xác - 20%");
            listRe.Add(re);
            re = new ComboboxResearch("10", "Dẻo dai - 20%");
            listRe.Add(re);
            re = new ComboboxResearch("11", "Thống lĩnh - 507");
            listRe.Add(re);

            return listRe;
        }

        public void SetPacketWriter(IPacketWriter writer)
        {
            packetWriter = writer;
        }

        public void SetMessageLogModel(IMessageLogModel model)
        {
            messageLogModel = model;
        }

        public void SetInfoModel(IInfoModel model)
        {
            infoModel = model;
        }

        public async void GetListResearh()
        {
            var packet = await packetWriter.GetListResearchAsync();
            if (packet == null)
            {
                return;
            }
            Debug.Assert(packet.CommandId == "63601");
            Parse63601(packet);
        }

        private void Parse63601(Packet packet)
        {
            var token = JToken.Parse(packet.Message);
            JArray array = (JArray)token["instityteDto"];

            JObject objCur = (JObject)array[indexCombo];
            string value = objCur["value"].ToString();
            string newvalue = objCur["newvalue"].ToString();
            this.lbCu.Text = value;
            this.lbMoi.Text = newvalue;
        }

        private string Parse63603(Packet packet)
        {
            var token = JToken.Parse(packet.Message);
            if (token["message"] != null)
            {
                return token["message"].ToString();
            }
            return "";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetListResearh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexCombo = this.comboBox1.SelectedIndex;
            GetListResearh();
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                try
                {
                    while (await CheckConditionAsync() && this.checkBox1.Checked)
                    {
                        //lam moi
                        var packet = await packetWriter.ChangeResearchAsync(indexCombo + 1, (int)numericUpDown1.Value);
                        if (packet == null)
                        {
                            return;
                        }
                        Debug.Assert(packet.CommandId == "63603");
                        if (Parse63603(packet) == "Bạc không đủ")
                        {
                            checkBox1.Checked = false;
                            messageLogModel.LogInfo("Hết bạc.");
                            return;
                        }

                        //kiem tra chi so thay doi
                        packet = await packetWriter.GetListResearchAsync();
                        if (packet == null)
                        {
                            return;
                        }
                        Debug.Assert(packet.CommandId == "63601");
                        Parse63601(packet);

                        string value = this.lbCu.Text;
                        string newvalue = this.lbMoi.Text;
                        if (int.Parse(newvalue) > int.Parse(value))
                        {
                            //thay the
                            string kynang = (indexCombo + 1) + "";
                            this.rtbLogResearch.Text += "Chỉ số mới: " + newvalue + " > " + value + " ==>  thay the\n";
                            packet = await packetWriter.UpdateResearchAsync(indexCombo + 1);
                            if (packet == null)
                            {
                                return;
                            }
                        }
                        else
                        {
                            this.rtbLogResearch.Text += "Chỉ số mới: " + newvalue + " < " + value + " ==> giu\n";
                        }
                        //Thread.Sleep(80);
                        await Task.Delay(80);
                    }
                    checkBox1.Checked = false;
                    messageLogModel.LogInfo("Hết bạc.");
                }
                catch (Exception ee)
                {
                    messageLogModel.LogInfo(ee.Message.ToString());
                }
            }
        }

        private async Task<bool> CheckConditionAsync()
        {
            var packet = await packetWriter.UpdateInfoAsync();
            if (packet == null)
            {
                return false;
            }
            if (infoModel.Silver > 20000 || infoModel.Gold > 60)
            {
                return true;
            }
            return false;
        }

        private void rtbLogResearch_TextChanged(object sender, EventArgs e)
        {
            this.rtbLogResearch.SelectionStart = this.rtbLogResearch.Text.Length;
            this.rtbLogResearch.ScrollToCaret();
            if (this.rtbLogResearch.Text.Length > 20000)
            {
                this.rtbLogResearch.Clear();
            }
        }
    }
}
