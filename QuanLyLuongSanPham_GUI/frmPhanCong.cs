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
    public partial class frmPhanCong : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanCong()
        {
            InitializeComponent();
            addLuoiCongDoan(dtgvDSCongDoan);
        }
        BUS_PhanCong busPC = new BUS_PhanCong();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_CongDoanSanXuat busCongDoan = new BUS_CongDoanSanXuat();
        BUS_CaLamViec busCaLamViec = new BUS_CaLamViec();
        BindingSource bsCongDoan = new BindingSource();
        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            loadDataToDataGrid();
            loadCbo();
            offControlInput();
            this.dtgvDSCongDoan.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvDSCN.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvCaLamViec.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvDSPhanCong.DefaultCellStyle.ForeColor = Color.Black;
            IEnumerable<PhanCong> listPC = busPC.layAllPhanCong();
            loadCongDoanToDataGrid();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addLuoiCongDoan(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soThuTu";
            dc.HeaderText = "Mã công đoạn";
            dc.Name = "soThuTu";
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenCongDoan";
            dc.HeaderText = "Tên công đoạn";
            dc.Name = "tenCongDoan";
            dc.Visible = true;
            dc.Width = 200;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "donGia";
            dc.HeaderText = "Đơn giá";
            dc.Name = "donGia";
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "thuTuCongDoan";
            dc.HeaderText = "Giai đoạn của công đoạn";
            dc.Name = "thuTuCongDoan";
            dc.Width = 120;
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maSanPhamSanXuat";
            dc.HeaderText = "Mã sản phẩm sản xuất";
            dc.Name = "maSanPhamSanXuat";
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenSanPhamSanXuat";
            dc.HeaderText = "Tên sản phẩm sản xuất";
            dc.Name = "tenSanPhamSanXuat";
            dc.Width = 200;
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soLuongSanXuat";
            dc.HeaderText = "Số lượng sản xuất";
            dc.Name = "soLuongSanXuat";
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maRangBuoc";
            dc.HeaderText = "Mã ràng buộc";
            dc.Name = "maRangBuoc";
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "ngayBatDau";
            dc.HeaderText = "Ngày bắt đầu";
            dc.Name = "ngayBatDau";
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "ngayKetThuc";
            dc.HeaderText = "Ngày kết thúc";
            dc.Name = "ngayKetThuc";
            dc.Visible = true;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "trangThai";
            dc.HeaderText = "Trạng thái";
            dc.Name = "trangThai";
            dc.Visible = true;
            dgr.Columns.Add(dc);

        }
        private void loadDataToDataGrid()
        {
            IEnumerable<NhanVien> listCongNhan = busNV.layDanhSachCongNhan();
            IEnumerable<CaLamViec> listCa = busCaLamViec.layDSCa();
            foreach(var n in listCongNhan)
            {
                dtgvDSCN.Rows.Add(n.maNhanVien, n.tenNhanVien);
                dtgvDSCN.Rows[dtgvDSCN.RowCount - 1].Tag = n;
            }
            foreach(var n in listCa)
            {
                dtgvCaLamViec.Rows.Add(n.maCa, n.ca);
                dtgvCaLamViec.Rows[dtgvCaLamViec.RowCount - 1].Tag = n;
            }

           
            dtgvDSPhanCong.DataSource = busPC.layDSPhanCong();
            dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoanChuaHoanThanh();
        }

        private void loadCongDoanToDataGrid()
        {
            bsCongDoan.DataSource = busCongDoan.layDSCongDoan();
            dtgvDSCongDoan.DataSource = bsCongDoan;
        }
        private void loadCbo()
        {
            IEnumerable<NhanVien> listQLNS = busNV.layDSQLNS();
            IEnumerable<NhanVien> listCongNhan = busNV.layDanhSachCongNhan();
            IEnumerable<CaLamViec> listCa = busCaLamViec.layDSCa();
            IEnumerable<CongDoanSanXuat> listCD = busCongDoan.layAllCDCHT();

            foreach (var n in listCongNhan)
            {
                cboMaCongNhan.Items.Add(n.maNhanVien);
                cboTenCongNhan.Items.Add(n.tenNhanVien);
            }
            foreach (var n in listCa)
            {
                cboMaCa.Items.Add(n.maCa);
                cboTenCa.Items.Add(n.ca);
            }
            foreach(var n in listCD)
            {
                cboMaCongDoan.Items.Add(n.soThuTu);
                cboTenCongDoan.Items.Add(n.tenCongDoan);
            }
            foreach(var n in listQLNS)
            {
                cboMaNhanVien.Items.Add(n.maNhanVien);
                cboTenNhanVien.Items.Add(n.tenNhanVien);
            }
        }
        private void offControlInput()
        {
            cboMaCongNhan.Enabled = false;
            cboTenCongNhan.Enabled = false;
            cboTenCongDoan.Enabled = false;
            cboMaCongDoan.Enabled = false;
            cboMaCa.Enabled = false;
            cboTenCa.Enabled = false;
            txtMsPhanCong.Enabled = false;
            dtpNgayPhanCong.Enabled = false;
            cboMaNhanVien.Enabled = false;
            cboTenNhanVien.Enabled = false;
        }
        private void onControlInput()
        {
            cboMaCongNhan.Enabled = true;
            cboTenCongNhan.Enabled = true;
            cboTenCongDoan.Enabled = true;
            cboMaCongDoan.Enabled = true;
            cboMaCa.Enabled = true;
            cboTenCa.Enabled = true;
            txtMsPhanCong.Enabled = true;
            dtpNgayPhanCong.Enabled = true;
            cboMaNhanVien.Enabled = true;
            cboTenNhanVien.Enabled = true;
        }
        private void onButton()
        {
            btnSuaCong.Enabled = true;
            btnXoaCong.Enabled = true;
        }
        private void clearInPutControl()
        {
            cboMaCongNhan.Text ="";
            cboTenCongNhan.Text ="";
            cboTenCongDoan.Text="";
            cboMaCongDoan.Text= "";
            cboMaCa.Text = "";
            cboTenCa.Text= "";
            txtMsPhanCong.Text = "";
            dtpNgayPhanCong.Text = "";
            cboMaNhanVien.Text = "";
            cboTenNhanVien.Text = "";
        }
        private bool kiemTraNull()
        {
            if (cboMaCa.Text == "" || cboMaCongDoan.Text == "" || cboMaCongNhan.Text == "" || txtMsPhanCong.Text == ""||cboMaNhanVien.Text=="")
            {
                return true;
            }
            return false;
        }

        private void dtgvDSPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDSPhanCong.Rows[e.RowIndex];
                txtMsPhanCong.Text = row.Cells[0].Value.ToString();
                cboMaCongNhan.Text = row.Cells[1].Value.ToString();
                cboTenCongNhan.Text = row.Cells[2].Value.ToString();
                cboMaCongDoan.Text = row.Cells[3].Value.ToString();
                cboTenCongDoan.Text = row.Cells[4].Value.ToString();
                cboMaCa.Text = row.Cells[5].Value.ToString();
                cboTenCa.Text = row.Cells[6].Value.ToString();
                dtpNgayPhanCong.Text = row.Cells[7].Value.ToString();
                cboMaNhanVien.Text = row.Cells[8].Value.ToString();
                if (cboMaCongDoan.Equals(""))
                {
                    txtSoLuongCongNhanTrongCongDoan.Text = "";
                    txtSoLuongCongNhanToiDa.Text = "";
                }
                else
                {
                    txtSoLuongCongNhanTrongCongDoan.Text = busPC.getSoLuongNhanVienCoTrongCongDoan(cboMaCongDoan.Text).ToString();
                    txtSoLuongCongNhanToiDa.Text = busCongDoan.getSoLuongNhanVienToiDaCoTrongCongDoan(cboMaCongDoan.Text).ToString();
                }
                onButton();
            }
        }
        private void dtgvDSCongDoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDSCongDoan.Rows[e.RowIndex];
                cboMaCongDoan.Text = row.Cells[0].Value.ToString();
                cboTenCongDoan.Text = row.Cells[1].Value.ToString();
                if (cboMaCongDoan.Equals(""))
                {
                    txtSoLuongCongNhanTrongCongDoan.Text = "";
                    txtSoLuongCongNhanToiDa.Text = "";
                }
                else
                {
                    txtSoLuongCongNhanTrongCongDoan.Text = busPC.getSoLuongNhanVienCoTrongCongDoan(cboMaCongDoan.Text).ToString();
                    txtSoLuongCongNhanToiDa.Text = busCongDoan.getSoLuongNhanVienToiDaCoTrongCongDoan(cboMaCongDoan.Text).ToString();
                }
            }
        }
        private void cboMaCongDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<CongDoanSanXuat> listCD = busCongDoan.layAllDsCD();
            foreach(var n in listCD)
            {
                if (cboMaCongDoan.Text.Equals(n.soThuTu.ToString()))
                {
                    cboTenCongDoan.Text = n.tenCongDoan;
                }
            }
        }
        private void cboTenCongDoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<CongDoanSanXuat> listCD = busCongDoan.layAllDsCD();
            foreach (var n in listCD)
            {
                if (cboTenCongDoan.Text.Equals(n.tenCongDoan))
                {
                    cboMaCongDoan.Text = n.soThuTu.ToString();
                }
            }
        }
        private void cboMaCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<CaLamViec> listCa = busCaLamViec.layDSCa();
            foreach(var n in listCa)
            {
                if (cboMaCa.Text.Equals(n.maCa))
                {
                    cboTenCa.Text = n.ca;
                }
            }
        }
        private void cboTenCa_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<CaLamViec> listCa = busCaLamViec.layDSCa();
            foreach (var n in listCa)
            {
                if (cboTenCa.Text.Equals(n.ca))
                {
                    cboMaCa.Text = n.maCa;
                }
            }
        }
        private void cboMaCongNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> listCongNhan = busNV.layDanhSachCongNhan();
            foreach (var n in listCongNhan)
            {
                if (cboMaCongNhan.Text.Equals(n.maNhanVien))
                {
                    cboTenCongNhan.Text = n.tenNhanVien;
                }
            }
        }
        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> listQLNS = busNV.layDSQLNS();
            foreach (var n in listQLNS)
            {
                if (cboMaNhanVien.Text.Equals(n.maNhanVien))
                    cboTenNhanVien.Text = n.tenNhanVien;
            }
        }

        private void cboTenCongNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> listCongNhan = busNV.layDanhSachCongNhan();
            foreach (var n in listCongNhan)
            {
                if (cboTenCongNhan.Text.Equals(n.tenNhanVien))
                {
                    cboMaCongNhan.Text = n.maNhanVien;
                }
            }
        }
        private bool kiemTraPhanCongTrung(string strmaNV,string strMaCa,string ngayLamm)
        {
            IEnumerable<PhanCong> listPC = busPC.layAllPhanCong();
            foreach(var n in listPC)
            {
                if (strmaNV.Equals(n.maNhanVien) && strMaCa.Equals(n.maCa) && ngayLamm.Equals(String.Format("{0:dd,MM,yyyy}", n.ngayLam).ToString()))
                    return true;
            }
            return false;
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if(btnPhanCong.Text.Equals("Phân công"))
            {
                btnPhanCong.Text = "Lưu";
                clearInPutControl();
                onControlInput();
            }
            else if (kiemTraPhanCongTrung(cboMaCongNhan.Text, cboMaCa.Text, dtpNgayPhanCong.Text) == true )
            {
                MessageBox.Show("Công nhân này đã được phân công trùng lịch!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (kiemTraNull() == true)
            {
                MessageBox.Show("Không được để trống dữ liệu!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DTO_PhanCong pc = new DTO_PhanCong();
                pc.MaPhanCong = txtMsPhanCong.Text;
                pc.MaNhanVien = cboMaCongNhan.Text;
                pc.MaCongDoan = Convert.ToInt32(cboMaCongDoan.Text);
                pc.MaCa = cboMaCa.Text;
                pc.NgayLam = dtpNgayPhanCong.Value;
                pc.MaNVPhanCong = cboMaNhanVien.Text;
                if (busPC.phanCong(pc) == true)
                {
                    MessageBox.Show("Thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busPC.phanCong(pc);
                    dtgvDSPhanCong.DataSource = busPC.layDSPhanCong();
                }
                else
                {
                    MessageBox.Show("Thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                clearInPutControl();
                offControlInput();
                btnPhanCong.Text = "Phân công";
            }
            
        }
        private void btnSuaCong_Click(object sender, EventArgs e)
        {
            if (btnSuaCong.Text.Equals("Sửa công"))
            {
                btnSuaCong.Text = "Lưu";
                onControlInput();
                txtMsPhanCong.Enabled = false;
            }
            else if (kiemTraNull() == true)
            {
                MessageBox.Show("Không được để trống dữ liệu!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else if (kiemTraPhanCongTrung(cboMaCongNhan.Text, cboMaCa.Text, dtpNgayPhanCong.Text) == true)
            {
                MessageBox.Show("Công nhân này đã được phân công trùng lịch!!!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {
                DTO_PhanCong pc = new DTO_PhanCong();
                pc.MaPhanCong = txtMsPhanCong.Text;
                pc.MaNhanVien = cboMaCongNhan.Text;
                pc.MaCongDoan = Convert.ToInt32(cboMaCongDoan.Text);
                pc.MaCa = cboMaCa.Text;
                pc.NgayLam = dtpNgayPhanCong.Value;
                pc.MaNVPhanCong = cboMaNhanVien.Text;
                if (busPC.suaPhanCong(pc) == true)
                {
                    MessageBox.Show("Thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busPC.suaPhanCong(pc);
                    dtgvDSPhanCong.DataSource = busPC.layDSPhanCong();
                }
                else
                {
                    MessageBox.Show("Thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                clearInPutControl();
                offControlInput();
                btnSuaCong.Text = "Sửa công";
            }
            
        }

        private void btnXoaCong_Click(object sender, EventArgs e)
        {
            DialogResult dlg;
            if (dtgvDSPhanCong.SelectedRows.Count > 0)
            {
                dlg = MessageBox.Show("Are you sure delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dlg == DialogResult.Yes)
                {
                    bool xoa = busPC.xoaPhanCong(txtMsPhanCong.Text);
                    if (xoa == true)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        dtgvDSPhanCong.DataSource = busPC.layDSPhanCong();
                    }
                    else
                    {
                        MessageBox.Show("fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dtgvDSPhanCong.DataSource = busPC.layDSPhanCong();
        }

    }
}