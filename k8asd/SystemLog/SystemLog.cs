using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace k8asd {
    public class SystemLog : ISystemLog {
        private const int MessageLimit = 500;

        public event EventHandler MessagesChanged;

        private IClient client;
        private List<SystemMessage> messages;

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

        public List<SystemMessage> Messages {
            get { return messages; }
        }

        public SystemLog() {
            client = null;
            messages = new List<SystemMessage>();
        }

        public void Log(string message) {
            Log("Khác", message);
        }

        public void Log(string tag, string message) {
            messages.Add(new SystemMessage(client.Config.Username, tag, message));
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