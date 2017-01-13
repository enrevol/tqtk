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
    public partial class ChatLogView : UserControl, IPacketReader {
        private class Channel {
            private int id;
            private string name;

            public int Id { get { return id; } }
            public string Name { get { return name; } }

            public Channel(int id, string name) {
                this.id = id;
                this.name = name;
            }

            public override string ToString() {
                return Name;
            }
        }

        private IPacketWriter packetWriter;
        private IInfoModel infoModel;

        public ChatLogView() {
            InitializeComponent();

            channelList.Items.Clear();
            channelList.Items.Add(new Channel(2, "Thế giới"));
            channelList.Items.Add(new Channel(3, "Quốc gia"));
            channelList.Items.Add(new Channel(4, "Khu vực"));
            channelList.Items.Add(new Channel(5, "Bang"));
            channelList.Items.Add(new Channel(6, "Chiến"));
            channelList.SelectedIndex = 2;
        }

        public void SetPacketWriter(IPacketWriter writer) {
            packetWriter = writer;
        }

        public void SetInfoModel(IInfoModel model) {
            infoModel = model;
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "10103") {
                if (packet.Message.Length > 0) {
                    var token = JToken.Parse(packet.Message);
                    var message = (string) token["message"];
                    var sender = (string) token["sender"];
                    var category = (int) token["category"];
                    var messageType = (int) token["messageType"];
                    AddMessage(category, sender, message);
                }
            }
        }

        private void AddMessage(int category, string sender, string message) {
            if (logBox.Text.Length > 0) {
                logBox.Text += Environment.NewLine;
            }
            logBox.Text += String.Format("[{0}] {1}: {2}", Utils.FormatDuration(DateTime.Now), sender, message);
            logBox.SelectionStart = logBox.TextLength;
            logBox.ScrollToCaret();
        }

        private void chatInput_KeyPress(object sender, KeyPressEventArgs e) {
            //
        }

        private void chatInput_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && chatInput.Text.Trim().Length > 0) {
                var item = channelList.SelectedItem;
                var channel = (Channel) item;
                packetWriter.SendCommand("10103", infoModel.PlayerName, chatInput.Text, channel.Id.ToString(), " ");
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
    }
}

/*
 * 
 * case "10103": {
                    /*
                    if (packet.Message.Length > 0) {
                        R10103 r10103 = new R10103(cdata);
                        int cat = Convert.ToInt32(r10103.category);
                        string msg = r10103.text;
                        int start = txtChatBox[6].TextLength;

                        txtChatBox[6].AppendText("\n" + msg);
                        if (cat != 8)
                            txtChatBox[cat - 1].AppendText("\n" + msg);

                        if (r10103.href != "") {
                            txtChatBox[6].InsertLink(r10103.disp, r10103.href);
                            if (cat != 8)
                                txtChatBox[cat - 1].InsertLink(r10103.disp, r10103.href);
                        }

                        txtChatBox[6].ScrollToCaret();
                        if (cat != 8)
                            txtChatBox[cat - 1].ScrollToCaret();

                        txtChatBox[6].Select(start, txtChatBox[6].TextLength - start);
                        txtChatBox[6].SelectionColor = r10103.color;
                        txtChatBox[6].SelectionLength = 0;
                }
                break;
*/

/*
private void btnChatExpand_Click(object sender, EventArgs e) {
    if (btnChatExpand.Text == "+")
        btnChatExpand.Text = "1";
    navChat.BringToFront();
    if (btnChatExpand.Text == "1") {
        btnChatExpand.Text = "2";
        navChat.Top -= 200;
        navChat.Height += 200;
    } else if (btnChatExpand.Text == "2") {
        btnChatExpand.Text = "3";
        navChat.Width += 500;
    } else if (btnChatExpand.Text == "3") {
        btnChatExpand.Text = "1";
        navChat.Width -= 500;
        navChat.Height -= 200;
        navChat.Top += 200;
    }
}

     public class R10103 {
        public Color color;
        public string category;
        public string message;
        public string messageType;
        public string sender;
        public string text;
        public string disp;
        public string href;

        public R10103(string json) {
            string str;
            JToken token = JObject.Parse(json)["m"];
            messageType = token["messageType"].ToString();
            str = token["message"].ToString();
            int start = str.IndexOf("<a href");
            if (start > 0) {
                int start2 = str.IndexOf("<font color");
                if (start2 > 0) {
                    int end = str.IndexOf("<", start2 + 1);
                    int end2 = str.IndexOf(">", end + 1);
                    str = str.Remove(end, end2 - end + 1).Remove(start2, 22);
                }
                int end3 = str.IndexOf("<", start + 1);
                int end4 = str.IndexOf(">", end3 + 1);
                string str2 = str.Substring(start, end3 - start);
                disp = str2.Substring(str2.IndexOf("\'>") + 2);
                href = str2.Substring(9, str2.IndexOf("\'", 10) - 9);
                str = str.Remove(start, end4 - start + 1);
            } else
                href = "";
            message = str.Replace("\"", "");
            sender = token["sender"].ToString().Replace("\"", "");
            category = token["category"].ToString();
            switch (category) {
            case "1":
                text = "[Mật]";
                color = Color.OrangeRed;
                break;
            case "2":
                text = "[Thế giới]";
                color = Color.Gold;
                break;
            case "3":
                text = "[Quốc gia]";
                color = Color.FromArgb(90, 200, 90);
                break;
            case "4":
                text = "[Khu vực]";
                color = Color.FromArgb(113, 222, 227);
                break;
            case "5":
                text = "[Bang]";
                color = Color.FromArgb(90, 90, 200);
                break;
            case "6":
                category = "4";
                text = "[Hệ thống]";
                color = Color.FromArgb(113, 222, 227);
                break;
            case "7":
                break;
            case "8":
                sender = "[Công cáo]";
                color = Color.OrangeRed;
                break;
            case "9":
                break;
            case "10":
                break;
            case "11":
                break;
            case "12":
                category = "2";
                goto case "2";
            case "13":
                category = "3";
                goto case "3";
            case "14":
                category = "4";
                goto case "4";
            case "15":
                category = "4";
                sender = "";
                goto case "6";
            case "16":
                category = "5";
                text = "";
                color = Color.FromArgb(90, 90, 200);
                break;
            case "19":
                category = "6";
                color = Color.YellowGreen;
                break;
            }
            text += sender + ": " + message;
        }
    }
*/
