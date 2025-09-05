namespace WindowsFormsApp1
{
    partial class FormAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.QLMenu = new System.Windows.Forms.TabPage();
            this.btDX_MN = new System.Windows.Forms.Button();
            this.dataGrVMenu = new System.Windows.Forms.DataGridView();
            this.pnMenu = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHangTon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btTimKiemMon = new System.Windows.Forms.Button();
            this.comboBoxNhomMon = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btRefresh = new System.Windows.Forms.Button();
            this.lbTenMon = new System.Windows.Forms.Label();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.QLNhanVien = new System.Windows.Forms.TabPage();
            this.btDangXuat_2 = new System.Windows.Forms.Button();
            this.dataGrVNV = new System.Windows.Forms.DataGridView();
            this.pnNV = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.comboBoxChucVu = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btXoaNV = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btSuaNV = new System.Windows.Forms.Button();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.btThemNV = new System.Windows.Forms.Button();
            this.QLHoaDon = new System.Windows.Forms.TabPage();
            this.btDX_HD = new System.Windows.Forms.Button();
            this.dataGrVBills = new System.Windows.Forms.DataGridView();
            this.pnBills = new System.Windows.Forms.Panel();
            this.btXuatExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btXemHD = new System.Windows.Forms.Button();
            this.To = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.QLKho = new System.Windows.Forms.TabPage();
            this.btDX_Kho = new System.Windows.Forms.Button();
            this.dataGrVKho = new System.Windows.Forms.DataGridView();
            this.pnQLKho = new System.Windows.Forms.Panel();
            this.btLamMoiKho = new System.Windows.Forms.Button();
            this.numericUpDownKho = new System.Windows.Forms.NumericUpDown();
            this.btNhapHang = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btCanhBao = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.ThongKe = new System.Windows.Forms.TabPage();
            this.btDX_DT = new System.Windows.Forms.Button();
            this.dataGrVDoanhThu = new System.Windows.Forms.DataGridView();
            this.pnDoanhThu = new System.Windows.Forms.Panel();
            this.btnXuatBieuDo = new System.Windows.Forms.Button();
            this.comboBoxThoiGian = new System.Windows.Forms.ComboBox();
            this.btXuatBC = new System.Windows.Forms.Button();
            this.btXemBC = new System.Windows.Forms.Button();
            this.mainTab.SuspendLayout();
            this.QLMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVMenu)).BeginInit();
            this.pnMenu.SuspendLayout();
            this.QLNhanVien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVNV)).BeginInit();
            this.pnNV.SuspendLayout();
            this.QLHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVBills)).BeginInit();
            this.pnBills.SuspendLayout();
            this.QLKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVKho)).BeginInit();
            this.pnQLKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKho)).BeginInit();
            this.ThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVDoanhThu)).BeginInit();
            this.pnDoanhThu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÉ NÁI ĐANG YÊU DỢ ";
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.QLMenu);
            this.mainTab.Controls.Add(this.QLNhanVien);
            this.mainTab.Controls.Add(this.QLHoaDon);
            this.mainTab.Controls.Add(this.QLKho);
            this.mainTab.Controls.Add(this.ThongKe);
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTab.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTab.Location = new System.Drawing.Point(0, 0);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(1106, 450);
            this.mainTab.TabIndex = 1;
            // 
            // QLMenu
            // 
            this.QLMenu.BackColor = System.Drawing.Color.Beige;
            this.QLMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QLMenu.Controls.Add(this.btDX_MN);
            this.QLMenu.Controls.Add(this.dataGrVMenu);
            this.QLMenu.Controls.Add(this.pnMenu);
            this.QLMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.QLMenu.Location = new System.Drawing.Point(4, 28);
            this.QLMenu.Name = "QLMenu";
            this.QLMenu.Padding = new System.Windows.Forms.Padding(3);
            this.QLMenu.Size = new System.Drawing.Size(1098, 418);
            this.QLMenu.TabIndex = 0;
            this.QLMenu.Text = "Quản lý Menu";
            // 
            // btDX_MN
            // 
            this.btDX_MN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDX_MN.BackColor = System.Drawing.Color.DarkKhaki;
            this.btDX_MN.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDX_MN.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btDX_MN.Location = new System.Drawing.Point(949, 355);
            this.btDX_MN.Name = "btDX_MN";
            this.btDX_MN.Size = new System.Drawing.Size(141, 54);
            this.btDX_MN.TabIndex = 2;
            this.btDX_MN.Text = "Đăng xuất";
            this.btDX_MN.UseVisualStyleBackColor = false;
            this.btDX_MN.Click += new System.EventHandler(this.btDX_MN_Click);
            // 
            // dataGrVMenu
            // 
            this.dataGrVMenu.AllowUserToAddRows = false;
            this.dataGrVMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrVMenu.BackgroundColor = System.Drawing.Color.Beige;
            this.dataGrVMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrVMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrVMenu.GridColor = System.Drawing.Color.Olive;
            this.dataGrVMenu.Location = new System.Drawing.Point(3, 153);
            this.dataGrVMenu.MultiSelect = false;
            this.dataGrVMenu.Name = "dataGrVMenu";
            this.dataGrVMenu.RowHeadersWidth = 51;
            this.dataGrVMenu.RowTemplate.Height = 24;
            this.dataGrVMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrVMenu.Size = new System.Drawing.Size(1090, 260);
            this.dataGrVMenu.TabIndex = 1;
            this.dataGrVMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrVMenu_CellClick);
            this.dataGrVMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrVMenu_CellContentClick_1);
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnMenu.Controls.Add(this.label3);
            this.pnMenu.Controls.Add(this.txtHangTon);
            this.pnMenu.Controls.Add(this.label5);
            this.pnMenu.Controls.Add(this.btTimKiemMon);
            this.pnMenu.Controls.Add(this.comboBoxNhomMon);
            this.pnMenu.Controls.Add(this.label4);
            this.pnMenu.Controls.Add(this.btRefresh);
            this.pnMenu.Controls.Add(this.lbTenMon);
            this.pnMenu.Controls.Add(this.txtDonGia);
            this.pnMenu.Controls.Add(this.btXoa);
            this.pnMenu.Controls.Add(this.btSua);
            this.pnMenu.Controls.Add(this.btThem);
            this.pnMenu.Controls.Add(this.txtTenMon);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnMenu.Location = new System.Drawing.Point(3, 3);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(1090, 150);
            this.pnMenu.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label3.Location = new System.Drawing.Point(764, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hàng tồn";
            // 
            // txtHangTon
            // 
            this.txtHangTon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtHangTon.Location = new System.Drawing.Point(858, 74);
            this.txtHangTon.Name = "txtHangTon";
            this.txtHangTon.Size = new System.Drawing.Size(212, 27);
            this.txtHangTon.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label5.Location = new System.Drawing.Point(747, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nhóm Món";
            // 
            // btTimKiemMon
            // 
            this.btTimKiemMon.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btTimKiemMon.ForeColor = System.Drawing.Color.Olive;
            this.btTimKiemMon.Location = new System.Drawing.Point(512, 22);
            this.btTimKiemMon.Name = "btTimKiemMon";
            this.btTimKiemMon.Size = new System.Drawing.Size(153, 45);
            this.btTimKiemMon.TabIndex = 5;
            this.btTimKiemMon.Text = "Tìm Kiếm";
            this.btTimKiemMon.UseVisualStyleBackColor = false;
            this.btTimKiemMon.Click += new System.EventHandler(this.btTimKiemMon_Click);
            // 
            // comboBoxNhomMon
            // 
            this.comboBoxNhomMon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxNhomMon.FormattingEnabled = true;
            this.comboBoxNhomMon.Items.AddRange(new object[] {
            "Đồ ăn",
            "Đồ uống"});
            this.comboBoxNhomMon.Location = new System.Drawing.Point(858, 107);
            this.comboBoxNhomMon.Name = "comboBoxNhomMon";
            this.comboBoxNhomMon.Size = new System.Drawing.Size(136, 27);
            this.comboBoxNhomMon.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label4.Location = new System.Drawing.Point(764, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Đơn Giá";
            // 
            // btRefresh
            // 
            this.btRefresh.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btRefresh.ForeColor = System.Drawing.Color.Olive;
            this.btRefresh.Location = new System.Drawing.Point(338, 23);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(153, 45);
            this.btRefresh.TabIndex = 4;
            this.btRefresh.Text = "Làm Mới";
            this.btRefresh.UseVisualStyleBackColor = false;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // lbTenMon
            // 
            this.lbTenMon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTenMon.AutoSize = true;
            this.lbTenMon.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenMon.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lbTenMon.Location = new System.Drawing.Point(764, 11);
            this.lbTenMon.Name = "lbTenMon";
            this.lbTenMon.Size = new System.Drawing.Size(74, 19);
            this.lbTenMon.TabIndex = 5;
            this.lbTenMon.Text = "Tên Món";
            // 
            // txtDonGia
            // 
            this.txtDonGia.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtDonGia.Location = new System.Drawing.Point(858, 41);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(212, 27);
            this.txtDonGia.TabIndex = 2;
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btXoa.ForeColor = System.Drawing.Color.Olive;
            this.btXoa.Location = new System.Drawing.Point(159, 76);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(132, 45);
            this.btXoa.TabIndex = 3;
            this.btXoa.Text = "Xóa ";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btSua.ForeColor = System.Drawing.Color.Olive;
            this.btSua.Location = new System.Drawing.Point(18, 76);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(132, 45);
            this.btSua.TabIndex = 2;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = false;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btThem.ForeColor = System.Drawing.Color.Olive;
            this.btThem.Location = new System.Drawing.Point(92, 22);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(132, 45);
            this.btThem.TabIndex = 1;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = false;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTenMon.Location = new System.Drawing.Point(858, 8);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(212, 27);
            this.txtTenMon.TabIndex = 2;
            // 
            // QLNhanVien
            // 
            this.QLNhanVien.BackColor = System.Drawing.SystemColors.Control;
            this.QLNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QLNhanVien.Controls.Add(this.btDangXuat_2);
            this.QLNhanVien.Controls.Add(this.dataGrVNV);
            this.QLNhanVien.Controls.Add(this.pnNV);
            this.QLNhanVien.Location = new System.Drawing.Point(4, 28);
            this.QLNhanVien.Name = "QLNhanVien";
            this.QLNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.QLNhanVien.Size = new System.Drawing.Size(1098, 418);
            this.QLNhanVien.TabIndex = 1;
            this.QLNhanVien.Text = "Quản lý Nhân viên";
            // 
            // btDangXuat_2
            // 
            this.btDangXuat_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDangXuat_2.BackColor = System.Drawing.Color.DarkKhaki;
            this.btDangXuat_2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangXuat_2.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btDangXuat_2.Location = new System.Drawing.Point(953, 358);
            this.btDangXuat_2.Name = "btDangXuat_2";
            this.btDangXuat_2.Size = new System.Drawing.Size(136, 51);
            this.btDangXuat_2.TabIndex = 2;
            this.btDangXuat_2.Text = "Đăng xuất";
            this.btDangXuat_2.UseVisualStyleBackColor = false;
            this.btDangXuat_2.Click += new System.EventHandler(this.btDX_MN_Click);
            // 
            // dataGrVNV
            // 
            this.dataGrVNV.AllowUserToAddRows = false;
            this.dataGrVNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrVNV.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dataGrVNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrVNV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrVNV.Location = new System.Drawing.Point(3, 128);
            this.dataGrVNV.MultiSelect = false;
            this.dataGrVNV.Name = "dataGrVNV";
            this.dataGrVNV.RowHeadersWidth = 51;
            this.dataGrVNV.RowTemplate.Height = 24;
            this.dataGrVNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrVNV.Size = new System.Drawing.Size(1090, 285);
            this.dataGrVNV.TabIndex = 1;
            this.dataGrVNV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrVNV_CellClick);
            this.dataGrVNV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrVNV_CellContentClick);
            // 
            // pnNV
            // 
            this.pnNV.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnNV.Controls.Add(this.label6);
            this.pnNV.Controls.Add(this.txtMatKhau);
            this.pnNV.Controls.Add(this.comboBoxChucVu);
            this.pnNV.Controls.Add(this.label8);
            this.pnNV.Controls.Add(this.btXoaNV);
            this.pnNV.Controls.Add(this.label7);
            this.pnNV.Controls.Add(this.btSuaNV);
            this.pnNV.Controls.Add(this.txtTenNV);
            this.pnNV.Controls.Add(this.btThemNV);
            this.pnNV.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnNV.Location = new System.Drawing.Point(3, 3);
            this.pnNV.Name = "pnNV";
            this.pnNV.Size = new System.Drawing.Size(1090, 125);
            this.pnNV.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label6.Location = new System.Drawing.Point(793, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtMatKhau.Location = new System.Drawing.Point(886, 90);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(169, 27);
            this.txtMatKhau.TabIndex = 6;
            // 
            // comboBoxChucVu
            // 
            this.comboBoxChucVu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.comboBoxChucVu.FormattingEnabled = true;
            this.comboBoxChucVu.Items.AddRange(new object[] {
            "Quản Lý",
            "Nhân viên"});
            this.comboBoxChucVu.Location = new System.Drawing.Point(886, 54);
            this.comboBoxChucVu.Name = "comboBoxChucVu";
            this.comboBoxChucVu.Size = new System.Drawing.Size(169, 27);
            this.comboBoxChucVu.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label8.Location = new System.Drawing.Point(796, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 19);
            this.label8.TabIndex = 4;
            this.label8.Text = "Chức Vụ";
            // 
            // btXoaNV
            // 
            this.btXoaNV.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btXoaNV.ForeColor = System.Drawing.Color.Olive;
            this.btXoaNV.Location = new System.Drawing.Point(223, 21);
            this.btXoaNV.Name = "btXoaNV";
            this.btXoaNV.Size = new System.Drawing.Size(206, 45);
            this.btXoaNV.TabIndex = 2;
            this.btXoaNV.Text = "Xóa nhân viên";
            this.btXoaNV.UseVisualStyleBackColor = false;
            this.btXoaNV.Click += new System.EventHandler(this.btXoaNV_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label7.Location = new System.Drawing.Point(801, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 4;
            this.label7.Text = "Tên NV";
            // 
            // btSuaNV
            // 
            this.btSuaNV.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btSuaNV.ForeColor = System.Drawing.Color.Olive;
            this.btSuaNV.Location = new System.Drawing.Point(435, 21);
            this.btSuaNV.Name = "btSuaNV";
            this.btSuaNV.Size = new System.Drawing.Size(174, 45);
            this.btSuaNV.TabIndex = 2;
            this.btSuaNV.Text = "Sửa nhân viên";
            this.btSuaNV.UseVisualStyleBackColor = false;
            this.btSuaNV.Click += new System.EventHandler(this.btSuaNV_Click);
            // 
            // txtTenNV
            // 
            this.txtTenNV.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTenNV.Location = new System.Drawing.Point(886, 18);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(169, 27);
            this.txtTenNV.TabIndex = 2;
            // 
            // btThemNV
            // 
            this.btThemNV.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btThemNV.ForeColor = System.Drawing.Color.Olive;
            this.btThemNV.Location = new System.Drawing.Point(15, 21);
            this.btThemNV.Name = "btThemNV";
            this.btThemNV.Size = new System.Drawing.Size(206, 45);
            this.btThemNV.TabIndex = 2;
            this.btThemNV.Text = "Thêm nhân viên";
            this.btThemNV.UseVisualStyleBackColor = false;
            this.btThemNV.Click += new System.EventHandler(this.btThemNV_Click);
            // 
            // QLHoaDon
            // 
            this.QLHoaDon.BackColor = System.Drawing.SystemColors.Control;
            this.QLHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QLHoaDon.Controls.Add(this.btDX_HD);
            this.QLHoaDon.Controls.Add(this.dataGrVBills);
            this.QLHoaDon.Controls.Add(this.pnBills);
            this.QLHoaDon.Location = new System.Drawing.Point(4, 28);
            this.QLHoaDon.Name = "QLHoaDon";
            this.QLHoaDon.Padding = new System.Windows.Forms.Padding(3);
            this.QLHoaDon.Size = new System.Drawing.Size(1098, 418);
            this.QLHoaDon.TabIndex = 2;
            this.QLHoaDon.Text = "Quản lý Hóa đơn";
            // 
            // btDX_HD
            // 
            this.btDX_HD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDX_HD.BackColor = System.Drawing.Color.DarkKhaki;
            this.btDX_HD.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDX_HD.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btDX_HD.Location = new System.Drawing.Point(938, 351);
            this.btDX_HD.Name = "btDX_HD";
            this.btDX_HD.Size = new System.Drawing.Size(151, 58);
            this.btDX_HD.TabIndex = 3;
            this.btDX_HD.Text = "Đăng xuất";
            this.btDX_HD.UseVisualStyleBackColor = false;
            this.btDX_HD.Click += new System.EventHandler(this.btDX_MN_Click);
            // 
            // dataGrVBills
            // 
            this.dataGrVBills.AllowUserToAddRows = false;
            this.dataGrVBills.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dataGrVBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrVBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrVBills.Location = new System.Drawing.Point(3, 79);
            this.dataGrVBills.MultiSelect = false;
            this.dataGrVBills.Name = "dataGrVBills";
            this.dataGrVBills.RowHeadersWidth = 51;
            this.dataGrVBills.RowTemplate.Height = 24;
            this.dataGrVBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrVBills.Size = new System.Drawing.Size(1090, 334);
            this.dataGrVBills.TabIndex = 2;
            // 
            // pnBills
            // 
            this.pnBills.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnBills.Controls.Add(this.btXuatExcel);
            this.pnBills.Controls.Add(this.label2);
            this.pnBills.Controls.Add(this.btXemHD);
            this.pnBills.Controls.Add(this.To);
            this.pnBills.Controls.Add(this.dateTimePickerTo);
            this.pnBills.Controls.Add(this.dateTimePickerFrom);
            this.pnBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnBills.Location = new System.Drawing.Point(3, 3);
            this.pnBills.Name = "pnBills";
            this.pnBills.Size = new System.Drawing.Size(1090, 76);
            this.pnBills.TabIndex = 1;
            // 
            // btXuatExcel
            // 
            this.btXuatExcel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btXuatExcel.ForeColor = System.Drawing.Color.Olive;
            this.btXuatExcel.Location = new System.Drawing.Point(811, 16);
            this.btXuatExcel.Name = "btXuatExcel";
            this.btXuatExcel.Size = new System.Drawing.Size(200, 46);
            this.btXuatExcel.TabIndex = 3;
            this.btXuatExcel.Text = "Xuất Excel";
            this.btXuatExcel.UseVisualStyleBackColor = false;
            this.btXuatExcel.Click += new System.EventHandler(this.btXuatExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Cornsilk;
            this.label2.Location = new System.Drawing.Point(21, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 35);
            this.label2.TabIndex = 3;
            this.label2.Text = "From";
            // 
            // btXemHD
            // 
            this.btXemHD.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btXemHD.ForeColor = System.Drawing.Color.Olive;
            this.btXemHD.Location = new System.Drawing.Point(592, 16);
            this.btXemHD.Name = "btXemHD";
            this.btXemHD.Size = new System.Drawing.Size(200, 46);
            this.btXemHD.TabIndex = 2;
            this.btXemHD.Text = "Xem Hóa Đơn";
            this.btXemHD.UseVisualStyleBackColor = false;
            this.btXemHD.Click += new System.EventHandler(this.btXemHD_Click);
            // 
            // To
            // 
            this.To.AutoSize = true;
            this.To.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.To.ForeColor = System.Drawing.Color.Cornsilk;
            this.To.Location = new System.Drawing.Point(316, 18);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(47, 35);
            this.To.TabIndex = 2;
            this.To.Text = "To";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CalendarFont = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.CalendarForeColor = System.Drawing.Color.Olive;
            this.dateTimePickerTo.CalendarMonthBackground = System.Drawing.Color.LightGoldenrodYellow;
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerTo.Location = new System.Drawing.Point(369, 21);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(177, 27);
            this.dateTimePickerTo.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.CalendarForeColor = System.Drawing.Color.Olive;
            this.dateTimePickerFrom.CalendarMonthBackground = System.Drawing.Color.LightGoldenrodYellow;
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(111, 18);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(177, 27);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // QLKho
            // 
            this.QLKho.BackColor = System.Drawing.SystemColors.Control;
            this.QLKho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QLKho.Controls.Add(this.btDX_Kho);
            this.QLKho.Controls.Add(this.dataGrVKho);
            this.QLKho.Controls.Add(this.pnQLKho);
            this.QLKho.Location = new System.Drawing.Point(4, 28);
            this.QLKho.Name = "QLKho";
            this.QLKho.Padding = new System.Windows.Forms.Padding(3);
            this.QLKho.Size = new System.Drawing.Size(1098, 418);
            this.QLKho.TabIndex = 3;
            this.QLKho.Text = "Quản lý Kho";
            // 
            // btDX_Kho
            // 
            this.btDX_Kho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDX_Kho.BackColor = System.Drawing.Color.DarkKhaki;
            this.btDX_Kho.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDX_Kho.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btDX_Kho.Location = new System.Drawing.Point(950, 358);
            this.btDX_Kho.Name = "btDX_Kho";
            this.btDX_Kho.Size = new System.Drawing.Size(142, 54);
            this.btDX_Kho.TabIndex = 7;
            this.btDX_Kho.Text = "Đăng xuất";
            this.btDX_Kho.UseVisualStyleBackColor = false;
            this.btDX_Kho.Click += new System.EventHandler(this.btDX_MN_Click);
            // 
            // dataGrVKho
            // 
            this.dataGrVKho.AllowUserToAddRows = false;
            this.dataGrVKho.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dataGrVKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrVKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrVKho.Location = new System.Drawing.Point(3, 103);
            this.dataGrVKho.MultiSelect = false;
            this.dataGrVKho.Name = "dataGrVKho";
            this.dataGrVKho.RowHeadersWidth = 51;
            this.dataGrVKho.RowTemplate.Height = 24;
            this.dataGrVKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrVKho.Size = new System.Drawing.Size(1090, 310);
            this.dataGrVKho.TabIndex = 4;
            this.dataGrVKho.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrVKho_CellClick);
            // 
            // pnQLKho
            // 
            this.pnQLKho.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnQLKho.Controls.Add(this.btLamMoiKho);
            this.pnQLKho.Controls.Add(this.numericUpDownKho);
            this.pnQLKho.Controls.Add(this.btNhapHang);
            this.pnQLKho.Controls.Add(this.label11);
            this.pnQLKho.Controls.Add(this.btCanhBao);
            this.pnQLKho.Controls.Add(this.label10);
            this.pnQLKho.Controls.Add(this.txtTenSP);
            this.pnQLKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnQLKho.Location = new System.Drawing.Point(3, 3);
            this.pnQLKho.Name = "pnQLKho";
            this.pnQLKho.Size = new System.Drawing.Size(1090, 100);
            this.pnQLKho.TabIndex = 3;
            // 
            // btLamMoiKho
            // 
            this.btLamMoiKho.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btLamMoiKho.ForeColor = System.Drawing.Color.Olive;
            this.btLamMoiKho.Location = new System.Drawing.Point(354, 17);
            this.btLamMoiKho.Name = "btLamMoiKho";
            this.btLamMoiKho.Size = new System.Drawing.Size(160, 59);
            this.btLamMoiKho.TabIndex = 9;
            this.btLamMoiKho.Text = "Làm mới";
            this.btLamMoiKho.UseVisualStyleBackColor = false;
            this.btLamMoiKho.Click += new System.EventHandler(this.btLamMoiKho_Click);
            // 
            // numericUpDownKho
            // 
            this.numericUpDownKho.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownKho.Location = new System.Drawing.Point(893, 17);
            this.numericUpDownKho.Name = "numericUpDownKho";
            this.numericUpDownKho.Size = new System.Drawing.Size(136, 27);
            this.numericUpDownKho.TabIndex = 8;
            // 
            // btNhapHang
            // 
            this.btNhapHang.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btNhapHang.ForeColor = System.Drawing.Color.Olive;
            this.btNhapHang.Location = new System.Drawing.Point(14, 17);
            this.btNhapHang.Name = "btNhapHang";
            this.btNhapHang.Size = new System.Drawing.Size(151, 59);
            this.btNhapHang.TabIndex = 4;
            this.btNhapHang.Text = "Nhập Hàng";
            this.btNhapHang.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label11.Location = new System.Drawing.Point(761, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 19);
            this.label11.TabIndex = 6;
            this.label11.Text = "Tên sản phẩm";
            // 
            // btCanhBao
            // 
            this.btCanhBao.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btCanhBao.ForeColor = System.Drawing.Color.Olive;
            this.btCanhBao.Location = new System.Drawing.Point(171, 17);
            this.btCanhBao.Name = "btCanhBao";
            this.btCanhBao.Size = new System.Drawing.Size(177, 59);
            this.btCanhBao.TabIndex = 3;
            this.btCanhBao.Text = "Cảnh Báo Sắp Hết";
            this.btCanhBao.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label10.Location = new System.Drawing.Point(789, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 19);
            this.label10.TabIndex = 6;
            this.label10.Text = "Số lượng";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtTenSP.Location = new System.Drawing.Point(893, 57);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(136, 27);
            this.txtTenSP.TabIndex = 5;
            // 
            // ThongKe
            // 
            this.ThongKe.BackColor = System.Drawing.SystemColors.Control;
            this.ThongKe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThongKe.Controls.Add(this.btDX_DT);
            this.ThongKe.Controls.Add(this.dataGrVDoanhThu);
            this.ThongKe.Controls.Add(this.pnDoanhThu);
            this.ThongKe.Location = new System.Drawing.Point(4, 28);
            this.ThongKe.Name = "ThongKe";
            this.ThongKe.Padding = new System.Windows.Forms.Padding(3);
            this.ThongKe.Size = new System.Drawing.Size(1098, 418);
            this.ThongKe.TabIndex = 4;
            this.ThongKe.Text = "Thống kê Doanh thu";
            // 
            // btDX_DT
            // 
            this.btDX_DT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDX_DT.BackColor = System.Drawing.Color.DarkKhaki;
            this.btDX_DT.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDX_DT.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btDX_DT.Location = new System.Drawing.Point(930, 361);
            this.btDX_DT.Name = "btDX_DT";
            this.btDX_DT.Size = new System.Drawing.Size(162, 51);
            this.btDX_DT.TabIndex = 5;
            this.btDX_DT.Text = "Đăng xuất";
            this.btDX_DT.UseVisualStyleBackColor = false;
            this.btDX_DT.Click += new System.EventHandler(this.btDX_MN_Click);
            // 
            // dataGrVDoanhThu
            // 
            this.dataGrVDoanhThu.AllowUserToAddRows = false;
            this.dataGrVDoanhThu.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dataGrVDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrVDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrVDoanhThu.Location = new System.Drawing.Point(3, 87);
            this.dataGrVDoanhThu.MultiSelect = false;
            this.dataGrVDoanhThu.Name = "dataGrVDoanhThu";
            this.dataGrVDoanhThu.RowHeadersWidth = 51;
            this.dataGrVDoanhThu.RowTemplate.Height = 24;
            this.dataGrVDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrVDoanhThu.Size = new System.Drawing.Size(1090, 326);
            this.dataGrVDoanhThu.TabIndex = 4;
            // 
            // pnDoanhThu
            // 
            this.pnDoanhThu.BackColor = System.Drawing.Color.DarkKhaki;
            this.pnDoanhThu.Controls.Add(this.btnXuatBieuDo);
            this.pnDoanhThu.Controls.Add(this.comboBoxThoiGian);
            this.pnDoanhThu.Controls.Add(this.btXuatBC);
            this.pnDoanhThu.Controls.Add(this.btXemBC);
            this.pnDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnDoanhThu.Location = new System.Drawing.Point(3, 3);
            this.pnDoanhThu.Name = "pnDoanhThu";
            this.pnDoanhThu.Size = new System.Drawing.Size(1090, 84);
            this.pnDoanhThu.TabIndex = 3;
            // 
            // btnXuatBieuDo
            // 
            this.btnXuatBieuDo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnXuatBieuDo.ForeColor = System.Drawing.Color.Olive;
            this.btnXuatBieuDo.Location = new System.Drawing.Point(852, 21);
            this.btnXuatBieuDo.Name = "btnXuatBieuDo";
            this.btnXuatBieuDo.Size = new System.Drawing.Size(200, 46);
            this.btnXuatBieuDo.TabIndex = 5;
            this.btnXuatBieuDo.Text = "Xuất dạng biểu đồ";
            this.btnXuatBieuDo.UseVisualStyleBackColor = false;
            this.btnXuatBieuDo.Click += new System.EventHandler(this.btnXuatBieuDo_Click_1);
            // 
            // comboBoxThoiGian
            // 
            this.comboBoxThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThoiGian.FormattingEnabled = true;
            this.comboBoxThoiGian.Items.AddRange(new object[] {
            "Hôm nay",
            "Tuần này",
            "Tháng này",
            "Năm nay"});
            this.comboBoxThoiGian.Location = new System.Drawing.Point(27, 21);
            this.comboBoxThoiGian.Name = "comboBoxThoiGian";
            this.comboBoxThoiGian.Size = new System.Drawing.Size(253, 27);
            this.comboBoxThoiGian.TabIndex = 4;
            // 
            // btXuatBC
            // 
            this.btXuatBC.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btXuatBC.ForeColor = System.Drawing.Color.Olive;
            this.btXuatBC.Location = new System.Drawing.Point(646, 21);
            this.btXuatBC.Name = "btXuatBC";
            this.btXuatBC.Size = new System.Drawing.Size(200, 46);
            this.btXuatBC.TabIndex = 3;
            this.btXuatBC.Text = "Xuất Báo Cáo";
            this.btXuatBC.UseVisualStyleBackColor = false;
            this.btXuatBC.Click += new System.EventHandler(this.btXuatBC_Click);
            // 
            // btXemBC
            // 
            this.btXemBC.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btXemBC.ForeColor = System.Drawing.Color.Olive;
            this.btXemBC.Location = new System.Drawing.Point(440, 21);
            this.btXemBC.Name = "btXemBC";
            this.btXemBC.Size = new System.Drawing.Size(200, 46);
            this.btXemBC.TabIndex = 2;
            this.btXemBC.Text = "Xem Báo Cáo";
            this.btXemBC.UseVisualStyleBackColor = false;
            this.btXemBC.Click += new System.EventHandler(this.btXemBC_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 450);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainTab.ResumeLayout(false);
            this.QLMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVMenu)).EndInit();
            this.pnMenu.ResumeLayout(false);
            this.pnMenu.PerformLayout();
            this.QLNhanVien.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVNV)).EndInit();
            this.pnNV.ResumeLayout(false);
            this.pnNV.PerformLayout();
            this.QLHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVBills)).EndInit();
            this.pnBills.ResumeLayout(false);
            this.pnBills.PerformLayout();
            this.QLKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVKho)).EndInit();
            this.pnQLKho.ResumeLayout(false);
            this.pnQLKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKho)).EndInit();
            this.ThongKe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrVDoanhThu)).EndInit();
            this.pnDoanhThu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage QLMenu;
        private System.Windows.Forms.TabPage QLNhanVien;
        private System.Windows.Forms.TabPage QLKho;
        private System.Windows.Forms.TabPage ThongKe;
        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.DataGridView dataGrVMenu;
        private System.Windows.Forms.Panel pnNV;
        private System.Windows.Forms.DataGridView dataGrVNV;
        private System.Windows.Forms.Button btXoaNV;
        private System.Windows.Forms.Button btSuaNV;
        private System.Windows.Forms.Button btThemNV;
        private System.Windows.Forms.TabPage QLHoaDon;
        private System.Windows.Forms.Panel pnBills;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label To;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button btXuatExcel;
        private System.Windows.Forms.Button btXemHD;
        private System.Windows.Forms.DataGridView dataGrVBills;
        private System.Windows.Forms.DataGridView dataGrVKho;
        private System.Windows.Forms.Panel pnQLKho;
        private System.Windows.Forms.Button btNhapHang;
        private System.Windows.Forms.Button btCanhBao;
        private System.Windows.Forms.DataGridView dataGrVDoanhThu;
        private System.Windows.Forms.Panel pnDoanhThu;
        private System.Windows.Forms.Button btXuatBC;
        private System.Windows.Forms.Button btXemBC;
        private System.Windows.Forms.ComboBox comboBoxThoiGian;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Button btTimKiemMon;
        private System.Windows.Forms.ComboBox comboBoxNhomMon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTenMon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHangTon;
        private System.Windows.Forms.ComboBox comboBoxChucVu;
        private System.Windows.Forms.Button btDX_MN;
        private System.Windows.Forms.Button btDangXuat_2;
        private System.Windows.Forms.Button btDX_HD;
        private System.Windows.Forms.Button btDX_Kho;
        private System.Windows.Forms.Button btDX_DT;
        private System.Windows.Forms.NumericUpDown numericUpDownKho;
        private System.Windows.Forms.Button btLamMoiKho;
        private System.Windows.Forms.Button btnXuatBieuDo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMatKhau;
    }
}