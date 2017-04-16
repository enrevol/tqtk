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
using System.Drawing;
using Nito.AsyncEx;

namespace k8asd {
    public partial class MainView : Form {
        private AsyncLock loginLock;

        public MainView() {
            InitializeComponent();

            loginLock = new AsyncLock();

            ConfigManager.Instance.LoadConfigs();
            LoadConfigs();

            descriptionColumn.AspectGetter = (obj) => {
                var client = (IClient) obj;
                var config = client.Config;
                return String.Format("{0}_{1}", config.ServerId, config.Username);
            };
            statusColumn.ImageGetter = (obj) => {
                var client = (IClient) obj;
                switch (client.State) {
                case ClientState.Connected: return "connected";
                case ClientState.Connecting: return "disconnected";
                case ClientState.Disconnected: return "disconnected";
                case ClientState.Disconnecting: return "disconnected";
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
            using (await loginLock.LockAsync()) {
                const int ThreadCount = 5;
                var loggingInTasks = new List<Task>();
                foreach (var client in clients) {
                    Debug.Assert(loggingInTasks.Count <= ThreadCount);
                    if (loggingInTasks.Count == ThreadCount) {
                        var loggedInTask = await Task.WhenAny(loggingInTasks);
                        loggingInTasks.Remove(loggedInTask);
                    } else {
                        await Task.Delay(500);
                    }
                    loggingInTasks.Add(client.LogIn(blocking));
                }
                await Task.WhenAll(loggingInTasks);
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
                var config = new ClientConfig();
                config.ServerId = dialog.ServerId;
                config.Username = dialog.Username;
                config.Password = dialog.Password;
                AddClient(config);
                ConfigManager.Instance.SaveConfig(config);
            }
        }

        private void removeButton_Click(object sender, EventArgs e) {
            var selectedClients = FindSelectedClients();
            foreach (var client in selectedClients) {
                RemoveClient(client);
                ConfigManager.Instance.DeleteConfig(client.Config);
            }
            clientList.SelectedObjects = null;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            var selectedClients = FindSelectedClients();
            foreach (var client in selectedClients) {
                ConfigManager.Instance.SaveConfig(client.Config);
            }
        }

        private void MainView_Load(object sender, EventArgs e) {
            SuspendLayout();
            foreach (var config in ConfigManager.Instance.Configs) {
                AddClient(config);
            }
            ResumeLayout();
        }

        private void AddClient(ClientConfig config) {
            var client = new ClientView();
            client.Config = config;
            client.Dock = DockStyle.Fill;
            Controls.Add(client);
            ClientManager.Instance.AddClient(client);
            client.BringToFront();
            clientList.SetObjects(ClientManager.Instance.Clients);
            client.StateChanged += OnClientStateChanged;
        }

        private void RemoveClient(IClient client) {
            ClientManager.Instance.RemoveClient(client);
            Controls.Remove((ClientView) client);
            clientList.SetObjects(ClientManager.Instance.Clients);
        }

        private void OnClientStateChanged(object sender, ClientState status) {
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

        private async void logoutAllButton_Click(object sender, EventArgs e) {
            var clients = ClientManager.Instance.Clients;
            foreach (var client in clients) {
                await client.LogOut();
            }
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

        private void autoReherseButton_Click(object sender, EventArgs e) {
            var view = new AutoReherseView();
            view.Show();
        }

        private void LoadConfigs() {
            LoadSize();
            LoadLocation();
        }

        private void LoadSize() {
            var array = ConfigManager.Instance.GetArray("main_window_size");
            if (array.Count > 0) {
                var width = Int32.Parse(array[0]);
                var height = Int32.Parse(array[1]);
                Size = new Size(width, height);
            }
        }

        private void LoadLocation() {
            var array = ConfigManager.Instance.GetArray("main_window_location");
            if (array.Count > 0) {
                var x = Int32.Parse(array[0]);
                var y = Int32.Parse(array[1]);
                Location = new Point(x, y);
            }
        }

        private void MainView_SizeChanged(object sender, EventArgs e) {
            var array = new List<int>();
            array.Add(Size.Width);
            array.Add(Size.Height);
            ConfigManager.Instance.PutArray("main_window_size", array);
        }

        private void MainView_LocationChanged(object sender, EventArgs e) {
            var array = new List<int>();
            array.Add(Location.X);
            array.Add(Location.Y);
            ConfigManager.Instance.PutArray("main_window_location", array);
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e) {
            ConfigManager.Instance.Flush();
        }

        private void autoQuestButton_Click(object sender, EventArgs e)
        {
            var selectedClients = ClientManager.Instance.Clients;
            foreach (var client in selectedClients)
            {
                client.EnableAutoQuest();
                Task.Delay(1000);
            }
        }

        private void autoReportQuestButton_Click(object sender, EventArgs e)
        {
            var selectedClients = ClientManager.Instance.Clients;
            foreach (var client in selectedClients)
            {
                client.ReportAutoQuest();
                Task.Delay(1000);
            }
        }
    }
}