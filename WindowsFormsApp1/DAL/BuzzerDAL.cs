using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace WindowsFormsApp1.DAL
{
    public class BuzzerDAL
    {
        private string connectionString;

        public BuzzerDAL(string conn)
        {
            connectionString = conn;
        }

        public DataTable GetBuzzer()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT BuzzerID, SoBuzzer FROM Buzzer";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi lấy danh sách buzzer: " + ex.Message);
                }
            }
        }

        public DataTable GetAvailableBuzzer()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT BuzzerID, SoBuzzer FROM Buzzer WHERE TrangThai = 0";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi lấy danh sách buzzer trống: " + ex.Message);
                }
            }
        }

        public bool UpdateStatus(int buzzerID, bool isUsing)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE Buzzer SET TrangThai = @TrangThai WHERE BuzzerID = @BuzzerID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TrangThai", isUsing);
                    cmd.Parameters.AddWithValue("@BuzzerID", buzzerID);
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi cập nhật trạng thái buzzer: " + ex.Message);
                }
            }
        }

        public DataTable GetUsingBuzzer()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("sp_LayBuzzerDangSuDung", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}
