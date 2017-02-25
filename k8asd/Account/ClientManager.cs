using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class ClientManager {
        private static ClientManager sharedInstance;

        private List<ClientView> clients;

        public static ClientManager Instance {
            get {
                if (sharedInstance == null) {
                    sharedInstance = new ClientManager();
                }
                return sharedInstance;
            }
        }

        private ClientManager() {
            clients = new List<ClientView>();
        }

        public void Add(ClientView client) {
            clients.Add(client);
        }

        public void Remove(ClientView client) {
            clients.Remove(client);
        }

        public List<ClientView> Clients { get { return clients; } }
    }
}