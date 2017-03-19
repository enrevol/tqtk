using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Giới hạn cho lập tổ đội vải.
    /// </summary>
    public enum WeaveTeamLimit {
        /// <summary>
        /// Giới hạn quốc gia.
        /// </summary>
        Nation = 1,

        /// <summary>
        /// Giới hạn bang hội.
        /// </summary>
        Legion = 2,
    }

    static class WeaveCommand {
        /// <summary>
        /// Cập nhật thông tin dệt.
        /// </summary>
        public static async Task<Packet> RefreshWeaveAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("45200");
        }

        /// <summary>
        /// Lập tổ đội dệt.
        /// </summary>
        /// <param name="productId">ID vải.</param>
        /// <param name="limit">Giới hạn.</param>
        public static async Task<Packet> CreateWeaveAsync(this IPacketWriter writer, int productId, WeaveTeamLimit limit) {
            return await writer.SendCommandAsync("45202", productId.ToString(), "0", ((int) limit).ToString());
        }

        /// <summary>
        /// Kick người chơi trong tổ đội dệt.
        /// </summary>
        /// <param name="teamId">ID tổ đội.</param>
        /// <param name="playerId">ID người chơi</param>
        public static async Task<Packet> KickWeaveAsync(this IPacketWriter writer, int teamId, int playerId) {
            return await writer.SendCommandAsync("45206", teamId.ToString(), playerId.ToString());
        }

        /// <summary>
        /// Giải tán tổ đội dệt.
        /// </summary>
        /// <param name="teamId">ID tổ đội.</param>        
        public static async Task<Packet> DisbandWeaveAsync(this IPacketWriter writer, int teamId) {
            return await writer.SendCommandAsync("45207", teamId.ToString());
        }

        /// <summary>
        /// Chế tạo.
        /// </summary>
        /// <param name="teamId">ID tổ đội.</param>
        public static async Task<Packet> MakeWeaveAsync(this IPacketWriter writer, int teamId) {
            return await writer.SendCommandAsync("45208", teamId.ToString());
        }

        /// <summary>
        /// Gia nhập tổ đội dệt.
        /// </summary>
        /// <param name="teamId">ID tổ đội.</param>
        public static async Task<Packet> JoinWeaveAsync(this IPacketWriter writer, int teamId) {
            return await writer.SendCommandAsync("45209", teamId.ToString());
        }

        /// <summary>
        /// Thoát tổ đội dệt.
        /// </summary>
        /// <param name="teamId">ID tổ đội.</param>
        public static async Task<Packet> QuitWeaveAsync(this IPacketWriter writer, int teamId) {
            return await writer.SendCommandAsync("45210", teamId.ToString());
        }

        /// <summary>
        /// Thoát và chế tạo một lúc.
        /// </summary>
        /// <param name="teamId">ID tổ đội</param>
        public static async Task<Packet> QuitAndMakeWeaveAsync(this IPacketWriter writer, int teamId) {
            // Nếu gửi gói thoát => gửi gói chế tạo => nhận gói thoát => xảy ra lỗi error code 45208.
            // Nên gửi rồi nhận cho xong.
            var p0 = await writer.QuitWeaveAsync(teamId);
            if (p0 == null) {
                return null;
            }
            var p1 = await writer.MakeWeaveAsync(teamId);
            if (p1 == null) {
                return null;
            }
            return p1;
        }
    }
}
