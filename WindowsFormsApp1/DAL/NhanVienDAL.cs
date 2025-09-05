using System;
using System.Data.SqlClient;
using System.Data;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class NhanVienDAL
    {
        private string connectionString = DatabaseConnection.ConnectionString;

        public NhanVienDTO DangNhap(string maNV, string matKhau)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM NhanVien WHERE MaNhanVien = @MaNV AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new NhanVienDTO
                        {
                            NhanVienID = reader["NhanVienID"] != DBNull.Value ? Convert.ToInt32(reader["NhanVienID"]) : (int?)null,
                            MaNhanVien = reader["MaNhanVien"].ToString(),
                            TenNhanVien = reader["TenNhanVien"].ToString(),
                            MatKhau = reader["MatKhau"].ToString(),
                            VaiTro = reader["VaiTro"].ToString(),
                            TrangThai = reader["TrangThai"] != DBNull.Value && Convert.ToBoolean(reader["TrangThai"])
                        };
                    }
                }
            }
            return null;
        }

        public DataTable GetAllNhanVien()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_LayDanhSachNhanVien", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool ThemNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // 1. Thêm nhân viên mới, KHÔNG truyền MaNhanVien
                string sql = "INSERT INTO NhanVien (TenNhanVien, MatKhau, VaiTro, TrangThai) " +
                             "VALUES (@TenNV, @MatKhau, @VaiTro, @TrangThai); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@TenNV", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
                cmd.Parameters.AddWithValue("@VaiTro", nv.VaiTro);
                cmd.Parameters.AddWithValue("@TrangThai", nv.TrangThai);
                conn.Open();
                int newId = Convert.ToInt32(cmd.ExecuteScalar());

                // 2. Cập nhật MaNhanVien = 'NV' + NhanVienID
                string sqlUpdate = "UPDATE NhanVien SET MaNhanVien = @MaNV WHERE NhanVienID = @ID";
                SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
                cmdUpdate.Parameters.AddWithValue("@MaNV", "NV" + newId);
                cmdUpdate.Parameters.AddWithValue("@ID", newId);
                cmdUpdate.ExecuteNonQuery();

                return true;
            }
        }

        public bool SuaNhanVien(NhanVienDTO nv)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SuaNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    // BỔ SUNG DÒNG NÀY:
                    cmd.Parameters.AddWithValue("@NhanVienID", nv.NhanVienID);
                    cmd.Parameters.AddWithValue("@TenNhanVien", nv.TenNhanVien);
                    cmd.Parameters.AddWithValue("@MatKhau", nv.MatKhau);
                    cmd.Parameters.AddWithValue("@VaiTro", nv.VaiTro);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi sửa nhân viên: " + ex.Message);
                }
            }
        }

        public bool XoaNhanVien(int nhanVienID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_XoaNhanVien", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi xóa nhân viên: " + ex.Message);
                }
            }
        }

        public string TaoMaNhanVienTuDong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT ISNULL(MAX(RIGHT(MaNhanVien, 3)), 0) FROM NhanVien";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int maxNumber = Convert.ToInt32(cmd.ExecuteScalar());
                return "NV" + (maxNumber + 1).ToString("D3");
            }
        }

    
            }
        }