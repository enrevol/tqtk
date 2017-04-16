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
        /// Đường dẫn đến tệp tin cấu hình mặc định.
        /// </summary>
        public string ConfigPath {
            get { return Path.Combine(Environment.CurrentDirectory, "configs.json"); }
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
        /// Tải cấu hình từ tệp tin mặc định.
        /// </summary>
        public void LoadConfigs() {
            LoadConfigs(ConfigPath);
        }

        /// <summary>
        /// Tải cấu hình từ tệp tin được chỉ định.
        /// </summary>
        /// <param name="path">Đường dẫn đến tệp tin.</param>
        public void LoadConfigs(string path) {
            var content = FileUtils.ReadFileContent(path);
            if (content.Length > 0) {
                var token = JToken.Parse(content);
                LoadConfigs(token);
            }
        }

        /// <summary>
        /// Tải cấu hình từ JSON.
        /// </summary>
        /// <param name="token">JSON</param>
        public void LoadConfigs(JToken token) {
            LoadSettings(token["settings"]);
            LoadAccounts(token["accounts"]);
        }

        /// <summary>
        /// Tải cấu hình tuỳ chọn từ JSON.
        /// </summary>
        /// <param name="token">JSON</param>
        private void LoadSettings(JToken token) {
            if (token == null) {
                return;
            }
            settings = new BaseConfig((JObject) token);
        }

        /// <summary>
        /// Tải cấu hình người chơi từ JSON.
        /// </summary>
        /// <param name="token">JSON</param>
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
        /// Thêm cấu hình người chơi vào cuối.
        /// </summary>
        /// <param name="config"></param>
        public void AddConfig(ClientConfig config) {
            configs.Add(new ClientConfig(config.Data));
        }

        /// <summary>
        /// Thay đổi cấu hình người chơi.
        /// </summary>
        /// <param name="index">Vị trí của cấu hình.</param>
        /// <param name="config">Cấu hình được thay đổi.</param>
        public void ReplaceConfig(int index, ClientConfig config) {
            configs[index] = new ClientConfig(config.Data);
        }

        /// <summary>
        /// Xoá cấu hình người chơi.
        /// </summary>
        /// <param name="config">Cấu hình bị xoá.</param>
        public void RemoveConfig(int index) {
            configs.RemoveAt(index);
        }

        /// <summary>
        /// Di chuyển cấu hình lên trước.
        /// </summary>
        /// <param name="config">Cấu hình được di chuyển.</param>
        public void MoveConfigUp(int index) {
            var temp = configs[index - 1];
            configs[index - 1] = configs[index];
            configs[index] = temp;
        }

        /// <summary>
        /// Di chuyển cấu hình ra sau.
        /// </summary>
        /// <param name="config">Cấu hình được di chuyển.</param>
        public void MoveConfigDown(int index) {
            var temp = configs[index + 1];
            configs[index + 1] = configs[index];
            configs[index] = temp;
        }

        /// <summary>
        /// Lưu cấu hình hiện tại vào tệp tin.
        /// </summary>
        public void Flush() {
            var token = new JObject();
            token["accounts"] = JArray.FromObject(configs.Select(item => item.Data));
            token["settings"] = settings.Data;
            Flush(token);
        }

        /// <summary>
        /// Lưu cấu hình JSON vào tệp tin.
        /// </summary>
        /// <param name="token">JSON</param>
        public void Flush(JToken token) {
            FileUtils.WriteFileContent(ConfigPath, token.ToString());
        }
    }
}
