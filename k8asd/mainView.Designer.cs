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
            this.oneSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.accountList = new System.Windows.Forms.ListBox();
            this._ignore0 = new System.Windows.Forms.Panel();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this._ignore0.SuspendLayout();
            this.SuspendLayout();
            // 
            // oneSecondTimer
            // 
            this.oneSecondTimer.Enabled = true;
            this.oneSecondTimer.Interval = 1000;
            this.oneSecondTimer.Tick += new System.EventHandler(this.oneSecondTimer_Tick);
            // 
            // accountList
            // 
            this.accountList.Dock = System.Windows.Forms.DockStyle.Left;
            this.accountList.FormattingEnabled = true;
            this.accountList.IntegralHeight = false;
            this.accountList.Location = new System.Drawing.Point(0, 30);
            this.accountList.Name = "accountList";
            this.accountList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.accountList.Size = new System.Drawing.Size(150, 596);
            this.accountList.TabIndex = 0;
            // 
            // _ignore0
            // 
            this._ignore0.Controls.Add(this.removeButton);
            this._ignore0.Controls.Add(this.addButton);
            this._ignore0.Controls.Add(this.logoutButton);
            this._ignore0.Controls.Add(this.loginButton);
            this._ignore0.Dock = System.Windows.Forms.DockStyle.Top;
            this._ignore0.Location = new System.Drawing.Point(0, 0);
            this._ignore0.Name = "_ignore0";
            this._ignore0.Size = new System.Drawing.Size(773, 30);
            this._ignore0.TabIndex = 1;
            // 
            // removeButton
            // 
            this.removeButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.removeButton.Location = new System.Drawing.Point(225, 0);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 30);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Xoá";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.addButton.Location = new System.Drawing.Point(150, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 30);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Thêm";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.logoutButton.Location = new System.Drawing.Point(75, 0);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 30);
            this.logoutButton.TabIndex = 1;
            this.logoutButton.Text = "Đăng xuất";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.loginButton.Location = new System.Drawing.Point(0, 0);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 30);
            this.loginButton.TabIndex = 0;
            this.loginButton.Text = "Đăng nhập";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 626);
            this.Controls.Add(this.accountList);
            this.Controls.Add(this._ignore0);
            this.Location = new System.Drawing.Point(640, 0);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "test";
            this._ignore0.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer oneSecondTimer;
        private ListBox accountList;
        private Panel _ignore0;
        private Button loginButton;
        private Button logoutButton;
        private Button addButton;
        private Button removeButton;
    }
}

