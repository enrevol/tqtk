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
            this.autoTrainCheck = new System.Windows.Forms.CheckBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.trainingTimer = new System.Windows.Forms.Timer(this.components);
            this.heroList = new BrightIdeasSoftware.ObjectListView();
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.levelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.shiftLevelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.autoTrainColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.autoGuideColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.heroList)).BeginInit();
            this.SuspendLayout();
            // 
            // autoTrainCheck
            // 
            this.autoTrainCheck.AutoSize = true;
            this.autoTrainCheck.Location = new System.Drawing.Point(90, 12);
            this.autoTrainCheck.Name = "autoTrainCheck";
            this.autoTrainCheck.Size = new System.Drawing.Size(159, 17);
            this.autoTrainCheck.TabIndex = 1;
            this.autoTrainCheck.Text = "Tự động luyện và mãnh tiến";
            this.autoTrainCheck.UseVisualStyleBackColor = true;
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
            // trainingTimer
            // 
            this.trainingTimer.Interval = 1000;
            this.trainingTimer.Tick += new System.EventHandler(this.trainingTimer_Tick);
            // 
            // heroList
            // 
            this.heroList.AllColumns.Add(this.nameColumn);
            this.heroList.AllColumns.Add(this.levelColumn);
            this.heroList.AllColumns.Add(this.shiftLevelColumn);
            this.heroList.AllColumns.Add(this.autoTrainColumn);
            this.heroList.AllColumns.Add(this.autoGuideColumn);
            this.heroList.CellEditUseWholeCell = false;
            this.heroList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.levelColumn,
            this.shiftLevelColumn,
            this.autoTrainColumn,
            this.autoGuideColumn});
            this.heroList.Cursor = System.Windows.Forms.Cursors.Default;
            this.heroList.FullRowSelect = true;
            this.heroList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.heroList.Location = new System.Drawing.Point(5, 40);
            this.heroList.MultiSelect = false;
            this.heroList.Name = "heroList";
            this.heroList.SelectColumnsOnRightClick = false;
            this.heroList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.heroList.ShowGroups = false;
            this.heroList.Size = new System.Drawing.Size(420, 150);
            this.heroList.TabIndex = 32;
            this.heroList.UseCompatibleStateImageBehavior = false;
            this.heroList.View = System.Windows.Forms.View.Details;
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "";
            this.nameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameColumn.MaximumWidth = 150;
            this.nameColumn.MinimumWidth = 150;
            this.nameColumn.Text = "Tên";
            this.nameColumn.Width = 150;
            // 
            // levelColumn
            // 
            this.levelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.levelColumn.MaximumWidth = 40;
            this.levelColumn.MinimumWidth = 40;
            this.levelColumn.Text = "Cấp";
            this.levelColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.levelColumn.Width = 40;
            // 
            // shiftLevelColumn
            // 
            this.shiftLevelColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.shiftLevelColumn.MaximumWidth = 60;
            this.shiftLevelColumn.MinimumWidth = 60;
            this.shiftLevelColumn.Text = "C. Sinh";
            this.shiftLevelColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // autoTrainColumn
            // 
            this.autoTrainColumn.CheckBoxes = true;
            this.autoTrainColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.autoTrainColumn.MaximumWidth = 60;
            this.autoTrainColumn.MinimumWidth = 60;
            this.autoTrainColumn.Text = "Tự luyện";
            this.autoTrainColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // autoGuideColumn
            // 
            this.autoGuideColumn.CheckBoxes = true;
            this.autoGuideColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.autoGuideColumn.MaximumWidth = 80;
            this.autoGuideColumn.MinimumWidth = 80;
            this.autoGuideColumn.Text = "Tự mãnh tiến";
            this.autoGuideColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.autoGuideColumn.Width = 80;
            // 
            // HeroTrainingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.heroList);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.autoTrainCheck);
            this.Name = "HeroTrainingView";
            this.Size = new System.Drawing.Size(430, 195);
            this.Load += new System.EventHandler(this.HeroTrainingView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heroList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox autoTrainCheck;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Timer trainingTimer;
        private BrightIdeasSoftware.ObjectListView heroList;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn levelColumn;
        private BrightIdeasSoftware.OLVColumn shiftLevelColumn;
        private BrightIdeasSoftware.OLVColumn autoTrainColumn;
        private BrightIdeasSoftware.OLVColumn autoGuideColumn;
    }
}
