using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public enum TaskType {
        /// <summary>
        /// Mua bán lúa.
        /// </summary>
        Food,

        /// <summary>
        /// Cải tiến.
        /// </summary>
        Improve,

        /// <summary>
        /// Thu thuế.
        /// </summary>
        Impose,

        /// <summary>
        /// Sử dụng xu.
        /// </summary>
        Gold,

        /// <summary>
        /// Chinh chiến.
        /// </summary>
        AttackNpc,

        /// <summary>
        /// Nâng cấp trang bị.
        /// </summary>
        Upgrade,

        /// <summary>
        /// Loại khác không cần quan tâm.
        /// </summary>
        Other,
    }

    /// <summary>
    /// Dịch gói 44201.
    /// </summary>
    public class TaskDetail {
        public bool CanReceived { get; private set; }

        /// <summary>
        /// Số sao.
        /// </summary>
        public int Quality { get; private set; }

        /// <summary>
        /// Số lần đã hoàn thành.
        /// </summary>
        public int DoneNum { get; private set; }

        /// <summary>
        /// Tên nhiệm vụ.
        /// </summary>
        public string Name { get; private set; }

        public TaskType Type { get; private set; }

        public static TaskDetail Parse(JToken token) {
            var result = new TaskDetail();
            result.CanReceived = (bool) token["canrecive"];

            var taskdto = token["taskdto"];
            result.Quality = (int) taskdto["quality"];
            // result.Type = (int) taskdto["type"]; ???
            result.Name = (string) taskdto["name"];
            result.DoneNum = (int) taskdto["num"];

            var type = TaskType.Other;
            if (result.Name == "Mua bán lúa") {
                type = TaskType.Food;
            } else if (result.Name == "Cải tạo") {
                type = TaskType.Improve;
            } else if (result.Name == "Thu Thuế") {
                type = TaskType.Impose;
            } else if (result.Name == "Sử dụng Xu") {
                type = TaskType.Gold;
            } else if (result.Name == "Chinh chiến") {
                type = TaskType.AttackNpc;
            } else if (result.Name == "Nâng cấp trang bị") {
                type = TaskType.Upgrade;
            }
            result.Type = type;

            return result;
        }
    }
}
