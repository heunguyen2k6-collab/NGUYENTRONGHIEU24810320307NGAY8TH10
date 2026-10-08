namespace BAITAPNGAY8TH10
{
    partial class Form3
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXoaToanBo = new System.Windows.Forms.Button();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.cboDVT = new System.Windows.Forms.ComboBox();
            this.txtTenVT = new System.Windows.Forms.TextBox();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvVatTu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXoaToanBo);
            this.groupBox1.Controls.Add(this.btnXoaDong);
            this.groupBox1.Controls.Add(this.btnCapNhat);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtDonGia);
            this.groupBox1.Controls.Add(this.cboDVT);
            this.groupBox1.Controls.Add(this.txtTenVT);
            this.groupBox1.Controls.Add(this.txtMaVT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 321);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin vật tư";
            // 
            // btnXoaToanBo
            // 
            this.btnXoaToanBo.Location = new System.Drawing.Point(146, 229);
            this.btnXoaToanBo.Name = "btnXoaToanBo";
            this.btnXoaToanBo.Size = new System.Drawing.Size(108, 36);
            this.btnXoaToanBo.TabIndex = 11;
            this.btnXoaToanBo.Text = "Xóa toàn bộ";
            this.btnXoaToanBo.UseVisualStyleBackColor = true;
            this.btnXoaToanBo.Click += new System.EventHandler(this.btnXoaToanBo_Click);
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.Location = new System.Drawing.Point(13, 229);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(103, 36);
            this.btnXoaDong.TabIndex = 10;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = true;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(146, 177);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(108, 36);
            this.btnCapNhat.TabIndex = 9;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(13, 177);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(103, 36);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtDonGia
            // 
            this.txtDonGia.Location = new System.Drawing.Point(133, 133);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(100, 22);
            this.txtDonGia.TabIndex = 7;
            // 
            // cboDVT
            // 
            this.cboDVT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDVT.FormattingEnabled = true;
            this.cboDVT.Items.AddRange(new object[] {
            "Cái",
            "Bộ",
            "Kg",
            "Mét"});
            this.cboDVT.Location = new System.Drawing.Point(133, 99);
            this.cboDVT.Name = "cboDVT";
            this.cboDVT.Size = new System.Drawing.Size(121, 24);
            this.cboDVT.TabIndex = 6;
            // 
            // txtTenVT
            // 
            this.txtTenVT.Location = new System.Drawing.Point(133, 64);
            this.txtTenVT.Name = "txtTenVT";
            this.txtTenVT.Size = new System.Drawing.Size(161, 22);
            this.txtTenVT.TabIndex = 5;
            this.txtTenVT.Text = "\r\n";
            // 
            // txtMaVT
            // 
            this.txtMaVT.Location = new System.Drawing.Point(133, 35);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.Size = new System.Drawing.Size(161, 22);
            this.txtMaVT.TabIndex = 4;
            this.txtMaVT.Text = "\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Đơn giá nhập: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đơn vị tính: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên vật tư: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã vật tư: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvVatTu);
            this.groupBox2.Location = new System.Drawing.Point(404, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 312);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách vật tư / linh kiện";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // lsvVatTu
            // 
            this.lsvVatTu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvVatTu.FullRowSelect = true;
            this.lsvVatTu.GridLines = true;
            this.lsvVatTu.HideSelection = false;
            this.lsvVatTu.Location = new System.Drawing.Point(18, 35);
            this.lsvVatTu.MultiSelect = false;
            this.lsvVatTu.Name = "lsvVatTu";
            this.lsvVatTu.Size = new System.Drawing.Size(344, 259);
            this.lsvVatTu.TabIndex = 0;
            this.lsvVatTu.UseCompatibleStateImageBehavior = false;
            this.lsvVatTu.View = System.Windows.Forms.View.Details;
            this.lsvVatTu.SelectedIndexChanged += new System.EventHandler(this.lsvVatTu_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã VT";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên VT";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn vị tính";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 100;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDVT;
        private System.Windows.Forms.TextBox txtTenVT;
        private System.Windows.Forms.TextBox txtMaVT;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.Button btnXoaToanBo;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lsvVatTu;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}