using System.Threading.Tasks;

namespace k8asd {
    public static class StoreCommand {
        /// <summary>
        /// Giao diện túi đồ.
        /// </summary>
        /// <param name="index">Thứ tự của trang.</param>
        /// <param name="size">Kích thước của mỗi trang.</param>
        public static async Task<Packet> RefreshStoreAsync(this IPacketWriter writer, int index, int size) {
            return await writer.SendCommandAsync(39100, index.ToString(), size.ToString());
        }

        /// <summary>
        /// Giao diện nâng.
        /// </summary>
        /// <param name="type">Loại trang: 0 = Tất cả, 1 = Vũ khí, etc...</param>
        /// <param name="index">Thứ tự trang.</param>
        /// <param name="size">Kích thước trang.</param>
        /// <returns></returns>
        public static async Task<Packet> RefreshUpgradeAsync(this IPacketWriter writer, int type, int index, int size) {
            return await writer.SendCommandAsync(39301, type.ToString(), index.ToString(), size.ToString());
        }

        /// <summary>
        /// Hạ cấp trang bị.
        /// </summary>
        /// <param name="equipmentId">ID của trang bị.</param>
        public static async Task<Packet> DegradeEquipmentAsync(this IPacketWriter writer, string equipmentId) {
            return await writer.SendCommandAsync(39402, equipmentId);
        }

        /// <summary>
        /// Nâng cấp vũ khí.
        /// </summary>
        /// <param name="equipmentId">ID của trang bị.</param>
        /// <param name="magic">Ma lực hiện tại.</param>
        public static async Task<Packet> UpgradeEquipmentAsync(this IPacketWriter writer, string equipmentId, string magic) {
            return await writer.SendCommandAsync(39302, equipmentId, "0", magic);
        }
    }
}
