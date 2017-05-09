using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Trạng thái của nhiệm vụ.
    /// </summary>
    public enum TaskState {
        /// <summary>
        /// Chưa nhận, chưa hoàn thành.
        /// </summary>
        None = 0,

        /// <summary>
        /// Đã nhận, đang làm.
        /// </summary>
        Received = 1,

        /// <summary>
        /// Đã hoàn thành.
        /// </summary>
        Completed = 2,
    }

    /// <summary>
    /// Nằm trong gói 44301.
    /// </summary>
    public class TaskInfo {
        /// <summary>
        /// ID của nhiêm vụ.
        /// </summary>
        public int Id { get; private set; }

        public TaskState State { get; private set; }

        public static TaskInfo Parse(JToken token) {
            var result = new TaskInfo();
            result.Id = (int) token["id"];
            result.State = (TaskState) (int) token["status"];
            return result;
        }
    }
}
