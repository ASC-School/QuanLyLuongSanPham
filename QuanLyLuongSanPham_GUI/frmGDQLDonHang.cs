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
            txtTongTien.Clear();
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
            txtTongTien.Enabled = false;
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
            txtTongTien.Enabled = true;
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
            List<DTO_NhanVien> lstNhanVien = new List<DTO_NhanVien>();
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
            }
            else
            {
                btnLuuDonHang.Enabled = false;
                btnThemDonHang.Text = "Thêm đơn hàng";
            }
        }

        private void radMaDonHang_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}