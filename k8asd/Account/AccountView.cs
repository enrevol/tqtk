using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k8asd {
    public partial class AccountView : Form {
        public AccountView() {
            InitializeComponent();
        }

        public string ServerId {
            get { return serverInput.Text; }
            set { serverInput.Text = value.ToString(); }
        }

        public string Username {
            get { return usernameInput.Text; }
            set { usernameInput.Text = value; }
        }

        public string Password {
            get { return passwordInput.Text; }
            set { passwordInput.Text = value; }
        }

        private void okButton_Click(object sender, EventArgs e) {
            Save();
        }

        private void serverInput_KeyPress(object sender, KeyPressEventArgs e) {
            int serverId;
            if (!Int32.TryParse(serverInput.Text, out serverId)) {
                e.Handled = false;
            }
        }

        private void AccountView_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Save();
            } else if (e.KeyCode == Keys.Escape) {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void Save() {
            if (serverInput.Text.Length > 0 &&
                            usernameInput.Text.Length > 0 &&
                            passwordInput.Text.Length > 0) {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
