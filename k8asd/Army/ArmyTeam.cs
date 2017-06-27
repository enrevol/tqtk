using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    class ArmyTeam {
        private Cooldown cooldown;

        /// <summary>
        /// ID của tổ đội.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Tên tổ đội.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Điều kiện tham gia của tổ đội.
        /// </summary>
        public string Condition { get; private set; }

        /// <summary>
        /// Số lượng người chơi có trong tổ đội.
        /// </summary>
        public int PlayerCount { get; private set; }

        /// <summary>
        /// Số lượng người chơi tối đa trong tổ đội.
        /// </summary>
        public int MaxPlayerCount { get; private set; }

        /// <summary>
        /// Thời gian chờ còn lại.
        /// </summary>
        public int RemainingTime { get { return cooldown.RemainingMilliseconds; } }

        public static ArmyTeam Parse(JToken token, DateTime serverTime) {
            var result = new ArmyTeam();
            result.Id = (long) token["teamid"];
            result.Name = (string) token["teamname"];
            result.Condition = (string) token["condition"];
            result.PlayerCount = (int) token["currentnum"];
            result.MaxPlayerCount = (int) token["maxnum"];
            var endtime = (long) token["endtime"];
            result.cooldown = new Cooldown(Utils.ConvertToLocalTime(serverTime, endtime));
            return result;
        }
    }
}
