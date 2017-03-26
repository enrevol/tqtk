namespace k8asd {
    partial class AutoMerchantView {
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
            this.refreshTeamButton = new System.Windows.Forms.Button();
            this.foundPlayerList = new BrightIdeasSoftware.ObjectListView();
            this.foundPlayerArea = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.foundPlayerScope = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.foundPlayerName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.foundPlayerMerchant = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.foundPlayerAutoMerchant = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerList = new BrightIdeasSoftware.ObjectListView();
            this.playerNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerReceivedColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerSentColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant0Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant1Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant2Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant3Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant4Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant5Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant6Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant7Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant8Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant9Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant10Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.playerMerchant11Column = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.refreshPlayerButton = new System.Windows.Forms.Button();
            this.playerMerchantColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.foundPlayerSendColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.foundPlayerList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshTeamButton
            // 
            this.refreshTeamButton.Location = new System.Drawing.Point(10, 10);
            this.refreshTeamButton.Name = "refreshTeamButton";
            this.refreshTeamButton.Size = new System.Drawing.Size(100, 30);
            this.refreshTeamButton.TabIndex = 29;
            this.refreshTeamButton.Text = "Làm mới khu vực";
            this.refreshTeamButton.UseVisualStyleBackColor = true;
            // 
            // foundPlayerList
            // 
            this.foundPlayerList.AllColumns.Add(this.foundPlayerArea);
            this.foundPlayerList.AllColumns.Add(this.foundPlayerScope);
            this.foundPlayerList.AllColumns.Add(this.foundPlayerName);
            this.foundPlayerList.AllColumns.Add(this.foundPlayerMerchant);
            this.foundPlayerList.AllColumns.Add(this.foundPlayerAutoMerchant);
            this.foundPlayerList.AllColumns.Add(this.foundPlayerSendColumn);
            this.foundPlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foundPlayerList.CellEditUseWholeCell = false;
            this.foundPlayerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.foundPlayerArea,
            this.foundPlayerScope,
            this.foundPlayerName,
            this.foundPlayerMerchant,
            this.foundPlayerAutoMerchant,
            this.foundPlayerSendColumn});
            this.foundPlayerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.foundPlayerList.FullRowSelect = true;
            this.foundPlayerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.foundPlayerList.Location = new System.Drawing.Point(10, 50);
            this.foundPlayerList.MultiSelect = false;
            this.foundPlayerList.Name = "foundPlayerList";
            this.foundPlayerList.SelectColumnsOnRightClick = false;
            this.foundPlayerList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.foundPlayerList.ShowGroups = false;
            this.foundPlayerList.Size = new System.Drawing.Size(450, 260);
            this.foundPlayerList.TabIndex = 32;
            this.foundPlayerList.UseCompatibleStateImageBehavior = false;
            this.foundPlayerList.View = System.Windows.Forms.View.Details;
            // 
            // foundPlayerArea
            // 
            this.foundPlayerArea.AspectName = "";
            this.foundPlayerArea.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerArea.MaximumWidth = 80;
            this.foundPlayerArea.MinimumWidth = 80;
            this.foundPlayerArea.Text = "Thành";
            this.foundPlayerArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerArea.Width = 80;
            // 
            // foundPlayerScope
            // 
            this.foundPlayerScope.AspectName = "";
            this.foundPlayerScope.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerScope.MaximumWidth = 55;
            this.foundPlayerScope.MinimumWidth = 55;
            this.foundPlayerScope.Text = "Khu vực";
            this.foundPlayerScope.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerScope.Width = 55;
            // 
            // foundPlayerName
            // 
            this.foundPlayerName.AspectName = "";
            this.foundPlayerName.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerName.MaximumWidth = 100;
            this.foundPlayerName.MinimumWidth = 100;
            this.foundPlayerName.Text = "Người chơi";
            this.foundPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerName.Width = 100;
            // 
            // foundPlayerMerchant
            // 
            this.foundPlayerMerchant.MaximumWidth = 70;
            this.foundPlayerMerchant.MinimumWidth = 70;
            this.foundPlayerMerchant.Text = "T. Minh";
            this.foundPlayerMerchant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerMerchant.Width = 70;
            // 
            // foundPlayerAutoMerchant
            // 
            this.foundPlayerAutoMerchant.CheckBoxes = true;
            this.foundPlayerAutoMerchant.MaximumWidth = 55;
            this.foundPlayerAutoMerchant.MinimumWidth = 55;
            this.foundPlayerAutoMerchant.Text = "Tự động";
            this.foundPlayerAutoMerchant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.foundPlayerAutoMerchant.Width = 55;
            // 
            // playerList
            // 
            this.playerList.AllColumns.Add(this.playerNameColumn);
            this.playerList.AllColumns.Add(this.playerReceivedColumn);
            this.playerList.AllColumns.Add(this.playerSentColumn);
            this.playerList.AllColumns.Add(this.playerMerchantColumn);
            this.playerList.AllColumns.Add(this.playerMerchant0Column);
            this.playerList.AllColumns.Add(this.playerMerchant1Column);
            this.playerList.AllColumns.Add(this.playerMerchant2Column);
            this.playerList.AllColumns.Add(this.playerMerchant3Column);
            this.playerList.AllColumns.Add(this.playerMerchant4Column);
            this.playerList.AllColumns.Add(this.playerMerchant5Column);
            this.playerList.AllColumns.Add(this.playerMerchant6Column);
            this.playerList.AllColumns.Add(this.playerMerchant7Column);
            this.playerList.AllColumns.Add(this.playerMerchant8Column);
            this.playerList.AllColumns.Add(this.playerMerchant9Column);
            this.playerList.AllColumns.Add(this.playerMerchant10Column);
            this.playerList.AllColumns.Add(this.playerMerchant11Column);
            this.playerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playerList.CellEditUseWholeCell = false;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.playerNameColumn,
            this.playerReceivedColumn,
            this.playerSentColumn,
            this.playerMerchantColumn,
            this.playerMerchant0Column,
            this.playerMerchant1Column,
            this.playerMerchant2Column,
            this.playerMerchant3Column,
            this.playerMerchant4Column,
            this.playerMerchant5Column,
            this.playerMerchant6Column,
            this.playerMerchant7Column,
            this.playerMerchant8Column,
            this.playerMerchant9Column,
            this.playerMerchant10Column,
            this.playerMerchant11Column});
            this.playerList.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerList.FullRowSelect = true;
            this.playerList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.playerList.Location = new System.Drawing.Point(10, 360);
            this.playerList.MultiSelect = false;
            this.playerList.Name = "playerList";
            this.playerList.SelectColumnsOnRightClick = false;
            this.playerList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.playerList.ShowGroups = false;
            this.playerList.ShowImagesOnSubItems = true;
            this.playerList.Size = new System.Drawing.Size(700, 260);
            this.playerList.TabIndex = 33;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            // 
            // playerNameColumn
            // 
            this.playerNameColumn.AspectName = "";
            this.playerNameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerNameColumn.MaximumWidth = 100;
            this.playerNameColumn.MinimumWidth = 100;
            this.playerNameColumn.Text = "Người chơi";
            this.playerNameColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerNameColumn.Width = 100;
            // 
            // playerReceivedColumn
            // 
            this.playerReceivedColumn.AspectName = "";
            this.playerReceivedColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerReceivedColumn.MaximumWidth = 70;
            this.playerReceivedColumn.MinimumWidth = 70;
            this.playerReceivedColumn.Text = "Đã nhận";
            this.playerReceivedColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerReceivedColumn.Width = 70;
            // 
            // playerSentColumn
            // 
            this.playerSentColumn.AspectName = "";
            this.playerSentColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerSentColumn.MaximumWidth = 70;
            this.playerSentColumn.MinimumWidth = 70;
            this.playerSentColumn.Text = "Đã gửi";
            this.playerSentColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerSentColumn.Width = 70;
            // 
            // playerMerchant0Column
            // 
            this.playerMerchant0Column.CheckBoxes = true;
            this.playerMerchant0Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant0Column.IsHeaderVertical = true;
            this.playerMerchant0Column.MaximumWidth = 30;
            this.playerMerchant0Column.MinimumWidth = 30;
            this.playerMerchant0Column.Text = "Lâu Lan";
            this.playerMerchant0Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant0Column.Width = 30;
            // 
            // playerMerchant1Column
            // 
            this.playerMerchant1Column.CheckBoxes = true;
            this.playerMerchant1Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant1Column.IsHeaderVertical = true;
            this.playerMerchant1Column.MaximumWidth = 30;
            this.playerMerchant1Column.MinimumWidth = 30;
            this.playerMerchant1Column.Text = "Tây Vực";
            this.playerMerchant1Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant1Column.Width = 30;
            // 
            // playerMerchant2Column
            // 
            this.playerMerchant2Column.AspectName = "";
            this.playerMerchant2Column.CheckBoxes = true;
            this.playerMerchant2Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant2Column.IsHeaderVertical = true;
            this.playerMerchant2Column.MaximumWidth = 30;
            this.playerMerchant2Column.MinimumWidth = 30;
            this.playerMerchant2Column.Text = "Ba Thục";
            this.playerMerchant2Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant2Column.Width = 30;
            // 
            // playerMerchant3Column
            // 
            this.playerMerchant3Column.AspectName = "";
            this.playerMerchant3Column.CheckBoxes = true;
            this.playerMerchant3Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant3Column.IsHeaderVertical = true;
            this.playerMerchant3Column.MaximumWidth = 30;
            this.playerMerchant3Column.MinimumWidth = 30;
            this.playerMerchant3Column.Text = "Đại Lý";
            this.playerMerchant3Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant3Column.Width = 30;
            // 
            // playerMerchant4Column
            // 
            this.playerMerchant4Column.CheckBoxes = true;
            this.playerMerchant4Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant4Column.IsHeaderVertical = true;
            this.playerMerchant4Column.MaximumWidth = 30;
            this.playerMerchant4Column.MinimumWidth = 30;
            this.playerMerchant4Column.Text = "Mẫn Nam";
            this.playerMerchant4Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant4Column.Width = 30;
            // 
            // playerMerchant5Column
            // 
            this.playerMerchant5Column.CheckBoxes = true;
            this.playerMerchant5Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant5Column.IsHeaderVertical = true;
            this.playerMerchant5Column.MaximumWidth = 30;
            this.playerMerchant5Column.MinimumWidth = 30;
            this.playerMerchant5Column.Text = "Liêu Đông";
            this.playerMerchant5Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant5Column.Width = 30;
            // 
            // playerMerchant6Column
            // 
            this.playerMerchant6Column.CheckBoxes = true;
            this.playerMerchant6Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant6Column.IsHeaderVertical = true;
            this.playerMerchant6Column.MaximumWidth = 30;
            this.playerMerchant6Column.MinimumWidth = 30;
            this.playerMerchant6Column.Text = "Quan Đông";
            this.playerMerchant6Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant6Column.Width = 30;
            // 
            // playerMerchant7Column
            // 
            this.playerMerchant7Column.CheckBoxes = true;
            this.playerMerchant7Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant7Column.IsHeaderVertical = true;
            this.playerMerchant7Column.MaximumWidth = 30;
            this.playerMerchant7Column.MinimumWidth = 30;
            this.playerMerchant7Column.Text = "Hoài Nam";
            this.playerMerchant7Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant7Column.Width = 30;
            // 
            // playerMerchant8Column
            // 
            this.playerMerchant8Column.CheckBoxes = true;
            this.playerMerchant8Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant8Column.IsHeaderVertical = true;
            this.playerMerchant8Column.MaximumWidth = 30;
            this.playerMerchant8Column.MinimumWidth = 30;
            this.playerMerchant8Column.Text = "Kinh Sở";
            this.playerMerchant8Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant8Column.Width = 30;
            // 
            // playerMerchant9Column
            // 
            this.playerMerchant9Column.CheckBoxes = true;
            this.playerMerchant9Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant9Column.IsHeaderVertical = true;
            this.playerMerchant9Column.MaximumWidth = 30;
            this.playerMerchant9Column.MinimumWidth = 30;
            this.playerMerchant9Column.Text = "Nam Việt";
            this.playerMerchant9Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant9Column.Width = 30;
            // 
            // playerMerchant10Column
            // 
            this.playerMerchant10Column.CheckBoxes = true;
            this.playerMerchant10Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant10Column.IsHeaderVertical = true;
            this.playerMerchant10Column.MaximumWidth = 30;
            this.playerMerchant10Column.MinimumWidth = 30;
            this.playerMerchant10Column.Text = "Tầm Dương";
            this.playerMerchant10Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant10Column.Width = 30;
            // 
            // playerMerchant11Column
            // 
            this.playerMerchant11Column.CheckBoxes = true;
            this.playerMerchant11Column.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant11Column.IsHeaderVertical = true;
            this.playerMerchant11Column.MaximumWidth = 30;
            this.playerMerchant11Column.MinimumWidth = 30;
            this.playerMerchant11Column.Text = "Lĩnh Nam";
            this.playerMerchant11Column.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchant11Column.Width = 30;
            // 
            // refreshPlayerButton
            // 
            this.refreshPlayerButton.Location = new System.Drawing.Point(10, 320);
            this.refreshPlayerButton.Name = "refreshPlayerButton";
            this.refreshPlayerButton.Size = new System.Drawing.Size(120, 30);
            this.refreshPlayerButton.TabIndex = 34;
            this.refreshPlayerButton.Text = "Làm mới người chơi";
            this.refreshPlayerButton.UseVisualStyleBackColor = true;
            this.refreshPlayerButton.Click += new System.EventHandler(this.refreshPlayerButton_Click);
            // 
            // playerMerchantColumn
            // 
            this.playerMerchantColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchantColumn.MaximumWidth = 70;
            this.playerMerchantColumn.MinimumWidth = 70;
            this.playerMerchantColumn.Text = "T. Minh";
            this.playerMerchantColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.playerMerchantColumn.Width = 70;
            // 
            // foundPlayerSendColumn
            // 
            this.foundPlayerSendColumn.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.foundPlayerSendColumn.IsButton = true;
            this.foundPlayerSendColumn.MaximumWidth = 60;
            this.foundPlayerSendColumn.MinimumWidth = 60;
            this.foundPlayerSendColumn.Text = "Thao tác";
            // 
            // AutoMerchantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 631);
            this.Controls.Add(this.refreshPlayerButton);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.foundPlayerList);
            this.Controls.Add(this.refreshTeamButton);
            this.Name = "AutoMerchantView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoMerchantVIew";
            ((System.ComponentModel.ISupportInitialize)(this.foundPlayerList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshTeamButton;
        private BrightIdeasSoftware.ObjectListView foundPlayerList;
        private BrightIdeasSoftware.OLVColumn foundPlayerArea;
        private BrightIdeasSoftware.OLVColumn foundPlayerScope;
        private BrightIdeasSoftware.OLVColumn foundPlayerName;
        private BrightIdeasSoftware.OLVColumn foundPlayerMerchant;
        private BrightIdeasSoftware.OLVColumn foundPlayerAutoMerchant;
        private BrightIdeasSoftware.ObjectListView playerList;
        private BrightIdeasSoftware.OLVColumn playerNameColumn;
        private BrightIdeasSoftware.OLVColumn playerReceivedColumn;
        private BrightIdeasSoftware.OLVColumn playerSentColumn;
        private BrightIdeasSoftware.OLVColumn playerMerchant0Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant1Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant2Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant3Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant4Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant5Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant6Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant7Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant8Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant9Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant10Column;
        private BrightIdeasSoftware.OLVColumn playerMerchant11Column;
        private System.Windows.Forms.Button refreshPlayerButton;
        private BrightIdeasSoftware.OLVColumn playerMerchantColumn;
        private BrightIdeasSoftware.OLVColumn foundPlayerSendColumn;
    }
}
