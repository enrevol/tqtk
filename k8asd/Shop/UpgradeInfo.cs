using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public enum MagicState {
        Down = 0,
        Up = 1
    }

    /// <summary>
    /// Dịch gói 39301.
    /// </summary>
    public class UpgradeInfo {
        private Cooldown upgradeCooldown;

        /// <summary>
        /// Số lượng trang bị.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Có thể dùng xu để làm ma lực 100% không? (VIP 4)
        /// </summary>
        public bool CanUseGold { get; private set; }

        /// <summary>
        /// Ma lực.
        /// </summary>
        public int Magic { get; private set; }

        public MagicState MagicState { get; private set; }

        /// <summary>
        /// Số lượng xu cần để đạt 100% ma lực.
        /// </summary>
        public int GoldToSuccess { get; private set; }

        public bool CanUpgrade { get; private set; }

        public int Cooldown { get { return upgradeCooldown.RemainingMilliseconds; } }

        public static UpgradeInfo Parse(JToken token) {
            var result = new UpgradeInfo();

            result.Count = 0;
            if (token["numCount"] != null) {
                // Cập nhật thứ tự trang=0 thì mới có token này.
                result.Count = (int) token["numCount"];
            }

            result.CanUseGold = (bool) token["canusegold"];
            result.Magic = (int) token["magic"];
            result.MagicState = (MagicState) (int) token["magicstate"];
            result.GoldToSuccess = (int) token["gold2Success"];
            result.CanUseGold = (bool) token["upgradecdusable"];

            var cd = (int) token["cd"];
            result.upgradeCooldown = new Cooldown(cd);

            return result;
        }
    }
}
