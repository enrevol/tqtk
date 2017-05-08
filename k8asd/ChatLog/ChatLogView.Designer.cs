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
            this.chatInput = new System.Windows.Forms.TextBox();
            this.logTabList = new System.Windows.Forms.TabControl();
            this.logTab0 = new System.Windows.Forms.TabPage();
            this.logBox0 = new k8asd.FastRichTextBox();
            this.logTab1 = new System.Windows.Forms.TabPage();
            this.logBox1 = new k8asd.FastRichTextBox();
            this.logTab2 = new System.Windows.Forms.TabPage();
            this.logBox2 = new k8asd.FastRichTextBox();
            this.logTab3 = new System.Windows.Forms.TabPage();
            this.logBox3 = new k8asd.FastRichTextBox();
            this.logTab4 = new System.Windows.Forms.TabPage();
            this.logBox4 = new k8asd.FastRichTextBox();
            this.logTab5 = new System.Windows.Forms.TabPage();
            this.logBox5 = new k8asd.FastRichTextBox();
            this.logTab6 = new System.Windows.Forms.TabPage();
            this.logAllBox = new k8asd.FastRichTextBox();
            this.autoScrollBox = new System.Windows.Forms.CheckBox();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.logTabList.SuspendLayout();
            this.logTab0.SuspendLayout();
            this.logTab1.SuspendLayout();
            this.logTab2.SuspendLayout();
            this.logTab3.SuspendLayout();
            this.logTab4.SuspendLayout();
            this.logTab5.SuspendLayout();
            this.logTab6.SuspendLayout();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // channelList
            // 
            this.channelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.channelList.FormattingEnabled = true;
            this.channelList.Items.AddRange(new object[] {
            "Thế giới",
            "Quốc gia",
            "Khu vực",
            "Bang",
            "Chiến"});
            this.channelList.Location = new System.Drawing.Point(5, 28);
            this.channelList.Name = "channelList";
            this.channelList.Size = new System.Drawing.Size(65, 21);
            this.channelList.TabIndex = 0;
            // 
            // chatInput
            // 
            this.chatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.chatInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(204)))));
            this.chatInput.Location = new System.Drawing.Point(75, 28);
            this.chatInput.Name = "chatInput";
            this.chatInput.Size = new System.Drawing.Size(503, 20);
            this.chatInput.TabIndex = 2;
            this.chatInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatInput_KeyDown);
            this.chatInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chatInput_KeyPress);
            // 
            // logTabList
            // 
            this.logTabList.Controls.Add(this.logTab0);
            this.logTabList.Controls.Add(this.logTab1);
            this.logTabList.Controls.Add(this.logTab2);
            this.logTabList.Controls.Add(this.logTab3);
            this.logTabList.Controls.Add(this.logTab4);
            this.logTabList.Controls.Add(this.logTab5);
            this.logTabList.Controls.Add(this.logTab6);
            this.logTabList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logTabList.Location = new System.Drawing.Point(0, 0);
            this.logTabList.Name = "logTabList";
            this.logTabList.SelectedIndex = 0;
            this.logTabList.Size = new System.Drawing.Size(584, 211);
            this.logTabList.TabIndex = 4;
            this.logTabList.SelectedIndexChanged += new System.EventHandler(this.logTabList_SelectedIndexChanged);
            // 
            // logTab0
            // 
            this.logTab0.Controls.Add(this.logBox0);
            this.logTab0.Location = new System.Drawing.Point(4, 22);
            this.logTab0.Name = "logTab0";
            this.logTab0.Size = new System.Drawing.Size(576, 185);
            this.logTab0.TabIndex = 6;
            this.logTab0.Text = "Mật";
            // 
            // logBox0
            // 
            this.logBox0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.logBox0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox0.Location = new System.Drawing.Point(0, 0);
            this.logBox0.Name = "logBox0";
            this.logBox0.ReadOnly = true;
            this.logBox0.Size = new System.Drawing.Size(576, 185);
            this.logBox0.TabIndex = 5;
            this.logBox0.TabStop = false;
            this.logBox0.Text = "";
            this.logBox0.WordWrap = false;
            // 
            // logTab1
            // 
            this.logTab1.Controls.Add(this.logBox1);
            this.logTab1.Location = new System.Drawing.Point(4, 22);
            this.logTab1.Name = "logTab1";
            this.logTab1.Size = new System.Drawing.Size(576, 185);
            this.logTab1.TabIndex = 0;
            this.logTab1.Text = "Thế giới";
            // 
            // logBox1
            // 
            this.logBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.logBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox1.Location = new System.Drawing.Point(0, 0);
            this.logBox1.Name = "logBox1";
            this.logBox1.ReadOnly = true;
            this.logBox1.Size = new System.Drawing.Size(576, 185);
            this.logBox1.TabIndex = 4;
            this.logBox1.TabStop = false;
            this.logBox1.Text = "";
            this.logBox1.WordWrap = false;
            // 
            // logTab2
            // 
            this.logTab2.Controls.Add(this.logBox2);
            this.logTab2.Location = new System.Drawing.Point(4, 22);
            this.logTab2.Name = "logTab2";
            this.logTab2.Size = new System.Drawing.Size(576, 185);
            this.logTab2.TabIndex = 1;
            this.logTab2.Text = "Quốc gia";
            // 
            // logBox2
            // 
            this.logBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.logBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox2.Location = new System.Drawing.Point(0, 0);
            this.logBox2.Name = "logBox2";
            this.logBox2.ReadOnly = true;
            this.logBox2.Size = new System.Drawing.Size(576, 185);
            this.logBox2.TabIndex = 5;
            this.logBox2.TabStop = false;
            this.logBox2.Text = "";
            this.logBox2.WordWrap = false;
            // 
            // logTab3
            // 
            this.logTab3.Controls.Add(this.logBox3);
            this.logTab3.Location = new System.Drawing.Point(4, 22);
            this.logTab3.Name = "logTab3";
            this.logTab3.Size = new System.Drawing.Size(576, 185);
            this.logTab3.TabIndex = 2;
            this.logTab3.Text = "Khu vực";
            // 
            // logBox3
            // 
            this.logBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.logBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox3.Location = new System.Drawing.Point(0, 0);
            this.logBox3.Name = "logBox3";
            this.logBox3.ReadOnly = true;
            this.logBox3.Size = new System.Drawing.Size(576, 185);
            this.logBox3.TabIndex = 5;
            this.logBox3.TabStop = false;
            this.logBox3.Text = "";
            this.logBox3.WordWrap = false;
            // 
            // logTab4
            // 
            this.logTab4.Controls.Add(this.logBox4);
            this.logTab4.Location = new System.Drawing.Point(4, 22);
            this.logTab4.Name = "logTab4";
            this.logTab4.Size = new System.Drawing.Size(576, 185);
            this.logTab4.TabIndex = 3;
            this.logTab4.Text = "Bang";
            // 
            // logBox4
            // 
            this.logBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.logBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox4.Location = new System.Drawing.Point(0, 0);
            this.logBox4.Name = "logBox4";
            this.logBox4.ReadOnly = true;
            this.logBox4.Size = new System.Drawing.Size(576, 185);
            this.logBox4.TabIndex = 5;
            this.logBox4.TabStop = false;
            this.logBox4.Text = "";
            this.logBox4.WordWrap = false;
            // 
            // logTab5
            // 
            this.logTab5.Controls.Add(this.logBox5);
            this.logTab5.Location = new System.Drawing.Point(4, 22);
            this.logTab5.Name = "logTab5";
            this.logTab5.Size = new System.Drawing.Size(576, 185);
            this.logTab5.TabIndex = 4;
            this.logTab5.Text = "Chiến";
            // 
            // logBox5
            // 
            this.logBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.logBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logBox5.Location = new System.Drawing.Point(0, 0);
            this.logBox5.Name = "logBox5";
            this.logBox5.ReadOnly = true;
            this.logBox5.Size = new System.Drawing.Size(576, 185);
            this.logBox5.TabIndex = 5;
            this.logBox5.TabStop = false;
            this.logBox5.Text = "";
            this.logBox5.WordWrap = false;
            // 
            // logTab6
            // 
            this.logTab6.Controls.Add(this.logAllBox);
            this.logTab6.Location = new System.Drawing.Point(4, 22);
            this.logTab6.Name = "logTab6";
            this.logTab6.Size = new System.Drawing.Size(576, 185);
            this.logTab6.TabIndex = 5;
            this.logTab6.Text = "Tất cả";
            // 
            // logAllBox
            // 
            this.logAllBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(38)))));
            this.logAllBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logAllBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logAllBox.Location = new System.Drawing.Point(0, 0);
            this.logAllBox.Name = "logAllBox";
            this.logAllBox.ReadOnly = true;
            this.logAllBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logAllBox.Size = new System.Drawing.Size(576, 185);
            this.logAllBox.TabIndex = 5;
            this.logAllBox.TabStop = false;
            this.logAllBox.Text = "";
            // 
            // autoScrollBox
            // 
            this.autoScrollBox.AutoSize = true;
            this.autoScrollBox.Checked = true;
            this.autoScrollBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScrollBox.Location = new System.Drawing.Point(5, 5);
            this.autoScrollBox.Name = "autoScrollBox";
            this.autoScrollBox.Size = new System.Drawing.Size(66, 17);
            this.autoScrollBox.TabIndex = 6;
            this.autoScrollBox.Text = "Tự cuộn";
            this.autoScrollBox.UseVisualStyleBackColor = true;
            // 
            // inputPanel
            // 
            this.inputPanel.Controls.Add(this.autoScrollBox);
            this.inputPanel.Controls.Add(this.chatInput);
            this.inputPanel.Controls.Add(this.channelList);
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputPanel.Location = new System.Drawing.Point(0, 211);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(584, 55);
            this.inputPanel.TabIndex = 7;
            // 
            // ChatLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.logTabList);
            this.Controls.Add(this.inputPanel);
            this.Name = "ChatLogView";
            this.Size = new System.Drawing.Size(584, 266);
            this.logTabList.ResumeLayout(false);
            this.logTab0.ResumeLayout(false);
            this.logTab1.ResumeLayout(false);
            this.logTab2.ResumeLayout(false);
            this.logTab3.ResumeLayout(false);
            this.logTab4.ResumeLayout(false);
            this.logTab5.ResumeLayout(false);
            this.logTab6.ResumeLayout(false);
            this.inputPanel.ResumeLayout(false);
            this.inputPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox channelList;
        private System.Windows.Forms.TextBox chatInput;
        private System.Windows.Forms.TabControl logTabList;
        private System.Windows.Forms.TabPage logTab2;
        private System.Windows.Forms.TabPage logTab3;
        private System.Windows.Forms.TabPage logTab4;
        private System.Windows.Forms.TabPage logTab5;
        private System.Windows.Forms.TabPage logTab6;
        private System.Windows.Forms.TabPage logTab1;
        private System.Windows.Forms.CheckBox autoScrollBox;
        private FastRichTextBox logBox1;
        private FastRichTextBox logBox2;
        private FastRichTextBox logBox3;
        private FastRichTextBox logBox4;
        private FastRichTextBox logBox5;
        private FastRichTextBox logAllBox;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.TabPage logTab0;
        private FastRichTextBox logBox0;
    }
}
