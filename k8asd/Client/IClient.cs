using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Trạng thái của người chơi.
    /// </summary>
    public enum ConnectionStatus {
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

    interface IClient : IPacketWriter {
        event EventHandler<ConnectionStatus> ConnectionStatusChanged;

        /// <summary>
        /// Trạng thái kết nối hiện tại.
        /// </summary>
        ConnectionStatus ConnectionStatus { get; }

        /// <summary>
        /// ID của người chơi.
        /// </summary>
        int PlayerId { get; }

        /// <summary>
        /// Tên của người chơi.
        /// </summary>
        string PlayerName { get; }
    }
}
