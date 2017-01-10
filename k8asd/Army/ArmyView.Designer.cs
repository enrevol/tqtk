namespace k8asd {
    partial class ArmyView {
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
            this.armyList = new System.Windows.Forms.ListBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // armyList
            // 
            this.armyList.FormattingEnabled = true;
            this.armyList.Location = new System.Drawing.Point(5, 40);
            this.armyList.Name = "armyList";
            this.armyList.Size = new System.Drawing.Size(200, 225);
            this.armyList.TabIndex = 0;
            this.armyList.SelectedIndexChanged += new System.EventHandler(this.armyList_SelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(5, 5);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 30);
            this.refreshButton.TabIndex = 11;
            this.refreshButton.Text = "Làm mới";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(210, 40);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(200, 225);
            this.listBox1.TabIndex = 12;
            // 
            // ArmyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.armyList);
            this.Name = "ArmyView";
            this.Size = new System.Drawing.Size(617, 479);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox armyList;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ListBox listBox1;
    }
}
