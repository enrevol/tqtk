using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    enum WeaveTeamAction {
        /// <summary>
        /// Vừa chế tạo xong.
        /// Sẽ kèm theo tin nhắn dệt được bao nhiêu bạc.
        /// Lưu ý: chế tạo xong sẽ gửi 45300 type=0 rồi gửi tiếp 45300 type=1.
        /// </summary>
        Produced = 0,

        // Bị ra khỏi tổ đội mà tổ đội biến mất luôn (giải tán/vừa dệt xong).
        Disbanded = 1,

        // Có người vào/ra tổ đội.
        Changed = 2,

        // Bị ra khỏi tổ đội mà tổ đội vẫn còn tồn tại (thoát ra/bị kick).
        Kicked = 3,
        Quit = 3,
    }

    /// <summary>
    /// Dịch tin nhắn 45300.
    /// </summary>
    class WeaveTeamDetail {
        private int limit; // ???

        public WeaveTeamAction Action { get; private set; }

        /// <summary>
        /// ID của tổ đội.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Cấp vải.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Tỉ lệ thành công.
        /// </summary>
        public string SuccessRate { get; private set; }

        /// <summary>
        /// Tỉ lệ bạo kích.
        /// </summary>
        public string CriticalRate { get; private set; }

        /// <summary>
        /// Chi phí.
        /// </summary>
        public int Cost { get; private set; }

        /// <summary>
        /// Giá bán.
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// ID của người chơi chủ tổ đội.
        /// </summary>
        public int LeaderId { get; private set; }

        /// <summary>
        /// Số người hiện tại trong tổ đội.
        /// </summary>
        public int PlayerCount { get; private set; }

        /// <summary>
        /// Số người tối đa trong tổ đội.
        /// </summary>
        public int MaxPlayerCount { get; private set; }

        public List<WeaveMember> Members { get; private set; }

        public static WeaveTeamDetail Parse(JToken token) {
            var result = new WeaveTeamDetail();
            result.Action = (WeaveTeamAction) (int) token["type"];
            if (result.Action == WeaveTeamAction.Changed) {
                var teamObject = token["teamObject"];
                Debug.Assert(teamObject != null);

                result.Level = (int) teamObject["level"];
                result.Id = (int) teamObject["teamid"];
                result.SuccessRate = (string) teamObject["succrate"];
                result.CriticalRate = (string) teamObject["baojirate"];
                result.Cost = (int) teamObject["cost"];
                result.Price = (int) teamObject["price"];
                result.LeaderId = (int) teamObject["leaderid"];
                result.PlayerCount = (int) teamObject["num"];
                result.MaxPlayerCount = (int) teamObject["maxnum"];
                result.limit = (int) teamObject["limit"];

                var memberList = teamObject["memberlist"];
                var members = new List<WeaveMember>();
                foreach (var memberToken in memberList) {
                    var member = WeaveMember.Parse(memberToken);
                    members.Add(member);
                }
                result.Members = members;
            }
            return result;
        }
    }
}
