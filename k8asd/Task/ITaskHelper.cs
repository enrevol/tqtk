using System.Threading.Tasks;

namespace k8asd {
    interface ITaskHelper {
        /// <summary>
        /// Kiếm tra xem có hoàn thành được nhiệm vụ này không?
        /// </summary>
        /// <param name="times">Số lần làm.</param>
        Task<bool> CanDo(IPacketWriter writer, int times);

        Task<bool> Do(IPacketWriter writer, int times);
    }
}
