using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
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
        public static async Task<Packet> AttackArmyAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("34107", "0");
        }
    }
}
