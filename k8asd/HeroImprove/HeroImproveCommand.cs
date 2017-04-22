using System.Threading.Tasks;

namespace k8asd {
    public static class HeroImproveCommand {
        /// <summary>
        /// Cải tiến.
        /// </summary>
        /// <param name="heroId">ID của tướng.</param>
        public static async Task<Packet> ImproveHeroAsync(this IPacketWriter writer, int heroId) {
            return await writer.SendCommandAsync(41301, heroId.ToString(), "0");
        }

        /// <summary>
        /// Giữ cải tiến.
        /// </summary>
        /// <param name="heroId">ID của tướng</param>
        public static async Task<Packet> KeepStatsAsync(this IPacketWriter writer, int heroId) {
            return await writer.SendCommandAsync(41303, heroId.ToString(), "0");
        }
    }
}
