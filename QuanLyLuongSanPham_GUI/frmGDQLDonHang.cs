﻿using DevExpress.XtraEditors;
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
using QuanLyLuongSanPham_GUI.Properties;
using System.Drawing.Printing;
using System.Globalization;

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public partial class frmGDQLDonHang : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bsPH;
        BUS_DonHang donHangBUS;
        BUS_NhanVien nhanVienBUS;
        checkFrmDonHang checkDH = new checkFrmDonHang();
        DTO_DonHang newDonHang;
        IEnumerable<dynamic> lstTimKiemToDataGrid = null;
        List<DTO_ChiTietDonHang> lstChiTietThuocDonHang = null;
        public frmGDQLDonHang()
        {
            InitializeComponent();
            donHangBUS = new BUS_DonHang();
            bsPH = new BindingSource();
            nhanVienBUS = new BUS_NhanVien();
            addLuoiDonHang(dgvDSDonHang);
        }

        public frmGDQLDonHang(IEnumerable<dynamic> lstTimKiem)
        {
            InitializeComponent();
            donHangBUS = new BUS_DonHang();
            bsPH = new BindingSource();
            nhanVienBUS = new BUS_NhanVien();
            addLuoiDonHang(dgvDSDonHang);
            lstTimKiemToDataGrid = lstTimKiem;
        }


        private void frmGDQLDonHang_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // ẩn nút
            btnLuuDonHang.Enabled = false;
            btnHuyDonHang.Enabled = false;
            btnXuatDonHang.Enabled = false;
            this.dgvDSDonHang.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvDSDonHang.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11F, FontStyle.Bold);
            this.dgvDSDonHang.DefaultCellStyle.Font = new Font("Tahoma", 11.25F, FontStyle.Bold);
            if (lstTimKiemToDataGrid != null)
            {
                loadDonHangToDataGridView(lstTimKiemToDataGrid);
            }
            else
            {
                loadDonHangToDataGridView();
            }
            loadComBoBox();

            // xủ lý autocomplet
            txtTenKhachHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //===
            txtSoDienKhachHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSoDienKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void loadDonHangToDataGridView()
        {
            // load data
            bsPH.DataSource = donHangBUS.getAllDonHang();
            dgvDSDonHang.DataSource = bsPH;
            bindingNavigatorDonHang.BindingSource = bsPH;
        }

        private void loadDonHangToDataGridView(IEnumerable<dynamic> lst)
        {
            // load data
            bsPH.DataSource = lst;
            dgvDSDonHang.DataSource = bsPH;
            bindingNavigatorDonHang.BindingSource = bsPH;
        }

        private void addLuoiDonHang(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maDonHang";
            dc.HeaderText = "Mã đơn hàng";
            dc.Name = "maDonHang";
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
            dc.HeaderText = "Ngày kết thúc";
            dc.Name = "ngayKetThuc";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenKhachHang";
            dc.HeaderText = "Tên Khách Hàng";
            dc.Name = "tenKhachHang";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soDienThoaiKhachHang";
            dc.HeaderText = "Số điện thoại khách hàng";
            dc.Name = "soDienThoaiKhachHang";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "noiDung";
            dc.HeaderText = "Nội dung";
            dc.Name = "noiDung";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maNhanVien";
            dc.HeaderText = "Mã nhân viên";
            dc.Name = "maNhanVien";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenNhanVien";
            dc.HeaderText = "Tên nhân viên";
            dc.Name = "tenNhanVien";
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

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tinhTrangDonHang";
            dc.HeaderText = "Tình trạng đơn hàng";
            dc.Name = "tinhTrangDonHang";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);
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
            donHang.TrangThai = false;
            donHang.TinhTrangDonHang = true; // đơn đặt hàng
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

            List<string> tinhTrang = new List<string>();
            tinhTrang.Add("Đơn đặt hàng");
            tinhTrang.Add("Đơn hàng");
            cboTinhTrangDonHang.DataSource = tinhTrang;
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
                                        else
                                        {
                                            errLoi.Clear();
                                            if(cboTrangThai.Text.Equals(""))
                                            {
                                                errLoi.SetError(cboTrangThai, "Bạn phải chọn trạng thái đơn hàng!!");
                                                cboTrangThai.Focus();
                                                return false;
                                            }
                                            else
                                            {
                                                errLoi.Clear();
                                                if(cboTinhTrangDonHang.Text.Equals(""))
                                                {
                                                    errLoi.SetError(cboTinhTrangDonHang, "Bạn phải chọn tình trạng đơn hàng!!");
                                                    cboTinhTrangDonHang.Focus();
                                                    return false;
                                                }    
                                            }    
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
                cboTrangThai.SelectedIndex = 1;
                cboTinhTrangDonHang.SelectedIndex = 0;
                cboTinhTrangDonHang.Enabled = false;
                cboTrangThai.Enabled = false;
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
            btnXuatDonHang.Enabled = true;
            btnChiTietDonHang.Enabled = true;
            hienThongTin();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSDonHang.Rows[e.RowIndex];
                txtMaDonHang.Text = row.Cells[0].Value.ToString();
                dateNgayBatDau.Text = row.Cells[1].Value.ToString();
                dateNgayKetThuc.Text = row.Cells[2].Value.ToString();
                txtTenKhachHang.Text = row.Cells[3].Value.ToString();
                txtSoDienKhachHang.Text = row.Cells[4].Value.ToString();
                txtNoiDung.Text = row.Cells[5].Value.ToString();
                cboMaNhanVien.Text = row.Cells[6].Value.ToString();
                cboTenNhanVien.Text = row.Cells[7].Value.ToString();
                if (row.Cells[8].Value.ToString() == "True")
                    cboTrangThai.SelectedIndex = 0;
                else
                    cboTrangThai.SelectedIndex = 1;
                if (row.Cells[9].Value.ToString() == "True")
                    cboTinhTrangDonHang.SelectedIndex = 0;
                else
                {
                    cboTinhTrangDonHang.SelectedIndex = 1;
                    btnSuaDonHang.Enabled = false;
                    btnLuuDonHang.Enabled = false;
                    btnHuyDonHang.Enabled = false;
                }    
            }

        }

        private void btnLoadDSDonHang_Click(object sender, EventArgs e)
        {
            loadDonHangToDataGridView();
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

        private bool kiemTraNgayThang()
        {
            DateTime ngayBD = DateTime.Parse(dateNgayBatDau.Text);
            DateTime ngayKT = DateTime.Parse(dateNgayKetThuc.Text);
            errLoi.Clear();
            if(ngayBD < DateTime.Today )
            {
                errLoi.SetError(dateNgayBatDau, "Ngày bắt đầu không hợp lệ");
                return false;
            }
            else
            {
                errLoi.Clear();
                if(ngayKT < ngayBD.AddMonths(1) ||  ngayBD > ngayKT)
                {
                    errLoi.SetError(dateNgayKetThuc, "Ngày kết thúc không hợp lệ");
                    return false;
                }    
            }
            return true;
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
                        if(!kiemTraNgayThang())
                        {

                        }
                        else
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
                                btnSuaDonHang.Enabled = true;
                                loadDonHangToDataGridView();
                                MessageBox.Show("Thêm đơn hàng thành công!!");
                            }

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

        private void btnXuatDonHang_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;//                                chieu rong,chieucao
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Hợp đồng sản xuất",900, 1700);
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // them logo cho don hang
            Image img = Resources.logo;

            // ve logo vaof toa do 0 0 den het chiu dai chiu ong anh
            e.Graphics.DrawImage(img, 0, 0, img.Width,img.Height);
            // them ngay thang
            e.Graphics.DrawString("Ngày: " + DateTime.Now, new Font("Tahoma", 12, FontStyle.Bold),Brushes.Red,new Point(25,200));
            e.Graphics.DrawString("HỢP ĐỒNG SẢN XUẤT SẢN PHẨM", new Font("Tahoma", 40, FontStyle.Bold),Brushes.Red, new Point(500,50));
            // in phan thong itn don hang
            e.Graphics.DrawString("Mã đơn hàng: " + txtMaDonHang.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Mã nhân viên: " + cboMaNhanVien.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 230));
            e.Graphics.DrawString("Ngày bắt đầu: " + dateNgayBatDau.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("Tên nhân viên: " + dateNgayKetThuc.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 260));
            e.Graphics.DrawString("Ngày kết thúc: " + dateNgayKetThuc.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 290));
            e.Graphics.DrawString("Nội dung: " + txtNoiDung.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 290));
            e.Graphics.DrawString("Tên khách hàng: " + txtTenKhachHang.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 320));
            e.Graphics.DrawString("Số điện thoại khách hàng: " + txtSoDienKhachHang.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 320));
            Pen pen1 = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(pen1, 25, 350, 1600, 350);
            try
            {
                lstChiTietThuocDonHang = donHangBUS.getCTDH(txtMaDonHang.Text);
                if(lstChiTietThuocDonHang != null)
                {
                    e.Graphics.DrawString("SẢN PHẨM", new Font("Tahoma", 24, FontStyle.Bold), Brushes.Black, new Point(700, 380));
                    Pen pen = new Pen(Color.Black, 1);
                    e.Graphics.DrawLine(pen, 25,430, 1600, 430);
                    //header của dơn hàng
                    e.Graphics.DrawString("|STT", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(30, 460));
                    e.Graphics.DrawString("|Mã sản phảm", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(70, 460));
                    e.Graphics.DrawString("|Tên sản phẩm", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(270, 460));
                    e.Graphics.DrawString("|Số lượng", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(670, 460));
                    e.Graphics.DrawString("|Đơn giá sản phẩm", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(870, 460));
                    e.Graphics.DrawString("|Thành tiền      |", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(1070, 460));
                    e.Graphics.DrawLine(pen, 25, 490, 1600, 490);

                    int STT = 1;
                    int xCu = 470;
                    int khoangCach = 30;
                    decimal tongTien = 0;
                    foreach(var item in lstChiTietThuocDonHang)
                    {
                        xCu += khoangCach;
                        decimal thanhTien = item.SoLuong * item.DonGia;
                        DTO_SanPham sp = donHangBUS.getMotSanPham(item.MaSanPham);
                        e.Graphics.DrawString("|" + STT, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(30, xCu));
                        e.Graphics.DrawString("|" + item.MaSanPham, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(70, xCu));
                        e.Graphics.DrawString("|" + sp.TenSanPham, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(270, xCu));
                        e.Graphics.DrawString("|" + item.SoLuong, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(670, xCu));
                        e.Graphics.DrawString("|" + item.DonGia, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(870, xCu));
                        e.Graphics.DrawString("|" + thanhTien.ToString() + "    |", new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(1070, xCu));
                        
                        STT++;
                        tongTien += thanhTien;
                    }
                    e.Graphics.DrawString("TỔNG TIỀN:  " + string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongTien) + "VNĐ", new Font("Tahoma", 18, FontStyle.Bold), Brushes.Black, new Point(1200, xCu + 100));
                    e.Graphics.DrawString("Chữ ký nhân viên", new Font("Tahoma", 18, FontStyle.Bold), Brushes.Black, new Point(100, xCu + 200));
                    e.Graphics.DrawString("Chữ ký khách hàng", new Font("Tahoma", 18, FontStyle.Bold), Brushes.Black, new Point(1120, xCu + 200));
                }
                else
                {
                    MessageBox.Show("Vui lòng thêm chi tiết đơn hàng!!!");
                }  
            }
            catch
            {

            }


        }
        private void XuLyHoTroAutocomletTenKH()
        {
            List<DTO_DonHang> lstDonHang = donHangBUS.getDSDonHang();
            txtTenKhachHang.AutoCompleteCustomSource.Clear();
            foreach (DTO_DonHang item in lstDonHang)
            {
                txtTenKhachHang.AutoCompleteCustomSource.Add(item.TenKhachHang);
            }
        }
        private void XuLyHoTroAutocomletoDienThoaiKH()
        {
            List<DTO_DonHang> lstDonHang = donHangBUS.getDSDonHang();
            txtSoDienKhachHang.AutoCompleteCustomSource.Clear();
            foreach (DTO_DonHang item in lstDonHang)
            {
                txtSoDienKhachHang.AutoCompleteCustomSource.Add(item.SoDienThoaiKhachHang);
            }
        }


        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            XuLyHoTroAutocomletTenKH();
        }

        private void txtSoDienKhachHang_TextChanged(object sender, EventArgs e)
        {
            XuLyHoTroAutocomletoDienThoaiKH();
        }
        private bool kiemTraRong()
        {
            if (txtMaDonHang.Text.Equals("") || dateNgayBatDau.Text.Equals("") || dateNgayKetThuc.Text.Equals("") || txtTenKhachHang.Text.Equals("") || cboTrangThai.Text.Equals("") || cboMaNhanVien.Text.Equals("") || cboTenNhanVien.Text.Equals("") || txtNoiDung.Text.Equals("") || txtSoDienKhachHang.Text.Equals("") || cboTinhTrangDonHang.Text.Equals(""))
                return true;
            else
                return false;
        }

        private string taoMaSanPhamSanXuat()
        {
            string Digits = "1234567890";
            string allCharacters = Digits;
            //Random will give random charactors for given length  
            Random r = new Random();
            String maSanPhamSanXuat = "SPSX";
            for (int i = 0; i < 3; i++)
            {
                double rand = r.NextDouble();
                if (i == 0)
                {
                    maSanPhamSanXuat += Digits.ToCharArray()[(int)Math.Floor(rand * Digits.Length)];
                }
                else
                {
                    maSanPhamSanXuat += allCharacters.ToCharArray()[(int)Math.Floor(rand * allCharacters.Length)];
                }
            }
            return maSanPhamSanXuat;
        }

      
        private List<DTO_SanPhamSanXuat> taoSanPhamSanXuat(string maDonHang)
        {
            List<DTO_ChiTietDonHang> lstChiTietDonHang = donHangBUS.getCTDH(maDonHang);
            List<DTO_SanPhamSanXuat> lstSPSX = new List<DTO_SanPhamSanXuat>();
            if(lstChiTietDonHang != null)
            {
                foreach (DTO_ChiTietDonHang item in lstChiTietDonHang)
                {
                    DTO_SanPhamSanXuat sanPham = new DTO_SanPhamSanXuat();
                    DTO_SanPham sp = donHangBUS.getMotSanPham(item.MaSanPham);
                    sanPham.MaSanPhamSanXuat = taoMaSanPhamSanXuat();
                    sanPham.MaDonHang = maDonHang;
                    sanPham.TenSanPham = sp.TenSanPham;
                    sanPham.SoLuongSanXuat = item.SoLuong;
                    sanPham.TrangThai = false;
                    lstSPSX.Add(sanPham);
                }
                return lstSPSX;
            }
            return null;
        }

        private void btnHoanThanhDatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (!kiemTraRong())
                {
                    newDonHang = taoDonHang();
                    newDonHang.TinhTrangDonHang = false;
                    DialogResult hoiThem;
                    hoiThem = MessageBox.Show("Bạn có muốn hoàn thành đặt đơn hàng?", "Hoàn thành đơn đặt hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (hoiThem == DialogResult.Yes)
                    {
                        List<DTO_SanPhamSanXuat> lstSPSX = taoSanPhamSanXuat(newDonHang.MaDonHang);
                        if(lstSPSX == null)
                        {
                            MessageBox.Show("Cần thêm sản phẩm vào đơn hàng!!");
                        }
                        else
                        {
                            donHangBUS.suaDonHang(newDonHang);
                            foreach(DTO_SanPhamSanXuat item in lstSPSX)
                            {
                                donHangBUS.themSanPhamSanXuat(item);
                            }
                            newDonHang = null;
                            formatTextBox();
                            khoaThongTin();
                            MessageBox.Show("Đặt hàng thành công!!");
                            loadDonHangToDataGridView();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Đặt hàng không thành công!!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!!");
                }

            }
            catch
            {

            }

        }

        private void btn_Click(object sender, EventArgs e)
        {
            frmCongDoan frm = new frmCongDoan();
            _ = frm.ShowDialog();
        }

        private void dgvDSDonHang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}