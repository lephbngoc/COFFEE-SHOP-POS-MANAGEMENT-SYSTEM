using System;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;
using System.Data;

namespace WindowsFormsApp1.GUI
{
    public partial class FormGiaoCa : Form
    {
        private GiaoCaBLL giaoCaBLL = new GiaoCaBLL();
        private int nhanVienID;
        private string tenNhanVien;
        private DateTime thoiGianBatDau;
        private DateTime thoiGianKetThuc;
        private int tongSoHoaDon;
        private decimal tongDoanhThu;

        public FormGiaoCa(int nhanVienID, string tenNhanVien, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, int tongSoHoaDon, decimal tongDoanhThu)
        {
            InitializeComponent();
            this.nhanVienID = nhanVienID;
            this.tenNhanVien = tenNhanVien;
            this.thoiGianBatDau = thoiGianBatDau;
            this.thoiGianKetThuc = thoiGianKetThuc;
            this.tongSoHoaDon = tongSoHoaDon;
            this.tongDoanhThu = tongDoanhThu;
        }

        private void FormGiaoCa_Load(object sender, EventArgs e)
        {
            txtNhanVien.Text = tenNhanVien;
            txtThoiGianBatDau.Text = thoiGianBatDau.ToString("dd/MM/yyyy HH:mm");
            txtThoiGianKetThuc.Text = thoiGianKetThuc.ToString("dd/MM/yyyy HH:mm");
            txtTongHoaDon.Text = tongSoHoaDon.ToString();
            txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
            txtTienMatThucTe.Text = tongDoanhThu.ToString("N0");
            txtChenhLech.Text = "0";
        }

        private void txtTienMatThucTe_TextChanged(object sender, EventArgs e)
        {
            decimal tienMatThucTe = 0;
            decimal.TryParse(txtTienMatThucTe.Text.Replace(".", ""), out tienMatThucTe);
            decimal chenhLech = tienMatThucTe - tongDoanhThu;
            txtChenhLech.Text = chenhLech.ToString("N0");
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            decimal tienMatThucTe = 0;
            decimal.TryParse(txtTienMatThucTe.Text.Replace(".", ""), out tienMatThucTe);
            decimal chenhLech = tienMatThucTe - tongDoanhThu;

            GiaoCaDTO giaoCa = new GiaoCaDTO
            {
                NhanVienID = nhanVienID,
                ThoiGianBatDau = thoiGianBatDau,
                ThoiGianKetThuc = thoiGianKetThuc,
                TongSoHoaDon = tongSoHoaDon,
                TongDoanhThu = tongDoanhThu,
                TienMatThucTe = tienMatThucTe,
                ChenhLech = chenhLech,
                GhiChu = txtGhiChu.Text
            };

            giaoCaBLL.LuuGiaoCa(giaoCa);

            MessageBox.Show("Giao ca thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}