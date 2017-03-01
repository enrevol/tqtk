using System;
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Collections.Generic;
using System.Diagnostics;

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

        private Dictionary<string, BufferBlock<Packet>> bufferBlocks;

        public string Data { get { return streamData; } }

        public PacketHandler(Session session) {
            this.session = session;
            tcpClient = null;
            buffer = new byte[BufferSize];
            hasher = MD5.Create();
            bufferBlocks = new Dictionary<string, BufferBlock<Packet>>();
            ClearData();
        }

        /// <summary>
        /// Clears data received from the server.
        /// </summary>
        private void ClearData() {
            streamData = "";
        }

        /// <summary>
        /// Disconnects from the server.
        /// </summary>
        public void Disconnect() {
            if (tcpClient != null) {
                tcpClient.Close();
                tcpClient = null;
            }
            ClearData();
        }

        /// <summary>
        /// Asynchronously connects to the server.
        /// </summary>
        public async Task Connect() {
            Disconnect();
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(session.Ip, session.Ports);
            ReadData();
        }

        public async void ReadData() {
            while (true) {
                var stream = tcpClient.GetStream();
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                streamData += Encoding.UTF8.GetString(buffer, 0, bytesRead);

                var packet = ParsePacket();
                if (packet != null) {
                    PushPacket(packet);
                }
            }
        }

        private Packet ParsePacket() {
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

        private void PushPacket(Packet packet) {
            var id = packet.CommandId;
            Debug.Assert(bufferBlocks.ContainsKey(id));

            var blocks = bufferBlocks[id];
            blocks.Post(packet);
            blocks.Complete();
        }

        public bool Connected {
            get { return tcpClient.Connected; }
        }

        public async Task<Packet> SendCommand(string commandId, params string[] parameters) {
            var msg = Utils.EncodeMessage(hasher, session.UserId, session.SessionKey, commandId, parameters);
            var bytes = Encoding.UTF8.GetBytes(msg);
            var stream = tcpClient.GetStream();
            await stream.WriteAsync(bytes, 0, bytes.Length);
            if (!tcpClient.Connected) {
                // Failed.
                return null;
            }

            Packet result = null;
            var consumerOptions = new ExecutionDataflowBlockOptions { BoundedCapacity = 1 };
            var consumerBlock = new ActionBlock<Packet>(packet => result = packet, consumerOptions);

            if (!bufferBlocks.ContainsKey(commandId)) {
                bufferBlocks.Add(commandId, new BufferBlock<Packet>());
            }
            var blocks = bufferBlocks[commandId];
            blocks.LinkTo(consumerBlock, new DataflowLinkOptions { PropagateCompletion = true });

            await consumerBlock.Completion;
            return result;
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
