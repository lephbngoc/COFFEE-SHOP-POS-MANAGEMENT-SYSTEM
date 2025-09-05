using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;


namespace WindowsFormsApp1.DAL
{
    public class KhachHangDAL
    {
        public DataTable GetLoaiKhach()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM dbo.LoaiKhach";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                // Chỉ giữ lại message box lỗi nếu cần
                MessageBox.Show("Lỗi truy vấn dữ liệu: " + ex.Message);
                return null;
            }
        }
        public DataTable TimKhachHang(string soDienThoai)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool ThemKhachHang(KhachHangDTO khachHang)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "INSERT INTO KhachHang (SoDienThoai, TenKhachHang, DiemTichLuy) VALUES (@SoDienThoai, @TenKhachHang, @DiemTichLuy)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                cmd.Parameters.AddWithValue("@DiemTichLuy", khachHang.DiemTichLuy);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public void CapNhatDiemTichLuy(int khachHangID, int diemTang)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE KhachHang SET DiemTichLuy = DiemTichLuy + @DiemTang WHERE KhachHangID = @KhachHangID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@DiemTang", diemTang);
                cmd.Parameters.AddWithValue("@KhachHangID", khachHangID);
                cmd.ExecuteNonQuery();
            }
        }

        public bool SuaKhachHang(KhachHangDTO khachHang)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "UPDATE KhachHang SET TenKhachHang = @TenKhachHang WHERE SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", khachHang.SoDienThoai);
                cmd.Parameters.AddWithValue("@TenKhachHang", khachHang.TenKhachHang);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int LayIDKhachHangMoi(string soDienThoai)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT KhachHangID FROM KhachHang WHERE SoDienThoai = @SoDienThoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}
