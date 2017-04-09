using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Thuộc gói tin 41100.
    /// </summary>
    public class Hero {
        private int trainFlag;
        private int trainModel;
        private Cooldown trainCooldown;

        /// <summary>
        /// ID của tướng.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Tên tướng.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Cấp độ của tướng.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Kinh nghiệm hiện tại của tướng.
        /// </summary>
        public int Exp { get; private set; }

        /// <summary>
        /// Tổng kinh nghiệm cần của cấp độ hiện tại.
        /// </summary>
        public int NextExp { get; private set; }

        /// <summary>
        /// Tướng có đang trong trạng thái huấn luyện không?
        /// </summary>
        public bool IsTraining {
            get { return RemainingTime > 0; }
        }

        /// <summary>
        /// Thời gian huấn luyện còn lại (mi-li-giây).
        /// </summary>
        public int RemainingTime {
            get {
                if (trainFlag == 0) {
                    return 0;
                }
                return trainCooldown.RemainingMilliseconds;
            }
        }

        /// <summary>
        /// Kinh nghiệm huấn luyện mối phút.
        /// </summary>
        public int ExpPerMin { get; private set; }

        /// <summary>
        /// Chiến tích cần cho mỗi lần mãnh tiến.
        /// </summary>
        public int HonorCost { get; private set; }

        /// <summary>
        /// Kinh nghiệm đạt được cho mỗi lần mãnh tiến.
        /// </summary>
        public int HonorExp { get; private set; }

        public static Hero Parse(JToken token) {
            var result = new Hero();
            result.Id = (int) token["generalid"];
            result.Name = (string) token["generalname"];
            result.Level = (int) token["generallevel"];
            result.Exp = (int) token["generalexp"];
            result.NextExp = (int) token["nextlevelexp"];
            result.trainFlag = (int) token["trainflag"];
            if (result.trainFlag == 0) {
                result.trainCooldown = new Cooldown();
                result.trainModel = result.ExpPerMin = result.HonorCost = result.HonorExp = 0;
            } else {
                result.trainModel = (int) token["trainmodel"];
                result.trainCooldown = new Cooldown((int) token["remainingtime"]);
                result.ExpPerMin = (int) token["exppermin"];
                result.HonorCost = (int) token["jyungong"];
                result.HonorExp = (int) token["jyungongexp"];
            }
            return result;
        }
    }
}
