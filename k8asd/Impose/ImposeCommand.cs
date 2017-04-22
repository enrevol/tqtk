using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace k8asd {
    public static class ImposeCommand {
        public static async Task<ImposeInfo> RefreshImposeAsync(this IPacketWriter writer) {
            var packet = await writer.SendCommandAsync(12400);
            if (packet == null) {
                return null;
            }
            return ImposeInfo.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Thu thuế.
        /// </summary>
        public static async Task<Packet> CollectTaxAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync(12401, "0", "0");
        }

        /// <summary>
        /// Tăng cường thu thuế.
        /// </summary>
        public static async Task<Packet> IncreaseTaxAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync(12401, "1", "1");
        }
    }
}
