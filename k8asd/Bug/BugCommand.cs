using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd
{
    public static class BugCommand
    {
        /// <summary>
        /// Nhận thưởng tiêu xu hằng ngày.
        /// </summary>
        public static async void UseGoldDailyAsync(this IPacketWriter writer) {
            for (int i = 1; i < 32; i++) {
                await writer.SendCommandAsync("64631", i.ToString(), "2");
                await Task.Delay(500);
            }
        }
    }
}
