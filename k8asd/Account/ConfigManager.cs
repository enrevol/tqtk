using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace k8asd {
    /// <summary>
    /// Quản lý cấu hình tất cả người chơi và phần mềm.
    /// </summary>
    public class ConfigManager : BaseConfig {
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

        /// <summary>
        /// Cấu hình tất cả người chơi.
        /// </summary>
        public List<ClientConfig> Configs {
            get { return configs; }
        }

        /// <summary>
        /// Cập nhật lại cấu hình tất cả người chơi từ tệp tin.
        /// </summary>
        public void LoadConfigs() {
            var path = ConfigPath;
            var content = ReadFileContent(path);
            if (content.Length > 0) {
                var token = JToken.Parse(content);
                var settings = token["settings"];
                if (settings != null) {
                    data = (JObject) settings.DeepClone();
                }
                var array = (JArray) token["accounts"];
                configs = new List<ClientConfig>();
                foreach (var item in array) {
                    var config = ClientConfig.Parse((JObject) item);
                    configs.Add(config);
                }
            }
        }

        /// <summary>
        /// Thêm hoặc thay đổi cấu hình.
        /// </summary>
        /// <param name="config">Cấu hình được thêm hoặc thay đổi.</param>
        public void SaveConfig(ClientConfig config) {
            var index = configs.IndexOf(config);
            if (index != -1) {
                // Thay thế cấu hình cũ.
                configs[index] = config;
            } else {
                // Thêm cấu hình vào cuối.
                configs.Add(config);
            }
            Flush();
        }

        /// <summary>
        /// Xoá cấu hình.
        /// </summary>
        /// <param name="config">Cấu hình bị xoá.</param>
        public void DeleteConfig(ClientConfig config) {
            configs.Remove(config);
            Flush();
        }

        /// <summary>
        /// Di chuyển cấu hình lên trước.
        /// </summary>
        /// <param name="config">Cấu hình được di chuyển.</param>
        public void MoveUpConfig(ClientConfig config) {
            var index = configs.IndexOf(config);
            var temp = configs[index - 1];
            configs[index - 1] = config;
            configs[index] = temp;
        }

        /// <summary>
        /// Di chuyển cấu hình ra sau.
        /// </summary>
        /// <param name="config">Cấu hình được di chuyển.</param>
        public void MoveDownConfig(ClientConfig config) {
            var index = configs.IndexOf(config);
            var temp = configs[index + 1];
            configs[index + 1] = config;
            configs[index] = temp;
        }

        /// <summary>
        /// Lưu cấu hình hiện tại vào tệp tin.
        /// </summary>
        public void Flush() {
            var accounts = new JArray();
            foreach (var config in configs) {
                accounts.Add(config.Data);
            }
            var path = ConfigPath;
            var token = new JObject();
            token["accounts"] = accounts;
            token["settings"] = Data;
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
