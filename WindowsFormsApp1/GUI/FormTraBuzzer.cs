using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1.GUI
{
    public partial class FormTraBuzzer : Form
    {
        private BuzzerBLL buzzerBLL = new BuzzerBLL();

        public FormTraBuzzer()
        {
            InitializeComponent();
            Load += FormTraBuzzer_Load;
        }

        private void FormTraBuzzer_Load(object sender, EventArgs e)
        {
            LoadBuzzerDangSuDung();
        }

        private void LoadBuzzerDangSuDung()
        {
            var dt = buzzerBLL.GetUsingBuzzer();
            dgvTraBuzzer.DataSource = dt;
            if (dt.Columns.Contains("BuzzerID"))
                dgvTraBuzzer.Columns["BuzzerID"].Visible = false;
        }

        private void btTraBuzzer_Click(object sender, EventArgs e)
        {

            if (dgvTraBuzzer.CurrentRow == null || dgvTraBuzzer.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn buzzer cần trả!");
                return;
            }
            string soBuzzer = dgvTraBuzzer.CurrentRow.Cells["SoBuzzer"].Value.ToString();
            if (dgvTraBuzzer.SelectedRows.Count > 0)
            {
                int buzzerID = Convert.ToInt32(dgvTraBuzzer.SelectedRows[0].Cells["BuzzerID"].Value);
                if (buzzerBLL.UpdateBuzzerStatus(buzzerID, false)) // false = rảnh
                {
                    MessageBox.Show("Đã trả buzzer thành công!");
                    LoadBuzzerDangSuDung();
                }
                else
                {
                    MessageBox.Show("Trả buzzer thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn buzzer cần trả!");
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTraBuzzer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}