namespace k8asd {
    partial class ChatLogView {
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
            this.channelList = new System.Windows.Forms.ComboBox();
            this.logBox = new System.Windows.Forms.TextBox();
            this.chatInput = new System.Windows.Forms.TextBox();
            this.modeButton = new System.Windows.Forms.Button();
            this.logTabList = new System.Windows.Forms.TabControl();
            this.logTab0 = new System.Windows.Forms.TabPage();
            this.logTab1 = new System.Windows.Forms.TabPage();
            this.logTab2 = new System.Windows.Forms.TabPage();
            this.logTab3 = new System.Windows.Forms.TabPage();
            this.logTab4 = new System.Windows.Forms.TabPage();
            this.logTab5 = new System.Windows.Forms.TabPage();
            this.logTabList.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelList
            // 
            this.channelList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.channelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelList.FormattingEnabled = true;
            this.channelList.Items.AddRange(new object[] {
            "Thế giới",
            "Quốc gia",
            "Khu vực",
            "Bang",
            "Chiến"});
            this.channelList.Location = new System.Drawing.Point(0, 179);
            this.channelList.Name = "channelList";
            this.channelList.Size = new System.Drawing.Size(65, 21);
            this.channelList.TabIndex = 0;
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(0, 22);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(350, 155);
            this.logBox.TabIndex = 1;
            // 
            // chatInput
            // 
            this.chatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatInput.Location = new System.Drawing.Point(66, 180);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(245, 20);
            this.chatInput.TabIndex = 2;
            this.chatInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatInput_KeyDown);
            this.chatInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chatInput_KeyPress);
            // 
            // modeButton
            // 
            this.modeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.modeButton.Location = new System.Drawing.Point(311, 178);
            this.modeButton.Name = "modeButton";
            this.modeButton.Size = new System.Drawing.Size(40, 23);
            this.modeButton.TabIndex = 3;
            this.modeButton.Text = "S";
            this.modeButton.UseVisualStyleBackColor = true;
            // 
            // logTabList
            // 
            this.logTabList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTabList.Controls.Add(this.logTab0);
            this.logTabList.Controls.Add(this.logTab1);
            this.logTabList.Controls.Add(this.logTab2);
            this.logTabList.Controls.Add(this.logTab3);
            this.logTabList.Controls.Add(this.logTab4);
            this.logTabList.Controls.Add(this.logTab5);
            this.logTabList.Location = new System.Drawing.Point(0, 0);
            this.logTabList.Name = "logTabList";
            this.logTabList.SelectedIndex = 0;
            this.logTabList.Size = new System.Drawing.Size(350, 20);
            this.logTabList.TabIndex = 4;
            this.logTabList.SelectedIndexChanged += new System.EventHandler(this.logTabList_SelectedIndexChanged);
            // 
            // logTab0
            // 
            this.logTab0.Location = new System.Drawing.Point(4, 22);
            this.logTab0.Name = "logTab0";
            this.logTab0.Padding = new System.Windows.Forms.Padding(3);
            this.logTab0.Size = new System.Drawing.Size(342, 0);
            this.logTab0.TabIndex = 0;
            this.logTab0.Text = "Thế giới";
            this.logTab0.UseVisualStyleBackColor = true;
            // 
            // logTab1
            // 
            this.logTab1.Location = new System.Drawing.Point(4, 22);
            this.logTab1.Name = "logTab1";
            this.logTab1.Padding = new System.Windows.Forms.Padding(3);
            this.logTab1.Size = new System.Drawing.Size(342, 0);
            this.logTab1.TabIndex = 1;
            this.logTab1.Text = "Quốc gia";
            this.logTab1.UseVisualStyleBackColor = true;
            // 
            // logTab2
            // 
            this.logTab2.Location = new System.Drawing.Point(4, 22);
            this.logTab2.Name = "logTab2";
            this.logTab2.Size = new System.Drawing.Size(342, 0);
            this.logTab2.TabIndex = 2;
            this.logTab2.Text = "Khu vực";
            this.logTab2.UseVisualStyleBackColor = true;
            // 
            // logTab3
            // 
            this.logTab3.Location = new System.Drawing.Point(4, 22);
            this.logTab3.Name = "logTab3";
            this.logTab3.Size = new System.Drawing.Size(342, 0);
            this.logTab3.TabIndex = 3;
            this.logTab3.Text = "Bang";
            this.logTab3.UseVisualStyleBackColor = true;
            // 
            // logTab4
            // 
            this.logTab4.Location = new System.Drawing.Point(4, 22);
            this.logTab4.Name = "logTab4";
            this.logTab4.Size = new System.Drawing.Size(342, 0);
            this.logTab4.TabIndex = 4;
            this.logTab4.Text = "Chiến";
            this.logTab4.UseVisualStyleBackColor = true;
            // 
            // logTab5
            // 
            this.logTab5.Location = new System.Drawing.Point(4, 22);
            this.logTab5.Name = "logTab5";
            this.logTab5.Size = new System.Drawing.Size(342, 0);
            this.logTab5.TabIndex = 5;
            this.logTab5.Text = "Tất cả";
            this.logTab5.UseVisualStyleBackColor = true;
            // 
            // ChatLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.logTabList);
            this.Controls.Add(this.modeButton);
            this.Controls.Add(this.chatInput);
            this.Controls.Add(this.channelList);
            this.Name = "ChatLogView";
            this.Size = new System.Drawing.Size(350, 200);
            this.logTabList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox channelList;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.TextBox chatInput;
        private System.Windows.Forms.Button modeButton;
        private System.Windows.Forms.TabControl logTabList;
        private System.Windows.Forms.TabPage logTab1;
        private System.Windows.Forms.TabPage logTab2;
        private System.Windows.Forms.TabPage logTab3;
        private System.Windows.Forms.TabPage logTab4;
        private System.Windows.Forms.TabPage logTab5;
        private System.Windows.Forms.TabPage logTab0;
    }
}
