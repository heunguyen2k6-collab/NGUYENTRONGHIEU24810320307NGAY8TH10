using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BAITAPNGAY8TH10
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Chọn mặc định mục đầu tiên của ComboBox khi mở Form
            if (cboLoaiSuCo.Items.Count > 0)
            {
                cboLoaiSuCo.SelectedIndex = 0;
            }
        }

        // 1. Nút "Tải ảnh lỗi"
        private void btnTaiAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn ảnh chụp lỗi";
                openFileDialog.Filter = "Hình ảnh (*.jpg; *.png)|*.jpg;*.png|Tất cả tệp (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picAnhLoi.SizeMode = PictureBoxSizeMode.StretchImage;
                    picAnhLoi.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }

        // 2. Nút "Gửi yêu cầu"
        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            // Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã phiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhieu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNguoiYeuCau.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên người yêu cầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiYeuCau.Focus();
                return;
            }

            // Lấy thông tin Mức độ ưu tiên (RadioButton)
            string mucDoUuTien = "";
            if (rdbThap.Checked) mucDoUuTien = rdbThap.Text;
            else if (rdbTrungBinh.Checked) mucDoUuTien = rdbTrungBinh.Text;
            else if (rdbKhanCap.Checked) mucDoUuTien = rdbKhanCap.Text;

            // Lấy thông tin Loại sự cố (ComboBox)
            string loaiSuCo = cboLoaiSuCo.SelectedItem != null ? cboLoaiSuCo.SelectedItem.ToString() : "Chưa chọn";

            // Lấy danh sách Thiết bị ảnh hưởng (CheckBox)
            List<string> thietBiList = new List<string>();
            if (chkMayTinhBan.Checked) thietBiList.Add(chkMayTinhBan.Text);
            if (chkLaptop.Checked) thietBiList.Add(chkLaptop.Text);
            if (chkMayIn.Checked) thietBiList.Add(chkMayIn.Text);
            if (chkDienThoai.Checked) thietBiList.Add(chkDienThoai.Text);

            string thietBiAnhHuong = thietBiList.Count > 0 ? string.Join(", ", thietBiList) : "Không xác định";

            // Kiểm tra trạng thái ảnh đính kèm
            string trangThaiAnh = (picAnhLoi.Image != null) ? "Đã đính kèm" : "Chưa đính kèm";

            // Tạo chuỗi tóm tắt thông tin
            StringBuilder thongTin = new StringBuilder();
            thongTin.AppendLine("--- THÔNG TIN PHIẾU YÊU CẦU IT ---");
            thongTin.AppendLine($"• Mã phiếu: {txtMaPhieu.Text.Trim()}");
            thongTin.AppendLine($"• Người yêu cầu: {txtNguoiYeuCau.Text.Trim()}");
            thongTin.AppendLine($"• Ngày ghi nhận: {dtpNgayGhiNhan.Value.ToString("dd/MM/yyyy HH:mm")}");
            thongTin.AppendLine($"• Mức độ ưu tiên: {mucDoUuTien}");
            thongTin.AppendLine($"• Loại sự cố: {loaiSuCo}");
            thongTin.AppendLine($"• Thiết bị ảnh hưởng: {thietBiAnhHuong}");
            thongTin.AppendLine($"• Ảnh đính kèm: {trangThaiAnh}");

            // Hiển thị tóm tắt qua MessageBox
            MessageBox.Show(thongTin.ToString(), "Xác nhận gửi thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 3. Nút "Nhập lại"
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            txtNguoiYeuCau.Clear();
            dtpNgayGhiNhan.Value = DateTime.Now;

            rdbThap.Checked = true;

            if (cboLoaiSuCo.Items.Count > 0)
                cboLoaiSuCo.SelectedIndex = 0;

            chkMayTinhBan.Checked = false;
            chkLaptop.Checked = false;
            chkMayIn.Checked = false;
            chkDienThoai.Checked = false;

            if (picAnhLoi.Image != null)
            {
                picAnhLoi.Image.Dispose();
                picAnhLoi.Image = null;
            }

            txtMaPhieu.Focus();
        }
    }
}