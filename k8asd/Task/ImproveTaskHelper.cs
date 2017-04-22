using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace k8asd {
    class ImproveTaskHelper : ITaskHelper {
        public Task<bool> CanDo(IPacketWriter writer, int times) {
            return Task.FromResult(true);
        }

        public async Task<bool> Do(IPacketWriter writer, int times) {
            var p = await writer.GetListHeroAsync();
            if (p == null) {
                return false;
            }

            var barracks = Barracks.Parse(JToken.Parse(p.Message));

            // Cải tiến tướng đầu tiên.
            var heroId = barracks.Heroes[0].Id;

            // Giữ chỉ số cũ (trường hợp đã cải tiến trước).
            // Tránh lỗi: "Võ tướng có thuộc tính mới chưa thay"
            var p0 = await writer.KeepStatsAsync(heroId);
            if (p0 == null) {
                return false;
            }

            for (int i = 0; i < times; ++i) {
                if (!await DoSingle(writer, heroId)) {
                    return false;
                }
            }
            return true;
        }

        private async Task<bool> DoSingle(IPacketWriter writer, int heroId) {
            var p1 = await writer.ImproveHeroAsync(heroId);
            if (p1 == null) {
                return false;
            }

            if (p1.HasError) {
                // Không đủ chiến tích.
                return false;
            }

            // Giữ chỉ số.
            var p2 = writer.KeepStatsAsync(heroId);
            if (p2 == null) {
                return false;
            }

            return true;
        }
    }
}
