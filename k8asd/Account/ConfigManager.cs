using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace k8asd {
    /// <summary>
    /// Quản lý cấu hình tất cả người chơi và phần mềm.
    /// </summary>
    public class ConfigManager {
        private static ConfigManager sharedInstance;

        private List<ClientConfig> configs;

        public static ConfigManager Instance {
            get {
                if (sharedInstance == null) {
                    sharedInstance = new ConfigManager();
                }
                return sharedInstance;
            }
        }

        private ConfigManager() {
            configs = new List<ClientConfig>();
        }

        public List<ClientConfig> Configs {
            get { return configs; }
        }

        public void LoadConfigs() {
            var path = ConfigPath;
            var content = ReadFileContent(path);
            if (content.Length > 0) {
                var token = JToken.Parse(content);
                var array = (JArray) token["accounts"];
                configs = new List<ClientConfig>();
                foreach (var item in array) {
                    var config = ClientConfig.Parse((JObject) item);
                    configs.Add(config);
                }
            }
        }

        public void SaveConfig(ClientConfig config) {
            configs.Remove(config);
            configs.Add(config);
            Flush();
        }

        public void DeleteConfig(ClientConfig config) {
            configs.Remove(config);
            Flush();
        }

        public void Flush() {
            var array = new JArray();
            foreach (var config in configs) {
                array.Add(config.Data);
            }
            var path = ConfigPath;
            var token = new JObject();
            token["accounts"] = array;
            WriteFileContent(path, token.ToString());
        }

        /// <summary>
        /// Đường dẫn đến tệp tin cấu hình.
        /// </summary>
        private string ConfigPath {
            get { return Path.Combine(Environment.CurrentDirectory, "configs.json"); }
        }

        /// <summary>
        /// Attempts to read the content of the specified file.
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns></returns>
        private string ReadFileContent(string path) {
            var content = String.Empty;
            if (File.Exists(path)) {
                using (var reader = new StreamReader(path)) {
                    content = reader.ReadToEnd();
                }
            }
            return content;
        }

        /// <summary>
        /// Attempts to write the specified content to the specified file.
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <param name="content">The content to be written</param>
        private void WriteFileContent(string path, string content) {
            if (!File.Exists(path)) {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (var fs = File.Create(path)) {
                    //
                }
            }
            using (var streamWriter = new StreamWriter(path)) {
                streamWriter.Write(content);
            }
        }
    }
}
