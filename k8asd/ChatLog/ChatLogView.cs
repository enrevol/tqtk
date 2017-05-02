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

        private const int ChannelLineLimit = 100;
        private const int AllChannelLineLimit = 50;

        private IChatLog chatModel;

        private enum ChatBoxSize {
            Small,
            Medium,
            Large,
        }

        private List<RichTextBox> logBoxes;

        private ChatBoxSize chatBoxSize;

        public ChatLogView() {
            InitializeComponent();

            channelList.Items.Clear();
            channelList.Items.Add(ChatChannel.World);
            channelList.Items.Add(ChatChannel.Nation);
            channelList.Items.Add(ChatChannel.Local);
            channelList.Items.Add(ChatChannel.Legion);
            channelList.Items.Add(ChatChannel.Campaign);
            channelList.SelectedIndex = 2;

            logBoxes = new List<RichTextBox>();
            logBoxes.Add(logBox0);
            logBoxes.Add(logBox1);
            logBoxes.Add(logBox2);
            logBoxes.Add(logBox3);
            logBoxes.Add(logBox4);
            logBoxes.Add(logAllBox);

            foreach (var box in logBoxes) {
                box.BackColor = Color.FromArgb(6, 40, 38);
            }

            logBox0.ForeColor = GetChannelColor(ChatChannel.World);
            logBox1.ForeColor = GetChannelColor(ChatChannel.Nation);
            logBox2.ForeColor = GetChannelColor(ChatChannel.Local);
            logBox3.ForeColor = GetChannelColor(ChatChannel.Legion);
            logBox4.ForeColor = GetChannelColor(ChatChannel.Campaign);

            chatBoxSize = ChatBoxSize.Small;
            logTabList.SelectedIndex = 5;
        }

        public void SetModel(IChatLog model) {
            if (chatModel != null) {
                chatModel.OnChatMessageAdded -= OnChatMessageAdded;
            }
            chatModel = model;
            chatModel.OnChatMessageAdded += OnChatMessageAdded;
        }

        private void OnChatMessageAdded(object sender, ChatMessage message) {
            var line = String.Format("[{0}] [{1}] {2}: {3}",
                Utils.FormatDuration(message.TimeStamp), message.Channel.Name, message.Sender, message.Content);

            var logBox = GetLogBox(message.Channel);
            if (logBox != null) {
                if (logBox.Lines.Length > 0) {
                    logBox.AppendText(Environment.NewLine);
                }
                logBox.AppendText(line);
                if (logBox.Lines.Length > ChannelLineLimit) {
                    RemoveFirstLine(logBox);
                }
            }

            AddMessage(logAllBox, line, GetChannelColor(message.Channel));
            TryScrollBoxes();
        }

        private void AddMessage(RichTextBox box, string line, Color color) {
            if (box.Text.Length > 0) {
                box.AppendText(Environment.NewLine);
            }
            var startIndex = box.Text.Length;
            box.AppendText(line);
            box.Select(startIndex, box.Text.Length - startIndex);
            box.SelectionColor = color;
            if (box.Lines.Length > AllChannelLineLimit) {
                RemoveFirstLine(box);
            }
        }

        private void RemoveFirstLine(RichTextBox box) {
            var isReadOnly = box.ReadOnly;
            if (isReadOnly) {
                box.ReadOnly = false;
            }
            var startIndex = box.GetFirstCharIndexFromLine(0);
            var endIndex = box.GetFirstCharIndexFromLine(1);
            box.Select(startIndex, endIndex - startIndex);
            box.SelectedText = String.Empty;
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

        private RichTextBox GetLogBox(ChatChannel channel) {
            if (channel.Id == ChatChannel.Private.Id) {
                return null;
            }
            if (channel.Id == ChatChannel.World.Id) {
                return logBox0;
            }
            if (channel.Id == ChatChannel.Nation.Id) {
                return logBox1;
            }
            if (channel.Id == ChatChannel.Local.Id) {
                return logBox2;
            }
            if (channel.Id == ChatChannel.Legion.Id) {
                return logBox3;
            }
            if (channel.Id == ChatChannel.Campaign.Id) {
                return logBox4;
            }
            return null;
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
            //
        }

        private void TryScrollBoxes() {
            if (autoScrollBox.Checked) {
                foreach (var box in logBoxes) {
                    Utils.ScrollToBottom(box);
                }
            }
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

            TryScrollBoxes();
        }
    }
}