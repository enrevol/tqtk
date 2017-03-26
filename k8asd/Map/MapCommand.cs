using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace k8asd {
    static class MapCommand {
        public static async Task<Packet> RefreshWorldAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("30100");
        }

        public static async Task<Scope> RefreshAreaAsync(this IPacketWriter writer, int areaId) {
            var packet = await writer.SendCommandAsync("31101", areaId.ToString());
            if (packet == null) {
                return null;
            }
            return Scope.Parse(JToken.Parse(packet.Message));
        }

        public static async Task<Scope> RefreshScopeAsync(this IPacketWriter writer, int areaId, int scopeId) {
            var packet = await writer.SendCommandAsync("31102", areaId.ToString(), scopeId.ToString());
            if (packet == null) {
                return null;
            }
            return Scope.Parse(JToken.Parse(packet.Message));
        }

        public static async Task<CityDetail> RefreshCityAsync(this IPacketWriter writer, int areaId, int scopeId, int cityIndex) {
            var packet = await writer.SendCommandAsync("31106", areaId.ToString(), scopeId.ToString(), cityIndex.ToString());
            if (packet == null) {
                return null;
            }
            return CityDetail.Parse(JToken.Parse(packet.Message));
        }
    }
}
