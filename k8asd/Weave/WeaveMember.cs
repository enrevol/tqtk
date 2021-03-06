﻿using Newtonsoft.Json.Linq;

namespace k8asd {
    /// <summary>
    /// Chứa thông tin của một thành viên trong tổ đội dệt.
    /// Thuộc tin nhắn 45300.
    /// </summary>
    class WeaveMember {
        /// <summary>
        /// ID của người chơi.
        /// </summary>
        public long Id { get; private set; }

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
            result.Id = (long) token["playerid"];
            result.Price = (int) token["price"];
            result.SpinnerLevel = (int) token["spinnerTotalLevel"];
            return result;
        }
    }
}
