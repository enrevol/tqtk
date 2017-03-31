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
using BrightIdeasSoftware;

namespace k8asd {
    public partial class MainView : Form {
        public MainView() {
            InitializeComponent();

            descriptionColumn.AspectGetter = (obj) => {
                var client = (ClientView) obj;
                return client.Configuration.ToString();
            };
            statusColumn.ImageGetter = (obj) => {
                var client = (IClient) obj;
                switch (client.ConnectionStatus) {
                case ConnectionStatus.Connected: return "connected";
                case ConnectionStatus.Connecting: return "disconnected";
                case ConnectionStatus.Disconnected: return "disconnected";
                case ConnectionStatus.Disconnecting: return "disconnected";
                }
                return String.Empty;
            };
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e) {
            Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private List<IClient> FindSelectedClients() {
            var selectedClients = new List<IClient>();
            var items = clientList.SelectedItems;
            foreach (var item in items) {
                var client = (IClient) ((OLVListItem) item).RowObject;
                selectedClients.Add(client);
            }
            return selectedClients;
        }

        private async Task LogIn(List<IClient> clients, bool blocking) {
            const int ThreadCount = 3;
            for (int i = 0; i < clients.Count; i += ThreadCount) {
                var tasks = new List<Task>();
                for (int j = 0; j < ThreadCount && i + j < clients.Count; ++j) {
                    tasks.Add(clients[i + j].LogIn(blocking));
                }
                await Task.WhenAll(tasks);
            }
        }

        private async void loginButton_Click(object sender, EventArgs e) {
            var selectedClients = FindSelectedClients();
            await LogIn(selectedClients, true);
        }

        private async void parallelLoginButton_Click(object sender, EventArgs e) {
            var selectedClients = FindSelectedClients();
            await LogIn(selectedClients, false);
        }

        private async void logoutButton_Click(object sender, EventArgs e) {
            var selectedClients = FindSelectedClients();
            foreach (var client in selectedClients) {
                await client.LogOut();
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
            var selectedClients = FindSelectedClients();
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

        private void RemoveClient(IClient client) {
            ClientManager.Instance.Remove(client);
            AccountManager.Instance.DeleteConfiguration(
              ((ClientView) client).Configuration.ServerId,
              ((ClientView) client).Configuration.Username);
            Controls.Remove((ClientView) client);
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
            await LogIn(clients, true);
        }

        private void autoWeaveButton_Click(object sender, EventArgs e) {
            var view = new AutoWeaveView();
            view.Show();
        }

        private void autoSwapButton_Click(object sender, EventArgs e) {
            var view = new AutoSwap();
            view.Show();
        }

        private void autoMerchantButton_Click(object sender, EventArgs e) {
            var view = new AutoMerchantView();
            view.Show();
        }
    }
}