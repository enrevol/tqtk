using System.Drawing;

namespace k8asd {
    static class ChatColor {
        public static readonly Color Background = Color.FromArgb(6, 40, 38);

        /// <summary>
        /// Text color for messages in private channel.
        /// </summary>
        public static readonly Color Private = Color.FromArgb(230, 130, 50);

        /// <summary>
        /// Text color for messages in world channel.
        /// </summary>
        public static readonly Color World = Color.FromArgb(250, 240, 140);

        /// <summary>
        /// Text color for messages in nation channel.
        /// </summary>
        public static readonly Color Nation = Color.FromArgb(100, 230, 140);

        /// <summary>
        /// Text color for messages in local channel.
        /// </summary>
        public static readonly Color Local = Color.FromArgb(100, 220, 220);

        /// <summary>
        /// Text color for messages in legion channel.
        /// </summary>
        public static readonly Color Legion = Color.FromArgb(80, 140, 230);

        public static readonly Color Campaign = Color.Yellow;
    }
}
