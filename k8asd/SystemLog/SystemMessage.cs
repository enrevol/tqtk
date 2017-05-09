using System;

namespace k8asd {
    public class SystemMessage {
        /// <summary>
        /// Thời gian của tin chát (giờ máy tính).
        /// </summary>
        public DateTime TimeStamp { get; }

        /// <summary>
        /// Người gửi.
        /// </summary>
        public string Sender { get; }

        public string Tag { get; }

        /// <summary>
        /// Nội dung.
        /// </summary>
        public string Content { get; }

        public SystemMessage(DateTime timeStamp, string sender, string tag, string content) {
            TimeStamp = timeStamp;
            Sender = sender;
            Tag = tag;
            Content = content;
        }

        public SystemMessage(string sender, string tag, string content) {
            TimeStamp = DateTime.Now;
            Sender = sender;
            Tag = tag;
            Content = content;
        }

        public string Format() {
            return String.Format("[{0}] [{1}] {2}: {3}", TimeStamp, Tag, Sender, Content);
        }

        public override string ToString() {
            return Format();
        }
    }
}
