using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace k8asd {
    public class UpgradeTaskHelper : ITaskHelper {
        private IPacketWriter writer;
        private IPlayerInfo info;
        private UpgradeInfo upgrade;

        public UpgradeTaskHelper(IPacketWriter writer, IPlayerInfo info, UpgradeInfo upgrade) {
            this.writer = writer;
            this.info = info;
            this.upgrade = upgrade;
        }

        public int PredictDifficulty(int times) {
            var weapon = upgrade.Equipments.FirstOrDefault(item => item.Quality == EquipmentQuality.Trang);
            if (weapon == null) {
                // Không có vũ khí trắng.
                return TaskDifficulty.CanNotBeDone;
            }

            const int UpgradeCost = 1000;
            int okTimes = 0;
            var silver = info.Silver;
            while (okTimes < times && silver > UpgradeCost) {
                ++okTimes;
            }
            if (okTimes == times) {
                return TaskDifficulty.UpgradeOk(times);
            }
            return TaskDifficulty.UpgradeNotOk(okTimes, times - okTimes);
        }

        public async Task<TaskResult> Do(int times) {
            var weapon = upgrade.Equipments.FirstOrDefault(item => item.Quality == EquipmentQuality.Trang);
            if (weapon == null) {
                // Không có vũ khí trắng.
                Debug.Assert(false);
                return TaskResult.CanNotBeDone;
            }

            // Hạ cấp hàng loạt.
            var p0 = await writer.DegradeEquipmentAllAsync(weapon.Id);
            if (p0 == null) {
                return TaskResult.LostConnection;
            }

            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(weapon.Id, upgrade.Magic);
                if (result != TaskResult.Done) {
                    return result;
                }
            }
            return TaskResult.Done;
        }

        private async Task<TaskResult> DoSingle(int equipmentId, int magic) {
            var p = await writer.UpgradeEquipmentAsync(equipmentId, magic);
            if (p == null) {
                return TaskResult.LostConnection;
            }

            if (p.HasError) {
                // Giá trị ma lực đã đổi.
                // Đóng băng.
                // Không đủ bạc.
                return TaskResult.CanBeDone;
            }

            if (!p.Successful) {
                // Thất bại, làm lại.
                return await DoSingle(equipmentId, magic);
            }

            return TaskResult.Done;
        }
    }
}
