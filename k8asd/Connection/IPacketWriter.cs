using System;
using System.Threading.Tasks;

namespace k8asd {
    public interface IPacketWriter {
        /// <summary>
        /// Occurs when the server has sent a message.
        /// </summary>
        event EventHandler<Packet> PacketReceived;

        /// <summary>
        /// Asynchronously send the specified command and parameters to the server.
        /// </summary>
        /// <param name="command">The command id.</param>
        /// <param name="parameters">The additional parameters.</param>
        /// <returns>Whether the attemption was successful.</returns>
        Task<Packet> SendCommandAsync(int commandId, params string[] parameters);
    }
}
