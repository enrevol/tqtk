namespace k8asd
{
    partial class InstituteView
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.techList = new BrightIdeasSoftware.ObjectListView();
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.levelColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.extraColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.valueColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.techList)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(345, 290);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 17);
            this.checkBox1.TabIndex = 103;
            this.checkBox1.Text = "Auto";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(5, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 30);
            this.refreshButton.TabIndex = 105;
            this.refreshButton.Text = "Làm mới";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // techList
            // 
            this.techList.AllColumns.Add(this.nameColumn);
            this.techList.AllColumns.Add(this.levelColumn);
            this.techList.AllColumns.Add(this.extraColumn);
            this.techList.AllColumns.Add(this.valueColumn);
            this.techList.CellEditUseWholeCell = false;
            this.techList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.levelColumn,
            this.extraColumn,
            this.valueColumn});
            this.techList.Cursor = System.Windows.Forms.Cursors.Default;
            this.techList.FullRowSelect = true;
            this.techList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.techList.Location = new System.Drawing.Point(6, 40);
            this.techList.MultiSelect = false;
            this.techList.Name = "techList";
            this.techList.Scrollable = false;
            this.techList.SelectColumnsOnRightClick = false;
            this.techList.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.None;
            this.techList.ShowGroups = false;
            this.techList.Size = new System.Drawing.Size(300, 220);
            this.techList.TabIndex = 106;
            this.techList.UseCompatibleStateImageBehavior = false;
            this.techList.View = System.Windows.Forms.View.Details;
            this.techList.SelectedIndexChanged += new System.EventHandler(this.techList_SelectedIndexChanged);
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "";
            this.nameColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nameColumn.MaximumWidth = 120;
            this.nameColumn.MinimumWidth = 120;
            this.nameColumn.Text = "Tên";
            this.nameColumn.Width = 120;
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
            // extraColumn
            // 
            this.extraColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.extraColumn.MaximumWidth = 60;
            this.extraColumn.MinimumWidth = 60;
            this.extraColumn.Text = "Hiệu quả";
            this.extraColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // valueColumn
            // 
            this.valueColumn.HeaderTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.valueColumn.MaximumWidth = 60;
            this.valueColumn.MinimumWidth = 60;
            this.valueColumn.Text = "Hiện tại";
            this.valueColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InstituteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.techList);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.checkBox1);
            this.Name = "InstituteView";
            this.Size = new System.Drawing.Size(475, 365);
            ((System.ComponentModel.ISupportInitialize)(this.techList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button refreshButton;
        private BrightIdeasSoftware.ObjectListView techList;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn levelColumn;
        private BrightIdeasSoftware.OLVColumn extraColumn;
        private BrightIdeasSoftware.OLVColumn valueColumn;
    }
}
