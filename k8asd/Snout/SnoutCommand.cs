using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace k8asd {
    static class SnoutCommand
    {
        /// <summary>
        /// Tìm khu vuc.
        /// </summary>
        public static async Task<Packet> RefreshAreaAsync(this IPacketWriter writer)
        {
            return await writer.SendCommandAsync(31101, "-1");
        }

        /// <summary>
        /// Tìm ai đang chiếm mỏ.
        /// </summary>
        public static async Task<Packet> FindSnoutAsync(this IPacketWriter writer, string areaID)
        {
            return await writer.SendCommandAsync(31102, areaID, "1");
        }

        /// <summary>
        /// Bỏ mỏ.
        /// </summary>
        public static async Task<Packet> BreakSnoutAsync(this IPacketWriter writer, string index)
        {
            return await writer.SendCommandAsync(31105, "1", index, "2");
        }

        /// <summary>
        /// Chiếm mỏ.
        /// </summary>
        public static async Task<Packet> AttackSnoutAsync(this IPacketWriter writer, string areaID, string index)
        {
            return await writer.SendCommandAsync(31107, areaID, "1", index);
        }

        /// <summary>
        /// Ấn mỏ.
        /// </summary>
        public static async Task<Packet> BlockSnoutAsync(this IPacketWriter writer, string index)
        {
            return await writer.SendCommandAsync(31109, index, "1", "1");
        }
    }
}
