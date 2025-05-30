namespace frmNhapHang
{
    partial class frmNhapHang
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
            this.lblMaPhieuNhap = new System.Windows.Forms.Label();
            this.lblNgayNhap = new System.Windows.Forms.Label();
            this.lblMaNhaCungCap = new System.Windows.Forms.Label();
            this.lblTenNhaCungCap = new System.Windows.Forms.Label();
            this.txtMaPhieuNhap = new System.Windows.Forms.TextBox();
            this.txtTenNhaCungCap = new System.Windows.Forms.TextBox();
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.cboMaNhaCungCap = new System.Windows.Forms.ComboBox();
            this.btnThemNCC = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvChiTietNhap = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaPhieuNhap
            // 
            this.lblMaPhieuNhap.AutoSize = true;
            this.lblMaPhieuNhap.Location = new System.Drawing.Point(12, 19);
            this.lblMaPhieuNhap.Name = "lblMaPhieuNhap";
            this.lblMaPhieuNhap.Size = new System.Drawing.Size(95, 16);
            this.lblMaPhieuNhap.TabIndex = 0;
            this.lblMaPhieuNhap.Text = "Mã phiếu nhập";
            this.lblMaPhieuNhap.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.AutoSize = true;
            this.lblNgayNhap.Location = new System.Drawing.Point(12, 68);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(73, 16);
            this.lblNgayNhap.TabIndex = 1;
            this.lblNgayNhap.Text = "Ngày nhập";
            // 
            // lblMaNhaCungCap
            // 
            this.lblMaNhaCungCap.AutoSize = true;
            this.lblMaNhaCungCap.Location = new System.Drawing.Point(430, 63);
            this.lblMaNhaCungCap.Name = "lblMaNhaCungCap";
            this.lblMaNhaCungCap.Size = new System.Drawing.Size(109, 16);
            this.lblMaNhaCungCap.TabIndex = 2;
            this.lblMaNhaCungCap.Text = "Mã nhà cung cấp";
            // 
            // lblTenNhaCungCap
            // 
            this.lblTenNhaCungCap.AutoSize = true;
            this.lblTenNhaCungCap.Location = new System.Drawing.Point(425, 19);
            this.lblTenNhaCungCap.Name = "lblTenNhaCungCap";
            this.lblTenNhaCungCap.Size = new System.Drawing.Size(114, 16);
            this.lblTenNhaCungCap.TabIndex = 4;
            this.lblTenNhaCungCap.Text = "Tên nhà cung cấp";
            // 
            // txtMaPhieuNhap
            // 
            this.txtMaPhieuNhap.Location = new System.Drawing.Point(125, 19);
            this.txtMaPhieuNhap.Name = "txtMaPhieuNhap";
            this.txtMaPhieuNhap.Size = new System.Drawing.Size(197, 22);
            this.txtMaPhieuNhap.TabIndex = 5;
            // 
            // txtTenNhaCungCap
            // 
            this.txtTenNhaCungCap.Location = new System.Drawing.Point(569, 16);
            this.txtTenNhaCungCap.Name = "txtTenNhaCungCap";
            this.txtTenNhaCungCap.Size = new System.Drawing.Size(201, 22);
            this.txtTenNhaCungCap.TabIndex = 6;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.Location = new System.Drawing.Point(125, 61);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayNhap.TabIndex = 7;
            // 
            // cboMaNhaCungCap
            // 
            this.cboMaNhaCungCap.FormattingEnabled = true;
            this.cboMaNhaCungCap.Location = new System.Drawing.Point(571, 60);
            this.cboMaNhaCungCap.Name = "cboMaNhaCungCap";
            this.cboMaNhaCungCap.Size = new System.Drawing.Size(198, 24);
            this.cboMaNhaCungCap.TabIndex = 8;
            // 
            // btnThemNCC
            // 
            this.btnThemNCC.Location = new System.Drawing.Point(36, 357);
            this.btnThemNCC.Name = "btnThemNCC";
            this.btnThemNCC.Size = new System.Drawing.Size(97, 23);
            this.btnThemNCC.TabIndex = 9;
            this.btnThemNCC.Text = "Thêm NCC";
            this.btnThemNCC.UseVisualStyleBackColor = true;
            this.btnThemNCC.Click += new System.EventHandler(this.btnThemNCC_Click_1);
            btnThemNCC.Click += BtnThemNCC_Click;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(247, 357);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(464, 357);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(675, 357);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(350, 407);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 13;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(569, 407);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(149, 407);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            // 
            // dgvChiTietNhap
            // 
            this.dgvChiTietNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietNhap.Location = new System.Drawing.Point(15, 105);
            this.dgvChiTietNhap.Name = "dgvChiTietNhap";
            this.dgvChiTietNhap.RowHeadersWidth = 51;
            this.dgvChiTietNhap.RowTemplate.Height = 24;
            this.dgvChiTietNhap.Size = new System.Drawing.Size(773, 233);
            this.dgvChiTietNhap.TabIndex = 16;
            this.dgvChiTietNhap.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietNhap_CellContentClick);
            // 
            // frmNhapHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvChiTietNhap);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnThemNCC);
            this.Controls.Add(this.cboMaNhaCungCap);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.txtTenNhaCungCap);
            this.Controls.Add(this.txtMaPhieuNhap);
            this.Controls.Add(this.lblTenNhaCungCap);
            this.Controls.Add(this.lblMaNhaCungCap);
            this.Controls.Add(this.lblNgayNhap);
            this.Controls.Add(this.lblMaPhieuNhap);
            this.Name = "frmNhapHang";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMaPhieuNhap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.Label lblMaNhaCungCap;
        private System.Windows.Forms.Label lblTenNhaCungCap;
        private System.Windows.Forms.TextBox txtMaPhieuNhap;
        private System.Windows.Forms.TextBox txtTenNhaCungCap;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.ComboBox cboMaNhaCungCap;
        private System.Windows.Forms.Button btnThemNCC;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
    }
}

