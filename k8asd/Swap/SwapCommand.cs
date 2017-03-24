using System.Threading.Tasks;

namespace k8asd {

    static class SwapCommand {
        /// <summary>
        /// Tìm bang chu.
        /// </summary>
        public static async Task<Packet> RefreshLegionAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("32101", "0", "12", " ");
        }

        public static async Task<Packet> RefreshCollectAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync("30100");
        }

        /// <summary>
        /// Chuyen bang chu.
        /// </summary>
        /// 
        public static async Task<Packet> Swap(this IPacketWriter writer, int slot1Id)
        {
            return await writer.SendCommandAsync("32108", slot1Id+"");
        }

        /// <summary>
        /// Collect.
        /// </summary>
        public static async Task<Packet> Collect(this IPacketWriter writer, int value)
        {
            return await writer.SendCommandAsync("30401", value + "");
        }       
    }
}
