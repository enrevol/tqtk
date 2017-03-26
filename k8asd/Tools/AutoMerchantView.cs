using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using BrightIdeasSoftware;

namespace k8asd {
    public partial class AutoMerchantView : Form {
        private int LineLimit = 500;

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

        private List<CheckBox> searchAreaFilterBoxes;
        private List<CheckBox> searchMerchantFilterBoxes;

        private bool isSearching;
        private bool isRefreshing;
        private bool isStopRequested;

        public AutoMerchantView() {
            InitializeComponent();

            isSearching = false;
            isRefreshing = false;
            isStopRequested = false;

            clients = new Dictionary<int, IClient>();
            infos = new Dictionary<int, MerchantInfo>();
            playerIds = new List<int>();

            searchAreaFilterBoxes = new List<CheckBox>();
            searchAreaFilterBoxes.Add(area21Box);
            searchAreaFilterBoxes.Add(area22Box);
            searchAreaFilterBoxes.Add(area23Box);
            searchAreaFilterBoxes.Add(area24Box);
            searchAreaFilterBoxes.Add(area25Box);
            searchAreaFilterBoxes.Add(area26Box);
            searchAreaFilterBoxes.Add(area27Box);
            searchAreaFilterBoxes.Add(area28Box);
            searchAreaFilterBoxes.Add(area29Box);
            searchAreaFilterBoxes.Add(area30Box);
            searchAreaFilterBoxes.Add(area31Box);
            searchAreaFilterBoxes.Add(area32Box);
            searchAreaFilterBoxes.Add(area33Box);
            searchAreaFilterBoxes.Add(area34Box);
            searchAreaFilterBoxes.Add(area35Box);
            searchAreaFilterBoxes.Add(area36Box);
            searchAreaFilterBoxes.Add(area37Box);
            searchAreaFilterBoxes.Add(area38Box);
            searchAreaFilterBoxes.Add(area39Box);

            searchMerchantFilterBoxes = new List<CheckBox>();
            searchMerchantFilterBoxes.Add(merchant1Box);
            searchMerchantFilterBoxes.Add(merchant2Box);
            searchMerchantFilterBoxes.Add(merchant3Box);
            searchMerchantFilterBoxes.Add(merchant4Box);
            searchMerchantFilterBoxes.Add(merchant5Box);
            searchMerchantFilterBoxes.Add(merchant6Box);
            searchMerchantFilterBoxes.Add(merchant7Box);
            searchMerchantFilterBoxes.Add(merchant8Box);
            searchMerchantFilterBoxes.Add(merchant9Box);
            searchMerchantFilterBoxes.Add(merchant10Box);
            searchMerchantFilterBoxes.Add(merchant11Box);
            searchMerchantFilterBoxes.Add(merchant12Box);
            foreach (var box in searchMerchantFilterBoxes) {
                box.CheckedChanged += Box_CheckedChanged;
            }
            autoMerchantBox.CheckedChanged += Box_CheckedChanged;

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
            if (logBox.Text.Length > 0) {
                logBox.Text += Environment.NewLine;
            }
            logBox.Text += String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            if (logBox.Lines.Length > LineLimit) {
                logBox.Text = logBox.Text.Remove(0, logBox.Lines[0].Length + Environment.NewLine.Length);
            }
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
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
                LogInfo("Đang tìm kiếm, không thể tìm kiếm!");
                return false;
            }

            var areaIds = new List<int>();
            int areaStartId = 21;
            foreach (var box in searchAreaFilterBoxes) {
                if (box.Checked) {
                    areaIds.Add(areaStartId);
                }
                ++areaStartId;
            }

            /*
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
            areaIds.Add(34); // Vũ Lăng.
            areaIds.Add(35); // Giang Hạ.
            areaIds.Add(36); // Hàn Dương.
            areaIds.Add(37); // Vũ Uy.
            areaIds.Add(38); // Hợp Phì.
            areaIds.Add(39); // Dương Đô.
            */

            foundPlayers.Clear();
            foundPlayerList.Items.Clear();

            try {
                LogInfo("Bắt đầu tìm kiếm...");
                isSearching = true;
                isStopRequested = false;
                searchAreaFilter.Enabled = false;
                stopButton.Enabled = true;
                var client = clients[playerIds[0]];
                foreach (var areaId in areaIds) {
                    var initialScope = await client.RefreshAreaAsync(areaId);
                    if (initialScope == null) {
                        return false;
                    }
                    if (isStopRequested) {
                        LogInfo("Đã dừng tìm kiếm...");
                        return true;
                    }
                    await SearchPlayers(client, initialScope);
                    for (int scopeId = initialScope.Id + 1; scopeId <= initialScope.Count; ++scopeId) {
                        var scope = await client.RefreshScopeAsync(areaId, scopeId);
                        if (scope == null) {
                            return false;
                        }
                        if (isStopRequested) {
                            LogInfo("Đã dừng tìm kiếm...");
                            return true;
                        }
                        await SearchPlayers(client, scope);
                    }
                }

            } finally {
                isSearching = false;
                isStopRequested = false;
                searchAreaFilter.Enabled = true;
                stopButton.Enabled = false;
            }

            LogInfo("Tìm kiếm hoàn thành");
            return true;
        }

        private async Task SearchPlayers(IPacketWriter writer, Scope scope) {
            LogInfo(String.Format("Tìm kiếm {0} khu vực {1}...", scope.AreaName, scope.Id));
            foreach (var city in scope.Cities) {
                // Delay tránh bị treo acc.
                await Task.Delay(50);
                var player = await SearchPlayer(writer, scope, city);
                if (player == null) {
                    continue;
                }
                foundPlayers.Add(player);
                RefreshSearchingResult();
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

        private void RefreshSearchingResult() {
            var filteredResult = new List<FoundPlayer>();
            foreach (var player in foundPlayers) {
                if (autoMerchantBox.Checked && !player.AutoPass) {
                    continue;
                }
                int merchantId = (int) player.Merchant;
                if (!searchMerchantFilterBoxes[merchantId - 1].Checked) {
                    continue;
                }
                filteredResult.Add(player);
            }
            foundPlayerList.SetObjects(filteredResult);
        }

        private void Box_CheckedChanged(object sender, EventArgs e) {
            RefreshSearchingResult();
        }

        private void selectAllAreaButton_Click(object sender, EventArgs e) {
            foreach (var box in searchAreaFilterBoxes) {
                box.Checked = true;
            }
        }

        private void deselectAllAreaButton_Click(object sender, EventArgs e) {
            foreach (var box in searchAreaFilterBoxes) {
                box.Checked = false;
            }
        }

        private void selectNeutralAreaButton_Click(object sender, EventArgs e) {
            // Trần Lưu đến Giang Hạ.
            for (int i = 3; i < searchAreaFilterBoxes.Count - 4; ++i) {
                searchAreaFilterBoxes[i].Checked = true;
            }

            // Dương Đô.
            searchAreaFilterBoxes[searchAreaFilterBoxes.Count - 1].Checked = true;
        }

        private void selectAllMerchantButton_Click(object sender, EventArgs e) {
            foreach (var box in searchMerchantFilterBoxes) {
                box.CheckedChanged -= Box_CheckedChanged;
                box.Checked = true;
                box.CheckedChanged += Box_CheckedChanged;
            }
            RefreshSearchingResult();
        }

        private void deselectAllMerchantButton_Click(object sender, EventArgs e) {
            foreach (var box in searchMerchantFilterBoxes) {
                box.CheckedChanged -= Box_CheckedChanged;
                box.Checked = false;
                box.CheckedChanged += Box_CheckedChanged;
            }
            RefreshSearchingResult();
        }

        private void stopButton_Click(object sender, EventArgs e) {
            if (isSearching) {
                LogInfo("Đang dừng tìm kiếm...");
                isStopRequested = true;
            }
        }
    }
}
