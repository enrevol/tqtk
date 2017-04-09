using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Dịch gói tin 41100.
    /// </summary>
    public class Barracks {
        private Cooldown guideCooldown;

        public List<Hero> Heroes { get; private set; }

        /// <summary>
        /// Số lượng vị trí huấn luyện đang dùng.
        /// </summary>
        public int CurrentSlots { get; private set; }

        /// <summary>
        /// Số lượng vị trí huận luyện tối đa.
        /// </summary>
        public int MaxSlots { get; private set; }

        /// <summary>
        /// Mãnh tiến lệnh.
        /// </summary>
        public int MTL { get; private set; }

        /// <summary>
        /// Có thể mãnh tiến hay không? (đóng băng)
        /// </summary>
        public bool CanGuide { get; private set; }

        /// <summary>
        /// Thời gian đóng băng mãnh tiến (mi-li-giây).
        /// </summary>
        public int GuideCooldown {
            get { return guideCooldown.RemainingMilliseconds; }
        }

        public static Barracks Parse(JToken token) {
            var result = new Barracks();
            result.CurrentSlots = (int) token["currentnum"];
            result.MaxSlots = (int) token["maxnum"];
            result.MTL = (int) token["tufeiTokenCount"];
            result.CanGuide = (bool) token["guidecdusable"];
            result.guideCooldown = new Cooldown((int) token["cd"]);

            var heroes = new List<Hero>();
            var general = token["general"];
            foreach (var subToken in general) {
                heroes.Add(Hero.Parse(subToken));
            }
            result.Heroes = heroes;

            return result;
        }
    }
}
