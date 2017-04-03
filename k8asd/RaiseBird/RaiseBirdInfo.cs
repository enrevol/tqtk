using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Parses 64005 message.
    /// </summary>
    class RaiseBirdInfo
    {
        public string name;
        public int level; //so sao
        public long currentExperience;
        public long upgradeExperience;

        public static RaiseBirdInfo Parse(JToken token) {
            var result = new RaiseBirdInfo();

            var petInfo = token["petInfo"];
            result.name = petInfo["name"].ToString();
            result.level = ((int)petInfo["level"])%10;
            result.currentExperience = (long)petInfo["currentExperience"];
            result.upgradeExperience = (long)petInfo["upgradeExperience"];

            return result;
        }
    }
}
