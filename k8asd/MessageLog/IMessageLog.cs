using System;

namespace k8asd {
    /// <summary>
    /// Represents the message log model.
    /// </summary>
    public interface IMessageLog : IClientComponent {
        void LogInfo(string message);

        string Message { get; }

        /// <summary>
        /// Occurs when the message log has changed.
        /// </summary>
        event EventHandler<string> MessageChanged;
    }
}
