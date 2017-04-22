using System.Threading.Tasks;

namespace k8asd {
    interface ITaskHelper {
        Task<bool> CanDo(IPacketWriter writer, int times);

        Task<bool> Do(IPacketWriter writer, int times);
    }
}
