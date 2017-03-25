using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    static class MapCommand {
        public static async Task<Packet> RefreshWorldAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("30100");
        }
    }
}
