using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class TaskDifficulty {
        /// <summary>
        /// Độ khó khi có thể làm được nhiệm vụ mua bán lúa.
        /// </summary>
        public static int FoodOk() {
            return 0;
        }

        /// <summary>
        /// Độ khó khi không thể làm được nhiệm vụ mua bán lúa.
        /// - Bạc tràn kho.
        /// - Lúa tràn kho.
        /// - Hết lượng giao dịch.
        /// </summary>
        /// <returns></returns>
        public static int FoodNotOk() {
            return 10;
        }

        /// <summary>
        /// Độ khó khi có thể làm được nhiệm vụ cải tạo.
        /// </summary>
        public static int ImproveOk() {
            return 1;
        }

        /// <summary>
        /// Độ khó khi không thể làm được nhiêm vụ cải tạo.
        /// - Không đủ chiến tích.
        /// </summary>
        public static int ImproveNotOk() {
            return 11;
        }

        /// <summary>
        /// Độ khó khi có thể làm được nhiệm vụ thu thuế.
        /// </summary>
        /// <param name="times">Số lần làm.</param>
        public static int ImposeOk(int times) {
            // Tăng độ khó vì đóng băng lâu.
            var arr = new int[] { 0, 2, 7, 12, 17, 22, 27, 32 };
            return arr[times];
        }

        /// <summary>
        /// Độ khó khi làm nhiệm vụ thu thuế mà bị tràn bạc.
        /// </summary>
        /// <param name="times">Số làn làm.</param>
        public static int ImposeOverSilver(int times) {
            return ImposeOk(times) + 10;
        }

        /// <summary>
        /// Độ khó khi không thể làm nhiệm vụ thu thuế.
        /// - Hết số lần thu thuế.
        /// </summary>
        public static int ImposeNotOk() {
            return 100;
        }
    }
}
