using System.Windows.Forms;
namespace k8asd
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.MenuStrip menuStrip1;
            System.Windows.Forms.ToolStripMenuItem menuItem0;
            System.Windows.Forms.ToolStripMenuItem autoArenaButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.autoWeaveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.autoMerchantButton = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSwapButton = new System.Windows.Forms.ToolStripMenuItem();
            this.autoReherseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.autoQuestButton = new System.Windows.Forms.ToolStripMenuItem();
            this.autoReportQuestButton = new System.Windows.Forms.ToolStripMenuItem();
            this.oneSecondTimer = new System.Windows.Forms.Timer(this.components);
            this._ignore0 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.parallelLoginButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.logoutAllButton = new System.Windows.Forms.Button();
            this.loginAllButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.descriptionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.clientList = new BrightIdeasSoftware.ObjectListView();
            this.changeButton = new System.Windows.Forms.Button();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuItem0 = new System.Windows.Forms.ToolStripMenuItem();
            autoArenaButton = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            this._ignore0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientList)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItem0});
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1350, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip";
            // 
            // menuItem0
            // 
            menuItem0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            autoArenaButton,
            this.autoWeaveButton,
            this.autoMerchantButton,
            this.autoSwapButton,
            this.autoReherseButton,
            this.autoQuestButton,
            this.autoReportQuestButton});
            menuItem0.Name = "menuItem0";
            menuItem0.Size = new System.Drawing.Size(58, 20);
            menuItem0.Text = "Phụ trợ";
            // 
            // autoArenaButton
            // 
            autoArenaButton.Name = "autoArenaButton";
            autoArenaButton.Size = new System.Drawing.Size(214, 22);
            autoArenaButton.Text = "Tự động đánh võ đài";
            autoArenaButton.Click += new System.EventHandler(this.autoArenaButton_Click);
            // 
            // autoWeaveButton
            // 
            this.autoWeaveButton.Name = "autoWeaveButton";
            this.autoWeaveButton.Size = new System.Drawing.Size(214, 22);
            this.autoWeaveButton.Text = "Tự động dệt";
            this.autoWeaveButton.Click += new System.EventHandler(this.autoWeaveButton_Click);
            // 
            // autoMerchantButton
            // 
            this.autoMerchantButton.Name = "autoMerchantButton";
            this.autoMerchantButton.Size = new System.Drawing.Size(214, 22);
            this.autoMerchantButton.Text = "Tự động tìm thương minh";
            this.autoMerchantButton.Click += new System.EventHandler(this.autoMerchantButton_Click);
            // 
            // autoSwapButton
            // 
            this.autoSwapButton.Name = "autoSwapButton";
            this.autoSwapButton.Size = new System.Drawing.Size(214, 22);
            this.autoSwapButton.Text = "Tự động chuyển bang chủ";
            this.autoSwapButton.Click += new System.EventHandler(this.autoSwapButton_Click);
            // 
            // autoReherseButton
            // 
            this.autoReherseButton.Name = "autoReherseButton";
            this.autoReherseButton.Size = new System.Drawing.Size(214, 22);
            this.autoReherseButton.Text = "Tự động tập trận";
            this.autoReherseButton.Click += new System.EventHandler(this.autoReherseButton_Click);
            // 
            // autoQuestButton
            // 
            this.autoQuestButton.Name = "autoQuestButton";
            this.autoQuestButton.Size = new System.Drawing.Size(214, 22);
            this.autoQuestButton.Text = "Bật tự động NVHN";
            this.autoQuestButton.Click += new System.EventHandler(this.autoQuestButton_Click);
            // 
            // autoReportQuestButton
            // 
            this.autoReportQuestButton.Name = "autoReportQuestButton";
            this.autoReportQuestButton.Size = new System.Drawing.Size(214, 22);
            this.autoReportQuestButton.Text = "Báo cáo NVHN";
            this.autoReportQuestButton.Click += new System.EventHandler(this.autoReportQuestButton_Click);
            // 
            // oneSecondTimer
            // 
            this.oneSecondTimer.Enabled = true;
            this.oneSecondTimer.Interval = 1000;
            this.oneSecondTimer.Tick += new System.EventHandler(this.oneSecondTimer_Tick);
            // 
            // _ignore0
            // 
            this._ignore0.Controls.Add(this.saveButton);
            this._ignore0.Controls.Add(this.logoutButton);
            this._ignore0.Controls.Add(this.parallelLoginButton);
            this._ignore0.Controls.Add(this.loginButton);
            this._ignore0.Controls.Add(this.logoutAllButton);
            this._ignore0.Controls.Add(this.loginAllButton);
            this._ignore0.Controls.Add(this.changeButton);
            this._ignore0.Controls.Add(this.removeButton);
            this._ignore0.Controls.Add(this.addButton);
            this._ignore0.Dock = System.Windows.Forms.DockStyle.Top;
            this._ignore0.Location = new System.Drawing.Point(0, 24);
            this._ignore0.Name = "_ignore0";
            this._ignore0.Size = new System.Drawing.Size(1350, 70);
            this._ignore0.TabIndex = 1;
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(570, 0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 70);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Lưu cấu hình";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Image = global::k8asd.Properties.Resources.btn_Logout;
            this.logoutButton.Location = new System.Drawing.Point(490, 0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(80, 70);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Đăng xuất";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // parallelLoginButton
            // 
            this.parallelLoginButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.parallelLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parallelLoginButton.Image = global::k8asd.Properties.Resources.btn_Login;
            this.parallelLoginButton.Location = new System.Drawing.Point(410, 0);
            this.parallelLoginButton.Name = "parallelLoginButton";
            this.parallelLoginButton.Size = new System.Drawing.Size(80, 70);
            this.parallelLoginButton.TabIndex = 4;
            this.parallelLoginButton.Text = "Đăng nhập song song";
            this.parallelLoginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.parallelLoginButton.UseVisualStyleBackColor = true;
            this.parallelLoginButton.Click += new System.EventHandler(this.parallelLoginButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Image = global::k8asd.Properties.Resources.btn_Login;
            this.loginButton.Location = new System.Drawing.Point(330, 0);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(80, 70);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Đăng nhập";
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // logoutAllButton
            // 
            this.logoutAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoutAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutAllButton.Location = new System.Drawing.Point(260, 0);
            this.logoutAllButton.Name = "logoutAllButton";
            this.logoutAllButton.Size = new System.Drawing.Size(70, 70);
            this.logoutAllButton.TabIndex = 2;
            this.logoutAllButton.Text = "Ngắt Kết Nối All";
            this.logoutAllButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.logoutAllButton.UseVisualStyleBackColor = true;
            this.logoutAllButton.Click += new System.EventHandler(this.logoutAllButton_Click);
            // 
            // loginAllButton
            // 
            this.loginAllButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.loginAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginAllButton.Location = new System.Drawing.Point(190, 0);
            this.loginAllButton.Name = "loginAllButton";
            this.loginAllButton.Size = new System.Drawing.Size(70, 70);
            this.loginAllButton.TabIndex = 1;
            this.loginAllButton.Text = "Đăng Nhập All";
            this.loginAllButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginAllButton.UseVisualStyleBackColor = true;
            this.loginAllButton.Click += new System.EventHandler(this.loginAllButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Image = global::k8asd.Properties.Resources.btn_Delete;
            this.removeButton.Location = new System.Drawing.Point(60, 0);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 70);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Xoá";
            this.removeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Image = global::k8asd.Properties.Resources.btn_Add;
            this.addButton.Location = new System.Drawing.Point(0, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(60, 70);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Thêm";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "connected");
            this.imageList1.Images.SetKeyName(1, "disconnected");
            // 
            // statusColumn
            // 
            this.statusColumn.AspectName = "";
            this.statusColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusColumn.Text = "";
            this.statusColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusColumn.Width = 16;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.AspectName = "";
            this.descriptionColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.descriptionColumn.MaximumWidth = 210;
            this.descriptionColumn.MinimumWidth = 210;
            this.descriptionColumn.Text = "Client";
            this.descriptionColumn.Width = 210;
            // 
            // clientList
            // 
            this.clientList.AllColumns.Add(this.statusColumn);
            this.clientList.AllColumns.Add(this.descriptionColumn);
            this.clientList.CellEditUseWholeCell = false;
            this.clientList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.statusColumn,
            this.descriptionColumn});
            this.clientList.Cursor = System.Windows.Forms.Cursors.Default;
            this.clientList.Dock = System.Windows.Forms.DockStyle.Left;
            this.clientList.FullRowSelect = true;
            this.clientList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.clientList.Location = new System.Drawing.Point(0, 94);
            this.clientList.Name = "clientList";
            this.clientList.ShowGroups = false;
            this.clientList.Size = new System.Drawing.Size(250, 587);
            this.clientList.SmallImageList = this.imageList1;
            this.clientList.TabIndex = 32;
            this.clientList.UseCompatibleStateImageBehavior = false;
            this.clientList.View = System.Windows.Forms.View.Details;
            this.clientList.SelectedIndexChanged += new System.EventHandler(this.clientList_SelectedIndexChanged);
            // 
            // changeButton
            // 
            this.changeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.changeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeButton.Location = new System.Drawing.Point(120, 0);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(70, 70);
            this.changeButton.TabIndex = 6;
            this.changeButton.Text = "Thay đổi thông tin đăng nhập";
            this.changeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 681);
            this.Controls.Add(this.clientList);
            this.Controls.Add(this._ignore0);
            this.Controls.Add(menuStrip1);
            this.Location = new System.Drawing.Point(640, 0);
            this.MainMenuStrip = menuStrip1;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "test";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainView_FormClosed);
            this.Load += new System.EventHandler(this.MainView_Load);
            this.LocationChanged += new System.EventHandler(this.MainView_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.MainView_SizeChanged);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this._ignore0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.clientList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer oneSecondTimer;
        private Panel _ignore0;
        private Button loginButton;
        private Button logoutButton;
        private Button addButton;
        private Button removeButton;
        private Button loginAllButton;
        private Button logoutAllButton;
        private ImageList imageList1;
        private ToolStripMenuItem autoWeaveButton;
        private BrightIdeasSoftware.OLVColumn statusColumn;
        private BrightIdeasSoftware.OLVColumn descriptionColumn;
        private BrightIdeasSoftware.ObjectListView clientList;
        private ToolStripMenuItem autoSwapButton;
        private ToolStripMenuItem autoMerchantButton;
        private Button parallelLoginButton;
        private ToolStripMenuItem autoReherseButton;
        private Button saveButton;
        private ToolStripMenuItem autoQuestButton;
        private ToolStripMenuItem autoReportQuestButton;
        private Button changeButton;
    }
}

