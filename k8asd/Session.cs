using System;

namespace k8asd {
    /// <summary>
    /// Stores the session info.
    /// </summary>
    public class Session {
        private string userId;
        private string ip;
        private int ports;
        private string sessionKey;

        /// <summary>
        /// Gets the user id.
        /// </summary>
        public string UserId { get { return userId; } }

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        public string Ip { get { return ip; } }

        /// <summary>
        /// Gets the ports.
        /// </summary>
        public int Ports { get { return ports; } }

        /// <summary>
        /// Gets the session key.
        /// </summary>
        public string SessionKey { get { return sessionKey; } }

        /// <summary>
        /// Resets this session.
        /// </summary>
        public void Reset() {
            userId = ip = sessionKey = null;
            ports = 0;
        }

        /// <summary>
        /// Attempts to parse the session from the specified html source code.
        /// </summary>
        /// <param name="htmlCode">The html source code used for parsing.</param>
        /// <returns></returns>
        public Boolean Parse(string htmlCode) {
            string ports = null;
            var succeeded =
                ParseToken(htmlCode, "userID", ref userId) &&
                ParseToken(htmlCode, "ip", ref ip) &&
                ParseToken(htmlCode, "ports", ref ports) &&
                ParseToken(htmlCode, "sessionKey", ref sessionKey);

            if (!succeeded || !Int32.TryParse(ports, out this.ports)) {
                Reset();
            }
            return succeeded;
        }

        private bool ParseToken(string htmlCode, string token, ref string output) {
            token = token + " : ";
            int index = htmlCode.IndexOf(token);
            if (index == -1) {
                return false;
            }

            index += token.Length;
            var suffixIndex = htmlCode.IndexOf(",", index);
            if (suffixIndex == -1) {
                return false;
            }

            var value = htmlCode.Substring(index, suffixIndex - index);
            value = value.Trim('\'', '"');
            output = value;
            return true;
        }
    }
}
