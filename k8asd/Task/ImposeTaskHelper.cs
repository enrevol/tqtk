using System.Threading.Tasks;

namespace k8asd {
    class ImposeTaskHelper : ITaskHelper {
        public async Task<TaskResult> Do(IPacketWriter writer, int times) {
            var imposeInfo = await writer.RefreshImposeAsync();
            if (imposeInfo == null) {
                return TaskResult.LostConnection;
            }

            var remainImposes = imposeInfo.ImposeNum;
            if (remainImposes < times) {
                return TaskResult.CanNotBeDone;
            }

            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(writer);
                if (result != TaskResult.Done) {
                    return result;
                }
            }
            return TaskResult.Done;
        }

        private async Task<TaskResult> DoSingle(IPacketWriter writer) {
            var p = await writer.ImposeAsync();
            if (p == null) {
                return TaskResult.LostConnection;
            }

            if (p.HasError) {
                // Đóng băng.
                return TaskResult.CanBeDone;
            }

            // Không làm tăng cường thu thuế.
            return TaskResult.Done;
        }
    }
}
