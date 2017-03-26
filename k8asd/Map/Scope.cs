using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Thuộc gói tin 31101 và 31102.
    /// </summary>
    class Scope {
        /// <summary>
        /// ID của khu vực.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Số lượng khu vực trong thành này.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// ID của thành chứa khu vực này.
        /// </summary>
        public int AreaId { get; private set; }

        /// <summary>
        /// Tên của thành chứa khu vực này.
        /// </summary>
        public string AreaName { get; private set; }

        /// <summary>
        /// Danh sách các thành phố (người chơi) trong khu vực này.
        /// </summary>
        public List<City> Cities { get; private set; }

        public static Scope Parse(JToken token) {
            var result = new Scope();

            var areaToken = token["area"];
            result.AreaId = (int) areaToken["areaid"];
            result.AreaName = (string) areaToken["areaname"];
            result.Id = (int) areaToken["scopeid"];
            result.Count = (int) areaToken["scopecount"];

            var cities = new List<City>();
            var cityToken = token["city"];
            foreach (var subToken in cityToken) {
                var city = City.Parse(subToken);
                cities.Add(city);
            }
            result.Cities = cities;

            return result;
        }
    }
}
