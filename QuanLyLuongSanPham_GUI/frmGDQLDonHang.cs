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
using System.Text.RegularExpressions;
using QuanLyLuongSanPham_GUI.Regular_Expression;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmGDQLDonHang : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bsPH;
        BUS_DonHang donHangBUS;
        BUS_NhanVien nhanVienBUS;
        checkFrmDonHang checkDH = new checkFrmDonHang();
        DTO_DonHang newDonHang;

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
            foreach (DTO_NhanVien nhanVien in lstNhanVien)
            {
                maNhanVien.Add(nhanVien.MaNhanVien);
                tenNhanVien.Add(nhanVien.TenNhanVien);
            }
            cboMaNhanVien.DataSource = maNhanVien;
            cboTenNhanVien.DataSource = tenNhanVien;

        }

        private bool chechEmptyDonHang()
        {
            if (txtMaDonHang.Text.Equals(""))
            {
                errLoi.SetError(txtMaDonHang, "Bạn phải nhập mã đơn hàng");
                txtMaDonHang.Focus();
                return false;
            }
            else
            {
                errLoi.Clear();
                if (dateNgayBatDau.Text.Equals(""))
                {
                    errLoi.SetError(dateNgayBatDau, "Bạn phải chọn ngày bắt đầu!!");
                    dateNgayBatDau.Focus();
                    return false;
                }
                else
                {
                    errLoi.Clear();
                    if (dateNgayKetThuc.Text.Equals(""))
                    {
                        errLoi.SetError(dateNgayKetThuc, "Bạn phải chọn ngày kết thúc!!");
                        dateNgayKetThuc.Focus();
                        return false;
                    }
                    else
                    {
                        errLoi.Clear();
                        if (txtTenKhachHang.Text.Equals(""))
                        {
                            errLoi.SetError(txtTenKhachHang, "Bạn phải nhập tên khách hàng!!");
                            txtTenKhachHang.Focus();
                            return false;
                        }
                        else
                        {
                            errLoi.Clear();
                            if (cboMaNhanVien.Text.Equals(""))
                            {
                                errLoi.SetError(cboMaNhanVien, "Mã nhân viên không được để trống!!");
                                cboMaNhanVien.Focus();
                                return false;
                            }
                            else
                            {
                                errLoi.Clear();
                                if (cboTenNhanVien.Text.Equals(""))
                                {
                                    errLoi.SetError(cboTenNhanVien, "Tên nhân viên không được để trống!");
                                    cboTenNhanVien.Focus();
                                    return false;
                                }
                                else
                                {
                                    errLoi.Clear();
                                    if (txtNoiDung.Text.Equals(""))
                                    {
                                        errLoi.SetError(txtNoiDung, "Bạn phải nhập nội dung cho đơn hàng!!");
                                        txtNoiDung.Focus();
                                        return false;
                                    }
                                    else
                                    {
                                        errLoi.Clear();
                                        if (txtSoDienKhachHang.Text.Equals(""))
                                        {
                                            errLoi.SetError(txtSoDienKhachHang, "Bạn phải nhập số điện thoại khách hàng!!");
                                            txtSoDienKhachHang.Focus();
                                            return false;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
        private void btnDongGD_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialog == DialogResult.Yes)
                this.Close();
        }

        private bool checkMaDonHang(string maDonHang)
        {
            if (checkDH.checkMaDonHang(maDonHang))
            {
                if (donHangBUS.checkTonTaiDonHang(maDonHang))
                {
                    MessageBox.Show("Đơn hàng này đã tồn tại!!");
                    return false;
                }
            }
            return true;
        }

        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            if (!btnThemDonHang.Text.Equals("Hủy thêm"))
            {
                btnLuuDonHang.Enabled = true;
                btnSuaDonHang.Enabled = false;
                btnHuyDonHang.Enabled = false;
                btnTimKiem.Enabled = false;
                btnDongGD.Enabled = false;
                btnChiTietDonHang.Enabled = false;
                btnThemDonHang.Text = "Hủy thêm";
                formatTextBox();
                hienThongTin();
                txtMaDonHang.Enabled = true;
            }
            else
            {
                btnLuuDonHang.Enabled = false;
                btnSuaDonHang.Enabled = true;
                btnHuyDonHang.Enabled = true;
                btnTimKiem.Enabled = true;
                btnDongGD.Enabled = true;
                btnThemDonHang.Text = "Thêm đơn hàng";
                khoaThongTin();
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
            if (chechEmptyDonHang())
            {
                if (btnThemDonHang.Text.Equals("Hủy thêm"))
                {
                    DialogResult hoiThem;
                    hoiThem = MessageBox.Show("Bạn có muốn thêm?", "Hỏi thêm đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (hoiThem == DialogResult.Yes)
                    {
                        newDonHang = taoDonHang();
                        if (donHangBUS.checkTonTaiDonHang(newDonHang.MaDonHang)) MessageBox.Show("Đơn hàng đã tồn tại!!");
                        else
                        {
                            donHangBUS.themDonHang(newDonHang);
                            newDonHang = null;
                            formatTextBox();
                            btnLuuDonHang.Enabled = false;
                            btnThemDonHang.Text = "Thêm đơn hàng";
                            khoaThongTin();
                            loadDonHangToDataGridView();
                            MessageBox.Show("Thêm đơn hàng thành công!!");
                        }


                    }
                    else
                    {
                        MessageBox.Show("Thêm đơn hàng không thành công!!");
                    }

                }
                else if (btnSuaDonHang.Text.Equals("Hủy sửa"))
                {
                    newDonHang = taoDonHang();
                    DialogResult hoiThem;
                    hoiThem = MessageBox.Show("Bạn có muốn sửa thông tin đơn hàng?", "Hỏi sửa thông tin đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (hoiThem == DialogResult.Yes)
                    {
                        donHangBUS.suaDonHang(newDonHang);
                        newDonHang = null;
                        formatTextBox();
                        btnLuuDonHang.Enabled = false;
                        btnSuaDonHang.Text = "Sửa đơn hàng";
                        khoaThongTin();
                        MessageBox.Show("Sửa thông tin đơn hàng thành công!!");
                        loadDonHangToDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thông tin đơn hàng không thành công!!");
                    }

                }
            }
            else
            {
                MessageBox.Show("Bạn vui lòng nhập đầy đủ thông tin!!");
            }
        }

        private void btnHuyDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoiXoa;
                if (dgvDSDonHang.SelectedCells.Count > 0)
                {
                    hoiXoa = MessageBox.Show("Bạn có muốn xóa?", "Hỏi xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (hoiXoa == DialogResult.Yes)
                    {
                        errLoi.Clear();
                        bool donHang = donHangBUS.xoaDonHang(txtMaDonHang.Text);
                        if (donHang)
                        {
                            MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDonHangToDataGridView();
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

        private void btnInDonHang_Click(object sender, EventArgs e)
        {

        }

        private void btnSuaDonHang_Click(object sender, EventArgs e)
        {
            if (!btnSuaDonHang.Text.Equals("Hủy sửa"))
            {
                btnLuuDonHang.Enabled = true;
                btnHuyDonHang.Enabled = false;
                btnThemDonHang.Enabled = false;
                btnTimKiem.Enabled = false;
                btnSuaDonHang.Text = "Hủy sửa";
                hienThongTin();

            }
            else
            {
                btnHuyDonHang.Enabled = true;
                btnThemDonHang.Enabled = true;
                btnTimKiem.Enabled = true;
                btnLuuDonHang.Enabled = false;
                btnSuaDonHang.Text = "Sửa đơn hàng";
                khoaThongTin();
            }
        }
        bool KiemTraTonTaiForm(string frmTenForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(frm))
                {
                    frm.Activate();//sang len
                    return true;
                }
            }
            return false;
        }

        private void btnChiTietDonHang_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTaiForm("frmChiTietDonHang") == false)
            {
                DTO_DonHang donHang = donHangBUS.getDonHang(txtMaDonHang.Text);
                frmChiTietDonHang frm = new frmChiTietDonHang(donHang);
                frm.ShowDialog();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemDonHang frm = new frmTimKiemDonHang();
            frm.ShowDialog();
        }
    }
}