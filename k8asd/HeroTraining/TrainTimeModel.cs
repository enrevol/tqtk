using Newtonsoft.Json.Linq;

namespace k8asd {
    /// <summary>
    /// Kiểu huấn luyện, ví dụ: 20 phút, 2 tiếng, 8 tiếng.
    /// </summary>
    class TrainTimeModel {
        public int Id { get; private set; }
        public int Time { get; private set; }
        public string TimeUnit { get; private set; }
        public string Cost { get; private set; }

        public static TrainTimeModel Parse(JToken token) {
            var result = new TrainTimeModel();
            result.Id = (int) token["id"];
            result.Time = (int) token["time"];
            result.TimeUnit = (string) token["timeunit"];
            result.Cost = (string) token["cost"];
            return result;
        }
    }
}
