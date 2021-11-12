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
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_BUS;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmGDQLDonHang : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bsPH;
        BUS_DonHang donHangBUS;
        BUS_NhanVien nhanVienBUS;
        public frmGDQLDonHang()
        {
            InitializeComponent();
            donHangBUS = new BUS_DonHang();
            bsPH = new BindingSource();
            nhanVienBUS = new BUS_NhanVien();
        }

        private void frmGDQLDonHang_Load(object sender, EventArgs e)
        {
            // ẩn nút
            btnLuuDonHang.Enabled = false;
            btnHuyDonHang.Enabled = false;
            btnInDonHang.Enabled = false;

            loadDonHangToDataGridView();
            FormatLuoi(dgvDSDonHang);
            loadComBoBox();
        }
        private void loadDonHangToDataGridView()
        {
            // load data
            bsPH.DataSource = donHangBUS.getAllDonHang();
            dgvDSDonHang.DataSource = bsPH;
            bindingNavigatorDonHang.BindingSource = bsPH;
            FormatLuoi(dgvDSDonHang);
        }

        void FormatLuoi(DataGridView dgr)
        {
            dgr.Columns["maDonHang"].HeaderText = "Mã đơn hàng";
            dgr.Columns["tenKhachHang"].HeaderText = "Tên khách hàng";
            dgr.Columns["tenKhachHang"].Width = 200;
            dgr.Columns["soDienThoaiKhachHang"].HeaderText = "Số điện thoại khách hàng";
            dgr.Columns["ngayBatDau"].HeaderText = "Ngày bắt đầu";
            dgr.Columns["ngayKetThuc"].HeaderText = "Ngày kết thúc";
            dgr.Columns["noiDung"].HeaderText = "Nội dung";
            dgr.Columns["maNhanVien"].HeaderText = "Mã Nhân Viên";
            dgr.Columns["tenNhanVien"].HeaderText = "Tên Nhân Viên";
            dgr.Columns["tenNhanVien"].Width = 200;
        }

        public void formatTextBox()
        {
            txtMaDonHang.Clear();
            dateNgayBatDau.Text = "";
            dateNgayKetThuc.Text = "";
            txtTenKhachHang.Clear();
            cboMaNhanVien.Text = "";
            cboTenNhanVien.Text = "";
            txtNoiDung.Clear();
            txtSoDienKhachHang.Clear();
        }

        private void khoaThongTin()
        {
            txtMaDonHang.Enabled = false;
            dateNgayBatDau.Enabled = false;
            dateNgayKetThuc.Enabled = false;
            txtTenKhachHang.Enabled = false;
            cboMaNhanVien.Enabled = false;
            cboTenNhanVien.Enabled = false;
            txtNoiDung.Enabled = false;
            txtSoDienKhachHang.Enabled = false;
            
        }
        private void hienThongTin()
        {
            txtMaDonHang.Enabled = true;
            dateNgayBatDau.Enabled = true;
            dateNgayKetThuc.Enabled = true;
            txtTenKhachHang.Enabled = true;
            cboMaNhanVien.Enabled = true;
            cboTenNhanVien.Enabled = true;
            txtNoiDung.Enabled = true;
            txtSoDienKhachHang.Enabled = true;
          
        }

        private DTO_DonHang taoDonHang()
        {
            DTO_DonHang donHang = new DTO_DonHang();
            donHang.MaDonHang = txtMaDonHang.Text;
            donHang.TenKhachHang = txtTenKhachHang.Text;
            donHang.SoDienThoaiKhachHang = txtSoDienKhachHang.Text;
            donHang.NgayBatDau = DateTime.Parse(dateNgayBatDau.Text);
            donHang.NgayKetThuc = DateTime.Parse(dateNgayKetThuc.Text);
            donHang.NoiDung = txtNoiDung.Text;
            donHang.MaNhanVien = cboMaNhanVien.Text;
            return donHang;
        }

        private void loadComBoBox()
        {
            List<DTO_NhanVien> lstNhanVien = nhanVienBUS.getDSNhanVienForDonHang();
            List<string> maNhanVien = new List<string>();
            List<string> tenNhanVien = new List<string>();
            foreach(DTO_NhanVien nhanVien in lstNhanVien)
            {
                maNhanVien.Add(nhanVien.MaNhanVien);
                tenNhanVien.Add(nhanVien.TenNhanVien);
            }
            cboMaNhanVien.DataSource = maNhanVien;
            cboTenNhanVien.DataSource = tenNhanVien;
                              
        }
       
        private void btnDongGD_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            if(!btnThemDonHang.Text.Equals("Hủy thêm"))
            {
                btnLuuDonHang.Enabled = true;
                btnThemDonHang.Text = "Hủy thêm";
                formatTextBox();
                hienThongTin();
            }
            else
            {
                btnLuuDonHang.Enabled = false;
                btnThemDonHang.Text = "Thêm đơn hàng";
            }
        }

        private void dgvDSDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLuuDonHang.Enabled = true;
            btnHuyDonHang.Enabled = true;
            btnInDonHang.Enabled = true;
            hienThongTin();
            DataGridViewRow row = this.dgvDSDonHang.Rows[e.RowIndex];
            txtMaDonHang.Text = row.Cells[0].Value.ToString();
            dateNgayBatDau.Text = row.Cells[1].Value.ToString();
            dateNgayKetThuc.Text = row.Cells[2].Value.ToString();
            txtTenKhachHang.Text = row.Cells[3].Value.ToString();
            txtSoDienKhachHang.Text = row.Cells[4].Value.ToString();
            txtNoiDung.Text = row.Cells[5].Value.ToString();
            cboMaNhanVien.Text = row.Cells[6].Value.ToString();
            cboTenNhanVien.Text = row.Cells[7].Value.ToString();
        }

        private void btnLoadDSDonHang_Click(object sender, EventArgs e)
        {
            loadDonHangToDataGridView();
            FormatLuoi(dgvDSDonHang);
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhanVien.SelectedIndex == -1)
                return;
            else
            {
                if (cboTenNhanVien.DataSource == null)
                    return;
                cboTenNhanVien.SelectedIndex = cboMaNhanVien.SelectedIndex;
            }
        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenNhanVien.SelectedIndex == -1)
                return;
            else
            {
                if (cboMaNhanVien.DataSource == null)
                    return;
                cboMaNhanVien.SelectedIndex = cboTenNhanVien.SelectedIndex;
            }
        }

        private void btnLuuDonHang_Click(object sender, EventArgs e)
        {

        }

        private void btnHuyDonHang_Click(object sender, EventArgs e)
        {

        }

        private void btnInDonHang_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaDonHang_Click(object sender, EventArgs e)
        {

        }
    }
}