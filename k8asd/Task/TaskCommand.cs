using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public static class TaskCommand {
        /// <summary>
        /// Nhận nhiệm vụ.
        /// </summary>
        /// <param name="taskId">ID nhiêm vụ.</param>
        public static async Task<Packet> AcceptTaskAsync(this IPacketWriter writer, int taskId) {
            return await writer.SendCommandAsync(44101, taskId.ToString());
        }

        /// <summary>
        /// Hủy nhiệm vụ.
        /// </summary>
        /// <param name="taskId">ID nhiêm vụ.</param>
        public static async Task<Packet> CancelTaskAsync(this IPacketWriter writer, int taskId) {
            return await writer.SendCommandAsync(44102, taskId.ToString());
        }

        /// <summary>
        /// Hoàn thành nhiệm vụ.
        /// </summary>
        /// <param name="taskId">ID nhiêm vụ.</param>
        public static async Task<Packet> CompleteTaskAsync(this IPacketWriter writer, int taskId) {
            return await writer.SendCommandAsync(44103, taskId.ToString());
        }

        /// <summary>
        /// Làm mới danh sách nhiệm vụ.
        /// </summary>
        public static async Task<TaskBoard> RefreshTaskBoardAsync(this IPacketWriter writer) {
            var packet = await writer.SendCommandAsync(44301);
            if (packet == null) {
                return null;
            }
            return TaskBoard.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Lấy thông tin của nhiêm vụ.
        /// </summary>
        /// <param name="taskId">ID nhiêm vụ.</param>
        public static async Task<TaskDetail> RefreshTaskAsync(this IPacketWriter writer, int taskId) {
            var packet = await writer.SendCommandAsync(44201, taskId.ToString());
            if (packet == null) {
                return null;
            }
            return TaskDetail.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Lấy danh sách tướng quân để chọn ID tướng quân cải tiến.
        /// </summary>s
        public static async Task<Packet> GetListHeroAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("41100", "0");
        }

        /// <summary>
        /// Cải tiến.
        /// </summary>s
        public static async Task<Packet> HeroImproveAsync(this IPacketWriter writer, int idHero) {
            return await writer.SendCommandAsync("41301", idHero.ToString(), "0");
        }

        /// <summary>
        /// Giữ gải tiến.
        /// </summary>s
        public static async Task<Packet> NotUpdateHeroImproveAsync(this IPacketWriter writer, int idHero) {
            return await writer.SendCommandAsync("41303", idHero.ToString(), "0");
        }       

        /// <summary>
        /// Ủy phái ngựa 1.
        /// </summary>s
        public static async Task<Packet> CommissionAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("40102", "1", "0");
        }

        /// <summary>
        /// Nhận vật phẩm ủy phái.
        /// </summary>s
        public static async Task<Packet> AcceptCommissionAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("40103");
        }

        /// <summary>
        /// phá băng ủy phái.
        /// </summary>s
        public static async Task<Packet> BreakIceCommissionAsync(this IPacketWriter writer) {
            return await writer.SendCommandAsync("11301", "8", "0");
        }
    }
}
