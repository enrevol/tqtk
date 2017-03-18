using System;
using System.Threading.Tasks;

namespace k8asd {
    enum ArmyTeamLimit {
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

    enum ArmyType {
        /// <summary>
        /// NPC thường.
        /// </summary>
        Normal = 1,

        /// <summary>
        /// NCP tinh anh (rớt đồ).
        /// </summary>
        Elite = 2,

        /// <summary>
        /// NPC tướng (đánh 1 lần).
        /// </summary>
        Hero = 3,

        /// <summary>
        /// Quân đoàn.
        /// </summary>
        Army = 5,
    }

    enum PartyType {
        /// <summary>
        /// Thường.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Đặc công.
        /// </summary>
        Special = 1,
    }

    static class ArmyCommand {
        public static async Task<Packet> RefreshPowerAsync(this IPacketWriter writer, int powerId) {
            return await writer.SendCommandAsync("33100", powerId.ToString());
        }

        /// <summary>
        /// Cập nhật thông tin thế lực.
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public static async Task<Packet> RefreshPowerAreaAsync(this IPacketWriter writer, int powerAreaId) {
            return await writer.SendCommandAsync("33201", powerAreaId.ToString());
        }

        public static async Task<Packet> RefreshArmyAsync(this IPacketWriter writer, int armyId) {
            return await writer.SendCommandAsync("34100", armyId.ToString());
        }

        /// <summary>
        /// Tạo tổ đội quân đoàn.
        /// </summary>
        /// <param name="armyId">ID của quân đoàn.</param>
        /// <param name="minimumLevel">Giới hạn cấp độ tối thiểu.</param>
        /// <param name="limit">Giới hạn chung</param>
        public static async Task<Packet> CreateArmyAsync(this IPacketWriter writer, int armyId,
            int minimumLevel, ArmyTeamLimit limit, PartyType partyType) {
            return await writer.SendCommandAsync("34101", armyId.ToString(),
                String.Format("4:{0};{1}", minimumLevel, (int) limit), ((int) partyType).ToString());
        }

        /// <summary>
        /// Gia nhập tổ đội.
        /// </summary>
        public static async Task<Packet> JoinArmyAsync(this IPacketWriter writer, int teamId) {
            return await writer.SendCommandAsync("34102", teamId.ToString());
        }

        /// <summary>
        /// Di chuyển người chơi lên 1 vị trí trong tổ đội.
        /// </summary>
        public static async Task<Packet> MoveArmyPlayerUpAsync(this IPacketWriter writer, int playerId) {
            return await writer.SendCommandAsync("34103", playerId.ToString(), "0");
        }

        /// <summary>
        /// Di chuyển người chơi xuống 1 vị trí trong tổ đội.
        /// </summary>
        public static async Task<Packet> MoveArmyPlayerDownAsync(this IPacketWriter writer, int playerId) {
            return await writer.SendCommandAsync("34103", playerId.ToString(), "1");
        }

        /// <summary>
        /// Kick người chơi ta khỏi tổ đội.
        /// </summary>
        public static async Task<Packet> KickArmyPlayerAsync(this IPacketWriter writer, int playerId) {
            return await writer.SendCommandAsync("34104", playerId.ToString());
        }

        /// <summary>
        /// Giải tán tổ đội.
        /// </summary>
        public static async Task<Packet> DisbandArmyAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("34105");
        }

        /// <summary>
        /// Thoát khỏi tổ đội.
        /// </summary>
        public static async Task<Packet> QuitArmyAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("34106");
        }

        /// <summary>
        /// Tấn công tổ đội.
        /// </summary>
        public static async Task<Packet> AttackArmyAsync(this IPacketWriter writer, PartyType partyType) {
            return await writer.SendCommandAsync("34107", ((int) partyType).ToString());
        }
    }
}
