using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd
{
    public static class ReherseCommand
    {
        public static async Task<Packet> RefreshListMemberAsync(this IPacketWriter writer, int page)
        {
            return await writer.SendCommandAsync("32101", (page-1).ToString(), "12", " ");
        }

        public static async Task<Packet> ReherseAsync(this IPacketWriter writer, long playerid)
        {
            return await writer.SendCommandAsync("32132", playerid.ToString());
        }
    }
}
