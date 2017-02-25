using System;
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace k8asd {
    public class PacketHandler : IDisposable {
        public enum ConnectResult {
            Connecting,
            Failed,
            Succeeded,
        };

        private const int BufferSize = 1024;

        private Session session;
        private TcpClient tcpClient;
        private string streamData;
        private byte[] buffer;
        private MD5 hasher;
        private Dictionary<string, Queue<Action<Packet>>> callbacks;

        public string Data { get { return streamData; } }

        public PacketHandler(Session session) {
            this.session = session;
            tcpClient = new TcpClient();
            buffer = new byte[BufferSize];
            hasher = MD5.Create();
            callbacks = new Dictionary<string, Queue<Action<Packet>>>();
            ClearData();
        }

        private void ClearData() {
            streamData = "";
        }

        public void Disconnect() {
            // tcpClient_.
        }

        /// <summary>
        /// Attempts to connect to the server.
        /// </summary>
        /// <returns></returns>
        public bool Connect() {
            Disconnect();
            tcpClient.Connect(session.Ip, session.Ports);
            return true;
        }

        public bool Connected {
            get { return tcpClient.Connected; }
        }

        public Packet ReadPacket() {
            if (tcpClient.Available > 0) {
                var stream = tcpClient.GetStream();
                var bytesRead = stream.Read(buffer, 0, buffer.Length);
                streamData += Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }

            // Find the termination of the received message.
            const char TerminationChar = '\x5';
            var index = streamData.IndexOf(TerminationChar);
            if (index == -1) {
                return null;
            }

            var packetData = streamData.Remove(index);
            var packet = new Packet();

            if (packet.Parse(packetData)) {
                streamData = streamData.Substring(index + 1); // Ignore the termination character.
                PopCallback(packet);
                return packet;
            }
            return null;
        }

        private void PushCallback(Action<Packet> callback, string commandId) {
            if (callback != null) {
                if (!callbacks.ContainsKey(commandId)) {
                    callbacks.Add(commandId, new Queue<Action<Packet>>());
                }
                callbacks[commandId].Enqueue(callback);
            }
        }

        private void PopCallback(Packet packet) {
            var key = packet.CommandId;
            if (callbacks.ContainsKey(key)) {
                var queue = callbacks[key];
                if (queue.Count > 0) {
                    queue.Dequeue()(packet);
                }
            }
        }

        // public bool sendCommand(Command command) {
        //     return sendCommand(command.Id, command.Parameters);
        // }

        public bool SendCommand(Action<Packet> callback, string commandId, params string[] parameters) {
            const string what_is_this = "5dcd73d391c90e8769618d42a916ea1b";

            var input = commandId + session.UserId;
            var msg = String.Format("{0}\x1{1}\t{2}\x2", commandId, session.UserId, session.SessionKey);

            var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var millisecondsSinceEpoch = (long) timeSpan.TotalMilliseconds;

            foreach (var parameter in parameters) {
                input += parameter;
                msg += parameter + '\t';
            }

            input += what_is_this;

            if (parameters.Length > 0) {
                msg = msg.Remove(msg.Length - 1);
            }

            var checksum = Utils.ComputeHash(hasher, input);
            msg += String.Format("\x3{0}\x4{1}\x5\0", checksum, millisecondsSinceEpoch);

            var bytes = Encoding.UTF8.GetBytes(msg);
            var stream = tcpClient.GetStream();
            stream.Write(bytes, 0, bytes.Length);

            var succeeded = tcpClient.Connected;
            if (succeeded) {
                PushCallback(callback, commandId);
            }
            return succeeded;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (disposed) {
                return;
            }

            if (disposing) {
                ((IDisposable) tcpClient).Dispose();
                ((IDisposable) hasher).Dispose();
            }
            streamData = null;
            buffer = null;
            disposed = true;
        }

        ~PacketHandler() {
            Dispose(false);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
