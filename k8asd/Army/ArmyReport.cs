using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    /// <summary>
    /// Dịch gói tin 34108.
    /// </summary>
    class ArmyReport {
        /// <summary>
        /// Thông tin đội hình ban đầu.
        /// </summary>
        private string init;

        /// <summary>
        /// ???
        /// </summary>
        private string describe;

        /// <summary>
        /// Thực ra là detailreport trong fieldreport.
        /// </summary>
        public List<string> Reports { get; private set; }

        public string Gains { get; private set; }

        public static ArmyReport Parse(JToken token) {
            var result = new ArmyReport();

            var battlereport = token["battlereport"];
            result.init = (string) battlereport["init"];

            var report = battlereport["report"];
            result.describe = (string) report["describe"];

            var reports = new List<string>();
            var fieldreport = report["fieldreport"];
            foreach (var subToken in fieldreport) {
                var detailreport = subToken["detailreport"];
                foreach (var subSubToken in detailreport) {
                    reports.Add((string) subSubToken);
                }
            }
            result.Reports = reports;

            result.Gains = (string) report["gains"];
            return result;
        }
    }
}
