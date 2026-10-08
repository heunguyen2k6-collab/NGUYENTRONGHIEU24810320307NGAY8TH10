using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BAITAPNGAY8TH10
{
    public partial class Form4 : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblSelectedCount;
        private Label lblTotalPrice;
        private ComboBox cboTimeSlot;
        private Button btnConfirm;
        private Button btnDeselectAll;

        private const decimal PRICE_MORNING = 100000m;
        private const decimal PRICE_EVENING = 150000m;

        public Form4()
        {
            InitializeComponent();
            SetupUI();              // Dựng layout
            InitializeSeatMatrix(); // Sinh 20 nút ô chọn
            UpdateRealtimeInfo();   // Cập nhật thông tin
        }

        private void SetupUI()
        {
            this.Text = "Form4 - Đặt chỗ";
            this.Size = new Size(750, 480);
            this.StartPosition = FormStartPosition.CenterScreen;

            // 1. Tạo TableLayoutPanel bên TÁI (Ma trận 4x5)
            tableLayoutPanel1 = new TableLayoutPanel
            {
                Dock = DockStyle.Left,
                Width = 450,
                RowCount = 4,
                ColumnCount = 5,
                Padding = new Padding(10)
            };

            for (int i = 0; i < 4; i++)
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25f));
            for (int j = 0; j < 5; j++)
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f));

            // 2. Tạo Panel chứa các thông tin bên PHẢI
            Panel rightPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15)
            };

            Label lblTimeSlot = new Label { Text = "Khung giờ:", Location = new Point(10, 20), AutoSize = true };

            cboTimeSlot = new ComboBox
            {
                Location = new Point(10, 45),
                Width = 220,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboTimeSlot.Items.Add("Sáng (100.000đ)");
            cboTimeSlot.Items.Add("Tối (150.000đ)");
            cboTimeSlot.SelectedIndex = 0;
            cboTimeSlot.SelectedIndexChanged += (s, e) => UpdateRealtimeInfo();

            lblSelectedCount = new Label { Text = "Số vị trí đang chọn: 0", Location = new Point(10, 90), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            lblTotalPrice = new Label { Text = "Tạm tính tiền: 0đ", Location = new Point(10, 120), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };

            btnConfirm = new Button
            {
                Text = "Xác nhận đặt",
                Location = new Point(10, 170),
                Size = new Size(220, 38),
                BackColor = Color.LightSkyBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnConfirm.Click += BtnConfirm_Click;

            btnDeselectAll = new Button
            {
                Text = "Hủy chọn tất cả",
                Location = new Point(10, 220),
                Size = new Size(220, 38),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };
            btnDeselectAll.Click += BtnDeselectAll_Click;

            rightPanel.Controls.Add(lblTimeSlot);
            rightPanel.Controls.Add(cboTimeSlot);
            rightPanel.Controls.Add(lblSelectedCount);
            rightPanel.Controls.Add(lblTotalPrice);
            rightPanel.Controls.Add(btnConfirm);
            rightPanel.Controls.Add(btnDeselectAll);

            // Thêm rightPanel trước, tableLayoutPanel1 sau để không bị đè màn hình
            this.Controls.Add(rightPanel);
            this.Controls.Add(tableLayoutPanel1);
        }

        private void InitializeSeatMatrix()
        {
            tableLayoutPanel1.Controls.Clear();
            int[] lockedSeats = new int[] { 3, 8 }; // Giả định ghế 3 và 8 đã khóa

            for (int i = 1; i <= 20; i++)
            {
                Button btnSeat = new Button
                {
                    Text = $"Vị trí {i}",
                    Dock = DockStyle.Fill,
                    Margin = new Padding(3),
                    FlatStyle = FlatStyle.Flat
                };

                if (lockedSeats.Contains(i))
                {
                    btnSeat.BackColor = Color.Red; // Đã khóa
                    btnSeat.Enabled = false;
                }
                else
                {
                    btnSeat.BackColor = Color.White; // Trống
                }

                btnSeat.Click += BtnSeat_Click;
                tableLayoutPanel1.Controls.Add(btnSeat);
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            if (btn.BackColor == Color.White)
                btn.BackColor = Color.LimeGreen;
            else if (btn.BackColor == Color.LimeGreen)
                btn.BackColor = Color.White;

            UpdateRealtimeInfo();
        }

        private void UpdateRealtimeInfo()
        {
            int selectedCount = tableLayoutPanel1.Controls
                .OfType<Button>()
                .Count(btn => btn.BackColor == Color.LimeGreen);

            decimal unitPrice = (cboTimeSlot.SelectedIndex == 0) ? PRICE_MORNING : PRICE_EVENING;
            decimal totalPrice = selectedCount * unitPrice;

            lblSelectedCount.Text = $"Số vị trí đang chọn: {selectedCount}";
            lblTotalPrice.Text = $"Tạm tính tiền: {totalPrice:N0}đ";
        }

        private void BtnDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Button btn && btn.BackColor == Color.LimeGreen)
                {
                    btn.BackColor = Color.White;
                }
            }
            UpdateRealtimeInfo();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            var selectedSeats = tableLayoutPanel1.Controls
                .OfType<Button>()
                .Where(btn => btn.BackColor == Color.LimeGreen)
                .ToList();

            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 vị trí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var btn in selectedSeats)
            {
                btn.BackColor = Color.Red;
                btn.Enabled = false;
            }

            MessageBox.Show($"Đặt thành công {selectedSeats.Count} vị trí!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateRealtimeInfo();
        }
    }
}