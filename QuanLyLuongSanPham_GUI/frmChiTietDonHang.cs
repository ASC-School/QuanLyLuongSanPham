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
    public partial class frmChiTietDonHang : DevExpress.XtraEditors.XtraForm
    {
        public frmChiTietDonHang()
        {
            InitializeComponent();
        }
        DTO_DonHang donHangDTO;
        BUS_DonHang donHangBUS;
        BindingSource bsPH;
        BUS_NhanVien nhanVienBUS;
        List<DTO_SanPham> lstSanPham;
        public frmChiTietDonHang(DTO_DonHang donHang): this()
        {
            donHangDTO = donHang;
            txtMaDonHang.Text = donHang.MaDonHang;
            txtTenKhachHang.Text = donHang.TenKhachHang;
            txtSoDienThoaiKhachHang.Text = donHang.SoDienThoaiKhachHang;
            txtMaNhanVien.Text = donHang.MaNhanVien;
            donHangBUS = new BUS_DonHang();
            bsPH = new BindingSource();
            lstSanPham = donHangBUS.getDSSanPham();
        }

        private void loadChiTietDonHangToDataGridView()
        {
            bsPH.DataSource = donHangBUS.getAllChiTietDonHang(donHangDTO.MaDonHang);
            dgvChiTietDonHang.DataSource = bsPH;
            bindingNavigatorCTDH.BindingSource = bsPH;
            FormatLuoi(dgvChiTietDonHang);
            loadCboSanPham();
        }

        private void FormatLuoi(DataGridView dgr)
        {
            dgr.Columns["maDonHang"].HeaderText = "Mã đơn hàng";
            dgr.Columns["tenKhachHang"].HeaderText = "Tên khách hàng";
            dgr.Columns["tenKhachHang"].Width = 200;
            dgr.Columns["soDienThoaiKhachHang"].HeaderText = "Số điện thoại khách hàng";
            dgr.Columns["maSanPham"].HeaderText = "Mã sản phẩm";
            dgr.Columns["tenSanPham"].HeaderText = "Tên sản phảm";
            dgr.Columns["soLuong"].HeaderText = "Số lượng";
            dgr.Columns["donGiaSanPham"].HeaderText = "Đơn giá";
            dgr.Columns["thanhTien"].HeaderText = "Thành tiền";
            dgr.Columns["maNhanVien"].HeaderText = "Mã nhân viên";
        }
        private DTO_SanPham getSanPham(string tenSanPham)
        {
            int i = 0;
            foreach(DTO_SanPham sp in lstSanPham)
            {
                if (sp.TenSanPham.Equals(tenSanPham))
                    return sp;
            }
            return null;
        }
        private void loadCboSanPham()
        {
            
            List<string> tenSanPham = new List<string>();
            foreach(DTO_SanPham sp in lstSanPham)
            {
                tenSanPham.Add(sp.TenSanPham);
            }
            cboTenSanPham.DataSource = tenSanPham;
        }
        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {
            loadChiTietDonHangToDataGridView();
        }
        private void btnHoanTat_Click(object sender, EventArgs e)
        {

        }

        private void cboTenSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboTenSanPham.SelectedIndex == -1)
                return;
            else
            {
                DTO_SanPham sanPham = getSanPham(cboTenSanPham.SelectedItem.ToString());
                txtGiaTien.Text = sanPham.GiaBan.ToString();
                txtSoLuongSanPham.Text = "1";
            }
        }
    }
}