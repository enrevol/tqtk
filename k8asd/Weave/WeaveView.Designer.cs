namespace k8asd {
    partial class WeaveView {
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
            this.refreshTeamInterval = new System.Windows.Forms.NumericUpDown();
            this.autoRefreshTeamBox = new System.Windows.Forms.CheckBox();
            this.memberBox = new System.Windows.Forms.GroupBox();
            this.teamLevelLabel = new System.Windows.Forms.Label();
            this.teamRateLabel = new System.Windows.Forms.Label();
            this.teamPriceLabel = new System.Windows.Forms.Label();
            this.memberList = new BrightIdeasSoftware.ObjectListView();
            this.memberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.kickColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.teamBox = new System.Windows.Forms.GroupBox();
            this.createLegionButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.inviteButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.disbandButton = new System.Windows.Forms.Button();
            this.makeButton = new System.Windows.Forms.Button();
            this.teamList = new BrightIdeasSoftware.ObjectListView();
            this.teamColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.joinColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.refreshTeamButton = new System.Windows.Forms.Button();
            this.refreshTeamTimer = new System.Windows.Forms.Timer(this.components);
            this.spinnerLevelLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.numLabel = new System.Windows.Forms.Label();
            this.baseInfoBox = new System.Windows.Forms.GroupBox();
            this.spinnerRateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.refreshTeamInterval)).BeginInit();
            this.memberBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberList)).BeginInit();
            this.teamBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.teamList)).BeginInit();
            this.baseInfoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshTeamInterval
            // 
            this.refreshTeamInterval.Location = new System.Drawing.Point(280, 11);
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
            this.refreshTeamInterval.TabIndex = 31;
            this.refreshTeamInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.refreshTeamInterval.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.refreshTeamInterval.ValueChanged += new System.EventHandler(this.refreshTeamInterval_ValueChanged);
            // 
            // autoRefreshTeamBox
            // 
            this.autoRefreshTeamBox.AutoSize = true;
            this.autoRefreshTeamBox.Location = new System.Drawing.Point(120, 12);
            this.autoRefreshTeamBox.Name = "autoRefreshTeamBox";
            this.autoRefreshTeamBox.Size = new System.Drawing.Size(157, 17);
            this.autoRefreshTeamBox.TabIndex = 30;
            this.autoRefreshTeamBox.Text = "Tự động làm mới tổ đội (ms)";
            this.autoRefreshTeamBox.UseVisualStyleBackColor = true;
            this.autoRefreshTeamBox.CheckedChanged += new System.EventHandler(this.autoRefreshTeamBox_CheckedChanged);
            // 
            // memberBox
            // 
            this.memberBox.Controls.Add(this.teamLevelLabel);
            this.memberBox.Controls.Add(this.teamRateLabel);
            this.memberBox.Controls.Add(this.teamPriceLabel);
            this.memberBox.Controls.Add(this.memberList);
            this.memberBox.Location = new System.Drawing.Point(5, 356);
            this.memberBox.Name = "memberBox";
            this.memberBox.Size = new System.Drawing.Size(360, 126);
            this.memberBox.TabIndex = 29;
            this.memberBox.TabStop = false;
            this.memberBox.Text = "Danh sách thành viên tổ đội";
            // 
            // teamLevelLabel
            // 
            this.teamLevelLabel.AutoSize = true;
            this.teamLevelLabel.Location = new System.Drawing.Point(8, 20);
            this.teamLevelLabel.Name = "teamLevelLabel";
            this.teamLevelLabel.Size = new System.Drawing.Size(44, 13);
            this.teamLevelLabel.TabIndex = 24;
            this.teamLevelLabel.Text = "Cấp: 22";
            // 
            // teamRateLabel
            // 
            this.teamRateLabel.AutoSize = true;
            this.teamRateLabel.Location = new System.Drawing.Point(180, 20);
            this.teamRateLabel.Name = "teamRateLabel";
            this.teamRateLabel.Size = new System.Drawing.Size(88, 13);
            this.teamRateLabel.TabIndex = 23;
            this.teamRateLabel.Text = "Tỉ lệ: 101% - 20%";
            // 
            // teamPriceLabel
            // 
            this.teamPriceLabel.AutoSize = true;
            this.teamPriceLabel.Location = new System.Drawing.Point(70, 20);
            this.teamPriceLabel.Name = "teamPriceLabel";
            this.teamPriceLabel.Size = new System.Drawing.Size(80, 13);
            this.teamPriceLabel.TabIndex = 18;
            this.teamPriceLabel.Text = "Giá: 870 - 4350";
            // 
            // memberList
            // 
            this.memberList.AllColumns.Add(this.memberColumn);
            this.memberList.AllColumns.Add(this.kickColumn);
            this.memberList.CellEditUseWholeCell = false;
            this.memberList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.memberColumn,
            this.kickColumn});
            this.memberList.Cursor = System.Windows.Forms.Cursors.Default;
            this.memberList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.memberList.Location = new System.Drawing.Point(10, 50);
            this.memberList.MultiSelect = false;
            this.memberList.Name = "memberList";
            this.memberList.ShowGroups = false;
            this.memberList.Size = new System.Drawing.Size(340, 64);
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
            // teamBox
            // 
            this.teamBox.Controls.Add(this.createLegionButton);
            this.teamBox.Controls.Add(this.createButton);
            this.teamBox.Controls.Add(this.inviteButton);
            this.teamBox.Controls.Add(this.quitButton);
            this.teamBox.Controls.Add(this.disbandButton);
            this.teamBox.Controls.Add(this.makeButton);
            this.teamBox.Controls.Add(this.teamList);
            this.teamBox.Location = new System.Drawing.Point(5, 90);
            this.teamBox.Name = "teamBox";
            this.teamBox.Size = new System.Drawing.Size(380, 240);
            this.teamBox.TabIndex = 28;
            this.teamBox.TabStop = false;
            this.teamBox.Text = "Danh sách tổ đội";
            // 
            // createLegionButton
            // 
            this.createLegionButton.Location = new System.Drawing.Point(270, 171);
            this.createLegionButton.Name = "createLegionButton";
            this.createLegionButton.Size = new System.Drawing.Size(80, 30);
            this.createLegionButton.TabIndex = 30;
            this.createLegionButton.Text = "Lập bang";
            this.createLegionButton.UseVisualStyleBackColor = true;
            this.createLegionButton.Click += new System.EventHandler(this.createLegionButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(185, 171);
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
            this.inviteButton.Location = new System.Drawing.Point(10, 206);
            this.inviteButton.Name = "inviteButton";
            this.inviteButton.Size = new System.Drawing.Size(80, 30);
            this.inviteButton.TabIndex = 28;
            this.inviteButton.Text = "Mời";
            this.inviteButton.UseVisualStyleBackColor = true;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(95, 206);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(80, 30);
            this.quitButton.TabIndex = 27;
            this.quitButton.Text = "Thoát";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // disbandButton
            // 
            this.disbandButton.Location = new System.Drawing.Point(95, 171);
            this.disbandButton.Name = "disbandButton";
            this.disbandButton.Size = new System.Drawing.Size(80, 30);
            this.disbandButton.TabIndex = 26;
            this.disbandButton.Text = "Giải tán";
            this.disbandButton.UseVisualStyleBackColor = true;
            this.disbandButton.Click += new System.EventHandler(this.disbandButton_Click);
            // 
            // makeButton
            // 
            this.makeButton.Location = new System.Drawing.Point(10, 171);
            this.makeButton.Name = "makeButton";
            this.makeButton.Size = new System.Drawing.Size(80, 30);
            this.makeButton.TabIndex = 24;
            this.makeButton.Text = "Chế tạo";
            this.makeButton.UseVisualStyleBackColor = true;
            this.makeButton.Click += new System.EventHandler(this.makeButton_Click);
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
            this.teamList.Location = new System.Drawing.Point(10, 20);
            this.teamList.MultiSelect = false;
            this.teamList.Name = "teamList";
            this.teamList.ShowGroups = false;
            this.teamList.Size = new System.Drawing.Size(360, 145);
            this.teamList.TabIndex = 22;
            this.teamList.UseCompatibleStateImageBehavior = false;
            this.teamList.View = System.Windows.Forms.View.Details;
            this.teamList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.teamList_ButtonClick);
            this.teamList.SelectedIndexChanged += new System.EventHandler(this.teamList_SelectedIndexChanged);
            // 
            // teamColumn
            // 
            this.teamColumn.AspectName = "Description";
            this.teamColumn.Width = 280;
            // 
            // joinColumn
            // 
            this.joinColumn.AspectName = "Name";
            this.joinColumn.AspectToStringFormat = "Gia nhập";
            this.joinColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.joinColumn.IsButton = true;
            this.joinColumn.Width = 55;
            // 
            // refreshTeamButton
            // 
            this.refreshTeamButton.Location = new System.Drawing.Point(5, 5);
            this.refreshTeamButton.Name = "refreshTeamButton";
            this.refreshTeamButton.Size = new System.Drawing.Size(100, 30);
            this.refreshTeamButton.TabIndex = 27;
            this.refreshTeamButton.Text = "Làm mới tổ đội";
            this.refreshTeamButton.UseVisualStyleBackColor = true;
            this.refreshTeamButton.Click += new System.EventHandler(this.refreshTeamButton_Click);
            // 
            // refreshTeamTimer
            // 
            this.refreshTeamTimer.Enabled = true;
            this.refreshTeamTimer.Interval = 1000;
            this.refreshTeamTimer.Tick += new System.EventHandler(this.refreshTeamTimer_Tick);
            // 
            // spinnerLevelLabel
            // 
            this.spinnerLevelLabel.AutoSize = true;
            this.spinnerLevelLabel.Location = new System.Drawing.Point(8, 20);
            this.spinnerLevelLabel.Name = "spinnerLevelLabel";
            this.spinnerLevelLabel.Size = new System.Drawing.Size(95, 13);
            this.spinnerLevelLabel.TabIndex = 15;
            this.spinnerLevelLabel.Text = "Công nhân: Lv. 18";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(190, 20);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(107, 13);
            this.priceLabel.TabIndex = 13;
            this.priceLabel.Text = "Giá bán: 107 ▲ (Lên)";
            // 
            // numLabel
            // 
            this.numLabel.AutoSize = true;
            this.numLabel.Location = new System.Drawing.Point(310, 20);
            this.numLabel.Name = "numLabel";
            this.numLabel.Size = new System.Drawing.Size(63, 13);
            this.numLabel.TabIndex = 14;
            this.numLabel.Text = "Lượt: 10/10";
            // 
            // baseInfoBox
            // 
            this.baseInfoBox.Controls.Add(this.spinnerRateLabel);
            this.baseInfoBox.Controls.Add(this.numLabel);
            this.baseInfoBox.Controls.Add(this.spinnerLevelLabel);
            this.baseInfoBox.Controls.Add(this.priceLabel);
            this.baseInfoBox.Location = new System.Drawing.Point(5, 40);
            this.baseInfoBox.Name = "baseInfoBox";
            this.baseInfoBox.Size = new System.Drawing.Size(380, 45);
            this.baseInfoBox.TabIndex = 31;
            this.baseInfoBox.TabStop = false;
            this.baseInfoBox.Text = "Thông tin cơ bản";
            // 
            // spinnerRateLabel
            // 
            this.spinnerRateLabel.AutoSize = true;
            this.spinnerRateLabel.Location = new System.Drawing.Point(120, 20);
            this.spinnerRateLabel.Name = "spinnerRateLabel";
            this.spinnerRateLabel.Size = new System.Drawing.Size(54, 13);
            this.spinnerRateLabel.TabIndex = 16;
            this.spinnerRateLabel.Text = "Tỉ lệ: 5 - 5";
            // 
            // WeaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseInfoBox);
            this.Controls.Add(this.refreshTeamInterval);
            this.Controls.Add(this.autoRefreshTeamBox);
            this.Controls.Add(this.teamBox);
            this.Controls.Add(this.refreshTeamButton);
            this.Controls.Add(this.memberBox);
            this.Name = "WeaveView";
            this.Size = new System.Drawing.Size(598, 596);
            ((System.ComponentModel.ISupportInitialize)(this.refreshTeamInterval)).EndInit();
            this.memberBox.ResumeLayout(false);
            this.memberBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberList)).EndInit();
            this.teamBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.teamList)).EndInit();
            this.baseInfoBox.ResumeLayout(false);
            this.baseInfoBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown refreshTeamInterval;
        private System.Windows.Forms.CheckBox autoRefreshTeamBox;
        private System.Windows.Forms.GroupBox memberBox;
        private BrightIdeasSoftware.ObjectListView memberList;
        private BrightIdeasSoftware.OLVColumn memberColumn;
        private BrightIdeasSoftware.OLVColumn kickColumn;
        private System.Windows.Forms.GroupBox teamBox;
        private System.Windows.Forms.Button createLegionButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button inviteButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button disbandButton;
        private System.Windows.Forms.Button makeButton;
        private BrightIdeasSoftware.ObjectListView teamList;
        private BrightIdeasSoftware.OLVColumn teamColumn;
        private System.Windows.Forms.Button refreshTeamButton;
        private System.Windows.Forms.Timer refreshTeamTimer;
        private System.Windows.Forms.Label spinnerLevelLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label numLabel;
        private System.Windows.Forms.GroupBox baseInfoBox;
        private System.Windows.Forms.Label spinnerRateLabel;
        private BrightIdeasSoftware.OLVColumn joinColumn;
        private System.Windows.Forms.Label teamPriceLabel;
        private System.Windows.Forms.Label teamRateLabel;
        private System.Windows.Forms.Label teamLevelLabel;
    }
}
