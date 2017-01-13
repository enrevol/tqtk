using Newtonsoft.Json.Linq;

namespace k8asd {
    public class Packet {
        // Example packet header: {"u":5542014,"r":0,"m":1479487733780,"h":10100}

        private string u; /// User id.
        private string r; /// ???
        private string m; /// Message.
        private string h; /// Command id.
        private string raw;

        public string UserId { get { return u; } }
        public string Message { get { return m; } }
        public string CommandId { get { return h; } }
        public string Raw { get { return raw; } }

        public bool Parse(string data) {
            var token = JToken.Parse(data);
            u = (string) token["u"];
            r = (string) token["r"];
            m = token["m"].ToString(); // m is still in JSON format.
            h = (string) token["h"];
            raw = data;
            return true;
        }
    }
}
