using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public interface IClient : IPacketWriter {
        event EventHandler<ClientState> StateChanged;

        /// <summary>
        /// Trạng thái kết nối hiện tại.
        /// </summary>
        ClientState State { get; }

        /// <summary>
        /// Cấu hình của người chơi.
        /// </summary>
        ClientConfig Config { get; }

        /// <summary>
        /// ID của người chơi.
        /// </summary>
        int PlayerId { get; }

        /// <summary>
        /// Tên của người chơi.
        /// </summary>
        string PlayerName { get; }

        Task LogIn(bool blocking);

        Task LogOut();

        void EnableAutoQuest();
        void ReportAutoQuest();
        void UseGoldDaily();
    }
}
