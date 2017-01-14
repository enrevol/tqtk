﻿namespace k8asd {
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
            this.refreshTeamTimer = new System.Windows.Forms.Timer(this.components);
            this.armyInfoBox = new System.Windows.Forms.GroupBox();
            this.itemLabel = new System.Windows.Forms.TextBox();
            this.limitLabel = new System.Windows.Forms.Label();
            this._ignore0 = new System.Windows.Forms.Label();
            this.honorLabel = new System.Windows.Forms.Label();
            this.playerNumLabel = new System.Windows.Forms.Label();
            this.armyNumLabel = new System.Windows.Forms.Label();
            this.baseHonorLabel = new System.Windows.Forms.Label();
            this.refreshTeamButton = new System.Windows.Forms.Button();
            this.teamBox = new System.Windows.Forms.GroupBox();
            this.createLegionButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.inviteButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.disbandButton = new System.Windows.Forms.Button();
            this.forceAttackButton = new System.Windows.Forms.Button();
            this.attackButton = new System.Windows.Forms.Button();
            this.joinX10Button = new System.Windows.Forms.Button();
            this.teamList = new BrightIdeasSoftware.ObjectListView();
            this.teamColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.joinColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.memberList = new BrightIdeasSoftware.ObjectListView();
            this.memberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.kickColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.moveUpColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.moveDownColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.memberBox = new System.Windows.Forms.GroupBox();
            this.autoRefreshTeamBox = new System.Windows.Forms.CheckBox();
            this.refreshTeamInterval = new System.Windows.Forms.NumericUpDown();
            this.armyInfoBox.SuspendLayout();
            this.teamBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberList)).BeginInit();
            this.memberBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshTeamInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // armyList
            // 
            this.armyList.FormattingEnabled = true;
            this.armyList.Location = new System.Drawing.Point(5, 120);
            this.armyList.Name = "armyList";
            this.armyList.Size = new System.Drawing.Size(250, 329);
            this.armyList.TabIndex = 0;
            this.armyList.SelectedIndexChanged += new System.EventHandler(this.armyList_SelectedIndexChanged);
            // 
            // refreshArmyButton
            // 
            this.refreshArmyButton.Location = new System.Drawing.Point(5, 5);
            this.refreshArmyButton.Name = "refreshArmyButton";
            this.refreshArmyButton.Size = new System.Drawing.Size(120, 30);
            this.refreshArmyButton.TabIndex = 11;
            this.refreshArmyButton.Text = "Làm mới quân đoàn";
            this.refreshArmyButton.UseVisualStyleBackColor = true;
            this.refreshArmyButton.Click += new System.EventHandler(this.refreshArmyButton_Click);
            // 
            // refreshTeamTimer
            // 
            this.refreshTeamTimer.Enabled = true;
            this.refreshTeamTimer.Interval = 1000;
            this.refreshTeamTimer.Tick += new System.EventHandler(this.refreshTeamTimer_Tick);
            // 
            // armyInfoBox
            // 
            this.armyInfoBox.Controls.Add(this.itemLabel);
            this.armyInfoBox.Controls.Add(this.limitLabel);
            this.armyInfoBox.Controls.Add(this._ignore0);
            this.armyInfoBox.Controls.Add(this.honorLabel);
            this.armyInfoBox.Location = new System.Drawing.Point(5, 41);
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
            this.itemLabel.TabStop = false;
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
            this.playerNumLabel.Location = new System.Drawing.Point(75, 20);
            this.playerNumLabel.Name = "playerNumLabel";
            this.playerNumLabel.Size = new System.Drawing.Size(105, 13);
            this.playerNumLabel.TabIndex = 13;
            this.playerNumLabel.Text = "Người tham gia: 4 - 8";
            // 
            // armyNumLabel
            // 
            this.armyNumLabel.AutoSize = true;
            this.armyNumLabel.Location = new System.Drawing.Point(5, 20);
            this.armyNumLabel.Name = "armyNumLabel";
            this.armyNumLabel.Size = new System.Drawing.Size(62, 13);
            this.armyNumLabel.TabIndex = 14;
            this.armyNumLabel.Text = "Đội quân: 8";
            // 
            // baseHonorLabel
            // 
            this.baseHonorLabel.AutoSize = true;
            this.baseHonorLabel.Location = new System.Drawing.Point(190, 20);
            this.baseHonorLabel.Name = "baseHonorLabel";
            this.baseHonorLabel.Size = new System.Drawing.Size(122, 13);
            this.baseHonorLabel.TabIndex = 15;
            this.baseHonorLabel.Text = "Chiến tích cơ bản: 9999";
            // 
            // refreshTeamButton
            // 
            this.refreshTeamButton.Location = new System.Drawing.Point(265, 5);
            this.refreshTeamButton.Name = "refreshTeamButton";
            this.refreshTeamButton.Size = new System.Drawing.Size(100, 30);
            this.refreshTeamButton.TabIndex = 20;
            this.refreshTeamButton.Text = "Làm mới tổ đội";
            this.refreshTeamButton.UseVisualStyleBackColor = true;
            this.refreshTeamButton.Click += new System.EventHandler(this.refreshTeamButton_Click);
            // 
            // teamBox
            // 
            this.teamBox.Controls.Add(this.createLegionButton);
            this.teamBox.Controls.Add(this.createButton);
            this.teamBox.Controls.Add(this.inviteButton);
            this.teamBox.Controls.Add(this.quitButton);
            this.teamBox.Controls.Add(this.disbandButton);
            this.teamBox.Controls.Add(this.forceAttackButton);
            this.teamBox.Controls.Add(this.attackButton);
            this.teamBox.Controls.Add(this.joinX10Button);
            this.teamBox.Controls.Add(this.teamList);
            this.teamBox.Controls.Add(this.armyNumLabel);
            this.teamBox.Controls.Add(this.playerNumLabel);
            this.teamBox.Controls.Add(this.baseHonorLabel);
            this.teamBox.Location = new System.Drawing.Point(265, 40);
            this.teamBox.Name = "teamBox";
            this.teamBox.Size = new System.Drawing.Size(360, 285);
            this.teamBox.TabIndex = 21;
            this.teamBox.TabStop = false;
            this.teamBox.Text = "Danh sách tổ đội";
            // 
            // createLegionButton
            // 
            this.createLegionButton.Location = new System.Drawing.Point(270, 210);
            this.createLegionButton.Name = "createLegionButton";
            this.createLegionButton.Size = new System.Drawing.Size(80, 30);
            this.createLegionButton.TabIndex = 30;
            this.createLegionButton.Text = "Lập bang";
            this.createLegionButton.UseVisualStyleBackColor = true;
            this.createLegionButton.Click += new System.EventHandler(this.createLegionButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(185, 210);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(80, 30);
            this.createButton.TabIndex = 29;
            this.createButton.Text = "Lập tổ đội";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // inviteButton
            // 
            this.inviteButton.Enabled = false;
            this.inviteButton.Location = new System.Drawing.Point(10, 245);
            this.inviteButton.Name = "inviteButton";
            this.inviteButton.Size = new System.Drawing.Size(80, 30);
            this.inviteButton.TabIndex = 28;
            this.inviteButton.Text = "Mời";
            this.inviteButton.UseVisualStyleBackColor = true;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(95, 245);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(80, 30);
            this.quitButton.TabIndex = 27;
            this.quitButton.Text = "Thoát";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // disbandButton
            // 
            this.disbandButton.Location = new System.Drawing.Point(95, 210);
            this.disbandButton.Name = "disbandButton";
            this.disbandButton.Size = new System.Drawing.Size(80, 30);
            this.disbandButton.TabIndex = 26;
            this.disbandButton.Text = "Giải tán";
            this.disbandButton.UseVisualStyleBackColor = true;
            this.disbandButton.Click += new System.EventHandler(this.disbandButton_Click);
            // 
            // forceAttackButton
            // 
            this.forceAttackButton.Location = new System.Drawing.Point(185, 245);
            this.forceAttackButton.Name = "forceAttackButton";
            this.forceAttackButton.Size = new System.Drawing.Size(80, 30);
            this.forceAttackButton.TabIndex = 25;
            this.forceAttackButton.Text = "Ép tấn công";
            this.forceAttackButton.UseVisualStyleBackColor = true;
            this.forceAttackButton.Click += new System.EventHandler(this.forceAttackButton_Click);
            // 
            // attackButton
            // 
            this.attackButton.Location = new System.Drawing.Point(10, 210);
            this.attackButton.Name = "attackButton";
            this.attackButton.Size = new System.Drawing.Size(80, 30);
            this.attackButton.TabIndex = 24;
            this.attackButton.Text = "Tấn công";
            this.attackButton.UseVisualStyleBackColor = true;
            this.attackButton.Click += new System.EventHandler(this.attackButton_Click);
            // 
            // joinX10Button
            // 
            this.joinX10Button.Location = new System.Drawing.Point(270, 245);
            this.joinX10Button.Name = "joinX10Button";
            this.joinX10Button.Size = new System.Drawing.Size(80, 30);
            this.joinX10Button.TabIndex = 23;
            this.joinX10Button.Text = "Gia nhập x10";
            this.joinX10Button.UseVisualStyleBackColor = true;
            this.joinX10Button.Click += new System.EventHandler(this.joinX10Button_Click);
            // 
            // teamList
            // 
            this.teamList.AllColumns.Add(this.teamColumn);
            this.teamList.AllColumns.Add(this.joinColumn);
            this.teamList.CellEditUseWholeCell = false;
            this.teamList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.teamColumn,
            this.joinColumn});
            this.teamList.Cursor = System.Windows.Forms.Cursors.Default;
            this.teamList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.teamList.Location = new System.Drawing.Point(10, 40);
            this.teamList.MultiSelect = false;
            this.teamList.Name = "teamList";
            this.teamList.ShowGroups = false;
            this.teamList.Size = new System.Drawing.Size(340, 160);
            this.teamList.TabIndex = 22;
            this.teamList.UseCompatibleStateImageBehavior = false;
            this.teamList.View = System.Windows.Forms.View.Details;
            this.teamList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.teamList_ButtonClick);
            this.teamList.SelectedIndexChanged += new System.EventHandler(this.teamList_SelectedIndexChanged);
            // 
            // teamColumn
            // 
            this.teamColumn.AspectName = "Description";
            this.teamColumn.Width = 260;
            // 
            // joinColumn
            // 
            this.joinColumn.AspectName = "Name";
            this.joinColumn.AspectToStringFormat = "Gia nhập";
            this.joinColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.joinColumn.IsButton = true;
            this.joinColumn.Width = 55;
            // 
            // memberList
            // 
            this.memberList.AllColumns.Add(this.memberColumn);
            this.memberList.AllColumns.Add(this.kickColumn);
            this.memberList.AllColumns.Add(this.moveUpColumn);
            this.memberList.AllColumns.Add(this.moveDownColumn);
            this.memberList.CellEditUseWholeCell = false;
            this.memberList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.memberColumn,
            this.kickColumn,
            this.moveUpColumn,
            this.moveDownColumn});
            this.memberList.Cursor = System.Windows.Forms.Cursors.Default;
            this.memberList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.memberList.Location = new System.Drawing.Point(10, 20);
            this.memberList.MultiSelect = false;
            this.memberList.Name = "memberList";
            this.memberList.ShowGroups = false;
            this.memberList.Size = new System.Drawing.Size(340, 140);
            this.memberList.TabIndex = 22;
            this.memberList.UseCompatibleStateImageBehavior = false;
            this.memberList.View = System.Windows.Forms.View.Details;
            this.memberList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.memberList_ButtonClick);
            // 
            // memberColumn
            // 
            this.memberColumn.AspectName = "Description";
            this.memberColumn.Width = 200;
            // 
            // kickColumn
            // 
            this.kickColumn.AspectName = "Name";
            this.kickColumn.AspectToStringFormat = "KICK";
            this.kickColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.kickColumn.IsButton = true;
            this.kickColumn.Width = 55;
            // 
            // moveUpColumn
            // 
            this.moveUpColumn.AspectName = "Name";
            this.moveUpColumn.AspectToStringFormat = "▲";
            this.moveUpColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.moveUpColumn.IsButton = true;
            this.moveUpColumn.Width = 30;
            // 
            // moveDownColumn
            // 
            this.moveDownColumn.AspectName = "Name";
            this.moveDownColumn.AspectToStringFormat = "▼";
            this.moveDownColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.moveDownColumn.IsButton = true;
            this.moveDownColumn.Width = 30;
            // 
            // memberBox
            // 
            this.memberBox.Controls.Add(this.memberList);
            this.memberBox.Location = new System.Drawing.Point(265, 335);
            this.memberBox.Name = "memberBox";
            this.memberBox.Size = new System.Drawing.Size(360, 170);
            this.memberBox.TabIndex = 23;
            this.memberBox.TabStop = false;
            this.memberBox.Text = "Danh sách thành viên tổ đội";
            // 
            // autoRefreshTeamBox
            // 
            this.autoRefreshTeamBox.AutoSize = true;
            this.autoRefreshTeamBox.Location = new System.Drawing.Point(380, 12);
            this.autoRefreshTeamBox.Name = "autoRefreshTeamBox";
            this.autoRefreshTeamBox.Size = new System.Drawing.Size(157, 17);
            this.autoRefreshTeamBox.TabIndex = 24;
            this.autoRefreshTeamBox.Text = "Tự động làm mới tổ đội (ms)";
            this.autoRefreshTeamBox.UseVisualStyleBackColor = true;
            this.autoRefreshTeamBox.CheckedChanged += new System.EventHandler(this.autoRefreshTeamBox_CheckedChanged);
            // 
            // refreshTeamInterval
            // 
            this.refreshTeamInterval.Location = new System.Drawing.Point(550, 11);
            this.refreshTeamInterval.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.refreshTeamInterval.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.refreshTeamInterval.Name = "refreshTeamInterval";
            this.refreshTeamInterval.Size = new System.Drawing.Size(60, 20);
            this.refreshTeamInterval.TabIndex = 26;
            this.refreshTeamInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.refreshTeamInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.refreshTeamInterval.ValueChanged += new System.EventHandler(this.refreshTeamInterval_ValueChanged);
            // 
            // ArmyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refreshTeamInterval);
            this.Controls.Add(this.autoRefreshTeamBox);
            this.Controls.Add(this.memberBox);
            this.Controls.Add(this.teamBox);
            this.Controls.Add(this.refreshTeamButton);
            this.Controls.Add(this.armyInfoBox);
            this.Controls.Add(this.refreshArmyButton);
            this.Controls.Add(this.armyList);
            this.Name = "ArmyView";
            this.Size = new System.Drawing.Size(673, 538);
            this.armyInfoBox.ResumeLayout(false);
            this.armyInfoBox.PerformLayout();
            this.teamBox.ResumeLayout(false);
            this.teamBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberList)).EndInit();
            this.memberBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.refreshTeamInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox armyList;
        private System.Windows.Forms.Button refreshArmyButton;
        private System.Windows.Forms.Timer refreshTeamTimer;
        private System.Windows.Forms.GroupBox armyInfoBox;
        private System.Windows.Forms.Label playerNumLabel;
        private System.Windows.Forms.Label armyNumLabel;
        private System.Windows.Forms.Label honorLabel;
        private System.Windows.Forms.Label baseHonorLabel;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.Label _ignore0;
        private System.Windows.Forms.TextBox itemLabel;
        private System.Windows.Forms.Button refreshTeamButton;
        private System.Windows.Forms.GroupBox teamBox;
        private BrightIdeasSoftware.ObjectListView teamList;
        private BrightIdeasSoftware.OLVColumn teamColumn;
        private BrightIdeasSoftware.OLVColumn joinColumn;
        private System.Windows.Forms.Button joinX10Button;
        private System.Windows.Forms.Button forceAttackButton;
        private System.Windows.Forms.Button attackButton;
        private System.Windows.Forms.Button disbandButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button inviteButton;
        private BrightIdeasSoftware.ObjectListView memberList;
        private BrightIdeasSoftware.OLVColumn memberColumn;
        private BrightIdeasSoftware.OLVColumn kickColumn;
        private System.Windows.Forms.Button createLegionButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.GroupBox memberBox;
        private BrightIdeasSoftware.OLVColumn moveUpColumn;
        private BrightIdeasSoftware.OLVColumn moveDownColumn;
        private System.Windows.Forms.CheckBox autoRefreshTeamBox;
        private System.Windows.Forms.NumericUpDown refreshTeamInterval;
    }
}
