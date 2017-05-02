namespace k8asd {
    /// <summary>
    /// Trạng thái của người chơi.
    /// </summary>
    public enum ClientState {
        /// <summary>
        /// Đang kết nối.
        /// </summary>
        Connecting,

        /// <summary>
        /// Đã kết nối.
        /// </summary>
        Connected,

        /// <summary>
        /// Đang ngắt kết nối.
        /// </summary>
        Disconnecting,

        /// <summary>
        /// Đã ngắt kết nối.
        /// </summary>
        Disconnected
    };
}
