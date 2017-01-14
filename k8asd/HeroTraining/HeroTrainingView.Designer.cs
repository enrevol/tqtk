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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label _ignore6;
            System.Windows.Forms.Label _ignore2;
            System.Windows.Forms.Label _ignore5;
            System.Windows.Forms.Label _ignore4;
            System.Windows.Forms.Label _ignore3;
            System.Windows.Forms.Label _ignore1;
            System.Windows.Forms.Label _ignore0;
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
            this.trainBox = new System.Windows.Forms.GroupBox();
            this.trainButton = new System.Windows.Forms.Button();
            this.timeModelList = new System.Windows.Forms.ComboBox();
            this.guideBox = new System.Windows.Forms.GroupBox();
            this.guideButton = new System.Windows.Forms.Button();
            this.honorExpLabel = new System.Windows.Forms.Label();
            this.expPerMinLabel = new System.Windows.Forms.Label();
            this.remainingTimeLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.oneSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.trainingTimer = new System.Windows.Forms.Timer(this.components);
            _ignore6 = new System.Windows.Forms.Label();
            _ignore2 = new System.Windows.Forms.Label();
            _ignore5 = new System.Windows.Forms.Label();
            _ignore4 = new System.Windows.Forms.Label();
            _ignore3 = new System.Windows.Forms.Label();
            _ignore1 = new System.Windows.Forms.Label();
            _ignore0 = new System.Windows.Forms.Label();
            this.infoBox.SuspendLayout();
            this.trainBox.SuspendLayout();
            this.guideBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ignore6
            // 
            _ignore6.AutoSize = true;
            _ignore6.Location = new System.Drawing.Point(5, 173);
            _ignore6.Name = "_ignore6";
            _ignore6.Size = new System.Drawing.Size(65, 13);
            _ignore6.TabIndex = 6;
            _ignore6.Text = "Kinh nghiệm";
            // 
            // _ignore2
            // 
            _ignore2.AutoSize = true;
            _ignore2.Location = new System.Drawing.Point(5, 73);
            _ignore2.Name = "_ignore2";
            _ignore2.Size = new System.Drawing.Size(61, 13);
            _ignore2.TabIndex = 5;
            _ignore2.Text = "Binh chủng";
            // 
            // _ignore5
            // 
            _ignore5.AutoSize = true;
            _ignore5.Location = new System.Drawing.Point(5, 148);
            _ignore5.Name = "_ignore5";
            _ignore5.Size = new System.Drawing.Size(65, 13);
            _ignore5.TabIndex = 4;
            _ignore5.Text = "Chuyển sinh";
            // 
            // _ignore4
            // 
            _ignore4.AutoSize = true;
            _ignore4.Location = new System.Drawing.Point(5, 123);
            _ignore4.Name = "_ignore4";
            _ignore4.Size = new System.Drawing.Size(46, 13);
            _ignore4.TabIndex = 3;
            _ignore4.Text = "Kỹ năng";
            // 
            // _ignore3
            // 
            _ignore3.AutoSize = true;
            _ignore3.Location = new System.Drawing.Point(5, 98);
            _ignore3.Name = "_ignore3";
            _ignore3.Size = new System.Drawing.Size(51, 13);
            _ignore3.TabIndex = 2;
            _ignore3.Text = "Quân đội";
            // 
            // _ignore1
            // 
            _ignore1.AutoSize = true;
            _ignore1.Location = new System.Drawing.Point(5, 48);
            _ignore1.Name = "_ignore1";
            _ignore1.Size = new System.Drawing.Size(60, 13);
            _ignore1.TabIndex = 1;
            _ignore1.Text = "Thuộc tính";
            // 
            // _ignore0
            // 
            _ignore0.AutoSize = true;
            _ignore0.Location = new System.Drawing.Point(5, 23);
            _ignore0.Name = "_ignore0";
            _ignore0.Size = new System.Drawing.Size(45, 13);
            _ignore0.TabIndex = 0;
            _ignore0.Text = "Binh lực";
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
            this.heroList.Location = new System.Drawing.Point(5, 70);
            this.heroList.Name = "heroList";
            this.heroList.Size = new System.Drawing.Size(160, 134);
            this.heroList.TabIndex = 0;
            this.heroList.SelectedIndexChanged += new System.EventHandler(this.heroList_SelectedIndexChanged);
            // 
            // autoTrainCheck
            // 
            this.autoTrainCheck.AutoSize = true;
            this.autoTrainCheck.Location = new System.Drawing.Point(100, 12);
            this.autoTrainCheck.Name = "autoTrainCheck";
            this.autoTrainCheck.Size = new System.Drawing.Size(95, 17);
            this.autoTrainCheck.TabIndex = 1;
            this.autoTrainCheck.Text = "Tự động luyện";
            this.autoTrainCheck.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(6, 215);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 30);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Thêm";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(88, 215);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 30);
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
            this.selectedHeroList.Location = new System.Drawing.Point(5, 255);
            this.selectedHeroList.Name = "selectedHeroList";
            this.selectedHeroList.Size = new System.Drawing.Size(160, 134);
            this.selectedHeroList.TabIndex = 4;
            // 
            // slotLabel
            // 
            this.slotLabel.AutoSize = true;
            this.slotLabel.Location = new System.Drawing.Point(5, 45);
            this.slotLabel.Name = "slotLabel";
            this.slotLabel.Size = new System.Drawing.Size(107, 13);
            this.slotLabel.TabIndex = 5;
            this.slotLabel.Text = "Vị trí huấn luyện: 9/9";
            // 
            // tokenLabel
            // 
            this.tokenLabel.AutoSize = true;
            this.tokenLabel.Location = new System.Drawing.Point(135, 45);
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
            this.infoBox.Controls.Add(_ignore6);
            this.infoBox.Controls.Add(_ignore2);
            this.infoBox.Controls.Add(_ignore5);
            this.infoBox.Controls.Add(_ignore4);
            this.infoBox.Controls.Add(_ignore3);
            this.infoBox.Controls.Add(_ignore1);
            this.infoBox.Controls.Add(_ignore0);
            this.infoBox.Location = new System.Drawing.Point(175, 70);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(250, 200);
            this.infoBox.TabIndex = 7;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Tư Mã Sư Lv. 199";
            // 
            // info6Label
            // 
            this.info6Label.Location = new System.Drawing.Point(80, 170);
            this.info6Label.Name = "info6Label";
            this.info6Label.ReadOnly = true;
            this.info6Label.Size = new System.Drawing.Size(160, 20);
            this.info6Label.TabIndex = 13;
            this.info6Label.Text = "999999/999999";
            this.info6Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info5Label
            // 
            this.info5Label.Location = new System.Drawing.Point(80, 145);
            this.info5Label.Name = "info5Label";
            this.info5Label.ReadOnly = true;
            this.info5Label.Size = new System.Drawing.Size(160, 20);
            this.info5Label.TabIndex = 12;
            this.info5Label.Text = "Cấp 200 trở lên";
            this.info5Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info4Label
            // 
            this.info4Label.Location = new System.Drawing.Point(80, 120);
            this.info4Label.Name = "info4Label";
            this.info4Label.ReadOnly = true;
            this.info4Label.Size = new System.Drawing.Size(160, 20);
            this.info4Label.TabIndex = 11;
            this.info4Label.Text = "Phích Lịch Cửu Tiêu";
            this.info4Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info3Label
            // 
            this.info3Label.Location = new System.Drawing.Point(80, 95);
            this.info3Label.Name = "info3Label";
            this.info3Label.ReadOnly = true;
            this.info3Label.Size = new System.Drawing.Size(160, 20);
            this.info3Label.TabIndex = 10;
            this.info3Label.Text = "Lv20 - 10";
            this.info3Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info2Label
            // 
            this.info2Label.Location = new System.Drawing.Point(80, 70);
            this.info2Label.Name = "info2Label";
            this.info2Label.ReadOnly = true;
            this.info2Label.Size = new System.Drawing.Size(160, 20);
            this.info2Label.TabIndex = 9;
            this.info2Label.Text = "Phích Lịch Hoả Kỵ";
            this.info2Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info1Label
            // 
            this.info1Label.Location = new System.Drawing.Point(80, 45);
            this.info1Label.Name = "info1Label";
            this.info1Label.ReadOnly = true;
            this.info1Label.Size = new System.Drawing.Size(160, 20);
            this.info1Label.TabIndex = 8;
            this.info1Label.Text = "D199 K199 T199";
            this.info1Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info0Label
            // 
            this.info0Label.Location = new System.Drawing.Point(80, 20);
            this.info0Label.Name = "info0Label";
            this.info0Label.ReadOnly = true;
            this.info0Label.Size = new System.Drawing.Size(160, 20);
            this.info0Label.TabIndex = 7;
            this.info0Label.Text = "19999/19999";
            this.info0Label.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trainBox
            // 
            this.trainBox.Controls.Add(this.trainButton);
            this.trainBox.Controls.Add(this.timeModelList);
            this.trainBox.Location = new System.Drawing.Point(175, 280);
            this.trainBox.Name = "trainBox";
            this.trainBox.Size = new System.Drawing.Size(250, 50);
            this.trainBox.TabIndex = 8;
            this.trainBox.TabStop = false;
            this.trainBox.Text = "Luyện";
            // 
            // trainButton
            // 
            this.trainButton.Location = new System.Drawing.Point(165, 13);
            this.trainButton.Name = "trainButton";
            this.trainButton.Size = new System.Drawing.Size(75, 30);
            this.trainButton.TabIndex = 1;
            this.trainButton.Text = "Bắt đầu";
            this.trainButton.UseVisualStyleBackColor = true;
            this.trainButton.Click += new System.EventHandler(this.trainButton_Click);
            // 
            // timeModelList
            // 
            this.timeModelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeModelList.FormattingEnabled = true;
            this.timeModelList.Location = new System.Drawing.Point(8, 20);
            this.timeModelList.Name = "timeModelList";
            this.timeModelList.Size = new System.Drawing.Size(150, 21);
            this.timeModelList.TabIndex = 0;
            // 
            // guideBox
            // 
            this.guideBox.Controls.Add(this.guideButton);
            this.guideBox.Controls.Add(this.honorExpLabel);
            this.guideBox.Controls.Add(this.expPerMinLabel);
            this.guideBox.Controls.Add(this.remainingTimeLabel);
            this.guideBox.Controls.Add(this.stopButton);
            this.guideBox.Location = new System.Drawing.Point(175, 340);
            this.guideBox.Name = "guideBox";
            this.guideBox.Size = new System.Drawing.Size(250, 90);
            this.guideBox.TabIndex = 9;
            this.guideBox.TabStop = false;
            this.guideBox.Text = "Mãnh tiến";
            // 
            // guideButton
            // 
            this.guideButton.Location = new System.Drawing.Point(165, 50);
            this.guideButton.Name = "guideButton";
            this.guideButton.Size = new System.Drawing.Size(75, 30);
            this.guideButton.TabIndex = 5;
            this.guideButton.Text = "Mãnh tiến";
            this.guideButton.UseVisualStyleBackColor = true;
            this.guideButton.Click += new System.EventHandler(this.guideButton_Click);
            // 
            // honorExpLabel
            // 
            this.honorExpLabel.AutoSize = true;
            this.honorExpLabel.Location = new System.Drawing.Point(5, 64);
            this.honorExpLabel.Name = "honorExpLabel";
            this.honorExpLabel.Size = new System.Drawing.Size(121, 13);
            this.honorExpLabel.TabIndex = 4;
            this.honorExpLabel.Text = "600 C.Tích - 24588 Exp";
            // 
            // expPerMinLabel
            // 
            this.expPerMinLabel.AutoSize = true;
            this.expPerMinLabel.Location = new System.Drawing.Point(5, 42);
            this.expPerMinLabel.Name = "expPerMinLabel";
            this.expPerMinLabel.Size = new System.Drawing.Size(132, 13);
            this.expPerMinLabel.TabIndex = 3;
            this.expPerMinLabel.Text = "Kinh nghiệm mỗi phút: 999";
            // 
            // remainingTimeLabel
            // 
            this.remainingTimeLabel.AutoSize = true;
            this.remainingTimeLabel.Location = new System.Drawing.Point(5, 20);
            this.remainingTimeLabel.Name = "remainingTimeLabel";
            this.remainingTimeLabel.Size = new System.Drawing.Size(133, 13);
            this.remainingTimeLabel.TabIndex = 2;
            this.remainingTimeLabel.Text = "Thời gian còn lại: 23:59:59";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(165, 13);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 30);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Kết thúc";
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(5, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 30);
            this.refreshButton.TabIndex = 10;
            this.refreshButton.Text = "Làm mới";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // oneSecondTimer
            // 
            this.oneSecondTimer.Enabled = true;
            this.oneSecondTimer.Interval = 1000;
            this.oneSecondTimer.Tick += new System.EventHandler(this.oneSecondTimer_Tick);
            // 
            // trainingTimer
            // 
            this.trainingTimer.Interval = 5000;
            this.trainingTimer.Tick += new System.EventHandler(this.trainingTimer_Tick);
            // 
            // HeroTrainingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.refreshButton);
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
            this.Size = new System.Drawing.Size(430, 435);
            this.Load += new System.EventHandler(this.HeroTrainingView_Load);
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
        private System.Windows.Forms.Label remainingTimeLabel;
        private System.Windows.Forms.Button guideButton;
        private System.Windows.Forms.Label honorExpLabel;
        private System.Windows.Forms.Label expPerMinLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Timer oneSecondTimer;
        private System.Windows.Forms.Timer trainingTimer;
    }
}
