namespace k8asd.Map {
    partial class MapView {
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
            this.refreshTeamButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // refreshTeamButton
            // 
            this.refreshTeamButton.Location = new System.Drawing.Point(6, 6);
            this.refreshTeamButton.Name = "refreshTeamButton";
            this.refreshTeamButton.Size = new System.Drawing.Size(100, 30);
            this.refreshTeamButton.TabIndex = 28;
            this.refreshTeamButton.Text = "Làm mới khu vực";
            this.refreshTeamButton.UseVisualStyleBackColor = true;
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.refreshTeamButton);
            this.Name = "MapView";
            this.Size = new System.Drawing.Size(541, 440);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshTeamButton;
    }
}
