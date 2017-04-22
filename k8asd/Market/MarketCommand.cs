using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace k8asd {
    public static class MarketCommand {
        public static async Task<MarketInfo> RefreshMarketAsync(this IPacketWriter writer) {
            var packet = await writer.SendCommandAsync(13100);
            if (packet == null) {
                return null;
            }
            return MarketInfo.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Mua lúa.
        /// </summary>
        /// <param name="amount">Số lượng.</param>
        public static async Task<Packet> BuyPaddyAsync(this IPacketWriter writer, int amount) {
            return await writer.SendCommandAsync(13101, "0", amount.ToString());
        }

        /// <summary>
        /// Bán lúa.
        /// </summary>
        /// <param name="amount">Số lượng.</param>
        public static async Task<Packet> SalePaddyAsync(this IPacketWriter writer, int amount) {
            return await writer.SendCommandAsync(13101, "1", amount.ToString());
        }

        /// <summary>
        /// Mua lúa chợ đen.
        /// </summary>
        /// <param name="amount">Số lượng.</param>
        public static async Task<Packet> BuyPaddyInMaketAsync(this IPacketWriter writer, int amount) {
            return await writer.SendCommandAsync(13101, "2", amount.ToString());
        }
    }
}
