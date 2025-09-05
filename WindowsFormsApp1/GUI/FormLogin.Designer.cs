namespace WindowsFormsApp1.GUI
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.lbMaNV = new System.Windows.Forms.Label();
            this.lbMatKhau = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.btDangNhap = new System.Windows.Forms.Button();
            this.cMK = new System.Windows.Forms.CheckBox();
            this.ktraLoiNhapLieu = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbWelcome = new System.Windows.Forms.Label();
            this.timerWelcome = new System.Windows.Forms.Timer(this.components);
            this.timerNhapNhay = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ktraLoiNhapLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // lbMaNV
            // 
            this.lbMaNV.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaNV.ForeColor = System.Drawing.Color.Olive;
            this.lbMaNV.Location = new System.Drawing.Point(129, 107);
            this.lbMaNV.Name = "lbMaNV";
            this.lbMaNV.Size = new System.Drawing.Size(208, 36);
            this.lbMaNV.TabIndex = 0;
            this.lbMaNV.Text = "Mã nhân viên :";
            // 
            // lbMatKhau
            // 
            this.lbMatKhau.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMatKhau.ForeColor = System.Drawing.Color.Olive;
            this.lbMatKhau.Location = new System.Drawing.Point(129, 162);
            this.lbMatKhau.Name = "lbMatKhau";
            this.lbMatKhau.Size = new System.Drawing.Size(162, 39);
            this.lbMatKhau.TabIndex = 1;
            this.lbMatKhau.Text = "Mật khẩu : ";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaNV.Location = new System.Drawing.Point(343, 106);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(258, 39);
            this.txtMaNV.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.Location = new System.Drawing.Point(343, 162);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(258, 39);
            this.txtMatKhau.TabIndex = 2;
            // 
            // btDangNhap
            // 
            this.btDangNhap.BackColor = System.Drawing.Color.DarkKhaki;
            this.btDangNhap.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangNhap.ForeColor = System.Drawing.Color.LemonChiffon;
            this.btDangNhap.Location = new System.Drawing.Point(216, 242);
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.Size = new System.Drawing.Size(188, 53);
            this.btDangNhap.TabIndex = 4;
            this.btDangNhap.Text = "Đăng nhập";
            this.btDangNhap.UseVisualStyleBackColor = false;
            this.btDangNhap.Click += new System.EventHandler(this.btDangNhap_Click);
            // 
            // cMK
            // 
            this.cMK.AutoSize = true;
            this.cMK.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cMK.ForeColor = System.Drawing.Color.Olive;
            this.cMK.Location = new System.Drawing.Point(607, 165);
            this.cMK.Name = "cMK";
            this.cMK.Size = new System.Drawing.Size(94, 36);
            this.cMK.TabIndex = 3;
            this.cMK.Text = "Hiện";
            this.cMK.UseVisualStyleBackColor = true;
            this.cMK.CheckedChanged += new System.EventHandler(this.cMK_CheckedChanged);
            // 
            // ktraLoiNhapLieu
            // 
            this.ktraLoiNhapLieu.ContainerControl = this;
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.Khaki;
            this.lbWelcome.Font = new System.Drawing.Font("Segoe UI", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.Olive;
            this.lbWelcome.Location = new System.Drawing.Point(137, -3);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(525, 59);
            this.lbWelcome.TabIndex = 5;
            this.lbWelcome.Text = "WELCOME TO N&&B CAFÉ";
            this.lbWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerWelcome
            // 
            this.timerWelcome.Enabled = true;
            this.timerWelcome.Interval = 20;
            this.timerWelcome.Tick += new System.EventHandler(this.timerWelcome_Tick);
            // 
            // timerNhapNhay
            // 
            this.timerNhapNhay.Enabled = true;
            this.timerNhapNhay.Interval = 300;
            this.timerNhapNhay.Tick += new System.EventHandler(this.timerNhapNhay_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(644, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 6;
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.DarkKhaki;
            this.btExit.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExit.ForeColor = System.Drawing.Color.LemonChiffon;
            this.btExit.Location = new System.Drawing.Point(427, 242);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(188, 53);
            this.btExit.TabIndex = 7;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = false;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(830, 395);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbWelcome);
            this.Controls.Add(this.cMK);
            this.Controls.Add(this.btDangNhap);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lbMatKhau);
            this.Controls.Add(this.lbMaNV);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ktraLoiNhapLieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbMaNV;
        private System.Windows.Forms.Label lbMatKhau;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btDangNhap;
        private System.Windows.Forms.CheckBox cMK;
        private System.Windows.Forms.ErrorProvider ktraLoiNhapLieu;
        private System.Windows.Forms.Label lbWelcome;
        private System.Windows.Forms.Timer timerWelcome;
        private System.Windows.Forms.Timer timerNhapNhay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btExit;
    }
}

