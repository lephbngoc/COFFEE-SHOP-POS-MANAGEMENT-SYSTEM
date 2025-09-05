using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;
using System.Data;

namespace WindowsFormsApp1.BLL
{
    public class GiaoCaBLL
    {
        private GiaoCaDAL giaoCaDAL = new GiaoCaDAL();

        public int LuuGiaoCa(GiaoCaDTO giaoCa)
        {
            return giaoCaDAL.LuuGiaoCa(giaoCa);
        }
    }
}