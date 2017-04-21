using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
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

            ConfigManager.Instance.LoadConfigs();
            LoadConfigs();
            LoadClients();
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e) {
            Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private List<IClient> FindSelectedClients() {
            var items = clientList.SelectedItems;
            return items.Cast<OLVListItem>().Select(item => (IClient) item.RowObject).ToList();
        }

        private List<int> FindSelectedIndices() {
            var items = clientList.SelectedIndices;
            return items.Cast<int>().ToList();
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

        private async Task LogOut(List<IClient> clients) {
            var logoutTasks = clients.Select(item => item.LogOut());
            await Task.WhenAll(logoutTasks);
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
            await LogOut(selectedClients);
        }

        private async void loginAllButton_Click(object sender, EventArgs e) {
            var clients = ClientManager.Instance.Clients;
            await LogIn(clients, true);
        }

        private async void logoutAllButton_Click(object sender, EventArgs e) {
            var clients = ClientManager.Instance.Clients;
            await LogOut(clients);
        }

        private void addButton_Click(object sender, EventArgs e) {
            var dialog = new AccountView();
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }

            var config = new ClientConfig();
            config.ServerId = Convert.ToInt32(dialog.ServerId);
            config.Username = dialog.Username;
            config.Password = dialog.Password;

            AddConfig(config);
        }

        private void removeButton_Click(object sender, EventArgs e) {
            var selectedIndices = FindSelectedIndices();
            selectedIndices.Reverse();
            foreach (var index in selectedIndices) {
                RemoveConfig(index);
            }
            clientList.SelectedObjects = null;
        }

        private void changeButton_Click(object sender, EventArgs e) {
            var selectedIndices = FindSelectedIndices();
            if (selectedIndices.Count == 0) {
                return;
            }

            const string MultipleValues = "<Nhiều giá trị>";
            var serverIds = new HashSet<int>();
            var usernames = new HashSet<string>();
            var passwords = new HashSet<string>();
            foreach (var index in selectedIndices) {
                var config = ConfigManager.Instance.Configs[index];
                serverIds.Add(config.ServerId);
                usernames.Add(config.Username);
                passwords.Add(config.Password);
            }

            var serverId = (serverIds.Count == 1 ? serverIds.First().ToString() : MultipleValues);
            var username = (usernames.Count == 1 ? usernames.First() : MultipleValues);
            var password = (passwords.Count == 1 ? passwords.First() : MultipleValues);

            var dialog = new AccountView();
            dialog.ServerId = serverId;
            dialog.Username = username;
            dialog.Password = password;
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }

            var newServerId = dialog.ServerId;
            var newUsername = dialog.Username;
            var newPassword = dialog.Password;

            bool changed = false;
            foreach (var index in selectedIndices) {
                var config = ConfigManager.Instance.Configs[index];
                var clientConfig = ClientManager.Instance.Clients[index].Config;
                if (!newServerId.Equals(serverId)) {
                    config.ServerId = clientConfig.ServerId = Convert.ToInt32(newServerId);
                    changed = true;
                }
                if (!newUsername.Equals(username)) {
                    config.Username = clientConfig.Username = newUsername;
                    changed = true;
                }
                if (!newPassword.Equals(password)) {
                    config.Password = clientConfig.Password = newPassword;
                    changed = true;
                }
            }
            if (changed) {
                ConfigManager.Instance.Flush();
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            var selectedIndices = FindSelectedIndices();
            foreach (var index in selectedIndices) {
                var client = ClientManager.Instance.Clients[index];
                ConfigManager.Instance.ReplaceConfig(index, client.Config);
            }
            ConfigManager.Instance.Flush();
        }

        private void MainView_Load(object sender, EventArgs e) {

        }

        private void AddConfig(ClientConfig config) {
            AddClient(config);
            ConfigManager.Instance.AddConfig(config);
            ConfigManager.Instance.Flush();
        }

        /// <summary>
        /// Adds a new client with the specified config.
        /// </summary>
        /// <param name="config">The config of the client.</param>
        private void AddClient(ClientConfig config) {
            var client = new ClientView();
            client.Config = config;

            ClientManager.Instance.AddClient(client);
            AddClient(client);
        }

        /// <summary>
        /// Adds the specified client to the view.
        /// </summary>
        /// <param name="client">The client to be added.</param>
        private void AddClient(ClientView client) {
            Controls.Add(client);
            client.Dock = DockStyle.Fill;
            client.BringToFront();
            client.StateChanged += OnClientStateChanged;
            clientList.SetObjects(ClientManager.Instance.Clients, true);
        }

        private void RemoveConfig(int index) {
            RemoveClient(index);
            ConfigManager.Instance.RemoveConfig(index);
            ConfigManager.Instance.Flush();
        }

        private void RemoveClient(int index) {
            var client = ClientManager.Instance.Clients[index];
            ClientManager.Instance.RemoveClient(client);
            RemoveClient((ClientView) client);
        }

        /// <summary>
        /// Remove the specified client from the view.
        /// </summary>
        /// <param name="client">The client to be removed.</param>
        private void RemoveClient(ClientView client) {
            Controls.Remove(client);
            clientList.SetObjects(ClientManager.Instance.Clients, true);
        }

        private void moveUpButton_Click(object sender, EventArgs e) {
            var selectedIndices = FindSelectedIndices();
            if (selectedIndices.Count == 0) {
                return;
            }
            foreach (var index in selectedIndices) {
                if (index - 1 >= 0) {
                    ConfigManager.Instance.MoveConfigUp(index);
                    ClientManager.Instance.MoveClientUp(index);
                }
            }
            clientList.SetObjects(ClientManager.Instance.Clients, true);
            ConfigManager.Instance.Flush();
        }

        private void moveDownButton_Click(object sender, EventArgs e) {
            var selectedIndices = FindSelectedIndices();
            if (selectedIndices.Count == 0) {
                return;
            }
            selectedIndices.Reverse();
            foreach (var index in selectedIndices) {
                if (index + 1 < ClientManager.Instance.Clients.Count) {
                    ConfigManager.Instance.MoveConfigDown(index);
                    ClientManager.Instance.MoveClientDown(index);
                }
            }
            clientList.SetObjects(ClientManager.Instance.Clients, true);
            ConfigManager.Instance.Flush();
        }

        private void OnClientStateChanged(object sender, ClientState state) {
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

        private void LoadClients() {
            SuspendLayout();
            foreach (var config in ConfigManager.Instance.Configs) {
                AddClient(config);
            }
            ResumeLayout();
        }

        private void LoadSize() {
            var array = ConfigManager.Instance.Settings.GetArray("main_window_size");
            if (array.Count > 0) {
                var width = Int32.Parse(array[0]);
                var height = Int32.Parse(array[1]);
                Size = new Size(width, height);
            }
        }

        private void LoadLocation() {
            var array = ConfigManager.Instance.Settings.GetArray("main_window_location");
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
            ConfigManager.Instance.Settings.PutArray("main_window_size", array);
        }

        private void MainView_LocationChanged(object sender, EventArgs e) {
            var array = new List<int>();
            array.Add(Location.X);
            array.Add(Location.Y);
            ConfigManager.Instance.Settings.PutArray("main_window_location", array);
        }

        private void MainView_FormClosed(object sender, FormClosedEventArgs e) {
            ConfigManager.Instance.Flush();
        }

        private void autoQuestButton_Click(object sender, EventArgs e) {
            var selectedClients = ClientManager.Instance.Clients;
            foreach (var client in selectedClients) {
                client.EnableAutoQuest();
                Task.Delay(1000);
            }
        }

        private void autoReportQuestButton_Click(object sender, EventArgs e) {
            var selectedClients = ClientManager.Instance.Clients;
            foreach (var client in selectedClients) {
                client.ReportAutoQuest();
                Task.Delay(1000);
            }
        }

        private void autoGoldDailyButton_Click(object sender, EventArgs e){
            var selectedClients = ClientManager.Instance.Clients;
            foreach (var client in selectedClients) {
                client.UseGoldDaily();
                Task.Delay(1000);
            }
        }

        private void autoSwapSnoutButton_Click(object sender, EventArgs e)
        {
            var view = new AutoSnoutView();
            view.Show();
        }
    }
}