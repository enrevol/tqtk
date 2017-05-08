using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Khung chát.
    /// </summary>
    public class ChatLog : IChatLog {
        private const int ChannelLimit = 100;
        private const int AllChannelLimit = 50;

        public event EventHandler MessagesChanged;

        private IClient client;
        private Dictionary<ChatChannel, List<ChatMessage>> channelMessages;
        private List<ChatMessage> allChannelMessages;

        public IClient Client {
            get { return client; }
            set {
                if (client != null) {
                    client.PacketReceived -= OnPacketReceived;
                }
                client = value;
                if (client != null) {
                    client.PacketReceived += OnPacketReceived;
                }
            }
        }

        public ChatLog() {
            client = null;

            channelMessages = new Dictionary<ChatChannel, List<ChatMessage>>();
            channelMessages[ChatChannel.Private] = new List<ChatMessage>();
            channelMessages[ChatChannel.World] = new List<ChatMessage>();
            channelMessages[ChatChannel.Nation] = new List<ChatMessage>();
            channelMessages[ChatChannel.Local] = new List<ChatMessage>();
            channelMessages[ChatChannel.Legion] = new List<ChatMessage>();
            channelMessages[ChatChannel.Campaign] = new List<ChatMessage>();

            allChannelMessages = new List<ChatMessage>();
        }

        public List<ChatMessage> GetChannelMessages(ChatChannel channel) {
            return channelMessages[channel];
        }

        public List<ChatMessage> GetAllChannelMessages() {
            return allChannelMessages;
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.Id == 10103) {
                Parse10103(packet);
            }
        }

        private void Parse10103(Packet packet) {
            if (packet.Message.Length > 0) {
                var token = JToken.Parse(packet.Message);
                var message = (string) token["message"];
                var sender = (string) token["sender"];
                var category = (int) token["category"];
                var messageType = (int) token["messageType"];
                AddMessage(category, sender, message);
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
                // return;
            }
            if (category == 12) {
                // sender: Hệ thống
                // message: Thánh_Nữ Chinh chiến nhận được {Bá Đạo Kiếm(mảnh)|6|272780}(Mảnh vỡ 1/20)
                // message: Dân Chơi tại Võ Đài thắng liên tiếp 10 trận, đại sát đại nộ!
                // message: ĐộcCôCầuBại đã tóm gọn kẻ bị truy nã - Gaj Thaj từ Ngụy Quốc. Mọi ngời nhiệt liệt hoan nghênh!<a href='event:reportId|148446471411827152'>[<font color='#71DEE3'>Chiến báo</font>]</a>
                // message: F.Lampard Ủy phái nhận được {Kỳ Lân(mảnh)|6|63965}(Mảnh vỡ 15/20)
                AddMessage(ChatChannel.World, sender, message);
                return;
            }
            if (category == 13) {
                // sender: Hệ thống
                // message: Quân Sư Rồng Uy Danh tăng mạnh 530000 trở thành Đại Đô Đốc Tam Tinh, hiệu quả gia thành: Công Kích+10%, Phòng Thủ+5%! Chúc mừng mãnh tướng mới của Ngụy quốc!
                AddMessage(ChatChannel.World, sender, message);
                return;
            }
            if (category == 14) {
                // sender: Hệ thống
                // message: MNSĐ.014 đã ghép lại các mảnh vỡ và nhận được {Đồng Tước|4|1548879}
                AddMessage(ChatChannel.Local, sender, message);
                return;
            }
            if (category == 15) {
                // sender: Hệ thống
                // message: Hộ tống thành công 【Vận Thâu Xa】 đến đích, nhận 9180 bạc, 8160 lúa, 918 chiến tích.
                AddMessage(ChatChannel.Local, sender, message);
                return;
            }
            if (category == 16) {
                // sender: Hệ thống
                // message: Kỹ thuật Bang Đẳng cấp đã nâng đến cấp 160
                AddMessage(ChatChannel.Legion, sender, message);
                return;
            }
            return;
        }

        private void AddMessage(ChatChannel channel, string sender, string message) {
            AddMessage(new ChatMessage(channel, sender, message));
        }

        private void AddMessage(ChatMessage message) {
            channelMessages[message.Channel].Add(message);
            allChannelMessages.Add(message);
            Validate();
            MessagesChanged.Raise(this);
        }

        private void Validate() {
            foreach (var item in channelMessages) {
                Validate(item.Value, ChannelLimit);
            }
            Validate(allChannelMessages, AllChannelLimit);
        }

        private void Validate(List<ChatMessage> messages, int limit) {
            while (messages.Count > limit) {
                messages.RemoveAt(0);
            }
        }

        public async Task<bool> SendMessage(ChatChannel channel, string content) {
            var packet = await client.SendCommandAsync(10103, client.PlayerName, content, channel.Id.ToString(), " ");
            if (packet == null) {
                return false;
            }
            return true;
        }
    }
}