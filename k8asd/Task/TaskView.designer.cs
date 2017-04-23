namespace k8asd
{
    partial class TaskView
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
            this.dailyTaskCheck = new System.Windows.Forms.CheckBox();
            this.taskTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // dailyTaskCheck
            // 
            this.dailyTaskCheck.AutoSize = true;
            this.dailyTaskCheck.Location = new System.Drawing.Point(17, 13);
            this.dailyTaskCheck.Name = "dailyTaskCheck";
            this.dailyTaskCheck.Size = new System.Drawing.Size(157, 17);
            this.dailyTaskCheck.TabIndex = 0;
            this.dailyTaskCheck.Text = "Tự làm nhiệm vụ hằng ngày";
            this.dailyTaskCheck.UseVisualStyleBackColor = true;
            this.dailyTaskCheck.CheckedChanged += new System.EventHandler(this.chkQuest_CheckedChanged);
            // 
            // taskTimer
            // 
            this.taskTimer.Interval = 5000;
            this.taskTimer.Tick += new System.EventHandler(this.taskTimer_Tick);
            // 
            // TaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dailyTaskCheck);
            this.Name = "TaskView";
            this.Size = new System.Drawing.Size(285, 151);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox dailyTaskCheck;
        private System.Windows.Forms.Timer taskTimer;
    }
}
