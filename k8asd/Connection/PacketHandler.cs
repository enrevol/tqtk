using System;
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.Concurrent;
using Nito.AsyncEx;
using System.Threading;

namespace k8asd {
    /// <summary>
    /// Handles packets between the client and server.
    /// </summary>
    public class PacketHandler : IDisposable, IPacketWriter {
        public enum ConnectResult {
            Connecting,
            Failed,
            Succeeded,
        };

        private const int BufferSize = 1024;

        public event EventHandler<Packet> OnPacketReceived;

        public bool Connected {
            get { return tcpClient.Connected; }
        }

        public Session Session { get; private set; }

        private TcpClient tcpClient;

        /// <summary>
        /// Accumulated messages received from the server.
        /// </summary>
        private string streamData;

        private byte[] buffer;

        /// <summary>
        /// Used for encoding messages for sending.
        /// </summary>
        private MD5 hasher;

        /// <summary>
        /// Packet queues.
        /// </summary>
        private ConcurrentDictionary<string, AsyncCollection<Packet>> queues;

        private CancellationTokenSource tokenSource;
        private Task readingTask;

        public PacketHandler(Session session) {
            Session = session;
            tcpClient = null;
            buffer = new byte[BufferSize];
            hasher = MD5.Create();
            queues = new ConcurrentDictionary<string, AsyncCollection<Packet>>();
            streamData = String.Empty;
            tokenSource = null;
            readingTask = null;
        }

        /// <summary>
        /// Clears data received from the server.
        /// </summary>
        private void ClearData() {
            streamData = String.Empty;
            queues.Clear();
        }

        /// <summary>
        /// Asynchronously connects to the server.
        /// </summary>
        public async Task ConnectAsync() {
            await Disconnect();
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(Session.Ip, Session.Ports);
            StartReadingData();
        }

        /// <summary>
        /// Asynchronously disconnects from the server.
        /// </summary>
        public async Task Disconnect() {
            await StopReadingData();
            if (tcpClient != null) {
                tcpClient.Close();
                tcpClient = null;
            }
            ClearData();
        }

        public async Task<Packet> SendCommandAsync(string commandId, params string[] parameters) {
            var msg = Utils.EncodeMessage(hasher, Session.UserId, Session.SessionKey, commandId, parameters);
            var bytes = Encoding.UTF8.GetBytes(msg);
            var stream = tcpClient.GetStream();
            await stream.WriteAsync(bytes, 0, bytes.Length);
            if (!tcpClient.Connected) {
                // Failed.
                return null;
            }

            var blocks = GetQueue(commandId);
            var result = await blocks.TakeAsync();
            return result;
        }

        private void StartReadingData() {
            if (tokenSource == null) {
                tokenSource = new CancellationTokenSource();
                readingTask = Task.Factory.StartNew(ReadData, tokenSource.Token,
                    TaskCreationOptions.DenyChildAttach, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        private async Task StopReadingData() {
            if (tokenSource != null) {
                tokenSource.Cancel();
                tokenSource.Dispose();
                tokenSource = null;
                await readingTask;
            }
        }

        private async Task ReadData() {
            while (true) {
                if (tokenSource.Token.IsCancellationRequested) {
                    return;
                }
                var stream = tcpClient.GetStream();
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                streamData += Encoding.UTF8.GetString(buffer, 0, bytesRead);

                var packet = ParsePacket();
                if (packet != null) {
                    OnPacketReceived.Raise(this, packet);
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

        /// <summary>
        /// Adds the specified packet to its corresponding queue.
        /// </summary>
        private void PushPacket(Packet packet) {
            var id = packet.CommandId;
            var queue = GetQueue(id);
            queue.Add(packet);
        }

        private AsyncCollection<Packet> GetQueue(string id) {
            return queues.GetOrAdd(id, new AsyncCollection<Packet>());
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing) {
            if (disposed) {
                return;
            }

            if (disposing) {
                if (tcpClient != null) {
                    tcpClient.Close();
                    tcpClient = null;
                }
                hasher.Dispose();
                hasher = null;
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
