using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
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

        public void Add(IClient client) {
            clients.Add(client);
        }

        public void Remove(IClient client) {
            clients.Remove(client);
        }

        public List<IClient> Clients {
            get { return clients; }
        }       
    }
}