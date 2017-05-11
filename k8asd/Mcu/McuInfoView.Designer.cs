namespace k8asd {
    partial class McuInfoView {
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
            this.mcuLabel = new System.Windows.Forms.Label();
            this.extraZhengzhanLabel = new System.Windows.Forms.Label();
            this.extraGongjiLabel = new System.Windows.Forms.Label();
            this.extraZhengfuLabel = new System.Windows.Forms.Label();
            this.extraNongtianLabel = new System.Windows.Forms.Label();
            this.extraYinkuangLabel = new System.Windows.Forms.Label();
            this.mcuCooldownLabel = new System.Windows.Forms.Label();
            this.btnCoolDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mcuLabel
            // 
            this.mcuLabel.AccessibleName = "";
            this.mcuLabel.AutoSize = true;
            this.mcuLabel.Location = new System.Drawing.Point(5, 5);
            this.mcuLabel.Name = "mcuLabel";
            this.mcuLabel.Size = new System.Drawing.Size(63, 13);
            this.mcuLabel.TabIndex = 5;
            this.mcuLabel.Text = "Lượt: 30/30";
            // 
            // extraZhengzhanLabel
            // 
            this.extraZhengzhanLabel.AccessibleName = "";
            this.extraZhengzhanLabel.AutoSize = true;
            this.extraZhengzhanLabel.Location = new System.Drawing.Point(98, 5);
            this.extraZhengzhanLabel.Name = "extraZhengzhanLabel";
            this.extraZhengzhanLabel.Size = new System.Drawing.Size(15, 13);
            this.extraZhengzhanLabel.TabIndex = 6;
            this.extraZhengzhanLabel.Text = "Đ";
            // 
            // extraGongjiLabel
            // 
            this.extraGongjiLabel.AccessibleName = "";
            this.extraGongjiLabel.AutoSize = true;
            this.extraGongjiLabel.Location = new System.Drawing.Point(111, 5);
            this.extraGongjiLabel.Name = "extraGongjiLabel";
            this.extraGongjiLabel.Size = new System.Drawing.Size(14, 13);
            this.extraGongjiLabel.TabIndex = 7;
            this.extraGongjiLabel.Text = "T";
            // 
            // extraZhengfuLabel
            // 
            this.extraZhengfuLabel.AccessibleName = "";
            this.extraZhengfuLabel.AutoSize = true;
            this.extraZhengfuLabel.Location = new System.Drawing.Point(126, 5);
            this.extraZhengfuLabel.Name = "extraZhengfuLabel";
            this.extraZhengfuLabel.Size = new System.Drawing.Size(14, 13);
            this.extraZhengfuLabel.TabIndex = 8;
            this.extraZhengfuLabel.Text = "C";
            // 
            // extraNongtianLabel
            // 
            this.extraNongtianLabel.AccessibleName = "";
            this.extraNongtianLabel.AutoSize = true;
            this.extraNongtianLabel.Location = new System.Drawing.Point(139, 5);
            this.extraNongtianLabel.Name = "extraNongtianLabel";
            this.extraNongtianLabel.Size = new System.Drawing.Size(15, 13);
            this.extraNongtianLabel.TabIndex = 9;
            this.extraNongtianLabel.Text = "R";
            // 
            // extraYinkuangLabel
            // 
            this.extraYinkuangLabel.AccessibleName = "";
            this.extraYinkuangLabel.AutoSize = true;
            this.extraYinkuangLabel.Location = new System.Drawing.Point(153, 5);
            this.extraYinkuangLabel.Name = "extraYinkuangLabel";
            this.extraYinkuangLabel.Size = new System.Drawing.Size(16, 13);
            this.extraYinkuangLabel.TabIndex = 10;
            this.extraYinkuangLabel.Text = "M";
            // 
            // mcuCooldownLabel
            // 
            this.mcuCooldownLabel.AccessibleName = "";
            this.mcuCooldownLabel.AutoSize = true;
            this.mcuCooldownLabel.Location = new System.Drawing.Point(179, 5);
            this.mcuCooldownLabel.Name = "mcuCooldownLabel";
            this.mcuCooldownLabel.Size = new System.Drawing.Size(49, 13);
            this.mcuCooldownLabel.TabIndex = 11;
            this.mcuCooldownLabel.Text = "23:59:59";
            // 
            // btnCoolDown
            // 
            this.btnCoolDown.Location = new System.Drawing.Point(250, -1);
            this.btnCoolDown.Name = "btnCoolDown";
            this.btnCoolDown.Size = new System.Drawing.Size(56, 23);
            this.btnCoolDown.TabIndex = 12;
            this.btnCoolDown.Text = "PB QD";
            this.btnCoolDown.UseVisualStyleBackColor = true;
            this.btnCoolDown.Click += new System.EventHandler(this.btnPhaBangQD_Click);
            // 
            // McuView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCoolDown);
            this.Controls.Add(this.mcuCooldownLabel);
            this.Controls.Add(this.extraYinkuangLabel);
            this.Controls.Add(this.extraNongtianLabel);
            this.Controls.Add(this.extraZhengfuLabel);
            this.Controls.Add(this.extraGongjiLabel);
            this.Controls.Add(this.extraZhengzhanLabel);
            this.Controls.Add(this.mcuLabel);
            this.Name = "McuView";
            this.Size = new System.Drawing.Size(319, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mcuLabel;
        private System.Windows.Forms.Label extraZhengzhanLabel;
        private System.Windows.Forms.Label extraGongjiLabel;
        private System.Windows.Forms.Label extraZhengfuLabel;
        private System.Windows.Forms.Label extraNongtianLabel;
        private System.Windows.Forms.Label mcuCooldownLabel;
        private System.Windows.Forms.Label extraYinkuangLabel;
        private System.Windows.Forms.Button btnCoolDown;
    }
}
