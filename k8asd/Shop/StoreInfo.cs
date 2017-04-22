using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Dịch gói 39100.
    /// </summary>
    public class StoreInfo {
        /// <summary>
        /// Số lượng ô trong túi đồ.
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Số lượng ô đã dùng.
        /// </summary>
        public int UsedSize { get; private set; }

        /// <summary>
        /// Số lượng đồ (tính cả chưa nhận?)
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Số xu cần thiết để mở ô tiếp theo.
        /// </summary>
        public int ExpansionCost { get; private set; }

        public static StoreInfo Parse(JToken token) {
            var result = new StoreInfo();
            result.Size = (int) token["stoersize"];
            result.UsedSize = (int) token["usesize"];
            result.Count = (int) token["numCount"];
            result.ExpansionCost = (int) token["cost"];
            return result;
        }
    }
}
