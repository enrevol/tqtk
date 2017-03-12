using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Xu hướng giá dệt.
    /// </summary>
    enum WeavePriceWay {
        /// <summary>
        /// Giá dệt đang lên.
        /// </summary>
        Up = 1,

        /// <summary>
        /// Giá dệt đang xuống.
        /// </summary>
        Down = 0,
    };

    class WeaveInfo {
        private int gold;  // ???

        /// <summary>
        /// Tổng cấp độ công nhân.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Tỉ lệ thành công.
        /// </summary>
        public int SuccessRate { get; private set; }

        /// <summary>
        /// Tỉ lệ bạo kích.
        /// </summary>
        public int CriticalRate { get; private set; }

        /// <summary>
        /// Số lượt dệt còn lại.
        /// </summary>
        public int Turns { get; private set; }

        /// <summary>
        /// Số lượt dệt tối đa.
        /// </summary>
        public int MaxTurns { get; private set; }

        /// <summary>
        /// Giá dệt.
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// Xu hướng giá dệt của lần làm mới tiếp theo.        
        /// </summary>
        public WeavePriceWay PriceWay { get; private set; }

        /// <summary>
        /// Danh sách tổ đội dệt.
        /// </summary>
        public List<WeaveTeam> Teams { get; private set; }

        public static WeaveInfo Parse(JToken token) {
            var message = token["message"];
            if (message != null) {
                // Chưa đủ lv 82.
                return null;
            }

            var result = new WeaveInfo();

            var baseinfo = token["baseinfo"];
            result.Level = (int) baseinfo["totallevel"];
            result.Turns = (int) baseinfo["num"];
            result.MaxTurns = (int) baseinfo["maxnum"];
            result.Price = (int) baseinfo["price"];
            result.PriceWay = (WeavePriceWay) (int) baseinfo["priceway"];
            result.SuccessRate = (int) baseinfo["succrate"];
            result.CriticalRate = (int) baseinfo["baojirate"];
            result.gold = (int) baseinfo["gold"];

            var teamList = token["teamList"];
            var teams = new List<WeaveTeam>();
            foreach (var teamToken in teamList) {
                var team = WeaveTeam.Parse(teamToken);
                teams.Add(team);
            }
            result.Teams = teams;

            return result;
        }
    }
}
