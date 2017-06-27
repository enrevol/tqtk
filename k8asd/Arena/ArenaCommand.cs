using System.Threading.Tasks;

namespace k8asd {
    public static class ArenaCommand {
        /// <summary>
        /// Làm mới võ đài.
        /// </summary>
        public static async Task<Packet> RefreshArenaAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("64005");
        }

        /// <summary>
        /// Khiêu chiến với người chơi khác.
        /// </summary>
        /// <param name="playerId">ID của người chơi bị khiêu chiến.</param>
        /// <param name="playerRank">Thứ hạng hiện tại của người chơi bị khiêu chiến.</param>
        public static async Task<Packet> DuelArenaAsync(this IPacketWriter writer, long playerId, int playerRank) {
            return await writer.SendCommandAsync("64007", playerId.ToString(), playerRank.ToString());
        }
    }
}
