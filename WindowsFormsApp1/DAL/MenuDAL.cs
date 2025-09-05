using System;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class MenuDAL
    {
        private string connectionString;

        // Constructor nhận connection string
        public MenuDAL(string conn)
        {
            connectionString = conn;
        }

        // Constructor mặc định
        public MenuDAL()
        {
            connectionString = DatabaseConnection.ConnectionString;
        }

        // Lấy toàn bộ menu (dùng stored procedure nếu có)
        public DataTable GetAllMenu()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_LayDanhSachMenu", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy món theo ID
        public DataTable GetMonByID(int monID)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Mon WHERE MonID = @MonID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MonID", monID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy món theo tên
        public DataTable GetMonByName(string tenMon)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM Mon WHERE TenMon = @TenMon";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy danh sách món theo nhóm
        public DataTable GetMonByNhomID(int nhomMonID)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT MonID, TenMon FROM Mon WHERE NhomMonID = @NhomMonID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NhomMonID", nhomMonID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lấy danh sách nhóm món
        public DataTable GetNhomMon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT NhomMonID, TenNhom FROM NhomMon";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Thêm món mới (dùng stored procedure)
        public bool ThemMon(MenuItemDTO mon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_ThemMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenMon", mon.TenMon);
                cmd.Parameters.AddWithValue("@DonGia", mon.DonGia);
                cmd.Parameters.AddWithValue("@NhomMonID", mon.NhomMonID);
                cmd.Parameters.AddWithValue("@HangTon", mon.HangTon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Sửa món (dùng stored procedure)
        public bool SuaMon(MenuItemDTO mon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_SuaMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MonID", mon.MonID);
                cmd.Parameters.AddWithValue("@TenMon", mon.TenMon);
                cmd.Parameters.AddWithValue("@DonGia", mon.DonGia);
                cmd.Parameters.AddWithValue("@NhomMonID", mon.NhomMonID);
                cmd.Parameters.AddWithValue("@HangTon", mon.HangTon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa món (dùng stored procedure)
        public bool XoaMon(int monID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_XoaMon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MonID", monID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy NhomMonID từ tên nhóm
        public int GetNhomMonIDByTenNhom(string tenNhom)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT NhomMonID FROM NhomMon WHERE TenNhom = @TenNhom";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenNhom", tenNhom);
                object result = cmd.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int id))
                    return id;
                else
                    throw new Exception("Không tìm thấy nhóm món với tên: " + tenNhom);
            }
        }

        // Trong MenuDAL
        public bool NhapHang(int monID, int soLuongNhap)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Mon SET HangTon = HangTon + @SoLuongNhap WHERE MonID = @MonID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SoLuongNhap", soLuongNhap);
                cmd.Parameters.AddWithValue("@MonID", monID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public int KiemTraHangTon(int monID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT HangTon FROM Mon WHERE MonID = @MonID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MonID", monID);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public DataTable TimKiemMon(string tenMon, decimal? donGia, int? hangTon, int? nhomMonID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Mon WHERE 1=1";
                if (!string.IsNullOrEmpty(tenMon))
                    sql += " AND TenMon LIKE @TenMon";
                if (donGia.HasValue)
                    sql += " AND DonGia = @DonGia";
                if (hangTon.HasValue)
                    sql += " AND HangTon = @HangTon";
                if (nhomMonID.HasValue)
                    sql += " AND NhomMonID = @NhomMonID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (!string.IsNullOrEmpty(tenMon))
                    cmd.Parameters.AddWithValue("@TenMon", "%" + tenMon + "%");
                if (donGia.HasValue)
                    cmd.Parameters.AddWithValue("@DonGia", donGia.Value);
                if (hangTon.HasValue)
                    cmd.Parameters.AddWithValue("@HangTon", hangTon.Value);
                if (nhomMonID.HasValue)
                    cmd.Parameters.AddWithValue("@NhomMonID", nhomMonID.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        

        public DataTable LayDanhSachMonTonDuoiNguong(int nguongTon)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT MonID, TenMon, HangTon, NhomMonID FROM Mon WHERE HangTon <= @NguongTon";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NguongTon", nguongTon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int GetMonIDByTenMon(string tenMon)
{
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string sql = "SELECT MonID FROM Mon WHERE TenMon = @TenMon";
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@TenMon", tenMon);
        conn.Open();
        object result = cmd.ExecuteScalar();
        return result != null ? Convert.ToInt32(result) : -1;
    }
}
    }
}