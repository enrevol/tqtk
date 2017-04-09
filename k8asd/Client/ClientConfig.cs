using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class ClientConfig : IConfig {
        private static readonly string ServerIdKey = "server_id";
        private static readonly string UsernameKey = "username";
        private static readonly string PasswordKey = "password";

        private JObject data;

        public static ClientConfig Parse(JObject data) {
            var result = new ClientConfig();
            result.data = (JObject) data.DeepClone();
            return result;
        }

        public JObject Data {
            get {
                if (data == null) {
                    data = new JObject();
                }
                return data;
            }
        }

        public int ServerId {
            get {
                int result;
                if (!Int32.TryParse(Get(ServerIdKey), out result)) {
                    result = 0;
                }
                return result;
            }
            set { Put(ServerIdKey, value); }
        }

        public string Username {
            get { return Get(UsernameKey); }
            set { Put(UsernameKey, value); }
        }

        public string Password {
            get { return Get(PasswordKey); }
            set { Put(PasswordKey, value); }
        }

        public void Put<T>(string key, T value) {
            Data[key] = JToken.FromObject(value);
        }

        public void PutArray<T>(string key, List<T> values) {
            var value = String.Join(",", values);
            Put(key, value);
        }

        public string Get(string key) {
            var value = Data[key];
            if (value == null) {
                return null;
            }
            return (string) value;
        }

        public List<string> GetArray(string key) {
            var values = Get(key);
            if (values == null) {
                return Enumerable.Empty<string>().ToList();
            }
            return values.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public override bool Equals(object obj) {
            var item = obj as ClientConfig;
            if (item == null) {
                return false;
            }
            return ServerId == item.ServerId && Username == item.Username;
        }

        public override int GetHashCode() {
            return (ServerId.ToString() + Username).GetHashCode();
        }
    }
}
