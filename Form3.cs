using System;
using System.Text;
using System.Windows.Forms;

namespace BAITAPNGAY8TH10
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình các cột cho ListView nếu chưa tạo ở giao diện
            CaiDatListView();

            // 2. Chọn mặc định Đơn vị tính đầu tiên
            if (cboDVT.Items.Count > 0)
            {
                cboDVT.SelectedIndex = 0;
            }
        }

        // Cấu hình các cột cho ListView
        private void CaiDatListView()
        {
            lsvVatTu.View = View.Details;
            lsvVatTu.FullRowSelect = true;
            lsvVatTu.GridLines = true;

            // Nếu trong Designer chưa tạo Cột thì đoạn code này sẽ tự sinh cột
            if (lsvVatTu.Columns.Count == 0)
            {
                lsvVatTu.Columns.Add("Mã VT", 100);
                lsvVatTu.Columns.Add("Tên VT", 180);
                lsvVatTu.Columns.Add("Đơn vị tính", 100);
                lsvVatTu.Columns.Add("Đơn giá", 120, HorizontalAlignment.Right);
            }
        }

        // -------------------------------------------------------------
        // 1. NÚT "THÊM MỚI"
        // -------------------------------------------------------------
        private void btnThem_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu đầu vào
            if (!KiemTraHopLe()) return;

            string maVT = txtMaVT.Text.Trim();

            // Validate: Kiểm tra Mã VT đã tồn tại trong ListView chưa
            if (KiemTraTonTaiMaVT(maVT))
            {
                MessageBox.Show($"Mã vật tư '{maVT}' đã tồn tại trong danh sách!", "Cảnh báo trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaVT.SelectAll();
                txtMaVT.Focus();
                return;
            }

            // Thêm dữ liệu vào ListView
            ListViewItem item = new ListViewItem(maVT);
            item.SubItems.Add(txtTenVT.Text.Trim());
            item.SubItems.Add(cboDVT.SelectedItem.ToString());

            decimal donGia = decimal.Parse(txtDonGia.Text.Trim());
            item.SubItems.Add(donGia.ToString("#,##0"));

            lsvVatTu.Items.Add(item);

            // Xóa trắng ô nhập liệu sau khi thêm
            XoaFormInput();
            MessageBox.Show("Thêm vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // -------------------------------------------------------------
        // 2. NÚT "CẬP NHẬT"
        // -------------------------------------------------------------
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (lsvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần cập nhật từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate dữ liệu đầu vào
            if (!KiemTraHopLe()) return;

            ListViewItem item = lsvVatTu.SelectedItems[0];
            string maVTChange = txtMaVT.Text.Trim();

            // Nếu người dùng đổi Mã VT, kiểm tra xem mã mới có bị trùng với dòng khác không
            if (item.Text != maVTChange && KiemTraTonTaiMaVT(maVTChange))
            {
                MessageBox.Show($"Mã vật tư '{maVTChange}' đã tồn tại!", "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật lại dữ liệu dòng đã chọn
            item.Text = maVTChange;
            item.SubItems[1].Text = txtTenVT.Text.Trim();
            item.SubItems[2].Text = cboDVT.SelectedItem.ToString();

            decimal donGia = decimal.Parse(txtDonGia.Text.Trim());
            item.SubItems[3].Text = donGia.ToString("#,##0");

            XoaFormInput();
            MessageBox.Show("Cập nhật thông tin vật tư thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // -------------------------------------------------------------
        // 3. NÚT "XÓA DÒNG"
        // -------------------------------------------------------------
        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (lsvVatTu.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenVT = lsvVatTu.SelectedItems[0].SubItems[1].Text;

            // Hiển thị MessageBox xác nhận Yes/No
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa vật tư '{tenVT}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                lsvVatTu.Items.Remove(lsvVatTu.SelectedItems[0]);
                XoaFormInput();
                MessageBox.Show("Đã xóa dòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------------------------------------------------
        // 4. NÚT "XÓA TOÀN BỘ"
        // -------------------------------------------------------------
        private void btnXoaToanBo_Click(object sender, EventArgs e)
        {
            if (lsvVatTu.Items.Count == 0)
            {
                MessageBox.Show("Danh sách vật tư đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn XÓA TOÀN BỘ danh sách vật tư không?", "Xác nhận xóa tất cả", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                lsvVatTu.Items.Clear();
                XoaFormInput();
                MessageBox.Show("Đã xóa toàn bộ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------------------------------------------------
        // SỰ KIỆN: SỰ CỐ CHỌN DÒNG TRÊN LISTVIEW (SelectedIndexChanged)
        // -------------------------------------------------------------
        private void lsvVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvVatTu.SelectedItems.Count > 0)
            {
                ListViewItem item = lsvVatTu.SelectedItems[0];

                // Đẩy dữ liệu ngược lên các Control bên trái
                txtMaVT.Text = item.Text;
                txtTenVT.Text = item.SubItems[1].Text;
                cboDVT.SelectedItem = item.SubItems[2].Text;

                // Xóa định dạng phân cách ngàn để đưa về dạng chuỗi số nhập liệu
                txtDonGia.Text = item.SubItems[3].Text.Replace(",", "").Replace(".", "");
            }
        }

        // -------------------------------------------------------------
        // CÁC HÀM BỔ TRỢ (HELPER FUNCTIONS)
        // -------------------------------------------------------------

        // Kiểm tra hợp lệ dữ liệu nhập
        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtMaVT.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã vật tư!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaVT.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenVT.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên vật tư!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenVT.Focus();
                return false;
            }

            if (cboDVT.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn Đơn vị tính!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDonGia.Text) || !decimal.TryParse(txtDonGia.Text, out decimal donGia) || donGia < 0)
            {
                MessageBox.Show("Đơn giá nhập không hợp lệ (phải là số lớn hơn hoặc bằng 0)!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return false;
            }

            return true;
        }

        // Kiểm tra Mã VT có tồn tại trong ListView chưa
        private bool KiemTraTonTaiMaVT(string maVT)
        {
            foreach (ListViewItem item in lsvVatTu.Items)
            {
                if (item.Text.Equals(maVT, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        // Xóa trắng form nhập liệu
        private void XoaFormInput()
        {
            txtMaVT.Clear();
            txtTenVT.Clear();
            txtDonGia.Clear();
            if (cboDVT.Items.Count > 0) cboDVT.SelectedIndex = 0;
            txtMaVT.Focus();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load_1(object sender, EventArgs e)
        {

        }
    }
}