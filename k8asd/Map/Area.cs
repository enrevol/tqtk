using Newtonsoft.Json.Linq;

namespace k8asd {
    enum Nation {
        Nguy = 1,
        Thuc = 2,
        Ngo = 3,
    };

    /// <summary>
    /// Trong gói tin 30100.
    /// </summary>
    class Area {
        /// <summary>
        /// ID của khu vực.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Tên khu vực.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Giá dệt.
        /// </summary>
        public int Price { get; private set; }

        /// <summary>
        /// Đẳng cấp tối đa trong khu vực.
        /// </summary>
        public int MaxLevel { get; private set; }

        /// <summary>
        /// ???
        /// </summary>
        public bool IsSameLevel { get; private set; }

        /// <summary>
        /// Có thuộc quốc gia mình không? (không thể xâm chiếm).
        /// </summary>
        public bool IsSelfArea { get; private set; }

        /// <summary>
        /// Có vào (xem) được không?
        /// </summary>
        public bool Enterable { get; private set; }

        /// <summary>
        /// Có di chuyển đến được không?
        /// </summary>
        public bool Transferable { get; private set; }

        /// <summary>
        /// Quốc gia.
        /// </summary>
        public Nation Nation { get; private set; }

        public static Area Parse(JToken token) {
            var result = new Area();
            result.Id = (int) token["areaid"];
            result.Name = (string) token["areaname"];
            result.Price = (int) token["areaprice"];
            result.MaxLevel = (int) token["maxlevel"];
            result.Nation = (Nation) (int) token["nation"];
            result.IsSameLevel = (bool) token["issamelevel"];
            result.IsSelfArea = (bool) token["isselfarea"];
            result.Transferable = (bool) token["transferable"];
            return result;
        }
    }
}
