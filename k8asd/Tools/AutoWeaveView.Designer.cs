namespace k8asd {
    partial class AutoWeaveView {
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            this.playerList = new BrightIdeasSoftware.ObjectListView();
            this.spinnerLevelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.successRateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.criticalRateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.priceColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.turnColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cooldownColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.refreshButton = new System.Windows.Forms.Button();
            this.weaveTimer = new System.Windows.Forms.Timer(this.components);
            this.hostInput = new System.Windows.Forms.TextBox();
            this.autoWeave = new System.Windows.Forms.CheckBox();
            this.textileLevelInput = new System.Windows.Forms.NumericUpDown();
            this.autoMake = new System.Windows.Forms.CheckBox();
            this.logBox = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textileLevelInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(15, 55);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(56, 13);
            label1.TabIndex = 33;
            label1.Text = "Chủ tổ đội";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(185, 55);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 37;
            label2.Text = "Cấp vải";
            // 
            // playerList
            // 
            this.playerList.AllColumns.Add(this.spinnerLevelColumn);
            this.playerList.AllColumns.Add(this.successRateColumn);
            this.playerList.AllColumns.Add(this.criticalRateColumn);
            this.playerList.AllColumns.Add(this.priceColumn);
            this.playerList.AllColumns.Add(this.turnColumn);
            this.playerList.AllColumns.Add(this.nameColumn);
            this.playerList.AllColumns.Add(this.cooldownColumn);
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.CellEditUseWholeCell = false;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.spinnerLevelColumn,
            this.successRateColumn,
            this.criticalRateColumn,
            this.priceColumn,
            this.turnColumn,
            this.nameColumn,
            this.cooldownColumn});
            this.playerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerList.FullRowSelect = true;
            this.playerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playerList.Location = new System.Drawing.Point(10, 210);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.SelectColumnsOnRightClick = false;
            this.playerList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.playerList.ShowGroups = false;
            this.playerList.Size = new System.Drawing.Size(450, 240);
            this.playerList.TabIndex = 31;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            // 
            // spinnerLevelColumn
            // 
            this.spinnerLevelColumn.AspectName = "";
            this.spinnerLevelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinnerLevelColumn.MaximumWidth = 55;
            this.spinnerLevelColumn.MinimumWidth = 55;
            this.spinnerLevelColumn.Text = "C. Nhân";
            this.spinnerLevelColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.spinnerLevelColumn.Width = 55;
            // 
            // successRateColumn
            // 
            this.successRateColumn.AspectName = "";
            this.successRateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.successRateColumn.MaximumWidth = 55;
            this.successRateColumn.MinimumWidth = 55;
            this.successRateColumn.Text = "T. Công";
            this.successRateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.successRateColumn.Width = 55;
            // 
            // criticalRateColumn
            // 
            this.criticalRateColumn.AspectName = "";
            this.criticalRateColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.criticalRateColumn.MaximumWidth = 55;
            this.criticalRateColumn.MinimumWidth = 55;
            this.criticalRateColumn.Text = "B. Kích";
            this.criticalRateColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.criticalRateColumn.Width = 55;
            // 
            // priceColumn
            // 
            this.priceColumn.MaximumWidth = 40;
            this.priceColumn.MinimumWidth = 40;
            this.priceColumn.Text = "Giá";
            this.priceColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceColumn.Width = 40;
            // 
            // turnColumn
            // 
            this.turnColumn.MaximumWidth = 40;
            this.turnColumn.MinimumWidth = 40;
            this.turnColumn.Text = "Lượt";
            this.turnColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.turnColumn.Width = 40;
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "";
            this.nameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameColumn.MaximumWidth = 120;
            this.nameColumn.MinimumWidth = 120;
            this.nameColumn.Text = "Người chơi";
            this.nameColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameColumn.Width = 120;
            // 
            // cooldownColumn
            // 
            this.cooldownColumn.AspectName = "";
            this.cooldownColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cooldownColumn.MaximumWidth = 60;
            this.cooldownColumn.MinimumWidth = 60;
            this.cooldownColumn.Text = "Đ. băng";
            this.cooldownColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(10, 10);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 32;
            this.refreshButton.Text = "Làm mới dệt";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // weaveTimer
            // 
            this.weaveTimer.Interval = 1000;
            this.weaveTimer.Tick += new System.EventHandler(this.weaveTimer_Tick);
            // 
            // hostInput
            // 
            this.hostInput.Location = new System.Drawing.Point(85, 52);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(80, 20);
            this.hostInput.TabIndex = 34;
            this.hostInput.Text = "Zinge";
            // 
            // autoWeave
            // 
            this.autoWeave.AutoSize = true;
            this.autoWeave.Location = new System.Drawing.Point(130, 16);
            this.autoWeave.Name = "autoWeave";
            this.autoWeave.Size = new System.Drawing.Size(85, 17);
            this.autoWeave.TabIndex = 35;
            this.autoWeave.Text = "Tự động dệt";
            this.autoWeave.UseVisualStyleBackColor = true;
            // 
            // textileLevelInput
            // 
            this.textileLevelInput.Location = new System.Drawing.Point(235, 53);
            this.textileLevelInput.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.textileLevelInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textileLevelInput.Name = "textileLevelInput";
            this.textileLevelInput.Size = new System.Drawing.Size(50, 20);
            this.textileLevelInput.TabIndex = 38;
            this.textileLevelInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textileLevelInput.Value = new decimal(new int[] {
            21,
            0,
            0,
            0});
            // 
            // autoMake
            // 
            this.autoMake.AutoSize = true;
            this.autoMake.Location = new System.Drawing.Point(310, 54);
            this.autoMake.Name = "autoMake";
            this.autoMake.Size = new System.Drawing.Size(131, 17);
            this.autoMake.TabIndex = 40;
            this.autoMake.Text = "Dệt chung khi lượt > 1";
            this.autoMake.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(10, 80);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(450, 120);
            this.logBox.TabIndex = 41;
            // 
            // AutoWeaveView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 461);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.autoMake);
            this.Controls.Add(this.textileLevelInput);
            this.Controls.Add(label2);
            this.Controls.Add(this.autoWeave);
            this.Controls.Add(this.hostInput);
            this.Controls.Add(label1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.playerList);
            this.Name = "AutoWeaveView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoWeaveView";
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textileLevelInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView playerList;
        private BrightIdeasSoftware.OLVColumn spinnerLevelColumn;
        private BrightIdeasSoftware.OLVColumn successRateColumn;
        private BrightIdeasSoftware.OLVColumn cooldownColumn;
        private BrightIdeasSoftware.OLVColumn criticalRateColumn;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private System.Windows.Forms.Button refreshButton;
        private BrightIdeasSoftware.OLVColumn priceColumn;
        private BrightIdeasSoftware.OLVColumn turnColumn;
        private System.Windows.Forms.Timer weaveTimer;
        private System.Windows.Forms.TextBox hostInput;
        private System.Windows.Forms.CheckBox autoWeave;
        private System.Windows.Forms.NumericUpDown textileLevelInput;
        private System.Windows.Forms.CheckBox autoMake;
        private System.Windows.Forms.TextBox logBox;
    }
}
