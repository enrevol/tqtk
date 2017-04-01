using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace k8asd {
    class DrillReward {
        public int Award { get; private set; }
        public string Name { get; private set; }

        public static DrillReward Parse(JToken token) {
            var result = new DrillReward();
            result.Award = (int) token["award"];
            result.Name = (string) token["name"];
            return result;
        }
    }

    class DrillResult {
        public List<DrillReward> Rewards { get; private set; }

        public static DrillResult Parse(JToken token) {
            var reward = token["reward"];
            if (reward == null) {
                return null;
            }
            var result = new DrillResult();
            var rewards = new List<DrillReward>();
            var totalItemList = (JArray) reward["totalItemList"];
            foreach (JToken subToken in totalItemList) {
                rewards.Add(DrillReward.Parse(subToken));
            }
            result.Rewards = rewards;
            return result;
        }
    }
}
