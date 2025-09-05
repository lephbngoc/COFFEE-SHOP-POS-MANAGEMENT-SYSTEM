namespace WindowsFormsApp1.GUI
{
    partial class formKhuyenMai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formKhuyenMai));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.btChon = new System.Windows.Forms.Button();
            this.btHuy = new System.Windows.Forms.Button();
            this.btBoChon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Olive;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Khaki;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH KHUYẾN MÃI ĐANG ÁP DỤNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Location = new System.Drawing.Point(0, 93);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            this.dgvKhuyenMai.ReadOnly = true;
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.RowTemplate.Height = 24;
            this.dgvKhuyenMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(800, 283);
            this.dgvKhuyenMai.TabIndex = 1;
            // 
            // btChon
            // 
            this.btChon.BackColor = System.Drawing.Color.Olive;
            this.btChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btChon.ForeColor = System.Drawing.Color.Khaki;
            this.btChon.Location = new System.Drawing.Point(42, 389);
            this.btChon.Name = "btChon";
            this.btChon.Size = new System.Drawing.Size(146, 49);
            this.btChon.TabIndex = 2;
            this.btChon.Text = "Chọn";
            this.btChon.UseVisualStyleBackColor = false;
            this.btChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btHuy
            // 
            this.btHuy.BackColor = System.Drawing.Color.Olive;
            this.btHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btHuy.ForeColor = System.Drawing.Color.Khaki;
            this.btHuy.Location = new System.Drawing.Point(613, 389);
            this.btHuy.Name = "btHuy";
            this.btHuy.Size = new System.Drawing.Size(146, 49);
            this.btHuy.TabIndex = 3;
            this.btHuy.Text = "Thoát";
            this.btHuy.UseVisualStyleBackColor = false;
            this.btHuy.Click += new System.EventHandler(this.btHuy_Click);
            // 
            // btBoChon
            // 
            this.btBoChon.BackColor = System.Drawing.Color.Olive;
            this.btBoChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBoChon.ForeColor = System.Drawing.Color.Khaki;
            this.btBoChon.Location = new System.Drawing.Point(330, 389);
            this.btBoChon.Name = "btBoChon";
            this.btBoChon.Size = new System.Drawing.Size(146, 49);
            this.btBoChon.TabIndex = 4;
            this.btBoChon.Text = "Bỏ chọn";
            this.btBoChon.UseVisualStyleBackColor = false;
            this.btBoChon.Click += new System.EventHandler(this.btXoaKM_Click);
            // 
            // formKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btBoChon);
            this.Controls.Add(this.btHuy);
            this.Controls.Add(this.btChon);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formKhuyenMai";
            this.Text = "Khuyến Mãi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.Button btChon;
        private System.Windows.Forms.Button btHuy;
        private System.Windows.Forms.Button btBoChon;
    }
}