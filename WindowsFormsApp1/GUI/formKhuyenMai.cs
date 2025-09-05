using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DAL;

namespace WindowsFormsApp1.GUI
{
    public partial class formKhuyenMai : Form
    {
        public int? SelectedKhuyenMaiID { get; private set; }
        public float SelectedPhanTramGiam { get; private set; }
        public string SelectedTenKhuyenMai { get; private set; }

        public formKhuyenMai()
        {
            InitializeComponent();
            LoadKhuyenMai();
            btChon.Click += btnChon_Click;
            btHuy.Click += (s, e) => this.Close();
        }

        private void LoadKhuyenMai()
        {
            var bll = new KhuyenMaiBLL();
            dgvKhuyenMai.DataSource = bll.GetKhuyenMaiDangApDung();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            if (dgvKhuyenMai.SelectedRows.Count > 0)
            {
                var row = dgvKhuyenMai.SelectedRows[0];
                SelectedKhuyenMaiID = Convert.ToInt32(row.Cells["KhuyenMaiID"].Value);
                SelectedPhanTramGiam = float.Parse(row.Cells["PhanTramGiam"].Value.ToString());
                SelectedTenKhuyenMai = row.Cells["TenKhuyenMai"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khuyến mãi!");
            }
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btXoaKM_Click(object sender, EventArgs e)
        {
            {
                // Trả về trạng thái không áp dụng khuyến mãi
                SelectedKhuyenMaiID = null;
                SelectedPhanTramGiam = 0;
                SelectedTenKhuyenMai = "";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}