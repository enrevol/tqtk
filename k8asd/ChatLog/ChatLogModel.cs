using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class ChatLogModel : IChatLogModel, IPacketReader {
        public event EventHandler<ChatMessage> OnChatMessageAdded;

        private IInfoModel infoModel;
        private IPacketWriter packetWriter;

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
            if (category == 1) {
                // Mật.
                return;
            }
            if (category == 2) {
                AddMessage(ChatChannel.World, sender, message);
                return;
            }
            if (category == 3) {
                AddMessage(ChatChannel.Nation, sender, message);
                return;
            }
            if (category == 4) {
                AddMessage(ChatChannel.Local, sender, message);
                return;
            }
            if (category == 5) {
                AddMessage(ChatChannel.Legion, sender, message);
                return;
            }
            if (category == 6) {
                AddMessage(ChatChannel.Local, "Hệ thống", message);
                return;
            }
            if (category == 8) {
                /*
                sender = "[Công cáo]";
                color = Color.OrangeRed;
                */
                return;
            }
            if (category == 12) {
                // sender: Hệ thống
                // message: Thánh_Nữ Chinh chiến nhận được {Bá Đạo Kiếm(mảnh)|6|272780}(Mảnh vỡ 1/20)
                // message: Dân Chơi tại Võ Đài thắng liên tiếp 10 trận, đại sát đại nộ!
                AddMessage(ChatChannel.World, sender, message);
                return;
            }
            if (category == 13) {
                // sender: Hệ thống
                // message: Quân Sư Rồng Uy Danh tăng mạnh 530000 trở thành Đại Đô Đốc Tam Tinh, hiệu quả gia thành: Công Kích+10%, Phòng Thủ+5%! Chúc mừng mãnh tướng mới của Ngụy quốc!
                AddMessage(ChatChannel.World, sender, message);
                return;
            }
            return;
        }

        private void AddMessage(ChatChannel channel, string sender, string message) {
            OnChatMessageAdded(this, new ChatMessage(channel, sender, message));
        }

        public void SendMessage(ChatChannel channel, string content) {
            packetWriter.SendCommand("10103", infoModel.PlayerName, content, channel.Id.ToString(), " ");
        }
    }
}