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
        public MainView() {
            InitializeComponent();

            descriptionColumn.AspectGetter = (obj) => {
                var client = (ClientView) obj;
                return client.Configuration.ToString();
            };
            statusColumn.AspectGetter = (obj) => {
                var client = (IClient) obj;
                /*
                switch (client.ConnectionStatus) {
                case ConnectionStatus.Connected: return "Đã kết nối";
                case ConnectionStatus.Connecting: return "Đang kết nối...";
                case ConnectionStatus.Disconnected: return "Không kết nối";
                case ConnectionStatus.Disconnecting: return "Đang ngắt kết nối...";
                }
                */
                return String.Empty;
            };
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e) {
            Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private async Task LogIn(List<IClient> clients) {
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
            var selectedClients = new List<IClient>();
            var items = clientList.SelectedItems;
            foreach (var item in items) {
                var client = (IClient) item;
                selectedClients.Add(client);
            }
            await LogIn(selectedClients);
        }

        private void logoutButton_Click(object sender, EventArgs e) {
            var selectedClients = new List<IClient>();
            var items = clientList.SelectedItems;
            foreach (var item in items) {
                var client = (IClient) item;
                selectedClients.Add(client);
            }
            foreach (var client in selectedClients) {
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
            clientList.SelectedObjects = null;
        }

        private void MainView_Load(object sender, EventArgs e) {
            var configs = AccountManager.Instance.LoadConfigurations();
            SuspendLayout();
            foreach (var config in configs) {
                AddClient(config);
            }
            ResumeLayout();
        }

        private void AddClient(Configuration config) {
            var client = new ClientView();
            client.Configuration = config;
            client.Dock = DockStyle.Fill;
            Controls.Add(client);
            ClientManager.Instance.Add(client);
            client.BringToFront();
            clientList.SetObjects(ClientManager.Instance.Clients);
            client.ConnectionStatusChanged += OnConnectionStatusChanged;
        }

        private void RemoveClient(ClientView client) {
            ClientManager.Instance.Remove(client);
            AccountManager.Instance.DeleteConfiguration(
                client.Configuration.ServerId,
                client.Configuration.Username);
            Controls.Remove(client);
            clientList.SetObjects(ClientManager.Instance.Clients);
        }

        private void OnConnectionStatusChanged(object sender, ConnectionStatus status) {
            clientList.RefreshObject(sender);
        }

        private void clientList_SelectedIndexChanged(object sender, EventArgs e) {
            var item = clientList.SelectedItem;
            if (item != null) {
                SuspendLayout();
                foreach (var client in ClientManager.Instance.Clients) {
                    ((ClientView) client).Visible = false;
                }
                ((ClientView) item.RowObject).Visible = true;
                ResumeLayout();
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