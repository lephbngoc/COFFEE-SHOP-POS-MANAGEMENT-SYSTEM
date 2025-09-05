using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.GUI;

namespace WindowsFormsApp1.GUI
{
    public partial class FormLogin : Form
    {
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
            lbWelcome.Left = this.Width;
            timerWelcome.Start();
            lbWelcome.Invalidate();
        }

        private bool KiemTraLoiNhapLieu()
        {
            bool hopLe = true;

            // Kiểm tra Mã nhân viên
            if (string.IsNullOrEmpty(txtMaNV.Text.Trim()))
            {
                ktraLoiNhapLieu.SetError(txtMaNV, "Vui lòng nhập mã nhân viên!");
                hopLe = false;
            }
            else
            {
                ktraLoiNhapLieu.SetError(txtMaNV, "");
            }

            // Kiểm tra Mật khẩu
            if (string.IsNullOrEmpty(txtMatKhau.Text.Trim()))
            {
                ktraLoiNhapLieu.SetError(txtMatKhau, "Vui lòng nhập mật khẩu!");
                hopLe = false;
            }
            else
            {
                ktraLoiNhapLieu.SetError(txtMatKhau, "");
            }
            return hopLe;
        }


        private void cMK_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = cMK.Checked ? '\0' : '*';
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (!KiemTraLoiNhapLieu())
                    return;

                string maNV = txtMaNV.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();

                NhanVienDTO nhanVien = nhanVienBLL.DangNhap(maNV, matKhau);

                if (nhanVien != null)
                {
                    MessageBox.Show($"Xin chào {nhanVien.TenNhanVien} ({nhanVien.VaiTro})");
                    this.Hide();

                    if (nhanVien.VaiTro.Trim().ToLower() == "quản lý" ||
                        nhanVien.VaiTro.Trim().ToLower() == "quan ly")
                    {
                        FormAdmin formAdmin = new FormAdmin(nhanVien.TenNhanVien, nhanVien.VaiTro);
                        formAdmin.Show();
                    }
                    else
                    {
                        if (nhanVien.NhanVienID == null)
                        {
                            MessageBox.Show("Không lấy được mã nhân viên. Vui lòng kiểm tra lại dữ liệu!");
                            return;
                        }
                        FormThuNgan formThuNgan = new FormThuNgan(
                            nhanVien.NhanVienID ?? 0,
                            nhanVien.TenNhanVien,
                            nhanVien.VaiTro
                        );
                        formThuNgan.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai mã nhân viên hoặc mật khẩu!", "Lỗi đăng nhập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerWelcome_Tick(object sender, EventArgs e)
        {

            lbWelcome.Left -= 2;
            if (lbWelcome.Right < 0)
            {
                lbWelcome.Left = this.ClientSize.Width + 20;
            }
            lbWelcome.Invalidate();
        }

        private void timerNhapNhay_Tick(object sender, EventArgs e)
        {
            // Đổi màu hoặc ẩn/hiện chữ để tạo hiệu ứng nhấp nháy
            // Đổi màu chữ giữa 2 màu để tạo hiệu ứng nhấp nháy
            if (lbWelcome.ForeColor == Color.Olive)
            {
                lbWelcome.ForeColor = Color.LemonChiffon;
            }
            else
            {
                lbWelcome.ForeColor = Color.Olive;
            }

            lbWelcome.Left -= 2; // Di chuyển chữ sang trái

            if (lbWelcome.Right < 0)
            {
                lbWelcome.Left = this.ClientSize.Width; // Reset lại bên phải form
            }
        }

        private int brightness = 0;
        private bool increasing = true;
        private void timerLapLanh_Tick(object sender, EventArgs e)
        {
            if (increasing)
            {
                brightness += 15; // Tăng độ sáng
                if (brightness >= 255) increasing = false;
            }
            else
            {
                brightness -= 15; // Giảm độ sáng
                if (brightness <= 0) increasing = true;
            }

            // Tạo màu phát sáng (màu vàng với độ sáng thay đổi)
            lbWelcome.ForeColor = Color.FromArgb(255, brightness, brightness / 2, 0);
        }

        private void btExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
 }


