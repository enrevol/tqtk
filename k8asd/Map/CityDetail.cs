using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Dịch gói tin 31106.
    /// </summary>
    class CityDetail {
        /// <summary>
        /// Danh sách thương minh.
        /// </summary>
        public List<Merchant> Merchants { get; private set; }

        /// <summary>
        /// Có tự động thông thương không?
        /// </summary>
        public bool AutoPass { get; private set; }

        public static CityDetail Parse(JToken token) {
            var result = new CityDetail();

            var merchants = new List<Merchant>();
            if (token["merchants"] != null) {
                foreach (var subToken in token["merchants"]) {
                    var merchant = (Merchant) (int) subToken["id"];
                    merchants.Add(merchant);
                }
            }
            result.Merchants = merchants;

            result.AutoPass = false;
            if (token["autoPass"] != null) {
                result.AutoPass = (bool) token["autoPass"];
            }

            return result;
        }
    }
}
