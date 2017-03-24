using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {

    /// <summary>
    /// Thuộc tin nhắn 45200.
    /// </summary>
    class SwapInfo
    {
        private Cooldown cooldown;

        /// <summary>
        /// Tổng cấp độ công nhân.
        /// </summary>
        public int imposenum { get; private set; }

        /// <summary>
        /// Tỉ lệ thành công.
        /// </summary>
        public int maximposenum { get; private set; }

        public int Cooldown { get { return cooldown.RemainingMilliseconds; } }


        public static SwapInfo Parse(JToken token, int value) {
            var result = new SwapInfo();

            var res = token["res"];
            foreach (var item in res)
            {
                if (item["resid"].ToString().Equals(value+""))
                {
                    result.imposenum = (int)item["imposenum"];
                    result.maximposenum = (int)item["maximposenum"];
                    var cd = (int)item["cd"];
                    result.cooldown = new Cooldown(cd);
                }
            }
            return result;
        }
    }
}
