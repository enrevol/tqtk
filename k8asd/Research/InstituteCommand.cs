using System.Threading.Tasks;

namespace k8asd {
    public static class ResearchCommand {
        /// <summary>
        /// Lấy danh sách các kỹ năng.
        /// </summary>
        public static async Task<Packet> GetListResearchAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("63601");
        }

        public static async Task<Packet> ChangeResearchAsync(this IPacketWriter writer, int department, int type) {
            return await writer.SendCommandAsync("63603", department.ToString(), type.ToString());
        }

        public static async Task<Packet> UpdateResearchAsync(this IPacketWriter writer, int department) {
            return await writer.SendCommandAsync("63604", department.ToString());
        }
    }
}
