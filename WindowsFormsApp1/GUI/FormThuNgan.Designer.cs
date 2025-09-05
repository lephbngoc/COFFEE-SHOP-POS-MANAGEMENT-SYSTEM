using System.Windows.Forms;
using System;

namespace WindowsFormsApp1.GUI
{
    partial class FormThuNgan
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //// Ví dụ: lấy item được chọn và hiển thị ra MessageBox
            //string selectedItem = comboBox1.SelectedItem?.ToString();
            //MessageBox.Show("Anh yêu đã chọn: " + selectedItem, "Thông báo");
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormThuNgan));
            this.btDangXuat = new System.Windows.Forms.Button();
            this.timerWelcome = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoaiKhach = new System.Windows.Forms.ComboBox();
            this.cboBuzzer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btThanhVien = new System.Windows.Forms.Button();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvMenu = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LB = new System.Windows.Forms.Panel();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cboMaMon = new System.Windows.Forms.ComboBox();
            this.label = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbGia = new System.Windows.Forms.Label();
            this.cboNhomMon = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btGiaoCa = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.label13 = new System.Windows.Forms.Label();
            this.lbTong = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lbTienThua = new System.Windows.Forms.Label();
            this.txtTienKhachDua = new System.Windows.Forms.TextBox();
            this.btThanhToan = new System.Windows.Forms.Button();
            this.btInHoaDon = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblKhuyenMai = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.lbWelcome = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).BeginInit();
            this.LB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            this.SuspendLayout();
            // 
            // btDangXuat
            // 
            this.btDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDangXuat.BackColor = System.Drawing.Color.DarkKhaki;
            this.btDangXuat.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangXuat.ForeColor = System.Drawing.Color.LemonChiffon;
            this.btDangXuat.Location = new System.Drawing.Point(1056, 697);
            this.btDangXuat.Name = "btDangXuat";
            this.btDangXuat.Size = new System.Drawing.Size(165, 41);
            this.btDangXuat.TabIndex = 1;
            this.btDangXuat.Text = "Đăng xuất";
            this.btDangXuat.UseVisualStyleBackColor = false;
            this.btDangXuat.Click += new System.EventHandler(this.btDangXuat_Click);
            // 
            // timerWelcome
            // 
            this.timerWelcome.Enabled = true;
            this.timerWelcome.Interval = 50;
            this.timerWelcome.Tick += new System.EventHandler(this.timerWelcome_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Loại khách";
            // 
            // cboLoaiKhach
            // 
            this.cboLoaiKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLoaiKhach.FormattingEnabled = true;
            this.cboLoaiKhach.Location = new System.Drawing.Point(118, 24);
            this.cboLoaiKhach.Name = "cboLoaiKhach";
            this.cboLoaiKhach.Size = new System.Drawing.Size(152, 28);
            this.cboLoaiKhach.TabIndex = 0;
            this.cboLoaiKhach.SelectedIndexChanged += new System.EventHandler(this.cboLoaiKhach_SelectedIndexChanged);
            // 
            // cboBuzzer
            // 
            this.cboBuzzer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuzzer.FormattingEnabled = true;
            this.cboBuzzer.Location = new System.Drawing.Point(365, 23);
            this.cboBuzzer.Name = "cboBuzzer";
            this.cboBuzzer.Size = new System.Drawing.Size(121, 28);
            this.cboBuzzer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label2.Location = new System.Drawing.Point(288, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Buzzer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label4.Location = new System.Drawing.Point(981, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mã hóa đơn: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btThanhVien);
            this.panel1.Controls.Add(this.lblMaHoaDon);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboLoaiKhach);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cboBuzzer);
            this.panel1.Location = new System.Drawing.Point(1, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1243, 75);
            this.panel1.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(662, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 37);
            this.button2.TabIndex = 17;
            this.button2.Text = "Khuyến mãi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(503, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 37);
            this.button1.TabIndex = 16;
            this.button1.Text = "Trả buzzer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btThanhVien
            // 
            this.btThanhVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThanhVien.Location = new System.Drawing.Point(821, 18);
            this.btThanhVien.Name = "btThanhVien";
            this.btThanhVien.Size = new System.Drawing.Size(147, 37);
            this.btThanhVien.TabIndex = 15;
            this.btThanhVien.Text = "Thành viên";
            this.btThanhVien.UseVisualStyleBackColor = true;
            this.btThanhVien.Click += new System.EventHandler(this.btThanhVien_Click);
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblMaHoaDon.Location = new System.Drawing.Point(1107, 27);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(106, 20);
            this.lblMaHoaDon.TabIndex = 14;
            this.lblMaHoaDon.Text = "mã hóa đơn";
            this.lblMaHoaDon.Click += new System.EventHandler(this.lblMaHoaDon_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvMenu);
            this.panel2.Location = new System.Drawing.Point(17, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 244);
            this.panel2.TabIndex = 16;
            // 
            // dgvMenu
            // 
            this.dgvMenu.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.dgvMenu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMenu.Location = new System.Drawing.Point(0, 0);
            this.dgvMenu.MultiSelect = false;
            this.dgvMenu.Name = "dgvMenu";
            this.dgvMenu.RowHeadersWidth = 51;
            this.dgvMenu.RowTemplate.Height = 24;
            this.dgvMenu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMenu.Size = new System.Drawing.Size(766, 244);
            this.dgvMenu.TabIndex = 0;
            this.dgvMenu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellClick);
            this.dgvMenu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMenu_CellContentClick);
            this.dgvMenu.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMenu_DataBindingComplete);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label6.Location = new System.Drawing.Point(13, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Menu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label7.Location = new System.Drawing.Point(808, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 19;
            this.label7.Text = "Hóa đơn";
            // 
            // LB
            // 
            this.LB.Controls.Add(this.btXoa);
            this.LB.Controls.Add(this.btSua);
            this.LB.Controls.Add(this.btThem);
            this.LB.Controls.Add(this.txtGhiChu);
            this.LB.Controls.Add(this.label11);
            this.LB.Controls.Add(this.txtTenMon);
            this.LB.Controls.Add(this.nudSoLuong);
            this.LB.Controls.Add(this.cboMaMon);
            this.LB.Controls.Add(this.label);
            this.LB.Controls.Add(this.label12);
            this.LB.Controls.Add(this.lbGia);
            this.LB.Controls.Add(this.cboNhomMon);
            this.LB.Controls.Add(this.label10);
            this.LB.Controls.Add(this.label9);
            this.LB.Controls.Add(this.label8);
            this.LB.Location = new System.Drawing.Point(17, 490);
            this.LB.Name = "LB";
            this.LB.Size = new System.Drawing.Size(766, 248);
            this.LB.TabIndex = 20;
            // 
            // btXoa
            // 
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(523, 197);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(119, 29);
            this.btXoa.TabIndex = 7;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSua.Location = new System.Drawing.Point(289, 197);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(119, 29);
            this.btSua.TabIndex = 6;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThem.Location = new System.Drawing.Point(55, 197);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(119, 29);
            this.btThem.TabIndex = 5;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(566, 145);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(178, 27);
            this.txtGhiChu.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label11.Location = new System.Drawing.Point(443, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 20);
            this.label11.TabIndex = 9;
            this.label11.Text = "Ghi chú";
            // 
            // txtTenMon
            // 
            this.txtTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMon.Location = new System.Drawing.Point(138, 87);
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(152, 27);
            this.txtTenMon.TabIndex = 2;
            this.txtTenMon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenMon_KeyDown);
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudSoLuong.Location = new System.Drawing.Point(566, 84);
            this.nudSoLuong.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(178, 27);
            this.nudSoLuong.TabIndex = 3;
            // 
            // cboMaMon
            // 
            this.cboMaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMaMon.FormattingEnabled = true;
            this.cboMaMon.Location = new System.Drawing.Point(566, 21);
            this.cboMaMon.Name = "cboMaMon";
            this.cboMaMon.Size = new System.Drawing.Size(178, 28);
            this.cboMaMon.TabIndex = 1;
            this.cboMaMon.SelectedIndexChanged += new System.EventHandler(this.cboMaMon_SelectedIndexChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label.Location = new System.Drawing.Point(443, 25);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 20);
            this.label.TabIndex = 0;
            this.label.Text = "Mã món";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label12.Location = new System.Drawing.Point(439, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 7;
            this.label12.Text = "Số lượng";
            // 
            // lbGia
            // 
            this.lbGia.AutoSize = true;
            this.lbGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGia.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lbGia.Location = new System.Drawing.Point(134, 145);
            this.lbGia.Name = "lbGia";
            this.lbGia.Size = new System.Drawing.Size(38, 20);
            this.lbGia.TabIndex = 8;
            this.lbGia.Text = "Giá";
            // 
            // cboNhomMon
            // 
            this.cboNhomMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhomMon.FormattingEnabled = true;
            this.cboNhomMon.Location = new System.Drawing.Point(138, 21);
            this.cboNhomMon.Name = "cboNhomMon";
            this.cboNhomMon.Size = new System.Drawing.Size(152, 28);
            this.cboNhomMon.TabIndex = 0;
            this.cboNhomMon.SelectedIndexChanged += new System.EventHandler(this.cboNhomMon_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label10.Location = new System.Drawing.Point(13, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tên món";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label9.Location = new System.Drawing.Point(13, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Giá (VNĐ)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label8.Location = new System.Drawing.Point(13, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nhóm món";
            // 
            // btGiaoCa
            // 
            this.btGiaoCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btGiaoCa.BackColor = System.Drawing.Color.DarkKhaki;
            this.btGiaoCa.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGiaoCa.ForeColor = System.Drawing.Color.LemonChiffon;
            this.btGiaoCa.Location = new System.Drawing.Point(857, 697);
            this.btGiaoCa.Name = "btGiaoCa";
            this.btGiaoCa.Size = new System.Drawing.Size(137, 41);
            this.btGiaoCa.TabIndex = 0;
            this.btGiaoCa.Text = "Giao ca";
            this.btGiaoCa.UseVisualStyleBackColor = false;
            this.btGiaoCa.Click += new System.EventHandler(this.btGiaoCa_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.printPreviewDialog1_FormClosed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label13.Location = new System.Drawing.Point(3, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 20);
            this.label13.TabIndex = 5;
            this.label13.Text = "Tổng (VNĐ)";
            // 
            // lbTong
            // 
            this.lbTong.AutoSize = true;
            this.lbTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTong.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lbTong.Location = new System.Drawing.Point(186, 24);
            this.lbTong.Name = "lbTong";
            this.lbTong.Size = new System.Drawing.Size(0, 20);
            this.lbTong.TabIndex = 19;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label15.Location = new System.Drawing.Point(3, 109);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "Tiền thừa";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label16.Location = new System.Drawing.Point(3, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(136, 20);
            this.label16.TabIndex = 18;
            this.label16.Text = "Tiền khách đưa";
            // 
            // lbTienThua
            // 
            this.lbTienThua.AutoSize = true;
            this.lbTienThua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienThua.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lbTienThua.Location = new System.Drawing.Point(186, 109);
            this.lbTienThua.Name = "lbTienThua";
            this.lbTienThua.Size = new System.Drawing.Size(0, 20);
            this.lbTienThua.TabIndex = 21;
            // 
            // txtTienKhachDua
            // 
            this.txtTienKhachDua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKhachDua.Location = new System.Drawing.Point(190, 67);
            this.txtTienKhachDua.Name = "txtTienKhachDua";
            this.txtTienKhachDua.Size = new System.Drawing.Size(217, 27);
            this.txtTienKhachDua.TabIndex = 0;
            this.txtTienKhachDua.TextChanged += new System.EventHandler(this.txtTienKhachDua_TextChanged_1);
            this.txtTienKhachDua.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTienKhachDua_KeyPress);
            this.txtTienKhachDua.Leave += new System.EventHandler(this.txtTienKhachDua_Leave);
            // 
            // btThanhToan
            // 
            this.btThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btThanhToan.Location = new System.Drawing.Point(36, 184);
            this.btThanhToan.Name = "btThanhToan";
            this.btThanhToan.Size = new System.Drawing.Size(137, 36);
            this.btThanhToan.TabIndex = 1;
            this.btThanhToan.Text = "Thanh toán";
            this.btThanhToan.UseVisualStyleBackColor = true;
            this.btThanhToan.Click += new System.EventHandler(this.btThanhToan_Click_1);
            // 
            // btInHoaDon
            // 
            this.btInHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInHoaDon.Location = new System.Drawing.Point(235, 184);
            this.btInHoaDon.Name = "btInHoaDon";
            this.btInHoaDon.Size = new System.Drawing.Size(165, 36);
            this.btInHoaDon.TabIndex = 2;
            this.btInHoaDon.Text = "In hóa đơn";
            this.btInHoaDon.UseVisualStyleBackColor = true;
            this.btInHoaDon.Click += new System.EventHandler(this.btInHoaDon_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblKhuyenMai);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.btInHoaDon);
            this.panel3.Controls.Add(this.btThanhToan);
            this.panel3.Controls.Add(this.txtTienKhachDua);
            this.panel3.Controls.Add(this.lbTienThua);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.lbTong);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Location = new System.Drawing.Point(821, 462);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(423, 223);
            this.panel3.TabIndex = 2;
            // 
            // lblKhuyenMai
            // 
            this.lblKhuyenMai.AutoSize = true;
            this.lblKhuyenMai.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhuyenMai.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lblKhuyenMai.Location = new System.Drawing.Point(187, 148);
            this.lblKhuyenMai.Name = "lblKhuyenMai";
            this.lblKhuyenMai.Size = new System.Drawing.Size(0, 19);
            this.lblKhuyenMai.TabIndex = 24;
            this.lblKhuyenMai.Click += new System.EventHandler(this.lblKhuyenMai_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.label5.Location = new System.Drawing.Point(3, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Giảm giá";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvBill);
            this.panel4.Location = new System.Drawing.Point(821, 213);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(423, 243);
            this.panel4.TabIndex = 23;
            // 
            // dgvBill
            // 
            this.dgvBill.BackgroundColor = System.Drawing.Color.DarkKhaki;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Location = new System.Drawing.Point(0, 0);
            this.dgvBill.MultiSelect = false;
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.RowHeadersWidth = 51;
            this.dgvBill.RowTemplate.Height = 24;
            this.dgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBill.Size = new System.Drawing.Size(423, 243);
            this.dgvBill.TabIndex = 4;
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.Khaki;
            this.lbWelcome.Font = new System.Drawing.Font("Segoe UI", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.Olive;
            this.lbWelcome.Location = new System.Drawing.Point(362, 9);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(525, 59);
            this.lbWelcome.TabIndex = 24;
            this.lbWelcome.Text = "WELCOME TO N&&B CAFÉ";
            this.lbWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormThuNgan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkKhaki;
            this.ClientSize = new System.Drawing.Size(1266, 750);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btGiaoCa);
            this.Controls.Add(this.LB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btDangXuat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormThuNgan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thu Ngân";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormThuNgan_FormClosing);
            this.Load += new System.EventHandler(this.FormThuNgan_Load_1);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMenu)).EndInit();
            this.LB.ResumeLayout(false);
            this.LB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btDangXuat;
        private System.Windows.Forms.Timer timerWelcome;
        private System.Windows.Forms.Label label3;
        private Label label1;
        private ComboBox cboLoaiKhach;
        private ComboBox cboBuzzer;
        private Label label2;
        private Label label4;
        private Panel panel1;
        private Panel panel2;
        private DataGridView dgvMenu;
        private Label label6;
        private Label label7;
        private Panel LB;
        private ComboBox cboNhomMon;
        private Label label10;
        private Label label9;
        private Label label8;
        private ComboBox cboMaMon;
        private Label label;
        private Label label12;
        private Label lbGia;
        private NumericUpDown nudSoLuong;
        private TextBox txtTenMon;
        private TextBox txtGhiChu;
        private Label label11;
        private Button btXoa;
        private Button btSua;
        private Button btThem;
        private Button btGiaoCa;
        private Label lblMaHoaDon;
        private Button btThanhVien;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
        private Label label13;
        private Label lbTong;
        private Label label15;
        private Label label16;
        private Label lbTienThua;
        private TextBox txtTienKhachDua;
        private Button btThanhToan;
        private Button btInHoaDon;
        private Panel panel3;
        private Panel panel4;
        private Label lbWelcome;
        private DataGridView dgvBill;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label lblKhuyenMai;
    }
}