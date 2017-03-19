using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    enum CampaignTeamLimit {
        /// <summary>
        /// Không giới hạn.
        /// </summary>
        None = 1,

        /// <summary>
        /// Giới hạn quốc gia.
        /// </summary>
        Nation = 2,

        /// <summary>
        /// Giới hạn bang hội.
        /// </summary>
        Legion = 3,
    }

    static class CampaignCommand {
        /// <summary>
        /// Tạo tổ đội chiến dịch.
        /// </summary>
        /// <param name="campaignId">ID của chiến dịch.</param>
        /// <param name="minimumLevel">Giới hạn cấp độ tối thiểu.</param>
        /// <param name="limit">Giới hạn chung</param>
        public static async Task<Packet> CreateCampaignAsync(this IPacketWriter writer, int campaignId, int minimumLevel, CampaignTeamLimit limit) {
            return await writer.SendCommandAsync("47001", campaignId.ToString(), String.Format("4:{0};{1}", minimumLevel, (int) limit));
        }

        /// <summary>
        /// Gia nhập chiến dịch.
        /// </summary>
        public static async Task<Packet> JoinCampaignAsync(this IPacketWriter writer, int teamId) {
            return await writer.SendCommandAsync("47002", teamId.ToString());
        }

        /// <summary>
        /// Di chuyển người chơi lên 1 vị trí trong tổ đội.
        /// </summary>
        public static async Task<Packet> MoveCampaignyPlayerUpAsync(this IPacketWriter writer, int playerId) {
            return await writer.SendCommandAsync("47003", playerId.ToString(), "0");
        }

        /// <summary>
        /// Di chuyển người chơi xuống 1 vị trí trong tổ đội.
        /// </summary>
        public static async Task<Packet> MoveCampaignPlayerDownAsync(this IPacketWriter writer, int playerId) {
            return await writer.SendCommandAsync("47003", playerId.ToString(), "1");
        }

        /// <summary>
        /// Kick người chơi ta khỏi tổ đội.
        /// </summary>
        public static async Task<Packet> KickCampaignPlayerAsync(this IPacketWriter writer, int playerId) {
            return await writer.SendCommandAsync("47004", playerId.ToString());
        }

        /// <summary>
        /// Thoát khỏi tổ đội.
        /// </summary>
        public static async Task<Packet> QuitCampaignAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("47005");
        }

        /// <summary>
        /// Giải tán tổ đội.
        /// </summary>
        public static async Task<Packet> DisbandCampaignAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("47006");
        }

        /// <summary>
        /// Tấn công tổ đội.
        /// </summary>
        public static async Task<Packet> AttackCampaignAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("47007");
        }

        /// <summary>
        /// Di chuyển đến toạ độ được chỉ định.
        /// </summary>
        /// <param name="x">Toạ độ ngang.</param>
        /// <param name="y">Toạ độ dọc.</param>
        /// <param name="campaignId">ID của chiến dịch.</param>
        /// <returns></returns>
        public static async Task<Packet> MoveCampaignAsync(this IPacketWriter writer, int x, int y, int campaignId) {
            return await writer.SendCommandAsync("47102", x.ToString(), y.ToString(), campaignId.ToString());
        }
    }
}
