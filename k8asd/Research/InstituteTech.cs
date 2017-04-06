using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k8asd {
    public class InstituteTech {
        public int Id { get; private set; }

        /// <summary>
        /// Tinh thông công, tinh thông chiến pháp, ...
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Công, công phép, ...
        /// </summary>
        public string Desc { get; private set; }

        /// <summary>
        /// Tăng sức mạnh tấn công phổ thông...
        /// </summary>
        public string Intro { get; private set; }

        /// <summary>
        /// Phần hiệu quả cộng thêm do nâng cấp tinh thông.
        /// </summary>
        public int Extra { get; private set; }

        /// <summary>
        /// Giá trị cải tiến hiện tại.
        /// </summary>
        public int Value { get; private set; }

        /// <summary>
        /// Gía trị cải tiến làm mới (chưa làm mới thì bằng 0).
        /// </summary>
        public int NewValue { get; private set; }

        /// <summary>
        /// Đơn vị, ví dụ tỷ lệ tránh né là "%".
        /// </summary>
        public string ValueUnit { get; private set; }

        /// <summary>
        /// Có thể nâng cấp được không?
        /// </summary>
        public bool IsUp { get; private set; }

        /// <summary>
        /// Lượng chiến tích cần thiết để lên cấp kế.
        /// </summary>
        public int Progress { get; private set; }

        /// <summary>
        /// Đẳng cấp hiện tại.
        /// </summary>
        public int Level { get; private set; }

        public static InstituteTech Parse(JToken token) {
            var result = new InstituteTech();
            result.Desc = (string) token["desc"];
            result.Extra = (int) token["extra"];
            result.Intro = (string) token["intro"];
            result.IsUp = (bool) token["isup"];
            result.Level = (int) token["level"];
            result.NewValue = (int) token["newvalue"];
            result.Progress = (int) token["progress"];
            result.Id = (int) token["techId"];
            result.Name = (string) token["techName"];
            result.Value = (int) token["value"];
            result.ValueUnit = (string) token["valueUnit"];
            return result;
        }
    }
}
