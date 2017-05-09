namespace k8asd
{
    partial class DailyTaskView
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
            this.doFoodTaskCheck = new System.Windows.Forms.CheckBox();
            this.doImproveTaskCheck = new System.Windows.Forms.CheckBox();
            this.doAttackNpcTaskCheck = new System.Windows.Forms.CheckBox();
            this.doImposeTaskCheck = new System.Windows.Forms.CheckBox();
            this.doUpgradeTaskCheck = new System.Windows.Forms.CheckBox();
            this.taskTypesPanel = new System.Windows.Forms.GroupBox();
            this.taskTypesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // dailyTaskCheck
            // 
            this.dailyTaskCheck.AutoSize = true;
            this.dailyTaskCheck.Location = new System.Drawing.Point(10, 10);
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
            // doFoodTaskCheck
            // 
            this.doFoodTaskCheck.AutoSize = true;
            this.doFoodTaskCheck.Location = new System.Drawing.Point(10, 19);
            this.doFoodTaskCheck.Name = "doFoodTaskCheck";
            this.doFoodTaskCheck.Size = new System.Drawing.Size(163, 17);
            this.doFoodTaskCheck.TabIndex = 1;
            this.doFoodTaskCheck.Text = "Mua bán lúa (mua/bán 1 lúa)";
            this.doFoodTaskCheck.UseVisualStyleBackColor = true;
            // 
            // doImproveTaskCheck
            // 
            this.doImproveTaskCheck.AutoSize = true;
            this.doImproveTaskCheck.Location = new System.Drawing.Point(10, 42);
            this.doImproveTaskCheck.Name = "doImproveTaskCheck";
            this.doImproveTaskCheck.Size = new System.Drawing.Size(193, 17);
            this.doImproveTaskCheck.TabIndex = 2;
            this.doImproveTaskCheck.Text = "Cải tiến (cải tiến xong giữ chỉ số cũ)";
            this.doImproveTaskCheck.UseVisualStyleBackColor = true;
            // 
            // doAttackNpcTaskCheck
            // 
            this.doAttackNpcTaskCheck.AutoSize = true;
            this.doAttackNpcTaskCheck.Location = new System.Drawing.Point(10, 88);
            this.doAttackNpcTaskCheck.Name = "doAttackNpcTaskCheck";
            this.doAttackNpcTaskCheck.Size = new System.Drawing.Size(203, 17);
            this.doAttackNpcTaskCheck.TabIndex = 3;
            this.doAttackNpcTaskCheck.Text = "Chinh chiến (đánh Nguỵ Tục - Lữ Bố)";
            this.doAttackNpcTaskCheck.UseVisualStyleBackColor = true;
            // 
            // doImposeTaskCheck
            // 
            this.doImposeTaskCheck.AutoSize = true;
            this.doImposeTaskCheck.Location = new System.Drawing.Point(10, 65);
            this.doImposeTaskCheck.Name = "doImposeTaskCheck";
            this.doImposeTaskCheck.Size = new System.Drawing.Size(165, 17);
            this.doImposeTaskCheck.TabIndex = 4;
            this.doImposeTaskCheck.Text = "Thu thuế (không tăng cường)";
            this.doImposeTaskCheck.UseVisualStyleBackColor = true;
            // 
            // doUpgradeTaskCheck
            // 
            this.doUpgradeTaskCheck.AutoSize = true;
            this.doUpgradeTaskCheck.Location = new System.Drawing.Point(10, 111);
            this.doUpgradeTaskCheck.Name = "doUpgradeTaskCheck";
            this.doUpgradeTaskCheck.Size = new System.Drawing.Size(178, 17);
            this.doUpgradeTaskCheck.TabIndex = 5;
            this.doUpgradeTaskCheck.Text = "Nâng cấp trang bị (vũ khí trắng)";
            this.doUpgradeTaskCheck.UseVisualStyleBackColor = true;
            // 
            // taskTypesPanel
            // 
            this.taskTypesPanel.Controls.Add(this.doFoodTaskCheck);
            this.taskTypesPanel.Controls.Add(this.doUpgradeTaskCheck);
            this.taskTypesPanel.Controls.Add(this.doImproveTaskCheck);
            this.taskTypesPanel.Controls.Add(this.doAttackNpcTaskCheck);
            this.taskTypesPanel.Controls.Add(this.doImposeTaskCheck);
            this.taskTypesPanel.Location = new System.Drawing.Point(10, 35);
            this.taskTypesPanel.Name = "taskTypesPanel";
            this.taskTypesPanel.Size = new System.Drawing.Size(220, 138);
            this.taskTypesPanel.TabIndex = 6;
            this.taskTypesPanel.TabStop = false;
            this.taskTypesPanel.Text = "Cấu hình loại nhiệm vụ";
            // 
            // DailyTaskView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.taskTypesPanel);
            this.Controls.Add(this.dailyTaskCheck);
            this.Name = "DailyTaskView";
            this.Size = new System.Drawing.Size(240, 180);
            this.taskTypesPanel.ResumeLayout(false);
            this.taskTypesPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox dailyTaskCheck;
        private System.Windows.Forms.Timer taskTimer;
        private System.Windows.Forms.CheckBox doFoodTaskCheck;
        private System.Windows.Forms.CheckBox doImproveTaskCheck;
        private System.Windows.Forms.CheckBox doAttackNpcTaskCheck;
        private System.Windows.Forms.CheckBox doImposeTaskCheck;
        private System.Windows.Forms.CheckBox doUpgradeTaskCheck;
        private System.Windows.Forms.GroupBox taskTypesPanel;
    }
}
