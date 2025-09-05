using System;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.DTO;

namespace WindowsFormsApp1.DAL
{
    public class GiaoCaDAL
    {
        private string connectionString = DatabaseConnection.ConnectionString;

        public int LuuGiaoCa(GiaoCaDTO giaoCa)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"INSERT INTO GiaoCa (NhanVienID, ThoiGianBatDau, ThoiGianKetThuc, TongSoHoaDon, TongDoanhThu, TienMatThucTe, ChenhLech, GhiChu)
                               VALUES (@NhanVienID, @ThoiGianBatDau, @ThoiGianKetThuc, @TongSoHoaDon, @TongDoanhThu, @TienMatThucTe, @ChenhLech, @GhiChu);
                               SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NhanVienID", giaoCa.NhanVienID);
                cmd.Parameters.AddWithValue("@ThoiGianBatDau", giaoCa.ThoiGianBatDau);
                cmd.Parameters.AddWithValue("@ThoiGianKetThuc", giaoCa.ThoiGianKetThuc);
                cmd.Parameters.AddWithValue("@TongSoHoaDon", giaoCa.TongSoHoaDon);
                cmd.Parameters.AddWithValue("@TongDoanhThu", giaoCa.TongDoanhThu);
                cmd.Parameters.AddWithValue("@TienMatThucTe", giaoCa.TienMatThucTe);
                cmd.Parameters.AddWithValue("@ChenhLech", giaoCa.ChenhLech);
                cmd.Parameters.AddWithValue("@GhiChu", (object)giaoCa.GhiChu ?? DBNull.Value);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}