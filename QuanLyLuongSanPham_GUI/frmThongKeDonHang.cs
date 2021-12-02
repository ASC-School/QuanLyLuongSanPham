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
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_BUS;

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public partial class frmThongKeDonHang : DevExpress.XtraEditors.XtraForm
    {
        private string LocationExcel = null;
        BUS_DonHang donHangBUS;
        BUS_NhanVien nhanVienBUS;
        BindingSource bsDonHang;
        BUS_BaoCao baoCaoExcel;
        IEnumerable<dynamic> lstDonHang = null;
        public frmThongKeDonHang()
        {
            InitializeComponent();
            addLuoiDonHang(dgvDSDonHang);
            donHangBUS = new BUS_DonHang();
            nhanVienBUS = new BUS_NhanVien();
            bsDonHang = new BindingSource();
            baoCaoExcel = new BUS_BaoCao();
        }

        

        private void loadDSDonHangToDataGridView()
        {
            bsDonHang.DataSource = donHangBUS.getAllDonHangCoThanhTien();
            dgvDSDonHang.DataSource = bsDonHang;
            bindingNavigatorDonHang.BindingSource = bsDonHang;
            loadTongTienVaTonGSoLuongDonHang(dgvDSDonHang);

        }
        private void loadDSDonHangToDataGridView(IEnumerable<dynamic> lst)
        {
            bsDonHang.DataSource = lst;
            dgvDSDonHang.DataSource = bsDonHang;
            bindingNavigatorDonHang.BindingSource = bsDonHang;
            if(!cboDonGiaDonHang.Text.Equals("None"))
            {
                if (cboDonGiaDonHang.Text.Equals("Từ thấp đến cao"))
                {
                    dgvDSDonHang.Sort(dgvDSDonHang.Columns[8], ListSortDirection.Ascending);
                }
                else
                {
                    dgvDSDonHang.Sort(dgvDSDonHang.Columns[8], ListSortDirection.Descending);
                }
            }
            loadTongTienVaTonGSoLuongDonHang(dgvDSDonHang);
        }

        private void loadTongTienVaTonGSoLuongDonHang(DataGridView dgv)
        {
            if(dgv.DataSource == null)
            {
                lblTongSoDonHang.Text = "0";
                lblTongTatCaDonHang.Text = "0 VNĐ";
            }
            else
            {

            }    
            lblTongSoDonHang.Text = dgv.Rows.Count.ToString();
            decimal tongTien = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                int j = 0;
                tongTien += (decimal)dgv[8, i].Value;
            }
            lblTongTatCaDonHang.Text = string.Format("{0:N0}", tongTien) + " VNĐ";
        }
        private void frmThongKeDonHang_Load(object sender, EventArgs e)
        {
            // chan resize
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            // fomart dgv
            this.dgvDSDonHang.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvDSDonHang.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            loadComBoBox();
            anThongTIn();
            loadDSDonHangToDataGridView();
        }

        private bool checkExist(string tenKH,List<string> lst)
        {
            if(lst.Count < 0) return false;
            foreach(string item in lst)
            {
                if (item.Equals(tenKH))
                    return true;
            }
            return false;
        }

        private void loadComBoBox()
        {
            //dateNgayBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //dateNgayCuoi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dateNgayThongKe.Text = DateTime.Now.ToString("dd/MM/yyyy");
            // load combo box danh mục thống kê
            List<string> lstDanhMucThongKe = new List<string>();
            lstDanhMucThongKe.Add("None");
            lstDanhMucThongKe.Add("Nhân viên");
            lstDanhMucThongKe.Add("Khách hàng");
            lstDanhMucThongKe.Add("Đơn giá");
            lstDanhMucThongKe.Add("Sản phẩm");
            cboDanhMucThongKe.DataSource = lstDanhMucThongKe;

            //=== load combo box nhanvien
            List<DTO_NhanVien> lstNhanVien = nhanVienBUS.getDSNhanVienForDonHang();
            List<string> maNhanVien = new List<string>();
            List<string> tenNhanVien = new List<string>();
            maNhanVien.Add("None");
            tenNhanVien.Add("None");
            foreach (DTO_NhanVien nhanVien in lstNhanVien)
            {
                maNhanVien.Add(nhanVien.MaNhanVien);
                tenNhanVien.Add(nhanVien.TenNhanVien);
            }
            cboMaNhanVien.DataSource = maNhanVien;
            cboTenNhanVien.DataSource = tenNhanVien;

            //======= load combox khachhang
            List<DTO_DonHang> lstDonHang = donHangBUS.getDSDonHang();
            List<string> tenKhachHang = new List<string>();
            List<string> soDienThoaiKhachHang = new List<string>();
            tenKhachHang.Add("None");
            soDienThoaiKhachHang.Add("None");
            foreach(DTO_DonHang item in lstDonHang)
            {
                if (!checkExist(item.TenKhachHang, tenKhachHang)) tenKhachHang.Add(item.TenKhachHang);
                if (!checkExist(item.SoDienThoaiKhachHang, soDienThoaiKhachHang)) soDienThoaiKhachHang.Add(item.SoDienThoaiKhachHang);
            }
            cboTenKhachHang.DataSource = tenKhachHang;
            cboSoDienThoaiKhachHang.DataSource = soDienThoaiKhachHang;

            //=== load cboSAnPham
            List<DTO_SanPham> lstSanPham = donHangBUS.getDSSanPham();
            List<string> tenSanPham = new List<string>();
            tenSanPham.Add("None");
            foreach (DTO_SanPham item in lstSanPham)
            {
                tenSanPham.Add(item.TenSanPham);
            }
            cboSanPham.DataSource = tenSanPham;

            //===== loadCBO donGia
            List<string> lstDonGia = new List<string>();
            lstDonGia.Add("None");
            lstDonGia.Add("Từ thấp đến cao");
            lstDonGia.Add("Từ cao xuống thấp");
            cboDonGiaDonHang.DataSource = lstDonGia;
            
        }

        private void anThongTIn()
        {
            lblTongSoDonHang.Enabled = false;
            lblTongTatCaDonHang.Enabled = false;
            cboMaNhanVien.Enabled = false;
            cboTenNhanVien.Enabled = false;
            cboTenKhachHang.Enabled = false;
            cboSoDienThoaiKhachHang.Enabled = false;
            cboSanPham.Enabled = false;
            cboDonGiaDonHang.Enabled = false;
            txtDuongDanExport.Enabled = false;
        }

        private void hienThongTIn()
        {
            cboMaNhanVien.Enabled = true;
            cboTenNhanVien.Enabled = true;
            cboTenKhachHang.Enabled = true;
            cboSoDienThoaiKhachHang.Enabled = true;
            cboSanPham.Enabled = true;
            cboDonGiaDonHang.Enabled = true;
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
            dc.DataPropertyName = "thanhTien";
            dc.HeaderText = "Thành tiền";
            dc.Name = "thanhTien";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

        }

        private void formatCbo()
        {
            cboMaNhanVien.SelectedIndex = 0;
            cboTenNhanVien.SelectedIndex = 0;
            cboTenKhachHang.SelectedIndex = 0;
            cboSanPham.SelectedIndex = 0;
            cboSoDienThoaiKhachHang.SelectedIndex = 0;
            cboDonGiaDonHang.SelectedIndex = 0;
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboDanhMucThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDanhMucThongKe.SelectedIndex == 0)
                return;
            else
            {
                if(cboDanhMucThongKe.SelectedIndex == 1)
                {
                    anThongTIn();
                    formatCbo();
                    cboMaNhanVien.Enabled = true;
                    cboTenNhanVien.Enabled = true;

                }else if(cboDanhMucThongKe.SelectedIndex == 2)
                {
                    anThongTIn();
                    formatCbo();
                    cboTenKhachHang.Enabled = true;
                    cboSoDienThoaiKhachHang.Enabled = true;
                }else if(cboDanhMucThongKe.SelectedIndex == 3)
                {
                    anThongTIn();
                    formatCbo();
                    cboDonGiaDonHang.Enabled = true;
                }
                else
                {
                    anThongTIn();
                    formatCbo();
                    cboSanPham.Enabled = true;
                }


            }
        }

        //==== thống kê với nhân viên
        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaNhanVien.SelectedIndex == -1)
                return;
            else
            {
                if (cboTenNhanVien.DataSource == null)
                    return;
                cboTenNhanVien.SelectedIndex = cboMaNhanVien.SelectedIndex;
                // thong ke theo thoi gian + nhan vien
                if(!dateNgayBatDau.Text.Equals("") || !dateNgayCuoi.Text.Equals(""))
                {
                    //thong ke don hang theo nhanvien tu ngay bat dau den ngay hien tai
                    if (!dateNgayBatDau.Text.Equals("") && dateNgayCuoi.Text.Equals(""))
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoNhanVien(dateNgayBatDau.Text, dateNgayCuoi.Text,cboMaNhanVien.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                    }else if (dateNgayBatDau.Text.Equals("") && !dateNgayCuoi.Text.Equals(""))//thong ke don hang theo nhanvien tu ngay cuoi tro ve truoc
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoNhanVien(dateNgayBatDau.Text, dateNgayCuoi.Text, cboMaNhanVien.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                    }
                    else //thong ke don hang theo nhanvien tu ngay bat dau den ngay cuoi
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoNhanVien(dateNgayBatDau.Text, dateNgayCuoi.Text, cboMaNhanVien.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                    }
                }
                else
                {
                    lstDonHang = donHangBUS.getDHTheoNhanVienCoThanhTien(cboMaNhanVien.Text);
                    loadDSDonHangToDataGridView(lstDonHang);
                }    
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
                // thong ke theo thoi gian + nhan vien
                if (!dateNgayBatDau.Text.Equals("") && !dateNgayCuoi.Text.Equals(""))
                {
                    //thong ke don hang theo nhanvien tu ngay bat dau den ngay hien tai
                    if (!dateNgayBatDau.Text.Equals("") && dateNgayCuoi.Text.Equals(""))
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoNhanVien(dateNgayBatDau.Text, dateNgayCuoi.Text, cboMaNhanVien.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                    }
                    else if (dateNgayBatDau.Text.Equals("") && !dateNgayCuoi.Text.Equals(""))//thong ke don hang theo nhanvien tu ngay cuoi tro ve truoc
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoNhanVien(dateNgayBatDau.Text, dateNgayCuoi.Text, cboMaNhanVien.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                    }
                    else //thong ke don hang theo nhanvien tu ngay bat dau den ngay cuoi
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoNhanVien(dateNgayBatDau.Text, dateNgayCuoi.Text, cboMaNhanVien.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                    }
                }
                else
                {

                    lstDonHang = donHangBUS.getDHTheoNhanVienCoThanhTien(cboMaNhanVien.Text);
                    loadDSDonHangToDataGridView(lstDonHang);
                }
            }
        }

        private void btnLoadDSDonHang_Click(object sender, EventArgs e)
        {
            loadDSDonHangToDataGridView();
        }

        private void cboTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenKhachHang.SelectedIndex == -1)
                return;
            else
            {
                // thong ke theo tenKhachHang + thoigian
                if (!dateNgayBatDau.Text.Equals("") || !dateNgayCuoi.Text.Equals(""))
                {
                    //thong ke don hang theo tenKhachHang tu ngay bat dau den ngay hien tai
                    if (!dateNgayBatDau.Text.Equals("") && dateNgayCuoi.Text.Equals(""))
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoKhachHang(dateNgayBatDau.Text, dateNgayCuoi.Text, cboTenKhachHang.Text, cboSoDienThoaiKhachHang.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch
                        {

                        }
                    }
                    else if (dateNgayBatDau.Text.Equals("") && !dateNgayCuoi.Text.Equals(""))//thong ke don hang theo tenKhachHang tu ngay cuoi tro ve truoc
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoKhachHang(dateNgayBatDau.Text, dateNgayCuoi.Text, cboTenKhachHang.Text, cboSoDienThoaiKhachHang.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                    else //thong ke don hang theo tenKhachHang tu ngay bat dau den ngay cuoi
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoKhachHang(dateNgayBatDau.Text, dateNgayCuoi.Text, cboTenKhachHang.Text, cboSoDienThoaiKhachHang.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                }
                else // thong ke theo ten khach hang
                {
                    lstDonHang = donHangBUS.getDHTheoTenKHCoThanhTien(cboTenKhachHang.Text);
                    loadDSDonHangToDataGridView(lstDonHang);
                }
            }
        }

        private void cboSoDienThoaiKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoDienThoaiKhachHang.SelectedIndex == -1)
                return;
            else
            {
                if (cboSoDienThoaiKhachHang.DataSource == null)
                    return;
                cboTenKhachHang.Text = donHangBUS.getTenKhTheoSoDienThoai(cboSoDienThoaiKhachHang.Text);
                // thong ke theo tenKhachHang + thoigian
                if (!dateNgayBatDau.Text.Equals("") || !dateNgayCuoi.Text.Equals(""))
                {
                    //thong ke don hang theo tenKhachHang tu ngay bat dau den ngay hien tai
                    if (!dateNgayBatDau.Text.Equals("") && dateNgayCuoi.Text.Equals(""))
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoKhachHang(dateNgayBatDau.Text, dateNgayCuoi.Text, cboTenKhachHang.Text, cboSoDienThoaiKhachHang.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                    else if (dateNgayBatDau.Text.Equals("") && !dateNgayCuoi.Text.Equals(""))//thong ke don hang theo tenKhachHang tu ngay cuoi tro ve truoc
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoKhachHang(dateNgayBatDau.Text, dateNgayCuoi.Text, cboTenKhachHang.Text, cboSoDienThoaiKhachHang.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                    else //thong ke don hang theo tenKhachHang tu ngay bat dau den ngay cuoi
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoKhachHang(dateNgayBatDau.Text, dateNgayCuoi.Text, cboTenKhachHang.Text, cboSoDienThoaiKhachHang.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                }
                else // thong ke theo ten khach hang
                {
                    lstDonHang = donHangBUS.getDHKhachHangCoThanhTien(cboTenKhachHang.Text, cboSoDienThoaiKhachHang.Text);
                    loadDSDonHangToDataGridView(lstDonHang);
                }
            }
        }

        private void cboSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedIndex == -1)
                return;
            else
            {
                // thong ke theo sanPham + thoigian
                if (!dateNgayBatDau.Text.Equals("") || !dateNgayCuoi.Text.Equals(""))
                {
                    //thong ke don hang theo SanPham tu ngay bat dau den ngay hien tai
                    if (!dateNgayBatDau.Text.Equals("") && dateNgayCuoi.Text.Equals(""))
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoSanPham(dateNgayBatDau.Text, dateNgayCuoi.Text, cboSanPham.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                    else if (dateNgayBatDau.Text.Equals("") && !dateNgayCuoi.Text.Equals(""))//thong ke don hang theo sanPham tu ngay cuoi tro ve truoc
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoSanPham(dateNgayBatDau.Text, dateNgayCuoi.Text, cboSanPham.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                    else //thong ke don hang theo sanPham tu ngay bat dau den ngay cuoi
                    {
                        try
                        {
                            lstDonHang = donHangBUS.thongKeDonHangTheoSanPham(dateNgayBatDau.Text, dateNgayCuoi.Text, cboSanPham.Text);
                            loadDSDonHangToDataGridView(lstDonHang);
                        }
                        catch { }
                    }
                }
                else // thong ke theo ten sanPham
                {
                    lstDonHang = donHangBUS.getDHTheoSanPhamCoThanhTien(cboSanPham.Text);
                    loadDSDonHangToDataGridView(lstDonHang);
                }
            }
        }

        private void cboDonGiaDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDonGiaDonHang.SelectedIndex == -1)
                return;
            else
            {
                if(!dateNgayBatDau.Text.Equals("") || ! dateNgayCuoi.Text.Equals(""))
                {
                    try
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoDonGia(dateNgayCuoi.Text, dateNgayCuoi.Text, cboDonGiaDonHang.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                        
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        lstDonHang = donHangBUS.thongKeDonHangTheoDonGia(cboDonGiaDonHang.Text);
                        loadDSDonHangToDataGridView(lstDonHang);
                    }
                    catch { }
                }
            }
        }

        private void btnChonDuongDan_Click(object sender, EventArgs e)
        {
            LocationExcel = baoCaoExcel.GetLocationForExcel(); 
            txtDuongDanExport.Text =LocationExcel;
        }

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            if (LocationExcel == null)
            {
                MessageBox.Show("Chưa có đường dẫn để xuất dữ liệu");
                return;
            }

            
            if (lstDonHang == null) MessageBox.Show("Danh sách bị trống");
            if(dateNgayBatDau.Text.Equals("") || dateNgayCuoi.Text.Equals(""))
            {
                if(!dateNgayBatDau.Text.Equals("") && dateNgayCuoi.Text.Equals(""))
                {
                    dateNgayCuoi.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }else if (dateNgayBatDau.Text.Equals("") && !dateNgayCuoi.Text.Equals(""))
                {
                    dateNgayBatDau.Text = donHangBUS.layNgayLonNhat();
                }
                else
                {
                    dateNgayBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    dateNgayCuoi.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }

           var result = baoCaoExcel.ReportThongTinDonHang(dgvDSDonHang, LocationExcel, dateNgayBatDau.Text, dateNgayCuoi.Text);
            if (result == true)
            {
                MessageBox.Show("Xuất file thành công");
                LocationExcel = null;
                txtDuongDanExport.Text = "";
            }
            else
            {
                MessageBox.Show("Xuất file thất bại");
            }

            //var result = Extendsion.ReportCalculationSalary(request, LocationExcel);

        }
    }
}