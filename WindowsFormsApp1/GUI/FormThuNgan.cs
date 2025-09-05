using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection.Emit;
using WindowsFormsApp1.GUI;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;
using System.IO;

namespace WindowsFormsApp1.GUI
{
    public partial class FormThuNgan : Form
    {
        private string tenNhanVien;
        private string chucvu;
        private int currentNhanVienID;
        private DateTime thoiGianBatDauCa;
        private BuzzerBLL buzzerBLL;
        private KhachHangBLL khachHangBLL;
        private MenuBLL menuBLL;
        private HoaDonBLL hoaDonBLL;
        private int hoaDonID = 0; // biến toàn cục lưu ID hóa đơn
        private int? currentKhuyenMaiID = null;
        private float currentPhanTramGiam = 0;
        private string currentTenKhuyenMai = "";
        private decimal tongTienGoc = 0; 

        string connectionString = DatabaseConnection.ConnectionString;

        public FormThuNgan(int nhanVienID, string tenNV, string vaiTro)
        {
            InitializeComponent();

            currentNhanVienID = nhanVienID;
            tenNhanVien = tenNV;
            chucvu = vaiTro;
            thoiGianBatDauCa = DateTime.Now;

            //tạo các đối tượng in
            printDocument1 = new PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1.PrintPage += printDocument1_PrintPage;


            //tạo các BLL
            buzzerBLL = new BuzzerBLL();
            khachHangBLL = new KhachHangBLL();
            menuBLL = new MenuBLL();
            hoaDonBLL = new HoaDonBLL();
        }

        private void FormThuNgan_Load_1(object sender, EventArgs e)
        {
            try
            {
                //loadloại khách
                DataTable dtLoaiKhach = khachHangBLL.GetLoaiKhach();
                cboLoaiKhach.DataSource = dtLoaiKhach;
                cboLoaiKhach.DisplayMember = "TenLoai";
                cboLoaiKhach.ValueMember = "LoaiKhachID";

                //load nhóm món
                DataTable dtNhomMon = menuBLL.GetNhomMon();
                cboNhomMon.DataSource = dtNhomMon;
                cboNhomMon.DisplayMember = "TenNhom";
                cboNhomMon.ValueMember = "NhomMonID";

                //menu
                dgvMenu.DataSource = menuBLL.GetAllMenu();
                dgvMenu.DataBindingComplete += dgvMenu_DataBindingComplete;

                // Setup dgvBill
                SetupDgvBill();

                //mã hóa đơn
                lblMaHoaDon.Text = hoaDonBLL.TaoMaHoaDon();
                LoadBuzzer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load form: " + ex.Message + "\n\nChi tiết: " + ex.StackTrace);
            }
        }

        //design label
        private void timerWelcome_Tick(object sender, EventArgs e)
        {
         
            lbWelcome.Left -= 5; 
          
            if (lbWelcome.Right < 0)
            {
                lbWelcome.Left = this.Width; 
            }
        }

        private FormLogin formLogin;
        private void btDangXuat_Click(object sender, EventArgs e)
        {

            isLoggingOut = true;  //đánh dấu đang đăng xuất, chọn no là đăng xuất

            //show hộp thoại xác nhận khi nhấn đăng xuất
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); //ẩn frm thu ngân

                //mở frm đăng nhập
                if (formLogin == null || formLogin.IsDisposed)
                {
                    formLogin = new FormLogin(); 
                }
                formLogin.Show(); 
            }
            else
            {
                isLoggingOut = false;  
            }
        }

        private bool isLoggingOut = false;
        private void FormThuNgan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isLoggingOut)
            {
                return;  
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // ẩn fỏm thu ngân
                if (formLogin == null || formLogin.IsDisposed)
                {
                    formLogin = new FormLogin();  
                }
                formLogin.Show();
            }
            else
            {
                e.Cancel = true; 
            }
        }


        private void LoadMenu()
        {
            try
            {
                dgvMenu.DataSource = menuBLL.GetAllMenu();
                dgvMenu.Columns["MonID"].HeaderText = "Mã món";
                dgvMenu.Columns["TenMon"].HeaderText = "Tên món";
                dgvMenu.Columns["DonGia"].HeaderText = "Đơn giá (VNĐ)";
                dgvMenu.Columns["TenNhom"].HeaderText = "Nhóm món";
                dgvMenu.Columns["HangTon"].HeaderText = "Tồn kho";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load menu: " + ex.Message);
            }
        }


        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvMenu.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvMenu.Rows[e.RowIndex];
                int monID = Convert.ToInt32(row.Cells["MonID"].Value);

                int nhomMonID = 0;
                if (dgvMenu.Columns.Contains("NhomMonID"))
                {
                    nhomMonID = Convert.ToInt32(row.Cells["NhomMonID"].Value);
                }
                else
                {
                    string tenNhom = row.Cells["TenNhom"].Value.ToString();
                    nhomMonID = menuBLL.GetNhomMonIDByTenNhom(tenNhom);
                }

                // Gán lại DataSource cho cboMaMon theo nhóm món
                cboMaMon.DataSource = menuBLL.GetMonByNhomID(nhomMonID);
                cboMaMon.DisplayMember = "MonID";
                cboMaMon.ValueMember = "MonID";
                cboMaMon.SelectedValue = monID;

                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                cboNhomMon.SelectedValue = nhomMonID;
                lbGia.Text = Convert.ToDouble(row.Cells["DonGia"].Value).ToString("N0") + " VNĐ";
                nudSoLuong.Value = 1;
            }
        }

        //chọn 1 mã món trong combobox thì hiện tên món và giá (lấy từ DB và hiện lên form)
        private void cboMaMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaMon.SelectedValue != null && int.TryParse(cboMaMon.SelectedValue.ToString(), out int monID))
            {
                DataTable dt = menuBLL.GetMonByID(monID);
                if (dt.Rows.Count > 0)
                {
                    txtTenMon.Text = dt.Rows[0]["TenMon"].ToString();
                    lbGia.Text = Convert.ToDouble(dt.Rows[0]["DonGia"]).ToString("N0") + " VNĐ";
                }
            }
        }

        private void LoadMaMon()
        {
            try
            {
                cboMaMon.DataSource = menuBLL.GetAllMenu();
                cboMaMon.DisplayMember = "MonID";
                cboMaMon.ValueMember = "MonID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load mã món: " + ex.Message);
            }
        }

        private void LoadNhomMon()
        {
            try
            {
                cboNhomMon.DataSource = menuBLL.GetNhomMon();
                cboNhomMon.DisplayMember = "TenNhom";
                cboNhomMon.ValueMember = "NhomMonID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhóm món: " + ex.Message);
            }
        }

        private void cboNhomMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNhomMon.SelectedValue != null && int.TryParse(cboNhomMon.SelectedValue.ToString(), out int nhomMonID))
            {
                cboMaMon.DataSource = menuBLL.GetMonByNhomID(nhomMonID);
                cboMaMon.DisplayMember = "MonID";
                cboMaMon.ValueMember = "MonID";
            }
        }

        //tìm món ăn khi nhấn Enter
        private void txtTenMon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string tenMon = txtTenMon.Text.Trim();
                if (!string.IsNullOrEmpty(tenMon))
                {
                    try
                    {
                        DataTable dt = menuBLL.GetMonByName(tenMon);
                        if (dt.Rows.Count > 0)
                        {
                            int nhomMonID = Convert.ToInt32(dt.Rows[0]["NhomMonID"]);
                            int monID = Convert.ToInt32(dt.Rows[0]["MonID"]);
                            double gia = Convert.ToDouble(dt.Rows[0]["DonGia"]);


                            cboNhomMon.SelectedValue = nhomMonID;


                            DataTable dtMonTheoNhom = menuBLL.GetMonByNhomID(nhomMonID);
                            cboMaMon.DataSource = dtMonTheoNhom;
                            cboMaMon.DisplayMember = "MonID";
                            cboMaMon.ValueMember = "MonID";

                            //chọn món 
                            cboMaMon.SelectedValue = monID;
                            lbGia.Text = gia.ToString("N0") + " VNĐ";
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy món này!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tìm món: " + ex.Message);
                    }
                }
            }
        }

        private void SetupDgvBill()
        {
            dgvBill.Columns.Clear();
            dgvBill.Columns.Add("NhomMon", "Nhóm món");
            dgvBill.Columns.Add("MaMon", "Mã món");
            dgvBill.Columns.Add("TenMon", "Tên món");
            dgvBill.Columns.Add("SoLuong", "Số lượng");
            dgvBill.Columns.Add("DonGia", "Đơn giá");
            dgvBill.Columns.Add("ThanhTien", "Thành tiền");
            dgvBill.Columns.Add("GhiChu", "Ghi chú");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(cboNhomMon.Text) ||
                string.IsNullOrWhiteSpace(cboMaMon.Text) ||
                string.IsNullOrWhiteSpace(txtTenMon.Text) ||
                nudSoLuong.Value <= 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ các ô nhập
            string nhomMon = cboNhomMon.Text;
            string maMon = cboMaMon.Text;
            string tenMon = txtTenMon.Text;
            int soLuong = (int)nudSoLuong.Value;

            double donGia = 0;
            if (!double.TryParse(lbGia.Text.Replace(" VNĐ", "").Replace(".", "").Replace(",", ""), out donGia))
            {
                MessageBox.Show("Định dạng giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double thanhTien = soLuong * donGia;
            string ghiChu = txtGhiChu.Text.Trim();

            // Thêm dòng vào dgvBill
            dgvBill.Rows.Add(nhomMon, maMon, tenMon, soLuong, donGia.ToString("N0"), thanhTien.ToString("N0"), ghiChu);

            TinhTongTien();
        }
        private void TinhTongTien()
        {
            tongTienGoc = 0;
            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.IsNewRow) continue;
                decimal thanhTien = 0;
                decimal.TryParse(row.Cells["ThanhTien"].Value?.ToString().Replace(".", "").Replace(" VNĐ", ""), out thanhTien);
                tongTienGoc += thanhTien;
            }
            TinhTongTienSauKhuyenMai(); //cập nhật tổng tiền sau giảm
        }

        private void TinhTongTienSauKhuyenMai()
        {
            decimal giamGia = tongTienGoc * (decimal)currentPhanTramGiam / 100;
            decimal tongTienSauGiam = tongTienGoc - giamGia;
            lbTong.Text = tongTienSauGiam.ToString("N0") + " VNĐ";
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (dgvBill.CurrentRow != null && !dgvBill.CurrentRow.IsNewRow)
            {
                int rowIndex = dgvBill.CurrentRow.Index;
                dgvBill.Rows.RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }
            TinhTongTien();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            if (dgvBill.CurrentRow != null && !dgvBill.CurrentRow.IsNewRow)
            {
                DataGridViewRow row = dgvBill.CurrentRow;
                row.Cells["NhomMon"].Value = cboNhomMon.Text;
                row.Cells["MaMon"].Value = cboMaMon.Text;
                row.Cells["TenMon"].Value = txtTenMon.Text;
                row.Cells["SoLuong"].Value = nudSoLuong.Value;
                row.Cells["DonGia"].Value = lbGia.Text;
                row.Cells["GhiChu"].Value = txtGhiChu.Text;
                double donGia = double.Parse(lbGia.Text.Replace(" VNĐ", "").Replace(".", ""));
                int soLuong = (int)nudSoLuong.Value;
                row.Cells["ThanhTien"].Value = (soLuong * donGia).ToString("N0");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa!");
            }
            TinhTongTien();
        }

        //bấm vào một dòng hóa đơn form tự động nhập liệu
        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !dgvBill.Rows[e.RowIndex].IsNewRow)
            {
                DataGridViewRow row = dgvBill.Rows[e.RowIndex];
                cboNhomMon.Text = row.Cells["NhomMon"].Value.ToString();
                cboMaMon.Text = row.Cells["MaMon"].Value.ToString();
                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                nudSoLuong.Value = Convert.ToInt32(row.Cells["SoLuong"].Value);
                lbGia.Text = row.Cells["DonGia"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            }
        }


        private void btThanhToan_Click(object sender, EventArgs e)
        {
            // Kiểm tra tổng tiền và tiền khách đưa
            double tongTien = 0;
            double tienKhachDua = 0;
            double tienThua = 0;

            double.TryParse(lbTong.Text.Replace(".", "").Replace(" VNĐ", ""), out tongTien);
            double.TryParse(txtTienKhachDua.Text.Replace(".", ""), out tienKhachDua); //out:tham chiếu để ra gtri

            tienThua = tienKhachDua - tongTien;

            if (tienThua < 0)
            {
                MessageBox.Show("Khách đưa chưa đủ tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thanh toán thành công
            MessageBox.Show("Thanh toán thành công!\nTiền thừa trả khách: " + tienThua.ToString("N0") + " VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // định dạng cọ,font,lề
            Graphics g = e.Graphics;
            Font fontHeader = new Font("Arial", 14, FontStyle.Bold);
            Font fontBold = new Font("Arial", 9, FontStyle.Bold);
            Font fontRegular = new Font("Arial", 9, FontStyle.Regular);
            Font fontSmall = new Font("Arial", 8, FontStyle.Italic);
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            StringFormat formatCenter = new StringFormat { Alignment = StringAlignment.Center };
            StringFormat formatRight = new StringFormat { Alignment = StringAlignment.Far };
            float yPos = 0;
            float leftMargin = 10;
            float topMargin = 10;
            float pageWidth = e.PageBounds.Width - (leftMargin * 2);

            //lấy dữ liệu từ form
            string maHoaDon = lblMaHoaDon.Text;
            string tenThuNgan = this.tenNhanVien; 

            // Tính toán
            decimal tongTienTruocGiam = this.tongTienGoc; 
            int tongSoLuong = 0;
            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.IsNewRow) continue;
                tongSoLuong += Convert.ToInt32(row.Cells["SoLuong"].Value);
            }

            decimal tongThanhToan = decimal.Parse(lbTong.Text.Replace(".", "").Replace(" VNĐ", ""));
            decimal giamGia = tongTienTruocGiam - tongThanhToan;
            decimal tienKhachDua = decimal.Parse(txtTienKhachDua.Text.Replace(".", ""));
            decimal tienThua = decimal.Parse(lbTienThua.Text.Replace(".", "").Replace(" VNĐ", ""));
            string deliNote = cboLoaiKhach.Text;

            //code hóa đơn
            // Header
            yPos = topMargin;
            g.DrawString("N&B COFFEE", fontHeader, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 20), formatCenter);
            yPos += 25;
            g.DrawString("Địa chỉ: 527 Phan Văn Trị, phường An Nhơn, Thành phố Hồ Chí Minh", fontRegular, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 20;
            g.DrawString("HÓA ĐƠN BÁN HÀNG", fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 20;
            g.DrawString("Số Bill: " + maHoaDon, fontRegular, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 25;

            //thông tin hóa đơn
            g.DrawString("Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontRegular, blackBrush, leftMargin, yPos);
            yPos += 20;
            g.DrawString("Thu ngân: " + tenThuNgan, fontRegular, blackBrush, leftMargin, yPos);
            yPos += 20;
            g.DrawString("DELI NOTE: " + deliNote, fontBold, blackBrush, leftMargin, yPos);
            yPos += 25;

            //bảng món ăn đã chọn
            g.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, leftMargin + pageWidth, yPos);
            yPos += 5;
            g.DrawString("Tên món", fontBold, blackBrush, leftMargin, yPos);
            g.DrawString("SL", fontBold, blackBrush, leftMargin + 150, yPos);
            g.DrawString("Đ.Giá", fontBold, blackBrush, leftMargin + 180, yPos);
            g.DrawString("T.Tiền", fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatRight);
            yPos += 20;
            g.DrawLine(new Pen(Color.Black, 1), leftMargin, yPos, leftMargin + pageWidth, yPos);
            yPos += 5;

           
            foreach (DataGridViewRow row in dgvBill.Rows)
            {
                if (row.IsNewRow) continue;

                string tenMon = row.Cells["TenMon"].Value?.ToString() ?? "";
                string soLuong = row.Cells["SoLuong"].Value?.ToString() ?? "0";
                string donGiaRaw = row.Cells["DonGia"].Value?.ToString() ?? "0";
                decimal.TryParse(donGiaRaw.Replace(".", "").Replace(",", ""), out decimal donGiaDecimal);
                string donGia = donGiaDecimal.ToString("N0");
                string thanhTienRaw = row.Cells["ThanhTien"].Value?.ToString() ?? "0";
                decimal.TryParse(thanhTienRaw.Replace(".", "").Replace(",", ""), out decimal thanhTienDecimal);
                string thanhTien = thanhTienDecimal.ToString("N0");
                string ghiChu = row.Cells["GhiChu"].Value?.ToString() ?? "";

                g.DrawString(tenMon, fontRegular, blackBrush, leftMargin, yPos);
                g.DrawString(soLuong, fontRegular, blackBrush, leftMargin + 150, yPos);
                g.DrawString(donGia, fontRegular, blackBrush, leftMargin + 180, yPos);
                g.DrawString(thanhTien, fontRegular, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatRight);
                yPos += 20;
                if (!string.IsNullOrWhiteSpace(ghiChu))
                {
                    g.DrawString("  * " + ghiChu, fontSmall, blackBrush, leftMargin + 10, yPos);
                    yPos += 15;
                }
            }


            //tổng kết chi tiết
            g.DrawString("Tổng số lượng:", fontRegular, blackBrush, leftMargin, yPos);
            g.DrawString(tongSoLuong.ToString(), fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatRight);
            yPos += 20;
            g.DrawString("Thành tiền:", fontRegular, blackBrush, leftMargin, yPos);
            g.DrawString(tongTienTruocGiam.ToString("N0"), fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatRight);
            yPos += 20;
            g.DrawString("Giảm giá (" + currentTenKhuyenMai + "):", fontRegular, blackBrush, leftMargin, yPos);
            g.DrawString(giamGia.ToString("N0"), fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatRight);
            yPos += 25;
            g.DrawString("TỔNG CỘNG:", fontBold, blackBrush, leftMargin, yPos);
            g.DrawString(tongThanhToan.ToString("N0") + " VNĐ", fontHeader, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 20), formatRight);
            yPos += 25;
            Pen dashedPen = new Pen(Color.Black, 1);
            dashedPen.DashPattern = new float[] { 3, 3 };
            g.DrawLine(dashedPen, leftMargin, yPos, leftMargin + pageWidth, yPos);
            yPos += 5;
            g.DrawString("Tiền khách đưa:", fontRegular, blackBrush, leftMargin, yPos);
            g.DrawString(tienKhachDua.ToString("N0"), fontRegular, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatRight);
            yPos += 20;
            g.DrawString("Tiền thừa:", fontRegular, blackBrush, leftMargin, yPos);
            g.DrawString(tienThua.ToString("N0"), fontRegular, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatRight);
            yPos += 25;

            // Footer
            g.DrawString("Giá đã bao gồm VAT. Vui lòng kiểm tra hóa đơn. Hóa đơn chỉ có giá trị trong vòng 30 ngày kể từ ngày in", fontSmall, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 20;

            //mã QR 
            string qrPath = @"D:\QL_quan_cafe\ma qr.jpg";
            if (File.Exists(qrPath))
            {
                Image qrImage = Image.FromFile(qrPath);
                g.DrawImage(qrImage, (e.PageBounds.Width - 100) / 2, yPos, 100, 100);
                yPos += 105;
            }

            g.DrawString(
                "Ngân hàng: MB Bank\n" +
                "Tên tài khoản: NB COFFEE\n" +
                "Số tài khoản: 090141xxxx\n" +
                "Khách hàng vui lòng ghi chú mã hóa đơn khi chuyển khoản",
                fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 60), formatCenter);
            yPos += 60;

            yPos += 20;
            g.DrawString("Fanpage: N&B coffee", fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 20;
            g.DrawString("Website: N&B coffee.com", fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 20;
            g.DrawString("Mọi đóng góp ý kiến xin vui lòng nhắn tại fanpage/website", fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 20;

            yPos += 20;
            g.DrawString("Password wifi: naibeocoffe", fontRegular, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
            yPos += 20; 
            g.DrawString("Chúc quý khách ngon miệng! Cảm ơn quý khách!", fontBold, blackBrush, new RectangleF(leftMargin, yPos, pageWidth, 15), formatCenter);
        }



        private void printPreviewDialog1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (sender is PrintPreviewDialog dialog)
                {
                    dialog.FormClosed -= printPreviewDialog1_FormClosed;
                }

                ResetForm();

                string newMaHoaDon = hoaDonBLL.TaoMaHoaDon();
                lblMaHoaDon.Text = newMaHoaDon;

                MessageBox.Show("Đã lưu và in hóa đơn thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi reset form: " + ex.Message);
            }

            
        }

        private int GetCurrentNhanVienID()
        {
            return currentNhanVienID;
        }

        private void txtTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //tổng tiền sau giảm
                string tongTienStr = lbTong.Text.Replace("VNĐ", "").Replace(".", "").Trim();
                decimal tongTienSauGiam = 0;
                decimal.TryParse(tongTienStr, out tongTienSauGiam);

                //tiền khách đưa
                string tienKhachDuaStr = txtTienKhachDua.Text.Replace(".", "").Trim();
                decimal tienKhachDua = 0;
                decimal.TryParse(tienKhachDuaStr, out tienKhachDua);

                //tiền thừa
                decimal tienThua = tienKhachDua - tongTienSauGiam;
                lbTienThua.Text = tienThua.ToString("N0") + " VNĐ";

                // Enable/disable nút thanh toán
                btThanhToan.Enabled = (tienKhachDua >= tongTienSauGiam);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tiền thừa: " + ex.Message);
            }
        }



        private void txtTienKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void btInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBill.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa có món nào trong hóa đơn!");
                    return;
                }

                if (string.IsNullOrEmpty(txtTienKhachDua.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa!");
                    return;
                }

                // Tạo HoaDonDTO
HoaDonDTO hoaDon = new HoaDonDTO
{
    MaHoaDon = lblMaHoaDon.Text,
    NgayGio = DateTime.Now,
    KhachHangID = currentKhachHangID != 0 ? (int?)currentKhachHangID : null,
    BuzzerID = (cboBuzzer.Visible && cboBuzzer.SelectedValue != null) ? Convert.ToInt32(cboBuzzer.SelectedValue) : (int?)null,
    TongTien = decimal.Parse(lbTong.Text.Replace(".", "").Replace(" VNĐ", "")), // Tổng tiền sau giảm
    NhanVienID = currentNhanVienID,
    GhiChu = txtGhiChu.Text,
    KhuyenMaiID = currentKhuyenMaiID,
    GiamGia = currentPhanTramGiam
};

                List<ChiTietHoaDonDTO> chiTietList = new List<ChiTietHoaDonDTO>();
                foreach (DataGridViewRow row in dgvBill.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        chiTietList.Add(new ChiTietHoaDonDTO
                        {
                            MonID = Convert.ToInt32(row.Cells["MaMon"].Value),
                            SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                            ThanhTien = decimal.Parse(row.Cells["ThanhTien"].Value.ToString().Replace(".", "").Replace(" VNĐ", "")),
                            NhanVienID = GetCurrentNhanVienID()
                        });
                    }
                }

                //lưu hóa đơn
                int hoaDonID = hoaDonBLL.LuuHoaDon(hoaDon, chiTietList);
                if (hoaDonID > 0)
                {
                    //cập nhật trạng thái buzzer
                    if (hoaDon.BuzzerID != null)
                    {
                        buzzerBLL.UpdateBuzzerStatus(hoaDon.BuzzerID.Value, true);
                    }

                    if (hoaDon.KhachHangID != null)
                    {
                        int diemTang = (int)(hoaDon.TongTien / 10000);
                        khachHangBLL.CapNhatDiemTichLuy(hoaDon.KhachHangID.Value, diemTang);
                        MessageBox.Show("Điểm tích lũy đã được cập nhật.");
                    }

                    // Thiết lập PrintPreviewDialog
                    printPreviewDialog1.Document = printDocument1;
                    printPreviewDialog1.WindowState = FormWindowState.Maximized;

                    // Hiển thị preview
                    if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                    {
                        printDocument1.Print();
                    }

                    // Reset form và tạo mã hóa đơn mới
                    ResetForm();
                    lblMaHoaDon.Text = hoaDonBLL.TaoMaHoaDon();
                    MessageBox.Show("Đã lưu và in hóa đơn thành công!");

                    if (cboBuzzer.Visible && cboBuzzer.SelectedValue != null)
                    {
                        int buzzerID = Convert.ToInt32(cboBuzzer.SelectedValue);
                        buzzerBLL.UpdateBuzzerStatus(buzzerID, true); 
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message);
            }

        }

        private void ResetForm()
        {
            cboLoaiKhach.SelectedIndex = -1;
            cboBuzzer.SelectedIndex = -1;
            dgvBill.Rows.Clear();
            lbTong.Text = "0 VNĐ";
            txtTienKhachDua.Text = "";
            lbTienThua.Text = "0 VNĐ";
            txtGhiChu.Text = "";
            currentKhachHangID = 0; 
            hoaDonID = 0;           
            currentKhuyenMaiID = null;
            currentPhanTramGiam = 0;
            currentTenKhuyenMai = "";
            lblKhuyenMai.Text = ""; 
        }



        private void cboLoaiKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string loaiKhach = cboLoaiKhach.Text;

            // Kiểm tra và hiển thị/ẩn controls liên quan đến buzzer
            bool needBuzzer = buzzerBLL.IsNeedBuzzer(loaiKhach);

            // Ẩn/hiện controls
            cboBuzzer.Visible = needBuzzer;

            // Nếu cần buzzer, load danh sách buzzer trống
            if (needBuzzer)
            {
                DataTable dtBuzzer = buzzerBLL.GetAvailableBuzzer();
                cboBuzzer.DataSource = dtBuzzer;
                cboBuzzer.DisplayMember = "SoBuzzer";
                cboBuzzer.ValueMember = "BuzzerID";
            }
            else
            {
                cboBuzzer.DataSource = null;
            }
        }

        private void txtTienKhachDua_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTienKhachDua.Text))
                {
                    lbTienThua.Text = "0 VNĐ";
                    btThanhToan.Enabled = false;
                    return;
                }

                //tổng tiền
                string tongTienStr = lbTong.Text.Replace("VNĐ", "").Replace(".", "").Trim();
                double tongTien = 0;
                Double.TryParse(tongTienStr, out tongTien);

                //tiền khách đưa
                string tienKhachDuaStr = txtTienKhachDua.Text.Replace(".", "").Trim();
                double tienKhachDua = 0;
                Double.TryParse(tienKhachDuaStr, out tienKhachDua);

                //tiền thừa
                double tienThua = tienKhachDua - tongTien;

                // Format và hiển thị
                lbTienThua.Text = tienThua.ToString("N0") + " VNĐ";
                btThanhToan.Enabled = (tienKhachDua >= tongTien);

                // Format lại số tiền khách đưa
                if (tienKhachDua > 0)
                {
                    txtTienKhachDua.TextChanged -= txtTienKhachDua_TextChanged;
                    txtTienKhachDua.Text = tienKhachDua.ToString("N0");
                    txtTienKhachDua.SelectionStart = txtTienKhachDua.Text.Length;
                    txtTienKhachDua.TextChanged += txtTienKhachDua_TextChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tiền thừa: " + ex.Message);
            }
        }

        private void btThanhToan_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (dgvBill.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa có món nào trong hóa đơn!");
                    return;
                }

                if (string.IsNullOrEmpty(txtTienKhachDua.Text))
                {
                    MessageBox.Show("Vui lòng nhập số tiền khách đưa!");
                    txtTienKhachDua.Focus();
                    return;
                }

                double tongTien = double.Parse(lbTong.Text.Replace(".", "").Replace(" VNĐ", ""));
                double tienKhachDua = double.Parse(txtTienKhachDua.Text.Replace(".", ""));
                double tienThua = tienKhachDua - tongTien;

                if (tienThua < 0)
                {
                    MessageBox.Show("Khách đưa chưa đủ tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTienKhachDua.Focus();
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Xác nhận thanh toán:\nTổng tiền: {tongTien:N0} VNĐ\nTiền khách đưa: {tienKhachDua:N0} VNĐ\nTiền thừa: {tienThua:N0} VNĐ",
                    "Xác nhận thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );


                if (result == DialogResult.Yes)
                {
                    if (hoaDonID != 0 && currentKhachHangID != 0)
                    {
                        hoaDonBLL.CapNhatHoaDon(hoaDonID, currentKhachHangID, (decimal)tongTien);
                        int diemTang = (int)(tongTien / 10000);
                        khachHangBLL.CapNhatDiemTichLuy(currentKhachHangID, diemTang);
                        MessageBox.Show("Điểm tích lũy đã được cập nhật.");
                        // Reset sau khi cộng điểm
                        currentKhachHangID = 0;
                        hoaDonID = 0;
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

        private void txtTienKhachDua_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTienKhachDua.Text))
            {
                decimal value;
                if (decimal.TryParse(txtTienKhachDua.Text.Replace(".", ""), out value))
                {
                    txtTienKhachDua.Text = value.ToString("N0");
                }
            }
        }

        private int currentKhachHangID = 0; 
        private void btThanhVien_Click(object sender, EventArgs e)
        {
            this.Hide(); // Ẩn FormThuNgan

            FormKhachHang frm = new FormKhachHang();
            var result = frm.ShowDialog(); // ShowDialog sẽ luôn nổi lên trên

            if (result == DialogResult.OK)
            {
                // Lấy ID khách hàng vừa chọn/thêm
                currentKhachHangID = frm.KhachHangID;
                // Có thể hiển thị tên khách lên giao diện nếu muốn
            }
            else
            {
                // Nếu bấm Cancel hoặc đóng form, không liên kết khách hàng
                currentKhachHangID = 0;
            }

            this.Show(); // Hiện lại FormThuNgan sau khi đóng FormKhachHang
        }

        private void btGiaoCa_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu ca hiện tại
            int nhanVienID = currentNhanVienID;
            string tenNV = tenNhanVien;
            DateTime thoiGianBatDau = thoiGianBatDauCa;
            DateTime thoiGianKetThuc = DateTime.Now;

            // Lấy tổng số hóa đơn và doanh thu trong ca từ DB
            int tongSoHoaDon = 0;
            decimal tongDoanhThu = 0;

            using (SqlConnection conn = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                conn.Open();
                string sql = @"SELECT COUNT(*) AS SoHoaDon, ISNULL(SUM(TongTien),0) AS DoanhThu
                       FROM HoaDon
                       WHERE NhanVienID = @NhanVienID
                         AND NgayGio >= @BatDau
                         AND NgayGio <= @KetThuc";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NhanVienID", nhanVienID);
                cmd.Parameters.AddWithValue("@BatDau", thoiGianBatDau);
                cmd.Parameters.AddWithValue("@KetThuc", thoiGianKetThuc);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tongSoHoaDon = Convert.ToInt32(reader["SoHoaDon"]);
                        tongDoanhThu = Convert.ToDecimal(reader["DoanhThu"]);
                    }
                }
            }

            // Mở form giao ca
            FormGiaoCa frm = new FormGiaoCa(nhanVienID, tenNV, thoiGianBatDau, thoiGianKetThuc, tongSoHoaDon, tongDoanhThu);
            frm.ShowDialog();

            // Reset lại thời gian bắt đầu ca cho ca mới
            thoiGianBatDauCa = DateTime.Now;
        }

        //đổi tiêu đề
        private void dgvMenu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dgvMenu.Columns["MonID"] != null)
                dgvMenu.Columns["MonID"].HeaderText = "Mã món";
            if (dgvMenu.Columns["TenMon"] != null)
                dgvMenu.Columns["TenMon"].HeaderText = "Tên món";
            if (dgvMenu.Columns["DonGia"] != null)
                dgvMenu.Columns["DonGia"].HeaderText = "Đơn giá";
            if (dgvMenu.Columns["TenNhom"] != null)
                dgvMenu.Columns["TenNhom"].HeaderText = "Nhóm món";
            if (dgvMenu.Columns["HangTon"] != null)
                dgvMenu.Columns["HangTon"].HeaderText = "Tồn kho";
            if (dgvMenu.Columns["NhomMonID"] != null)
                dgvMenu.Columns["NhomMonID"].Visible = false; 
    }

        private void button1_Click(object sender, EventArgs e)
        {

            FormTraBuzzer frm = new FormTraBuzzer();
            frm.ShowDialog();
            LoadBuzzer();
        }

        private void LoadBuzzer()
        {
            try
            {
                DataTable dtBuzzer = buzzerBLL.GetAvailableBuzzer(); // Chỉ buzzer rảnh
                cboBuzzer.DataSource = dtBuzzer;
                cboBuzzer.DisplayMember = "SoBuzzer";
                cboBuzzer.ValueMember = "BuzzerID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load buzzer: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (formKhuyenMai frm = new formKhuyenMai())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu không chọn khuyến mãi nào
                    if (frm.SelectedKhuyenMaiID == null)
                    {
                        currentKhuyenMaiID = null;
                        currentPhanTramGiam = 0;
                        currentTenKhuyenMai = "";
                        lblKhuyenMai.Text = "Không áp dụng";
                    }
                    else
                    {
                        currentKhuyenMaiID = frm.SelectedKhuyenMaiID;
                        currentPhanTramGiam = frm.SelectedPhanTramGiam;
                        currentTenKhuyenMai = frm.SelectedTenKhuyenMai;
                        lblKhuyenMai.Text = currentTenKhuyenMai;
                    }
                    TinhTongTien();
                }
            }
        }


       
        //HÀM KHÔNG DÙNG 
        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBill_Click(object sender, EventArgs e)
        {


        }
        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblMaHoaDon_Click(object sender, EventArgs e)
        {

        }
        private void lblKhuyenMai_Click(object sender, EventArgs e)
        {

        }
    }
}
