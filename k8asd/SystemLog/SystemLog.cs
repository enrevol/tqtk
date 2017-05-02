using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace k8asd {
    public class SystemLog : ISystemLog {
        private int LineLimit = 500;

        private Queue<int> lineLengths;

        private IClient client;
        private string message;

        public event EventHandler<string> MessageChanged;

        public string Message {
            get { return message; }
        }

        public SystemLog() {
            message = String.Empty;
            lineLengths = new Queue<int>();
        }

        public IClient Client {
            get { return client; }
            set {
                if (client != null) {
                    client.PacketReceived -= OnPacketReceived;
                }
                client = value;
                client.PacketReceived += OnPacketReceived;
            }
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.Id == 10103) {
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
            var line = String.Format("[{0}] {1}", Utils.FormatDuration(DateTime.Now), newMessage);
            message += line;
            lineLengths.Enqueue(line.Length);
            while (lineLengths.Count > LineLimit) {
                var firstLineLength = lineLengths.Dequeue() + Environment.NewLine.Length;
                message = message.Remove(0, firstLineLength);
            }
            MessageChanged.Raise(this, message);
        }
    }
}