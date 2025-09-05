using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class HoaDonDAL
    {
        private string connectionString;

        public HoaDonDAL(string conn)
        {
            connectionString = conn;
        }

        public string GenerateOrderID()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_TaoMaHoaDon", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    return cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tạo mã hóa đơn: " + ex.Message);
            }
        }

        public int SaveOrder(HoaDonDTO hoaDon, List<ChiTietHoaDonDTO> chiTietList)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Thêm hóa đơn
                        SqlCommand cmdHoaDon = new SqlCommand("sp_ThemHoaDon", conn, transaction);
                        cmdHoaDon.CommandType = CommandType.StoredProcedure;
                        cmdHoaDon.Parameters.AddWithValue("@MaHoaDon", hoaDon.MaHoaDon);
                        cmdHoaDon.Parameters.AddWithValue("@KhachHangID", (object)hoaDon.KhachHangID ?? DBNull.Value);
                        cmdHoaDon.Parameters.AddWithValue("@BuzzerID", (object)hoaDon.BuzzerID ?? DBNull.Value);
                        cmdHoaDon.Parameters.AddWithValue("@GiamGia", hoaDon.GiamGia);
                        cmdHoaDon.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                        cmdHoaDon.Parameters.AddWithValue("@NhanVienID", hoaDon.NhanVienID);
                        cmdHoaDon.Parameters.AddWithValue("@GhiChu", (object)hoaDon.GhiChu ?? DBNull.Value);
                        cmdHoaDon.Parameters.AddWithValue("@KhuyenMaiID", (object)hoaDon.KhuyenMaiID ?? DBNull.Value);

                        int hoaDonID = Convert.ToInt32(cmdHoaDon.ExecuteScalar());

                        // 2. Thêm chi tiết hóa đơn
                        foreach (var chiTiet in chiTietList)
                        {
                            SqlCommand cmdChiTiet = new SqlCommand("sp_ThemChiTietHoaDon", conn, transaction);
                            cmdChiTiet.CommandType = CommandType.StoredProcedure;
                            cmdChiTiet.Parameters.AddWithValue("@HoaDonID", hoaDonID);
                            cmdChiTiet.Parameters.AddWithValue("@MonID", chiTiet.MonID);
                            cmdChiTiet.Parameters.AddWithValue("@SoLuong", chiTiet.SoLuong);
                            cmdChiTiet.Parameters.AddWithValue("@ThanhTien", chiTiet.ThanhTien);
                            cmdChiTiet.Parameters.AddWithValue("@NhanVienID", chiTiet.NhanVienID);
                            cmdChiTiet.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return hoaDonID;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Lỗi khi lưu hóa đơn: " + ex.Message);
                    }
                }
            }
        }

        public void CapNhatHoaDon(int hoaDonID, int khachHangID, decimal tongTien)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_CapNhatHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoaDonID", hoaDonID);
                cmd.Parameters.AddWithValue("@KhachHangID", khachHangID);
                cmd.Parameters.AddWithValue("@TongTien", tongTien);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable LayDanhSachHoaDon(DateTime? tuNgay = null, DateTime? denNgay = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayDanhSachHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TuNgay", (object)tuNgay ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DenNgay", (object)denNgay ?? DBNull.Value);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable LayChiTietHoaDon(int hoaDonID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_LayChiTietHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@HoaDonID", hoaDonID);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable ThongKeDoanhThu(DateTime fromDate, DateTime toDate)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                SqlCommand cmd = new SqlCommand("sp_ThongKeDoanhThu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}




