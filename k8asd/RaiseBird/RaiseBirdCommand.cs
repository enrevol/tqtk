using System.Threading.Tasks;

namespace k8asd {
    public static class RaiseBirdCommand {
        /// <summary>
        /// Làm mới võ đài.
        /// </summary>
        public static async Task<Packet> RefreshRaiseBirdAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("66004");
        }

        /// <summary>
        /// Nuôi chim.
        /// </summary>
        /// <param name="type">hình thứ nuôi: 1 bạc, 2 xu.</param>
        public static async Task<Packet> RaiseBirdAsync(this IPacketWriter writer, int type) {
            return await writer.SendCommandAsync("66008", type.ToString(), "1");
        }

        public static async Task<Packet> UpdateInfoAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync("11102");
        }
    }
}
