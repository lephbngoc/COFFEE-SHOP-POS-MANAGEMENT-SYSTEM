using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;

namespace WindowsFormsApp1.BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL hoaDonDAL;
        private MenuDAL menuDAL;

        public HoaDonBLL()
        {
            string connectionString = DatabaseConnection.ConnectionString;
            hoaDonDAL = new HoaDonDAL(connectionString);
            menuDAL = new MenuDAL(connectionString);
        }

        public string TaoMaHoaDon()
        {
            return hoaDonDAL.GenerateOrderID();
        }

        public int LuuHoaDon(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTietList)
        {
            try
            {
                ValidateHoaDon(hoaDon, chiTietList, hoaDon.GiamGia);
                return hoaDonDAL.SaveOrder(hoaDon, chiTietList);
            }
            catch
            {
                throw;
            }
        }

        private void ValidateHoaDon(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTietList, float giamGia)
        {
            if (hoaDon == null)
                throw new Exception("Hóa đơn không được null");

            if (string.IsNullOrEmpty(hoaDon.MaHoaDon))
                throw new Exception("Mã hóa đơn không được trống");

            if (hoaDon.TongTien <= 0)
                throw new Exception("Tổng tiền không hợp lệ");

            if (hoaDon.GiamGia < 0 || hoaDon.GiamGia > 100)
                throw new Exception("Giảm giá phải từ 0 đến 100%");

            if (chiTietList == null || chiTietList.Count == 0)
                throw new Exception("Hóa đơn phải có ít nhất một món");

            foreach (var chiTiet in chiTietList)
            {
                ValidateChiTietHoaDon(chiTiet);
            }

            ValidateTongTien(hoaDon.TongTien, chiTietList, giamGia);
        }

        private void ValidateChiTietHoaDon(ChiTietHoaDonDTO chiTiet)
        {
            if (chiTiet == null)
                throw new Exception("Chi tiết hóa đơn không được null");

            if (chiTiet.MonID <= 0)
                throw new Exception("Mã món không hợp lệ");

            if (chiTiet.SoLuong <= 0)
                throw new Exception("Số lượng phải lớn hơn 0");

            if (chiTiet.ThanhTien <= 0)
                throw new Exception("Thành tiền phải lớn hơn 0");

            if (chiTiet.NhanVienID <= 0)
                throw new Exception("Mã nhân viên không hợp lệ");

            DataTable monInfo = menuDAL.GetMonByID(chiTiet.MonID);
            if (monInfo == null || monInfo.Rows.Count == 0)
                throw new Exception($"Không tìm thấy món có mã {chiTiet.MonID}");
        }

        private void ValidateTongTien(decimal tongTien, List<ChiTietHoaDonDTO> chiTietList, float giamGia)
        {
            decimal tongTienChiTiet = chiTietList.Sum(ct => ct.ThanhTien);
            decimal expected = tongTienChiTiet - (tongTienChiTiet * (decimal)giamGia / 100);
            if (Math.Abs(expected - tongTien) > 1) // cho phép lệch nhỏ do làm tròn
                throw new Exception("Tổng tiền không khớp với chi tiết hóa đơn");
        }

        public void CapNhatHoaDon(int hoaDonID, int khachHangID, decimal tongTien)
        {
            hoaDonDAL.CapNhatHoaDon(hoaDonID, khachHangID, tongTien);
        }

        public DataTable LayDanhSachHoaDon(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            return hoaDonDAL.LayDanhSachHoaDon(tuNgay, denNgay);
        }

        public DataTable LayChiTietHoaDon(int hoaDonID)
        {
            return hoaDonDAL.LayChiTietHoaDon(hoaDonID);
        }

        public DataTable ThongKeDoanhThu(DateTime fromDate, DateTime toDate)
        {
            return hoaDonDAL.ThongKeDoanhThu(fromDate, toDate);
        }
    }
}
