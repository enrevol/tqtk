using System;

namespace k8asd {
    public interface IPacketWriter {
        /// <summary>
        /// Attempts to send the specified command and parameters to the server without a callback.
        /// </summary>
        /// <param name="command">The command id</param>
        /// <param name="parameters">The additional parameters</param>
        /// <returns></returns>
        bool SendCommand(string command, params string[] parameters);

        /// <summary>
        /// Attempts to send the specified command and parameters to the server with a callback.
        /// </summary>
        /// <param name="callback">Will be called when the corresponding reply from the server is received</param>
        /// <param name="command">The command id</param>
        /// <param name="parameters">The additional parameters</param>
        /// <returns>Whether the attemption was successful</returns>
        bool SendCommand(Action<Packet> callback, string command, params string[] parameters);
    }
}
