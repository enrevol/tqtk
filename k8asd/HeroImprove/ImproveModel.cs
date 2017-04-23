using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    /// <summary>
    /// Nằm trong gói 41300.
    /// </summary>
    public class ImproveModel {
        /// <summary>
        /// Phổ thông/Cao cấp.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 240 (nếu là chiến tích) hoặc 6 (xu).
        /// </summary>
        public int Cost { get; private set; }

        /// <summary>
        /// Chiến tích hoặc xu.
        /// </summary>
        public string CostUnit { get; private set; }

        public static ImproveModel Parse(JToken token) {
            var result = new ImproveModel();
            result.Name = (string) token["name"];

            var cost = (string) token["cost"];

            int index = 0;
            while (Char.IsDigit(cost[index])) {
                ++index;
            }
            result.Cost = Int32.Parse(cost.Remove(index));
            result.CostUnit = cost.Substring(index);

            return result;
        }
    }
}