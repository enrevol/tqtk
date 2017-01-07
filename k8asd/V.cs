using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace k8asd
{
    public static class V
    {        
        public static Color[] listcolorchat = 
        {
            Color.OrangeRed,
            Color.Gold,
            Color.FromArgb(90, 200, 90),
            Color.FromArgb(113, 222, 227),
            Color.FromArgb(90, 90, 200),
            Color.YellowGreen,
            Color.White
        };

        public static TimeSpan[] listtimerefresh =
        {
            new TimeSpan(8, 30, 0),
            new TimeSpan(12, 30, 0),
            new TimeSpan(19, 0, 0),
            new TimeSpan(21, 0, 0)
        };

        public static int[] listcampid = { 1, 2, 3, 5, 7, 8, 9, 10 };
        public static int[] attribredirect = { 0, 1, 2, 3, 5, 4, 7, 6 };

        public static string[] listimposeprior = { "Bạc", "Dân tâm", "Uy danh", "Xu" };
        public static string[] listchat = { "Mật", "Thế giới", "Quốc gia", "Khu vực", "Bang", "Chiến", "Tất cả" };
        public static string[] listarmymode = { "Chỉ lập tổ đội", "Chỉ gia nhập", "Gia nhập và lập tổ đội" };
        public static string[] listweavemode = { "Chỉ lập tổ đội", "Chỉ gia nhập", "Lập tổ đội (bug)" };
        public static string[] listnation = { "Không", "Nguỵ", "Thục", "Ngô" };
        public static string[] listseason = { "Xuân", "Hạ", "Thu", "Đông" };
        public static string[] listatt = { "Dũng", "Kỹ", "Trí" };
        public static string[] listcamprank = { "Kết thúc", "Lính lác", "Tân binh", "Nguyên Soái", "Thần Tướng" };
        public static string[] listattribute = { "Công", "Thủ", "Công phép", "Công mưu", "Thủ phép", "Lính", "Thủ mưu" };
        public static string[] listbindstatus = { "Khoá", "Mở khoá", "Huỷ" };
        public static string[] listequiptype = { "Toàn bộ", "Vũ khí", "Giáp", "Chiến mã", "Phi phong", "Sách", "Nón", "Ấn" };
        public static string[] listcamp =   
        {     
            "Giang Hạ Chi Chiến",
            "Phù Thủy Chi Chiến",
            "Tây Lương Chi Chiến",
            "Thất Cầm Mạch Hoạch",
            "Quan Độ Chi Chiến",
            "Hổ Lao Chi Chiến",
            "Binh Lâm Thành Hạ",
            "Hãn Dũng Vô Song"
        };
        public static string[] arrow = { "↓", "↑" };
        public static string[] arrow4 = { "◄", "▲", "►", "▼" };
        public static string[] server =
        {
            "s1 - Xích Bích",
            "s2 - Trường Bản",
            "s3 - Hoa Dung",
            "s4 - Tân Dã",
            "s5 - Hổ Lao",
            "s6 - Di Lăng",
            "s8 - Quan Độ", 
            "s9 - Hào Đình",
            "s10 - Hợp Phì",
            "s11 - Bác Vọng",
            "s12 - Hán Trung",
            "s14 - Tương Dương",
            "s15 - Kí Thành",
            "s16 - Hạ Bì",
            "s18 - Tà Cốc",
            "s19 - Nhai Đình",
            "s20 - Vị Thuỷ",
            "s21 - Diên Tân",
            "s22 - Định Quân",
            "s23 - Ô Sào",
            "s25 - Hứa Xương",
            "s26 - Bạch Mã",
            "s28 - Đông Lĩnh",
            "s29 - Tây Xuyên",
            "s30 - Hứa Đô",
            "s31 - Thổ San",
            "s32 - Kiến Nghiệp",
            "s33 - Nam Tử",
            "s35 - Thượng Phương",
            "s36 - Phàn Thành",
            "s38 - Trường Giang",
            "s39 - Kỳ Sơn",
            "s40 - Đồng Quan",
            "s41 - Kinh Châu",
            "s42 - Trác Quân",
            "s43 - Hoài Nam",
            "s45 - Tứ Linh",
            "s46 - Miên Trúc",
            "s48 - Kiếm Các",
            "s49 - Phong Vũ",
            "s50 - Dương Đô"
        };

        public static string[][] listimposequest =
        {
            #region sCopper
            new string[]
            {
                "Vô cùng phẫn nộ",
                "Kiên nhẫn ngồi thẩm vấn từng người",
                "Đề phòng bất trắc",
                "Thích khách bị bắt",
                "Không sinh cùng nhau nhưng nguyện chết cùng nhau",
                "Thể hiện sự khoan dung",
                "Đại cục làm trọng",
                "Phát triển công thương",
                "Kêu gọi đóng góp để cứu trợ",
                "Năng tình đồng hương",
                "Huy động tiền khắp nơi để mở vùng đất mới",
                "Mau chóng nâng cao thuế suất",
                "Bắt ông ta chuyển công trình đến nơi khác",
                "Buồn cười ! Sao hắn không tự đoán",
                "Nhanh chóng lên đường đi tìm trăn để ngâm rượu",
                "Thu họ vào làm quân lính",
                "Từ chối vì họ có thể là gián điệp",
                "Truy bắt người đó",
                "Chấp nhận họ",
                "Con người tự tạo nên số phận mình",
                "Ắt có nội tình",
                "Cũng là một ý hay, điều thêm dân",
                "Khai đình thụ thẩm",
                "Nặng tình đồng hương, vương pháp khai ân"
            },
            #endregion

            #region sLoyalty
            new string[] 
            {
                "Vô cùng phẫn nộ",
                "Kiên nhẫn ngồi thẩm vấn từng người",
                "Đề phòng bất trắc",
                "Lập đền thờ tại vùng đất",
                "Ngự giá xuất chinh",
                "Thân chinh cùng dân",
                "Không sinh cùng nhau nhưng nguyện chết cùng nhau",
                "Tính tình ngay thẳng, cương quyết chống lại",
                "Kĩ năng thì quan trọng hơn là sự tự tin",
                "Xử theo luật",
                "Lấy dân làm gốc",
                "Điều dân khai hoang",
                "Mạng người đáng quí",
                "Bái Nguyệt Thần Giáo",
                "Cảm thông cho các nạn dân",
                "Tập tục của thôn nhỏ",
                "Bình đẳng chấp pháp",
                "Sửa chữa nhà cửa giúp dân",
                "Vui cùng dân",
                "Ngăn chặn tin đồn",
                "Thấy nhân dân vui vẻ",
                "Cúi đầu kính cẩn",
                "Khai đình thu thẩm, điều tra rõ ràng",
                "Cũng là 1 ý hay, điều thêm dân",
                "Cùng nhân dân đi ngắm mưa sau băng",
                "Nâng cao trình độ kiến thức của người dân",
                "Trừng phạt hắn ta và phát triển điều kiện thương mại",
                "Tôn thờ nó như 1 vị thánh",
                "Dân nào cũng là dân",
                "Thiên tai là do trời, lập bàn thờ thiên địa",
                "Tên này chắc là đặc biệt lắm đây",
                "Chấp nhận họ làm dân chúng của mình",
                "Dân là gốc",
                "Từ chối vì họ có thể là gián điệp",
                "Sai dân đi dò hỏi",
                "Tự tay sửa chữa",
                "Thương cảm",
                "Chấp nhận 1 cách vui vẻ",
                "Nhà văn thì chỉ là nhà văn",
                "Tranh đấu với hổ dữ",
                "Từ chối",
                "Số mệnh do trời ban",
                "điều binh cứu hỏa",
                "Tự tin là điều tốt",
                "Con người tự tạo nên số phận mình",
                "Ắt có nội tình",
                "Cũng là một ý hay, điều thêm dân",
                "Khai đình thụ thẩm",
                "Bình đẳng chấp pháp, áp giải lên công đường",
                "Đề phòng bất trắc, thay đổi đường đi",
                "Thân chinh cùng dân đi tu sửa đê",
                "Số mệnh do trời",
                "Cùng dân thưởng thức mưa sao băng",
                "Mạng người đáng quý",
                "Phong quan tiến chức",
                "Phong làm quốc thú",
                "Tế đường là của gia tộc",
                "Vui vẻ nhận lời",
                "Hiện tượng lạ",
                "Thương cảm trước sự khổ cực",
                "Tế lễ và hỏi thăm",
                "Đã là số mệnh",
                "Thiết yến tiệc đối đãi",
                "Cùng thưởng nguyệt"
            },
            #endregion

            #region sPrestige
            new string[]
            {
                "Thà Giết Nhầm trăm người còn hơn bỏ sót 1 người",
                "Tương kế tựu kế",
                "Phái quân cứu trợ",
                "Chinh chiến bận rộn, kêu gọi nhân dân đi hộ đê",
                "Tính tình ngay thẳng, cương quyết chống lại",
                "Có tự tin thì làm gì cũng được",
                "Quân pháp lấy uy làm trọng",
                "Vốn tính ham học hỏi, đi lại thỉnh giáo",
                "Xuất binh dương uy",
                "Thu thuế hăn ta cao hơn",
                "Bắt nó làm thú cưỡi",
                "Quốc uy làm trọng",
                "Con trăn quá nguy hiểm không nên tấn công, vạn vật tự sinh tự diệt",
                "An toàn là trên hết",
                "Đối đãi với hắn ta tử tế",
                "Chấp nhận hộ và cho gia nhập quân đội",
                "Nhờ người dân sữa chữa",
                "Vô cùng tức giận",
                "Từ chối và chỉ gửi quà đến",
                "Nhà văn thì chỉ là nhà văn",
                "Hổ dữ báo thù trời đất còn phải né",
                "Bảo vệ tài sản",
                "Tình hình cấp bách, kêu gọi dân cứ hỏa",
                "Một nước không nên có nhìu đạo giáo",
                "Thuận theo thiên mệnh",
                "Quân pháp lấy quân uy làm trọng",
                "Sao băng mang lại may mắn",
                "Nhờ người dân sửa chữa"
            },
            #endregion

            #region sSysGold
            new string[] 
            {
                "Chắc chắn sẽ có",
                "Di chuyển dân cư",
                "Tập tục của thôn nhỏ không cần để ý",
                "Hạn chế sự xâm nhập của văn hoá phương tây",
                "Thấy nhân dân vui vẻ",
                "Tôn thờ nó như 1 vị thánh",
                "Buồn cười ! Sao hắn không tự đoán",
                "Ngân khố đang thiếu thốn,tạm hứa với hắn ta",
                "Chỉ là tên hữu dũng vô mưu",
                "Từ chối vì họ có thể là gián điệp",
                "Hâm mộ anh ta và xin vài ý kiến",
                "Chấp nhận họ",
                "Con người tự tạo nên số phận mình",
                "Đã là số mệnh thì phải thuận theo"
            }
            #endregion
        };
    }
}
