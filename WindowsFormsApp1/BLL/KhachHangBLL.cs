using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;
using System.Data;
using System.Windows.Forms;


namespace WindowsFormsApp1.BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL khachHangDAL;

        public KhachHangBLL()
        {
            khachHangDAL = new KhachHangDAL();
        }

        public DataTable GetLoaiKhach()
        {
            try
            {
                return khachHangDAL.GetLoaiKhach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi BLL: " + ex.Message);
                return null;
            }
        }

        public DataTable TimKhachHang(string soDienThoai)
        {
            return khachHangDAL.TimKhachHang(soDienThoai);
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            return khachHangDAL.ThemKhachHang(khachHang);
        }

        public void CapNhatDiemTichLuy(int khachHangID, int diemTang)
        {
            khachHangDAL.CapNhatDiemTichLuy(khachHangID, diemTang);
        }

        public bool SuaKhachHang(KhachHangDTO khachHang)
        {
            return khachHangDAL.SuaKhachHang(khachHang);
        }

        public int LayIDKhachHangMoi(string soDienThoai)
        {
            return khachHangDAL.LayIDKhachHangMoi(soDienThoai);
        }
    }
}