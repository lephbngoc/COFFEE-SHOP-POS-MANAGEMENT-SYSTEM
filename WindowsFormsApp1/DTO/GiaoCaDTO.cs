using System;
using System.Data;

namespace WindowsFormsApp1.DTO
{
    public class GiaoCaDTO
    {
        public int GiaoCaID { get; set; }
        public int NhanVienID { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public int TongSoHoaDon { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TienMatThucTe { get; set; }
        public decimal ChenhLech { get; set; }
        public string GhiChu { get; set; }
    }
}