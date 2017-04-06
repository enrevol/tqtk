using System.Windows.Forms;

namespace k8asd {
    partial class ClientView : UserControl {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.barFoodBuy = new System.Windows.Forms.TrackBar();
            this.barFoodSell = new System.Windows.Forms.TrackBar();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.heroTrainingTab = new System.Windows.Forms.TabPage();
            this.heroTrainingView = new k8asd.HeroTrainingView();
            this.armyTab = new System.Windows.Forms.TabPage();
            this.armyView = new k8asd.ArmyView();
            this.weaveTab = new System.Windows.Forms.TabPage();
            this.weaveView = new k8asd.WeaveView();
            this.arenaTab = new System.Windows.Forms.TabPage();
            this.arenaView = new k8asd.ArenaView();
            this.campaignTab = new System.Windows.Forms.TabPage();
            this.campaignView = new k8asd.CampaignView();
            this.outsideTab = new System.Windows.Forms.TabPage();
            this.outsideView = new k8asd.OutsideView();
            this.packetTab = new System.Windows.Forms.TabPage();
            this.packetView = new k8asd.PacketView();
            this.raiseBirdTab = new System.Windows.Forms.TabPage();
            this.raiseBirdView = new k8asd.RaiseBirdView();
            this.instituteTab = new System.Windows.Forms.TabPage();
            this.instituteView = new k8asd.InstituteView();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.testConnectionTimer = new System.Windows.Forms.Timer(this.components);
            this.messageLogView = new k8asd.MessageLogView();
            this.chatLogView = new k8asd.ChatLogView();
            this.cooldownView = new k8asd.CooldownView();
            this.mcuView = new k8asd.McuView();
            this.infoView = new k8asd.InfoView();
            ((System.ComponentModel.ISupportInitialize)(this.barFoodBuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFoodSell)).BeginInit();
            this.tabControl.SuspendLayout();
            this.heroTrainingTab.SuspendLayout();
            this.armyTab.SuspendLayout();
            this.weaveTab.SuspendLayout();
            this.arenaTab.SuspendLayout();
            this.campaignTab.SuspendLayout();
            this.outsideTab.SuspendLayout();
            this.packetTab.SuspendLayout();
            this.raiseBirdTab.SuspendLayout();
            this.instituteTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // barFoodBuy
            // 
            this.barFoodBuy.LargeChange = 100;
            this.barFoodBuy.Location = new System.Drawing.Point(3, 3);
            this.barFoodBuy.Maximum = 1000;
            this.barFoodBuy.Minimum = 1;
            this.barFoodBuy.Name = "barFoodBuy";
            this.barFoodBuy.Size = new System.Drawing.Size(324, 45);
            this.barFoodBuy.TabIndex = 0;
            this.barFoodBuy.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barFoodBuy.Value = 1;
            // 
            // barFoodSell
            // 
            this.barFoodSell.LargeChange = 100;
            this.barFoodSell.Location = new System.Drawing.Point(3, 3);
            this.barFoodSell.Maximum = 1000;
            this.barFoodSell.Minimum = 1;
            this.barFoodSell.Name = "barFoodSell";
            this.barFoodSell.Size = new System.Drawing.Size(324, 45);
            this.barFoodSell.TabIndex = 0;
            this.barFoodSell.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barFoodSell.Value = 1;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.heroTrainingTab);
            this.tabControl.Controls.Add(this.armyTab);
            this.tabControl.Controls.Add(this.weaveTab);
            this.tabControl.Controls.Add(this.arenaTab);
            this.tabControl.Controls.Add(this.campaignTab);
            this.tabControl.Controls.Add(this.outsideTab);
            this.tabControl.Controls.Add(this.packetTab);
            this.tabControl.Controls.Add(this.raiseBirdTab);
            this.tabControl.Controls.Add(this.instituteTab);
            this.tabControl.Location = new System.Drawing.Point(321, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(645, 558);
            this.tabControl.TabIndex = 33;
            // 
            // heroTrainingTab
            // 
            this.heroTrainingTab.Controls.Add(this.heroTrainingView);
            this.heroTrainingTab.Location = new System.Drawing.Point(4, 22);
            this.heroTrainingTab.Name = "heroTrainingTab";
            this.heroTrainingTab.Padding = new System.Windows.Forms.Padding(3);
            this.heroTrainingTab.Size = new System.Drawing.Size(637, 532);
            this.heroTrainingTab.TabIndex = 0;
            this.heroTrainingTab.Text = "Luyện";
            this.heroTrainingTab.UseVisualStyleBackColor = true;
            // 
            // heroTrainingView
            // 
            this.heroTrainingView.BackColor = System.Drawing.SystemColors.Control;
            this.heroTrainingView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.heroTrainingView.Location = new System.Drawing.Point(3, 3);
            this.heroTrainingView.Name = "heroTrainingView";
            this.heroTrainingView.Size = new System.Drawing.Size(631, 526);
            this.heroTrainingView.TabIndex = 32;
            // 
            // armyTab
            // 
            this.armyTab.Controls.Add(this.armyView);
            this.armyTab.Location = new System.Drawing.Point(4, 22);
            this.armyTab.Name = "armyTab";
            this.armyTab.Padding = new System.Windows.Forms.Padding(3);
            this.armyTab.Size = new System.Drawing.Size(637, 532);
            this.armyTab.TabIndex = 1;
            this.armyTab.Text = "Quân đoàn";
            this.armyTab.UseVisualStyleBackColor = true;
            // 
            // armyView
            // 
            this.armyView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.armyView.Location = new System.Drawing.Point(3, 3);
            this.armyView.Name = "armyView";
            this.armyView.Size = new System.Drawing.Size(631, 526);
            this.armyView.TabIndex = 0;
            // 
            // weaveTab
            // 
            this.weaveTab.Controls.Add(this.weaveView);
            this.weaveTab.Location = new System.Drawing.Point(4, 22);
            this.weaveTab.Name = "weaveTab";
            this.weaveTab.Padding = new System.Windows.Forms.Padding(3);
            this.weaveTab.Size = new System.Drawing.Size(637, 532);
            this.weaveTab.TabIndex = 2;
            this.weaveTab.Text = "Dệt";
            this.weaveTab.UseVisualStyleBackColor = true;
            // 
            // weaveView
            // 
            this.weaveView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weaveView.Location = new System.Drawing.Point(3, 3);
            this.weaveView.Name = "weaveView";
            this.weaveView.Size = new System.Drawing.Size(631, 526);
            this.weaveView.TabIndex = 0;
            // 
            // arenaTab
            // 
            this.arenaTab.Controls.Add(this.arenaView);
            this.arenaTab.Location = new System.Drawing.Point(4, 22);
            this.arenaTab.Name = "arenaTab";
            this.arenaTab.Padding = new System.Windows.Forms.Padding(3);
            this.arenaTab.Size = new System.Drawing.Size(637, 532);
            this.arenaTab.TabIndex = 3;
            this.arenaTab.Text = "Võ đài";
            this.arenaTab.UseVisualStyleBackColor = true;
            // 
            // arenaView
            // 
            this.arenaView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arenaView.Location = new System.Drawing.Point(3, 3);
            this.arenaView.Name = "arenaView";
            this.arenaView.Size = new System.Drawing.Size(631, 526);
            this.arenaView.TabIndex = 0;
            // 
            // campaignTab
            // 
            this.campaignTab.Controls.Add(this.campaignView);
            this.campaignTab.Location = new System.Drawing.Point(4, 22);
            this.campaignTab.Name = "campaignTab";
            this.campaignTab.Padding = new System.Windows.Forms.Padding(3);
            this.campaignTab.Size = new System.Drawing.Size(637, 532);
            this.campaignTab.TabIndex = 4;
            this.campaignTab.Text = "Chiến dịch";
            this.campaignTab.UseVisualStyleBackColor = true;
            // 
            // campaignView
            // 
            this.campaignView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.campaignView.Location = new System.Drawing.Point(3, 3);
            this.campaignView.Name = "campaignView";
            this.campaignView.Size = new System.Drawing.Size(631, 526);
            this.campaignView.TabIndex = 0;
            // 
            // outsideTab
            // 
            this.outsideTab.Controls.Add(this.outsideView);
            this.outsideTab.Location = new System.Drawing.Point(4, 22);
            this.outsideTab.Name = "outsideTab";
            this.outsideTab.Padding = new System.Windows.Forms.Padding(3);
            this.outsideTab.Size = new System.Drawing.Size(637, 532);
            this.outsideTab.TabIndex = 6;
            this.outsideTab.Text = "Ngoại thành";
            this.outsideTab.UseVisualStyleBackColor = true;
            // 
            // outsideView
            // 
            this.outsideView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outsideView.Location = new System.Drawing.Point(3, 3);
            this.outsideView.Name = "outsideView";
            this.outsideView.Size = new System.Drawing.Size(631, 526);
            this.outsideView.TabIndex = 0;
            // 
            // packetTab
            // 
            this.packetTab.Controls.Add(this.packetView);
            this.packetTab.Location = new System.Drawing.Point(4, 22);
            this.packetTab.Name = "packetTab";
            this.packetTab.Size = new System.Drawing.Size(637, 532);
            this.packetTab.TabIndex = 5;
            this.packetTab.Text = "Gói tin";
            this.packetTab.UseVisualStyleBackColor = true;
            // 
            // packetView
            // 
            this.packetView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.packetView.Location = new System.Drawing.Point(0, 0);
            this.packetView.Name = "packetView";
            this.packetView.Size = new System.Drawing.Size(637, 532);
            this.packetView.TabIndex = 0;
            // 
            // raiseBirdTab
            // 
            this.raiseBirdTab.Controls.Add(this.raiseBirdView);
            this.raiseBirdTab.Location = new System.Drawing.Point(4, 22);
            this.raiseBirdTab.Name = "raiseBirdTab";
            this.raiseBirdTab.Size = new System.Drawing.Size(637, 532);
            this.raiseBirdTab.TabIndex = 7;
            this.raiseBirdTab.Text = "Chim to dần";
            this.raiseBirdTab.UseVisualStyleBackColor = true;
            // 
            // raiseBirdView
            // 
            this.raiseBirdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.raiseBirdView.Location = new System.Drawing.Point(0, 0);
            this.raiseBirdView.Name = "raiseBirdView";
            this.raiseBirdView.Size = new System.Drawing.Size(637, 532);
            this.raiseBirdView.TabIndex = 0;
            // 
            // instituteTab
            // 
            this.instituteTab.Controls.Add(this.instituteView);
            this.instituteTab.Location = new System.Drawing.Point(4, 22);
            this.instituteTab.Name = "instituteTab";
            this.instituteTab.Size = new System.Drawing.Size(637, 532);
            this.instituteTab.TabIndex = 8;
            this.instituteTab.Text = "SNC";
            // 
            // instituteView
            // 
            this.instituteView.Location = new System.Drawing.Point(0, 0);
            this.instituteView.Name = "instituteView";
            this.instituteView.Size = new System.Drawing.Size(453, 287);
            this.instituteView.TabIndex = 0;
            // 
            // dataTimer
            // 
            this.dataTimer.Interval = 50;
            this.dataTimer.Tick += new System.EventHandler(this.dataTimer_Tick);
            // 
            // testConnectionTimer
            // 
            this.testConnectionTimer.Enabled = true;
            this.testConnectionTimer.Interval = 1000;
            this.testConnectionTimer.Tick += new System.EventHandler(this.testConnectionTimer_Tick);
            // 
            // messageLogView
            // 
            this.messageLogView.Location = new System.Drawing.Point(0, 245);
            this.messageLogView.Name = "messageLogView";
            this.messageLogView.Size = new System.Drawing.Size(315, 125);
            this.messageLogView.TabIndex = 31;
            // 
            // chatLogView
            // 
            this.chatLogView.Location = new System.Drawing.Point(0, 375);
            this.chatLogView.Name = "chatLogView";
            this.chatLogView.Size = new System.Drawing.Size(315, 180);
            this.chatLogView.TabIndex = 34;
            // 
            // cooldownView
            // 
            this.cooldownView.Location = new System.Drawing.Point(0, 100);
            this.cooldownView.Name = "cooldownView";
            this.cooldownView.Size = new System.Drawing.Size(310, 120);
            this.cooldownView.TabIndex = 30;
            // 
            // mcuView
            // 
            this.mcuView.Location = new System.Drawing.Point(0, 220);
            this.mcuView.Name = "mcuView";
            this.mcuView.Size = new System.Drawing.Size(310, 22);
            this.mcuView.TabIndex = 29;
            // 
            // infoView
            // 
            this.infoView.Location = new System.Drawing.Point(0, 0);
            this.infoView.Name = "infoView";
            this.infoView.Size = new System.Drawing.Size(310, 100);
            this.infoView.TabIndex = 28;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chatLogView);
            this.Controls.Add(this.messageLogView);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cooldownView);
            this.Controls.Add(this.mcuView);
            this.Controls.Add(this.infoView);
            this.Name = "ClientView";
            this.Size = new System.Drawing.Size(987, 565);
            this.Load += new System.EventHandler(this.ClientView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barFoodBuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barFoodSell)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.heroTrainingTab.ResumeLayout(false);
            this.armyTab.ResumeLayout(false);
            this.weaveTab.ResumeLayout(false);
            this.arenaTab.ResumeLayout(false);
            this.campaignTab.ResumeLayout(false);
            this.outsideTab.ResumeLayout(false);
            this.packetTab.ResumeLayout(false);
            this.raiseBirdTab.ResumeLayout(false);
            this.instituteTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TrackBar barFoodBuy;
        private TrackBar barFoodSell;
        private InfoView infoView;
        private McuView mcuView;
        private CooldownView cooldownView;
        private MessageLogView messageLogView;
        private HeroTrainingView heroTrainingView;
        private TabControl tabControl;
        private TabPage heroTrainingTab;
        private TabPage armyTab;
        private ArmyView armyView;
        private ChatLogView chatLogView;
        private TabPage weaveTab;
        private WeaveView weaveView;
        private TabPage arenaTab;
        private ArenaView arenaView;
        private Timer dataTimer;
        private TabPage campaignTab;
        private CampaignView campaignView;
        private Timer testConnectionTimer;
        private TabPage packetTab;
        private PacketView packetView;
        private TabPage outsideTab;
        private OutsideView outsideView;
        private TabPage raiseBirdTab;
        private RaiseBirdView raiseBirdView;
        private TabPage instituteTab;
        private InstituteView instituteView;
    }
}

