using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class AccountInfo {
        private int serverId;
        private string username;
        private string password;

        public int ServerId { get { return serverId; } }
        public string Username { get { return username; } }
        public string Password { get { return password; } }

        public AccountInfo(int serverId, string username, string password) {
            this.serverId = serverId;
            this.username = username;
            this.password = password;
        }

        public override string ToString() {
            return String.Format("{0}_{1}", serverId, username);
        }

        public override bool Equals(object obj) {
            var other = obj as AccountInfo;
            if (other == null) {
                return false;
            }
            return serverId == other.serverId && username == other.username;
        }
    }
}
