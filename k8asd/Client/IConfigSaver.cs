using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    interface IConfigSaver {
        /// <summary>
        /// Lưu cấu hình hiện tại.
        /// </summary>
        /// <param name="config">Cấu hình để lưu vào.</param>
        void SaveConfig(IConfig config);
    }
}
