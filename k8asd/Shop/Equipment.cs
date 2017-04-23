using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public enum EquipmentQuality {
        /// <summary>
        /// Đồ trắng, mua trong của tiệm cũng có.
        /// </summary>
        Trang = 1,

        /// <summary>
        /// Đồ lục.
        /// </summary>
        Luc = 2,

        /// <summary>
        /// Đồ xanh.
        /// </summary>
        Xanh = 3,

        /// <summary>
        /// Đồ vàng.
        /// </summary>
        Vang = 4,

        /// <summary>
        /// Đồ dỏ.
        /// </summary>
        Do = 5,

        /// <summary>
        /// Đồ tím.
        /// </summary>
        Tim = 6,

        /// <summary>
        /// Đồ cam.
        /// </summary>
        Cam = 7,

        /// <summary>
        /// Đồ hồng.
        /// </summary>
        Hong = 8
    }

    public class Equipment {
        public int Id { get; private set; }

        public EquipmentQuality Quality { get; private set; }

        public static Equipment Parse(JToken token) {
            var result = new Equipment();
            result.Id = (int) token["storeid"];
            result.Quality = (EquipmentQuality) (int) token["quality"];
            return result;
        }
    }
}
