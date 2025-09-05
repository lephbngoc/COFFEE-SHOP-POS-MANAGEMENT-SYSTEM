using System;
using System.Data;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.DAL;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL = new NhanVienDAL();

        public NhanVienDTO DangNhap(string maNV, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(matKhau))
                throw new Exception("Vui lòng nhập đầy đủ thông tin đăng nhập");

            return nhanVienDAL.DangNhap(maNV, matKhau);
        }

        public DataTable GetAllNhanVien()
        {
            return nhanVienDAL.GetAllNhanVien();
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
 

            return nhanVienDAL.ThemNhanVien(nv);
        }

        public bool SuaNhanVien(NhanVienDTO nv)
        {
            if (string.IsNullOrWhiteSpace(nv.TenNhanVien))
                throw new Exception("Tên nhân viên không được để trống");
            if (string.IsNullOrWhiteSpace(nv.MatKhau))
                throw new Exception("Mật khẩu không được để trống");
            if (string.IsNullOrWhiteSpace(nv.VaiTro))
                throw new Exception("Vai trò không được để trống");

            return nhanVienDAL.SuaNhanVien(nv);
           
        }

        public bool XoaNhanVien(int nhanVienID)
        {
            return nhanVienDAL.XoaNhanVien(nhanVienID);
        }

        public string TaoMaNhanVienTuDong()
        {
            return nhanVienDAL.TaoMaNhanVienTuDong();
        }

    }
}