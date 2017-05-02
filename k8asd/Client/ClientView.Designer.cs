using System.Windows.Forms;

namespace k8asd {
    partial class ClientView : UserControl {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cooldownView = new k8asd.CooldownView();
            this.mcuView = new k8asd.McuView();
            this.infoView = new k8asd.InfoView();
            this.systemLogView = new k8asd.SystemLogView();
            this.SuspendLayout();
            // 
            // cooldownView
            // 
            this.cooldownView.Location = new System.Drawing.Point(0, 100);
            this.cooldownView.Name = "cooldownView";
            this.cooldownView.Size = new System.Drawing.Size(310, 120);
            this.cooldownView.TabIndex = 30;
            // 
            // mcuView
            // 
            this.mcuView.Location = new System.Drawing.Point(0, 220);
            this.mcuView.Name = "mcuView";
            this.mcuView.Size = new System.Drawing.Size(310, 22);
            this.mcuView.TabIndex = 29;
            // 
            // infoView
            // 
            this.infoView.Location = new System.Drawing.Point(0, 0);
            this.infoView.Name = "infoView";
            this.infoView.Size = new System.Drawing.Size(310, 100);
            this.infoView.TabIndex = 28;
            // 
            // systemLogView
            // 
            this.systemLogView.Location = new System.Drawing.Point(7, 265);
            this.systemLogView.Name = "systemLogView";
            this.systemLogView.Size = new System.Drawing.Size(347, 180);
            this.systemLogView.TabIndex = 31;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.systemLogView);
            this.Controls.Add(this.cooldownView);
            this.Controls.Add(this.mcuView);
            this.Controls.Add(this.infoView);
            this.Name = "ClientView";
            this.Size = new System.Drawing.Size(357, 548);
            this.Load += new System.EventHandler(this.ClientView_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private InfoView infoView;
        private McuView mcuView;
        private CooldownView cooldownView;
        private SystemLogView systemLogView;
    }
}

