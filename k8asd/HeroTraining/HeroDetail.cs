using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Dịch gói 41107.
    /// </summary>
    public class HeroDetail {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int ShiftLevel { get; private set; }

        public static HeroDetail Parse(JToken token) {
            var result = new HeroDetail();
            var generaldto = token["generaldto"];
            result.Id = (int) generaldto["generalid"];
            result.Name = (string) generaldto["generalname"];
            result.Level = (int) generaldto["generallevel"];
            result.ShiftLevel = (int) generaldto["shiftlv"];
            return result;
        }
    }
}
