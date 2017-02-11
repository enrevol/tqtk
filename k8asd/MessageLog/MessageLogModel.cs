using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class MessageLogModel : IMessageLogModel, IPacketReader {
        private string message;

        public event EventHandler<string> MessageChanged;

        public string Message {
            get { return message; }
        }

        public MessageLogModel() {
            message = String.Empty;
        }

        public void OnPacketReceived(Packet packet) {
            if (packet.CommandId == "10103") {
                // Ignore chat messages.
                return;
            }
            if (packet.Message.Length > 0) {
                var token = JToken.Parse(packet.Message);
                if (token.HasValues) {
                    // Packet 10100 won't have any values.
                    var message = token["message"];
                    if (message != null) {
                        LogInfo((string) message);
                    }
                    var errmessage = token["errmessage"];
                    if (errmessage != null) {
                        LogInfo((string) errmessage);
                    }
                    var msg = token["msg"];
                    if (msg != null) {
                        LogInfo((string) msg);
                    }
                }
            }
        }

        public void LogInfo(string newMessage) {
            if (message.Length > 0) {
                message += Environment.NewLine;
            }
            message += String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            MessageChanged.Raise(this, message);
        }
    }
}

/*
 * 
 * public class R10103 {
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
