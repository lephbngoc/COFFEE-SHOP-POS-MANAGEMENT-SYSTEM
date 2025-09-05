using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class HoaDonDTO
    {
        public int HoaDonID { get; set; }
        public string MaHoaDon { get; set; }
        public DateTime NgayGio { get; set; }
        public int? KhachHangID { get; set; }
        public int? BuzzerID { get; set; }
        public float GiamGia { get; set; }
        public decimal TongTien { get; set; }
        public int NhanVienID { get; set; }
        public string GhiChu { get; set; }
        public int? KhuyenMaiID { get; set; }
    }
}
