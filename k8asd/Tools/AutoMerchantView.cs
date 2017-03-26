using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using BrightIdeasSoftware;

namespace k8asd {
    public partial class AutoMerchantView : Form {
        private Dictionary<int, IClient> clients;
        private Dictionary<int, MerchantInfo> infos;
        private List<int> playerIds;

        private bool isRefreshing;

        public AutoMerchantView() {
            InitializeComponent();

            isRefreshing = false;

            clients = new Dictionary<int, IClient>();
            infos = new Dictionary<int, MerchantInfo>();
            playerIds = new List<int>();

            playerNameColumn.AspectGetter = obj => clients[(int) obj].PlayerName;
            playerMerchantColumn.AspectGetter = obj => infos[(int) obj].OwnedMerchant.GetMerchantName();

            var playerMerchantColumns = new OLVColumn[] {
                playerMerchant0Column,
                playerMerchant1Column,
                playerMerchant2Column,
                playerMerchant3Column,
                playerMerchant4Column,
                playerMerchant5Column,
                playerMerchant6Column,
                playerMerchant7Column,
                playerMerchant8Column,
                playerMerchant9Column,
                playerMerchant10Column,
                playerMerchant11Column,
            };
            for (int i = 0; i < playerMerchantColumns.Length; ++i) {
                var column = playerMerchantColumns[i];
                int merchantId = i + 1; // Copy by value.
                column.AspectGetter = obj => {
                    var info = infos[(int) obj];
                    return info.Merchants.Contains((Merchant) merchantId);
                };
            }
        }

        private async void refreshPlayerButton_Click(object sender, EventArgs e) {
            await RefreshPlayersAsync(FindConnectedClients());
        }

        public void LogInfo(string newMessage) {
            /*
            if (logBox.Text.Length > 0) {
                logBox.Text += Environment.NewLine;
            }
            logBox.Text += String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            if (logBox.Lines.Length > LineLimit) {
                logBox.Text = logBox.Text.Remove(0, logBox.Lines[0].Length + Environment.NewLine.Length);
            }
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
            */
        }

        private List<IClient> FindConnectedClients() {
            var clients = ClientManager.Instance.Clients;
            var connectedClients = new List<IClient>();
            foreach (var client in clients) {
                if (client.ConnectionStatus == ConnectionStatus.Connected) {
                    connectedClients.Add(client);
                }
            }
            return connectedClients;
        }

        private async Task<bool> RefreshPlayersAsync(List<IClient> connectedClients) {
            if (isRefreshing) {
                LogInfo("Đang làm mới, không thể làm mới!");
                return false;
            }
            LogInfo("Bắt đầu làm mới...");
            isRefreshing = true;

            clients.Clear();
            infos.Clear();
            playerIds.Clear();
            playerList.Items.Clear();

            foreach (var client in connectedClients) {
                var info = await client.RefreshMerchantAsync();
                if (info == null) {
                    continue;
                }

                var playerId = client.PlayerId;
                playerIds.Add(playerId);
                clients.Add(playerId, client);
                infos.Add(playerId, info);
                playerList.SetObjects(playerIds);
            }

            LogInfo("Làm mới hoàn thành!");
            isRefreshing = false;
            return true;
        }
    }
}
