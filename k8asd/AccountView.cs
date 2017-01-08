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

        public int ServerId {
            get { return Int32.Parse(serverInput.Text); }
        }

        public string Username {
            get { return usernameInput.Text; }
        }

        public string Password {
            get { return passwordInput.Text; }
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
