namespace k8asd {
    partial class OutsideView {
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
            this.autoDrillBox = new System.Windows.Forms.CheckBox();
            this.miningTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // autoDrillBox
            // 
            this.autoDrillBox.AutoSize = true;
            this.autoDrillBox.Location = new System.Drawing.Point(10, 10);
            this.autoDrillBox.Name = "autoDrillBox";
            this.autoDrillBox.Size = new System.Drawing.Size(142, 17);
            this.autoDrillBox.TabIndex = 0;
            this.autoDrillBox.Text = "Tự động khoan (thường)";
            this.autoDrillBox.UseVisualStyleBackColor = true;
            // 
            // miningTimer
            // 
            this.miningTimer.Enabled = true;
            this.miningTimer.Interval = 1000;
            this.miningTimer.Tick += new System.EventHandler(this.miningTimer_Tick);
            // 
            // OutsideView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.autoDrillBox);
            this.Name = "OutsideView";
            this.Size = new System.Drawing.Size(162, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox autoDrillBox;
        private System.Windows.Forms.Timer miningTimer;
    }
}
