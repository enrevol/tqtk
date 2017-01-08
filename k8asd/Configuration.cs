using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class Configuration {
        private JObject data;

        private JObject Data {
            get {
                if (data == null) {
                    data = new JObject();
                }
                return data;
            }
        }

        private JObject Account {
            get {
                var account = Data["account"];
                if (account == null) {
                    Data.Add("account", new JObject());
                }
                return (JObject) Data["account"];
            }
        }

        public int ServerId {
            get {
                return (int) Data["account"]["server_id"];
            }
            set {
                Account["server_id"] = value;
            }
        }

        public string Username {
            get {
                return (string) Data["account"]["username"];
            }
            set {
                Account["username"] = value;
            }
        }

        public string Password {
            get {
                return (string) Data["account"]["password"];
            }
            set {
                Account["password"] = value;
            }
        }

        public static Configuration Parse(string content) {
            var config = new Configuration();
            if (content.Length > 0) {
                config.data = JObject.Parse(content);
            }
            return config;
        }

        public string Dump() {
            return data.ToString();
        }

        public override string ToString() {
            return String.Format("{0}_{1}", ServerId, Username);
        }
    }
}
