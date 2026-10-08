using System;
using System.Windows.Forms;

namespace BAITAPNGAY8TH10

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện Click nút Tính tiền
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            // 1. Validate dữ liệu ô Đơn giá
            if (!double.TryParse(txtDonGia.Text.Trim(), out double donGia) || donGia < 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá hợp lệ (số không âm)!", "Lỗi nhập liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            // 2. Validate dữ liệu ô Số lượng
            if (!int.TryParse(txtSoLuong.Text.Trim(), out int soLuong) || soLuong < 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng khách hợp lệ (số nguyên không âm)!", "Lỗi nhập liệu",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            // 3. Validate dữ liệu ô Giảm giá (% từ 0 đến 100)
            // Nếu để trống thì mặc định % giảm = 0
            double phanTramGiam = 0;
            if (!string.IsNullOrWhiteSpace(txtGiamGia.Text))
            {
                if (!double.TryParse(txtGiamGia.Text.Trim(), out phanTramGiam) || phanTramGiam < 0 || phanTramGiam > 100)
                {
                    MessageBox.Show("Phần trăm giảm giá phải là số từ 0 đến 100!", "Lỗi nhập liệu",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGiamGia.Focus();
                    return;
                }
            }

            // 4. Tính toán tổng tiền theo công thức:
            // TongTien = (DonGia * SoLuong) * (100 - GiamGia) / 100
            double tongTien = (donGia * soLuong) * (100 - phanTramGiam) / 100.0;

            // 5. Hiển thị kết quả (định dạng theo tiền tệ)
            lblTongTien.Text = $"Tổng tiền thanh toán: {tongTien:N0} VNĐ";
        }

        // Sự kiện Click nút Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDonGia.Clear();
            txtSoLuong.Clear();
            txtGiamGia.Clear();
            lblTongTien.Text = "Tổng tiền thanh toán: 0 VNĐ";
            txtDonGia.Focus(); // Đặt con trỏ quay lại ô Đơn giá
        }
    }
}