using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class BaseConfig : IConfig {
        protected JObject data;

        public JObject Data {
            get {
                if (data == null) {
                    data = new JObject();
                }
                return data;
            }
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
    }
}
