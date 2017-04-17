using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    public class TaskBoard {
        /// <summary>
        /// Số lượng nhiêm vụ đã hoàn thành.
        /// </summary>
        public int DoneNum { get; private set; }

        /// <summary>
        /// Số lượng nhiệm vụ tối đa có thể hoàn thành.
        /// </summary>
        public int MaxDoneNum { get; private set; }

        public List<int> TaskIds { get; private set; }

        public static TaskBoard Parse(JToken token) {
            var result = new TaskBoard();
            result.DoneNum = (int) token["donenum"];
            result.MaxDoneNum = (int) token["maxdonenum"];

            var taskIds = new List<int>();
            var taskbasedto = token["taskbasedto"];
            foreach (var subToken in taskbasedto) {
                var id = (int) subToken["id"];
                taskIds.Add(id);
            }
            result.TaskIds = taskIds;

            return result;
        }
    }
}
