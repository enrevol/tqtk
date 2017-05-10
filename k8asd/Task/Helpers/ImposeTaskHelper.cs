using System;
using System.Threading.Tasks;

namespace k8asd {
    public class ImposeTaskHelper : ITaskHelper {
        private IPacketWriter writer;
        private IPlayerInfo info;
        private ImposeInfo impose;

        public ImposeTaskHelper(IPacketWriter writer, IPlayerInfo info, ImposeInfo impose) {
            this.writer = writer;
            this.info = info;
            this.impose = impose;
        }

        public int PredictDifficulty(int times) {
            if (impose.ImposeNum < times) {
                return TaskDifficulty.ImposeNotOk();
            }

            var silverEachImpose = impose.Copper;
            if (info.Silver + silverEachImpose * times > info.MaxSilver) {
                // Tràn bạc.
                return TaskDifficulty.ImposeOverSilver(times);
            }

            return TaskDifficulty.ImposeOk(times);
        }

        public async Task<TaskResult> Do(int times) {
            var remainImposes = impose.ImposeNum;
            if (remainImposes < times) {
                return TaskResult.CanNotBeDone;
            }

            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(writer);
                if (result != TaskResult.Done) {
                    return result;
                }

                // Tránh kẹt acc.
                await Task.Delay(250);
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
