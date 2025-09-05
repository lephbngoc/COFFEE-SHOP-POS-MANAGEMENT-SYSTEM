using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DAL;
using System.Data;

namespace WindowsFormsApp1.BLL
{
    public class BuzzerBLL
    {
        private BuzzerDAL buzzerDAL;

        public BuzzerBLL()
        {
            buzzerDAL = new BuzzerDAL(DatabaseConnection.ConnectionString);
        }

        public bool IsNeedBuzzer(string loaiKhach)
        {
            if (string.IsNullOrEmpty(loaiKhach))
                return false;

            // Chỉ hiện buzzer cho khách tại chỗ
            return loaiKhach.Trim().Equals("Tại chỗ", StringComparison.OrdinalIgnoreCase);
        }

        public DataTable GetAvailableBuzzer()
        {
            try
            {
                return buzzerDAL.GetAvailableBuzzer(); // Lấy buzzer có TrangThai = 0
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách buzzer trống: " + ex.Message);
            }
        }

        public DataTable GetBuzzer()
        {
            try
            {
                return buzzerDAL.GetBuzzer();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách buzzer: " + ex.Message);
            }
        }

        public bool UpdateBuzzerStatus(int buzzerID, bool isUsing)
        {
            try
            {
                return buzzerDAL.UpdateStatus(buzzerID, isUsing);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật trạng thái buzzer: " + ex.Message);
            }
        }

        public DataTable GetUsingBuzzer()
        {
            return buzzerDAL.GetUsingBuzzer();
        }
    }
}
