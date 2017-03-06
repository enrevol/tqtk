using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    /// <summary>
    /// Chứa thông tin của một loại vải.
    /// </summary>
    class WeaveProduct {
        /// <summary>
        /// ID vải.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Cấp độ vải.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Tên vải.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Chi phí.
        /// </summary>
        public int Cost { get; private set; }

        /// <summary>
        /// Giá bán.
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// Mô tả.
        /// </summary>
        public string Desc { get; private set; }

        /// <summary>
        /// Tỉ lệ thành công.
        /// </summary>
        public string SuccessRate { get; private set; }

        /// <summary>
        /// Tỉ lệ thất bại.
        /// </summary>
        public string CriticalRate { get; private set; }

        public static WeaveProduct Parse(JToken token) {
            var result = new WeaveProduct();
            result.CriticalRate = (string) token["baojirate"];
            result.Cost = (int) token["cost"];
            result.Desc = (string) token["desc"];
            result.Level = (int) token["level"];
            result.Name = (string) token["name"];
            result.Price = (int) token["price"];
            result.Id = (int) token["prodid"];
            result.SuccessRate = (string) token["succrate"];
            return result;
        }

        public string Description() {
            return String.Format("Lv. {0} [{1} - {2}] [{3} - {4}]",
                Level, Cost, Price, SuccessRate, CriticalRate);
        }
    }
}
