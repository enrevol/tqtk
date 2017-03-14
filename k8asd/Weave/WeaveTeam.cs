using Newtonsoft.Json.Linq;

namespace k8asd {
    /// <summary>
    /// Chứa thông tin cho một tổ đội dệt.
    /// Thuộc tin nhắn 45200.
    /// </summary>
    class WeaveTeam {
        private string desc;
        private int legion; // ???
        private int limit; // ???
        private int limitlv; // ??
        private int mnation; // ???
        private int nation; // ???
        private string product;

        /// <summary>
        /// ID của tổ đội.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Tên tổ đội.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Cấp vải tổ đội.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Số lượng người chơi hiện tại trong tổ đội.
        /// </summary>
        public int PlayerCount { get; private set; }

        /// <summary>
        /// Số lượng người chơi tối đa trong tổ đội.
        /// </summary>
        public int MaxPlayerCount { get; private set; }

        /// <summary>
        /// Chi phí.
        /// </summary>
        public int Cost { get; private set; }

        /// <summary>
        /// Giá bán.
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// Tỉ lệ thành công.
        /// </summary>
        public string SuccessRate { get; private set; }

        /// <summary>
        /// Tỉ lệ bạo kích.
        /// </summary>
        public string CriticalRate { get; private set; }

        public static WeaveTeam Parse(JToken token) {
            var result = new WeaveTeam();
            result.CriticalRate = (string) token["baojirate"];
            result.Cost = (int) token["cost"];
            result.desc = (string) token["desc"];
            result.legion = (int) token["legion"];
            result.Level = (int) token["level"];
            result.limit = (int) token["limit"];
            result.limitlv = (int) token["limitlv"];
            result.MaxPlayerCount = (int) token["maxnum"];
            result.mnation = (int) token["mnation"];
            result.nation = (int) token["nation"];
            result.PlayerCount = (int) token["num"];
            result.Price = (int) token["price"];
            result.product = (string) token["product"];
            result.SuccessRate = (string) token["succrate"];
            result.Id = (int) token["teamid"];
            result.Name = (string) token["teamname"];
            return result;
        }
    }
}
