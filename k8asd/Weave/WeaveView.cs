using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace k8asd {
    public partial class WeaveView : UserControl {
        private int InvalidTeamId = -1;

        /// <summary>
        /// Có đang cập nhật dệt không?
        /// </summary>
        private bool isRefreshing;

        private bool isMaking;

        private WeaveInfo weaveInfo;
        private WeaveTeamDetail myTeam;

        private ICooldownModel cooldownModel;
        private IInfoModel infoModel;
        private IPacketWriter packetWriter;

        public WeaveView() {
            InitializeComponent();

            weaveInfo = null;
            myTeam = null;

            isRefreshing = false;
            isMaking = false;

            teamColumn.AspectGetter = (obj) => {
                var team = (WeaveTeam) obj;
                return String.Format("{0} Lv. {1} ({2}/{3}) [{4} - {5}] [{6} - {7}]",
                   team.Name, team.Level, team.PlayerCount, team.MaxPlayerCount,
                   team.Cost, team.Price, team.SuccessRate, team.CriticalRate);
            };

            memberColumn.AspectGetter = (obj) => {
                var member = (WeaveMember) obj;
                return String.Format("{0} Lv. {1} - Công nhân {2}",
                    member.Name, member.Level, member.SpinnerLevel);
            };
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        public void SetCooldownModel(ICooldownModel cooldown) {
            cooldownModel = cooldown;
        }

        public void SetInfoModel(IInfoModel info) {
            infoModel = info;
        }

        /// <summary>
        /// Cập nhật danh sách tổ đội.
        /// </summary>
        private async Task RefreshTeamsAsync() {
            if (isRefreshing) {
                return;
            }
            isRefreshing = true;

            try {
                var packet = await packetWriter.RefreshWeaveAsync();
                if (packet == null) {
                    return;
                }

                Parse45200(packet);
                await TryAutoCreateAsync();
            } finally {
                isRefreshing = false;
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "45300") {
                Parse45300(packet);
            }
        }

        private void Parse45200(Packet packet) {
            var token = JToken.Parse(packet.Message);
            weaveInfo = WeaveInfo.Parse(token);
            if (weaveInfo == null) {
                // Chưa đủ lv 82.
                return;
            }

            spinnerLevelLabel.Text = String.Format("Công nhân: Lv. {0}", weaveInfo.Level);
            spinnerRateLabel.Text = String.Format("Tỉ lệ: {0} - {1}", weaveInfo.SuccessRate, weaveInfo.CriticalRate);
            priceLabel.Text = String.Format("Giá bán: {0} {1} {2}", weaveInfo.Price,
                weaveInfo.PriceWay == WeavePriceWay.Up ? "▲" : "▼",
                weaveInfo.PriceWay == WeavePriceWay.Up ? "(Lên)" : "(Xuống)");
            numLabel.Text = String.Format("Lượt: {0}/{1}", weaveInfo.Turns, weaveInfo.MaxTurns);

            var oldSelectedIndex = teamList.SelectedIndex;
            teamList.SetObjects(weaveInfo.Teams, true);
            teamList.SelectedIndex = oldSelectedIndex;
        }

        private void Parse45300(Packet packet) {
            var token = JToken.Parse(packet.Message);
            myTeam = WeaveTeamDetail.Parse(token);
            if (myTeam.Action == WeaveTeamAction.Changed) {
                var oldSelectedIndex = memberList.SelectedIndex;
                memberList.SetObjects(myTeam.Members, true);
                memberList.SelectedIndex = oldSelectedIndex;

                teamLevelLabel.Text = String.Format("Cấp: {0}", myTeam.Level);
                teamPriceLabel.Text = String.Format("Giá: {0} - {1}", myTeam.Cost, myTeam.Price);
                teamRateLabel.Text = String.Format("Tỉ lệ: {0} - {1}", myTeam.SuccessRate, myTeam.CriticalRate);

                CheckAutoMake();
                return;
            }
            if (myTeam.Action == WeaveTeamAction.Produced) {
                memberList.ClearObjects();
                return;
            }
            if (myTeam.Action == WeaveTeamAction.Disbanded) {
                memberList.ClearObjects();
                return;
            }
            if (myTeam.Action == WeaveTeamAction.Kicked) {
                memberList.ClearObjects();
                return;
            }
            Debug.Assert(false);
        }

        private async void refreshTeamButton_Click(object sender, EventArgs e) {
            await RefreshTeamsAsync();
        }

        private async void autoRefreshTeamBox_CheckedChanged(object sender, EventArgs e) {
            await TryAutoRefreshAsync();
        }

        private void refreshTeamInterval_ValueChanged(object sender, EventArgs e) {
            refreshTeamTimer.Interval = (int) refreshTeamInterval.Value;
        }

        private async void refreshTeamTimer_Tick(object sender, EventArgs e) {
            await TryAutoRefreshAsync();
        }

        private async void teamList_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e) {
            var item = e.Item;
            var team = (WeaveTeam) item.RowObject;
            await packetWriter.JoinWeaveAsync(team.Id);
        }

        private async void disbandButton_Click(object sender, EventArgs e) {
            var teamId = GetHostingTeamId();
            if (teamId == InvalidTeamId) {
                return;
            }
            await packetWriter.DisbandWeaveAsync(teamId);
        }

        private async void makeButton_Click(object sender, EventArgs e) {
            var teamId = GetHostingTeamId();
            if (teamId == InvalidTeamId) {
                return;
            }
            await packetWriter.MakeWeaveAsync(teamId);
        }

        private async void createButton_Click(object sender, EventArgs e) {
            var textileLevel = (int) textileLevelInput.Value;
            await packetWriter.CreateWeaveAsync(textileLevel, WeaveTeamLimit.Nation);
        }

        private async void createLegionButton_Click(object sender, EventArgs e) {
            var textileLevel = (int) textileLevelInput.Value;
            await packetWriter.CreateWeaveAsync(textileLevel, WeaveTeamLimit.Legion);
        }

        private async void memberList_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e) {
            var item = e.Item;
            var member = (WeaveMember) item.RowObject;
            await packetWriter.KickWeaveAsync(myTeam.Id, member.Id);
        }

        private async void quitButton_Click(object sender, EventArgs e) {
            if (!IsInParty()) {
                return;
            }
            if (myTeam.Members.Count == 1) {
                // Tránh trường hợp tổ đội 0/3.
                return;
            }
            await packetWriter.QuitWeaveAsync(myTeam.Id);
        }

        private async void quitAndMakeButton_Click(object sender, EventArgs e) {
            if (!IsInParty()) {
                return;
            }
            if (myTeam.Members.Count == 1) {
                // Tránh trường hợp tổ đội 0/3.
                return;
            }
            await packetWriter.QuitAndMakeWeaveAsync(myTeam.Id);
        }

        /// <summary>
        /// Kiểm tra xem người chơi hiện tại có đang lập tổ đội nào không?
        /// Lập tổ đội không có nghĩa là phải ở trong tổ đội (lập xong thoát).
        /// Làm mới bởi 45200.
        /// </summary>
        private bool IsHosting() {
            if (weaveInfo == null) {
                return false;
            }
            if (weaveInfo.Teams.Count == 0) {
                return false;
            }
            return weaveInfo.Teams.Any(team => team.Name == infoModel.PlayerName);
        }

        /// <summary>
        /// Kiểm tra xem người chơi hiện có đang lập tổ đội nào không?
        /// Không chính xác nếu người chơi lập xong rồi thoát.
        /// Làm mới bởi 45300.
        /// </summary>
        private bool IsLeader() {
            if (!IsInParty()) {
                return false;
            }
            return myTeam.Members[0].Name == infoModel.PlayerName;
        }

        /// <summary>
        /// Kiểm tra xem người chơi hiện tại có đang trong tổ đội nào không?
        /// </summary>
        private bool IsInParty() {
            return myTeam != null && myTeam.Action == WeaveTeamAction.Changed;
        }

        private int GetHostingTeamId() {
            if (IsHosting()) {
                // Dùng 45200 trước.
                return weaveInfo.Teams.First(team => team.Name == infoModel.PlayerName).Id;
            }

            if (myTeam != null) {
                return myTeam.Id;
            }

            return InvalidTeamId;
        }

        private async Task TryAutoRefreshAsync() {
            if (!autoRefreshTeamBox.Checked) {
                return;
            }
            await RefreshTeamsAsync();
        }

        /// <summary>
        /// Kiểm tra xem có thể tự động tạo tổ đội.
        /// </summary>
        private async Task TryAutoCreateAsync() {
            if (!autoCreate.Checked) {
                // Chưa bật.
                return;
            }
            if (cooldownModel.WeaveCooldown > 0) {
                // Chưa hết đóng băng.
                return;
            }
            if (IsHosting()) {
                // Đã lập tổ đội.
                return;
            }
            // OK.
            var textileLevel = (int) autoTextileLevelInput.Value;
            await packetWriter.CreateWeaveAsync(textileLevel, WeaveTeamLimit.Nation);
        }

        /// <summary>
        /// Kiểm tra xong có thể tự động chế tạo hoặc tự động thoát và chế tạo (chỉ có thể chạy một trong hai).
        /// </summary>
        private async Task TryAutoMakeOrAutoQuitAndMakeAsync() {
            if (isMaking) {
                return;
            }
            isMaking = true;
            await Task.WhenAll(TryAutoMakeAsync(), TryAutoQuitAndMakeAsync());
            isMaking = false;
        }

        /// <summary>
        /// Kiểm tra xem có thể tự động chế tạo.
        /// </summary>
        private async Task TryAutoMakeAsync() {
            if (!autoMake.Checked) {
                // Chưa bật.
                return;
            }
            if (!IsLeader()) {
                // Không phải chủ tổ đội.
                return;
            }
            if (myTeam.Members.Count < 3) {
                // Chưa đủ số lượng thành viên.
                return;
            }
            if (autoQuitAndMake.Checked && weaveInfo.Turns <= 1) {
                // Ưu tiên kéo dệt.
                return;
            }
            // OK.
            await packetWriter.MakeWeaveAsync(myTeam.Id);
        }

        /// <summary>
        /// Kiểm tra xem có thể tự động thoát và chế tạo.
        /// </summary>
        private async Task TryAutoQuitAndMakeAsync() {
            if (!autoQuitAndMake.Checked) {
                // Chưa bật.
                return;
            }
            if (!IsLeader()) {
                // Không phải chủ tổ đội.
                return;
            }
            if (myTeam.Members.Count < 3) {
                // Chưa đủ số lượng thành viên.
                return;
            }
            if (autoMake.Checked && weaveInfo.Turns > 1) {
                // Ưu tiên dệt chung trước.
                return;
            }
            // OK.
            var packets = await packetWriter.QuitAndMakeWeaveAsync(myTeam.Id);
        }

        private List<string> ParsePlayers(string input) {
            var delimiters = new char[] { ',' };
            return input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        /// <summary>
        /// Kiểm tra các thành viên trong tổ đội có phù hợp điều kiện hay không để kick ra.
        /// </summary>
        /// <returns>True nếu tất cả thành viên đều phù hợp</returns>
        private bool CheckLimitPlayer() {
            if (!IsLeader()) {
                // Không phải chủ tổ đội.
                return false;
            }

            var slot1Players = ParsePlayers(slot1PlayerInput.Text);
            var slot2Players = ParsePlayers(slot2PlayerInput.Text);
            if (slot1Players.Count == 0 && slot2Players.Count == 0) {
                // Ai vào cũng được.
                return true;
            }

            var members = myTeam.Members;
            if (slot1Players.Count == 0 || slot2Players.Count == 0) {
                // Có 1 slot ai vào cũng được.
                if (myTeam.Members.Count < 3) {
                    // Vẫn còn 1 slot trống, chưa cần kick.
                    return true;
                }

                if (slot1Players.Count == 0) {
                    // Swap.
                    var temp = slot1Players;
                    slot2Players = slot1Players;
                    slot1Players = temp;
                }

                if (slot1Players.Contains(members[1].Name) ||
                    slot1Players.Contains(members[2].Name)) {
                    // OK.
                    return true;
                }

                // Kick slot 1.
                packetWriter.KickWeaveAsync(myTeam.Id, members[1].Id).Forget();
                return false;
            }

            // Kiểm tra slot 1.
            if (members.Count > 1 && !slot1Players.Contains(members[1].Name)) {
                packetWriter.KickWeaveAsync(myTeam.Id, members[1].Id).Forget();
                return false;
            }

            // Kiểm tra slot 2.
            if (members.Count > 2 && !slot2Players.Contains(members[2].Name)) {
                packetWriter.KickWeaveAsync(myTeam.Id, members[2].Id).Forget();
                return false;
            }

            // OK.
            return true;
        }

        private void CheckAutoMake() {
            if (IsLeader()) {
                // Chủ tổ đội.
                if (CheckLimitPlayer()) {
                    TryAutoMakeOrAutoQuitAndMakeAsync().Forget();
                }
            }
        }

        private void autoQuitAndMake_CheckedChanged(object sender, EventArgs e) {
            CheckAutoMake();
        }

        private void autoMake_CheckedChanged(object sender, EventArgs e) {
            CheckAutoMake();
        }
    }


    /*
    private void btnWeaveInvite_Click(object sender, EventArgs e) {
    int cnum = Convert.ToInt32(r45300.num);
    int mnum = Convert.ToInt32(r45300.maxnum);
    /*
    if (cnum <= mnum)
        SendMsg("10103", r11102.playername,
            "Tổ đội dệt vải cấp " + r45300.level
            + " đã được lập "
            + "<a href='event:textile|" + r45300.teamid
            + "'>[Gia nhập]</a>",
            (cbbChat.SelectedIndex + 1).ToString(), " ");
    }    
    */
}
