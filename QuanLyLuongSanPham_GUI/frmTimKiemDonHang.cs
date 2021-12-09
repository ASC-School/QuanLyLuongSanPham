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
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_BUS;

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public partial class frmTimKiemDonHang : DevExpress.XtraEditors.XtraForm
    {
        BUS_DonHang donHangBUS;
        BUS_NhanVien nhanVienBUS;
        BUS_SanPham sanPhamBUS;
        BindingSource bsDonHang;
        IEnumerable<dynamic> lstTimKiem = null;
        public frmTimKiemDonHang()
        {
            InitializeComponent();
            donHangBUS = new BUS_DonHang();
            nhanVienBUS = new BUS_NhanVien();
            sanPhamBUS = new BUS_SanPham();
            bsDonHang = new BindingSource();
            addLuoiDonHang(dgvDSDomHang);
        }

        private void frmTimKiemDonHang_Load(object sender, EventArgs e)
        {
            // chan resize form
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            loadCbo();
            loadDSDonHangToDataGridView();
            this.dgvDSDomHang.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvDSDomHang.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            txtTenKhachHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtTenKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //===
            txtSoDienThoaiKhachHang.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtSoDienThoaiKhachHang.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void loadDSDonHangToDataGridView()
        {
            bsDonHang.DataSource = donHangBUS.getAllDonHang();
            dgvDSDomHang.DataSource = bsDonHang;
            bindingNavigatorDonHang.BindingSource = bsDonHang;
        }
        private void loadDSDonHangToDataGridView(IEnumerable<dynamic> lst)
        {
            bsDonHang.DataSource = lst;
            dgvDSDomHang.DataSource = bsDonHang;
            bindingNavigatorDonHang.BindingSource = bsDonHang;
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
                 
        }
        private void loadCbo()
        {
            // cbo Ma Nhan Vien + cbo tenNhanVien
            List<DTO_NhanVien> lstNhanVien = nhanVienBUS.getDSNhanVienForDonHang();
            List<string> maNhanVien = new List<string>();
            List<string> tenNhanVien = new List<string>();
            maNhanVien.Add("None");
            tenNhanVien.Add("None");
            foreach(DTO_NhanVien nv in lstNhanVien)
            {
                maNhanVien.Add(nv.MaNhanVien);
                tenNhanVien.Add(nv.TenNhanVien);
            }
            cboMaNhanVien.DataSource = maNhanVien;
            cboTenNhanVien.DataSource = tenNhanVien;

            //load cbo maDonHang + cbo ngayBatdau + cboKetThuc
            List<DTO_DonHang> lstDonHang = donHangBUS.getDSDonHang();
            List<string> maDonHang = new List<string>();
            List<string> ngayBatDau = new List<string>();
            List<string> ngayKeThuc = new List<string>();
            maDonHang.Add("None");
            ngayBatDau.Add("None");
            ngayKeThuc.Add("None");
            foreach (DTO_DonHang item in lstDonHang)
            {
                maDonHang.Add(item.MaDonHang);
                ngayBatDau.Add(item.NgayBatDau.ToString("MM/dd/yyyy"));
                ngayKeThuc.Add(item.NgayKetThuc.ToString("MM/dd/yyyy"));
            }
            cboMaDonHang.DataSource = maDonHang;
            cboNgayBatDau.DataSource = ngayBatDau;
            cboNgayKetThuc.DataSource = ngayKeThuc;

            //load cboSanPham 
            List<DTO_SanPham> lstSanPham = sanPhamBUS.getAllSanPham();
            List<string> tenSanPham = new List<string>();
            tenSanPham.Add("None");
            foreach(DTO_SanPham item in lstSanPham)
            {
                tenSanPham.Add(item.TenSanPham);
            }
            cboSanPham.DataSource = tenSanPham;
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

        private void cboMaNhanVien_SelectedIndexChanged_1(object sender, EventArgs e)
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
            txtSoDienThoaiKhachHang.AutoCompleteCustomSource.Clear();
            foreach (DTO_DonHang item in lstDonHang)
            {
                txtSoDienThoaiKhachHang.AutoCompleteCustomSource.Add(item.SoDienThoaiKhachHang);
            }
        }
        private void btnTimKimDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                if(!cboMaNhanVien.Text.Equals("None") || !cboTenNhanVien.Text.Equals("None")) // tim kiem don hang theo nhanVien
                {
                    if (!txtTenKhachHang.Text.Equals("") || !txtSoDienThoaiKhachHang.Text.Equals("")) // tim kiem nhanVien + khachhang
                    {
                        
                        if (!txtTenKhachHang.Text.Equals("") && txtSoDienThoaiKhachHang.Text.Equals("")) // tim kiem theo nhanVien + tenKhachHang
                        {
                            
                            if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + thoiGian
                            {
                                
                                // tim kiem theo nhanvien + tenKhachHang + ngayBatDau
                                if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                                {
                                    
                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + ngayBatDau + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + ngayBatDau + tenSanPham
                                        {
                                            //lblLoi.Text = "Tim theo nhanvien + ten khach hang + ngayBatDau + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau_SanPham(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + ngayBatDau + maDonHang
                                        {
                                           // lblLoi.Text = "Tim theo nhanvien + tenKhachHang + ngayBatDau + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + tenKhachHang + ngayBatDau + tenSanPham + madonHang
                                        {
                                          // lblLoi.Text = "Tim theo nhanvien + tenKhachHang + ngayBatDau + tenSanPham + madonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau_SanPham_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text,cboSanPham.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + tenKhachHang + ngayBatDau 
                                    {
                                        //lblLoi.Text = "Tim theo nhanvien + ten khach hang + ngayBatDau";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }


                                }
                                else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + ngayKetThuc
                                {

                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + ngayKetThuc + tenSanPham
                                        {
                                          //  lblLoi.Text = "Tim theo nhanvien + ten khach hang + ngayKetThuc + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayKetThuc_SanPham(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayKetThuc.Text,cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }

                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + ngayKetThuc + maDonHang
                                        {
                                          //  lblLoi.Text = "Tim theo nhanvien + tenKhachHang + ngayKetThuc + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayKetThuc_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + tenKhachHang + ngayKetThuc + tenSanPham + madonHang
                                        {
                                           // lblLoi.Text = "Tim theo nhanvien + tenKhachHang + ngayKetThuc + tenSanPham + madonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayKetThuc_SanPham_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayKetThuc.Text,cboSanPham.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + tenKhachHang + ngayKetThuc 
                                    {
                                       // lblLoi.Text = "Tim theo nhanvien + ten khach hang + ngayKetThuc";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayKetThuc(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayKetThuc.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }

                                }
                                else // tim kiem theo nhanvien + tenKhachHang + ngayBatDau + ngayKetThuc
                                {
                                    
                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + ngayBatDau + ngayKetThuc + tenSanPham
                                        {
                                           // lblLoi.Text = "Tim theo nhanvien + ten khach hang + ngayBatDau + ngayKetThuc + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text,cboNgayKetThuc.Text,cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + ngayBatDau + ngayKetThuc + maDonHang
                                        {
                                           // lblLoi.Text = "Tim theo nhanvien + tenKhachHang + ngayBatDau + ngayKetThuc + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + tenKhachHang+ ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                        {//lblLoi.Text = "Tim theo nhanvien + tenKhachHang + ngayBatDau + ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text,cboSanPham.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + tenKhachHang + ngayBatDau + ngayKetThuc 
                                    {
                                       // lblLoi.Text = "Tim theo nhanvien + ten khach hang + ngayBatDau + ngayKetThuc";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc(cboMaNhanVien.Text, txtTenKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }

                                }
                            }
                            else if (!cboSanPham.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + sanPham
                            {
                               // lblLoi.Text = "Tim theo nhanvien + ten khach hang + sanPham";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_SanPham(cboMaNhanVien.Text, txtTenKhachHang.Text,cboSanPham.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else if (!cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang + maDonhang
                            {
                               // lblLoi.Text = "Tim theo nhanvien + ten khach hang + maDonHang";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, cboSanPham.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else // tim kiem theo nhanVien + tenKhachHang
                            {
                               // lblLoi.Text = "Tim theo nhanvien + ten khach hang";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_TenKH(cboMaNhanVien.Text, txtTenKhachHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                        }
                        else if (!txtSoDienThoaiKhachHang.Text.Equals("") && txtTenKhachHang.Text.Equals("")) // tim kiem theo nhanVien + so dienThoaiKhachHang
                        {
                           // lblLoi.Text = "Tim theo nhanvien + so dien thoai khach hang";
                            if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + thoiGian
                            {
                              //  lblLoi.Text = "Tim theo nhanvien + ten khach hang + thoiGian";
                                // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau
                                if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                                {

                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + tenSanPham
                                        {
                                        //    lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + maDonHang
                                        {
                                            //lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_soDienThoaiKH_NgayBatDau_MaDonHang(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                        {
                                           // lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau 
                                    {
                                       // lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }


                                }
                                else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo nhanvien + soDienThoaiKhachHang + ngayKetThuc
                                {

                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + soDienThoaiKhachHang + ngayKetThuc + tenSanPham
                                        {
//lblLoi.Text = "Tim theo nhanvien + so dien thoai khach hang + ngayKetThuc + tenSanPham";
                                            IEnumerable<dynamic> lst = donHangBUS.getDHTheoNhanVien_SODienThoaiKH_NgayKetThuc_SanPham(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text,cboSanPham.Text);
                                            if (lst == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lst);
                                            }
                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + soDienThoaiKhachHang + ngayKetThuc + maDonHang
                                        {
                                            //lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayKetThuc + maDonHang";
                                            IEnumerable<dynamic> lst = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayKetThuc_MaDonHang(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                            if (lst == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lst);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                        {
                                            //lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang";
                                            IEnumerable<dynamic> lst = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text,cboSanPham.Text, cboMaDonHang.Text);
                                            if (lst == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lst);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayKetThuc 
                                    {
                                       // lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayKetThuc";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_SODienThoaiKH_NgayKetThuc(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }

                                }
                                else // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc
                                {

                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham
                                        {
                                          //  lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang
                                        {
                                           // lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_MaDonHang(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + soDienThoaiKhachHang+ ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                        {
                                           // lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text,cboSanPham.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc 
                                    {
                                       // lblLoi.Text = "Tim theo nhanvien + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }

                                }
                            }
                            else if (!cboSanPham.Text.Equals("None")) // tim kiem theo nhanvien + soDienThoaiKhachHang + sanPham
                            {
                                //lblLoi.Text = "Tim theo nhanvien + so dien thoai khach hang + sanPham";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_SanPham(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboSanPham.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else if (!cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + so dien thoai khach hang + maDonhang
                            {
                                lblLoi.Text = "Tim theo nhanvien + so dien thoai khach hang + maDonHang";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH_MaDonHang(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text, cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else // tim kiem theo nhanVien + so dien thoai khach hang
                            {
                                lblLoi.Text = "Tim theo nhanvien + so dien thoai khach hang";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_SoDienThoaiKH(cboMaNhanVien.Text, txtSoDienThoaiKhachHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                        }
                        else  // tim kiem theo nhanvien + tenkhachhang + sodienThoaiKhachHang
                        {
                            //lblLoi.Text = "Tim theo nhanvien +  ten khach hang + so dien thoai khach hang";
                            if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + thoiGian
                            {
                                // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau
                                if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                                {

                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayBatDau_SanPham(cboMaNhanVien.Text,txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text,cboNgayBatDau.Text,cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }

                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + maDonHang
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KH_NgayBatDau_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }

                                        }
                                        else // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayBatDau_SanPham_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text,cboSanPham.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau 
                                    {
                                        lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayBatDau_SanPham_MaDonHang(cboMaNhanVien.Text,txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc
                                {

                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + ten khach hang + ngayKetThuc + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayKetThuc_SanPham(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + maDonHang
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayKetThuc_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang";
                                        }
                                    }
                                    else // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc 
                                    {
                                        lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayKetThuc(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }

                                }
                                else // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc
                                {

                                    if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_SanPham(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text,cboNgayBatDau.Text, cboNgayKetThuc.Text,cboSanPham.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                        else // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang+ ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                        {
                                            lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + soDienThoaiKhachHang  ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                            lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_ThoiGian_SanPham_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text,cboSanPham.Text, cboMaDonHang.Text);
                                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                            else
                                            {
                                                loadDSDonHangToDataGridView(lstTimKiem);
                                            }
                                        }
                                    }
                                    else // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc 
                                    {
                                        lblLoi.Text = "Tim theo nhanvien+ tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc";
                                        lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_ThoiGian(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }

                                    }

                                }
                            }
                            else if (!cboSanPham.Text.Equals("None")) // tim kiem theo nhanvien + tenKhachHang  + soDienThoaiKhachHang + sanPham
                            {
                                lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + so dien thoai khach hang + sanPham";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_SanPham(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboSanPham.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else if (!cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + so dien thoai khach hang + maDonhang
                            {
                                lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + so dien thoai khach hang + maDonHang";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang_MaDonHang(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else // tim kiem theo nhanVien + tenKhachHang + so dien thoai khach hang
                            {
                                lblLoi.Text = "Tim theo nhanvien + tenKhachHang  + so dien thoai khach hang";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_KhachHang(cboMaNhanVien.Text, txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                        }
                    }
                    else if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo nhan vien + thoi gian
                    {
                        //lblLoi.Text = "Tim theo nhanvien + thoigian";
                        // tim kiem theo nhanvien + ngayBatDau
                        if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                        {

                            if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + ngayBatDau + tenSanPham + madonHang
                            {
                                if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + ngayBatDau + tenSanPham
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayBatDau + tenSanPham";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_NgayBatDau_SanPham(cboMaNhanVien.Text, cboNgayBatDau.Text, cboSanPham.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                                else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + ngayBatDau + maDonHang
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayBatDau + maDonHang";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_NgayBatDau_MaDonHang(cboMaNhanVien.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                                else // tim kiem theo nhanvien + ngayBatDau + tenSanPham + madonHang
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayBatDau + tenSanPham + madonHang";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_NgayBatDau_SanPham_MaDonHang(cboMaNhanVien.Text, cboNgayBatDau.Text,cboSanPham.Text, cboMaDonHang.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                            }
                            else // tim kiem theo nhanvien + ngayBatDau 
                            {
                                lblLoi.Text = "Tim theo nhanvien + ngayBatDau";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_NgayBatDau(cboMaNhanVien.Text, cboNgayBatDau.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }


                        }
                        else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo nhanvien + ngayKetThuc
                        {

                            if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien  + ngayKetThuc + tenSanPham + madonHang
                            {
                                if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + ngayKetThuc + tenSanPham
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayKetThuc + tenSanPham";
                                    IEnumerable<dynamic> lst = donHangBUS.getDHTheoNhanVien_NgayKetThuc_SanPham(cboMaNhanVien.Text, cboNgayKetThuc.Text,cboSanPham.Text);
                                    if (lst == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lst);
                                    }
                                }
                                else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + ngayKetThuc + maDonHang
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayKetThuc + maDonHang";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_NgayKetThuc_MaDonHang(cboMaNhanVien.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                                else // tim kiem theo nhanvien+ ngayKetThuc + tenSanPham + madonHang
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayKetThuc + tenSanPham + madonHang";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_NgayKetThuc_SanPham_MaDonHang(cboMaNhanVien.Text, cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                            }
                            else // tim kiem theo nhanvien + ngayKetThuc 
                            {
                                lblLoi.Text = "Tim theo nhanvien + ngayKetThuc";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_NgayKetThuc(cboMaNhanVien.Text, cboNgayKetThuc.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }

                        }
                        else // tim kiem theo nhanvien + ngayBatDau + ngayKetThuc
                        {

                            if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo nhanvien + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                            {
                                if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + ngayBatDau + ngayKetThuc + tenSanPham
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayBatDau + ngayKetThuc + tenSanPham";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_ThoiGian_SanPham(cboMaNhanVien.Text,cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                                else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + ngayBatDau + ngayKetThuc + maDonHang
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayBatDau + ngayKetThuc + maDonHang";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_ThoiGian_MaDonHang(cboMaNhanVien.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                                else // tim kiem theo nhanvien + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                {
                                    lblLoi.Text = "Tim theo nhanvien + ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                    lstTimKiem = donHangBUS.getDHTheoNhanVien_ThoiGian_MaDonHang(cboMaNhanVien.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }
                            }
                            else // tim kiem theo nhanvien + ngayBatDau + ngayKetThuc 
                            {
                                lblLoi.Text = "Tim theo nhanvien + ngayBatDau + ngayKetThuc";
                                lstTimKiem = donHangBUS.getDHTheoNhanVien_ThoiGian(cboMaNhanVien.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }

                        }
                    }
                    else if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhan vien + sanPham + donhang
                    {
                        //lblLoi.Text = "Tim theo nhanvien + sanPham";
                        if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenSanPham
                        {
                            lblLoi.Text = "Tim theo nhanvien + tenSanPham";
                            IEnumerable<dynamic> lst = donHangBUS.getDHTheoNhanVien_SanPham(cboMaNhanVien.Text,cboSanPham.Text);
                            if (lst == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lst);
                            }
                        }
                        else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + maDonHang
                        {
                            lblLoi.Text = "Tim theo nhanvien + maDonHang";
                            lstTimKiem = donHangBUS.getDHTheoNhanVien_MaDonHang(cboMaNhanVien.Text, cboMaDonHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                        else // tim kiem theo nhanvien+ ngayKetThuc + tenSanPham + madonHang
                        {
                            lblLoi.Text = "Tim theo nhanvien + tenSanPham + madonHang";
                            lstTimKiem = donHangBUS.getDHTheoNhanVien_SanPham_DonHang(cboMaNhanVien.Text, cboMaDonHang.Text,cboMaDonHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }

                    }
                    else // tim theo nhan vien
                    {
                        lstTimKiem = donHangBUS.getDHTheoNhanVien(cboMaNhanVien.Text);
                        loadDSDonHangToDataGridView(lstTimKiem);
                    }
                }
                else
                if(!txtTenKhachHang.Text.Equals("") || !txtSoDienThoaiKhachHang.Text.Equals("")) // tim kim theo khach hang
                {
                    lblLoi.Text = "Tim theo khach hang";
                    if (!txtTenKhachHang.Text.Equals("") && txtSoDienThoaiKhachHang.Text.Equals("")) // tim kiem theo tenKhachHang
                    {

                        if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo tenKhachHang + thoiGian
                        {
                            
                            // tim kiem theo tenKhachHang + ngayBatDau
                            if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo tenKhachHang + ngayBatDau + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang + ngayBatDau + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo ten khach hang + ngayBatDau + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_NgayBatDau_SanPham(txtTenKhachHang.Text, cboNgayBatDau.Text,cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang + ngayBatDau + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang + ngayBatDau + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_NgayBatDau_MaDonHang(txtTenKhachHang.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo ngayBatDau + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang + ngayBatDau + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_NgayBatDau_SanPham_MaDonHang(txtTenKhachHang.Text, cboNgayBatDau.Text,cboSanPham.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo tenKhachHang + ngayBatDau 
                                {
                                    lblLoi.Text = "Tim theo ten khach hang + ngayBatDau";
                                    lstTimKiem = donHangBUS.getDHTheoTenKH_NgayBatDau(txtTenKhachHang.Text, cboNgayBatDau.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }


                            }
                            else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo tenKhachHang + ngayKetThuc
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo tenKhachHang + ngayKetThuc + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang + ngayKetThuc + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo ten khach hang + ngayKetThuc + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_NgayKetThuc_SanPham(txtTenKhachHang.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang + ngayKetThuc + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang + ngayKetThuc + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_NgayKetThuc_MaDonHang(txtTenKhachHang.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo tenKhachHang + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang + ngayKetThuc + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_NgayBatDau_SanPham_MaDonHang(txtTenKhachHang.Text, cboNgayKetThuc.Text, cboSanPham.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo tenKhachHang + ngayKetThuc 
                                {
                                    lblLoi.Text = "Tim theo ten khach hang + ngayKetThuc";
                                    lstTimKiem = donHangBUS.getDHTheoTenKH_NgayKetThuc(txtTenKhachHang.Text, cboNgayKetThuc.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }

                            }
                            else // tim kiem theo tenKhachHang + ngayBatDau + ngayKetThuc
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo tenKhachHang + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang + ngayBatDau + ngayKetThuc + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo ten khach hang + thoigian + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_ThoiGian_SanPham(txtTenKhachHang.Text,cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang + ngayBatDau + ngayKetThuc + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang + ngayBatDau + ngayKetThuc + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_ThoiGian_MaDonHang(txtTenKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo tenKhachHang+ ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang + ngayBatDau + ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoTenKH_ThoiGian_SanPham_MaDonHang(txtTenKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo tenKhachHang + ngayBatDau + ngayKetThuc 
                                {
                                    lblLoi.Text = "Tim theo ten khach hang + ngayBatDau + ngayKetThuc";
                                    lstTimKiem = donHangBUS.getDHTheoTenKH_ThoiGian(txtTenKhachHang.Text, cboNgayBatDau.Text,cboNgayBatDau.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }

                            }
                        }
                        else if (!cboSanPham.Text.Equals("None")) // tim kiem theo tenKhachHang + sanPham
                        {
                            lblLoi.Text = "Tim theo ten khach hang + sanPham";
                            lstTimKiem = donHangBUS.getDHTheoTenKH_SanPham(txtTenKhachHang.Text, cboSanPham.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                        else if (!cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang + maDonhang
                        {
                            lblLoi.Text = "Tim theo ten khach hang + maDonHang";
                            lstTimKiem = donHangBUS.getDHTheoTenKH_MaDonHang(txtTenKhachHang.Text, cboMaDonHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                        else // tim kiem theo tenKhachHang
                        {
                            lblLoi.Text = "Tim theo ten khach hang";
                            lstTimKiem = donHangBUS.getDHTheoTenKH(txtTenKhachHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                    }
                    else if (!txtSoDienThoaiKhachHang.Text.Equals("") && txtTenKhachHang.Text.Equals("")) // tim kiem theo  so dienThoaiKhachHang
                    {
                        lblLoi.Text = "Tim theo so dien thoai khach hang";
                        if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo sodienThoai + thoiGian
                        {
                            lblLoi.Text = "Tim theo sodienthoai khach hang + thoiGian";
                            // tim kiem theo soDienThoaiKhachHang + ngayBatDau
                            if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo  soDienThoaiKhachHang + ngayBatDau + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayBatDau + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayBatDau_SanPham(txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo  soDienThoaiKhachHang + ngayBatDau + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayBatDau + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayBatDau_MaDonHang(txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text,cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo  soDienThoaiKhachHang + ngayBatDau 
                                {
                                    lblLoi.Text = "Tim theo  soDienThoaiKhachHang + ngayBatDau";
                                    lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayBatDau(txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }


                            }
                            else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo  soDienThoaiKhachHang + ngayKetThuc
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo soDienThoaiKhachHang + ngayKetThuc + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo ten khach hang + ngayKetThuc + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayKetThuc_SanPham(txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem the soDienThoaiKhachHang + ngayKetThuc + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayKetThuc + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayKetThuc_MaDonHang(txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo  soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo soDienThoaiKhachHang + ngayKetThuc 
                                {
                                    lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayKetThuc";
                                    lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_NgayKetThuc(txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }

                            }
                            else // tim kiem theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_ThoiGian_SanPham(txtSoDienThoaiKhachHang.Text,cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_ThoiGian_MaDonHang(txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo  soDienThoaiKhachHang+ ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayBatDau + ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_ThoiGian_SanPham_MaDonHang(txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc 
                                {
                                    lblLoi.Text = "Tim theo soDienThoaiKhachHang + ngayBatDau + ngayKetThuc";
                                    lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_ThoiGian(txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }

                            }
                        }
                        else if (!cboSanPham.Text.Equals("None")) // tim kiem theo soDienThoaiKhachHang + sanPham
                        {
                            lblLoi.Text = "Tim theo so dien thoai khach hang + sanPham";
                            lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_SanPham(txtSoDienThoaiKhachHang.Text, cboSanPham.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                        else if (!cboMaDonHang.Text.Equals("None"))// tim kiem theo so dien thoai khach hang + maDonhang
                        {
                            lblLoi.Text = "Tim theo so dien thoai khach hang + maDonHang";
                            lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH_SanPham(txtSoDienThoaiKhachHang.Text, cboMaDonHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                        else // tim kiem theo so dien thoai khach hang
                        {
                            lblLoi.Text = "Tim theo so dien thoai khach hang";
                            lstTimKiem = donHangBUS.getDHTheoSoDienThoaiKH(txtSoDienThoaiKhachHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                    }
                    else  // tim kiem theo tenkhachhang + sodienThoaiKhachHang
                    {
                        //lblLoi.Text = "Tim theo ten khach hang + so dien thoai khach hang";
                        if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo tenKhachHang + thoiGian
                        {
                            // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau
                            if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayBatDau_SanPham(txtTenKhachHang.Text,txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayBatDau_MaDonHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayBatDau_SanPham_MaDonHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboSanPham.Text,cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau 
                                {
                                    lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau";
                                    lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayBatDau(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }


                            }
                            else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + ten khach hang + ngayKetThuc + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayKetThuc_SanPham(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayKetThuc_MaDonHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayKetThuc_SanPham_MaDonHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc 
                                {
                                    lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayKetThuc";
                                    lstTimKiem = donHangBUS.getDHTheoKhachHang_NgayKetThuc(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayKetThuc.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }

                            }
                            else // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc
                            {

                                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo tenKhachHang + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                {
                                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + tenSanPham";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_ThoiGian_SanPham(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text,cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc + maDonHang";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_ThoiGian_MaDonHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                    else // tim kiem theo tenKhachHang  + soDienThoaiKhachHang+ ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                                    {
                                        lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                        lstTimKiem = donHangBUS.getDHTheoKhachHang_ThoiGian_SanPham_MaDonHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                        else
                                        {
                                            loadDSDonHangToDataGridView(lstTimKiem);
                                        }
                                    }
                                }
                                else // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc 
                                {
                                    lblLoi.Text = "Tim theo tenKhachHang  + soDienThoaiKhachHang + ngayBatDau + ngayKetThuc";
                                    lstTimKiem = donHangBUS.getDHTheoKhachHang_ThoiGian(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboNgayBatDau.Text, cboNgayKetThuc.Text);
                                    if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                    else
                                    {
                                        loadDSDonHangToDataGridView(lstTimKiem);
                                    }
                                }

                            }
                        }
                        else if (!cboSanPham.Text.Equals("None")) // tim kiem theo tenKhachHang  + soDienThoaiKhachHang + sanPham
                        {
                            lblLoi.Text = "Tim theo tenKhachHang  + so dien thoai khach hang + sanPham";
                            lstTimKiem = donHangBUS.getDHTheoKhachHang_SanPham(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboSanPham.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                        else if (!cboMaDonHang.Text.Equals("None"))// tim kiem theo nhanvien + tenKhachHang  + so dien thoai khach hang + maDonhang
                        {
                            lblLoi.Text = "Tim theo tenKhachHang  + so dien thoai khach hang + maDonHang";
                            lstTimKiem = donHangBUS.getDHTheoKhachHang_MaDonHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text, cboMaDonHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                        else // tim kiem theo tenKhachHang + so dien thoai khach hang
                        {
                            lblLoi.Text = "Tim theo tenKhachHang  + so dien thoai khach hang";
                            lstTimKiem = donHangBUS.getDHKhachHang(txtTenKhachHang.Text, txtSoDienThoaiKhachHang.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }
                    }
                }
                else
                if (!cboNgayBatDau.Text.Equals("None") || !cboNgayKetThuc.Text.Equals("None")) // tim kiem theo thoi gian
                {
                    lblLoi.Text = "Tim theo thời gian";
                    // tim kiem theo ngayBatDau
                    if (!cboNgayBatDau.Text.Equals("None") && cboNgayKetThuc.Text.Equals("None"))
                    {

                        if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo  ngayBatDau + tenSanPham + madonHang
                        {
                            if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo ngayBatDau + tenSanPham
                            {
                                lblLoi.Text = "Tim theo ngayBatDau + tenSanPham";
                                lstTimKiem = donHangBUS.getDHTheoNgayBatDau_SanPham(cboNgayBatDau.Text, cboSanPham.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }

                            }
                            else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo ngayBatDau + maDonHang
                            {
                                lblLoi.Text = "Tim theo ngayBatDau + maDonHang";
                                lstTimKiem = donHangBUS.getDHTheoNgayBatDau_MaDonHang(cboNgayBatDau.Text, cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else // tim kiem theo ngayBatDau + tenSanPham + madonHang
                            {
                                lblLoi.Text = "Tim theo ngayBatDau + tenSanPham + madonHang";
                                lstTimKiem = donHangBUS.getDHTheoNgayBatDau_SanPham_MaDonHang(cboNgayBatDau.Text, cboSanPham.Text,cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                        }
                        else // tim kiem theo ngayBatDau 
                        {
                            lblLoi.Text = "Tim theo ngayBatDau";
                            lstTimKiem = donHangBUS.getDHTheoNgayBatDau(cboNgayBatDau.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }


                    }
                    else if (cboNgayBatDau.Text.Equals("None") && !cboNgayKetThuc.Text.Equals("None"))// tim kiem theo ngayKetThuc
                    {

                        if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo ngayKetThuc + tenSanPham + madonHang
                        {
                            if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem the ngayKetThuc + tenSanPham
                            {
                                lblLoi.Text = "Tim theo ngayKetThuc + tenSanPham";
                                lstTimKiem = donHangBUS.getDHTheoNgayKetThuc_SanPham(cboNgayKetThuc.Text, cboSanPham.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo ngayKetThuc + maDonHang
                            {
                                lblLoi.Text = "Tim theo ngayKetThuc + maDonHang";
                                lstTimKiem = donHangBUS.getDHTheoNgayKetThuc_MaDonHang(cboNgayKetThuc.Text, cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else // tim kiem theo ngayKetThuc + tenSanPham + madonHang
                            {
                                lblLoi.Text = "Tim theo ngayKetThuc + tenSanPham + madonHang";
                                lstTimKiem = donHangBUS.getDHTheoNgayKetThuc_SanPham_MaDonHang(cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                        }
                        else // tim kiem theo ngayKetThuc 
                        {
                            lblLoi.Text = "Tim theo ngayKetThuc";
                            lstTimKiem = donHangBUS.getDHTheoNgayKetThuc(cboNgayKetThuc.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }

                    }
                    else // tim kiem theo ngayBatDau + ngayKetThuc
                    {

                        if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo  ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                        {
                            if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo  ngayBatDau + ngayKetThuc + tenSanPham
                            {
                                lblLoi.Text = "Tim theo ngayBatDau + ngayKetThuc + tenSanPham";
                                lstTimKiem = donHangBUS.getDHTheoThoiGian_SanPham(cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo ngayBatDau + ngayKetThuc + maDonHang
                            {
                                lblLoi.Text = "Tim theo ngayBatDau + ngayKetThuc + maDonHang";
                                lstTimKiem = donHangBUS.getDHTheoThoiGian_MaDonHang(cboNgayBatDau.Text, cboNgayKetThuc.Text, cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                            else // tim kiem theo ngayBatDau + ngayKetThuc + tenSanPham + madonHang
                            {
                                lblLoi.Text = "Tim theo+ ngayBatDau + ngayBatDau + ngayKetThuc + tenSanPham + madonHang";
                                lstTimKiem = donHangBUS.getDHTheoThoiGian_SanPham_MaDonHang(cboNgayBatDau.Text, cboNgayKetThuc.Text, cboSanPham.Text,cboMaDonHang.Text);
                                if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                                else
                                {
                                    loadDSDonHangToDataGridView(lstTimKiem);
                                }
                            }
                        }
                        else // tim kiem theo ngayBatDau + ngayKetThuc 
                        {
                            lblLoi.Text = "Tim theo ngayBatDau + ngayKetThuc";
                            lstTimKiem = donHangBUS.getDHTheoThoiGian(cboNgayBatDau.Text, cboNgayKetThuc.Text);
                            if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                            else
                            {
                                loadDSDonHangToDataGridView(lstTimKiem);
                            }
                        }

                    }
                }
                else
                if (!cboSanPham.Text.Equals("None") || !cboMaDonHang.Text.Equals("None")) // tim kiem theo tenSanPham + madonHang
                {
                    lblLoi.Text = "Tim theo sản phẩm";
                    if (!cboSanPham.Text.Equals("None") && cboMaDonHang.Text.Equals("None"))// tim kiem theo tenSanPham
                    {
                        lblLoi.Text = "Tim theo tenSanPham";
                        lstTimKiem = donHangBUS.getDHTheoSanPham(cboSanPham.Text);
                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                        else
                        {
                            loadDSDonHangToDataGridView(lstTimKiem);
                        }
                    }
                    else if (cboSanPham.Text.Equals("None") && !cboMaDonHang.Text.Equals("None"))// tim kiem theo maDonHang
                    {
                        lblLoi.Text = "Tim theo maDonHang";
                        lstTimKiem = donHangBUS.getDHTheoMaDonHang(cboMaDonHang.Text);
                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                        else
                        {
                            loadDSDonHangToDataGridView(lstTimKiem);
                        }
                    }
                    else // tim kiem theo tenSanPham + madonHang
                    {
                        lblLoi.Text = "Tim theo tenSanPham + madonHang";
                        lstTimKiem = donHangBUS.getDHTheoSanPham_MaDonHang(cboSanPham.Text, cboMaDonHang.Text);
                        if (lstTimKiem == null) MessageBox.Show("Đơn không tồn tại!");
                        else
                        {
                            loadDSDonHangToDataGridView(lstTimKiem);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Khong tim thay");
                }

            }catch(Exception)
            {
                MessageBox.Show("Không tìm được");
            }
        }

        private void btnCapNhatDonHang_Click(object sender, EventArgs e)
        {
            frmGDQLDonHang frm = new frmGDQLDonHang(lstTimKiem);
            frm.ShowDialog();
            this.Close();
        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {
            XuLyHoTroAutocomletTenKH();
        }

        private void txtSoDienThoaiKhachHang_TextChanged(object sender, EventArgs e)
        {
            XuLyHoTroAutocomletoDienThoaiKH();
        }
    }
}