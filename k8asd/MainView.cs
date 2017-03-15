using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

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


        private async Task LogIn(List<ClientView> clients) {
            const int ThreadCount = 3;
            for (int i = 0; i < clients.Count; i += ThreadCount) {
                var tasks = new List<Task>();
                for (int j = 0; j < ThreadCount && i + j < clients.Count; ++j) {
                    tasks.Add(clients[i + j].LogIn());
                }
                await Task.WhenAll(tasks);
            }
        }

        private async void loginButton_Click(object sender, EventArgs e) {
            var selectedClients = new List<ClientView>();
            var items = clientList.SelectedItems;
            foreach (var item in items) {
                var client = (ClientView) item;
                selectedClients.Add(client);
            }
            await LogIn(selectedClients);
        }

        private void logoutButton_Click(object sender, EventArgs e) {
            var selectedClients = new List<ClientView>();
            var items = clientList.SelectedItems;
            foreach (var item in items)
            {
                var client = (ClientView)item;
                selectedClients.Add(client);
            }
            foreach (var client in selectedClients)
            {
                client.LogOut();
            }
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
                AddClient(config);
            }
        }

        private void removeButton_Click(object sender, EventArgs e) {
            var selectedClients = new List<ClientView>();
            foreach (var item in clientList.SelectedItems) {
                selectedClients.Add((ClientView) item);
            }
            foreach (var client in selectedClients) {
                RemoveClient(client);
            }
            clientList.ClearSelected();
        }

        private void MainView_Load(object sender, EventArgs e) {
            var configs = AccountManager.Instance.LoadConfigurations();
            foreach (var config in configs) {
                AddClient(config);
            }
        }

        private void AddClient(Configuration config) {
            var client = new ClientView();
            client.Configuration = config;
            client.Dock = DockStyle.Fill;
            clients.Add(client);
            Controls.Add(client);
            ClientManager.Instance.Add(client);
            client.BringToFront();
        }

        private void RemoveClient(ClientView client) {
            clients.Remove(client);
            ClientManager.Instance.Remove(client);
            AccountManager.Instance.DeleteConfiguration(
                client.Configuration.ServerId,
                client.Configuration.Username);
            Controls.Remove(client);
        }

        private void clientList_SelectedIndexChanged(object sender, EventArgs e) {
            var item = clientList.SelectedItem;
            if (item != null) {
                foreach (var client in clients) {
                    client.Visible = false;
                }
                ((ClientView) item).Visible = true;
            }
        }

        private void autoArenaButton_Click(object sender, EventArgs e) {
            var view = new AutoArenaView();
            view.Show();
        }

        private async void loginAllButton_Click(object sender, EventArgs e) {
            var clients = ClientManager.Instance.Clients;
            await LogIn(clients);
        }

        private void autoWeaveButton_Click(object sender, EventArgs e) {
            var view = new AutoWeaveView();
            view.Show();
        }
    }
}