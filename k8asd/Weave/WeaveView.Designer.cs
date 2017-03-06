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
            System.Windows.Forms.Label noteLabel;
            System.Windows.Forms.TabPage interfaceTab;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            this.refreshTeamButton = new System.Windows.Forms.Button();
            this.memberBox = new System.Windows.Forms.GroupBox();
            this.teamLevelLabel = new System.Windows.Forms.Label();
            this.teamRateLabel = new System.Windows.Forms.Label();
            this.teamPriceLabel = new System.Windows.Forms.Label();
            this.memberList = new BrightIdeasSoftware.ObjectListView();
            this.memberColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.kickColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.baseInfoBox = new System.Windows.Forms.GroupBox();
            this.spinnerRateLabel = new System.Windows.Forms.Label();
            this.numLabel = new System.Windows.Forms.Label();
            this.spinnerLevelLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.teamBox = new System.Windows.Forms.GroupBox();
            this.textileLevelInput = new System.Windows.Forms.NumericUpDown();
            this.quitAndMakeButton = new System.Windows.Forms.Button();
            this.createLegionButton = new System.Windows.Forms.Button();
            this.createNationButton = new System.Windows.Forms.Button();
            this.inviteButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.disbandButton = new System.Windows.Forms.Button();
            this.makeButton = new System.Windows.Forms.Button();
            this.teamList = new BrightIdeasSoftware.ObjectListView();
            this.teamColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.joinColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.refreshTeamInterval = new System.Windows.Forms.NumericUpDown();
            this.autoRefreshTeamBox = new System.Windows.Forms.CheckBox();
            this.autoTextileLevelInput = new System.Windows.Forms.NumericUpDown();
            this.refreshTeamTimer = new System.Windows.Forms.Timer(this.components);
            this.autoQuitAndMake = new System.Windows.Forms.CheckBox();
            this.autoCreate = new System.Windows.Forms.CheckBox();
            this.autoMake = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.configTab = new System.Windows.Forms.TabPage();
            this.slot2PlayerInput = new System.Windows.Forms.TextBox();
            this.slot1PlayerInput = new System.Windows.Forms.TextBox();
            this.textilePriceInput = new System.Windows.Forms.NumericUpDown();
            noteLabel = new System.Windows.Forms.Label();
            interfaceTab = new System.Windows.Forms.TabPage();
            label4 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            interfaceTab.SuspendLayout();
            this.memberBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberList)).BeginInit();
            this.baseInfoBox.SuspendLayout();
            this.teamBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textileLevelInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshTeamInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoTextileLevelInput)).BeginInit();
            this.tabControl.SuspendLayout();
            this.configTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textilePriceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(15, 120);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(172, 39);
            noteLabel.TabIndex = 35;
            noteLabel.Text = "Chú ý: nếu tích cả 2 ô trên thì:\r\n- Dệt chung khi còn >1 lượt.\r\n- Thoát và dệt kh" +
    "i còn đúng 1 lượt.";
            // 
            // interfaceTab
            // 
            interfaceTab.Controls.Add(this.refreshTeamButton);
            interfaceTab.Controls.Add(this.memberBox);
            interfaceTab.Controls.Add(this.baseInfoBox);
            interfaceTab.Controls.Add(this.teamBox);
            interfaceTab.Controls.Add(this.refreshTeamInterval);
            interfaceTab.Controls.Add(this.autoRefreshTeamBox);
            interfaceTab.Location = new System.Drawing.Point(4, 22);
            interfaceTab.Name = "interfaceTab";
            interfaceTab.Padding = new System.Windows.Forms.Padding(3);
            interfaceTab.Size = new System.Drawing.Size(402, 464);
            interfaceTab.TabIndex = 0;
            interfaceTab.Text = "Giao diện";
            interfaceTab.UseVisualStyleBackColor = true;
            // 
            // refreshTeamButton
            // 
            this.refreshTeamButton.Location = new System.Drawing.Point(10, 10);
            this.refreshTeamButton.Name = "refreshTeamButton";
            this.refreshTeamButton.Size = new System.Drawing.Size(100, 30);
            this.refreshTeamButton.TabIndex = 27;
            this.refreshTeamButton.Text = "Làm mới tổ đội";
            this.refreshTeamButton.UseVisualStyleBackColor = true;
            this.refreshTeamButton.Click += new System.EventHandler(this.refreshTeamButton_Click);
            // 
            // memberBox
            // 
            this.memberBox.Controls.Add(this.teamLevelLabel);
            this.memberBox.Controls.Add(this.teamRateLabel);
            this.memberBox.Controls.Add(this.teamPriceLabel);
            this.memberBox.Controls.Add(this.memberList);
            this.memberBox.Location = new System.Drawing.Point(10, 340);
            this.memberBox.Name = "memberBox";
            this.memberBox.Size = new System.Drawing.Size(380, 115);
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
            this.memberList.Location = new System.Drawing.Point(10, 40);
            this.memberList.MultiSelect = false;
            this.memberList.Name = "memberList";
            this.memberList.ShowGroups = false;
            this.memberList.Size = new System.Drawing.Size(360, 64);
            this.memberList.TabIndex = 22;
            this.memberList.UseCompatibleStateImageBehavior = false;
            this.memberList.View = System.Windows.Forms.View.Details;
            this.memberList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.memberList_ButtonClick);
            // 
            // memberColumn
            // 
            this.memberColumn.AspectName = "";
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
            // baseInfoBox
            // 
            this.baseInfoBox.Controls.Add(this.spinnerRateLabel);
            this.baseInfoBox.Controls.Add(this.numLabel);
            this.baseInfoBox.Controls.Add(this.spinnerLevelLabel);
            this.baseInfoBox.Controls.Add(this.priceLabel);
            this.baseInfoBox.Location = new System.Drawing.Point(10, 45);
            this.baseInfoBox.Name = "baseInfoBox";
            this.baseInfoBox.Size = new System.Drawing.Size(380, 45);
            this.baseInfoBox.TabIndex = 31;
            this.baseInfoBox.TabStop = false;
            this.baseInfoBox.Text = "Thông tin cơ bản";
            // 
            // spinnerRateLabel
            // 
            this.spinnerRateLabel.AutoSize = true;
            this.spinnerRateLabel.Location = new System.Drawing.Point(115, 20);
            this.spinnerRateLabel.Name = "spinnerRateLabel";
            this.spinnerRateLabel.Size = new System.Drawing.Size(54, 13);
            this.spinnerRateLabel.TabIndex = 16;
            this.spinnerRateLabel.Text = "Tỉ lệ: 5 - 5";
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
            this.priceLabel.Location = new System.Drawing.Point(180, 20);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(107, 13);
            this.priceLabel.TabIndex = 13;
            this.priceLabel.Text = "Giá bán: 107 ▲ (Lên)";
            // 
            // teamBox
            // 
            this.teamBox.Controls.Add(this.textileLevelInput);
            this.teamBox.Controls.Add(label4);
            this.teamBox.Controls.Add(this.quitAndMakeButton);
            this.teamBox.Controls.Add(this.createLegionButton);
            this.teamBox.Controls.Add(this.createNationButton);
            this.teamBox.Controls.Add(this.inviteButton);
            this.teamBox.Controls.Add(this.quitButton);
            this.teamBox.Controls.Add(this.disbandButton);
            this.teamBox.Controls.Add(this.makeButton);
            this.teamBox.Controls.Add(this.teamList);
            this.teamBox.Location = new System.Drawing.Point(10, 95);
            this.teamBox.Name = "teamBox";
            this.teamBox.Size = new System.Drawing.Size(380, 235);
            this.teamBox.TabIndex = 28;
            this.teamBox.TabStop = false;
            this.teamBox.Text = "Danh sách tổ đội";
            // 
            // textileLevelInput
            // 
            this.textileLevelInput.Location = new System.Drawing.Point(319, 205);
            this.textileLevelInput.Name = "textileLevelInput";
            this.textileLevelInput.Size = new System.Drawing.Size(50, 20);
            this.textileLevelInput.TabIndex = 33;
            this.textileLevelInput.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(185, 207);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(120, 13);
            label4.TabIndex = 32;
            label4.Text = "Lập tổ đội dùng cấp vải";
            // 
            // quitAndMakeButton
            // 
            this.quitAndMakeButton.Location = new System.Drawing.Point(265, 165);
            this.quitAndMakeButton.Name = "quitAndMakeButton";
            this.quitAndMakeButton.Size = new System.Drawing.Size(105, 30);
            this.quitAndMakeButton.TabIndex = 31;
            this.quitAndMakeButton.Text = "Thoát và chế tạo";
            this.quitAndMakeButton.UseVisualStyleBackColor = true;
            this.quitAndMakeButton.Click += new System.EventHandler(this.quitAndMakeButton_Click);
            // 
            // createLegionButton
            // 
            this.createLegionButton.Location = new System.Drawing.Point(95, 198);
            this.createLegionButton.Name = "createLegionButton";
            this.createLegionButton.Size = new System.Drawing.Size(80, 30);
            this.createLegionButton.TabIndex = 30;
            this.createLegionButton.Text = "Lập bang";
            this.createLegionButton.UseVisualStyleBackColor = true;
            this.createLegionButton.Click += new System.EventHandler(this.createLegionButton_Click);
            // 
            // createNationButton
            // 
            this.createNationButton.Location = new System.Drawing.Point(10, 198);
            this.createNationButton.Name = "createNationButton";
            this.createNationButton.Size = new System.Drawing.Size(80, 30);
            this.createNationButton.TabIndex = 29;
            this.createNationButton.Text = "Lập quốc gia";
            this.createNationButton.UseVisualStyleBackColor = true;
            this.createNationButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // inviteButton
            // 
            this.inviteButton.Enabled = false;
            this.inviteButton.Location = new System.Drawing.Point(10, 200);
            this.inviteButton.Name = "inviteButton";
            this.inviteButton.Size = new System.Drawing.Size(0, 0);
            this.inviteButton.TabIndex = 28;
            this.inviteButton.Text = "Mời";
            this.inviteButton.UseVisualStyleBackColor = true;
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(180, 165);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(80, 30);
            this.quitButton.TabIndex = 27;
            this.quitButton.Text = "Thoát";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // disbandButton
            // 
            this.disbandButton.Location = new System.Drawing.Point(95, 165);
            this.disbandButton.Name = "disbandButton";
            this.disbandButton.Size = new System.Drawing.Size(80, 30);
            this.disbandButton.TabIndex = 26;
            this.disbandButton.Text = "Giải tán";
            this.disbandButton.UseVisualStyleBackColor = true;
            this.disbandButton.Click += new System.EventHandler(this.disbandButton_Click);
            // 
            // makeButton
            // 
            this.makeButton.Location = new System.Drawing.Point(10, 165);
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
            this.teamList.Size = new System.Drawing.Size(360, 140);
            this.teamList.TabIndex = 22;
            this.teamList.UseCompatibleStateImageBehavior = false;
            this.teamList.View = System.Windows.Forms.View.Details;
            this.teamList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.teamList_ButtonClick);
            // 
            // teamColumn
            // 
            this.teamColumn.AspectName = "";
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
            // refreshTeamInterval
            // 
            this.refreshTeamInterval.Location = new System.Drawing.Point(285, 16);
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
            this.autoRefreshTeamBox.Location = new System.Drawing.Point(125, 17);
            this.autoRefreshTeamBox.Name = "autoRefreshTeamBox";
            this.autoRefreshTeamBox.Size = new System.Drawing.Size(157, 17);
            this.autoRefreshTeamBox.TabIndex = 30;
            this.autoRefreshTeamBox.Text = "Tự động làm mới tổ đội (ms)";
            this.autoRefreshTeamBox.UseVisualStyleBackColor = true;
            this.autoRefreshTeamBox.CheckedChanged += new System.EventHandler(this.autoRefreshTeamBox_CheckedChanged);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 250);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(259, 52);
            label1.TabIndex = 39;
            label1.Text = "Chú ý:\r\n- Để trống thì ai vào cũng được.\r\n- Nhập đúng tên kể cả chữ viết hoa viết" +
    " thường.\r\n- Những ai không đủ điều kiện thì sẽ bị kick ra tổ đội.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(30, 200);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 40;
            label2.Text = "- Slot 1:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(30, 225);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 13);
            label3.TabIndex = 41;
            label3.Text = "- Slot 2:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(15, 175);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(237, 13);
            label5.TabIndex = 43;
            label5.Text = "Chỉ dệt khi có những người chơi sau trong tổ đội:";
            // 
            // autoTextileLevelInput
            // 
            this.autoTextileLevelInput.Location = new System.Drawing.Point(210, 14);
            this.autoTextileLevelInput.Name = "autoTextileLevelInput";
            this.autoTextileLevelInput.Size = new System.Drawing.Size(50, 20);
            this.autoTextileLevelInput.TabIndex = 31;
            this.autoTextileLevelInput.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // refreshTeamTimer
            // 
            this.refreshTeamTimer.Enabled = true;
            this.refreshTeamTimer.Interval = 1000;
            this.refreshTeamTimer.Tick += new System.EventHandler(this.refreshTeamTimer_Tick);
            // 
            // autoQuitAndMake
            // 
            this.autoQuitAndMake.AutoSize = true;
            this.autoQuitAndMake.Location = new System.Drawing.Point(15, 85);
            this.autoQuitAndMake.Name = "autoQuitAndMake";
            this.autoQuitAndMake.Size = new System.Drawing.Size(250, 17);
            this.autoQuitAndMake.TabIndex = 32;
            this.autoQuitAndMake.Text = "Tự thoát và dệt khi có 3 người (chế độ kéo vải)";
            this.autoQuitAndMake.UseVisualStyleBackColor = true;
            // 
            // autoCreate
            // 
            this.autoCreate.AutoSize = true;
            this.autoCreate.Location = new System.Drawing.Point(15, 15);
            this.autoCreate.Name = "autoCreate";
            this.autoCreate.Size = new System.Drawing.Size(192, 17);
            this.autoCreate.TabIndex = 33;
            this.autoCreate.Text = "Tự lập tổ đội bang sử dụng cấp vải";
            this.autoCreate.UseVisualStyleBackColor = true;
            // 
            // autoMake
            // 
            this.autoMake.AutoSize = true;
            this.autoMake.Location = new System.Drawing.Point(15, 50);
            this.autoMake.Name = "autoMake";
            this.autoMake.Size = new System.Drawing.Size(192, 17);
            this.autoMake.TabIndex = 34;
            this.autoMake.Text = "Tự dệt khi có 3 người và giá dệt >=";
            this.autoMake.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(interfaceTab);
            this.tabControl.Controls.Add(this.configTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(410, 490);
            this.tabControl.TabIndex = 35;
            // 
            // configTab
            // 
            this.configTab.Controls.Add(label5);
            this.configTab.Controls.Add(this.slot2PlayerInput);
            this.configTab.Controls.Add(label3);
            this.configTab.Controls.Add(label2);
            this.configTab.Controls.Add(label1);
            this.configTab.Controls.Add(this.slot1PlayerInput);
            this.configTab.Controls.Add(this.textilePriceInput);
            this.configTab.Controls.Add(noteLabel);
            this.configTab.Controls.Add(this.autoTextileLevelInput);
            this.configTab.Controls.Add(this.autoQuitAndMake);
            this.configTab.Controls.Add(this.autoMake);
            this.configTab.Controls.Add(this.autoCreate);
            this.configTab.Location = new System.Drawing.Point(4, 22);
            this.configTab.Name = "configTab";
            this.configTab.Padding = new System.Windows.Forms.Padding(3);
            this.configTab.Size = new System.Drawing.Size(402, 464);
            this.configTab.TabIndex = 1;
            this.configTab.Text = "Cấu hình";
            this.configTab.UseVisualStyleBackColor = true;
            // 
            // slot2PlayerInput
            // 
            this.slot2PlayerInput.Location = new System.Drawing.Point(80, 222);
            this.slot2PlayerInput.Name = "slot2PlayerInput";
            this.slot2PlayerInput.Size = new System.Drawing.Size(280, 20);
            this.slot2PlayerInput.TabIndex = 42;
            // 
            // slot1PlayerInput
            // 
            this.slot1PlayerInput.Location = new System.Drawing.Point(80, 197);
            this.slot1PlayerInput.Name = "slot1PlayerInput";
            this.slot1PlayerInput.Size = new System.Drawing.Size(280, 20);
            this.slot1PlayerInput.TabIndex = 38;
            // 
            // textilePriceInput
            // 
            this.textilePriceInput.Location = new System.Drawing.Point(210, 49);
            this.textilePriceInput.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.textilePriceInput.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.textilePriceInput.Name = "textilePriceInput";
            this.textilePriceInput.Size = new System.Drawing.Size(50, 20);
            this.textilePriceInput.TabIndex = 36;
            this.textilePriceInput.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // WeaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "WeaveView";
            this.Size = new System.Drawing.Size(410, 490);
            interfaceTab.ResumeLayout(false);
            interfaceTab.PerformLayout();
            this.memberBox.ResumeLayout(false);
            this.memberBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memberList)).EndInit();
            this.baseInfoBox.ResumeLayout(false);
            this.baseInfoBox.PerformLayout();
            this.teamBox.ResumeLayout(false);
            this.teamBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textileLevelInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teamList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshTeamInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoTextileLevelInput)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.configTab.ResumeLayout(false);
            this.configTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textilePriceInput)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button createNationButton;
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
        private System.Windows.Forms.NumericUpDown autoTextileLevelInput;
        private System.Windows.Forms.CheckBox autoQuitAndMake;
        private System.Windows.Forms.CheckBox autoCreate;
        private System.Windows.Forms.CheckBox autoMake;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage configTab;
        private System.Windows.Forms.NumericUpDown textilePriceInput;
        private System.Windows.Forms.TextBox slot1PlayerInput;
        private System.Windows.Forms.TextBox slot2PlayerInput;
        private System.Windows.Forms.Button quitAndMakeButton;
        private System.Windows.Forms.NumericUpDown textileLevelInput;
    }
}
