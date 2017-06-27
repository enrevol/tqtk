using Newtonsoft.Json.Linq;

namespace k8asd {
    public class ArenaPlayer {
        /// <summary>
        /// Cấp độ phần thưởng, ví dụ: 2k bạc là lv1, 15k bạc là lv4.
        /// </summary>
        private int awardLevel;

        /// <summary>
        /// Tên phần thưởng, ví dụ: bạc, lúa, lượt.
        /// </summary>
        private string awardName;

        /// <summary>
        /// Số lượng tương ứng của phần thưởng, ví dụ: 15k bạc thì là 15k.
        /// </summary>
        private int awardnum;

        /// <summary>
        /// ???
        /// </summary>
        private int cascadeRewards;

        /// <summary>
        /// Thời gian còn lại để nhận phần thưởng.
        /// </summary>
        private int countDownRemain;

        /// <summary>
        /// Hạng.
        /// </summary>
        public int Rank { get; private set; }

        /// <summary>
        /// Hạng cao nhất (chỉ đúng với người chơi hiện tại; người chơi khác có giá trị bằng 0).
        /// </summary>
        public int TopRank { get; private set; }

        /// <summary>
        /// Liên thắng hiện tại (chỉ đúng với người chơi hiện tại; người chơi khác có giá trị bằng 0).
        /// </summary>
        public int Cascade { get; private set; }

        /// <summary>
        /// Liên thắng cao nhất.
        /// </summary>
        public int TopCascade { get; private set; }

        /// <summary>
        /// Lượt đánh còn lại (chỉ đúng với người chơi hiện tại; người chơi khác có giá trị bằng 0).
        /// </summary>
        public int RemainTimes { get; private set; }

        /// <summary>
        /// ID người chơi.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Tên người chơi.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Cấp độ người chơi.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Quốc gia.
        /// </summary>
        public string Nation { get; private set; }

        public static ArenaPlayer Parse(JToken token) {
            var result = new ArenaPlayer();
            result.awardLevel = (int) token["awardLevel"];
            result.awardName = (string) token["awardName"];
            result.awardnum = (int) token["awardnum"];
            result.Cascade = (int) token["cascade"];
            result.cascadeRewards = (int) token["cascadeRewards"];
            result.countDownRemain = (int) token["countDownRemain"];
            result.Level = (int) token["level"];
            result.Nation = (string) token["nation"];
            result.Id = (long) token["playerId"];
            result.Name = (string) token["playerName"];
            result.Rank = (int) token["rank"];
            result.RemainTimes = (int) token["remainTimes"];
            result.TopCascade = (int) token["topestCascade"];
            result.TopRank = (int) token["topestRank"];
            return result;
        }
    }
}
