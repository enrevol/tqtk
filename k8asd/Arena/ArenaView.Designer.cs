namespace k8asd {
    partial class ArenaView {
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
            BrightIdeasSoftware.OLVColumn rankColumn;
            BrightIdeasSoftware.OLVColumn duelColumn;
            BrightIdeasSoftware.OLVColumn nationColumn;
            BrightIdeasSoftware.OLVColumn nameColumn;
            BrightIdeasSoftware.OLVColumn levelColumn;
            BrightIdeasSoftware.OLVColumn cascadeColumn;
            this.refreshButton = new System.Windows.Forms.Button();
            this.playerList = new BrightIdeasSoftware.ObjectListView();
            this.timesLabel = new System.Windows.Forms.Label();
            this.cascadeLabel = new System.Windows.Forms.Label();
            this.topRankLabel = new System.Windows.Forms.Label();
            rankColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            duelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            nationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            levelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            cascadeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).BeginInit();
            this.SuspendLayout();
            // 
            // rankColumn
            // 
            rankColumn.AspectName = "Rank";
            rankColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            rankColumn.MaximumWidth = 50;
            rankColumn.MinimumWidth = 50;
            rankColumn.Text = "Hạng";
            rankColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            rankColumn.Width = 50;
            // 
            // duelColumn
            // 
            duelColumn.AspectName = "Name";
            duelColumn.AspectToStringFormat = "Khiêu chiến";
            duelColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            duelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            duelColumn.IsButton = true;
            duelColumn.MaximumWidth = 70;
            duelColumn.MinimumWidth = 70;
            duelColumn.Text = "Thao tác";
            duelColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            duelColumn.Width = 70;
            // 
            // nationColumn
            // 
            nationColumn.AspectName = "Nation";
            nationColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nationColumn.MaximumWidth = 50;
            nationColumn.MinimumWidth = 50;
            nationColumn.Text = "Q. gia";
            nationColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nationColumn.Width = 50;
            // 
            // nameColumn
            // 
            nameColumn.AspectName = "Name";
            nameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nameColumn.MaximumWidth = 150;
            nameColumn.MinimumWidth = 150;
            nameColumn.Text = "Người chơi";
            nameColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            nameColumn.Width = 150;
            // 
            // levelColumn
            // 
            levelColumn.AspectName = "Level";
            levelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            levelColumn.MaximumWidth = 40;
            levelColumn.MinimumWidth = 40;
            levelColumn.Text = "Cấp";
            levelColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            levelColumn.Width = 40;
            // 
            // cascadeColumn
            // 
            cascadeColumn.AspectName = "TopCascade";
            cascadeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            cascadeColumn.MaximumWidth = 50;
            cascadeColumn.MinimumWidth = 50;
            cascadeColumn.Text = "LT max";
            cascadeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            cascadeColumn.Width = 50;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(5, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 28;
            this.refreshButton.Text = "Làm mới võ đài";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // playerList
            // 
            this.playerList.AllColumns.Add(rankColumn);
            this.playerList.AllColumns.Add(cascadeColumn);
            this.playerList.AllColumns.Add(nationColumn);
            this.playerList.AllColumns.Add(nameColumn);
            this.playerList.AllColumns.Add(levelColumn);
            this.playerList.AllColumns.Add(duelColumn);
            this.playerList.CellEditUseWholeCell = false;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            rankColumn,
            cascadeColumn,
            nationColumn,
            nameColumn,
            levelColumn,
            duelColumn});
            this.playerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerList.FullRowSelect = true;
            this.playerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playerList.Location = new System.Drawing.Point(6, 40);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.SelectColumnsOnRightClick = false;
            this.playerList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.playerList.ShowGroups = false;
            this.playerList.Size = new System.Drawing.Size(440, 221);
            this.playerList.TabIndex = 29;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            this.playerList.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.playerList_ButtonClick);
            // 
            // timesLabel
            // 
            this.timesLabel.AutoSize = true;
            this.timesLabel.Location = new System.Drawing.Point(120, 15);
            this.timesLabel.Name = "timesLabel";
            this.timesLabel.Size = new System.Drawing.Size(60, 13);
            this.timesLabel.TabIndex = 30;
            this.timesLabel.Text = "Số lần: 5/5";
            // 
            // cascadeLabel
            // 
            this.cascadeLabel.AutoSize = true;
            this.cascadeLabel.Location = new System.Drawing.Point(195, 15);
            this.cascadeLabel.Name = "cascadeLabel";
            this.cascadeLabel.Size = new System.Drawing.Size(118, 13);
            this.cascadeLabel.TabIndex = 31;
            this.cascadeLabel.Text = "Liên thắng hiện tại: 150";
            // 
            // topRankLabel
            // 
            this.topRankLabel.AutoSize = true;
            this.topRankLabel.Location = new System.Drawing.Point(330, 15);
            this.topRankLabel.Name = "topRankLabel";
            this.topRankLabel.Size = new System.Drawing.Size(108, 13);
            this.topRankLabel.TabIndex = 33;
            this.topRankLabel.Text = "Hạng cao nhất: 1000";
            // 
            // ArenaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topRankLabel);
            this.Controls.Add(this.cascadeLabel);
            this.Controls.Add(this.timesLabel);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.refreshButton);
            this.Name = "ArenaView";
            this.Size = new System.Drawing.Size(450, 275);
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private BrightIdeasSoftware.ObjectListView playerList;
        private System.Windows.Forms.Label timesLabel;
        private System.Windows.Forms.Label cascadeLabel;
        private System.Windows.Forms.Label topRankLabel;
    }
}
