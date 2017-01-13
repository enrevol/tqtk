using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public interface IMessageLogModel {
        void LogInfo(string message);

        string Message { get; }

        /// <summary>
        /// Occurs when the message log has changed.
        /// </summary>
        event EventHandler<string> MessageChanged;
    }
}
