﻿using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace k8asd {
    public class ImproveTaskHelper : ITaskHelper {
        private IPacketWriter writer;
        private IInfoModel info;

        public ImproveTaskHelper(IPacketWriter writer, IInfoModel info) {
            this.writer = writer;
            this.info = info;
        }

        public double PredictDifficulty(int times) {
            // FIXME:
            // Cho mỗi lần cải tiến hết 800 chiến tích.
            const double ImproveCost = 800;

            var needed = ImproveCost * times;
            if (needed > info.Honor) {
                return 1500;
            }

            return 0;
        }

        public async Task<TaskResult> Do(int times) {
            var p = await writer.GetListHeroAsync();
            if (p == null) {
                return TaskResult.LostConnection;
            }

            var barracks = Barracks.Parse(JToken.Parse(p.Message));

            // Cải tiến tướng đầu tiên.
            var heroId = barracks.Heroes[0].Id;

            // Giữ chỉ số cũ (trường hợp đã cải tiến trước).
            // Tránh lỗi: "Võ tướng có thuộc tính mới chưa thay"
            var p0 = await writer.KeepStatsAsync(heroId);
            if (p0 == null) {
                return TaskResult.LostConnection;
            }

            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(writer, heroId);
                if (result != TaskResult.Done) {
                    return result;
                }
            }
            return TaskResult.Done;
        }

        private async Task<TaskResult> DoSingle(int heroId) {
            var p1 = await writer.ImproveHeroAsync(heroId);
            if (p1 == null) {
                return TaskResult.LostConnection;
            }

            if (p1.HasError) {
                // Không đủ chiến tích.
                return TaskResult.CanBeDone;
            }

            // Giữ chỉ số.
            var p2 = writer.KeepStatsAsync(heroId);
            if (p2 == null) {
                return TaskResult.LostConnection;
            }

            return TaskResult.Done;
        }
    }
}
