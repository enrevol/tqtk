using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace k8asd {
    public interface IChatLog : IClientComponent {
        /// <summary>
        /// Occurs when the chat log has changed.
        /// </summary>
        event EventHandler MessagesChanged;

        /// <summary>
        /// Gets chat messages for the specified channel.
        /// </summary>
        /// <param name="channel">The chat channel.</param>
        List<ChatMessage> GetChannelMessages(ChatChannel channel);

        /// <summary>
        /// Gets all chat messages.
        /// </summary>
        List<ChatMessage> GetAllChannelMessages();

        /// <summary>
        /// Attempts to send a chat message.
        /// </summary>
        /// <param name="channel">The channel of the message.</param>
        /// <param name="content">The content of the message.</param>
        /// <returns>Whether the message was sent succesfully.</returns>
        Task<bool> SendMessage(ChatChannel channel, string content);
    }
}