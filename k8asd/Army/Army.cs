using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;

namespace k8asd {
    class Army {
        private bool completed;
        private string intro;

        /// <summary>
        /// ID của NPC.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Cấp độ của NPC.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Tên NPC.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Số lượt đánh còn lại.
        /// </summary>
        public int Limit { get; private set; }

        /// <summary>
        /// Số lượt đánh tối đa.
        /// </summary>
        public int MaxLimit { get; private set; }

        /// <summary>
        /// Có thể tấn công không?
        /// </summary>
        public bool Attackable { get; private set; }

        /// <summary>
        /// Vật phẩm có thể rớt.
        /// </summary>
        public string ItemName { get; private set; }

        /// <summary>
        /// Chiến tích.
        /// </summary>
        public int Honor { get; private set; }

        /// <summary>
        /// Thể loại NPC.
        /// </summary>
        public ArmyType Type { get; private set; }

        public static Army Parse(JToken token) {
            var result = new Army();
            result.Id = (int) token["armyid"];
            result.Level = (int) token["armylevel"];
            result.Name = (string) token["armyname"];
            result.Limit = (int) token["armynum"];
            result.MaxLimit = (int) token["armymaxnum"];
            result.Attackable = (bool) token["attackable"];
            result.completed = (bool) token["complete"];
            result.intro = (string) token["intro"];
            result.ItemName = (string) token["itemname"];
            result.Honor = (int) token["jyungong"];
            var type = (int) token["type"];
            if (type == 1) {
                result.Type = ArmyType.Normal;
            } else if (type == 2) {
                result.Type = ArmyType.Elite;
            } else if (type == 3) {
                result.Type = ArmyType.Hero;
            } else if (type == 5) {
                result.Type = ArmyType.Army;
            } else {
                Debug.Assert(false);
            }
            return result;
        }

        public override string ToString() {
            return String.Format("{0} Lv. {1}", Name, Level);
        }
    }
}
