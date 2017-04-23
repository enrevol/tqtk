using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    /// <summary>
    /// Dịch gói 39302.
    /// </summary>
    public class UpgradeResult {
        public bool HasError { get { return ErrorMessage != null; } }

        public string ErrorMessage { get; private set; }

        public string Message { get; private set; }

        public bool Successful { get { return Flag == 0; } }

        /// <summary>
        /// Có bạo kích không? (nâng một lúc 2 cấp)
        /// </summary>
        public bool Critical { get; private set; }

        /// <summary>
        /// ??? 3 = nâng thất bại, 0 = nâng thành công.
        /// </summary>
        public int Flag { get; private set; }

        /// <summary>
        /// Số bạc nhận lại (nếu nâng cấp thất bại).
        /// </summary>
        public int Repay { get; private set; }

        public static UpgradeResult Parse(Packet packet) {
            if (packet.HasError) {
                var result = new UpgradeResult();
                result.ErrorMessage = packet.ErrorMessage;
                return result;
            }

            return Parse(JToken.Parse(packet.Message));
        }

        private static UpgradeResult Parse(JToken token) {
            var result = new UpgradeResult();

            if (token["message"] != null) {
                // "Thất bại! Chúc may mắn lần sau!"
                result.Message = (string) token["message"];
            }

            result.Critical = (bool) token["baoji"];
            result.Flag = (int) token["flag"];

            if (token["replaySilver"] != null) {
                result.Repay = (int) token["replaySilver"];
            }
            return result;
        }
    }
}
