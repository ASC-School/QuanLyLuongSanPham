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
        BindingSource bsPHSanPham;
        BUS_NhanVien nhanVienBUS;
        List<DTO_SanPham> lstSanPham;
        DTO_ChiTietDonHang newCTDH;
        public frmChiTietDonHang(DTO_DonHang donHang): this()
        {
            donHangDTO = donHang;
            txtMaDonHang.Text = donHang.MaDonHang;
            txtTenKhachHang.Text = donHang.TenKhachHang;
            txtSoDienThoaiKhachHang.Text = donHang.SoDienThoaiKhachHang;
            txtMaNhanVien.Text = donHang.MaNhanVien;
            donHangBUS = new BUS_DonHang();
            bsPH = new BindingSource();
            bsPHSanPham = new BindingSource();
            lstSanPham = donHangBUS.getDSSanPham();
        }

        private void loadChiTietDonHangToDataGridView()
        {
            anThongTin();
            bsPH.DataSource = donHangBUS.getAllChiTietDonHang(donHangDTO.MaDonHang);
            dgvChiTietDonHang.DataSource = bsPH;
            bindingNavigatorCTDH.BindingSource = bsPH;
            FormatLuoi(dgvChiTietDonHang);
            loadCboSanPham();
            lblTongTien.Text = donHangBUS.tongTienDonHang(txtMaDonHang.Text).ToString();
        }
        private void loadDSSanPhamToDataGridView()
        {
            bsPHSanPham.DataSource = donHangBUS.getDSSanPham();
            dgvSanPham.DataSource = bsPHSanPham;
            formatLuoiSanPham(dgvSanPham);
        }

        private void formatLuoiSanPham(DataGridView dgr)
        {
            dgr.Columns["maSanPham"].HeaderText = "Mã sản phẩm";
            dgr.Columns["tenSanPham"].HeaderText = "Tên sản phảm";
            dgr.Columns["tenSanPham"].Width = 200;
            dgr.Columns["namSanXuat"].HeaderText = "Năm sản xuất";
            dgr.Columns["giaBan"].HeaderText = "Giá bán";
            dgr.Columns["trangThai"].HeaderText = "Trạng thái";
        }
        private void FormatLuoi(DataGridView dgr)
        {
            dgr.Columns["maDonHang"].HeaderText = "Mã đơn hàng";
            dgr.Columns["tenKhachHang"].HeaderText = "Tên khách hàng";
            dgr.Columns["tenKhachHang"].Width = 200;
            dgr.Columns["soDienThoaiKhachHang"].HeaderText = "Số điện thoại khách hàng";
            dgr.Columns["maSanPham"].HeaderText = "Mã sản phẩm";
            dgr.Columns["tenSanPham"].HeaderText = "Tên sản phảm";
            dgr.Columns["tenSanPham"].Width = 200;
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
            loadDSSanPhamToDataGridView();
        }

        private void hienThongTin()
        {
            cboTenSanPham.Enabled = true;
            txtGiaTien.Enabled = true;
            txtSoLuongSanPham.Enabled = true;
        }

        private void anThongTin()
        {
            txtMaDonHang.Enabled = false;
            txtTenKhachHang.Enabled = false;
            txtSoDienThoaiKhachHang.Enabled = false;
            txtMaNhanVien.Enabled = false;
            cboTenSanPham.Enabled = false;
            txtGiaTien.Enabled = false;
            txtSoLuongSanPham.Enabled = false;
        }

        private void formatTextBox()
        {
            cboTenSanPham.Text = "";
            txtGiaTien.Clear();
            txtSoLuongSanPham.Clear();
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
        
        private DTO_ChiTietDonHang taoChiTietDonHang()
        {
            DTO_SanPham sp = getSanPham(cboTenSanPham.Text);
            DTO_ChiTietDonHang ctdh = new DTO_ChiTietDonHang();
            ctdh.MaDonHang = txtMaDonHang.Text;
            ctdh.MaSanPham = sp.MaSanPham;
            ctdh.SoLuong = int.Parse(txtSoLuongSanPham.Text);
            ctdh.DonGia = decimal.Parse(txtGiaTien.Text);
            return ctdh;
        }

        

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (!btnThemSanPham.Text.Equals("Lưu"))
            {
                btnSuaChiTietDonHang.Enabled = false;
                btnXoaSanPham.Enabled = false;
                btnThemSanPham.Text = "Lưu";
                hienThongTin();
                btnHoanTat.Enabled = false;
            }
            else
            {
                btnThemSanPham.Text = "Thêm sản phảm";
                btnSuaChiTietDonHang.Enabled = true;
                btnXoaSanPham.Enabled = true;
                DialogResult hoiThem;
                hoiThem = MessageBox.Show("Bạn có muốn thêm?", "Hỏi thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiThem == DialogResult.Yes)
                {
                    newCTDH = taoChiTietDonHang();
                    if(donHangBUS.checkExistChiTietDonHang(newCTDH.MaSanPham))
                    {
                        donHangBUS.tangSoLuongSanPham(newCTDH);
                    }
                    else
                    {
                        donHangBUS.themChiTietDonHang(txtMaDonHang.Text, newCTDH);
                    }
                    formatTextBox();
                    anThongTin();
                    MessageBox.Show("Thêm thành công!!");
                    loadChiTietDonHangToDataGridView();
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!");
                }
            }
        }

        private void dgvChiTietDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvChiTietDonHang.Rows[e.RowIndex];
            cboTenSanPham.Text = row.Cells[4].Value.ToString();
            txtSoLuongSanPham.Text = row.Cells[5].Value.ToString();
            txtGiaTien.Text = row.Cells[6].Value.ToString();
        }

        private void btnSuaChiTietDonHang_Click(object sender, EventArgs e)
        {
            if (!btnSuaChiTietDonHang.Text.Equals("Lưu"))
            {

                btnSuaChiTietDonHang.Text = "Lưu";
                btnThemSanPham.Enabled = false;
                btnXoaSanPham.Enabled = false;
                hienThongTin();

            }
            else
            {
                btnSuaChiTietDonHang.Text = "Sửa sản phảm";
                btnThemSanPham.Enabled = true;
                btnXoaSanPham.Enabled = true;
                DialogResult hoiThem;
                btnHoanTat.Enabled = false;
                hoiThem = MessageBox.Show("Bạn có muốn sửa?", "Hỏi sửa chi tiết đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiThem == DialogResult.Yes)
                {
                    newCTDH = taoChiTietDonHang();
                    donHangBUS.suaChiTietDonHang(newCTDH);
                    formatTextBox();
                    anThongTin();
                    MessageBox.Show("Sửa thành công!!");
                    loadChiTietDonHangToDataGridView();
                }
                else
                {
                    MessageBox.Show("Sửa không thành công!");
                }
            }
        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvSanPham.Rows[e.RowIndex];
            cboTenSanPham.Text = row.Cells[1].Value.ToString();
            txtGiaTien.Text = row.Cells[3].Value.ToString();
        }

        private void btnLoadDSSanPham_Click(object sender, EventArgs e)
        {
            loadDSSanPhamToDataGridView();
        }

        private void btnLoadChiTietDonHang_Click(object sender, EventArgs e)
        {
            loadChiTietDonHangToDataGridView();
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoiXoa;
                if (dgvChiTietDonHang.SelectedCells.Count > 0)
                {
                    hoiXoa = MessageBox.Show("Bạn có muốn xóa?", "Hỏi xóa chi tiết đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (hoiXoa == DialogResult.Yes)
                    {
                        errLoi.Clear();
                        bool sanPham = donHangBUS.xoaChiTietDonHang(cboTenSanPham.Text);
                        if (sanPham)
                        {
                            MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadChiTietDonHangToDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        
        private void btnOpenFrmSanPham_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.ShowDialog();
        }
    }
}