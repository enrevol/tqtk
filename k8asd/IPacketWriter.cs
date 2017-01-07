using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface IPacketWriter {
        bool SendCommand(string command, params string[] parameters);
    }
}
