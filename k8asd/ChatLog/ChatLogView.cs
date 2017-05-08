using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace k8asd {
    public partial class ChatLogView : UserControl, IChatLogView {
        private IChatLog chatLog;
        private List<RichTextBox> logBoxes;

        public ChatLogView() {
            InitializeComponent();

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

        public IChatLog ChatLog {
            get { return chatLog; }
            set {
                if (chatLog != null) {
                    chatLog.OnMessageAdded -= OnChatMessageAdded;
                }
                chatLog = value;
                if (chatLog != null) {
                    chatLog.OnMessageAdded += OnChatMessageAdded;
                }
            }
        }

        private void OnChatMessageAdded(object sender, ChatMessage message) {
            var line = String.Format("[{0}] [{1}] {2}: {3}",
                Utils.FormatDuration(message.TimeStamp), message.Channel.Name, message.Sender, message.Content);

            var logChannelBox = GetLogChannelBox(message.Channel);
            if (logChannelBox.Lines.Length > 0) {
                logChannelBox.AppendText(Environment.NewLine);
            }
            logChannelBox.AppendText(line);
            if (logChannelBox.Lines.Length > ChatLog.ChannelLimit) {
                RemoveFirstLine(logChannelBox);
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
            if (box.Lines.Length > ChatLog.AllChannelLimit) {
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
                chatLog.SendMessage(channel, chatInput.Text);
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
    }
}