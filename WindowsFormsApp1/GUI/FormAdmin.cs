using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;
using WindowsFormsApp1.GUI;


using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms.DataVisualization;
using System.Globalization;


// Khai báo cụ thể để tránh xung đột1A
using DataTable = System.Data.DataTable;
using Chart = System.Windows.Forms.DataVisualization.Charting.Chart;
using ChartArea = System.Windows.Forms.DataVisualization.Charting.ChartArea;
using Series = System.Windows.Forms.DataVisualization.Charting.Series;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;



namespace WindowsFormsApp1
{
    public partial class FormAdmin : Form
    {
        private MenuBLL menuBLL = new MenuBLL();
        private NhanVienBLL nhanVienBLL = new NhanVienBLL();
        private HoaDonBLL hoadonBLL = new HoaDonBLL();
        private string tenNhanVien;
        private string chucvu;
        private SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString);

        // Thêm phương thức này vào đây
        private void SetupDataGridView(DataGridView dgv)
        {
            if (dgv.Columns.Count > 0)
            {
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
        public FormAdmin()
        {
            InitializeComponent();
            btnXuatBieuDo.Click += new EventHandler(btnXuatBieuDo_Click_1);

        }

        public FormAdmin(string tenNV, string cV)
        {
            InitializeComponent();
            tenNhanVien = tenNV;
            chucvu = cV;

            // Đăng ký sự kiện ngay trong constructor
            btNhapHang.Click += new EventHandler(btNhapHang_Click);
            btCanhBao.Click += new EventHandler(btCanhBao_Click);

            LoadNhomMon();
            LoadMon();
            LoadNhanVien();
            LoadKho();


        }

        private void MoKetNoi()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        private void DongKetNoi()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        // --- TAB MENU ---
        void LoadMon()
        {
            try
            {
                // Lấy dữ liệu menu qua BLL (BLL sẽ gọi DAL, DAL sẽ gọi proc)
                DataTable dt = menuBLL.GetAllMenu();

                dataGrVMenu.DataSource = dt;

                // Thiết lập SelectionMode trước khi set SortMode
                dataGrVMenu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGrVMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGrVMenu.AllowUserToAddRows = false;
                dataGrVMenu.AllowUserToDeleteRows = false;
                dataGrVMenu.ReadOnly = true;

                // Đặt SortMode = NotSortable cho tất cả các cột
                foreach (DataGridViewColumn col in dataGrVMenu.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // Format tên cột tiếng Việt
                dataGrVMenu.Columns["MonID"].HeaderText = "Mã món";
                dataGrVMenu.Columns["TenMon"].HeaderText = "Tên món";
                dataGrVMenu.Columns["DonGia"].HeaderText = "Đơn giá";
                dataGrVMenu.Columns["TenNhom"].HeaderText = "Nhóm món";
                dataGrVMenu.Columns["HangTon"].HeaderText = "Hàng tồn";
                if (dataGrVMenu.Columns.Contains("NhomMonID"))
                    dataGrVMenu.Columns["NhomMonID"].Visible = false;

                // Format hiển thị
                dataGrVMenu.Columns["DonGia"].DefaultCellStyle.Format = "N0";

                // Căn giữa các cột số
                dataGrVMenu.Columns["MonID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGrVMenu.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGrVMenu.Columns["HangTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load menu: " + ex.Message);
            }
        }

        private void LoadNhomMon()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT NhomMonID, TenNhom FROM NhomMon ORDER BY NhomMonID", connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Reset ComboBox
                comboBoxNhomMon.DataSource = null;
                comboBoxNhomMon.Items.Clear();

                // Gán dữ liệu mới
                comboBoxNhomMon.DataSource = dt;
                comboBoxNhomMon.DisplayMember = "TenNhom";
                comboBoxNhomMon.ValueMember = "NhomMonID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhóm món: " + ex.Message);
            }
        }

        private void btTimKiemMon_Click(object sender, EventArgs e)
        {
            try
            {
                string tenMon = txtTenMon.Text.Trim();
                string donGiaText = txtDonGia.Text.Trim();
                string hangTonText = txtHangTon.Text.Trim();

                string query = @"SELECT m.MonID, m.TenMon, m.DonGia, n.TenNhom AS NhomMon, m.NhomMonID, m.HangTon 
                               FROM Mon m 
                               LEFT JOIN NhomMon n ON m.NhomMonID = n.NhomMonID 
                               WHERE 1=1";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;

                // Tìm theo tên món
                if (!string.IsNullOrEmpty(tenMon))
                {
                    query += " AND m.TenMon LIKE @TenMon";
                    cmd.Parameters.AddWithValue("@TenMon", "%" + tenMon + "%");
                }

                // Tìm theo đơn giá
                if (!string.IsNullOrEmpty(donGiaText))
                {
                    // Kiểm tra nếu có dấu < hoặc > trong chuỗi giá
                    if (donGiaText.Contains("<"))
                    {
                        string[] parts = donGiaText.Split('<');
                        if (parts.Length == 2 && decimal.TryParse(parts[1].Trim(), out decimal donGia))
                        {
                            query += " AND m.DonGia < @DonGia";
                            cmd.Parameters.AddWithValue("@DonGia", donGia);
                        }
                    }
                    else if (donGiaText.Contains(">"))
                    {
                        string[] parts = donGiaText.Split('>');
                        if (parts.Length == 2 && decimal.TryParse(parts[1].Trim(), out decimal donGia))
                        {
                            query += " AND m.DonGia > @DonGia";
                            cmd.Parameters.AddWithValue("@DonGia", donGia);
                        }
                    }
                    else if (donGiaText.Contains("-"))
                    {
                        // Tìm trong khoảng giá
                        string[] parts = donGiaText.Split('-');
                        if (parts.Length == 2 &&
                            decimal.TryParse(parts[0].Trim(), out decimal giaMin) &&
                            decimal.TryParse(parts[1].Trim(), out decimal giaMax))
                        {
                            query += " AND m.DonGia BETWEEN @GiaMin AND @GiaMax";
                            cmd.Parameters.AddWithValue("@GiaMin", giaMin);
                            cmd.Parameters.AddWithValue("@GiaMax", giaMax);
                        }
                    }
                    else if (decimal.TryParse(donGiaText, out decimal donGia))
                    {
                        // Tìm giá chính xác
                        query += " AND m.DonGia = @DonGia";
                        cmd.Parameters.AddWithValue("@DonGia", donGia);
                    }
                    else
                    {
                        MessageBox.Show("Định dạng giá không hợp lệ!\nSử dụng một trong các định dạng sau:\n- Số (vd: 50000)\n- Khoảng (vd: 20000-50000)\n- Lớn hơn (vd: >20000)\n- Nhỏ hơn (vd: <50000)",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Tìm theo hàng tồn
                if (!string.IsNullOrEmpty(hangTonText))
                {
                    if (int.TryParse(hangTonText, out int hangTon))
                    {
                        query += " AND m.HangTon = @HangTon";
                        cmd.Parameters.AddWithValue("@HangTon", hangTon);
                    }
                    else
                    {
                        MessageBox.Show("Hàng tồn phải là số nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Tìm theo nhóm món
                if (comboBoxNhomMon.SelectedValue != null && comboBoxNhomMon.SelectedIndex > -1)
                {
                    query += " AND m.NhomMonID = @NhomMonID";
                    cmd.Parameters.AddWithValue("@NhomMonID", comboBoxNhomMon.SelectedValue);
                }

                query += " ORDER BY m.MonID";
                cmd.CommandText = query;

                // Thực hiện tìm kiếm
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Hiển thị kết quả
                dataGrVMenu.DataSource = dt;
                dataGrVMenu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Định dạng lại các cột
                if (dt.Rows.Count > 0)
                {
                    dataGrVMenu.Columns["MonID"].HeaderText = "Mã món";
                    dataGrVMenu.Columns["TenMon"].HeaderText = "Tên món";
                    dataGrVMenu.Columns["DonGia"].HeaderText = "Đơn giá";
                    dataGrVMenu.Columns["NhomMon"].HeaderText = "Nhóm món";
                    dataGrVMenu.Columns["HangTon"].HeaderText = "Hàng tồn";
                    dataGrVMenu.Columns["NhomMonID"].Visible = false;
                    dataGrVMenu.Columns["DonGia"].DefaultCellStyle.Format = "N0";

                    MessageBox.Show($"Tìm thấy {dt.Rows.Count} kết quả!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy món nào phù hợp!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reset các trường tìm kiếm
                txtTenMon.Clear();
                txtDonGia.Clear();
                txtHangTon.Clear();
                comboBoxNhomMon.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                MenuItemDTO mon = new MenuItemDTO
                {
                    TenMon = txtTenMon.Text.Trim(),
                    DonGia = decimal.Parse(txtDonGia.Text),
                    NhomMonID = Convert.ToInt32(comboBoxNhomMon.SelectedValue),
                    HangTon = int.Parse(txtHangTon.Text)
                };
                if (menuBLL.ThemMon(mon))
                {
                    MessageBox.Show("Thêm món thành công!");
                    LoadMon();
                }
                else
                {
                    MessageBox.Show("Thêm món thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm món: " + ex.Message);
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrVMenu.CurrentRow == null) return;
                MenuItemDTO mon = new MenuItemDTO
                {
                    MonID = Convert.ToInt32(dataGrVMenu.CurrentRow.Cells["MonID"].Value),
                    TenMon = txtTenMon.Text.Trim(),
                    DonGia = decimal.Parse(txtDonGia.Text),
                    NhomMonID = Convert.ToInt32(comboBoxNhomMon.SelectedValue),
                    HangTon = int.Parse(txtHangTon.Text)
                };
                if (menuBLL.SuaMon(mon))
                {
                    MessageBox.Show("Sửa món thành công!");
                    LoadMon();
                }
                else
                {
                    MessageBox.Show("Sửa món thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa món: " + ex.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrVMenu.CurrentRow == null) return;
                int monID = Convert.ToInt32(dataGrVMenu.CurrentRow.Cells["MonID"].Value);
                if (menuBLL.XoaMon(monID))
                {
                    MessageBox.Show("Xóa món thành công!");
                    LoadMon();
                }
                else
                {
                    MessageBox.Show("Xóa món thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa món: " + ex.Message);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            txtTenMon.Clear();
            txtDonGia.Clear();
            txtHangTon.Clear();
            comboBoxNhomMon.SelectedIndex = -1;
            LoadMon();
        }

        private void dataGrVMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGrVMenu.Rows[e.RowIndex];
                txtTenMon.Text = row.Cells["TenMon"].Value.ToString();
                txtDonGia.Text = (Convert.ToDecimal(row.Cells["DonGia"].Value)).ToString();
                txtHangTon.Text = row.Cells["HangTon"].Value.ToString();
                comboBoxNhomMon.SelectedValue = row.Cells["NhomMonID"].Value;
            }
        }

        // --- TAB NHÂN VIÊN ---
        void LoadNhanVien()
        {
            try
            {
                DataTable dt = nhanVienBLL.GetAllNhanVien();

                dataGrVNV.DataSource = null;
                dataGrVNV.Columns.Clear();

                dataGrVNV.DataSource = dt;

            
                // Other configurations remain unchanged
                dataGrVNV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGrVNV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGrVNV.ReadOnly = true;
                dataGrVNV.AllowUserToAddRows = false;
                dataGrVNV.AllowUserToDeleteRows = false;

                foreach (DataGridViewColumn col in dataGrVNV.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dataGrVNV.Columns.Contains("MaNhanVien"))
                    dataGrVNV.Columns["MaNhanVien"].HeaderText = "Mã NV";
                if (dataGrVNV.Columns.Contains("TenNhanVien"))
                    dataGrVNV.Columns["TenNhanVien"].HeaderText = "Tên nhân viên";
                if (dataGrVNV.Columns.Contains("MatKhau"))
                    dataGrVNV.Columns["MatKhau"].HeaderText = "Mật khẩu";
                if (dataGrVNV.Columns.Contains("VaiTro"))
                    dataGrVNV.Columns["VaiTro"].HeaderText = "Vai trò";

                if (dataGrVNV.Columns.Contains("TrangThai"))
                {
                    int idx = dataGrVNV.Columns["TrangThai"].Index;
                    dataGrVNV.Columns.Remove("TrangThai");
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.Name = "TrangThai";
                    chk.HeaderText = "Trạng thái";
                    chk.DataPropertyName = "TrangThai";
                    chk.ReadOnly = true;
                    dataGrVNV.Columns.Insert(idx, chk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân viên: " + ex.Message);
            }
        }

     



     

        private void btSuaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrVNV.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
                    return;
                }

                int nhanVienID = Convert.ToInt32(dataGrVNV.CurrentRow.Cells["NhanVienID"].Value);
                string tenNV = txtTenNV.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                string vaiTro = comboBoxChucVu.Text.Trim();

                if (string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(vaiTro))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                // **BỔ SUNG NhanVienID**
                NhanVienDTO nv = new NhanVienDTO
                {
                    NhanVienID = nhanVienID, // <-- BỔ SUNG DÒNG NÀY
                    TenNhanVien = tenNV,
                    MatKhau = matKhau,
                    VaiTro = vaiTro
                };

                if (nhanVienBLL.SuaNhanVien(nv))
                {
                    MessageBox.Show("Sửa nhân viên thành công!");
                    LoadNhanVien();
                    txtTenNV.Clear();
                    txtMatKhau.Clear();
                    comboBoxChucVu.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Sửa nhân viên thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa nhân viên: " + ex.Message);
            }
        }

        private void btXoaNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGrVNV.CurrentRow == null) return;
                int nhanVienID = Convert.ToInt32(dataGrVNV.CurrentRow.Cells["NhanVienID"].Value);
                if (nhanVienBLL.XoaNhanVien(nhanVienID))
                {
                    MessageBox.Show("Xóa nhân viên thành công!");
                    LoadNhanVien();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa nhân viên: " + ex.Message);
            }
        }

        private void dataGrVNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGrVNV.Rows[e.RowIndex];
                txtTenNV.Text = row.Cells["TenNhanVien"].Value?.ToString();
                comboBoxChucVu.Text = row.Cells["VaiTro"].Value?.ToString();

            }
        }

        // --- TAB HÓA ĐƠN ---
        private void btXemHD_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime tuNgay = dateTimePickerFrom.Value.Date;
                DateTime denNgay = dateTimePickerTo.Value.Date;
                string query = @"SELECT h.HoaDonID, h.MaHoaDon, h.NgayGio, 
                h.KhachHangID, h.BuzzerID, h.GiamGia, h.TongTien,
                h.KhuyenMaiID, h.NhanVienID, h.GhiChu
                FROM HoaDon h 
                WHERE CAST(h.NgayGio AS DATE) BETWEEN @TuNgay AND @DenNgay
                ORDER BY h.HoaDonID";  // Bỏ DESC để sắp xếp tăng dần

                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                da.SelectCommand.Parameters.AddWithValue("@TuNgay", tuNgay);
                da.SelectCommand.Parameters.AddWithValue("@DenNgay", denNgay);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Thiết lập SelectionMode trước khi gán DataSource
                dataGrVBills.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGrVBills.DataSource = dt;

                // Đặt SortMode = NotSortable cho tất cả các cột
                foreach (DataGridViewColumn col in dataGrVBills.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // Format tên cột tiếng Việt
                dataGrVBills.Columns["HoaDonID"].HeaderText = "ID";
                dataGrVBills.Columns["MaHoaDon"].HeaderText = "Mã hóa đơn";
                dataGrVBills.Columns["NgayGio"].HeaderText = "Ngày giờ";
                dataGrVBills.Columns["KhachHangID"].HeaderText = "Mã KH";
                dataGrVBills.Columns["BuzzerID"].HeaderText = "Mã Buzzer";
                dataGrVBills.Columns["GiamGia"].HeaderText = "Giảm giá";
                dataGrVBills.Columns["TongTien"].HeaderText = "Tổng tiền";
                dataGrVBills.Columns["KhuyenMaiID"].HeaderText = "Mã KM";
                dataGrVBills.Columns["NhanVienID"].HeaderText = "Mã NV";
                dataGrVBills.Columns["GhiChu"].HeaderText = "Ghi chú";

                // Format hiển thị
                dataGrVBills.Columns["TongTien"].DefaultCellStyle.Format = "N0";
                dataGrVBills.Columns["GiamGia"].DefaultCellStyle.Format = "N0";

                // Căn giữa các cột số
                dataGrVBills.Columns["HoaDonID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGrVBills.Columns["KhachHangID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGrVBills.Columns["BuzzerID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGrVBills.Columns["GiamGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGrVBills.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGrVBills.Columns["KhuyenMaiID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGrVBills.Columns["NhanVienID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // AutoSize cho các cột
                dataGrVBills.AutoResizeColumns();
                dataGrVBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xem hóa đơn: " + ex.Message);
            }
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Workbooks.Add(Type.Missing);
            for (int i = 0; i < dataGrVBills.Columns.Count; i++)
                excel.Cells[1, i + 1] = dataGrVBills.Columns[i].HeaderText;
            for (int i = 0; i < dataGrVBills.Rows.Count; i++)
                for (int j = 0; j < dataGrVBills.Columns.Count; j++)
                    excel.Cells[i + 2, j + 1] = dataGrVBills.Rows[i].Cells[j].Value?.ToString();
            excel.Columns.AutoFit();
            excel.Visible = true;
        }

        // --- TAB KHO ---
        private void LoadKho()
        {
            try
            {
                string query = @"SELECT m.MonID, m.TenMon, m.HangTon, nm.TenNhom 
            FROM Mon m
            JOIN NhomMon nm ON m.NhomMonID = nm.NhomMonID
            ORDER BY nm.TenNhom, m.TenMon";

                using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGrVKho.DataSource = dt;
                    dataGrVKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGrVKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGrVKho.AllowUserToAddRows = false;
                    dataGrVKho.AllowUserToDeleteRows = false;
                    dataGrVKho.ReadOnly = true;

                    // Đặt SortMode = NotSortable cho tất cả các cột
                    foreach (DataGridViewColumn col in dataGrVKho.Columns)
                    {
                        col.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }

                    dataGrVKho.Columns["MonID"].Visible = false;
                    dataGrVKho.Columns["TenMon"].HeaderText = "Tên món";
                    dataGrVKho.Columns["HangTon"].HeaderText = "Số lượng tồn";
                    dataGrVKho.Columns["TenNhom"].HeaderText = "Nhóm món";
                    dataGrVKho.Columns["HangTon"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGrVKho.Columns["TenNhom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load kho: " + ex.Message);
            }
        }

        private void btnXemKho_Click(object sender, EventArgs e)
        {
            LoadKho();
        }

        private void btnCanhBaoSapHet_Click(object sender, EventArgs e)
        {
            try
            {
                const int NGUONG_TON_TOI_THIEU = 10; // Ngưỡng cảnh báo hàng tồn

                string query = @"SELECT m.TenMon, m.HangTon, nm.TenNhom 
                        FROM Mon m
                        JOIN NhomMon nm ON m.NhomMonID = nm.NhomMonID
                        WHERE m.HangTon <= @NguongTon
                        ORDER BY m.HangTon ASC";

                using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@NguongTon", NGUONG_TON_TOI_THIEU);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Hiển thị dữ liệu trên DataGridView
                        dataGrVKho.DataSource = dt;

                        // Định dạng lại DataGridView
                        dataGrVKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGrVKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGrVKho.ReadOnly = true;

                        // Format tên cột
                        dataGrVKho.Columns["TenMon"].HeaderText = "Tên món";
                        dataGrVKho.Columns["HangTon"].HeaderText = "Số lượng tồn";
                        dataGrVKho.Columns["TenNhom"].HeaderText = "Nhóm món";

                        // Tạo thông báo chi tiết
                        string thongBao = $"Có {dt.Rows.Count} món cần nhập thêm hàng (dưới {NGUONG_TON_TOI_THIEU}):\n\n";
                        foreach (DataRow row in dt.Rows)
                        {
                            thongBao += $"- {row["TenMon"]}: còn {row["HangTon"]} {(int.Parse(row["HangTon"].ToString()) <= 5 ? "(GẤP!)" : "")}\n";
                        }

                        MessageBox.Show(thongBao, "Cảnh báo hàng tồn thấp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Không có món nào tồn kho dưới {NGUONG_TON_TOI_THIEU}!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKho(); // Tải lại toàn bộ kho nếu không có cảnh báo
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra hàng tồn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNhapHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTenSP.Text))
                {
                    MessageBox.Show("Vui lòng chọn món cần nhập thêm!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int soLuongThem = (int)numericUpDownKho.Value;

                if (soLuongThem <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng lớn hơn 0!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string updateQuery = "UPDATE Mon SET HangTon = HangTon + @SoLuongThem WHERE TenMon = @TenMon";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    MoKetNoi();
                    cmd.Parameters.AddWithValue("@SoLuongThem", soLuongThem);
                    cmd.Parameters.AddWithValue("@TenMon", txtTenSP.Text.Trim());

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Đã nhập thêm {soLuongThem} {txtTenSP.Text} vào kho!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKho(); // Refresh lại datagridview
                        numericUpDownKho.Value = 0; // Reset về 0
                        txtTenSP.Clear(); // Xóa tên sản phẩm
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm này trong kho!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập hàng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                DongKetNoi();
            }
        }

        // Thêm sự kiện SelectionChanged để đảm bảo việc chọn sản phẩm luôn được cập nhật
        private void dataGrVKho_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGrVKho.CurrentRow != null)
            {
                if (dataGrVKho.CurrentRow.Cells["TenMon"] != null &&
                    dataGrVKho.CurrentRow.Cells["TenMon"].Value != null)
                {
                    txtTenSP.Text = dataGrVKho.CurrentRow.Cells["TenMon"].Value.ToString();
                }
            }
        }

        private void dataGrVKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGrVKho.Rows[e.RowIndex];
                if (row.Cells["TenMon"] != null && row.Cells["TenMon"].Value != null)
                {
                    txtTenSP.Text = row.Cells["TenMon"].Value.ToString();
                    // Chọn toàn bộ dòng để người dùng thấy rõ đang chọn món nào
                    dataGrVKho.Rows[e.RowIndex].Selected = true;
                }
            }
        }

        private void btLamMoiKho_Click(object sender, EventArgs e)
        {
            LoadKho();
            txtTenSP.Clear();
        }

        // --- TAB THỐNG KÊ ---
        private void LoadBaoCaoDoanhThu(DateTime fromDate, DateTime toDate)
        {

            try
            {
                DataTable dt = hoadonBLL.ThongKeDoanhThu(fromDate, toDate);
                dataGrVDoanhThu.DataSource = dt;
                dataGrVDoanhThu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in dataGrVDoanhThu.Columns)
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;

                if (dt.Rows.Count > 0)
                    MessageBox.Show("Báo cáo đã được tải thành công.", "Báo cáo doanh thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Không có hóa đơn trong khoảng thời gian này.", "Báo cáo doanh thu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy báo cáo doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btXuatBC_Click(object sender, EventArgs e)
        {
            // Tạo một ứng dụng Excel mới
            Excel.Application excel = new Excel.Application();
            excel.Workbooks.Add(Type.Missing);

            // Lấy dữ liệu từ DataGridView hoặc từ cơ sở dữ liệu để xuất
            // Giả sử bạn đã có DataTable dt chứa dữ liệu cần xuất

            // Đặt tiêu đề cột
            for (int i = 0; i < dataGrVDoanhThu.Columns.Count; i++)
            {
                excel.Cells[1, i + 1] = dataGrVDoanhThu.Columns[i].HeaderText;
            }

            // Đặt dữ liệu
            for (int i = 0; i < dataGrVDoanhThu.Rows.Count; i++)
            {
                for (int j = 0; j < dataGrVDoanhThu.Columns.Count; j++)
                {
                    excel.Cells[i + 2, j + 1] = dataGrVDoanhThu.Rows[i].Cells[j].Value?.ToString();
                }
            }

            // Tự động điều chỉnh kích thước cột
            excel.Columns.AutoFit();

            // Hiển thị Excel
            excel.Visible = true;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoadNhomMon();
            LoadMon();
            LoadNhanVien();
            LoadKho();
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {

        }

        private void btDX_MN_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
               "Xác nhận đăng xuất",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide(); // Ẩn form admin hiện tại
                FormLogin formLogin = new FormLogin();
                formLogin.Show(); // Hiển thị form đăng nhập
                this.Close(); // Đóng form admin
            }
        }

        private void btCanhBao_Click(object sender, EventArgs e)
        {
            try
            {
                const int NGUONG_TON_TOI_THIEU = 10;

                string query = @"SELECT m.MonID, m.TenMon, m.HangTon, nm.TenNhom 
                FROM Mon m
                JOIN NhomMon nm ON m.NhomMonID = nm.NhomMonID
                WHERE m.HangTon <= @NguongTon
                ORDER BY m.HangTon ASC";

                using (SqlConnection conn = new SqlConnection(connection.ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@NguongTon", NGUONG_TON_TOI_THIEU);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Cập nhật DataGridView để hiển thị danh sách sản phẩm cần chú ý
                        dataGrVKho.DataSource = dt;

                        // Định dạng lại DataGridView
                        dataGrVKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGrVKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dataGrVKho.ReadOnly = true;

                        dataGrVKho.Columns["TenMon"].HeaderText = "Tên món";
                        dataGrVKho.Columns["HangTon"].HeaderText = "Số lượng tồn";
                        dataGrVKho.Columns["TenNhom"].HeaderText = "Nhóm món";

                        // Hiển thị thông báo tổng quát
                        MessageBox.Show($"Có {dt.Rows.Count} món cần nhập thêm hàng (dưới {NGUONG_TON_TOI_THIEU})!",
                            "Cảnh báo hàng tồn thấp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"Không có món nào tồn kho dưới {NGUONG_TON_TOI_THIEU}!",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKho(); // Tải lại toàn bộ kho nếu không có cảnh báo
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra hàng tồn: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Thêm một test button click đơn giản
        private void btNhapHang_Click_Test(object sender, EventArgs e)
        {
            MessageBox.Show("Test click event");
        }


        // Tab Thống Kê
        private void btXemBC_Click(object sender, EventArgs e)
        {
            string thoiGian = comboBoxThoiGian.SelectedItem?.ToString();
            DateTime fromDate = DateTime.Today, toDate = DateTime.Today;

            switch (thoiGian)
            {
                case "Hôm nay":
                    toDate = fromDate.AddDays(1);
                    break;
                case "Tuần này":
                    int dayOfWeek = (int)DateTime.Today.DayOfWeek;
                    fromDate = fromDate.AddDays(-dayOfWeek);
                    toDate = fromDate.AddDays(7);
                    break;
                case "Tháng này":
                    fromDate = new DateTime(fromDate.Year, fromDate.Month, 1);
                    toDate = fromDate.AddMonths(1);
                    break;
                case "Năm nay":
                    fromDate = new DateTime(fromDate.Year, 1, 1);
                    toDate = new DateTime(fromDate.Year + 1, 1, 1);
                    break;
            }

            LoadBaoCaoDoanhThu(fromDate, toDate);
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NgayGio", typeof(DateTime));
            dt.Columns.Add("TongTien", typeof(decimal));

            // Thêm dữ liệu mẫu
            dt.Rows.Add(DateTime.Parse("2025-05-01"), 10000);
            dt.Rows.Add(DateTime.Parse("2025-05-02"), 20000); // Đảm bảo có dữ liệu cho ngày 2/5/2025

            // Kiểm tra dữ liệu
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"Ngày: {row["NgayGio"]}, Tổng tiền: {row["TongTien"]}");
            }

            return dt;
        }

        private DataTable GetFilteredData(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NgayGio", typeof(DateTime));
            dt.Columns.Add("TongTien", typeof(decimal));

            string query = @"SELECT NgayGio, TongTien FROM HoaDon 
                     WHERE NgayGio BETWEEN @FromDate AND @ToDate";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@FromDate", fromDate);
                cmd.Parameters.AddWithValue("@ToDate", toDate);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }

        private void dataGrVMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnXuatBieuDo_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatBieuDo_Click_1(object sender, EventArgs e)
        {
            if (comboBoxThoiGian.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một mục thời gian.");
                return;
            }

            DateTime fromDate = DateTime.Today;
            DateTime toDate = DateTime.Today;
            string xAxisFormat = "HH:mm"; // Mặc định cho hôm nay
            List<string> timePoints = new List<string>();

            switch (comboBoxThoiGian.SelectedItem.ToString())
            {
                case "Hôm nay":
                    toDate = fromDate.AddDays(1);
                    xAxisFormat = "HH:mm";
                    for (int hour = 0; hour < 24; hour++)
                    {
                        timePoints.Add(hour.ToString("00") + ":00");
                    }
                    break;
                case "Tuần này":
                    fromDate = fromDate.AddDays(-(int)DateTime.Today.DayOfWeek);
                    toDate = fromDate.AddDays(7);
                    xAxisFormat = "dd/MM";
                    for (DateTime date = fromDate; date < toDate; date = date.AddDays(1))
                    {
                        timePoints.Add(date.ToString("dd/MM"));
                    }
                    break;
                case "Tháng này":
                    fromDate = new DateTime(fromDate.Year, fromDate.Month, 1);
                    toDate = fromDate.AddMonths(1);
                    xAxisFormat = "Tuần";
                    for (int week = 1; week <= 4; week++)
                    {
                        timePoints.Add($"Tuần {week} - Tháng {fromDate.Month}");
                    }
                    break;
                case "Năm nay":
                    fromDate = new DateTime(fromDate.Year, 1, 1);
                    toDate = fromDate.AddYears(1);
                    xAxisFormat = "MM/yyyy";
                    for (int month = 1; month <= 12; month++)
                    {
                        timePoints.Add(new DateTime(fromDate.Year, month, 1).ToString("MM/yyyy"));
                    }
                    break;
                default:
                    MessageBox.Show("Lựa chọn không hợp lệ.");
                    return;
            }

            try
            {
                DataTable dt = GetFilteredData(fromDate, toDate);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                    return;
                }

                // Tổng hợp dữ liệu
                var groupedData = dt.AsEnumerable()
                    .GroupBy(row =>
                    {
                        DateTime ngayGio = row.Field<DateTime>("NgayGio");
                        switch (comboBoxThoiGian.SelectedItem.ToString())
                        {
                            case "Hôm nay":
                                return ngayGio.ToString("HH:00");
                            case "Tuần này":
                                return ngayGio.ToString("dd/MM");
                            case "Tháng này":
                                int weekOfMonth = (ngayGio.Day - 1) / 7 + 1;
                                return $"Tuần {weekOfMonth} - Tháng {ngayGio.Month}";
                            case "Năm nay":
                                return ngayGio.ToString("MM/yyyy");
                            default:
                                return ngayGio.ToString("dd/MM/yyyy");
                        }
                    })
                    .ToDictionary(g => g.Key, g => g.Sum(row => Convert.ToDouble(row["TongTien"])));

                Chart chart = new Chart
                {
                    Size = new Size(600, 400),
                    Dock = DockStyle.Fill
                };

                ChartArea chartArea = new ChartArea("MainArea");
                chart.ChartAreas.Add(chartArea);

                Series series = new Series("Doanh thu")
                {
                    ChartType = SeriesChartType.Column
                };

                // Thêm cột cho mỗi mốc thời gian
                foreach (var timePoint in timePoints)
                {
                    double tongTien = groupedData.ContainsKey(timePoint) ? groupedData[timePoint] : 0;
                    series.Points.AddXY(timePoint, tongTien);
                }

                chart.Series.Add(series);

                Form chartForm = new Form
                {
                    Text = "Biểu đồ Doanh thu",
                    Size = new Size(650, 450)
                };
                chartForm.Controls.Add(chart);
                chartForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGrVMenu_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGrVNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int GetNextNhanVienNumber()
        {
            try
            {
                // Lấy danh sách tất cả các số trong mã NV hiện có
                string query = "SELECT MaNhanVien FROM NhanVien WHERE MaNhanVien LIKE 'NV%'";
                List<int> existingNumbers = new List<int>();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    MoKetNoi();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maNV = reader["MaNhanVien"].ToString();
                            if (maNV.StartsWith("NV") && int.TryParse(maNV.Substring(2), out int number))
                            {
                                existingNumbers.Add(number);
                            }
                        }
                    }
                    DongKetNoi();
                }

                // Nếu không có nhân viên nào
                if (existingNumbers.Count == 0)
                    return 1;

                // Sắp xếp các số hiện có
                existingNumbers.Sort();

                // Tìm số còn trống đầu tiên
                int expectedNumber = 1;
                foreach (int number in existingNumbers)
                {
                    if (number != expectedNumber)
                        return expectedNumber;
                    expectedNumber++;
                }

                // Nếu không có số nào bị trống, trả về số tiếp theo
                return existingNumbers[existingNumbers.Count - 1] + 1;
            }
            catch
            {
                return 1; // Trả về 1 nếu có lỗi
            }
        }


        private void btThemNV_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenNV.Text) || comboBoxChucVu.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string tenNV = txtTenNV.Text.Trim();
                string chucVu = comboBoxChucVu.Text.Trim();
                string matKhau = txtMatKhau.Text.Trim();
                // Tạo mã nhân viên tự động dạng NV + số
                string maNV = "NV" + GetNextNhanVienNumber();

                string query = @"INSERT INTO NhanVien (MaNhanVien, TenNhanVien, MatKhau, VaiTro) 
                    VALUES (@MaNhanVien, @TenNhanVien, @MatKhau, @VaiTro)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNV);
                    cmd.Parameters.AddWithValue("@TenNhanVien", tenNV);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmd.Parameters.AddWithValue("@VaiTro", chucVu);

                    MoKetNoi();
                    cmd.ExecuteNonQuery();
                    DongKetNoi();
                }

                LoadNhanVien();
                MessageBox.Show($"Thêm nhân viên thành công!\nMã nhân viên: {maNV}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtTenNV.Clear();
                txtMatKhau.Clear();
                comboBoxChucVu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

