using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class AccountManager {
        private static AccountManager sharedInstance;

        public static AccountManager Instance {
            get {
                if (sharedInstance == null) {
                    sharedInstance = new AccountManager();
                }
                return sharedInstance;
            }
        }

        /// <summary>
        /// Gets the accounts directory.
        /// </summary>
        private string AccountsDirectory {
            get {
                var directory = Path.Combine(Environment.CurrentDirectory, "accounts");
                if (!Directory.Exists(directory)) {
                    Directory.CreateDirectory(directory);
                }
                return directory;
            }
        }

        public string GetFilePath(int serverId, string username) {
            var filename = String.Format("{0}_{1}.json", serverId, username);
            var filePath = Path.Combine(AccountsDirectory, filename);
            return filePath;
        }

        /// <summary>
        /// Gets the file path for the specified configuration.
        /// </summary>
        public string GetFilePath(Configuration configuration) {
            return GetFilePath(configuration.ServerId, configuration.Username);
        }

        public List<Configuration> LoadConfigurations() {
            List<Configuration> configurations = new List<Configuration>();
            var files = Directory.GetFiles(AccountsDirectory);
            foreach (var file in files) {
                configurations.Add(LoadConfiguration(file));
            }
            return configurations;
        }

        public Configuration LoadConfiguration(int serverId, string username) {
            var filePath = GetFilePath(serverId, username);
            return LoadConfiguration(filePath);
        }

        private Configuration LoadConfiguration(string path) {
            var content = ReadFileContent(path);
            return Configuration.Parse(content);
        }

        /// <summary>
        /// Saves the specified account configuration.
        /// </summary>
        /// <param name="configuration"></param>
        public void SaveConfiguration(Configuration configuration) {
            var filePath = GetFilePath(configuration);
            WriteFileContent(filePath, configuration.Dump());
        }

        public void DeleteConfiguration(int serverId, string username) {
            var filePath = GetFilePath(serverId, username);
            File.Delete(filePath);
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
