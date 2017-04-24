using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd
{
    public static class MailCommand{
        /// <summary>
        /// Nhận liên thắng.
        /// </summary>
        /// <param name="year">năm nhận liên thắng.</param>
        /// <param name="lt">số liên thắng.</param>
        public static async Task<Packet> GetMailLTAsync(this IPacketWriter writer, int year, int lt){
            return await writer.SendCommandAsync(60603, "12", "0", year.ToString() + lt.ToString(), lt.ToString());
        }
        /// <summary>
        /// Nhận liên thắng.
        /// </summary>
        /// <param name="year">năm nhận liên thắng.</param>
        /// <param name="lt">số liên thắng.</param>
        public static async Task<Packet> GetMailTTCAsync(this IPacketWriter writer, int year, int boss){
            return await writer.SendCommandAsync(60601, boss.ToString(), year.ToString());
        }
    }
}
