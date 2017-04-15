namespace k8asd
{
    partial class QuestView
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
            this.components = new System.ComponentModel.Container();
            this.chkQuest = new System.Windows.Forms.CheckBox();
            this.timerQuest = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // chkQuest
            // 
            this.chkQuest.AutoSize = true;
            this.chkQuest.Location = new System.Drawing.Point(17, 13);
            this.chkQuest.Name = "chkQuest";
            this.chkQuest.Size = new System.Drawing.Size(157, 17);
            this.chkQuest.TabIndex = 0;
            this.chkQuest.Text = "Tự làm nhiệm vụ hằng ngày";
            this.chkQuest.UseVisualStyleBackColor = true;
            this.chkQuest.CheckedChanged += new System.EventHandler(this.chkQuest_CheckedChanged);
            // 
            // timerQuest
            // 
            this.timerQuest.Interval = 5000;
            this.timerQuest.Tick += new System.EventHandler(this.timerQuest_Tick);
            // 
            // QuestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkQuest);
            this.Name = "QuestView";
            this.Size = new System.Drawing.Size(285, 151);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkQuest;
        private System.Windows.Forms.Timer timerQuest;
    }
}
