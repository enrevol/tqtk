using System.Threading.Tasks;

namespace k8asd {
    public enum TaskResult {
        /// <summary>
        /// Mất kết nối.
        /// </summary>
        LostConnection,

        /// <summary>
        /// Hoàn thành.
        /// </summary>
        Done,

        /// <summary>
        /// Có thể hoàn thành sau này (hiện tại chưa thể làm được).
        /// </summary>
        CanBeDone,

        /// <summary>
        /// Không thể hoàn thành.
        /// </summary>
        CanNotBeDone,
    }

    public interface ITaskHelper {
        Task<TaskResult> Do(IPacketWriter writer, int times);
    }
}
