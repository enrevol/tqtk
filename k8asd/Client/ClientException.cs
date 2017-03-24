using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class ClientException : InvalidOperationException {
        public IClient Client { get; set; }
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public ClientException(string message) : base(message) { }
    }
}
