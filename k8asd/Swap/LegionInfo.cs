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
    class LegionInfo
    {
        public string officername { get; private set; }

        public static LegionInfo Parse(JToken token) {
            var self = token["self"];

            var result = new LegionInfo();

            result.officername = self["officername"].ToString();
            return result;
        }
    }
}
