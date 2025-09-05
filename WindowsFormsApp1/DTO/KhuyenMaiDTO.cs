using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class KhuyenMaiDTO
    {
        public int KhuyenMaiID { get; set; }           // Mã khuyến mãi (khóa chính)
        public string TenKhuyenMai { get; set; }       // Tên khuyến mãi
        public float PhanTramGiam { get; set; }        // Phần trăm giảm giá
        public DateTime NgayBatDau { get; set; }       // Ngày bắt đầu áp dụng
        public DateTime NgayKetThuc { get; set; }      // Ngày kết thúc áp dụng
        public string DieuKien { get; set; }           // Điều kiện áp dụng (nếu có)
    }
}
