using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Dịch gói tin 33100.
    /// </summary>
    class PowerDetail {
        /// <summary>
        /// ID của thế lực.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Tên thế lực.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Có tấn công được không?
        /// </summary>
        public bool Attackable { get; private set; }

        /// <summary>
        /// Tên chiến dịch của thế lực này (nếu có).
        /// </summary>
        public string Campaign { get; private set; }

        /// <summary>
        /// Danh sách các thế lực tiếp theo.
        /// </summary>
        public List<Power> NextPowers { get; private set; }

        /// <summary>
        /// Danh sách các thế lực trước đó.
        /// </summary>
        public List<Power> PreviousPowers { get; private set; }

        /// <summary>
        /// Danh sách NPC.
        /// </summary>
        public List<Army> Armies { get; private set; }

        public static PowerDetail Parse(JToken token) {
            var result = new PowerDetail();

            var armies = new List<Army>();
            if (token["army"] == null)
            {
                return null;
            }
            foreach (var subToken in token["army"]) {
                armies.Add(Army.Parse(subToken));
            }
            result.Armies = armies;
            var power = token["power"];            
            result.Attackable = (bool) power["attackable"];
            result.Campaign = (string) power["campaign"];
            result.Id = (int) power["powerid"];
            result.Name = (string) power["powername"];

            var previousPowers = new List<Power>();
            var prepower = power["prepower"];
            if (prepower == null) {
                // Giặc Khăn Vàng, etc...
            } else {
                foreach (var subToken in prepower) {
                    previousPowers.Add(Power.Parse(subToken));
                }
            }
            result.PreviousPowers = previousPowers;

            var nextPowers = new List<Power>();
            var nextpower = power["nextpower"];
            if (nextpower == null) {
                // TQQA, etc...
            } else {
                foreach (var subToken in nextpower) {
                    nextPowers.Add(Power.Parse(subToken));
                }
            }
            result.NextPowers = nextPowers;

            return result;
        }
    }
}
