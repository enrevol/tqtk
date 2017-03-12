using System;
using System.Threading.Tasks;

namespace k8asd {
    public interface IPacketWriter {
        /// <summary>
        /// Occurs when the server has sent a message.
        /// </summary>
        event EventHandler<Packet> PacketReceived;

        /// <summary>
        /// Attempts to send the specified command and parameters to the server with a callback.
        /// </summary>
        /// <param name="callback">Will be called when the corresponding reply from the server is received</param>
        /// <param name="command">The command id</param>
        /// <param name="parameters">The additional parameters</param>
        /// <returns>Whether the attemption was successful</returns>
        Task<Packet> SendCommandAsync(string command, params string[] parameters);
    }
}
