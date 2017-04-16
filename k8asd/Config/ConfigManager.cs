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
        private BaseConfig settings;

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
            settings = new BaseConfig();
        }

        /// <summary>
        /// Cấu hình tất cả người chơi.
        /// </summary>
        public List<ClientConfig> Configs {
            get { return configs; }
        }

        /// <summary>
        /// Cấu hình tuỳ chọn.
        /// </summary>
        public BaseConfig Settings {
            get { return settings; }
        }

        /// <summary>
        /// Cập nhật lại cấu hình tất cả người chơi từ tệp tin.
        /// </summary>
        public void LoadConfigs() {
            var path = ConfigPath;
            var content = FileUtils.ReadFileContent(path);
            if (content.Length > 0) {
                var token = JToken.Parse(content);
                LoadSettings(token["settings"]);
                LoadAccounts(token["accounts"]);
            }
        }

        private void LoadSettings(JToken token) {
            if (token == null) {
                return;
            }
            settings = new BaseConfig((JObject) token);
        }

        private void LoadAccounts(JToken token) {
            if (token == null) {
                return;
            }
            configs = new List<ClientConfig>();
            foreach (var item in (JArray) token) {
                var config = new ClientConfig((JObject) item);
                configs.Add(config);
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
            token["settings"] = settings.Data;
            FileUtils.WriteFileContent(path, token.ToString());
        }

        /// <summary>
        /// Đường dẫn đến tệp tin cấu hình.
        /// </summary>
        private string ConfigPath {
            get { return Path.Combine(Environment.CurrentDirectory, "configs.json"); }
        }
    }
}
