using System.Threading.Tasks;

namespace k8asd {
    class ImposeTaskHelper : ITaskHelper {
        public async Task<bool> CanDo(IPacketWriter writer, int times) {
            var imposeInfo = await writer.RefreshImposeAsync();
            if (imposeInfo == null) {
                // Mất kết nối không tính là không làm được.
                return true;
            }

            var remainImposes = imposeInfo.ImposeNum;
            if (remainImposes < times) {
                return false;
            }

            // Không tính tăng cường thu thuế.
            return true;
        }

        public async Task<bool> Do(IPacketWriter writer, int times) {
            for (int i = 0; i < times; ++i) {
                if (!await DoSingle(writer)) {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> DoSingle(IPacketWriter writer) {
            var p = await writer.ImposeAsync();
            if (p == null) {
                return false;
            }

            if (p.HasError) {
                return false;
            }

            // Không làm tăng cường thu thuế.
            return true;
        }
    }
}
