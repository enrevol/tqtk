using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Dịch gói 13100.
    /// </summary>
    public class MarketInfo {
        public bool IsUp { get; private set; }

        /// <summary>
        /// Giá lúa.
        /// </summary>
        public float Price { get; private set; }

        /// <summary>
        /// Số lượng giao dịch tối đa.
        /// </summary>
        public int MaxTradeAmount { get; private set; }

        /// <summary>
        /// Số lượng giao dịch hiện tại.
        /// </summary>
        public int TradeAmount { get; private set; }

        public static MarketInfo Parse(JToken token) {
            var result = new MarketInfo();
            result.IsUp = (bool) token["isup"];
            result.Price = (float) token["price"];
            result.MaxTradeAmount = (int) token["maxtrade"];
            result.TradeAmount = (int) token["crutrade"];
            return result;
        }
    }
}
