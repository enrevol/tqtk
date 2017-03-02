using System;
using System.Threading.Tasks;

namespace k8asd {
    public class ChatChannel {
        public int Id { get; }
        public string Name { get; }

        public ChatChannel(int id, string name) {
            Id = id;
            Name = name;
        }

        public override string ToString() {
            return Name;
        }

        public static readonly ChatChannel Private = new ChatChannel(1, "Mật");

        /// <summary>
        /// Kênh thế giới.
        /// </summary>
        public static readonly ChatChannel World = new ChatChannel(2, "Thế giới");

        /// <summary>
        /// Kênh quốc gia.
        /// </summary>
        public static readonly ChatChannel Nation = new ChatChannel(3, "Quốc gia");

        /// <summary>
        /// Kênh khu vực.
        /// </summary>
        public static readonly ChatChannel Local = new ChatChannel(4, "Khu vực");

        /// <summary>
        /// Kênh bang hội.
        /// </summary>
        public static readonly ChatChannel Legion = new ChatChannel(5, "Bang");

        /// <summary>
        /// Kênh chiến dịch.
        /// </summary>
        public static readonly ChatChannel Campaign = new ChatChannel(6, "Chiến");
    }

    public class ChatMessage {
        public DateTime TimeStamp { get; }
        public ChatChannel Channel { get; }
        public string Sender { get; }
        public string Content { get; }

        public ChatMessage(ChatChannel channel, string sender, string content) {
            TimeStamp = DateTime.Now;
            Channel = channel;
            Sender = sender;
            Content = content;
        }
    }

    public interface IChatLogModel {
        Task SendMessage(ChatChannel channel, string content);

        event EventHandler<ChatMessage> OnChatMessageAdded;
    }
}