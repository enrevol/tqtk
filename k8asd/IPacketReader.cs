using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    interface IPacketReader {
        void OnPacketReceived(Packet packet);
    }
}
