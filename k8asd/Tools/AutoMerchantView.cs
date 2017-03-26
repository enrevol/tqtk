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

        private class FoundPlayer {
            public string AreaName { get; private set; }
            public int ScopeId { get; private set; }
            public string PlayerName { get; private set; }
            public int PlayerId { get; private set; }
            public Merchant Merchant { get; private set; }
            public bool AutoPass { get; private set; }

            public FoundPlayer(string areaName, int scopeId,
                string playerName, int playerId, Merchant merchant, bool autoPass) {
                AreaName = areaName;
                ScopeId = scopeId;
                PlayerName = playerName;
                PlayerId = playerId;
                Merchant = merchant;
                AutoPass = autoPass;
            }
        };

        private List<FoundPlayer> foundPlayers;

        private bool isSearching;
        private bool isRefreshing;

        public AutoMerchantView() {
            InitializeComponent();

            isSearching = false;
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

            foundPlayers = new List<FoundPlayer>();
            foundPlayerAreaColumn.AspectGetter = obj => ((FoundPlayer) obj).AreaName;
            foundPlayerScopeColumn.AspectGetter = obj => ((FoundPlayer) obj).ScopeId;
            foundPlayerNameColumn.AspectGetter = obj => ((FoundPlayer) obj).PlayerName;
            foundPlayerMerchantColumn.AspectGetter = obj => ((FoundPlayer) obj).Merchant.GetMerchantName();
            foundPlayerAutoMerchantColumn.AspectGetter = obj => ((FoundPlayer) obj).AutoPass;
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

        private async void searchButton_Click(object sender, EventArgs e) {
            await SearchPlayerAsync();
        }

        private async Task<bool> SearchPlayerAsync() {
            if (isSearching) {
                return false;
            }

            var areaIds = new List<int>();
            areaIds.Add(21); // Nhữ Nam.
            areaIds.Add(22); // Hán Trung.
            areaIds.Add(23); // Hạ Bì.
            areaIds.Add(24); // Trần Lưu.
            areaIds.Add(25); // Thượng Đông.
            areaIds.Add(26); // Từ Châu.
            areaIds.Add(27); // Uyển.
            areaIds.Add(28); // Tân Dã.
            areaIds.Add(29); // Thọ Xuân.
            areaIds.Add(30); // Hứa Xương.
            areaIds.Add(31); // Tương Dương.
            areaIds.Add(32); // Giang Lăng.
            areaIds.Add(33); // Trường An.
            areaIds.Add(33); // Trường An.
            areaIds.Add(34); // Vũ Lăng.
            areaIds.Add(35); // Giang Hạ.
            areaIds.Add(36); // Hàn Dương.
            areaIds.Add(37); // Vũ Uy.
            areaIds.Add(38); // Hợp Phì.
            areaIds.Add(39); // Dương Đô.

            foundPlayers.Clear();
            foundPlayerList.Items.Clear();

            try {
                isSearching = true;
                var client = clients[playerIds[0]];
                foreach (var areaId in areaIds) {
                    var initialScope = await client.RefreshAreaAsync(areaId);
                    if (initialScope == null) {
                        return false;
                    }
                    await SearchPlayers(client, initialScope);
                    for (int scopeId = initialScope.Id + 1; scopeId <= initialScope.Count; ++scopeId) {
                        var scope = await client.RefreshScopeAsync(areaId, scopeId);
                        if (scope == null) {
                            return false;
                        }
                        await SearchPlayers(client, scope);
                    }
                }

            } finally {
                isSearching = false;
            }
            return true;
        }

        private async Task SearchPlayers(IPacketWriter writer, Scope scope) {
            foreach (var city in scope.Cities) {
                await Task.Delay(20);
                var player = await SearchPlayer(writer, scope, city);
                if (player == null) {
                    continue;
                }
                foundPlayers.Add(player);
                foundPlayerList.SetObjects(foundPlayers);
            }
        }

        private async Task<FoundPlayer> SearchPlayer(IPacketWriter writer, Scope scope, City city) {
            var cityDetail = await writer.RefreshCityAsync(scope.AreaId, scope.Id, city.Index);
            if (cityDetail == null) {
                return null;
            }
            if (cityDetail.Merchants.Count == 0) {
                return null;
            }
            return new FoundPlayer(scope.AreaName, scope.Id,
                city.PlayerName, city.PlayerId, cityDetail.Merchants[0], cityDetail.AutoPass);
        }
    }
}
