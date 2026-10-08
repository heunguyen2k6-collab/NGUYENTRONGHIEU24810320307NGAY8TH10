using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Form1 : Form
    {
        // Khai báo giá vé theo khung giờ
        private const decimal GIA_SANG = 100000m;
        private const decimal GIA_TOI = 150000m;

        // Định nghĩa màu sắc trạng thái
        private readonly Color MAU_TRONG = Color.LightGray;      // Trắng/Xám nhạt: Trống
        private readonly Color MAU_DANG_CHON = Color.LightGreen; // Xanh lá: Đang chọn
        private readonly Color MAU_DA_DAT = Color.IndianRed;     // Đỏ: Đã khóa / Đã đặt

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Sự kiện Form_Load: Sinh tự động 20 Button
        private void Form1_Load(object sender, EventArgs e)
        {
            // Cấu hình ComboBox khung giờ
            cboKhungGio.Items.Clear();
            cboKhungGio.Items.Add("Sáng (100.000 VNĐ)");
            cboKhungGio.Items.Add("Tối (150.000 VNĐ)");
            cboKhungGio.SelectedIndex = 0; // Mặc định chọn Sáng

            // Tạo 20 Button động (Ma trận 4x5)
            TaoSoDoChoNgoi(20);

            // Cập nhật thống kê ban đầu
            CapNhatThongKe();
        }

        // Hàm khởi tạo các Button động trong FlowLayoutPanel
        private void TaoSoDoChoNgoi(int soLuong)
        {
            flpSoDo.Controls.Clear(); // Xóa sạch nếu có sẵn

            for (int i = 1; i <= soLuong; i++)
            {
                Button btnSeat = new Button();
                btnSeat.Name = $"btnCho_{i}";
                btnSeat.Text = $"Vị trí {i}";
                btnSeat.Size = new Size(80, 60);
                btnSeat.Margin = new Padding(4);
                btnSeat.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btnSeat.BackColor = MAU_TRONG; // Trạng thái ban đầu: Trống

                // Mô phỏng ngẫu nhiên vài chỗ đã được đặt trước (vị trí 3 và 8)
                if (i == 3 || i == 8)
                {
                    btnSeat.BackColor = MAU_DA_DAT;
                    btnSeat.Enabled = false; // Khóa không cho bấm chọn
                }

                // GÁN CHUNG 1 HÀM XỬ LÝ SỰ KIỆN CLICK CHO TẤT CẢ BUTTON
                btnSeat.Click += ViTri_Click;

                // Thêm Button vào FlowLayoutPanel
                flpSoDo.Controls.Add(btnSeat);
            }
        }

        // 2. Hàm xử lý sự kiện Click DÙNG CHUNG cho 20 Button
        private void ViTri_Click(object sender, EventArgs e)
        {
            Button btnCurrent = sender as Button;
            if (btnCurrent == null) return;

            // Đổi màu trạng thái qua lại giữa TRỐNG và ĐANG CHỌN
            if (btnCurrent.BackColor == MAU_TRONG)
            {
                btnCurrent.BackColor = MAU_DANG_CHON;
            }
            else if (btnCurrent.BackColor == MAU_DANG_CHON)
            {
                btnCurrent.BackColor = MAU_TRONG;
            }

            CapNhatThongKe();
        }

        // 3. Hàm tính toán và hiển thị Thống kê Realtime
        private void CapNhatThongKe()
        {
            int soLuongChon = 0;

            foreach (Control ctrl in flpSoDo.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == MAU_DANG_CHON)
                {
                    soLuongChon++;
                }
            }

            decimal donGia = (cboKhungGio.SelectedIndex == 0) ? GIA_SANG : GIA_TOI;
            decimal tongTien = soLuongChon * donGia;

            lblSoViTri.Text = $"Số vị trí đang chọn: {soLuongChon}";
            lblTamTinh.Text = $"Tạm tính tiền: {tongTien:N0} VNĐ";
        }

        // 4. Khi đổi Khung giờ -> Cập nhật lại Tạm tính tiền
        private void cboKhungGio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatThongKe();
        }

        // 5. Nút "Hủy chọn tất cả"
        private void btnHuyChon_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in flpSoDo.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == MAU_DANG_CHON)
                {
                    btn.BackColor = MAU_TRONG;
                }
            }
            CapNhatThongKe();
        }

        // 6. Nút "Xác nhận đặt"
        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            List<string> dsViTri = new List<string>();

            foreach (Control ctrl in flpSoDo.Controls)
            {
                if (ctrl is Button btn && btn.BackColor == MAU_DANG_CHON)
                {
                    dsViTri.Add(btn.Text);
                }
            }

            if (dsViTri.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 vị trí trước khi xác nhận!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal donGia = (cboKhungGio.SelectedIndex == 0) ? GIA_SANG : GIA_TOI;
            decimal tongTien = dsViTri.Count * donGia;

            string thongBao = $"--- THÔNG TIN ĐẶT CHỖ ---\n\n" +
                              $"• Khung giờ: {cboKhungGio.SelectedItem}\n" +
                              $"• Các vị trí chọn: {string.Join(", ", dsViTri)}\n" +
                              $"• Tổng số lượng: {dsViTri.Count} chỗ\n" +
                              $"• Tổng tiền: {tongTien:N0} VNĐ";

            DialogResult res = MessageBox.Show(thongBao + "\n\nBạn có muốn xác nhận đặt không?",
                                               "Xác nhận đơn đặt",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                foreach (Control ctrl in flpSoDo.Controls)
                {
                    if (ctrl is Button btn && btn.BackColor == MAU_DANG_CHON)
                    {
                        btn.BackColor = MAU_DA_DAT;
                        btn.Enabled = false;
                    }
                }

                MessageBox.Show("Đặt chỗ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CapNhatThongKe();
            }
        }
    }
}