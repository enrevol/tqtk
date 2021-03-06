﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace k8asd {
    public partial class ClientView : UserControl, IClientView {
        private List<IClient> clients;

        public List<IClient> Clients {
            get { return clients; }
            set {
                clients = value;
                if (clients != null) {
                    systemLogView.Models = clients.Select(item => item.GetComponent<ISystemLog>()).ToList();
                    chatLogView.Models = clients.Select(item => item.GetComponent<IChatLog>()).ToList();
                    playerInfoView.Models = clients.Select(item => item.GetComponent<IPlayerInfo>()).ToList();
                    mcuInfoView.Models = clients.Select(item => item.GetComponent<IMcuInfo>()).ToList();
                }
            }
        }

        public ClientView() {
            InitializeComponent();

            /*
            infoModel = new InfoModel();
            cooldownModel = new CooldownModel();
            mcuModel = new McuModel();
            messageLogModel = new SystemLog();

            cooldownModel.SetInfoModel(infoModel);
            taskView.SetInfoModel(infoModel);

            infoView.SetModel(infoModel);
            cooldownView.SetModel(cooldownModel);

            mcuView.SetModel(mcuModel);
            taskView.SetMcuModel(mcuModel);

            messageLogView.SetModel(messageLogModel);
            taskView.SetMessageModel(messageLogModel);

            weaveView.SetCooldownModel(cooldownModel);
            weaveView.SetInfoModel(infoModel);
            campaignView.SetInfoModel(infoModel);
            armyView.SetInfoModel(infoModel);
            armyView.SetMessageLogModel(messageLogModel);
            armyView.SetMcuModel(mcuModel);
            outsideView.SetInfoModel(infoModel);
            outsideView.SetCooldownModel(cooldownModel);
            raiseBirdView.SetInfoModel(infoModel);
            raiseBirdView.SetMessageLogModel(messageLogModel);
            instituteView.SetInfoModel(infoModel);
            instituteView.SetMessageLogModel(messageLogModel);

            heroTrainingView.SetCooldownModel(cooldownModel);
            heroTrainingView.SetLogModel(messageLogModel);
            arenaView.SetLogModel(messageLogModel);
            outsideView.SetLogModel(messageLogModel);

            infoModel.SetPacketWriter(this);
            cooldownModel.SetPacketWriter(this);
            mcuView.SetPacketWriter(this);
            mcuModel.SetPacketWriter(this);
            heroTrainingView.SetPacketWriter(this);
            armyView.SetPacketWriter(this);
            messageLogModel.SetPacketWriter(this);
            weaveView.SetPacketWriter(this);
            arenaView.SetPacketWriter(this);
            campaignView.SetPacketWriter(this);
            packetView.SetPacketWriter(this);
            outsideView.SetPacketWriter(this);
            raiseBirdView.SetPacketWriter(this);
            instituteView.SetPacketWriter(this);
            taskView.SetPacketWriter(this);
            */
        }

        private void ClientView_Load(object sender, EventArgs e) {
            //
        }

        public void EnableAutoQuest() {
            // taskView.EnableAutoQuest();
        }

        public void ReportAutoQuest() {
            // taskView.ReportQuest(Config.Username, PlayerName);
        }

        public void UseGoldDaily() {
            //  this.UseGoldDailyAsync();
        }
    }
}