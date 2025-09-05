using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.DAL;
using WindowsFormsApp1.DTO;


namespace WindowsFormsApp1.GUI
{
    public partial class FormKhachHang : Form
    {
        private KhachHangBLL khachHangBLL;
        string connectionString = DatabaseConnection.ConnectionString;
        public FormKhachHang()
        {
            InitializeComponent();
            khachHangBLL = new KhachHangBLL();
            this.FormClosing += FormKhachHang_FormClosing;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string sdt = txtSoDienThoai.Text.Trim();
            if (string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                return;
            }

            // Kết nối DB và gọi stored procedure sp_TimKhachHang
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_TimKhachHang", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SoDienThoai", sdt);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtTenKhachHang.Text = reader["TenKhachHang"].ToString();
                    lbDiemTichLuy.Text = reader["DiemTichLuy"].ToString();
                    // Lưu lại KhachHangID nếu cần cho các thao tác khác
                    this.Tag = reader["KhachHangID"];
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
                }
                reader.Close();
            }
        }

        public int KhachHangID { get; private set; }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string tenKhachHang = txtTenKhachHang.Text.Trim();

            if (!string.IsNullOrEmpty(soDienThoai) && !string.IsNullOrEmpty(tenKhachHang))
            {
                DataTable dt = khachHangBLL.TimKhachHang(soDienThoai);
                if (dt.Rows.Count > 0)
                {
                    KhachHangID = Convert.ToInt32(dt.Rows[0]["KhachHangID"]);
                    MessageBox.Show("Khách hàng đã được tìm thấy.");
                }
                else
                {
                    KhachHangDTO khachHang = new KhachHangDTO
                    {
                        SoDienThoai = soDienThoai,
                        TenKhachHang = tenKhachHang,
                        DiemTichLuy = 0
                    };

                    if (khachHangBLL.ThemKhachHang(khachHang))
                    {
                        KhachHangID = khachHangBLL.LayIDKhachHangMoi(soDienThoai);
                        MessageBox.Show("Thêm khách hàng thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm khách hàng thất bại!");
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK; // Để FormThuNgan biết là đã lưu thành công
                this.Close(); // Đóng form
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                MessageBox.Show("Vui lòng tìm khách hàng trước!");
                return;
            }
            int khachHangID = Convert.ToInt32(this.Tag);
            string ten = txtTenKhachHang.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();

            using (SqlConnection conn = new SqlConnection("your_connection_string"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE KhachHang SET TenKhachHang=@Ten, SoDienThoai=@SDT WHERE KhachHangID=@ID", conn);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@SDT", sdt);
                cmd.Parameters.AddWithValue("@ID", khachHangID);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btKhachHangMoi_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (!string.IsNullOrEmpty(soDienThoai))
            {
                DataTable dt = khachHangBLL.TimKhachHang(soDienThoai);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Số điện thoại này đã được đăng ký!");
                }
                else
                {
                    txtTenKhachHang.Clear();
                    lbDiemTichLuy.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
            }
        }

        private int khachHangID;
        private void btKhachHangCu_Click(object sender, EventArgs e)
        {
            string soDienThoai = txtSoDienThoai.Text.Trim();
            if (!string.IsNullOrEmpty(soDienThoai))
            {
                DataTable dt = khachHangBLL.TimKhachHang(soDienThoai);
                if (dt.Rows.Count > 0)
                {
                    khachHangID = Convert.ToInt32(dt.Rows[0]["KhachHangID"]);
                    txtTenKhachHang.Text = dt.Rows[0]["TenKhachHang"].ToString();
                    lbDiemTichLuy.Text = dt.Rows[0]["DiemTichLuy"].ToString();
                    MessageBox.Show("Khách hàng đã được tìm thấy. Điểm tích lũy hiện tại: " + lbDiemTichLuy.Text);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khách hàng!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string ten = txtTenKhachHang.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();

            if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO KhachHang (TenKhachHang, SoDienThoai) VALUES (@Ten, @SDT)", conn);
                cmd.Parameters.AddWithValue("@Ten", ten);
                cmd.Parameters.AddWithValue("@SDT", sdt);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm khách hàng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private bool isFormClosingHandled = false;

        private void FormKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isFormClosingHandled) return; // Ngăn việc xử lý nhiều lần

            if (this.DialogResult != DialogResult.OK) // Chỉ hỏi khi không phải bấm nút Lưu
            {
                var result = MessageBox.Show(
                    "Bạn có chắc chắn muốn thoát? Nếu thoát sẽ không liên kết khách hàng với hóa đơn.",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Không cho đóng form
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel; // Đảm bảo trả về Cancel cho FormThuNgan
                }
            }

            isFormClosingHandled = true; // Đánh dấu đã xử lý
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {

        }
    }
}

