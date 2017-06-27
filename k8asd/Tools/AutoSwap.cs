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

namespace k8asd {
    public partial class AutoSwap : Form {
        private int NoTeam = -1;

        private Dictionary<long, IClient> clients;
        private Dictionary<long, SwapInfo> infos;
        private List<long> playerIds;

        private int hostingTeamId;
        private bool isRefreshing;
        private bool isWeaving;
        private bool timerLocking;

        public AutoSwap() {
            InitializeComponent();

            clients = new Dictionary<long, IClient>();
            infos = new Dictionary<long, SwapInfo>();
            playerIds = new List<long>();

            hostingTeamId = NoTeam;
            isRefreshing = false;
            isWeaving = false;
            timerLocking = false;

            imposenum.AspectGetter = obj => infos[(int)obj].imposenum;
            maximposenum.AspectGetter = obj => infos[(int) obj].maximposenum;
            nameColumn.AspectGetter = obj => clients[(int) obj].PlayerName;
            cooldownColumn.AspectGetter = obj => Utils.FormatDuration(infos[(int) obj].Cooldown);

            weaveTimer.Start();
            weaveTimer.Interval = 1000; // 1 giây.
        }

        private async void refreshButton_Click(object sender, EventArgs e) {
            await RefreshPlayersAsync(FindConnectedClients());
        }

        private List<IClient> FindConnectedClients() {
            var clients = ClientManager.Instance.Clients;
            var connectedClients = new List<IClient>();
            foreach (var client in clients) {
                if (client.State == ClientState.Connected) {
                    connectedClients.Add(client);
                }
            }
            return connectedClients;
        }

        private async Task<bool> RefreshPlayersAsync(List<IClient> connectedClients) {
            if (isRefreshing) {
                return false;
            }
            isRefreshing = true;

            clients.Clear();
            infos.Clear();
            playerIds.Clear();
            playerList.Items.Clear();

            foreach (var client in connectedClients)
            { 
                var packet = await client.RefreshLegionAsync();
                if (packet == null) {
                    continue;
                }
                Debug.Assert(packet.CommandId == "32101");
                var token = JToken.Parse(packet.Message);

                var info = LegionInfo.Parse(token);
                if (info == null) {
                    continue;
                }
                if (info.officername.Equals("Bang chủ"))
                {
                    hostInput.Text = client.PlayerName;
                }

                packet = await client.RefreshCollectAsync();
                if (packet == null)
                {
                    continue;
                }
                Debug.Assert(packet.CommandId == "30100");
                token = JToken.Parse(packet.Message);

                var swapInfo = SwapInfo.Parse(token, (int)numericUpDown1.Value);
                if (swapInfo == null || swapInfo.imposenum == 0)
                {
                    continue;
                }

                var playerId = client.PlayerId;
                playerIds.Add(playerId);
                clients.Add(playerId, client);
                infos.Add(playerId, swapInfo);
                playerList.SetObjects(playerIds);
            }

            isRefreshing = false;
            return true;
        }

        private async Task<bool> RefreshPlayerAsync(long playerId) {
            if (isRefreshing) {
                return false;
            }
            isRefreshing = true;
            try {
                var client = clients[playerId];
                var packet = await client.RefreshLegionAsync();
                if (packet == null) {
                    return false;
                }
                Debug.Assert(packet.CommandId == "32101");
                var token = JToken.Parse(packet.Message);
                var info = LegionInfo.Parse(token);
                if (info == null)
                {
                    return false;
                }
                if (info.officername.Equals("Bang chủ"))
                {
                    hostInput.Text = client.PlayerName;
                }

                packet = await client.RefreshCollectAsync();
                if (packet == null)
                {
                    return false;
                }
                Debug.Assert(packet.CommandId == "30100");
                token = JToken.Parse(packet.Message);
                infos[playerId] = SwapInfo.Parse(token, (int)numericUpDown1.Value);
                playerList.RefreshObject(playerId);
            } finally {
                isRefreshing = false;
            }
            return true;
        }

        private async Task<bool> WeaveAsync(long hostId, long slot1Id) {
            return await WeaveAsync(clients[hostId], clients[slot1Id], slot1Id);
        }

        private async Task<bool> WeaveAsync(IPacketWriter host, IPacketWriter slot1, long slot1Id) {
            // Chuyen bang chu.
            try {
                host.PacketReceived += OnPacketReceived;
                var p0 = await host.Swap(slot1Id);
                if (p0 == null)
                {
                    return false;
                }
            } finally {
                host.PacketReceived -= OnPacketReceived;
            }
            // FIXME: Kiểm tra có tạo được không?

            //thu hoach
            try {
                var tasks = new List<Task<Packet>>();
                tasks.Add(slot1.Collect((int)numericUpDown1.Value));

                var p2s = await Task.WhenAll(tasks);
                return true;
            } finally {
                hostingTeamId = NoTeam;
            }
        }

        private class WeaveTeamInfo {
            public long HostId { get; private set; }
            public long Slot1Id { get; private set; }

            public WeaveTeamInfo(long host, long slot1) {
                HostId = host;
                Slot1Id = slot1;
            }
        }

        private WeaveTeamInfo FindWeaveTeam(long hostId, List<long> memberIds)
        {
            //if (infos[hostId].Cooldown > 0)
            //{
            //    return null;
            //}
            if (memberIds.Count == 0)
            {
                return null;
            }
            if (memberIds.Count == 1)
            {
                if (infos[memberIds[0]].Cooldown > 0)
                {
                    return null;
                }
                return new WeaveTeamInfo(hostId, memberIds[0]);
            }
            var orderedMembers = (from w in memberIds
                                  where infos[w].Cooldown == 0 && infos[w].imposenum < 7
                                  orderby infos[w].imposenum ascending
                                  select w).ToList();

            if (orderedMembers.Count == 0)
            {
                return null;
            }
            if (infos[orderedMembers[0]].Cooldown > 0 && infos[orderedMembers[1]].Cooldown > 0)
            {
                return null;
            }
            return new WeaveTeamInfo(hostId, orderedMembers[0]);
        }

        /// <summary>
        /// Cập nhật thời gian đóng băng.
        /// </summary>
        /// <returns>Thời gian đóng băng tất cả các tài khoản.</returns>
        private void UpdateCooldown() {
            int maxCooldown = playerIds.Count == 0 ? 0 : playerIds.Max(id => infos[id].Cooldown);
            cooldownLabel.Text = String.Format("Đóng băng: {0}", Utils.FormatDuration(maxCooldown));
            if (maxCooldown == 0)
            {
                timerLocking = false;
                isRefreshing = false;
                weaveTimer.Interval = 500;
            }
        }

        private async void weaveTimer_Tick(object sender, EventArgs e) {
            UpdateCooldown();

            if (timerLocking)
            {
                return;
            }
            timerLocking = true;
            try
            {
                if (!autoWeave.Checked)
                {
                    return;
                }

                if (playerIds.Count == 0)
                {
                    // Làm mới thông tin tất cả tài khoản.
                    await RefreshPlayersAsync(FindConnectedClients());
                    if (playerIds.Count == 0)
                    {
                        // Không có tài khoản được kết nối.
                        autoWeave.Checked = false;
                    }
                    return;
                }

                if (isRefreshing || isWeaving)
                {
                    return;
                }

                var hostId = playerIds.FirstOrDefault(id => clients[id].PlayerName == hostInput.Text);
                if (hostId == 0)
                {
                    // Không tìm thấy chủ tổ đội có tên được nhập.
                    return;
                }

                var memberIds = playerIds.Where(id => id != hostId).ToList();
                if (memberIds.Count == 0)
                {
                    // Không có thành viên nào.
                    autoWeave.Checked = false;
                    return;
                }

                int maxTurns = memberIds.Min(id => infos[id].imposenum);
                if (maxTurns == 7)
                {
                    // Các tài khoản khác hết lượt dệt.
                    autoWeave.Checked = false;
                    return;
                }

                var team = FindWeaveTeam(hostId, memberIds);
                if (team == null)
                {
                    weaveTimer.Interval = 1000;
                    return;
                }

                // Kiểm tra lại đóng băng.
                await RefreshPlayerAsync(hostId);
                await RefreshPlayerAsync(team.Slot1Id);
                if (infos[team.Slot1Id].Cooldown > 0)
                {
                    return;
                }

                await WeaveAsync(hostId, team.Slot1Id);
            }
            finally
            {
                timerLocking = false;
            }
        }

        public void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "45300") {
                var token = JToken.Parse(packet.Message);
                var teamId = (int) token["teamObject"]["teamid"];
                hostingTeamId = teamId;
            }
        }

        private async void weaveButton_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(""))
            {
                var hostId = playerIds.FirstOrDefault(id => clients[id].PlayerName == hostInput.Text);
                if (hostId == 0)
                {
                    // Không tìm thấy chủ tổ đội có tên được nhập.
                    return;
                }
                var hostSlot1Id = playerIds.FirstOrDefault(id => clients[id].PlayerName == textBox1.Text);
                if (hostId == 0)
                {
                    // Không tìm thấy chủ tổ đội có tên được nhập.
                    return;
                }
                // Chuyen bang chu.
                try
                {
                    clients[hostId].PacketReceived += OnPacketReceived;
                    var p0 = await clients[hostId].Swap(hostSlot1Id);
                    if (p0 == null)
                    {
                        return;
                    }
                    await RefreshPlayersAsync(FindConnectedClients());
                }
                finally
                {
                    clients[hostId].PacketReceived -= OnPacketReceived;
                }
            }
        }
    }
}
