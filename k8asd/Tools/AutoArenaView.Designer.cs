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
            BrightIdeasSoftware.OLVColumn rankColumn;
            BrightIdeasSoftware.OLVColumn cascadeColumn;
            BrightIdeasSoftware.OLVColumn nationColumn;
            BrightIdeasSoftware.OLVColumn nameColumn;
            BrightIdeasSoftware.OLVColumn levelColumn;
            this.playerList = new BrightIdeasSoftware.ObjectListView();
            this.refreshButton = new System.Windows.Forms.Button();
            this.duelButton = new System.Windows.Forms.Button();
            this.cooldownColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            rankColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            cascadeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            nationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            levelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).BeginInit();
            this.SuspendLayout();
            // 
            // playerList
            // 
            this.playerList.AllColumns.Add(rankColumn);
            this.playerList.AllColumns.Add(cascadeColumn);
            this.playerList.AllColumns.Add(nationColumn);
            this.playerList.AllColumns.Add(nameColumn);
            this.playerList.AllColumns.Add(levelColumn);
            this.playerList.AllColumns.Add(this.cooldownColumn);
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            rankColumn,
            cascadeColumn,
            nationColumn,
            nameColumn,
            levelColumn,
            this.cooldownColumn});
            this.playerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerList.FullRowSelect = true;
            this.playerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playerList.Location = new System.Drawing.Point(11, 50);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.SelectColumnsOnRightClick = false;
            this.playerList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.playerList.ShowGroups = false;
            this.playerList.Size = new System.Drawing.Size(450, 400);
            this.playerList.TabIndex = 30;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            // 
            // rankColumn
            // 
            rankColumn.AspectName = "RankDescription";
            rankColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            rankColumn.MaximumWidth = 60;
            rankColumn.MinimumWidth = 60;
            rankColumn.Text = "Hạng";
            rankColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cascadeColumn
            // 
            cascadeColumn.AspectName = "CascadeDescription";
            cascadeColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            cascadeColumn.MaximumWidth = 60;
            cascadeColumn.MinimumWidth = 60;
            cascadeColumn.Text = "L. thắng";
            cascadeColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // cooldownColumn
            // 
            this.cooldownColumn.AspectName = "Cooldown";
            this.cooldownColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cooldownColumn.MaximumWidth = 60;
            this.cooldownColumn.MinimumWidth = 60;
            this.cooldownColumn.Text = "Đ. băng";
            this.cooldownColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AutoArenaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 461);
            this.Controls.Add(this.duelButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.playerList);
            this.Name = "AutoArenaView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoArenaView";
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView playerList;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button duelButton;
        private BrightIdeasSoftware.OLVColumn cooldownColumn;
    }
}