using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    interface IConfigLoader {
        /// <summary>
        /// Tải cấu hình.
        /// </summary>
        /// <param name="config">Cấu hình để tải.</param>
        /// <returns>Có thành công hay không?</returns>
        bool LoadConfig(IConfig config);
    }
}
