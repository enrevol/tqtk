using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    class FileUtils {
        /// <summary>
        /// Attempts to read the content of the specified file.
        /// </summary>
        /// <param name="path">The path of the file</param>
        /// <returns></returns>
        public static string ReadFileContent(string path) {
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
        public static void WriteFileContent(string path, string content) {
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
