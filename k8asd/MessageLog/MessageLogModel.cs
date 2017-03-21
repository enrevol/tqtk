using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    public class MessageLogModel : IMessageLogModel {
        private string message;
        private IPacketWriter packetWriter;

        public event EventHandler<string> MessageChanged;

        public string Message {
            get { return message; }
        }

        public MessageLogModel() {
            message = String.Empty;
        }

        public void SetPacketWriter(IPacketWriter writer) {
            if (packetWriter != null) {
                packetWriter.PacketReceived -= OnPacketReceived;
            }
            packetWriter = writer;
            packetWriter.PacketReceived += OnPacketReceived;
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.CommandId == "10103") {
                // Ignore chat messages.
                return;
            }
            if (packet.Message.Length > 0) {
                var token = JToken.Parse(packet.Message);
                if (token.HasValues) {
                    // Packet 10100 won't have any values.
                    TryLog(token, "message");
                    TryLog(token, "errmessage");
                    TryLog(token, "msg");
                }
            }
        }

        private void TryLog(JToken token, string key) {
            var value = token[key];
            if (value != null) {
                LogInfo((string) value);
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