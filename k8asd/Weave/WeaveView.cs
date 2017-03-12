using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace k8asd {
    public partial class WeaveView : UserControl, IPacketReader {
        private const int NoTeam = -1;

        /// <summary>
        /// ID tổ đội hiện tại.
        /// Nếu không thuộc tổ đội nào thì giá trị bằng NoTeam.
        /// </summary>
        private int currentTeamId;

        /// <summary>
        /// Giá dệt hiện tại.
        /// </summary>
        private int currentTextilePrice;

        /// <summary>
        /// Số lần dệt còn lại.
        /// </summary>
        private int currentTurnCount;

        /// <summary>
        /// Có đang cập nhật dệt không?
        /// </summary>
        private bool isRefreshing;

        private bool isMaking;

        private WeaveInfo weaveInfo;

        /// <summary>
        /// Danh sách thành viên trong tổ đội dệt hiện tại.
        /// </summary>
        private List<WeaveMember> members;

        private ICooldownModel cooldownModel;
        private IInfoModel infoModel;
        private IPacketWriter packetWriter;

        public WeaveView() {
            InitializeComponent();

            weaveInfo = null;
            members = new List<WeaveMember>();

            isRefreshing = false;
            isMaking = false;
            currentTextilePrice = 0;
            currentTurnCount = 0;

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
            packetWriter = writer;
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
                if (IsHosting()) {
                    if (CheckLimitPlayer()) {
                        await TryAutoMakeOrAutoQuitAndMakeAsync();
                    }
                } else {
                    await TryAutoCreateAsync();
                }
            } finally {
                isRefreshing = false;
            }
        }

        public void OnPacketReceived(Packet packet) {
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
            var type = (int) token["type"];
            if (type == 0) {
                // Vừa chế tạo xong.
                // Sẽ kèm theo tin nhắn dệt được bao nhiêu bạc.
                // Lưu ý: chế tạo xong sẽ gửi 45300 type=0 rồi gửi tiếp 45300 type=1.
                return;
            }
            if (type == 1) {
                // Bị ra khỏi tổ đội mà tổ đội biến mất luôn (giải tán/vừa dệt xong).
                currentTeamId = NoTeam;
                members.Clear();
                memberList.SetObjects(members, true);
                return;
            }
            if (type == 2) {
                // Có người vào/ra tổ đội.                
                var teamObject = token["teamObject"];
                ParseTeamInfo(teamObject);
                if (IsHosting()) {
                    if (CheckLimitPlayer()) {
                        TryAutoMakeOrAutoQuitAndMakeAsync().Forget();
                    }
                }
                return;
            }
            if (type == 3) {
                // Bị ra khỏi tổ đội mà tổ đội vẫn còn tồn tại (thoát ra/bị kick).
                currentTeamId = NoTeam;
                if (IsHosting()) {
                    // Chủ tổ đội thoát tổ đội.
                } else {
                    members.Clear();
                    memberList.SetObjects(members, true);
                }
                return;
            }
            Debug.Assert(false);
        }

        private void ParseMembers(JToken token) {
            members.Clear();
            foreach (var memberToken in token) {
                var member = WeaveMember.Parse(memberToken);
                members.Add(member);
            }
            var oldSelectedIndex = memberList.SelectedIndex;
            memberList.SetObjects(members, true);
            memberList.SelectedIndex = oldSelectedIndex;
        }

        private void ParseTeamInfo(JToken token) {
            var memberlist = token["memberlist"];
            ParseMembers(memberlist);

            var baojirate = (string) token["baojirate"];
            var cost = (int) token["cost"];
            var level = (int) token["level"];
            var price = (int) token["price"];
            var succrate = (string) token["succrate"];
            currentTeamId = (int) token["teamid"];
            teamLevelLabel.Text = String.Format("Cấp: {0}", level);
            teamPriceLabel.Text = String.Format("Giá: {0} - {1}", cost, price);
            teamRateLabel.Text = String.Format("Tỉ lệ: {0} - {1}", succrate, baojirate);
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
            if (!IsHosting()) {
                return;
            }
            await packetWriter.DisbandWeaveAsync(GetHostingTeamId());
        }

        private async void makeButton_Click(object sender, EventArgs e) {
            if (!IsHosting()) {
                return;
            }
            await packetWriter.MakeWeaveAsync(GetHostingTeamId());
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
            if (!IsInParty()) {
                return;
            }
            var item = e.Item;
            var member = (WeaveMember) item.RowObject;
            await packetWriter.KickWeaveAsync(currentTeamId, member.Id);
        }

        private async void quitButton_Click(object sender, EventArgs e) {
            if (!IsInParty()) {
                return;
            }
            await packetWriter.QuitWeaveAsync(currentTeamId);
        }

        private async void quitAndMakeButton_Click(object sender, EventArgs e) {
            if (!IsInParty()) {
                return;
            }
            await packetWriter.QuitAndMakeWeaveAsync(currentTeamId);
        }

        /// <summary>
        /// Kiểm tra xem người chơi hiện tại có đang lập tổ đội nào không?
        /// Lập tổ đội không có nghĩa là phải ở trong tổ đội (lập xong thoát).
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

        private int GetHostingTeamId() {
            if (!IsHosting()) {
                return NoTeam;
            }
            return weaveInfo.Teams.First(team => team.Name == infoModel.PlayerName).Id;
        }

        /// <summary>
        /// Kiểm tra xem người chơi hiện tại có đang trong tổ đội nào không?
        /// </summary>
        private bool IsInParty() {
            return currentTeamId != NoTeam;
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
            var textilePrice = (int) textilePriceInput.Value;
            if (currentTextilePrice < textilePrice) {
                // Giá chưa đủ cao.
                return;
            }
            if (!IsHosting()) {
                // Chưa lập tổ đội.
                return;
            }
            if (!IsInParty()) {
                // Không nằm trong tổ đội.
                return;
            }
            if (members.Count < 3) {
                // Chưa đủ số lượng thành viên/
                return;
            }
            if (autoQuitAndMake.Checked && currentTurnCount <= 1) {
                // Ưu tiên kéo dệt.
                return;
            }
            // OK.
            await packetWriter.MakeWeaveAsync(currentTeamId);
        }

        /// <summary>
        /// Kiểm tra xem có thể tự động thoát và chế tạo.
        /// </summary>
        private async Task TryAutoQuitAndMakeAsync() {
            if (!autoQuitAndMake.Checked) {
                // Chưa bật.
                return;
            }
            if (!IsHosting()) {
                // Chưa lập tổ đội.
                return;
            }
            if (!IsInParty()) {
                // Không nằm trong tổ đội.
                return;
            }
            if (members.Count < 3) {
                // Chưa đủ số lượng thành viên.
                return;
            }
            if (autoMake.Checked && currentTurnCount > 1) {
                // Ưu tiên dệt chung trước.
                return;
            }
            // OK.
            var packets = await packetWriter.QuitAndMakeWeaveAsync(currentTeamId);
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
            if (!IsHosting()) {
                // Chưa lập tổ đội.
                return true;
            }

            if (!IsInParty()) {
                // Không nằm trong tổ đội (lập tổ đội xong thoát).
                return true;
            }

            var slot1Players = ParsePlayers(slot1PlayerInput.Text);
            var slot2Players = ParsePlayers(slot2PlayerInput.Text);
            if (slot1Players.Count == 0 && slot2Players.Count == 0) {
                // Ai vào cũng được.
                return true;
            }

            if (slot1Players.Count == 0 || slot2Players.Count == 0) {
                // Có 1 slot ai vào cũng được.
                if (members.Count < 3) {
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
                packetWriter.KickWeaveAsync(currentTeamId, members[1].Id).Forget();
                return false;
            }

            // Kiểm tra slot 1.
            if (members.Count > 1 && !slot1Players.Contains(members[1].Name)) {
                packetWriter.KickWeaveAsync(currentTeamId, members[1].Id).Forget();
                return false;
            }

            // Kiểm tra slot 2.
            if (members.Count > 2 && !slot2Players.Contains(members[2].Name)) {
                packetWriter.KickWeaveAsync(currentTeamId, members[2].Id).Forget();
                return false;
            }

            // OK.
            return true;
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
