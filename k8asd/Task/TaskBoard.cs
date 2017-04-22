using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Dịch gói 44301.
    /// </summary>
    public class TaskBoard {
        /// <summary>
        /// Số lượng nhiêm vụ đã hoàn thành.
        /// </summary>
        public int DoneNum { get; private set; }

        /// <summary>
        /// Số lượng nhiệm vụ tối đa có thể hoàn thành.
        /// </summary>
        public int MaxDoneNum { get; private set; }

        public List<TaskInfo> Tasks { get; private set; }

        public static TaskBoard Parse(JToken token) {
            var result = new TaskBoard();
            result.DoneNum = (int) token["donenum"];
            result.MaxDoneNum = (int) token["maxdonenum"];

            var tasks = new List<TaskInfo>();
            var taskbasedto = token["taskbasedto"];
            foreach (var subToken in taskbasedto) {
                tasks.Add(TaskInfo.Parse(subToken));
            }
            result.Tasks = tasks;

            return result;
        }
    }
}
