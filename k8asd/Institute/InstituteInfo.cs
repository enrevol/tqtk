using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Parses 63601 message.
    /// </summary>
    public class InstituteInfo {
        public List<InstituteTech> Techs { get; private set; }

        public static InstituteInfo Parse(JToken token) {
            var result = new InstituteInfo();
            var instityteDto = token["instityteDto"];
            var techs = new List<InstituteTech>();
            foreach (var subToken in instityteDto) {
                var tech = InstituteTech.Parse(subToken);
                techs.Add(tech);
            }
            result.Techs = techs;
            return result;
        }
    }
}
