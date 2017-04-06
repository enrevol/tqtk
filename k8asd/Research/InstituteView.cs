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

namespace k8asd {
    public partial class InstituteView : UserControl {
        private InstituteInfo instituteInfo;

        private IPacketWriter packetWriter;
        private IMessageLogModel messageLogModel;
        private IInfoModel infoModel;

        bool isRefreshing;

        public InstituteView() {
            InitializeComponent();

            isRefreshing = false;
            instituteInfo = null;

            nameColumn.AspectGetter = obj => {
                return instituteInfo.Techs.Find(tech => tech.Id == (int) obj).Name;
            };
            levelColumn.AspectGetter = obj => {
                return instituteInfo.Techs.Find(tech => tech.Id == (int) obj).Level;
            };
            extraColumn.AspectGetter = obj => {
                var tech = instituteInfo.Techs.Find(item => item.Id == (int) obj);
                return String.Format("+{0}{1}", tech.Extra, tech.ValueUnit);
            };
            valueColumn.AspectGetter = obj => {
                var tech = instituteInfo.Techs.Find(item => item.Id == (int) obj);
                return String.Format("+{0}{1}", tech.Value, tech.ValueUnit);
            };
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetMessageLogModel(IMessageLogModel model) {
            messageLogModel = model;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
        }

        private async Task RefreshInstitute() {
            if (isRefreshing) {
                return;
            }
            try {
                isRefreshing = true;
                instituteInfo = await packetWriter.RefreshInstituteAsync();
                if (instituteInfo == null) {
                    return;
                }
                var techIds = new List<int>();
                foreach (var tech in instituteInfo.Techs) {
                    techIds.Add(tech.Id);
                }
                techList.SetObjects(techIds, true);
            } finally {
                isRefreshing = false;
            }
        }

        private string Parse63603(Packet packet) {
            var token = JToken.Parse(packet.Message);
            if (token["message"] != null) {
                return token["message"].ToString();
            }
            return "";
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshInstitute();
        }

        private async void checkBox1_CheckedChanged(object sender, EventArgs e) {
            /*
            if (this.checkBox1.Checked) {
                try {
                    while (await CheckConditionAsync() && this.checkBox1.Checked) {
                        //lam moi
                        var packet = await packetWriter.ChangeResearchAsync(indexCombo + 1, (int) numericUpDown1.Value);
                        if (packet == null) {
                            return;
                        }
                        Debug.Assert(packet.CommandId == "63603");
                        if (Parse63603(packet) == "Bạc không đủ") {
                            checkBox1.Checked = false;
                            messageLogModel.LogInfo("Hết bạc.");
                            return;
                        }

                        //kiem tra chi so thay doi
                        packet = await packetWriter.GetListResearchAsync();
                        if (packet == null) {
                            return;
                        }
                        Debug.Assert(packet.CommandId == "63601");
                        Parse63601(packet);

                        string value = this.lbCu.Text;
                        string newvalue = this.lbMoi.Text;
                        if (int.Parse(newvalue) > int.Parse(value)) {
                            //thay the
                            string kynang = (indexCombo + 1) + "";
                            this.rtbLogResearch.Text += "Chỉ số mới: " + newvalue + " > " + value + " ==>  thay the\n";
                            packet = await packetWriter.UpdateResearchAsync(indexCombo + 1);
                            if (packet == null) {
                                return;
                            }
                        } else {
                            this.rtbLogResearch.Text += "Chỉ số mới: " + newvalue + " < " + value + " ==> giu\n";
                        }
                        //Thread.Sleep(80);
                        await Task.Delay(80);
                    }
                    checkBox1.Checked = false;
                    messageLogModel.LogInfo("Hết bạc.");
                } catch (Exception ee) {
                    messageLogModel.LogInfo(ee.Message.ToString());
                }
            }
            */
        }

        private async Task<bool> CheckConditionAsync() {
            var packet = await packetWriter.UpdateInfoAsync();
            if (packet == null) {
                return false;
            }
            if (infoModel.Silver > 20000 || infoModel.Gold > 60) {
                return true;
            }
            return false;
        }

        private void techList_SelectedIndexChanged(object sender, EventArgs e) {
            var selectedItem = techList.SelectedItem;
            if (selectedItem == null) {
                return;
            }
            var id = (int) selectedItem.RowObject;
            var selectedTech = instituteInfo.Techs.Find(tech => tech.Id == id);
        }
    }
}
