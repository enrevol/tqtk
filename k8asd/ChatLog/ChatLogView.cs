using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace k8asd {
    public partial class ChatLogView : UserControl {
        /// <summary>
        /// Text color for messages in private channel.
        /// </summary>
        private static readonly Color PrivateChannelColor = Color.FromArgb(230, 130, 50);

        /// <summary>
        /// Text color for messages in world channel.
        /// </summary>
        private static readonly Color WorldChannelColor = Color.FromArgb(250, 240, 140);

        /// <summary>
        /// Text color for messages in nation channel.
        /// </summary>
        private static readonly Color NationChannelColor = Color.FromArgb(100, 230, 140);

        /// <summary>
        /// Text color for messages in local channel.
        /// </summary>
        private static readonly Color LocalChannelColor = Color.FromArgb(100, 220, 220);

        /// <summary>
        /// Text color for messages in legion channel.
        /// </summary>
        private static readonly Color LegionChannelColor = Color.FromArgb(80, 140, 230);

        private IChatLogModel model;
        private Dictionary<ChatChannel, string> channelMessages;
        private string allMessages;

        private RichTextBox formatter;

        private enum ChatBoxMode {
            Small,
            Medium,
            Large,
        }

        private ChatBoxMode chatBoxMode;

        public ChatLogView() {
            InitializeComponent();

            channelList.Items.Clear();
            channelList.Items.Add(ChatChannel.World);
            channelList.Items.Add(ChatChannel.Nation);
            channelList.Items.Add(ChatChannel.Local);
            channelList.Items.Add(ChatChannel.Legion);
            channelList.Items.Add(ChatChannel.Campaign);
            channelList.SelectedIndex = 2;

            channelMessages = new Dictionary<ChatChannel, string>();
            channelMessages.Add(ChatChannel.World, String.Empty);
            channelMessages.Add(ChatChannel.Nation, String.Empty);
            channelMessages.Add(ChatChannel.Local, String.Empty);
            channelMessages.Add(ChatChannel.Legion, String.Empty);
            channelMessages.Add(ChatChannel.Campaign, String.Empty);

            allMessages = String.Empty;
            chatBoxMode = ChatBoxMode.Small;
            logTabList.SelectedIndex = 5;

            formatter = new RichTextBox();
        }

        public void SetModel(IChatLogModel model) {
            this.model = model;
            model.OnChatMessageAdded += OnChatMessageAdded;
        }

        private void OnChatMessageAdded(object sender, ChatMessage message) {
            var line = String.Format("[{0}] [{1}] {2}: {3}",
                Utils.FormatDuration(message.TimeStamp), message.Channel.Name, message.Sender, message.Content);

            var channelMessage = channelMessages[message.Channel];
            AddMessage(ref channelMessage, line, GetChannelColor(message.Channel));
            channelMessages[message.Channel] = channelMessage;
            AddMessage(ref allMessages, line, GetChannelColor(message.Channel));
            UpdateLogBox();
        }

        private void AddMessage(ref string lines, string line, Color color) {
            formatter.Rtf = lines;
            if (lines.Length > 0) {
                formatter.Text += Environment.NewLine;
            }
            var startIndex = formatter.Text.Length;
            formatter.Text += line;
            formatter.Select(startIndex, formatter.Text.Length - startIndex);
            formatter.SelectionColor = color;
            lines = formatter.Rtf;
        }

        private Color GetChannelColor(ChatChannel channel) {
            if (channel.Id == ChatChannel.Private.Id) {
                return PrivateChannelColor;
            }
            if (channel.Id == ChatChannel.World.Id) {
                return WorldChannelColor;
            }
            if (channel.Id == ChatChannel.Nation.Id) {
                return NationChannelColor;
            }
            if (channel.Id == ChatChannel.Local.Id) {
                return LocalChannelColor;
            }
            if (channel.Id == ChatChannel.Legion.Id) {
                return LegionChannelColor;
            }
            if (channel.Id == ChatChannel.Campaign.Id) {
                return Color.Yellow;
            }
            return Color.White;
        }

        private string GetChannelMessage(int tabIndex) {
            switch (tabIndex) {
            case 0: return channelMessages[ChatChannel.World];
            case 1: return channelMessages[ChatChannel.Nation];
            case 2: return channelMessages[ChatChannel.Local];
            case 3: return channelMessages[ChatChannel.Legion];
            case 4: return channelMessages[ChatChannel.Campaign];
            case 5: return allMessages;
            }
            return String.Empty;
        }

        private void UpdateLogBox() {
            var selectedIndex = logTabList.SelectedIndex;
            logBox.Rtf = GetChannelMessage(selectedIndex);
            Utils.ScrollToBottom(logBox);
        }

        private void chatInput_KeyPress(object sender, KeyPressEventArgs e) {
            //
        }

        private void chatInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && chatInput.Text.Trim().Length > 0) {
                var item = channelList.SelectedItem;
                var channel = (ChatChannel) item;
                model.SendMessage(channel, chatInput.Text);
                chatInput.Text = String.Empty;
                /*
                int n = cbbChat.SelectedIndex - 1;
                if (chatcd[n] == 0) {
                    switch (n) {
                    case 0:
                    case 1:
                    case 3:
                        chatcd[n] = 3500;
                        break;
                    case 2:
                        chatcd[n] = 10000;
                        break;
                    }
                }
                */
            }
        }

        private void logTabList_SelectedIndexChanged(object sender, EventArgs e) {
            UpdateLogBox();
        }

        private void modeButton_Click(object sender, EventArgs e) {
            const int AdditionalHeight = 200;
            const int AdditionalWidth = 800;

            int deltaWidth = 0;
            int deltaHeight = 0;
            if (chatBoxMode == ChatBoxMode.Small) {
                chatBoxMode = ChatBoxMode.Medium;
                deltaHeight = AdditionalHeight;
                modeButton.Text = "Vừa";
            } else if (chatBoxMode == ChatBoxMode.Medium) {
                chatBoxMode = ChatBoxMode.Large;
                deltaWidth = AdditionalWidth;
                modeButton.Text = "Lớn";
            } else {
                chatBoxMode = ChatBoxMode.Small;
                deltaHeight = -AdditionalHeight;
                deltaWidth = -AdditionalWidth;
                modeButton.Text = "Nhỏ";
            }

            Width += deltaWidth;
            Height += deltaHeight;
            Location = new Point(Location.X, Location.Y - deltaHeight);

            Utils.ScrollToBottom(logBox);
        }
    }
}