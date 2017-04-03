namespace k8asd
{
    partial class RaiseBirdView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.refreshButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNameRaiseBird = new System.Windows.Forms.Label();
            this.lbExpRaiseBird = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStar = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numRaiseBird = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAutoRaiseBird = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRaiseBird)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(3, 3);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(100, 30);
            this.refreshButton.TabIndex = 29;
            this.refreshButton.Text = "Làm mới chim";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tên Chim";
            // 
            // lbNameRaiseBird
            // 
            this.lbNameRaiseBird.AutoSize = true;
            this.lbNameRaiseBird.Location = new System.Drawing.Point(73, 40);
            this.lbNameRaiseBird.Name = "lbNameRaiseBird";
            this.lbNameRaiseBird.Size = new System.Drawing.Size(63, 13);
            this.lbNameRaiseBird.TabIndex = 31;
            this.lbNameRaiseBird.Text = "Chim to dần";
            // 
            // lbExpRaiseBird
            // 
            this.lbExpRaiseBird.AutoSize = true;
            this.lbExpRaiseBird.Location = new System.Drawing.Point(73, 63);
            this.lbExpRaiseBird.Name = "lbExpRaiseBird";
            this.lbExpRaiseBird.Size = new System.Drawing.Size(63, 13);
            this.lbExpRaiseBird.TabIndex = 33;
            this.lbExpRaiseBird.Text = "Chim to dần";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Kinh nghiệm";
            // 
            // lbStar
            // 
            this.lbStar.AutoSize = true;
            this.lbStar.Location = new System.Drawing.Point(73, 85);
            this.lbStar.Name = "lbStar";
            this.lbStar.Size = new System.Drawing.Size(13, 13);
            this.lbStar.TabIndex = 35;
            this.lbStar.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Số Sao";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "Hình thức";
            // 
            // numRaiseBird
            // 
            this.numRaiseBird.Location = new System.Drawing.Point(76, 104);
            this.numRaiseBird.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numRaiseBird.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRaiseBird.Name = "numRaiseBird";
            this.numRaiseBird.Size = new System.Drawing.Size(60, 20);
            this.numRaiseBird.TabIndex = 37;
            this.numRaiseBird.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 26);
            this.label5.TabIndex = 38;
            this.label5.Text = "1: bạc\r\n2: xu";
            // 
            // chkAutoRaiseBird
            // 
            this.chkAutoRaiseBird.AutoSize = true;
            this.chkAutoRaiseBird.Location = new System.Drawing.Point(76, 133);
            this.chkAutoRaiseBird.Name = "chkAutoRaiseBird";
            this.chkAutoRaiseBird.Size = new System.Drawing.Size(87, 17);
            this.chkAutoRaiseBird.TabIndex = 39;
            this.chkAutoRaiseBird.Text = "Tự nuôi chim";
            this.chkAutoRaiseBird.UseVisualStyleBackColor = true;
            this.chkAutoRaiseBird.CheckedChanged += new System.EventHandler(this.chkAutoRaiseBird_CheckedChanged);
            // 
            // RaiseBirdView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkAutoRaiseBird);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numRaiseBird);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbStar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbExpRaiseBird);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbNameRaiseBird);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refreshButton);
            this.Name = "RaiseBirdView";
            this.Size = new System.Drawing.Size(373, 253);
            ((System.ComponentModel.ISupportInitialize)(this.numRaiseBird)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNameRaiseBird;
        private System.Windows.Forms.Label lbExpRaiseBird;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numRaiseBird;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkAutoRaiseBird;
    }
}
