using System.Data.SqlClient;

namespace WindowsFormsApp1.DAL
{
    public class DatabaseConnection
    {
        private static string connectionString = @"Server=KHANH\KHANH;Database=CafeShopManagement;Trusted_Connection=True;";
        public static string ConnectionString
        {
            get { return connectionString; }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}