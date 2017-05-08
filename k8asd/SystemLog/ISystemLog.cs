using System;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Represents the message log model.
    /// </summary>
    public interface ISystemLog : IClientComponent {
        /// <summary>
        /// Occurs when the message log has changed.
        /// </summary>
        event EventHandler MessagesChanged;

        /// <summary>
        /// Gets all system messages.
        /// </summary>
        List<SystemMessage> Messages { get; }

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="message">The content of the message.</param>
        void Log(string message);

        /// <summary>
        /// Logs a message.
        /// </summary>
        /// <param name="tag">The tag of the message.</param>
        /// <param name="content">The content of the message.</param>
        void Log(string tag, string content);
    }
}
