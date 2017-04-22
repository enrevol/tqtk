using Newtonsoft.Json.Linq;

namespace k8asd {
    public class ImposeInfo {
        private Cooldown imposeCooldown;

        /// <summary>
        /// Đẳng cấp đại điện.
        /// </summary>
        public int OfficeLevel { get; private set; }

        /// <summary>
        /// Kỹ thuật thu thuế.
        /// </summary>
        public int LegionImposeTech { get; private set; }

        /// <summary>
        /// Tổng cấp nhà dân.
        /// </summary>
        public int HouseLevel { get; private set; }

        /// <summary>
        /// Độ thịnh vượng.
        /// </summary>
        public int AreaProsperity { get; private set; }

        /// <summary>
        /// Thu nhập bạc.
        /// </summary>
        public int Copper { get; private set; }

        /// <summary>
        /// Đẳng cấp sở thuế.
        /// </summary>
        public int CountingLevel { get; private set; }

        /// <summary>
        /// Số lần thu thuế còn lại.
        /// </summary>
        public int ImposeNum { get; private set; }

        /// <summary>
        /// Số lần thu thuế tối đa.
        /// </summary>
        public int ImposeMaxNum { get; private set; }

        /// <summary>
        /// Đẳng cấp xưởng vàng.
        /// </summary>
        public int MoneyFactoryLevel { get; private set; }

        /// <summary>
        /// Xu tốn để tăng cường thu thuế.
        /// </summary>
        public int ForceImposeCost { get; private set; }

        /// <summary>
        /// Dân tâm.
        /// </summary>
        public int Loyalty { get; private set; }

        public bool CanImpose { get; private set; }

        public int Cooldown { get { return imposeCooldown.RemainingMilliseconds; } }

        public static ImposeInfo Parse(JToken token) {
            var result = new ImposeInfo();
            var imposedto = token["imposedto"];
            result.OfficeLevel = (int) imposedto["officelv"];
            result.LegionImposeTech = (int) imposedto["legionimposetech"];
            result.HouseLevel = (int) imposedto["houseslv"];
            result.Copper = (int) imposedto["copper"];
            result.AreaProsperity = (int) imposedto["areaprosper"];
            result.CountingLevel = (int) imposedto["countinglv"];
            result.ImposeNum = (int) imposedto["imposenum"];
            result.ImposeMaxNum = (int) imposedto["imposemaxnum"];
            result.MoneyFactoryLevel = (int) imposedto["moneyfactorylv"];
            result.ForceImposeCost = (int) imposedto["forceimposecost"];
            result.Loyalty = (int) imposedto["loyalty"];
            result.CanImpose = (bool) imposedto["imposecdusable"];
            int cd = (int) imposedto["lastimposetime"];
            result.imposeCooldown = new Cooldown(cd);
            return result;
        }
    }
}
