using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    /// <summary>
    /// Chứa thông tin của một thành viên trong tổ đội dệt.
    /// </summary>
    class WeaveMember {
        /// <summary>
        /// ID của người chơi.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Cấp độ người chơi.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Tên người chơi.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Giá bán.
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// Tổng cấp độ công nhân.
        /// </summary>
        public int SpinnerLevel { get; private set; }

        public static WeaveMember Parse(JToken token) {
            var result = new WeaveMember();
            result.Level = (int) token["level"];
            result.Name = (string) token["name"];
            result.Id = (int) token["playerid"];
            result.Price = (int) token["price"];
            result.SpinnerLevel = (int) token["spinnerTotalLevel"];
            return result;
        }

        public string Description() {
            return String.Format("{0} Lv. {1} - Công nhân {2}", Name, Level, SpinnerLevel);
        }
    }
}
