using System.Data;
using WindowsFormsApp1.DAL;
using System.Data.SqlClient;
namespace WindowsFormsApp1.BLL
{
    public class KhuyenMaiBLL
    {
        private KhuyenMaiDAL khuyenMaiDAL;

        public KhuyenMaiBLL()
        {
            khuyenMaiDAL = new KhuyenMaiDAL(DatabaseConnection.ConnectionString);
        }

        public DataTable GetKhuyenMaiDangApDung()
        {
            return khuyenMaiDAL.GetKhuyenMaiDangApDung();
        }
    }
}