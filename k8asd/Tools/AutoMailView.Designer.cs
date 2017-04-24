namespace k8asd {
    partial class AutoMailView
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
            this.logBox = new System.Windows.Forms.TextBox();
            this.autoLT = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numYearLT = new System.Windows.Forms.NumericUpDown();
            this.numLT = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numBoss = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numYearTTC = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.autoTTC = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numYearLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoss)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTTC)).BeginInit();
            this.SuspendLayout();
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
            // autoLT
            // 
            this.autoLT.AutoSize = true;
            this.autoLT.Location = new System.Drawing.Point(323, 16);
            this.autoLT.Name = "autoLT";
            this.autoLT.Size = new System.Drawing.Size(143, 17);
            this.autoLT.TabIndex = 34;
            this.autoLT.Text = "Tự động nhận liên thắng";
            this.autoLT.UseVisualStyleBackColor = true;
            this.autoLT.CheckedChanged += new System.EventHandler(this.autoLT_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Năm";
            // 
            // numYearLT
            // 
            this.numYearLT.Location = new System.Drawing.Point(55, 13);
            this.numYearLT.Name = "numYearLT";
            this.numYearLT.Size = new System.Drawing.Size(77, 20);
            this.numYearLT.TabIndex = 36;
            // 
            // numLT
            // 
            this.numLT.Location = new System.Drawing.Point(227, 13);
            this.numLT.Name = "numLT";
            this.numLT.Size = new System.Drawing.Size(77, 20);
            this.numLT.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Liên Thắng";
            // 
            // numBoss
            // 
            this.numBoss.Location = new System.Drawing.Point(227, 45);
            this.numBoss.Name = "numBoss";
            this.numBoss.Size = new System.Drawing.Size(77, 20);
            this.numBoss.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Boss (1-5)";
            // 
            // numYearTTC
            // 
            this.numYearTTC.Location = new System.Drawing.Point(55, 45);
            this.numYearTTC.Name = "numYearTTC";
            this.numYearTTC.Size = new System.Drawing.Size(77, 20);
            this.numYearTTC.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Năm";
            // 
            // autoTTC
            // 
            this.autoTTC.AutoSize = true;
            this.autoTTC.Location = new System.Drawing.Point(323, 48);
            this.autoTTC.Name = "autoTTC";
            this.autoTTC.Size = new System.Drawing.Size(118, 17);
            this.autoTTC.TabIndex = 39;
            this.autoTTC.Text = "Tự động nhận TTC";
            this.autoTTC.UseVisualStyleBackColor = true;
            this.autoTTC.CheckedChanged += new System.EventHandler(this.autoTTC_CheckedChanged);
            // 
            // AutoMailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 354);
            this.Controls.Add(this.numBoss);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numYearTTC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.autoTTC);
            this.Controls.Add(this.numLT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numYearLT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.autoLT);
            this.Controls.Add(this.logBox);
            this.Name = "AutoMailView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoArenaView";
            ((System.ComponentModel.ISupportInitialize)(this.numYearLT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoss)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTTC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.CheckBox autoLT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numYearLT;
        private System.Windows.Forms.NumericUpDown numLT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numBoss;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numYearTTC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox autoTTC;
    }
}