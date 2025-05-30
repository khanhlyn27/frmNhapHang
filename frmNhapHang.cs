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

namespace frmNhapHang
{
    public partial class frmNhapHang : Form
    {
        private string connectionString = "Data Source=DESKTOP-42OU7AB;Initial Catalog=QuanLyCuaHangQuanAo;Integrated Security=True";
        private DataTable dtChiTietNhap;
        private DataTable dtSanPham;  // Dữ liệu sản phẩm để dùng cho ComboBox trong dgv
        private bool dangThemMoi = false;

        public frmNhapHang()
        {
            InitializeComponent();
            this.Load += FrmNhapHang_Load;

            btnThemNCC.Click += BtnThemNCC_Click;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            btnThoat.Click += BtnThoat_Click;
            cboMaNhaCungCap.SelectedIndexChanged += CboMaNhaCungCap_SelectedIndexChanged;

            dgvChiTietNhap.CellValueChanged += DgvChiTietNhap_CellValueChanged;
            dgvChiTietNhap.CellEndEdit += DgvChiTietNhap_CellEndEdit;
            dgvChiTietNhap.EditingControlShowing += DgvChiTietNhap_EditingControlShowing;
        }
            private void SetButtonState(bool enabled)
        {
            btnThem.Enabled = enabled;
            btnSua.Enabled = enabled;
            btnXoa.Enabled = enabled;
            btnLuu.Enabled = !enabled;
            btnHuy.Enabled = !enabled;
        }
        

        private void FrmNhapHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachNhaCungCap();
            LoadDanhSachSanPham();  // Load sản phẩm để bind vào dgv ComboBox
            ResetForm();
        }

        /// <summary>
        /// Load danh sách nhà cung cấp vào ComboBox
        /// </summary>
        private void LoadDanhSachNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT maNCC, tenNCC FROM nhaCungCap";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboMaNhaCungCap.DataSource = dt;
                    cboMaNhaCungCap.DisplayMember = "tenNCC"; // Hiển thị tên nhà cung cấp
                    cboMaNhaCungCap.ValueMember = "maNCC";   // Giá trị là mã nhà cung cấp
                    cboMaNhaCungCap.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách nhà cung cấp: " + ex.Message);
            }
        }

        /// <summary>
        /// Load danh sách sản phẩm dùng làm nguồn cho ComboBox trong DataGridView
        /// </summary>
        private void LoadDanhSachSanPham()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT maQuanAo, tenQuanAo, donGiaNhap FROM sanPham";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    dtSanPham = new DataTable();
                    da.Fill(dtSanPham);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load danh sách sản phẩm: " + ex.Message);
                dtSanPham = new DataTable();
            }
        }

        private void CboMaNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhaCungCap.SelectedIndex >= 0)
            {
                DataRowView drv = (DataRowView)cboMaNhaCungCap.SelectedItem;
                txtTenNhaCungCap.Text = drv["tenNCC"].ToString();
            }
            else
            {
                txtTenNhaCungCap.Clear();
            }
        }

        private void BtnThemNCC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm nhà cung cấp đang phát triển.");
        }

        /// <summary>
        /// Reset form về trạng thái ban đầu
        /// </summary>
        private void ResetForm()
        {
            txtMaPhieuNhap.Text = SinhMaPhieuNhapMoi();
            dtpNgayNhap.Value = DateTime.Now;
            cboMaNhaCungCap.SelectedIndex = -1;
            txtTenNhaCungCap.Clear();

            dtChiTietNhap = new DataTable();
            dtChiTietNhap.Columns.Add("MaQuanAo", typeof(string));
            dtChiTietNhap.Columns.Add("TenQuanAo", typeof(string));
            dtChiTietNhap.Columns.Add("SoLuong", typeof(int));
            dtChiTietNhap.Columns.Add("DonGiaNhap", typeof(decimal));
            dtChiTietNhap.Columns.Add("GiamGia", typeof(decimal));
            dtChiTietNhap.Columns.Add("ThanhTien", typeof(decimal));

            dgvChiTietNhap.DataSource = dtChiTietNhap;

            // Tạo ComboBox cột chọn sản phẩm
            SetupComboBoxColumn();

            SetButtonState(true);
            dangThemMoi = true;
        }

        /// <summary>
        /// Sinh mã phiếu nhập tự động dựa trên mã lớn nhất hiện tại
        /// </summary>
        /// <returns></returns>
        private string SinhMaPhieuNhapMoi()
        {
            string maMoi = "PN0001";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT TOP 1 maHDN FROM hoaDonNhap ORDER BY maHDN DESC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        string maCu = result.ToString();
                        int so = int.Parse(maCu.Substring(2)) + 1;
                        maMoi = "PN" + so.ToString("D4");
                    }
                }
            }
            catch { }
            return maMoi;
        }

        /// <summary>
        /// Cấu hình cột ComboBox chọn sản phẩm trong dgv
        /// </summary>
        private void SetupComboBoxColumn()
        {
            // Nếu đã có thì xóa cột cũ trước
            if (dgvChiTietNhap.Columns.Contains("colSanPham"))
                dgvChiTietNhap.Columns.Remove("colSanPham");

            // Tạo cột ComboBox chọn sản phẩm
            DataGridViewComboBoxColumn comboColumn = new DataGridViewComboBoxColumn
            {
                Name = "colSanPham",
                HeaderText = "Chọn sản phẩm",
                DataSource = dtSanPham,
                DisplayMember = "tenQuanAo",
                ValueMember = "maQuanAo",
                Width = 150
            };
            dgvChiTietNhap.Columns.Insert(0, comboColumn);
        }

        /// <summary>
        /// Khi ô comboBox chọn sản phẩm được chỉnh sửa xong
        /// Tự động lấy mã, tên, đơn giá sản phẩm tương ứng điền vào dgv
        /// </summary>
        private void DgvChiTietNhap_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvChiTietNhap.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (e.ColumnIndex == dgvChiTietNhap.Columns["colSanPham"].Index && e.RowIndex >= 0)
            {
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dgvChiTietNhap.Rows[e.RowIndex].Cells["colSanPham"];
                string maSP = cell.Value?.ToString();
                if (!string.IsNullOrEmpty(maSP))
                {
                    DataRow[] rows = dtSanPham.Select($"maQuanAo = '{maSP}'");
                    if (rows.Length > 0)
                    {
                        var rowData = rows[0];
                        dgvChiTietNhap.Rows[e.RowIndex].Cells["MaQuanAo"].Value = rowData["maQuanAo"];
                        dgvChiTietNhap.Rows[e.RowIndex].Cells["TenQuanAo"].Value = rowData["tenQuanAo"];
                        dgvChiTietNhap.Rows[e.RowIndex].Cells["DonGiaNhap"].Value = rowData["donGiaNhap"];
                        dgvChiTietNhap.Rows[e.RowIndex].Cells["SoLuong"].Value = 1;
                        dgvChiTietNhap.Rows[e.RowIndex].Cells["GiamGia"].Value = 0;
                        dgvChiTietNhap.Rows[e.RowIndex].Cells["ThanhTien"].Value = rowData["donGiaNhap"];
                    }
                }
            }
        }

        /// <summary>
        /// Tính toán lại thành tiền khi giá trị thay đổi
        /// </summary>
        private void DgvChiTietNhap_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvChiTietNhap.Rows[e.RowIndex];
            if (row.Cells["SoLuong"].Value == null || row.Cells["DonGiaNhap"].Value == null || row.Cells["GiamGia"].Value == null)
                return;

            try
            {
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                decimal donGia = Convert.ToDecimal(row.Cells["DonGiaNhap"].Value);
                decimal giamGia = Convert.ToDecimal(row.Cells["GiamGia"].Value);

                if (soLuong < 0)
                {
                    MessageBox.Show("Số lượng không được âm.");
                    row.Cells["SoLuong"].Value = 1;
                    return;
                }
                if (donGia < 0)
                {
                    MessageBox.Show("Đơn giá không được âm.");
                    row.Cells["DonGiaNhap"].Value = 0;
                    return;
                }
                if (giamGia < 0)
                {
                    MessageBox.Show("Giảm giá không được âm.");
                    row.Cells["GiamGia"].Value = 0;
                    return;
                }
                if (giamGia > soLuong * donGia)
                {
                    MessageBox.Show("Giảm giá không được vượt quá tổng tiền.");
                    row.Cells["GiamGia"].Value = 0;
                    return;
                }

                decimal thanhTien = soLuong * donGia - giamGia;
                row.Cells["ThanhTien"].Value = thanhTien;
            }
            catch
            {
                MessageBox.Show("Giá trị nhập không hợp lệ.");
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            DataRow newRow = dtChiTietNhap.NewRow();
            newRow["MaQuanAo"] = "";
            newRow["TenQuanAo"] = "";
            newRow["SoLuong"] = 1;
            newRow["DonGiaNhap"] = 0;
            newRow["GiamGia"] = 0;
            newRow["ThanhTien"] = 0;
            dtChiTietNhap.Rows.Add(newRow);

            SetButtonState(false);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.CurrentRow != null)
                SetButtonState(false);
            else
                MessageBox.Show("Vui lòng chọn dòng để sửa.");
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietNhap.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa dòng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    dgvChiTietNhap.Rows.RemoveAt(dgvChiTietNhap.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng để xóa.");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThemNCC_Click_1(object sender, EventArgs e)
        {
            
            BtnThemNCC_Click(sender, e);
        }

        private void dgvChiTietNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (dangThemMoi && KiemTraMaPhieuNhapTrung(txtMaPhieuNhap.Text.Trim()))
            {
                MessageBox.Show("Mã phiếu nhập đã tồn tại. Vui lòng nhập mã khác.");
                return;
            }

            if (SaveHoaDonNhap())
            {
                MessageBox.Show("Lưu phiếu nhập thành công!");
                ResetForm();
            }
            else
            {
                MessageBox.Show("Lưu phiếu nhập thất bại!");
            }
        }

        /// <summary>
        /// Kiểm tra mã phiếu nhập có bị trùng hay không
        /// </summary>
        private bool KiemTraMaPhieuNhapTrung(string maPhieuNhap)
        {
            bool isTrung = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM hoaDonNhap WHERE maHDN = @maHDN";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHDN", maPhieuNhap);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0) isTrung = true;
            }
            return isTrung;
        }

        /// <summary>
        /// Kiểm tra dữ liệu hợp lệ trước khi lưu
        /// </summary>
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Mã phiếu nhập không được để trống.");
                return false;
            }
            if (cboMaNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.");
                return false;
            }
            if (dtChiTietNhap.Rows.Count == 0)
            {
                MessageBox.Show("Chi tiết nhập không được để trống.");
                return false;
            }
            foreach (DataRow row in dtChiTietNhap.Rows)
            {
                if (row["MaQuanAo"] == null || string.IsNullOrWhiteSpace(row["MaQuanAo"].ToString()))
                {
                    MessageBox.Show("Mã sản phẩm không được để trống.");
                    return false;
                }
                if (row["SoLuong"] == null || Convert.ToInt32(row["SoLuong"]) <= 0)
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0.");
                    return false;
                }
                if (row["DonGiaNhap"] == null || Convert.ToDecimal(row["DonGiaNhap"]) < 0)
                {
                    MessageBox.Show("Đơn giá nhập không được âm.");
                    return false;
                }
                if (row["GiamGia"] == null || Convert.ToDecimal(row["GiamGia"]) < 0)
                {
                    MessageBox.Show("Giảm giá không được âm.");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Lưu phiếu nhập và chi tiết vào CSDL
        /// </summary>
        private bool SaveHoaDonNhap()
        {
            bool success = false;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert hóa đơn nhập
                    string insertHDN = @"INSERT INTO hoaDonNhap (maHDN, maNV, ngayNhap, maNCC, tongTien)
                                     VALUES (@maHDN, @maNV, @ngayNhap, @maNCC, @tongTien)";
                    SqlCommand cmdHDN = new SqlCommand(insertHDN, conn, transaction);
                    cmdHDN.Parameters.AddWithValue("@maHDN", txtMaPhieuNhap.Text.Trim());
                    cmdHDN.Parameters.AddWithValue("@maNV", "NV01"); // Cập nhật sau cho đúng nhân viên thực tế
                    cmdHDN.Parameters.AddWithValue("@ngayNhap", dtpNgayNhap.Value);
                    cmdHDN.Parameters.AddWithValue("@maNCC", cboMaNhaCungCap.SelectedValue.ToString());
                    cmdHDN.Parameters.AddWithValue("@tongTien", TinhTongTien());

                    cmdHDN.ExecuteNonQuery();

                    // Insert chi tiết nhập
                    foreach (DataRow row in dtChiTietNhap.Rows)
                    {
                        string insertCT = @"INSERT INTO chiTietHDNhap (maHDN, maQuanAo, soLuong, donGia, giamGia, thanhTien)
                                        VALUES (@maHDN, @maQuanAo, @soLuong, @donGia, @giamGia, @thanhTien)";
                        SqlCommand cmdCT = new SqlCommand(insertCT, conn, transaction);
                        cmdCT.Parameters.AddWithValue("@maHDN", txtMaPhieuNhap.Text.Trim());
                        cmdCT.Parameters.AddWithValue("@maQuanAo", row["MaQuanAo"]);
                        cmdCT.Parameters.AddWithValue("@soLuong", row["SoLuong"]);
                        cmdCT.Parameters.AddWithValue("@donGia", row["DonGiaNhap"]);
                        cmdCT.Parameters.AddWithValue("@giamGia", row["GiamGia"]);
                        cmdCT.Parameters.AddWithValue("@thanhTien", row["ThanhTien"]);

                        cmdCT.ExecuteNonQuery();
                    }

                    // Cập nhật tồn kho sản phẩm
                    CapNhatTonKho(conn, transaction);

                    transaction.Commit();
                    success = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message);
                }
            }
            return success;
        }

        /// <summary>
        /// Cập nhật tồn kho sau khi nhập hàng thành công
        /// </summary>
        private void CapNhatTonKho(SqlConnection conn, SqlTransaction transaction)
        {
            foreach (DataRow row in dtChiTietNhap.Rows)
            {
                string updateTonKho = @"UPDATE sanPham 
                                       SET soLuong = soLuong + @soLuongNhap
                                       WHERE maQuanAo = @maQuanAo";
                SqlCommand cmd = new SqlCommand(updateTonKho, conn, transaction);
                cmd.Parameters.AddWithValue("@soLuongNhap", row["SoLuong"]);
                cmd.Parameters.AddWithValue("@maQuanAo", row["MaQuanAo"]);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tính tổng tiền tất cả chi tiết nhập
        /// </summary>
        private decimal TinhTongTien()
        {
            decimal tong = 0;
            foreach (DataRow row in dtChiTietNhap.Rows)
            {
                if (row["ThanhTien"] != DBNull.Value)
                    tong += Convert.ToDecimal(row["ThanhTien"]);
            }
            return tong;
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Xử lý khi cell DataGridView đang được chỉnh sửa, để bắt sự kiện nhập liệu nếu cần (ví dụ chỉ cho nhập số ở cột số lượng, giá...)
        /// </summary>
        private void DgvChiTietNhap_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvChiTietNhap.CurrentCell.ColumnIndex == dtChiTietNhap.Columns["SoLuong"].Ordinal ||
                dgvChiTietNhap.CurrentCell.ColumnIndex == dtChiTietNhap.Columns["DonGiaNhap"].Ordinal ||
                dgvChiTietNhap.CurrentCell.ColumnIndex == dtChiTietNhap.Columns["GiamGia"].Ordinal)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Tb_KeyPress; // Gỡ event cũ nếu có
                    tb.KeyPress += Tb_KeyPress; // Thêm event kiểm tra chỉ nhập số
                }
            }
            else
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= Tb_KeyPress;
                }
            }
        }

        /// <summary>
        /// Giới hạn nhập chỉ cho phép số và phím điều khiển trong các ô số lượng, đơn giá, giảm giá
        /// </summary>
        private void Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép nhập số, backspace và dấu chấm (.), dấu phẩy (,)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Không cho phép nhập dấu chấm hoặc dấu phẩy nhiều lần
            TextBox tb = sender as TextBox;
            if ((e.KeyChar == '.' || e.KeyChar == ',') && tb.Text.IndexOfAny(new char[] { '.', ',' }) > -1)
            {
                e.Handled = true;
            }
        }
    }
}