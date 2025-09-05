using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DTO
{
    public class MenuItemDTO
    {
        public int MonID { get; set; }
        public string TenMon { get; set; }
        public decimal DonGia { get; set; }
        public string TenNhom { get; set; }
        public int NhomMonID { get; set; }
        public int HangTon { get; set; }
    }
}
