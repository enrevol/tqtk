using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public static class HeroTrainingCommand {
        public static async Task<Packet> TrainHeroAsync(this IPacketWriter writer, int heroId) {
            return await writer.SendCommandAsync("41101", heroId.ToString(), "1");
        }
    }
}
