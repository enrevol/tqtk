using Newtonsoft.Json.Linq;

namespace k8asd {
    /// <summary>
    /// Represents a packet received from the server
    /// </summary>
    public class Packet {
        // Example packet header: {"u":5542014,"r":0,"m":1479487733780,"h":10100}

        /// <summary>
        /// Gets the ID of the packet.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the associated user id.
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// Gets the main message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the original command id.
        /// </summary>
        [System.Obsolete("Use Id instead.")]
        public string CommandId { get { return Id.ToString(); } }

        /// <summary>
        /// Gets the raw message.
        /// </summary>
        public string Raw { get; private set; }

        public bool Parse(string data) {
            var token = JToken.Parse(data);
            Id = (int) token["h"];
            UserId = (int) token["u"];
            Message = token["m"].ToString(); // m is still in JSON format.
            Raw = data;
            return true;
        }
    }
}
