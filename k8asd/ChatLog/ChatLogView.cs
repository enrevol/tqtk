using MoreLinq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace k8asd {
    public partial class ChatLogView : UserControl, IChatLogView {
        private List<IChatLog> models;
        private List<RichTextBox> logBoxes;
        private Dictionary<ChatChannel, bool> channelDirties;

        public ChatLogView() {
            InitializeComponent();

            channelDirties = new Dictionary<ChatChannel, bool>();
            channelDirties.Add(ChatChannel.Private, false);
            channelDirties.Add(ChatChannel.World, false);
            channelDirties.Add(ChatChannel.Nation, false);
            channelDirties.Add(ChatChannel.Local, false);
            channelDirties.Add(ChatChannel.Legion, false);
            channelDirties.Add(ChatChannel.Campaign, false);

            channelList.Items.Clear();
            channelList.Items.Add(ChatChannel.World);
            channelList.Items.Add(ChatChannel.Nation);
            channelList.Items.Add(ChatChannel.Local);
            channelList.Items.Add(ChatChannel.Legion);
            channelList.Items.Add(ChatChannel.Campaign);
            channelList.DisplayMember = "Name";
            channelList.SelectedIndex = 2;

            logBoxes = new List<RichTextBox>();
            logBoxes.Add(logBox0);
            logBoxes.Add(logBox1);
            logBoxes.Add(logBox2);
            logBoxes.Add(logBox3);
            logBoxes.Add(logBox4);
            logBoxes.Add(logBox5);
            logBoxes.Add(logAllBox);

            foreach (var box in logBoxes) {
                box.BackColor = ChatColor.Background;
            }

            logBox0.ForeColor = GetChannelColor(ChatChannel.Private);
            logBox1.ForeColor = GetChannelColor(ChatChannel.World);
            logBox2.ForeColor = GetChannelColor(ChatChannel.Nation);
            logBox3.ForeColor = GetChannelColor(ChatChannel.Local);
            logBox4.ForeColor = GetChannelColor(ChatChannel.Legion);
            logBox5.ForeColor = GetChannelColor(ChatChannel.Campaign);

            logTabList.SelectedIndex = 5;
        }

        public List<IChatLog> Models {
            get { return models; }
            set {
                if (models != null) {
                    foreach (var model in models) {
                        model.MessagesChanged -= OnMessagesChanged;
                    }
                }
                models = value;
                if (models != null) {
                    foreach (var model in models) {
                        model.MessagesChanged += OnMessagesChanged;
                    }
                    var channels = new List<ChatChannel>(channelDirties.Keys);
                    foreach (var channel in channels) {
                        channelDirties[channel] = true;
                    }
                }
            }
        }

        private void OnMessagesChanged(object sender, ChatChannel channel) {
            channelDirties[channel] = true;
        }

        private void UpdateChannelMessages(ChatChannel channel) {
            var messages = models
                .SelectMany(item => item.GetChannelMessages(channel))
                .OrderBy(item => item.TimeStamp)
                .DistinctBy(item => new { item.Channel, item.Sender, item.Content })
                .TakeLast(100)
                .ToList();

            if (messages.Count == 0) {
                return;
            }

            var builder = new StringBuilder();
            foreach (var message in messages) {
                if (builder.Length > 0) {
                    builder.Append(Environment.NewLine);
                }
                builder.Append(message.Format());
            }

            var box = GetLogChannelBox(channel);

            var text = builder.ToString();
            var hash = text.GetHashCode();
            var currentHash = box.Text.GetHashCode();
            if (currentHash == hash) {
                return;
            }

            box.Text = text;
        }

        private void UpdateAllChannelMessages() {
            var messages = models
                .SelectMany(item => item.GetAllChannelMessages())
                .OrderBy(item => item.TimeStamp)
                .DistinctBy(item => new { item.Channel, item.Sender, item.Content })
                .TakeLast(30)
                .ToList();

            if (messages.Count == 0) {
                return;
            }

            var builder = new StringBuilder();
            foreach (var message in messages) {
                if (builder.Length > 0) {
                    builder.Append(Environment.NewLine);
                }
                builder.Append(message.Format());
            }

            var text = builder.ToString();
            var hash = text.GetHashCode();
            var currentHash = logAllBox.Text.GetHashCode();
            if (currentHash == hash) {
                return;
            }

            logAllBox.SuspendLayout();
            logAllBox.BeginUpdate();
            logAllBox.Clear();
            foreach (var message in messages) {
                AddMessage(logAllBox, message.Format(), GetChannelColor(message.Channel));
            }
            logAllBox.EndUpdate();
            logAllBox.ResumeLayout();
        }

        private void AddMessage(RichTextBox box, string line, Color color) {
            if (box.Text.Length > 0) {
                box.AppendText(Environment.NewLine);
            }
            var currentSelectIndex = box.SelectionStart;
            var startIndex = box.Text.Length;
            box.AppendText(line);
            box.Select(startIndex, box.Text.Length - startIndex);
            box.SelectionColor = color;
            box.Select(currentSelectIndex, 0);
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
            var colors = new Dictionary<ChatChannel, Color>();
            colors[ChatChannel.Private] = ChatColor.Private;
            colors[ChatChannel.World] = ChatColor.World;
            colors[ChatChannel.Nation] = ChatColor.Nation;
            colors[ChatChannel.Local] = ChatColor.Local;
            colors[ChatChannel.Legion] = ChatColor.Legion;
            colors[ChatChannel.Campaign] = ChatColor.Campaign;
            return colors[channel];
        }

        private RichTextBox GetLogChannelBox(ChatChannel channel) {
            var boxes = new Dictionary<ChatChannel, RichTextBox>();
            boxes[ChatChannel.Private] = logBox0;
            boxes[ChatChannel.World] = logBox1;
            boxes[ChatChannel.Nation] = logBox2;
            boxes[ChatChannel.Local] = logBox3;
            boxes[ChatChannel.Legion] = logBox4;
            boxes[ChatChannel.Campaign] = logBox5;
            return boxes[channel];
        }

        private void chatInput_KeyPress(object sender, KeyPressEventArgs e) {
            //
        }

        private void chatInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && chatInput.Text.Trim().Length > 0) {
                var item = channelList.SelectedItem;
                var channel = (ChatChannel) item;
                foreach (var model in models) {
                    model.SendMessage(channel, chatInput.Text).Forget();
                }
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

        private void updateTimer_Tick(object sender, EventArgs e) {
            var channels = new List<ChatChannel>(channelDirties.Keys);
            bool allChannelDirty = false;
            foreach (var channel in channels) {
                if (channelDirties[channel]) {
                    channelDirties[channel] = false;
                    allChannelDirty = true;
                    UpdateChannelMessages(channel);
                }
            }

            if (allChannelDirty) {
                UpdateAllChannelMessages();
                TryScrollBoxes();
            }
        }
    }
}