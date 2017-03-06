using System.Threading.Tasks;

namespace k8asd {
    public static class FormationCommand {
        public static async Task<Packet> SetDefaultFormationAsync(this IPacketWriter writer, int formationId) {
            return await writer.SendCommandAsync("42104", formationId.ToString());
        }

        public static async Task<Packet> RemoveAllHeroesFromFormationAsync(this IPacketWriter writer, int formationId) {
            return await writer.SendCommandAsync("42107", formationId.ToString());
        }
    }
}
