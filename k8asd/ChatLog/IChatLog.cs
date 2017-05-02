using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace k8asd {
    public interface IChatLog : IModule {
        /// <summary>
        /// Occurs when there is a new message added.
        /// </summary>
        event EventHandler<ChatMessage> OnChatMessageAdded;

        /// <summary>
        /// The number of limited chat messages.
        /// </summary>
        int Limit { get; set; }

        /// <summary>
        /// Gets all chat messages.
        /// </summary>
        List<ChatMessage> Messages { get; }

        /// <summary>
        /// Attempts to send a chat message.
        /// </summary>
        /// <param name="channel">The channel of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <returns>Whether the message was sent succesfully.</returns>
        Task<bool> SendMessage(ChatChannel channel, string content);
    }
}