using Newtonsoft.Json.Linq;

namespace k8asd {
    /// <summary>
    /// Thuộc gói tin 31101 và 31102.
    /// </summary>
    class City {
        /// <summary>
        /// Vị trí của thành phố này trong khu vực (1 đến 16).
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Cấp người chơi.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Tên bang hội.
        /// </summary>
        public string LegionName { get; private set; }

        /// <summary>
        /// ID của người chơi.
        /// </summary>
        public long PlayerId { get; private set; }

        /// <summary>
        /// Tên người chơi.
        /// </summary>
        public string PlayerName { get; private set; }

        /// <summary>
        /// Quốc gia người chơi.
        /// </summary>
        public Nation Nation { get; private set; }

        public static City Parse(JToken token) {
            var result = new City();
            result.Index = (int) token["index"];
            result.Level = (int) token["citylevel"];
            result.LegionName = (string) token["legionName"];
            result.PlayerId = (long) token["playerid"];
            result.PlayerName = (string) token["playername"];
            result.Nation = (Nation) (int) token["nation"];
            return result;
        }
    }
}
