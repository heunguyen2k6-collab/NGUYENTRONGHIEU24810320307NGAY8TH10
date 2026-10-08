namespace Bai4
{
    partial class Form1
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
            this.flpSoDo = new System.Windows.Forms.FlowLayoutPanel();
            this.cboKhungGio = new System.Windows.Forms.ComboBox();
            this.lblSoViTri = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnHuyChon = new System.Windows.Forms.Button();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpSoDo
            // 
            this.flpSoDo.AutoScroll = true;
            this.flpSoDo.Location = new System.Drawing.Point(25, 34);
            this.flpSoDo.Name = "flpSoDo";
            this.flpSoDo.Size = new System.Drawing.Size(448, 360);
            this.flpSoDo.TabIndex = 0;
            // 
            // cboKhungGio
            // 
            this.cboKhungGio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhungGio.FormattingEnabled = true;
            this.cboKhungGio.Location = new System.Drawing.Point(112, 28);
            this.cboKhungGio.Name = "cboKhungGio";
            this.cboKhungGio.Size = new System.Drawing.Size(133, 21);
            this.cboKhungGio.TabIndex = 1;
            this.cboKhungGio.SelectedIndexChanged += new System.EventHandler(this.cboKhungGio_SelectedIndexChanged);
            // 
            // lblSoViTri
            // 
            this.lblSoViTri.AutoSize = true;
            this.lblSoViTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoViTri.Location = new System.Drawing.Point(6, 63);
            this.lblSoViTri.Name = "lblSoViTri";
            this.lblSoViTri.Size = new System.Drawing.Size(115, 16);
            this.lblSoViTri.TabIndex = 2;
            this.lblSoViTri.Text = "Số chỗ đang chọn: 0";
            // 
            // lblTamTinh
            // 
            this.lblTamTinh.AutoSize = true;
            this.lblTamTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamTinh.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTamTinh.Location = new System.Drawing.Point(6, 97);
            this.lblTamTinh.Name = "lblTamTinh";
            this.lblTamTinh.Size = new System.Drawing.Size(155, 16);
            this.lblTamTinh.TabIndex = 3;
            this.lblTamTinh.Text = "Tạm tính tiền: 0 VNĐ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Chọn khung giờ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHuyChon);
            this.groupBox1.Controls.Add(this.btnXacNhan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboKhungGio);
            this.groupBox1.Controls.Add(this.lblTamTinh);
            this.groupBox1.Controls.Add(this.lblSoViTri);
            this.groupBox1.Location = new System.Drawing.Point(485, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 197);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đặt chỗ";
            // 
            // btnHuyChon
            // 
            this.btnHuyChon.Location = new System.Drawing.Point(135, 136);
            this.btnHuyChon.Name = "btnHuyChon";
            this.btnHuyChon.Size = new System.Drawing.Size(110, 30);
            this.btnHuyChon.TabIndex = 6;
            this.btnHuyChon.Text = "Hủy chọn tất cả";
            this.btnHuyChon.UseVisualStyleBackColor = true;
            this.btnHuyChon.Click += new System.EventHandler(this.btnHuyChon_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(9, 136);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(110, 30);
            this.btnXacNhan.TabIndex = 5;
            this.btnXacNhan.Text = "Xác nhận đặt";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flpSoDo);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sơ đồ chọn vị trí chỗ ngồi / Đặt bàn hẹn giờ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSoDo;
        private System.Windows.Forms.ComboBox cboKhungGio;
        private System.Windows.Forms.Label lblSoViTri;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnHuyChon;
        private System.Windows.Forms.Button btnXacNhan;
    }
}