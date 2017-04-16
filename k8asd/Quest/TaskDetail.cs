using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd.Quest {
    /// <summary>
    /// Dịch gói 44201.
    /// </summary>
    public class TaskDetail {
        public bool CanReceived { get; private set; }

        /// <summary>
        /// Số sao.
        /// </summary>
        public int Quality { get; private set; }

        public int Type { get; private set; }

        /// <summary>
        /// Tên nhiệm vụ.
        /// </summary>
        public string Name { get; private set; }

        public static TaskDetail Parse(JToken token) {
            var result = new TaskDetail();
            result.CanReceived = (bool) token["canrecive"];

            var taskdto = token["taskdto"];
            result.Quality = (int) taskdto["quality"];
            result.Type = (int) taskdto["type"];
            result.Name = (string) taskdto["name"];
            return result;
        }
    }
}
