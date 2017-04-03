using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Parses 64005 message.
    /// </summary>
    public class ResearchInfo
    {
        public string name;
        public int level; //so sao
        public long currentExperience;
        public long upgradeExperience;

        public static ResearchInfo Parse(JToken token) {
            var result = new ResearchInfo();

            var petInfo = token["petInfo"];
            result.name = petInfo["name"].ToString();
            result.level = ((int)petInfo["level"])%10;
            result.currentExperience = (long)petInfo["currentExperience"];
            result.upgradeExperience = (long)petInfo["upgradeExperience"];

            return result;
        }
    }
}
