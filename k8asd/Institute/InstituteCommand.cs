using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace k8asd {
    public enum InstituteImproveType {
        /// <summary>
        /// Phổ thông: 10K bạc.
        /// </summary>
        PhoThong = 0,

        /// <summary>
        /// Bạch kim: 15 xu.
        /// </summary>
        BachKim = 1,

        /// <summary>
        /// Chí tôn: 60 xu.
        /// </summary>
        ChiTon = 2
    }

    public static class InstituteCommand {
        /// <summary>
        /// Làm mới sở nghiên cứu.
        /// </summary>
        public static async Task<InstituteInfo> RefreshInstituteAsync(this IPacketWriter writer) {
            var packet = await writer.SendCommandAsync("63601");
            if (packet == null) {
                return null;
            }
            return InstituteInfo.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Làm mới kỹ năng trong sở nghiên cứu.
        /// </summary>
        /// <param name="techId">ID của kỹ năng.</param>
        /// <param name="type"></param>
        public static async Task<StatePacket> ImproveInstituteTechAsync(this IPacketWriter writer, int techId, InstituteImproveType type) {
            var packet = await writer.SendCommandAsync("63603", techId.ToString(), ((int) type).ToString());
            return StatePacket.Parse(packet);
        }

        /// <summary>
        /// Thay thế giá trị kỹ năng (sau khi làm mới).
        /// </summary>
        /// <param name="techId">ID của kỹ năng.</param>
        public static async Task<StatePacket> ChangeInstituteTechAsync(this IPacketWriter writer, int techId) {
            var packet = await writer.SendCommandAsync("63604", techId.ToString());
            return StatePacket.Parse(packet);
        }
    }
}
