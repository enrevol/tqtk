using System;
using System.Text;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Collections.Generic;
using Nito.AsyncEx;
using System.IO;
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

        /// <summary>
        /// Size of the buffer used to read received data.
        /// </summary>
        private const int BufferSize = 1024;

        public event EventHandler<Packet> PacketReceived;

        public bool Connected {
            get { return tcpClient.Connected; }
        }

        public Session Session { get; private set; }

        /// <summary>
        /// Underlying TCP client to communicate with the server.
        /// </summary>
        private TcpClient tcpClient;

        /// <summary>
        /// Accumulated messages received from the server.
        /// </summary>
        private string streamData;

        /// <summary>
        /// Used to read received data.
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// Used for encoding messages for sending.
        /// </summary>
        private MD5 hasher;

        /// <summary>
        /// Packet queues.
        /// </summary>
        private Dictionary<string, AsyncCollection<Packet>> queues;

        private Dictionary<string, int> messageDelta;

        private CancellationTokenSource readingTokenSource;
        private TaskCompletionSource readingTaskSignal;

        private bool isReading;

        public PacketHandler(Session session) {
            Session = session;
            tcpClient = null;
            buffer = new byte[BufferSize];
            hasher = MD5.Create();
            queues = new Dictionary<string, AsyncCollection<Packet>>();
            messageDelta = new Dictionary<string, int>();
            streamData = String.Empty;
            readingTokenSource = null;
            isReading = false;
        }

        /// <summary>
        /// Clears data received from the server.
        /// </summary>
        private void ClearData() {
            streamData = String.Empty;
            queues.Clear();
            messageDelta.Clear();
        }

        /// <summary>
        /// Asynchronously connects to the server.
        /// </summary>
        public async Task ConnectAsync() {
            await Disconnect();
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(Session.Ip, Session.Ports);
        }

        /// <summary>
        /// Asynchronously disconnects from the server.
        /// </summary>
        public async Task Disconnect() {
            if (readingTokenSource != null) {
                readingTaskSignal = new TaskCompletionSource();
                readingTokenSource.Cancel();
                await readingTaskSignal.Task;
            }
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
            try {
                await stream.WriteAsync(bytes, 0, bytes.Length);
                if (!tcpClient.Connected) {
                    // Failed.
                    return null;
                }
                PushDelta(commandId);
            } catch (SocketException ex) {
                Console.WriteLine(ex.Message);
                return null;
            }

            var blocks = GetQueue(commandId);
            var result = await blocks.TakeAsync();
            return result;
        }

        public async Task<bool> ReadData() {
            if (isReading) {
                return true;
            }
            isReading = true;
            try {
                readingTokenSource = new CancellationTokenSource();
                while (true) {
                    var stream = tcpClient.GetStream();
                    try {
                        var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, readingTokenSource.Token);
                        if (bytesRead == 0) {
                            break;
                        }
                        if (readingTokenSource.Token.IsCancellationRequested) {
                            break;
                        }
                        streamData += Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    } catch (SocketException ex) {
                        Console.WriteLine(ex.Message);
                        return false;
                    } catch (IOException ex) {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                    while (true) {
                        var packet = ParsePacket();
                        if (packet == null) {
                            break;
                        }
                        PacketReceived.Raise(this, packet);
                        var id = packet.CommandId;
                        if (PopDelta(id)) {
                            PushPacket(packet);
                        }
                    }
                }
            } finally {
                isReading = false;
                readingTokenSource.Dispose();
                readingTokenSource = null;
                if (readingTaskSignal != null) {
                    readingTaskSignal.SetResult();
                }
            }
            return true;
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
            if (!queues.ContainsKey(id)) {
                queues.Add(id, new AsyncCollection<Packet>());
            }
            return queues[id];
        }

        private void EnsureDelta(string id) {
            if (!messageDelta.ContainsKey(id)) {
                messageDelta.Add(id, 0);
            }
        }

        private int GetDelta(string id) {
            EnsureDelta(id);
            return messageDelta[id];
        }

        private void PushDelta(string id) {
            EnsureDelta(id);
            ++messageDelta[id];
        }

        private bool PopDelta(string id) {
            EnsureDelta(id);
            if (messageDelta[id] == 0) {
                return false;
            }
            --messageDelta[id];
            return true;
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
            Session = null;
            streamData = null;
            buffer = null;
            queues = null;
            messageDelta = null;
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
