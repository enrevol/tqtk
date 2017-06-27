using System.Threading.Tasks;

namespace k8asd {
    static class OutsideCommand {
        public static Task<Packet> RefreshOutsideAsync(this IPacketWriter writer, long playerId) {
            return writer.SendCommandAsync("62002", playerId.ToString());
        }

        public static Task<Packet> DrillAsync(this IPacketWriter writer) {
            return writer.SendCommandAsync("62006", "3", "101", "0", "0");
        }

        public static Task<Packet> GetDrillResultAsync(this IPacketWriter writer) {
            return writer.SendCommandAsync("62007", "3", "101");
        }
    }
}
