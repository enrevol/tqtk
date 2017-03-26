using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace k8asd {
    public enum Merchant {
        LauLan = 1,
        TayVuc = 2,
        BaThuc = 3,
        DaiLy = 4,
        ManNam = 5,
        LieuDong = 6,
        QuanDong = 7,
        HoaiNam = 8,
        KinhSo = 9,
        NamViet = 10,
        TamDuong = 11,
        LinhNam = 12,
    }

    /// <summary>
    /// Dịch gói tin 43201.
    /// </summary>
    class MerchantInfo {
        public Merchant OwnedMerchant { get; private set; }
        public List<Merchant> Merchants { get; private set; }

        public static MerchantInfo Parse(JToken token) {
            var defMerchantId = (int) token["defMerchantId"];
            if (defMerchantId == 0) {
                return null;
            }
            var result = new MerchantInfo();
            result.OwnedMerchant = (Merchant) defMerchantId;

            var merchants = new List<Merchant>();
            foreach (var subToken in token["merchantIds"]) {
                merchants.Add((Merchant) (int) subToken);
            }
            result.Merchants = merchants;
            return result;
        }
    }
}
