namespace k8asd {
    partial class SystemLogView {
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
            this.autoScrollBox = new System.Windows.Forms.CheckBox();
            this.logBox = new k8asd.FastRichTextBox();
            this.SuspendLayout();
            // 
            // autoScrollBox
            // 
            this.autoScrollBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoScrollBox.AutoSize = true;
            this.autoScrollBox.Checked = true;
            this.autoScrollBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScrollBox.Location = new System.Drawing.Point(70, 161);
            this.autoScrollBox.Name = "autoScrollBox";
            this.autoScrollBox.Size = new System.Drawing.Size(66, 17);
            this.autoScrollBox.TabIndex = 7;
            this.autoScrollBox.Text = "Tự cuộn";
            this.autoScrollBox.UseVisualStyleBackColor = true;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.BackColor = System.Drawing.SystemColors.Info;
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox.Location = new System.Drawing.Point(0, 0);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logBox.Size = new System.Drawing.Size(350, 155);
            this.logBox.TabIndex = 2;
            this.logBox.TabStop = false;
            this.logBox.Text = "";
            // 
            // SystemLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.autoScrollBox);
            this.Controls.Add(this.logBox);
            this.Name = "SystemLogView";
            this.Size = new System.Drawing.Size(350, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastRichTextBox logBox;
        private System.Windows.Forms.CheckBox autoScrollBox;
    }
}
