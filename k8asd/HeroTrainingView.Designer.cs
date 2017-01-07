namespace k8asd {
    partial class HeroTrainingView {
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
            this.heroList = new System.Windows.Forms.ListBox();
            this.autoTrainCheck = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.selectedHeroList = new System.Windows.Forms.ListBox();
            this.slotLabel = new System.Windows.Forms.Label();
            this.tokenLabel = new System.Windows.Forms.Label();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.info6Label = new System.Windows.Forms.TextBox();
            this.info5Label = new System.Windows.Forms.TextBox();
            this.info4Label = new System.Windows.Forms.TextBox();
            this.info3Label = new System.Windows.Forms.TextBox();
            this.info2Label = new System.Windows.Forms.TextBox();
            this.info1Label = new System.Windows.Forms.TextBox();
            this.info0Label = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._ignore0 = new System.Windows.Forms.Label();
            this.trainBox = new System.Windows.Forms.GroupBox();
            this.trainButton = new System.Windows.Forms.Button();
            this.timeModelList = new System.Windows.Forms.ComboBox();
            this.guideBox = new System.Windows.Forms.GroupBox();
            this.guideButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.infoBox.SuspendLayout();
            this.trainBox.SuspendLayout();
            this.guideBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // heroList
            // 
            this.heroList.FormattingEnabled = true;
            this.heroList.Items.AddRange(new object[] {
            "Tư Mã Sư Lv. 199 (Đang luyện)",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.heroList.Location = new System.Drawing.Point(5, 30);
            this.heroList.Name = "heroList";
            this.heroList.Size = new System.Drawing.Size(160, 108);
            this.heroList.TabIndex = 0;
            this.heroList.SelectedIndexChanged += new System.EventHandler(this.heroList_SelectedIndexChanged);
            // 
            // autoTrainCheck
            // 
            this.autoTrainCheck.AutoSize = true;
            this.autoTrainCheck.Location = new System.Drawing.Point(5, 5);
            this.autoTrainCheck.Name = "autoTrainCheck";
            this.autoTrainCheck.Size = new System.Drawing.Size(95, 17);
            this.autoTrainCheck.TabIndex = 1;
            this.autoTrainCheck.Text = "Tự động luyện";
            this.autoTrainCheck.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(4, 144);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(60, 25);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Thêm";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(68, 144);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(60, 25);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Xoá";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // selectedHeroList
            // 
            this.selectedHeroList.FormattingEnabled = true;
            this.selectedHeroList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.selectedHeroList.Location = new System.Drawing.Point(5, 175);
            this.selectedHeroList.Name = "selectedHeroList";
            this.selectedHeroList.Size = new System.Drawing.Size(160, 108);
            this.selectedHeroList.TabIndex = 4;
            // 
            // slotLabel
            // 
            this.slotLabel.AutoSize = true;
            this.slotLabel.Location = new System.Drawing.Point(120, 7);
            this.slotLabel.Name = "slotLabel";
            this.slotLabel.Size = new System.Drawing.Size(107, 13);
            this.slotLabel.TabIndex = 5;
            this.slotLabel.Text = "Vị trí huấn luyện: 9/9";
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Location = new System.Drawing.Point(270, 7);
            this.tokenLabel.Name = "tokenLabel";
            this.tokenLabel.Size = new System.Drawing.Size(107, 13);
            this.tokenLabel.TabIndex = 6;
            this.tokenLabel.Text = "Mãnh tiến lệnh: 9999";
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.info6Label);
            this.infoBox.Controls.Add(this.info5Label);
            this.infoBox.Controls.Add(this.info4Label);
            this.infoBox.Controls.Add(this.info3Label);
            this.infoBox.Controls.Add(this.info2Label);
            this.infoBox.Controls.Add(this.info1Label);
            this.infoBox.Controls.Add(this.info0Label);
            this.infoBox.Controls.Add(this.label6);
            this.infoBox.Controls.Add(this.label5);
            this.infoBox.Controls.Add(this.label4);
            this.infoBox.Controls.Add(this.label3);
            this.infoBox.Controls.Add(this.label2);
            this.infoBox.Controls.Add(this.label1);
            this.infoBox.Controls.Add(this._ignore0);
            this.infoBox.Location = new System.Drawing.Point(175, 30);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(240, 200);
            this.infoBox.TabIndex = 7;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Tư Mã Sư Lv. 199";
            // 
            // info6Label
            // 
            this.info6Label.Location = new System.Drawing.Point(80, 167);
            this.info6Label.Name = "info6Label";
            this.info6Label.Size = new System.Drawing.Size(150, 20);
            this.info6Label.TabIndex = 13;
            this.info6Label.Text = "999999/999999";
            this.info6Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info5Label
            // 
            this.info5Label.Location = new System.Drawing.Point(80, 142);
            this.info5Label.Name = "info5Label";
            this.info5Label.Size = new System.Drawing.Size(150, 20);
            this.info5Label.TabIndex = 12;
            this.info5Label.Text = "Cấp 200 trở lên";
            this.info5Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info4Label
            // 
            this.info4Label.Location = new System.Drawing.Point(80, 117);
            this.info4Label.Name = "info4Label";
            this.info4Label.Size = new System.Drawing.Size(150, 20);
            this.info4Label.TabIndex = 11;
            this.info4Label.Text = "Phích Lịch Cửu Tiêu";
            this.info4Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info3Label
            // 
            this.info3Label.Location = new System.Drawing.Point(80, 92);
            this.info3Label.Name = "info3Label";
            this.info3Label.Size = new System.Drawing.Size(150, 20);
            this.info3Label.TabIndex = 10;
            this.info3Label.Text = "Lv20 - 10";
            this.info3Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info2Label
            // 
            this.info2Label.Location = new System.Drawing.Point(80, 67);
            this.info2Label.Name = "info2Label";
            this.info2Label.Size = new System.Drawing.Size(150, 20);
            this.info2Label.TabIndex = 9;
            this.info2Label.Text = "Phích Lịch Hoả Kỵ";
            this.info2Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info1Label
            // 
            this.info1Label.Location = new System.Drawing.Point(80, 42);
            this.info1Label.Name = "info1Label";
            this.info1Label.Size = new System.Drawing.Size(150, 20);
            this.info1Label.TabIndex = 8;
            this.info1Label.Text = "D199 K199 T199";
            this.info1Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info0Label
            // 
            this.info0Label.Location = new System.Drawing.Point(80, 17);
            this.info0Label.Name = "info0Label";
            this.info0Label.Size = new System.Drawing.Size(150, 20);
            this.info0Label.TabIndex = 7;
            this.info0Label.Text = "19999/19999";
            this.info0Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Kinh nghiệm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Binh chủng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Chuyển sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kỹ năng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quân đội";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thuộc tính";
            // 
            // _ignore0
            // 
            this._ignore0.AutoSize = true;
            this._ignore0.Location = new System.Drawing.Point(5, 20);
            this._ignore0.Name = "_ignore0";
            this._ignore0.Size = new System.Drawing.Size(45, 13);
            this._ignore0.TabIndex = 0;
            this._ignore0.Text = "Binh lực";
            // 
            // trainBox
            // 
            this.trainBox.Controls.Add(this.trainButton);
            this.trainBox.Controls.Add(this.timeModelList);
            this.trainBox.Location = new System.Drawing.Point(175, 235);
            this.trainBox.Name = "trainBox";
            this.trainBox.Size = new System.Drawing.Size(240, 50);
            this.trainBox.TabIndex = 8;
            this.trainBox.TabStop = false;
            this.trainBox.Text = "Luyện";
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(156, 14);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(75, 30);
            this.trainButton.TabIndex = 1;
            this.trainButton.Text = "Bắt đầu";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // timeModelList
            // 
            this.timeModelList.FormattingEnabled = true;
            this.timeModelList.Location = new System.Drawing.Point(8, 20);
            this.timeModelList.Name = "timeModelList";
            this.timeModelList.Size = new System.Drawing.Size(140, 21);
            this.timeModelList.TabIndex = 0;
            // 
            // guideBox
            // 
            this.guideBox.Controls.Add(this.guideButton);
            this.guideBox.Controls.Add(this.label9);
            this.guideBox.Controls.Add(this.label8);
            this.guideBox.Controls.Add(this.label7);
            this.guideBox.Controls.Add(this.stopButton);
            this.guideBox.Location = new System.Drawing.Point(175, 290);
            this.guideBox.Name = "guideBox";
            this.guideBox.Size = new System.Drawing.Size(240, 90);
            this.guideBox.TabIndex = 9;
            this.guideBox.TabStop = false;
            this.guideBox.Text = "Mãnh tiến";
            // 
            // guideButton
            // 
            this.guideButton.Location = new System.Drawing.Point(156, 50);
            this.guideButton.Name = "guideButton";
            this.guideButton.Size = new System.Drawing.Size(75, 30);
            this.guideButton.TabIndex = 5;
            this.guideButton.Text = "Mãnh tiến";
            this.guideButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "600 CT - 24588 EXP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Kinh nghiệm mỗi phút: 999";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Thời gian còn lại: 23:59:59";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(156, 14);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 30);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Kết thúc";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // HeroTrainingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.guideBox);
            this.Controls.Add(this.trainBox);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.tokenLabel);
            this.Controls.Add(this.slotLabel);
            this.Controls.Add(this.selectedHeroList);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.autoTrainCheck);
            this.Controls.Add(this.heroList);
            this.Name = "HeroTrainingView";
            this.Size = new System.Drawing.Size(420, 385);
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.trainBox.ResumeLayout(false);
            this.guideBox.ResumeLayout(false);
            this.guideBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox heroList;
        private System.Windows.Forms.CheckBox autoTrainCheck;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ListBox selectedHeroList;
        private System.Windows.Forms.Label slotLabel;
        private System.Windows.Forms.Label tokenLabel;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.Label _ignore0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox info5Label;
        private System.Windows.Forms.TextBox info4Label;
        private System.Windows.Forms.TextBox info3Label;
        private System.Windows.Forms.TextBox info2Label;
        private System.Windows.Forms.TextBox info1Label;
        private System.Windows.Forms.TextBox info0Label;
        private System.Windows.Forms.TextBox info6Label;
        private System.Windows.Forms.GroupBox trainBox;
        private System.Windows.Forms.ComboBox timeModelList;
        private System.Windows.Forms.Button trainButton;
        private System.Windows.Forms.GroupBox guideBox;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button guideButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}
