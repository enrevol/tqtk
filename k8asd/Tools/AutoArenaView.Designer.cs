namespace k8asd {
    partial class AutoArenaView {
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
            BrightIdeasSoftware.OLVColumn nationColumn;
            BrightIdeasSoftware.OLVColumn nameColumn;
            BrightIdeasSoftware.OLVColumn levelColumn;
            BrightIdeasSoftware.OLVColumn timesColumn;
            this.cascadeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.rankColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerList = new BrightIdeasSoftware.ObjectListView();
            this.cooldownColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.refreshButton = new System.Windows.Forms.Button();
            this.duelButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.chkAutoArena = new System.Windows.Forms.CheckBox();
            this.lbArena = new System.Windows.Forms.Label();
            this.timerArena = new System.Windows.Forms.Timer(this.components);
            nationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            levelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            timesColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).BeginInit();
            this.SuspendLayout();
            // 
            // nationColumn
            // 
            nationColumn.AspectName = "CurrentPlayer.Nation";
            nationColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nationColumn.MaximumWidth = 50;
            nationColumn.MinimumWidth = 50;
            nationColumn.Text = "Q. gia";
            nationColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nationColumn.Width = 50;
            // 
            // nameColumn
            // 
            nameColumn.AspectName = "CurrentPlayer.Name";
            nameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nameColumn.MaximumWidth = 150;
            nameColumn.MinimumWidth = 150;
            nameColumn.Text = "Người chơi";
            nameColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nameColumn.Width = 150;
            // 
            // levelColumn
            // 
            levelColumn.AspectName = "CurrentPlayer.Level";
            levelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            levelColumn.MaximumWidth = 40;
            levelColumn.MinimumWidth = 40;
            levelColumn.Text = "Cấp";
            levelColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            levelColumn.Width = 40;
            // 
            // timesColumn
            // 
            timesColumn.AspectName = "CurrentPlayer.RemainTimes";
            timesColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            timesColumn.MaximumWidth = 40;
            timesColumn.MinimumWidth = 40;
            timesColumn.Text = "Lượt";
            timesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            timesColumn.Width = 40;
            // 
            // cascadeColumn
            // 
            this.cascadeColumn.AspectName = "";
            this.cascadeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cascadeColumn.MaximumWidth = 60;
            this.cascadeColumn.MinimumWidth = 60;
            this.cascadeColumn.Text = "L. thắng";
            this.cascadeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rankColumn
            // 
            this.rankColumn.AspectName = "";
            this.rankColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rankColumn.MaximumWidth = 60;
            this.rankColumn.MinimumWidth = 60;
            this.rankColumn.Text = "Hạng";
            this.rankColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // playerList
            // 
            this.playerList.AllColumns.Add(this.rankColumn);
            this.playerList.AllColumns.Add(this.cascadeColumn);
            this.playerList.AllColumns.Add(timesColumn);
            this.playerList.AllColumns.Add(nationColumn);
            this.playerList.AllColumns.Add(nameColumn);
            this.playerList.AllColumns.Add(levelColumn);
            this.playerList.AllColumns.Add(this.cooldownColumn);
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.CellEditUseWholeCell = false;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rankColumn,
            this.cascadeColumn,
            timesColumn,
            nationColumn,
            nameColumn,
            levelColumn,
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
            this.playerList.Size = new System.Drawing.Size(480, 270);
            this.playerList.TabIndex = 30;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
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
            this.refreshButton.TabIndex = 31;
            this.refreshButton.Text = "Làm mới võ đài";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // duelButton
            // 
            this.duelButton.Location = new System.Drawing.Point(120, 10);
            this.duelButton.Name = "duelButton";
            this.duelButton.Size = new System.Drawing.Size(100, 30);
            this.duelButton.TabIndex = 32;
            this.duelButton.Text = "Khiêu chiến";
            this.duelButton.UseVisualStyleBackColor = true;
            this.duelButton.Click += new System.EventHandler(this.duelButton_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(10, 50);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(480, 120);
            this.logBox.TabIndex = 33;
            // 
            // chkAutoArena
            // 
            this.chkAutoArena.AutoSize = true;
            this.chkAutoArena.Location = new System.Drawing.Point(241, 18);
            this.chkAutoArena.Name = "chkAutoArena";
            this.chkAutoArena.Size = new System.Drawing.Size(83, 17);
            this.chkAutoArena.TabIndex = 34;
            this.chkAutoArena.Text = "Auto Võ Đài";
            this.chkAutoArena.UseVisualStyleBackColor = true;
            this.chkAutoArena.CheckedChanged += new System.EventHandler(this.chkAutoArena_CheckedChanged);
            // 
            // lbArena
            // 
            this.lbArena.AutoSize = true;
            this.lbArena.Location = new System.Drawing.Point(328, 18);
            this.lbArena.Name = "lbArena";
            this.lbArena.Size = new System.Drawing.Size(13, 13);
            this.lbArena.TabIndex = 35;
            this.lbArena.Text = "0";
            // 
            // timerArena
            // 
            this.timerArena.Interval = 1000;
            this.timerArena.Tick += new System.EventHandler(this.timerArena_Tick);
            // 
            // AutoArenaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 461);
            this.Controls.Add(this.lbArena);
            this.Controls.Add(this.chkAutoArena);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.duelButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.playerList);
            this.Name = "AutoArenaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoArenaView";
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView playerList;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button duelButton;
        private BrightIdeasSoftware.OLVColumn cooldownColumn;
        private System.Windows.Forms.TextBox logBox;
        private BrightIdeasSoftware.OLVColumn cascadeColumn;
        private BrightIdeasSoftware.OLVColumn rankColumn;
        private System.Windows.Forms.CheckBox chkAutoArena;
        private System.Windows.Forms.Label lbArena;
        private System.Windows.Forms.Timer timerArena;
    }
}