using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading;
using System.Diagnostics;

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
            var selectedClients = new List<ClientView>();
            var items = clientList.SelectedItems;
            foreach (var item in items) {
                var client = (ClientView) item;
                selectedClients.Add(client);
            }

            int one = selectedClients.Count / 3;
            int start1 = 0;
            int end1 = one;

            int two = (selectedClients.Count - one) / 2;
            int start2 = one;
            int end2 = one + two;

            int start3 = end2;
            int end3 = selectedClients.Count;

            ImproveLogin(start1, end1, selectedClients);
            ImproveLogin(start2, end2, selectedClients);
            ImproveLogin(start3, end3, selectedClients);
        }

        public async void ImproveLogin(int start, int end, List<ClientView> arr)
        {
            for (int i = start; i < end; i++)
            {
                await arr[i].LogIn();
            }
        }

        private async void logoutButton_Click(object sender, EventArgs e) {
            var selectedClients = new List<ClientView>();
            var items = clientList.SelectedItems;
            foreach (var item in items)
            {
                var client = (ClientView)item;
                selectedClients.Add(client);
            }
            foreach (var client in selectedClients)
            {
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

        private void loginAllButton_Click(object sender, EventArgs e) {
            var clients = ClientManager.Instance.Clients;

            int one = clients.Count / 3;
            int start1 = 0;
            int end1 = one;

            int two = (clients.Count - one) / 2;
            int start2 = one;
            int end2 = one + two;

            int start3 = end2;
            int end3 = clients.Count;

            ImproveLogin(start1, end1, clients);
            ImproveLogin(start2, end2, clients);
            ImproveLogin(start3, end3, clients);

            //foreach (var client in clients) {
            //    await client.LogIn();
            //}
        }
    }
}