using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class UpgradeTaskHelper : ITaskHelper {
        public async Task<TaskResult> Do(IPacketWriter writer, int times) {
            const int max_weapon_count = 20;
            var info = await writer.RefreshUpgradeAsync(1, 0, max_weapon_count);
            if (info == null) {
                return TaskResult.LostConnection;
            }

            var weapon = info.Equipments.FirstOrDefault(item => item.Quality == EquipmentQuality.Trang);
            if (weapon == null) {
                // Không có vũ khí trắng.
                return TaskResult.CanNotBeDone;
            }

            // Hạ cấp hàng loạt.
            var p0 = await writer.DegradeEquipmentAllAsync(weapon.Id);
            if (p0 == null) {
                return TaskResult.LostConnection;
            }

            for (int i = 0; i < times; ++i) {
                var result = await DoSingle(writer, weapon.Id, info.Magic);
                if (result != TaskResult.Done) {
                    return result;
                }
            }
            return TaskResult.Done;
        }

        private async Task<TaskResult> DoSingle(IPacketWriter writer, int equipmentId, int magic) {
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
                return await DoSingle(writer, equipmentId, magic);
            }

            return TaskResult.Done;
        }
    }
}
