using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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

        private IChatLogModel chatModel;
        private Dictionary<ChatChannel, string> channelMessages;
        private string allMessages;

        private FastRichTextBox formatter;
        private int lineLimit;

        private enum ChatBoxSize {
            Small,
            Medium,
            Large,
        }

        private ChatBoxSize chatBoxSize;

        public ChatLogView() {
            InitializeComponent();

            lineLimit = 200;

            channelList.Items.Clear();
            channelList.Items.Add(ChatChannel.World);
            channelList.Items.Add(ChatChannel.Nation);
            channelList.Items.Add(ChatChannel.Local);
            channelList.Items.Add(ChatChannel.Legion);
            channelList.Items.Add(ChatChannel.Campaign);
            channelList.SelectedIndex = 2;

            formatter = new FastRichTextBox();
            formatter.Text = String.Empty;
            formatter.WordWrap = false;
            var emptyRtf = formatter.Rtf;

            channelMessages = new Dictionary<ChatChannel, string>();
            channelMessages.Add(ChatChannel.World, emptyRtf);
            channelMessages.Add(ChatChannel.Nation, emptyRtf);
            channelMessages.Add(ChatChannel.Local, emptyRtf);
            channelMessages.Add(ChatChannel.Legion, emptyRtf);
            channelMessages.Add(ChatChannel.Campaign, emptyRtf);

            allMessages = emptyRtf;

            chatBoxSize = ChatBoxSize.Small;
            logBox.BackColor = Color.FromArgb(6, 40, 38);
            logTabList.SelectedIndex = 5;
        }

        public void SetModel(IChatLogModel model) {
            if (chatModel != null) {
                chatModel.OnChatMessageAdded -= OnChatMessageAdded;
            }
            chatModel = model;
            chatModel.OnChatMessageAdded += OnChatMessageAdded;
        }

        private void OnChatMessageAdded(object sender, ChatMessage message) {
            var line = String.Format("[{0}] [{1}] {2}: {3}",
                Utils.FormatDuration(message.TimeStamp), message.Channel.Name, message.Sender, message.Content);

            var channelMessage = channelMessages[message.Channel];
            AddMessage(ref channelMessage, line, GetChannelColor(message.Channel));
            channelMessages[message.Channel] = channelMessage;
            AddMessage(ref allMessages, line, GetChannelColor(message.Channel));
            if (autoScrollBox.Checked) {
                UpdateLogBox();
            }
        }

        private void AddMessage(ref string lines, string line, Color color) {
            formatter.Rtf = lines;
            if (formatter.Text.Length > 0) {
                formatter.AppendText(Environment.NewLine);
            }
            var startIndex = formatter.Text.Length;
            formatter.AppendText(line);
            formatter.Select(startIndex, formatter.Text.Length - startIndex);
            formatter.SelectionColor = color;
            if (formatter.Lines.Length > lineLimit) {
                RemoveFirstLine(formatter);
            }
            lines = formatter.Rtf;
        }

        private void RemoveFirstLine(RichTextBox box) {
            var isReadOnly = box.ReadOnly;
            if (isReadOnly) {
                box.ReadOnly = false;
            }
            var startIndex = box.GetFirstCharIndexFromLine(0);
            var endIndex = box.GetFirstCharIndexFromLine(1);
            formatter.Select(startIndex, endIndex - startIndex);
            formatter.SelectedText = String.Empty;
            if (isReadOnly) {
                box.ReadOnly = true;
            }
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
                chatModel.SendMessage(channel, chatInput.Text);
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

        private void changeSizeButton_Click(object sender, EventArgs e) {
            const int AdditionalHeight = 200;
            const int AdditionalWidth = 800;

            int deltaWidth = 0;
            int deltaHeight = 0;
            if (chatBoxSize == ChatBoxSize.Small) {
                chatBoxSize = ChatBoxSize.Medium;
                deltaHeight = AdditionalHeight;
                changeSizeButton.Text = "Vừa";
            } else if (chatBoxSize == ChatBoxSize.Medium) {
                chatBoxSize = ChatBoxSize.Large;
                deltaWidth = AdditionalWidth;
                changeSizeButton.Text = "Lớn";
            } else {
                chatBoxSize = ChatBoxSize.Small;
                deltaHeight = -AdditionalHeight;
                deltaWidth = -AdditionalWidth;
                changeSizeButton.Text = "Nhỏ";
            }

            Width += deltaWidth;
            Height += deltaHeight;
            Location = new Point(Location.X, Location.Y - deltaHeight);

            if (autoScrollBox.Checked) {
                Utils.ScrollToBottom(logBox);
            }
        }
    }
}