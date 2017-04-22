namespace k8asd {
    partial class AutoSnoutView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.refreshButton = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.autoSnoutCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(10, 10);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 31;
            this.refreshButton.Text = "Làm mới mỏ";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(10, 100);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(480, 233);
            this.logBox.TabIndex = 33;
            // 
            // autoSnoutCheck
            // 
            this.autoSnoutCheck.AutoSize = true;
            this.autoSnoutCheck.Location = new System.Drawing.Point(136, 18);
            this.autoSnoutCheck.Name = "autoSnoutCheck";
            this.autoSnoutCheck.Size = new System.Drawing.Size(122, 17);
            this.autoSnoutCheck.TabIndex = 34;
            this.autoSnoutCheck.Text = "Tự động chuyển mỏ";
            this.autoSnoutCheck.UseVisualStyleBackColor = true;
            this.autoSnoutCheck.CheckedChanged += new System.EventHandler(this.autoSnoutCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 39);
            this.label1.TabIndex = 35;
            this.label1.Text = "==>Chú ý chương  trình lấy acc đầu tiên tìm kiếm khu vực\r\n==>Vì vậy tất cả acc ph" +
    "ải cùng khu vực\r\n==>Acc nào khác khu vực thì disconnect";
            // 
            // AutoSnoutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 354);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoSnoutCheck);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.refreshButton);
            this.Name = "AutoSnoutView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoArenaView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.CheckBox autoSnoutCheck;
        private System.Windows.Forms.Label label1;
    }
}