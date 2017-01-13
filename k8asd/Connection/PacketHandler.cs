using System;
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace k8asd {
    public class PacketHandler : IDisposable {
        private const int BufferSize = 1024;

        private Session session;
        private TcpClient tcpClient;
        private string streamData;
        private byte[] buffer;
        private MD5 hasher;

        public string Data { get { return streamData; } }

        public PacketHandler(Session session) {
            this.session = session;
            tcpClient = new TcpClient();
            buffer = new byte[BufferSize];
            hasher = MD5.Create();
            ClearData();
        }

        private void ClearData() {
            streamData = "";
        }

        public void Disconnect() {
            // tcpClient_.
        }

        public bool Connect() {
            Disconnect();
            tcpClient.Connect(session.Ip, session.Ports);
            return true;
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
                return packet;
            }
            return null;
        }

        // public bool sendCommand(Command command) {
        //     return sendCommand(command.Id, command.Parameters);
        // }

        public bool SendCommand(string commandId, params string[] parameters) {
            var succeeded = false;
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
            succeeded = true;
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
