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
using System.Drawing.Printing;
using System.Globalization;
using QuanLyLuongSanPham_GUI.Properties;

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
        List<DTO_ChiTietDonHang> lstChiTietThuocDonHang = null;
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
            nhanVienBUS = new BUS_NhanVien();
            lstSanPham = donHangBUS.getDSSanPham();
            toolTipOpenFrmSanPham.SetToolTip(btnOpenFrmSanPham,"Thêm sản phẩm");
            addLuoiChiTietDonHang(dgvChiTietDonHang);
        }

        private void loadChiTietDonHangToDataGridView()
        {
            anThongTin();
            if (donHangBUS.getAllChiTietDonHang(donHangDTO.MaDonHang) == null)
            {
                bsPH.DataSource = null;
            }
            else
            {
                bsPH.DataSource = donHangBUS.getAllChiTietDonHang(donHangDTO.MaDonHang);
                dgvChiTietDonHang.DataSource = bsPH;
                bindingNavigatorCTDH.BindingSource = bsPH;
                //FormatLuoi(dgvChiTietDonHang);
                loadCboSanPham();
                lblTongTien.Text = donHangBUS.tongTienDonHang(txtMaDonHang.Text).ToString();
            }
            
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

        private void addLuoiChiTietDonHang(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maDonHang";
            dc.HeaderText = "Mã đơn hàng";
            dc.Name = "maDonHang";
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
            dc.DataPropertyName = "maSanPham";
            dc.HeaderText = "Mã sản phẩm";
            dc.Name = "maSanPham";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenSanPham";
            dc.HeaderText = "Tên sản phẩm";
            dc.Name = "tenSanPham";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soLuong";
            dc.HeaderText = "Số lượng";
            dc.Name = "soLuong";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "donGiaSanPham";
            dc.HeaderText = "Đơn giá sản phẩm";
            dc.Name = "donGiaSanPham";
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

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maNhanVien";
            dc.HeaderText = "Mã nhân viên";
            dc.Name = "maNhanVien";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);


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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            loadChiTietDonHangToDataGridView();
            loadDSSanPhamToDataGridView();
            this.dgvChiTietDonHang.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvSanPham.DefaultCellStyle.ForeColor = Color.Black;
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
            this.Close();
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
                    if (!donHangBUS.checkExistChiTietDonHang(newCTDH.MaSanPham,txtMaDonHang.Text))
                    {
                        donHangBUS.themChiTietDonHang(txtMaDonHang.Text, newCTDH);
                    }
                    else
                    {
                        donHangBUS.tangSoLuongSanPham(newCTDH);

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
                        DTO_SanPham tmp = getSanPham(cboTenSanPham.Text);
                        bool sanPham = donHangBUS.xoaChiTietDonHang(tmp.MaSanPham,txtMaDonHang.Text);
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

        private void btnInDonHang_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;//                                chieu rong,chieucao
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Hợp đồng sản xuất", 900, 1700);
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // them logo cho don hang
            Image img = Resources.logo;

            // ve logo vaof toa do 0 0 den het chiu dai chiu ong anh
            e.Graphics.DrawImage(img, 0, 0, img.Width, img.Height);
            // them ngay thang
            DTO_DonHang buffer = donHangBUS.getDonHang(txtMaDonHang.Text);
            DTO_NhanVien nvTmp = nhanVienBUS.getMotNhanVien(txtMaNhanVien.Text);
            e.Graphics.DrawString("Ngày: " + DateTime.Now, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Red, new Point(25, 200));
            e.Graphics.DrawString("HỢP ĐỒNG SẢN XUẤT SẢN PHẨM", new Font("Tahoma", 40, FontStyle.Bold), Brushes.Red, new Point(500, 50));
            // in phan thong itn don hang
            e.Graphics.DrawString("Mã đơn hàng: " + txtMaDonHang.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 230));
            e.Graphics.DrawString("Mã nhân viên: " + txtMaNhanVien.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 230));
            e.Graphics.DrawString("Ngày bắt đầu: " + buffer.NgayBatDau, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 260));
            e.Graphics.DrawString("Tên nhân viên: " + nvTmp.TenNhanVien, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 260));
            e.Graphics.DrawString("Ngày kết thúc: " + buffer.NgayKetThuc, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 290));
            e.Graphics.DrawString("Nội dung: " + buffer.NoiDung, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 290));
            e.Graphics.DrawString("Tên khách hàng: " + txtTenKhachHang.Text.Trim(), new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(25, 320));
            e.Graphics.DrawString("Số điện thoại khách hàng: " + buffer.SoDienThoaiKhachHang, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, new Point(450, 320));
            Pen pen1 = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(pen1, 25, 350, 1600, 350);
            try
            {
                lstChiTietThuocDonHang = donHangBUS.getCTDH(txtMaDonHang.Text);
                if (lstChiTietThuocDonHang != null)
                {
                    e.Graphics.DrawString("SẢN PHẨM", new Font("Tahoma", 24, FontStyle.Bold), Brushes.Black, new Point(700, 380));
                    Pen pen = new Pen(Color.Black, 1);
                    e.Graphics.DrawLine(pen, 25, 430, 1600, 430);
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
                    foreach (var item in lstChiTietThuocDonHang)
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
    }
}