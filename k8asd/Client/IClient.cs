using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface IClient : IPacketWriter {
        /// <summary>
        /// Xảy ra khi trạng thái kết nối bị thay đổi.
        /// </summary>
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

        /// <summary>
        /// Đăng nhập.
        /// </summary>
        /// <param name="parallel">Kết nối song song không?</param>
        /// <returns>Thành công hay không?</returns>
        Task<bool> LogIn(bool parallel);

        /// <summary>
        /// Đăng xuất.
        /// </summary>
        /// <returns>Thành công hay không?</returns>
        Task<bool> LogOut();

        T GetComponent<T>();
    }
}
