using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.DAL
{
    public class KhuyenMaiDAL
    {
        private string connectionString;

        public KhuyenMaiDAL(string conn)
        {
            connectionString = conn;
        }

        public DataTable GetKhuyenMaiDangApDung()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM KhuyenMai WHERE NgayBatDau <= GETDATE() AND NgayKetThuc >= GETDATE()";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}