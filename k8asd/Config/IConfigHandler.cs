namespace k8asd {
    interface IConfigHandler {
        /// <summary>
        /// Tải cấu hình.
        /// </summary>
        /// <param name="config">Cấu hình để tải.</param>
        /// <returns>Có thành công hay không?</returns>
        bool LoadConfig(IConfig config);

        /// <summary>
        /// Lưu cấu hình hiện tại.
        /// </summary>
        /// <param name="config">Cấu hình để lưu vào.</param>
        void SaveConfig(IConfig config);
    }
}
