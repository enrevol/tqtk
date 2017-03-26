namespace k8asd {
    partial class PacketView {
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.sendButton = new System.Windows.Forms.Button();
            this.commandInput = new System.Windows.Forms.TextBox();
            this.param1Input = new System.Windows.Forms.TextBox();
            this.param2Input = new System.Windows.Forms.TextBox();
            this.replyBox = new System.Windows.Forms.TextBox();
            this.param3Input = new System.Windows.Forms.TextBox();
            this.param4Input = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 60);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(68, 13);
            label1.TabIndex = 6;
            label1.Text = "Command ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 85);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(43, 13);
            label2.TabIndex = 7;
            label2.Text = "Param1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(20, 110);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 13);
            label3.TabIndex = 8;
            label3.Text = "Param2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(20, 135);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(43, 13);
            label4.TabIndex = 9;
            label4.Text = "Param3";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(10, 10);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(100, 30);
            this.sendButton.TabIndex = 0;
            this.sendButton.Text = "Gửi";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // commandInput
            // 
            this.commandInput.Location = new System.Drawing.Point(100, 57);
            this.commandInput.Name = "commandInput";
            this.commandInput.Size = new System.Drawing.Size(100, 20);
            this.commandInput.TabIndex = 1;
            // 
            // param1Input
            // 
            this.param1Input.Location = new System.Drawing.Point(100, 82);
            this.param1Input.Name = "param1Input";
            this.param1Input.Size = new System.Drawing.Size(100, 20);
            this.param1Input.TabIndex = 2;
            // 
            // param2Input
            // 
            this.param2Input.Location = new System.Drawing.Point(100, 107);
            this.param2Input.Name = "param2Input";
            this.param2Input.Size = new System.Drawing.Size(100, 20);
            this.param2Input.TabIndex = 3;
            // 
            // replyBox
            // 
            this.replyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replyBox.Location = new System.Drawing.Point(15, 190);
            this.replyBox.Multiline = true;
            this.replyBox.Name = "replyBox";
            this.replyBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.replyBox.Size = new System.Drawing.Size(300, 165);
            this.replyBox.TabIndex = 6;
            // 
            // param3Input
            // 
            this.param3Input.Location = new System.Drawing.Point(100, 132);
            this.param3Input.Name = "param3Input";
            this.param3Input.Size = new System.Drawing.Size(100, 20);
            this.param3Input.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(20, 160);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(43, 13);
            label5.TabIndex = 10;
            label5.Text = "Param4";
            // 
            // param4Input
            // 
            this.param4Input.Location = new System.Drawing.Point(100, 157);
            this.param4Input.Name = "param4Input";
            this.param4Input.Size = new System.Drawing.Size(100, 20);
            this.param4Input.TabIndex = 5;
            // 
            // PacketView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.param4Input);
            this.Controls.Add(label5);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.param3Input);
            this.Controls.Add(this.replyBox);
            this.Controls.Add(this.param2Input);
            this.Controls.Add(this.param1Input);
            this.Controls.Add(this.commandInput);
            this.Controls.Add(this.sendButton);
            this.Name = "PacketView";
            this.Size = new System.Drawing.Size(330, 370);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox commandInput;
        private System.Windows.Forms.TextBox param1Input;
        private System.Windows.Forms.TextBox param2Input;
        private System.Windows.Forms.TextBox replyBox;
        private System.Windows.Forms.TextBox param3Input;
        private System.Windows.Forms.TextBox param4Input;
    }
}
