using System;
using System.Threading.Tasks;

namespace k8asd {
    public class ImposeTaskHelper : ITaskHelper {
        private static class Difficulty {
            public const int FreezingMultiplier = 1;
            public const int NotOk = 2000;
            public const int OverSilver = 100;
        }

        private IPacketWriter writer;
        private IInfoModel info;
        private ImposeInfo impose;

        public ImposeTaskHelper(IPacketWriter writer, IInfoModel info, ImposeInfo impose) {
            this.writer = writer;
            this.info = info;
            this.impose = impose;
        }

        public double PredictDifficulty(int times) {
            if (impose.ImposeNum < times) {
                return Difficulty.NotOk;
            }
            var silverEachImpose = impose.Copper;
            if (info.Silver + silverEachImpose * times > info.MaxSilver) {
                // Tràn bạc.
                return Difficulty.OverSilver;
            }

            // Tăng độ khó vì đóng băng lâu.
            return times * Difficulty.FreezingMultiplier;
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
