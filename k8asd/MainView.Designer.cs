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
            this.oneSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.clientList = new System.Windows.Forms.ListBox();
            this._ignore0 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.loginAllButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            menuItem0 = new System.Windows.Forms.ToolStripMenuItem();
            autoArenaButton = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            this._ignore0.SuspendLayout();
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
            autoArenaButton});
            menuItem0.Name = "menuItem0";
            menuItem0.Size = new System.Drawing.Size(58, 20);
            menuItem0.Text = "Phụ trợ";
            // 
            // autoArenaButton
            // 
            autoArenaButton.Name = "autoArenaButton";
            autoArenaButton.Size = new System.Drawing.Size(184, 22);
            autoArenaButton.Text = "Tự động đánh võ đài";
            autoArenaButton.Click += new System.EventHandler(this.autoArenaButton_Click);
            // 
            // oneSecondTimer
            // 
            this.oneSecondTimer.Enabled = true;
            this.oneSecondTimer.Interval = 1000;
            this.oneSecondTimer.Tick += new System.EventHandler(this.oneSecondTimer_Tick);
            // 
            // clientList
            // 
            this.clientList.Dock = System.Windows.Forms.DockStyle.Left;
            this.clientList.FormattingEnabled = true;
            this.clientList.IntegralHeight = false;
            this.clientList.Location = new System.Drawing.Point(0, 97);
            this.clientList.Name = "clientList";
            this.clientList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.clientList.Size = new System.Drawing.Size(179, 584);
            this.clientList.TabIndex = 0;
            this.clientList.SelectedIndexChanged += new System.EventHandler(this.clientList_SelectedIndexChanged);
            // 
            // _ignore0
            // 
            this._ignore0.Controls.Add(this.button1);
            this._ignore0.Controls.Add(this.loginAllButton);
            this._ignore0.Controls.Add(this.removeButton);
            this._ignore0.Controls.Add(this.addButton);
            this._ignore0.Controls.Add(this.logoutButton);
            this._ignore0.Controls.Add(this.loginButton);
            this._ignore0.Dock = System.Windows.Forms.DockStyle.Top;
            this._ignore0.Location = new System.Drawing.Point(0, 24);
            this._ignore0.Name = "_ignore0";
            this._ignore0.Size = new System.Drawing.Size(1350, 73);
            this._ignore0.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(170, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 73);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ngắt Kết Nối All";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // loginAllButton
            // 
            this.loginAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginAllButton.Location = new System.Drawing.Point(98, 0);
            this.loginAllButton.Name = "loginAllButton";
            this.loginAllButton.Size = new System.Drawing.Size(70, 74);
            this.loginAllButton.TabIndex = 1;
            this.loginAllButton.Text = "Đăng Nhập All";
            this.loginAllButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginAllButton.UseVisualStyleBackColor = true;
            this.loginAllButton.Click += new System.EventHandler(this.loginAllButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Image = global::k8asd.Properties.Resources.btn_Delete;
            this.removeButton.Location = new System.Drawing.Point(52, 0);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(43, 73);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Xoá";
            this.removeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Image = global::k8asd.Properties.Resources.btn_Add;
            this.addButton.Location = new System.Drawing.Point(4, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(47, 72);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Thêm";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Image = global::k8asd.Properties.Resources.btn_Logout;
            this.logoutButton.Location = new System.Drawing.Point(320, 0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(87, 73);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Đăng xuất";
            this.logoutButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Image = global::k8asd.Properties.Resources.btn_Login;
            this.loginButton.Location = new System.Drawing.Point(240, 0);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(78, 73);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Đăng nhập";
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "btn_LoginFalse.png");
            this.imageList1.Images.SetKeyName(1, "btn_LoginTrue.png");
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "test";
            this.Load += new System.EventHandler(this.MainView_Load);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            this._ignore0.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer oneSecondTimer;
        private ListBox clientList;
        private Panel _ignore0;
        private Button loginButton;
        private Button logoutButton;
        private Button addButton;
        private Button removeButton;
        private Button loginAllButton;
        private Button button1;
        private ImageList imageList1;
    }
}

