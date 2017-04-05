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
    public partial class RaiseBirdView : UserControl
    {
        private RaiseBirdInfo raiseBirdInfo;

        private IPacketWriter packetWriter;
        private IMessageLogModel messageLogModel;
        private IInfoModel infoModel;

        public RaiseBirdView()
        {
            InitializeComponent();
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

        private void OnPacketReceived(Packet packet)
        {
            //
        }

        private async void refreshButton_Click(object sender, EventArgs e)
        {
            var packet = await packetWriter.RefreshRaiseBirdAsync();
            if (packet == null)
            {
                return;
            }
            Debug.Assert(packet.CommandId == "66004");
            Parse66004(packet);
        }

        private void Parse66004(Packet packet)
        {
            var token = JToken.Parse(packet.Message);
            raiseBirdInfo = RaiseBirdInfo.Parse(token);

            lbNameRaiseBird.Text = raiseBirdInfo.name;
            lbStar.Text = String.Format("{0}", raiseBirdInfo.level);
            lbExpRaiseBird.Text = String.Format("{0} / {1}", raiseBirdInfo.currentExperience, raiseBirdInfo.upgradeExperience);
        }

        private async void chkAutoRaiseBird_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoRaiseBird.Checked)
            {
                try
                {
                    while (await CheckConditionAsync() && chkAutoRaiseBird.Checked)
                    {
                        int type = 1;
                        var packet = await packetWriter.RaiseBirdAsync(type);
                        if (packet == null)
                        {
                            messageLogModel.LogInfo("Lỗi nuôi chim.");
                        }
                        Parse66004(packet);
                        //Thread.Sleep(80);
                        await Task.Delay(80);
                    }
                    chkAutoRaiseBird.Checked = false;
                    messageLogModel.LogInfo("Hết bạc.");
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message.ToString());
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
            if (infoModel.Silver > 20000 || infoModel.Gold > 20)
            {
                return true;
            }
            return false;
        }
    }
}
