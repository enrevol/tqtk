using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace k8asd {
    public partial class MainView : Form {
        private BindingList<ClientView> clients;

        public MainView() {
            InitializeComponent();

            clients = new BindingList<ClientView>();
            clientList.DataSource = clients;
            clientList.DisplayMember = "Configuration";
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e) {
            Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void loginButton_Click(object sender, EventArgs e) {
            var items = clientList.SelectedItems;
            foreach (var item in items) {
                var client = (ClientView) item;
                client.LogIn();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e) {

        }

        private void addButton_Click(object sender, EventArgs e) {
            var dialog = new AccountView();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                var config = new Configuration();
                config.ServerId = dialog.ServerId;
                config.Username = dialog.Username;
                config.Password = dialog.Password;
                AccountManager.Instance.SaveConfiguration(config);
                var client = new ClientView();
                client.Configuration = config;
                client.Dock = DockStyle.Fill;
                clients.Add(client);
                Controls.Add(client);
            }
        }

        private void removeButton_Click(object sender, EventArgs e) {
            var selectedClients = new List<ClientView>();
            foreach (var item in clientList.SelectedItems) {
                selectedClients.Add((ClientView) item);
            }
            foreach (var account in selectedClients) {
                clients.Remove(account);
            }
            clientList.ClearSelected();
        }

        private void MainView_Load(object sender, EventArgs e) {
            var configs = AccountManager.Instance.LoadConfigurations();
            foreach (var config in configs) {
                var client = new ClientView();
                client.Configuration = config;
                client.Dock = DockStyle.Fill;
                clients.Add(client);
                Controls.Add(client);
            }
        }
    }
}