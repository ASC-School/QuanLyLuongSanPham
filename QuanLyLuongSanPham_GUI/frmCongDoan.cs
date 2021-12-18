using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLuongSanPham_BUS;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Trần Văn Sỹ,Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 17/11/2021
     */
    public partial class frmCongDoan : DevExpress.XtraEditors.XtraForm
    {
        public frmCongDoan()
        {
            InitializeComponent();
            addLuoiSanPhamSanXuat(dtgvDSSanPham);
            addLuoiCongDoan(dtgvDSCongDoan);
        }
        BindingSource bsSanPhamSX = new BindingSource();
        BindingSource bsCongDoan = new BindingSource();
        BUS_CongDoanSanXuat busCongDoan = new BUS_CongDoanSanXuat();
        int soLuong = 0;
        private void frmCongDoan_Load(object sender, EventArgs e)
        {
            offControlInput();
            this.dtgvDSCongDoan.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvDSSanPham.DefaultCellStyle.ForeColor = Color.Black;
            _ = this.dtgvDSCongDoan.RowHeadersDefaultCellStyle.Font.Bold;
            _ = this.dtgvDSSanPham.RowHeadersDefaultCellStyle.Font.Bold;
            loadCbo();
            loadDSSanPhamXStoDataGridView();
            loadDSCongDoantoDataGridView();
        }

        private void addLuoiSanPhamSanXuat(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maSanPhamSanXuat";
            dc.HeaderText = "Mã sản phẩm sản xuất";
            dc.Name = "maSanPhamSanXuat";
            dc.Width = 100;
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maDonHang";
            dc.HeaderText = "Mã đơn hàng";
            dc.Name = "maDonHang";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenSanPham";
            dc.HeaderText = "Tên sản phẩm";
            dc.Name = "tenSanPham";
            dc.Visible = true;
            dc.Width = 200;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soLuongSanXuat";
            dc.HeaderText = "Số lượng sản xuất";
            dc.Width = 100;
            dc.Name = "soLuongSanXuat";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "trangThai";
            dc.HeaderText = "Trạng thái";
            dc.Name = "trangThai";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

        }

        private void addLuoiCongDoan(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soThuTu";
            dc.HeaderText = "Mã công đoạn";
            dc.Name = "soThuTu";
            dc.Visible = true;
            dc.Width = 200;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenCongDoan";
            dc.HeaderText = "Tên công đoạn";
            dc.Name = "tenCongDoan";
            dc.Visible = true;
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "donGia";
            dc.HeaderText = "Giá tiền công đoạn";
            dc.Name = "donGia";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "thuTuCongDoan";
            dc.HeaderText = "Thứ tự công đoạn";
            dc.Name = "thuTuCongDoan";
            dc.Width = 100;
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maSanPhamSanXuat";
            dc.HeaderText = "Mã sản phẩm sản xuất";
            dc.Name = "maSanPhamSanXuat";
            dc.Width = 100;
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenSanPhamSanXuat";
            dc.HeaderText = "Tên sản phẩm sản xuất";
            dc.Name = "tenSanPhamSanXuat";
            dc.Visible = true;
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soLuongSanXuat";
            dc.HeaderText = "Số lượng sản xuất";
            dc.Name = "soLuongSanXuat";
            dc.Visible = true;
            dc.Width = 200;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maRangBuoc";
            dc.HeaderText = "Mã ràng buộc";
            dc.Name = "maRangBuoc";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "ngayBatDau";
            dc.HeaderText = "Ngày bắt đầu";
            dc.Name = "ngayBatDau";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "ngayKetThuc";
            dc.HeaderText = "Ngày kêt thúc";
            dc.Name = "ngayKetThuc";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "trangThai";
            dc.HeaderText = "Trạng thái";
            dc.Name = "trangThai";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

        }
        public void loadDSSanPhamXStoDataGridView()
        {
            bsSanPhamSX.DataSource = busCongDoan.layDSSanPhamSanXuat();
            dtgvDSSanPham.DataSource = bsSanPhamSX;
            bindingNavigatorDSSanPhamSX.BindingSource = bsSanPhamSX;
        }

        public void loadDSCongDoantoDataGridView()
        {
            bsCongDoan.DataSource = busCongDoan.layDSCongDoan();
            dtgvDSCongDoan.DataSource = bsCongDoan;
            bindingNavigatorDSCongDoan.BindingSource = bsCongDoan;
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tatBtn()
        {
            if (dtgvDSCongDoan.SelectedRows.Count > 0)
            {
                btnSuaCongDoan.Enabled = true;
                btnXoaCongDoan.Enabled = true;
            }
            else
            {
                btnSuaCongDoan.Enabled = false;
                btnXoaCongDoan.Enabled = false;
            }    
        }
        private void dtgvDSCongDoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tatBtn();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDSCongDoan.Rows[e.RowIndex];
                txtMaCongDoan.Text = row.Cells[0].Value.ToString();
                txtTenCongDoan.Text = row.Cells[1].Value.ToString();
                txtDonGia.Text = row.Cells[2].Value.ToString();
                //cboThuTuCongDoan.Text = row.Cells[3].Value.ToString();
                cboMaSanPhamSanXuat.Text = row.Cells[4].Value.ToString();
                cboTenSanPhamm.Text = row.Cells[5].Value.ToString();
                txtSoLuongSanXuat.Text = row.Cells[6].Value.ToString();
                soLuong = Convert.ToInt32(row.Cells[6].Value.ToString());
                if (row.Cells[7].Value == null)
                    cboMaRangBuoc.Text = "None";
                else
                    cboMaRangBuoc.Text = row.Cells[7].Value.ToString();
                dateNgayBatDau.Text = row.Cells[8].Value.ToString();
                dateNgayKetThuc.Text = row.Cells[9].Value.ToString();
                if (row.Cells[10].Value.ToString().Equals("True"))
                {
                    cboTrangThai.Text = "Chưa hoàn thành";
                    row.Cells[10].Style.BackColor = Color.Green;
                }    
                else
                {
                    cboTrangThai.Text = "Hoàn thành";
                    btnThemCongDoan.Enabled = false;
                    btnXoaCongDoan.Enabled = true;
                    row.Cells[10].Style.BackColor = Color.Red;
                }    
            }
        }
        private void offControlInput()
        {
            txtMaCongDoan.Enabled = false;
            txtTenCongDoan.Enabled = false;
            txtDonGia.Enabled = false;
            cboTenSanPhamm.Enabled = false;
            txtSoLuongSanXuat.Enabled = false;
            cboMaRangBuoc.Enabled = false;
            dateNgayBatDau.Enabled = false;
            dateNgayKetThuc.Enabled = false;
            cboTrangThai.Enabled = false;
            cboMaSanPhamSanXuat.Enabled = false;
            cboThuTuCongDoan.Enabled = false;
        }
        private void onControlInput()
        {
            txtTenCongDoan.Enabled = true;
            txtDonGia.Enabled = true;
            cboTenSanPhamm.Enabled = true;
            txtSoLuongSanXuat.Enabled = true;
            cboMaRangBuoc.Enabled = true;
            dateNgayBatDau.Enabled = true;
            dateNgayKetThuc.Enabled = true;
            cboTrangThai.Enabled = true;
            cboMaSanPhamSanXuat.Enabled = true;
            cboThuTuCongDoan.Enabled = true;
        }
        private void clearControlInput()
        {
            txtSoLuongSanXuat.Text = "";
            txtMaCongDoan.Text = "";
            txtTenCongDoan.Text = "";
            txtDonGia.Text = "";
            cboTenSanPhamm.Text = "None";
            cboMaSanPhamSanXuat.Text = "None";
            cboMaRangBuoc.Text = "None";
            dateNgayBatDau.Text = "";
            dateNgayKetThuc.Text = "";
            cboTrangThai.Text = "";
            cboThuTuCongDoan.Text = "";
        }
        private void loadCbo()
        {
            cboTenSanPhamm.DataSource = busCongDoan.layTenSanPhamSX();
            cboMaSanPhamSanXuat.DataSource = busCongDoan.layDSMaSanPhamSanXuat();
            List<string> thuTuCongDoan = new List<string>();
            thuTuCongDoan.Add("None");
            for (int i = 1; i < 21; i++)
            {
                thuTuCongDoan.Add("Công đoạn " + i);
            }
            cboThuTuCongDoan.DataSource = thuTuCongDoan;
            if (cboTenSanPhamm.Text.Equals("") && cboTenSanPhamm.Equals("None"))
                cboMaRangBuoc.DataSource = busCongDoan.layMaCongDoanTheoSanPhamSanXuat(cboTenSanPhamm.Text);
            else 
                cboMaRangBuoc.DataSource = null;

            List<string> lstTrangThaiCongDoan = new List<string>();
            lstTrangThaiCongDoan.Add("Chưa hoàn thành");
            lstTrangThaiCongDoan.Add("Hoàn thành");
            cboTrangThai.DataSource = lstTrangThaiCongDoan;
            cboTrangThai.SelectedIndex = 0;
        }

        private bool kiemTraSoLuongSanPham(string soLuongSP)
        {
            if (Convert.ToInt32(soLuongSP) < soLuong || Convert.ToInt32(soLuongSP) > 10000)
                return false;
            else
                return true;
        }
        private bool kiemTraNull()
        {
            if (txtMaCongDoan.Text == "" || txtTenCongDoan.Text == "" || txtDonGia.Text == ""|| txtSoLuongSanXuat.Text == "" || cboTenSanPhamm.Text.Equals("None") || cboTenSanPhamm.Equals("")  || cboThuTuCongDoan.Text.Equals("") || cboThuTuCongDoan.Text.Equals("None") || dateNgayBatDau.Text.Equals("") ||  dateNgayKetThuc.Text.Equals("") || cboTrangThai.Text.Equals("") || cboMaSanPhamSanXuat.Text.Equals("None") || cboMaSanPhamSanXuat.Text.Equals(""))
            {
                return true;
            }
            return false;
        }

        private bool kiemTraNgayThang()
        {
            DTO_DonHang donHang = busCongDoan.layThongTinDonHang(cboMaSanPhamSanXuat.Text);
            DateTime ngayBD = DateTime.Parse(dateNgayBatDau.Text);
            DateTime ngayKT = DateTime.Parse(dateNgayKetThuc.Text);
            // nếu ngày bd công đoạn trươc
            errorLoi.Clear();
            if (ngayBD < donHang.NgayBatDau || ngayBD > donHang.NgayKetThuc)
            {
                errorLoi.SetError(dateNgayBatDau, "Ngày bắt đầu không hợp lệ");
                return false;
            }
            else
            {
                errorLoi.Clear();
                if (ngayKT < ngayBD || ngayKT > donHang.NgayKetThuc)
                {
                    errorLoi.SetError(dateNgayKetThuc, "Ngày kết thúc không hợp lệ");
                    return false;
                }
            }

            return true;
        } 

        private DTO_CongDoanSanXuat taoCongDoanMoi()
        {
            DTO_CongDoanSanXuat newCongDoan = new DTO_CongDoanSanXuat();
            newCongDoan.SoThuTu = Convert.ToInt32(txtMaCongDoan.Text);
            newCongDoan.TenCongDoan = txtTenCongDoan.Text;
            newCongDoan.DonGia = decimal.Parse(txtDonGia.Text);
            newCongDoan.ThuTuCongDoan = cboThuTuCongDoan.Text;
            newCongDoan.MaSanPhamSanXuat = cboMaSanPhamSanXuat.Text;
            newCongDoan.MaRangBuoc = cboMaRangBuoc.Text;
            newCongDoan.NgayBatDau = DateTime.Parse(dateNgayBatDau.Text);
            newCongDoan.NgayKetThuc = DateTime.Parse(dateNgayKetThuc.Text);
            newCongDoan.TrangThai = true;// chưa honaf thành
            return newCongDoan;
        }

        private void btnThemCongDoan_Click(object sender, EventArgs e)
        {
            if(btnThemCongDoan.Text.Equals("Thêm"))
            {
                onControlInput();
                txtMaCongDoan.Enabled = true;
                clearControlInput();
                txtMaCongDoan.Focus();
                btnThemCongDoan.Text = "Lưu";
                cboTrangThai.Text = "Chưa hoàn thành";
                cboTrangThai.Enabled = false;
            }
            else if (kiemTraNull() == true)
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //btnThemCongDoan.Text = "Thêm";
                //offControlInput();
            }
            else if(!kiemTraSoLuongSanPham(txtSoLuongSanXuat.Text))
            {           
                MessageBox.Show("Số lượng sản phẩm không hợp lệ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }else if(!kiemTraNgayThang())
            {
               // MessageBox.Show("Số lượng sản phẩm không hợp lệ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DTO_CongDoanSanXuat cd = taoCongDoanMoi();
                if(cd == null)
                {
                    MessageBox.Show("Tạo công đoạn mới không thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                if (busCongDoan.addCongDoan(cd) == true)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busCongDoan.addCongDoan(cd);
                    loadDSCongDoantoDataGridView();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                btnThemCongDoan.Text = "Thêm";
                clearControlInput();
                offControlInput();
            }
        }

        private void btnSuaCongDoan_Click(object sender, EventArgs e)
        {
            if (btnSuaCongDoan.Text.Equals("Sửa"))
            {
                offControlInput();
                btnSuaCongDoan.Text = "Lưu";
                txtTenCongDoan.Enabled = true;
                txtDonGia.Enabled = true;
                cboMaRangBuoc.Enabled = true;
                dateNgayBatDau.Enabled = true;
                dateNgayKetThuc.Enabled = true;
                cboTrangThai.Enabled = true;
                txtSoLuongSanXuat.Enabled = true;
            }
            else if (kiemTraNull() == true)
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //btnThemCongDoan.Text = "Sửa";
                //offControlInput();
            }
            else if(!kiemTraSoLuongSanPham(txtSoLuongSanXuat.Text))
            {
                MessageBox.Show("Số lượng sản phẩm không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DTO_CongDoanSanXuat cd = taoCongDoanMoi();
                if (cd == null)
                {
                    MessageBox.Show("Tạo công đoạn mới không thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                if (busCongDoan.upDateCongDoan(cd) == true)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busCongDoan.upDateCongDoan(cd);
                    dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoan();
                }
                else
                {
                    MessageBox.Show("Fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Close();
                }
                offControlInput();
                btnSuaCongDoan.Text = "Thêm";
            }

        }

        private void btnXoaCongDoan_Click(object sender, EventArgs e)
        {
            DialogResult dlgAnswer;
            if (dtgvDSCongDoan.SelectedRows.Count > 0)
            {
                dlgAnswer = MessageBox.Show("Bạn có muốn xóa ???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dlgAnswer == DialogResult.Yes)
                {
                    bool cd = busCongDoan.delCongDoan(Convert.ToInt32(txtMaCongDoan.Text));
                    if (cd == true)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLoadDSCongDoan_Click(object sender, EventArgs e)
        {
            loadDSCongDoantoDataGridView();
        }

        private void dtgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDSSanPham.Rows[e.RowIndex];
                cboMaSanPhamSanXuat.Text = row.Cells[0].Value.ToString();
                cboTenSanPhamm.Text = row.Cells[2].Value.ToString();
                txtSoLuongSanXuat.Text = row.Cells[3].Value.ToString();
                soLuong = Convert.ToInt32(txtSoLuongSanXuat.Text);
            }
        }

        private void cboMaSanPhamSanXuat_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboMaSanPhamSanXuat.SelectedIndex == -1)
                return;
            else
            {
                string tenSanPham = busCongDoan.timTenSanPhamSXTheoMa(cboMaSanPhamSanXuat.SelectedItem.ToString());
                List<string> maConDoan = busCongDoan.layMaCongDoanTheoSanPhamSanXuat(cboMaSanPhamSanXuat.SelectedItem.ToString());
                cboMaRangBuoc.DataSource = maConDoan;
                cboTenSanPhamm.Text = tenSanPham;
                soLuong = busCongDoan.laySoLuongSanPhamTheoSanPhamSanXuat(cboMaSanPhamSanXuat.SelectedItem.ToString());
            }
        }
    }
}