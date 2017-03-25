using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Dịch gói tin 30100.
    /// </summary>
    class World {
        public List<Area> Areas { get; private set; }

        public static World Parse(JToken token) {
            var result = new World();
            var areas = new List<Area>();
            foreach (var subToken in token["area"]) {
                var area = Area.Parse(subToken);
                areas.Add(area);
            }
            result.Areas = areas;
            return result;
        }
    }
}
