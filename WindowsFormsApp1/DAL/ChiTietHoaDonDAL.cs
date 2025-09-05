using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class ChiTietHoaDonDAL
    {
        private string connectionString;

        public ChiTietHoaDonDAL(string conn)
        {
            connectionString = conn;
        }

        public DataTable GetChiTietHoaDon(int hoaDonID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_LayThongTinHoaDon", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HoaDonID", hoaDonID);

                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi lấy chi tiết hóa đơn: " + ex.Message);
                }
            }
        }

        public bool ThemChiTietHoaDon(ChiTietHoaDonDTO chiTiet)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_ThemChiTietHoaDon", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@HoaDonID", chiTiet.HoaDonID);
                    cmd.Parameters.AddWithValue("@MonID", chiTiet.MonID);
                    cmd.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                    cmd.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                    cmd.Parameters.AddWithValue("@NhanVienID", chiTiet.NhanVienID);

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi thêm chi tiết hóa đơn: " + ex.Message);
                }
            }
        }
    }
}
