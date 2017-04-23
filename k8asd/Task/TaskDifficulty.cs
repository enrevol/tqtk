using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public static class TaskDifficulty {
        public const int CanNotBeDone = 100;

        public static bool CanDo(int difficulty) {
            return difficulty < CanNotBeDone;
        }

        /// <summary>
        /// Có thể làm được nhiệm vụ mua bán lúa.
        /// </summary>
        public static int FoodOk() {
            return 0;
        }

        /// <summary>
        /// Không thể làm được nhiệm vụ mua bán lúa.
        /// - Bạc tràn kho.
        /// - Lúa tràn kho.
        /// - Hết lượng giao dịch.
        /// </summary>
        /// <returns></returns>
        public static int FoodNotOk() {
            return 10;
        }

        /// <summary>
        /// Có thể làm được nhiệm vụ cải tạo.
        /// </summary>
        public static int ImproveOk() {
            return 1;
        }

        /// <summary>
        /// Không thể làm được nhiêm vụ cải tạo.
        /// - Không đủ chiến tích.
        /// </summary>
        public static int ImproveNotOk() {
            return 11;
        }

        /// <summary>
        /// Có thể làm được nhiệm vụ thu thuế.
        /// </summary>
        /// <param name="times">Số lần làm.</param>
        public static int ImposeOk(int times) {
            // Tăng độ khó vì đóng băng lâu.
            var arr = new int[] { 0, 2, 7, 12, 17, 22, 27, 32 };
            return arr[times];
        }

        /// <summary>
        /// Làm nhiệm vụ thu thuế mà bị tràn bạc.
        /// </summary>
        /// <param name="times">Số làn làm.</param>
        public static int ImposeOverSilver(int times) {
            return ImposeOk(times) + 10;
        }

        /// <summary>
        /// Không thể làm nhiệm vụ thu thuế.
        /// - Hết số lần thu thuế.
        /// </summary>
        public static int ImposeNotOk() {
            return 101;
        }

        /// <summary>
        /// Tấn công NPC.
        /// </summary>
        /// <param name="times">Số lần làm.</param>
        public static int AttackNpcOk(int times) {
            var arr = new int[] { 0, 5, 10, 15, 20, 25, 30 };
            return arr[times];
        }

        /// <summary>
        /// Tấn công NPC mà thiếu lượt.
        /// </summary>
        /// <param name="times">Số lần làm.</param>
        /// <param name="lackTurns">Số lượt bị thiếu.</param>
        public static int AttackNpcLackTurns(int times, int lackTurns) {
            var arr = new int[] { 0, 11, 16, 21, 26, 31, 36 };
            return AttackNpcOk(times - lackTurns) + arr[lackTurns];
        }

        public static int UpgradeOk(int times) {
            var arr = new int[] { 0, 2, 4, 7, 11, 16 };
            return arr[times];
        }

        public static int UpgradeNotOk(int times, int lackTurns) {
            return UpgradeOk(times) + UpgradeOk(lackTurns) * 2;
        }
    }
}
