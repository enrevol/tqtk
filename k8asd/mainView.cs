using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace k8asd {
    public partial class MainView : Form {
        private BindingList<AccountInfo> accounts;
        private Dictionary<AccountInfo, ClientView> clients;
        private FileSystemWatcher fileWatcher;

        public MainView() {
            InitializeComponent();
            accounts = new BindingList<AccountInfo>();
            accountList.DataSource = accounts;
            clients = new Dictionary<AccountInfo, ClientView>();
            fileWatcher = new FileSystemWatcher();
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e) {
            Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void loginButton_Click(object sender, EventArgs e) {
            var items = accountList.SelectedItems;

        }

        private void logoutButton_Click(object sender, EventArgs e) {

        }

        private void addButton_Click(object sender, EventArgs e) {
            var dialog = new AccountView();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                var serverId = dialog.ServerId;
                var username = dialog.Username;
                var password = dialog.Password;
                var account = new AccountInfo(serverId, username, password);
                if (!accounts.Contains(account)) {
                    accounts.Add(account);
                }
            }
        }

        private void removeButton_Click(object sender, EventArgs e) {
            var selectedAccounts = new List<AccountInfo>();
            foreach (var item in accountList.SelectedItems) {
                selectedAccounts.Add((AccountInfo) item);
            }
            foreach (var account in selectedAccounts) {
                accounts.Remove(account);
            }
            accountList.ClearSelected();
        }
    }
}