using Newtonsoft.Json.Linq;
using System;

namespace k8asd {
    class StatePacket {
        public bool Ok { get; private set; }
        public string Message { get; private set; }

        public static StatePacket Parse(Packet packet) {
            return Parse(JToken.Parse(packet.Message));
        }

        public static StatePacket Parse(string message) {
            return Parse(JToken.Parse(message));
        }

        public static StatePacket Parse(JToken token) {
            var result = new StatePacket();
            var state = token["state"];
            if (state != null) {
                result.Ok = true;
                result.Message = null;
                return result;
            }
            result.Ok = false;
            result.Message = String.Empty;
            do {
                if (token["message"] != null) {
                    result.Message = (string) token["message"];
                    break;
                }
                if (token["errmessage"] != null) {
                    result.Message = (string) token["errmessage"];
                    break;
                }
                if (token["msg"] != null) {
                    result.Message = (string) token["msg"];
                    break;
                }
            } while (false);
            return result;
        }
    }
}
