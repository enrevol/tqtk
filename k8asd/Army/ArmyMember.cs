using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    class ArmyMember {
        public int Id { get; private set; }
        public int Level { get; private set; }
        public string Name { get; private set; }

        public static ArmyMember Parse(JToken token) {
            var result = new ArmyMember();
            result.Id = (int) token["playerid"];
            result.Level = (int) token["playerlevel"];
            result.Name = (string) token["playername"];
            return result;
        }
    }
}
