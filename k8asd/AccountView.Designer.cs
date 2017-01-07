namespace k8asd {
    partial class AccountView {
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
            this._ignore0 = new System.Windows.Forms.Label();
            this._ignore1 = new System.Windows.Forms.Label();
            this._ignore2 = new System.Windows.Forms.Label();
            this.serverInput = new System.Windows.Forms.TextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _ignore0
            // 
            this._ignore0.AutoSize = true;
            this._ignore0.Location = new System.Drawing.Point(10, 10);
            this._ignore0.Name = "_ignore0";
            this._ignore0.Size = new System.Drawing.Size(38, 13);
            this._ignore0.TabIndex = 0;
            this._ignore0.Text = "Server";
            // 
            // _ignore1
            // 
            this._ignore1.AutoSize = true;
            this._ignore1.Location = new System.Drawing.Point(10, 40);
            this._ignore1.Name = "_ignore1";
            this._ignore1.Size = new System.Drawing.Size(18, 13);
            this._ignore1.TabIndex = 1;
            this._ignore1.Text = "ID";
            // 
            // _ignore2
            // 
            this._ignore2.AutoSize = true;
            this._ignore2.Location = new System.Drawing.Point(10, 70);
            this._ignore2.Name = "_ignore2";
            this._ignore2.Size = new System.Drawing.Size(53, 13);
            this._ignore2.TabIndex = 2;
            this._ignore2.Text = "Password";
            // 
            // serverInput
            // 
            this.serverInput.Location = new System.Drawing.Point(80, 7);
            this.serverInput.Name = "serverInput";
            this.serverInput.Size = new System.Drawing.Size(100, 20);
            this.serverInput.TabIndex = 3;
            this.serverInput.Text = "1";
            this.serverInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.serverInput_KeyPress);
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(80, 37);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(100, 20);
            this.usernameInput.TabIndex = 4;
            this.usernameInput.Text = "rongtamquoc1";
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(80, 67);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.Size = new System.Drawing.Size(100, 20);
            this.passwordInput.TabIndex = 5;
            this.passwordInput.Text = "12081989";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(45, 100);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 30);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // AccountView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 135);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.serverInput);
            this.Controls.Add(this._ignore2);
            this.Controls.Add(this._ignore1);
            this.Controls.Add(this._ignore0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tài khoản";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _ignore0;
        private System.Windows.Forms.Label _ignore1;
        private System.Windows.Forms.Label _ignore2;
        private System.Windows.Forms.TextBox serverInput;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Button okButton;
    }
}