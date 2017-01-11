namespace k8asd {
    partial class ArmyView {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.armyList = new System.Windows.Forms.ListBox();
            this.refreshArmyButton = new System.Windows.Forms.Button();
            this.teamList = new System.Windows.Forms.ListBox();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.armyInfoBox = new System.Windows.Forms.GroupBox();
            this.itemLabel = new System.Windows.Forms.TextBox();
            this.limitLabel = new System.Windows.Forms.Label();
            this._ignore0 = new System.Windows.Forms.Label();
            this.honorLabel = new System.Windows.Forms.Label();
            this.playerNumLabel = new System.Windows.Forms.Label();
            this.armyNumLabel = new System.Windows.Forms.Label();
            this.baseHonorLabel = new System.Windows.Forms.Label();
            this.refreshTeamButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.armyInfoBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // armyList
            // 
            this.armyList.FormattingEnabled = true;
            this.armyList.Location = new System.Drawing.Point(5, 40);
            this.armyList.Name = "armyList";
            this.armyList.Size = new System.Drawing.Size(200, 225);
            this.armyList.TabIndex = 0;
            this.armyList.SelectedIndexChanged += new System.EventHandler(this.armyList_SelectedIndexChanged);
            // 
            // refreshArmyButton
            // 
            this.refreshArmyButton.Location = new System.Drawing.Point(5, 5);
            this.refreshArmyButton.Name = "refreshArmyButton";
            this.refreshArmyButton.Size = new System.Drawing.Size(75, 30);
            this.refreshArmyButton.TabIndex = 11;
            this.refreshArmyButton.Text = "Làm mới";
            this.refreshArmyButton.UseVisualStyleBackColor = true;
            this.refreshArmyButton.Click += new System.EventHandler(this.refreshArmyButton_Click);
            // 
            // teamList
            // 
            this.teamList.FormattingEnabled = true;
            this.teamList.Location = new System.Drawing.Point(10, 60);
            this.teamList.Name = "teamList";
            this.teamList.ScrollAlwaysVisible = true;
            this.teamList.Size = new System.Drawing.Size(230, 225);
            this.teamList.TabIndex = 12;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Enabled = true;
            this.refreshTimer.Interval = 1000;
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // armyInfoBox
            // 
            this.armyInfoBox.Controls.Add(this.itemLabel);
            this.armyInfoBox.Controls.Add(this.limitLabel);
            this.armyInfoBox.Controls.Add(this._ignore0);
            this.armyInfoBox.Controls.Add(this.honorLabel);
            this.armyInfoBox.Location = new System.Drawing.Point(215, 40);
            this.armyInfoBox.Name = "armyInfoBox";
            this.armyInfoBox.Size = new System.Drawing.Size(250, 70);
            this.armyInfoBox.TabIndex = 13;
            this.armyInfoBox.TabStop = false;
            this.armyInfoBox.Text = "Công Tôn Toản Lv. 32";
            // 
            // itemLabel
            // 
            this.itemLabel.Location = new System.Drawing.Point(60, 20);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.ReadOnly = true;
            this.itemLabel.Size = new System.Drawing.Size(180, 20);
            this.itemLabel.TabIndex = 19;
            this.itemLabel.Text = "Thất Tinh Kiếm";
            this.itemLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // limitLabel
            // 
            this.limitLabel.AutoSize = true;
            this.limitLabel.Location = new System.Drawing.Point(5, 48);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(81, 13);
            this.limitLabel.TabIndex = 18;
            this.limitLabel.Text = "Giới hạn: 99/99";
            // 
            // _ignore0
            // 
            this._ignore0.AutoSize = true;
            this._ignore0.Location = new System.Drawing.Point(5, 23);
            this._ignore0.Name = "_ignore0";
            this._ignore0.Size = new System.Drawing.Size(44, 13);
            this._ignore0.TabIndex = 17;
            this._ignore0.Text = "Thưởng";
            // 
            // honorLabel
            // 
            this.honorLabel.AutoSize = true;
            this.honorLabel.Location = new System.Drawing.Point(120, 48);
            this.honorLabel.Name = "honorLabel";
            this.honorLabel.Size = new System.Drawing.Size(92, 13);
            this.honorLabel.TabIndex = 16;
            this.honorLabel.Text = "Chiến tích: 99999";
            // 
            // playerNumLabel
            // 
            this.playerNumLabel.AutoSize = true;
            this.playerNumLabel.Location = new System.Drawing.Point(120, 15);
            this.playerNumLabel.Name = "playerNumLabel";
            this.playerNumLabel.Size = new System.Drawing.Size(105, 13);
            this.playerNumLabel.TabIndex = 13;
            this.playerNumLabel.Text = "Người tham gia: 4 - 8";
            // 
            // armyNumLabel
            // 
            this.armyNumLabel.AutoSize = true;
            this.armyNumLabel.Location = new System.Drawing.Point(5, 15);
            this.armyNumLabel.Name = "armyNumLabel";
            this.armyNumLabel.Size = new System.Drawing.Size(62, 13);
            this.armyNumLabel.TabIndex = 14;
            this.armyNumLabel.Text = "Đội quân: 8";
            // 
            // baseHonorLabel
            // 
            this.baseHonorLabel.AutoSize = true;
            this.baseHonorLabel.Location = new System.Drawing.Point(5, 35);
            this.baseHonorLabel.Name = "baseHonorLabel";
            this.baseHonorLabel.Size = new System.Drawing.Size(122, 13);
            this.baseHonorLabel.TabIndex = 15;
            this.baseHonorLabel.Text = "Chiến tích cơ bản: 9999";
            // 
            // refreshTeamButton
            // 
            this.refreshTeamButton.Location = new System.Drawing.Point(216, 119);
            this.refreshTeamButton.Name = "refreshTeamButton";
            this.refreshTeamButton.Size = new System.Drawing.Size(100, 30);
            this.refreshTeamButton.TabIndex = 20;
            this.refreshTeamButton.Text = "Làm mới tổ đội";
            this.refreshTeamButton.UseVisualStyleBackColor = true;
            this.refreshTeamButton.Click += new System.EventHandler(this.refreshTeamButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.teamList);
            this.groupBox1.Controls.Add(this.armyNumLabel);
            this.groupBox1.Controls.Add(this.playerNumLabel);
            this.groupBox1.Controls.Add(this.baseHonorLabel);
            this.groupBox1.Location = new System.Drawing.Point(215, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 300);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // ArmyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.refreshTeamButton);
            this.Controls.Add(this.armyInfoBox);
            this.Controls.Add(this.refreshArmyButton);
            this.Controls.Add(this.armyList);
            this.Name = "ArmyView";
            this.Size = new System.Drawing.Size(635, 521);
            this.armyInfoBox.ResumeLayout(false);
            this.armyInfoBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox armyList;
        private System.Windows.Forms.Button refreshArmyButton;
        private System.Windows.Forms.ListBox teamList;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.GroupBox armyInfoBox;
        private System.Windows.Forms.Label playerNumLabel;
        private System.Windows.Forms.Label armyNumLabel;
        private System.Windows.Forms.Label honorLabel;
        private System.Windows.Forms.Label baseHonorLabel;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.Label _ignore0;
        private System.Windows.Forms.TextBox itemLabel;
        private System.Windows.Forms.Button refreshTeamButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
