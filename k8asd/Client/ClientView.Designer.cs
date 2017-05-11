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
            this.systemLogView = new k8asd.SystemLogView();
            this.cooldownView = new k8asd.CooldownView();
            this.mcuInfoView = new k8asd.McuInfoView();
            this.playerInfoView = new k8asd.PlayerInfoView();
            this.componentTab = new System.Windows.Forms.TabControl();
            this.systemLogTab = new System.Windows.Forms.TabPage();
            this.chatLogTab = new System.Windows.Forms.TabPage();
            this.chatLogView = new k8asd.ChatLogView();
            this.dailyTaskTab = new System.Windows.Forms.TabPage();
            this.dailyTaskView = new k8asd.DailyTaskView();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.componentTab.SuspendLayout();
            this.systemLogTab.SuspendLayout();
            this.chatLogTab.SuspendLayout();
            this.dailyTaskTab.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // systemLogView
            // 
            this.systemLogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemLogView.Location = new System.Drawing.Point(3, 3);
            this.systemLogView.Models = null;
            this.systemLogView.Name = "systemLogView";
            this.systemLogView.Size = new System.Drawing.Size(618, 413);
            this.systemLogView.TabIndex = 31;
            // 
            // cooldownView
            // 
            this.cooldownView.Location = new System.Drawing.Point(319, 3);
            this.cooldownView.Name = "cooldownView";
            this.cooldownView.Size = new System.Drawing.Size(310, 120);
            this.cooldownView.TabIndex = 30;
            // 
            // mcuView
            // 
            this.mcuInfoView.Location = new System.Drawing.Point(3, 101);
            this.mcuInfoView.Models = null;
            this.mcuInfoView.Name = "mcuView";
            this.mcuInfoView.Size = new System.Drawing.Size(310, 22);
            this.mcuInfoView.TabIndex = 29;
            // 
            // playerInfoView
            // 
            this.playerInfoView.Location = new System.Drawing.Point(3, 3);
            this.playerInfoView.Models = null;
            this.playerInfoView.Name = "playerInfoView";
            this.playerInfoView.Size = new System.Drawing.Size(310, 100);
            this.playerInfoView.TabIndex = 28;
            // 
            // componentTab
            // 
            this.componentTab.Controls.Add(this.systemLogTab);
            this.componentTab.Controls.Add(this.chatLogTab);
            this.componentTab.Controls.Add(this.dailyTaskTab);
            this.componentTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentTab.Location = new System.Drawing.Point(0, 125);
            this.componentTab.Name = "componentTab";
            this.componentTab.SelectedIndex = 0;
            this.componentTab.Size = new System.Drawing.Size(632, 445);
            this.componentTab.TabIndex = 32;
            // 
            // systemLogTab
            // 
            this.systemLogTab.Controls.Add(this.systemLogView);
            this.systemLogTab.Location = new System.Drawing.Point(4, 22);
            this.systemLogTab.Name = "systemLogTab";
            this.systemLogTab.Padding = new System.Windows.Forms.Padding(3);
            this.systemLogTab.Size = new System.Drawing.Size(624, 419);
            this.systemLogTab.TabIndex = 0;
            this.systemLogTab.Text = "Hệ thống";
            this.systemLogTab.UseVisualStyleBackColor = true;
            // 
            // chatLogTab
            // 
            this.chatLogTab.Controls.Add(this.chatLogView);
            this.chatLogTab.Location = new System.Drawing.Point(4, 22);
            this.chatLogTab.Name = "chatLogTab";
            this.chatLogTab.Padding = new System.Windows.Forms.Padding(3);
            this.chatLogTab.Size = new System.Drawing.Size(624, 419);
            this.chatLogTab.TabIndex = 1;
            this.chatLogTab.Text = "Chat";
            this.chatLogTab.UseVisualStyleBackColor = true;
            // 
            // chatLogView
            // 
            this.chatLogView.AutoScroll = true;
            this.chatLogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatLogView.Location = new System.Drawing.Point(3, 3);
            this.chatLogView.Models = null;
            this.chatLogView.Name = "chatLogView";
            this.chatLogView.Size = new System.Drawing.Size(618, 413);
            this.chatLogView.TabIndex = 0;
            // 
            // dailyTaskTab
            // 
            this.dailyTaskTab.Controls.Add(this.dailyTaskView);
            this.dailyTaskTab.Location = new System.Drawing.Point(4, 22);
            this.dailyTaskTab.Name = "dailyTaskTab";
            this.dailyTaskTab.Size = new System.Drawing.Size(624, 419);
            this.dailyTaskTab.TabIndex = 2;
            this.dailyTaskTab.Text = "NVHN";
            this.dailyTaskTab.UseVisualStyleBackColor = true;
            // 
            // dailyTaskView
            // 
            this.dailyTaskView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dailyTaskView.Location = new System.Drawing.Point(0, 0);
            this.dailyTaskView.Models = null;
            this.dailyTaskView.Name = "dailyTaskView";
            this.dailyTaskView.Size = new System.Drawing.Size(624, 419);
            this.dailyTaskView.TabIndex = 0;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.playerInfoView);
            this.infoPanel.Controls.Add(this.mcuInfoView);
            this.infoPanel.Controls.Add(this.cooldownView);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(632, 125);
            this.infoPanel.TabIndex = 33;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.componentTab);
            this.Controls.Add(this.infoPanel);
            this.Name = "ClientView";
            this.Size = new System.Drawing.Size(632, 570);
            this.Load += new System.EventHandler(this.ClientView_Load);
            this.componentTab.ResumeLayout(false);
            this.systemLogTab.ResumeLayout(false);
            this.chatLogTab.ResumeLayout(false);
            this.dailyTaskTab.ResumeLayout(false);
            this.infoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PlayerInfoView playerInfoView;
        private McuInfoView mcuInfoView;
        private CooldownView cooldownView;
        private SystemLogView systemLogView;
        private TabControl componentTab;
        private TabPage systemLogTab;
        private TabPage chatLogTab;
        private Panel infoPanel;
        private ChatLogView chatLogView;
        private TabPage dailyTaskTab;
        private DailyTaskView dailyTaskView;
    }
}

