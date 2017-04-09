using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Quản lý tất cả người chơi.
    /// </summary>
    class ClientManager {
        private static ClientManager sharedInstance;

        private List<IClient> clients;

        public static ClientManager Instance {
            get {
                if (sharedInstance == null) {
                    sharedInstance = new ClientManager();
                }
                return sharedInstance;
            }
        }

        private ClientManager() {
            clients = new List<IClient>();
        }

        /// <summary>
        /// Thêm người chơi vào danh sách.
        /// </summary>
        /// <param name="client">Người chơi được thêm.</param>
        public void AddClient(IClient client) {
            clients.Add(client);
        }

        /// <summary>
        /// Xoá người chơi khỏi danh sách.
        /// </summary>
        /// <param name="client">Người chơi bị xoá.</param>
        public void RemoveClient(IClient client) {
            clients.Remove(client);
        }

        /// <summary>
        /// Danh sách người chơi.
        /// </summary>
        public List<IClient> Clients {
            get { return clients; }
        }
    }
}