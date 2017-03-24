namespace k8asd {
    partial class AutoSwap
    {
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
            System.Windows.Forms.Label label3;
            this.playerList = new BrightIdeasSoftware.ObjectListView();
            this.imposenum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.maximposenum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.cooldownColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.refreshButton = new System.Windows.Forms.Button();
            this.weaveTimer = new System.Windows.Forms.Timer(this.components);
            this.hostInput = new System.Windows.Forms.TextBox();
            this.autoWeave = new System.Windows.Forms.CheckBox();
            this.cooldownLabel = new System.Windows.Forms.Label();
            this.weaveButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 55);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(76, 13);
            label1.TabIndex = 33;
            label1.Text = "Tên Bang Chủ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(222, 55);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(22, 13);
            label2.TabIndex = 37;
            label2.Text = "Mỏ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(306, 55);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(84, 26);
            label3.TabIndex = 42;
            label3.Text = "12: tinh thạch\r\n13: huyễn thạch\r\n";
            // 
            // playerList
            // 
            this.playerList.AllColumns.Add(this.imposenum);
            this.playerList.AllColumns.Add(this.maximposenum);
            this.playerList.AllColumns.Add(this.nameColumn);
            this.playerList.AllColumns.Add(this.cooldownColumn);
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.CellEditUseWholeCell = false;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.imposenum,
            this.maximposenum,
            this.nameColumn,
            this.cooldownColumn});
            this.playerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerList.FullRowSelect = true;
            this.playerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playerList.Location = new System.Drawing.Point(10, 180);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.SelectColumnsOnRightClick = false;
            this.playerList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.playerList.ShowGroups = false;
            this.playerList.Size = new System.Drawing.Size(450, 270);
            this.playerList.TabIndex = 31;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            // 
            // imposenum
            // 
            this.imposenum.MaximumWidth = 60;
            this.imposenum.MinimumWidth = 60;
            this.imposenum.Text = "Đã thu";
            this.imposenum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // maximposenum
            // 
            this.maximposenum.MaximumWidth = 60;
            this.maximposenum.MinimumWidth = 60;
            this.maximposenum.Text = "Tối đa";
            this.maximposenum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.refreshButton.Size = new System.Drawing.Size(108, 30);
            this.refreshButton.TabIndex = 32;
            this.refreshButton.Text = "Làm mới bang chủ";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // weaveTimer
            // 
            this.weaveTimer.Interval = 200;
            this.weaveTimer.Tick += new System.EventHandler(this.weaveTimer_Tick);
            // 
            // hostInput
            // 
            this.hostInput.Enabled = false;
            this.hostInput.Location = new System.Drawing.Point(98, 53);
            this.hostInput.Name = "hostInput";
            this.hostInput.Size = new System.Drawing.Size(118, 20);
            this.hostInput.TabIndex = 34;
            // 
            // autoWeave
            // 
            this.autoWeave.AutoSize = true;
            this.autoWeave.Location = new System.Drawing.Point(250, 16);
            this.autoWeave.Name = "autoWeave";
            this.autoWeave.Size = new System.Drawing.Size(95, 17);
            this.autoWeave.TabIndex = 35;
            this.autoWeave.Text = "Tự động swap";
            this.autoWeave.UseVisualStyleBackColor = true;
            // 
            // cooldownLabel
            // 
            this.cooldownLabel.AutoSize = true;
            this.cooldownLabel.Location = new System.Drawing.Point(350, 17);
            this.cooldownLabel.Name = "cooldownLabel";
            this.cooldownLabel.Size = new System.Drawing.Size(108, 13);
            this.cooldownLabel.TabIndex = 36;
            this.cooldownLabel.Text = "Đóng băng: 00:15:20";
            // 
            // weaveButton
            // 
            this.weaveButton.Location = new System.Drawing.Point(12, 80);
            this.weaveButton.Name = "weaveButton";
            this.weaveButton.Size = new System.Drawing.Size(204, 30);
            this.weaveButton.TabIndex = 39;
            this.weaveButton.Text = "Chuyển lại bang chủ cho";
            this.weaveButton.UseVisualStyleBackColor = true;
            this.weaveButton.Click += new System.EventHandler(this.weaveButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(250, 53);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(50, 20);
            this.numericUpDown1.TabIndex = 41;
            this.numericUpDown1.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 20);
            this.textBox1.TabIndex = 43;
            // 
            // AutoSwap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 461);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.weaveButton);
            this.Controls.Add(label2);
            this.Controls.Add(this.cooldownLabel);
            this.Controls.Add(this.autoWeave);
            this.Controls.Add(this.hostInput);
            this.Controls.Add(label1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.playerList);
            this.Name = "AutoSwap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoWeaveView";
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView playerList;
        private BrightIdeasSoftware.OLVColumn cooldownColumn;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private System.Windows.Forms.Button refreshButton;
        private BrightIdeasSoftware.OLVColumn imposenum;
        private BrightIdeasSoftware.OLVColumn maximposenum;
        private System.Windows.Forms.Timer weaveTimer;
        private System.Windows.Forms.TextBox hostInput;
        private System.Windows.Forms.CheckBox autoWeave;
        private System.Windows.Forms.Label cooldownLabel;
        private System.Windows.Forms.Button weaveButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
