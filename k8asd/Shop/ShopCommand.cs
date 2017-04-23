using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace k8asd {
    public static class ShopCommand {
        /// <summary>
        /// Giao diện túi đồ.
        /// </summary>
        /// <param name="index">Thứ tự của trang.</param>
        /// <param name="size">Kích thước của mỗi trang.</param>
        public static async Task<StoreInfo> RefreshStoreAsync(this IPacketWriter writer, int index, int size) {
            var packet = await writer.SendCommandAsync(39100, index.ToString(), size.ToString());
            if (packet == null) {
                return null;
            }
            return StoreInfo.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Hạ cấp trang bị.
        /// </summary>
        /// <param name="equipmentId">ID của trang bị.</param>
        /// <param name="magic">Ma lực hiện tại</param>
        public static async Task<Packet> DegradeEquipmentAsync(this IPacketWriter writer, int equipmentId, int magic) {
            return await writer.SendCommandAsync(39103, equipmentId.ToString(), "0", magic.ToString());
        }

        /// <summary>
        /// Hạ cấp trang bị (ma lực không ảnh hưởng).
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="equipmentId">ID của trang bị.</param>
        public static async Task<Packet> DegradeEquipmentAsync(this IPacketWriter writer, int equipmentId) {
            return await writer.DegradeEquipmentAsync(equipmentId, 0);
        }

        /// <summary>
        /// Giao diện nâng.
        /// </summary>
        /// <param name="type">Loại trang: 0 = Tất cả, 1 = Vũ khí, etc...</param>
        /// <param name="index">Thứ tự trang.</param>
        /// <param name="size">Kích thước trang.</param>
        /// <returns></returns>
        public static async Task<UpgradeInfo> RefreshUpgradeAsync(this IPacketWriter writer, int type, int index, int size) {
            var packet = await writer.SendCommandAsync(39301, type.ToString(), index.ToString(), size.ToString());
            if (packet == null) {
                return null;
            }
            return UpgradeInfo.Parse(JToken.Parse(packet.Message));
        }

        /// <summary>
        /// Nâng cấp trang bị.
        /// </summary>
        /// <param name="equipmentId">ID của trang bị.</param>
        /// <param name="magic">Ma lực hiện tại.</param>
        public static async Task<UpgradeResult> UpgradeEquipmentAsync(this IPacketWriter writer, int equipmentId, int magic) {
            var packet = await writer.SendCommandAsync(39302, equipmentId.ToString(), "0", magic.ToString());
            if (packet == null) {
                return null;
            }
            return UpgradeResult.Parse(packet);
        }

        /// <summary>
        /// Bấm vào nút hạ cấp hàng loạt.
        /// </summary>
        /// <param name="equipmentId">ID của trang bị.</param>
        public static async Task<Packet> AskDegradeEquipmentAllAsync(this IPacketWriter writer, int equipmentId) {
            return await writer.SendCommandAsync(39401, equipmentId.ToString());
        }

        /// <summary>
        /// Hạ cấp hàng loạt.
        /// </summary>
        /// <param name="equipmentId">ID của trang bị.</param>
        public static async Task<Packet> DegradeEquipmentAllAsync(this IPacketWriter writer, int equipmentId) {
            return await writer.SendCommandAsync(39402, equipmentId.ToString());
        }
    }
}
