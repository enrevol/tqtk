using System;

namespace k8asd {
    public class ChatMessage {
        /// <summary>
        /// Thời gian của tin chát (giờ máy tính).
        /// </summary>
        public DateTime TimeStamp { get; }

        /// <summary>
        /// Kênh chát.
        /// </summary>
        public ChatChannel Channel { get; }

        /// <summary>
        /// Người gửi.
        /// </summary>
        public string Sender { get; }

        /// <summary>
        /// Nội dung.
        /// </summary>
        public string Content { get; }

        public ChatMessage(DateTime timeStamp, ChatChannel channel, string sender, string content) {
            TimeStamp = timeStamp;
            Channel = channel;
            Sender = sender;
            Content = content;
        }

        public ChatMessage(ChatChannel channel, string sender, string content) {
            TimeStamp = DateTime.Now;
            Channel = channel;
            Sender = sender;
            Content = content;
        }

        public string Format() {
            return String.Format("[{0}] [{1}] {2}: {3}", TimeStamp, Channel.Name, Sender, Content);
        }

        public override string ToString() {
            return Format();
        }
    }
}
