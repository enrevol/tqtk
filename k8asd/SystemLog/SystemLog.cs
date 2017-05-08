using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace k8asd {
    public class SystemLog : ISystemLog {
        public event EventHandler MessagesChanged;

        private int MessageLimit = 500;

        private List<SystemMessage> messages;
        private IClient client;

        public List<SystemMessage> Messages {
            get { return messages; }
        }

        public SystemLog() {
            messages = new List<SystemMessage>();
        }

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

        public void Log(string message) {
            Log("Khác", message);
        }

        public void Log(string tag, string message) {
            messages.Add(new SystemMessage(client.PlayerName, tag, message));
            if (messages.Count > MessageLimit) {
                messages.RemoveAt(0);
            }
            MessagesChanged.Raise(this);
        }

        private void OnPacketReceived(object sender, Packet packet) {
            if (packet.HasError) {
                Log("Lỗi", packet.ErrorMessage);
            }
        }
    }
}