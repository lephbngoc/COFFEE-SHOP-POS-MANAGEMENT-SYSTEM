using System;
using System.Data;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;
using System.Data.SqlClient;


namespace WindowsFormsApp1.BLL
{
    public class MenuBLL
    {
        private MenuDAL dal = new MenuDAL();

        public DataTable GetAllMenu() => dal.GetAllMenu();
        public DataTable GetNhomMon() => dal.GetNhomMon();

        public DataTable GetMonByNhomID(int nhomMonID)
        {
            return dal.GetMonByNhomID(nhomMonID);
        }

        public DataTable GetMonByID(int monID)
        {
            return dal.GetMonByID(monID);
        }

        public DataTable GetMonByName(string tenMon)
        {
            return dal.GetMonByName(tenMon);
        }

        public int GetNhomMonIDByTenNhom(string tenNhom)
        {
            return dal.GetNhomMonIDByTenNhom(tenNhom);
        }

        public bool ThemMon(MenuItemDTO mon)
        {
            if (string.IsNullOrWhiteSpace(mon.TenMon)) throw new Exception("Tên món không được để trống!");
            if (mon.DonGia <= 0) throw new Exception("Đơn giá phải lớn hơn 0!");
            if (mon.HangTon < 0) throw new Exception("Hàng tồn không hợp lệ!");
            return dal.ThemMon(mon);
        }

        public bool SuaMon(MenuItemDTO mon)
        {
            if (mon.MonID <= 0) throw new Exception("Mã món không hợp lệ!");
            return dal.SuaMon(mon);
        }

        public bool XoaMon(int monID)
        {
            if (monID <= 0) throw new Exception("Mã món không hợp lệ!");
            return dal.XoaMon(monID);
        }



        // Nhập hàng (giả sử là cập nhật tồn kho)
        public bool NhapHang(int monID, int soLuongNhap)
        {
            // Bạn cần viết thêm hàm cập nhật tồn kho trong DAL nếu chưa có
            return dal.NhapHang(monID, soLuongNhap);
        }

        // Kiểm tra hàng tồn

        public DataTable GetAllNhomMon()
        {
            return dal.GetNhomMon();
        }

        public DataTable KiemTraHangTon(int nguongTon)
        {
            return dal.LayDanhSachMonTonDuoiNguong(nguongTon);
        }

        public int GetMonIDByTenMon(string tenMon)
        {
            return dal.GetMonIDByTenMon(tenMon);
        }
    }
}