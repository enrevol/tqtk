using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Dùng trong gói tin 33100.
    /// </summary>
    class Power {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Reputation { get; private set; }
        public bool Attackable { get; private set; }

        public static Power Parse(JToken token) {
            var result = new Power();
            result.Attackable = (bool) token["attackable"];
            result.Id = (int) token["powerid"];
            result.Name = (string) token["powername"];
            result.Reputation = (int) token["prestige"];
            return result;
        }
    }
}
