using System;
using System.Drawing;
using System.Windows.Forms;

namespace BAITAPNGAY8TH10
{
    public partial class Form5 : Form
    {
        private SplitContainer splitContainer1;
        private TabControl tabControlLeft;
        private TabPage tabCustomer;
        private TabPage tabShipping;
        private DataGridView dgvOrderDetails;
        private StatusStrip statusStrip1;

        private ToolStripStatusLabel lblTime;
        private ToolStripStatusLabel lblTotalQty;
        private ToolStripStatusLabel lblTotalWeight;
        private ToolStripStatusLabel lblTotalPrice;

        private Timer systemTimer;
        private ErrorProvider errorProvider1;

        private TextBox txtCustomerName;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private ComboBox cboShippingType;

        public Form5()
        {
            InitializeComponent();
            this.KeyPreview = true;
            SetupLayoutUI();
            SetupDataGridViewColumns();
            SetupTimerAndEvents();
        }

        // Fix lỗi CS1061: Khai báo hàm Form5_Load
        private void Form5_Load(object sender, EventArgs e)
        {
            CalculateTotals();
        }

        private void SetupLayoutUI()
        {
            this.Text = "Bài 5: Bảng điều khiển Quản lý Đơn giao hàng";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            statusStrip1 = new StatusStrip();
            lblTime = new ToolStripStatusLabel { Text = "Thời gian: --:--:--", BorderSides = ToolStripStatusLabelBorderSides.Right };
            lblTotalQty = new ToolStripStatusLabel { Text = "Tổng số lượng: 0", BorderSides = ToolStripStatusLabelBorderSides.Right };
            lblTotalWeight = new ToolStripStatusLabel { Text = "Tổng trọng lượng: 0 kg", BorderSides = ToolStripStatusLabelBorderSides.Right };
            lblTotalPrice = new ToolStripStatusLabel { Text = "Tổng tiền: 0 VNĐ", Font = new Font(this.Font, FontStyle.Bold) };

            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTime, lblTotalQty, lblTotalWeight, lblTotalPrice });
            this.Controls.Add(statusStrip1);

            splitContainer1 = new SplitContainer
            {
                Dock = DockStyle.Fill,
                SplitterDistance = 320,
                FixedPanel = FixedPanel.Panel1
            };
            this.Controls.Add(splitContainer1);

            tabControlLeft = new TabControl { Dock = DockStyle.Fill };
            tabCustomer = new TabPage { Text = "Thông tin khách hàng", Padding = new Padding(10) };
            tabShipping = new TabPage { Text = "Loại vận chuyển", Padding = new Padding(10) };

            Label lblName = new Label { Text = "Tên khách hàng:", Location = new Point(10, 15), AutoSize = true };
            txtCustomerName = new TextBox { Location = new Point(10, 35), Width = 260 };

            Label lblPhone = new Label { Text = "Số điện thoại:", Location = new Point(10, 75), AutoSize = true };
            txtPhone = new TextBox { Location = new Point(10, 95), Width = 260 };

            Label lblAddr = new Label { Text = "Địa chỉ giao hàng:", Location = new Point(10, 135), AutoSize = true };
            txtAddress = new TextBox { Location = new Point(10, 155), Width = 260, Multiline = true, Height = 60 };

            tabCustomer.Controls.AddRange(new Control[] { lblName, txtCustomerName, lblPhone, txtPhone, lblAddr, txtAddress });

            Label lblShipType = new Label { Text = "Chọn loại vận chuyển:", Location = new Point(10, 15), AutoSize = true };
            cboShippingType = new ComboBox
            {
                Location = new Point(10, 35),
                Width = 260,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboShippingType.Items.AddRange(new object[] { "Giao hàng tiêu chuẩn", "Giao hàng hỏa tốc (24h)", "Tiết kiệm" });
            cboShippingType.SelectedIndex = 0;

            tabShipping.Controls.AddRange(new Control[] { lblShipType, cboShippingType });

            tabControlLeft.TabPages.Add(tabCustomer);
            tabControlLeft.TabPages.Add(tabShipping);
            splitContainer1.Panel1.Controls.Add(tabControlLeft);

            dgvOrderDetails = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            splitContainer1.Panel2.Controls.Add(dgvOrderDetails);

            errorProvider1 = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
        }

        private void SetupDataGridViewColumns()
        {
            dgvOrderDetails.Columns.Clear();
            dgvOrderDetails.Columns.Add("colName", "Tên hàng");
            dgvOrderDetails.Columns.Add("colQty", "Số lượng");
            dgvOrderDetails.Columns.Add("colWeight", "Trọng lượng (kg)");
            dgvOrderDetails.Columns.Add("colPrice", "Đơn giá");

            var colTotal = new DataGridViewTextBoxColumn { Name = "colTotal", HeaderText = "Thành tiền (tự tính)", ReadOnly = true };
            dgvOrderDetails.Columns.Add(colTotal);

            dgvOrderDetails.Rows.Add("Sách C# WinForms", 2, 0.5, 120000, 240000);
        }

        private void SetupTimerAndEvents()
        {
            systemTimer = new Timer { Interval = 1000 };
            systemTimer.Tick += (s, e) =>
            {
                lblTime.Text = $"Thời gian: {DateTime.Now:HH:mm:ss dd/MM/yyyy}";
            };
            systemTimer.Start();

            dgvOrderDetails.CellEndEdit += DgvOrderDetails_CellEndEdit;
            dgvOrderDetails.RowsRemoved += (s, e) => CalculateTotals();
            this.KeyDown += Form5_KeyDown;
        }

        private void DgvOrderDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvOrderDetails.Rows.Count - 1) return;

            DataGridViewRow row = dgvOrderDetails.Rows[e.RowIndex];

            double qty = GetDoubleValue(row.Cells["colQty"].Value);
            double weight = GetDoubleValue(row.Cells["colWeight"].Value);
            double price = GetDoubleValue(row.Cells["colPrice"].Value);

            bool hasError = false;
            if (qty <= 0)
            {
                row.Cells["colQty"].ErrorText = "Số lượng phải > 0!";
                hasError = true;
            }
            else
            {
                row.Cells["colQty"].ErrorText = string.Empty;
            }

            if (weight <= 0)
            {
                row.Cells["colWeight"].ErrorText = "Trọng lượng phải > 0!";
                hasError = true;
            }
            else
            {
                row.Cells["colWeight"].ErrorText = string.Empty;
            }

            if (!hasError)
            {
                row.Cells["colTotal"].Value = qty * price;
            }
            else
            {
                row.Cells["colTotal"].Value = 0;
            }

            CalculateTotals();
        }

        // Fix lỗi CS0103: Hàm CalculateTotals
        private void CalculateTotals()
        {
            double totalQty = 0;
            double totalWeight = 0;
            double totalPrice = 0;

            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.IsNewRow) continue;

                double qty = GetDoubleValue(row.Cells["colQty"].Value);
                double weight = GetDoubleValue(row.Cells["colWeight"].Value);
                double total = GetDoubleValue(row.Cells["colTotal"].Value);

                if (qty > 0) totalQty += qty;
                if (weight > 0) totalWeight += (qty * weight);
                if (total > 0) totalPrice += total;
            }

            lblTotalQty.Text = $"Tổng số lượng: {totalQty:N0}";
            lblTotalWeight.Text = $"Tổng trọng lượng: {totalWeight:N2} kg";
            lblTotalPrice.Text = $"Tổng tiền: {totalPrice:N0} VNĐ";
        }

        private void Form5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                int newRowIdx = dgvOrderDetails.Rows.Add();
                dgvOrderDetails.CurrentCell = dgvOrderDetails.Rows[newRowIdx].Cells[0];
                dgvOrderDetails.BeginEdit(true);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete && dgvOrderDetails.Focused)
            {
                if (dgvOrderDetails.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvOrderDetails.SelectedRows)
                    {
                        if (!row.IsNewRow) dgvOrderDetails.Rows.Remove(row);
                    }
                    CalculateTotals();
                    e.Handled = true;
                }
            }
        }

        // Fix lỗi CS0103: Hàm GetDoubleValue
        private double GetDoubleValue(object cellValue)
        {
            if (cellValue == null || cellValue == DBNull.Value) return 0;
            double.TryParse(cellValue.ToString(), out double result);
            return result;
        }
    }
}