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
        }
        BUS_PhanCong busPC = new BUS_PhanCong();
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_CongDoanSanXuat busCongDoan = new BUS_CongDoanSanXuat();
        BUS_CaLamViec busCaLamViec = new BUS_CaLamViec();
        private void frmPhanCong_Load(object sender, EventArgs e)
        {
            loadDataToDataGrid();
            loadCbo();
            offControlInput();
            this.dtgvDSCongDoan.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvDSCN.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvCaLamViec.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvDSPhanCong.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
            dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoan();
        }
        private void loadCbo()
        {
            IEnumerable<NhanVien> listCongNhan = busNV.layDanhSachCongNhan();
            IEnumerable<CaLamViec> listCa = busCaLamViec.layDSCa();
            IEnumerable<CongDoanSanXuat> listCD = busCongDoan.layAllDsCD();
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
        }
        private void onControlInput()
        {
            cboMaCongNhan.Enabled = true;
            cboTenCongNhan.Enabled = true;
            cboTenCongDoan.Enabled = true;
            cboMaCongDoan.Enabled = true;
            cboMaCa.Enabled = true;
            cboTenCa.Enabled = true;
            //txtMsPhanCong.Enabled = true;
            dtpNgayPhanCong.Enabled = true;
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
        }
        private bool kiemTraNull()
        {
            if (cboMaCa.Text == "" || cboMaCongDoan.Text == "" || cboMaCongNhan.Text == "" || txtMsPhanCong.Text == "")
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
                onButton();
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

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if(btnPhanCong.Text.Equals("Phân công"))
            {
                btnPhanCong.Text = "Lưu";
                clearInPutControl();
                onControlInput();
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
                btnPhanCong.Text = "Phân công";
            }
            
        }
        private void btnSuaCong_Click(object sender, EventArgs e)
        {
            if (btnPhanCong.Text.Equals("Sửa công"))
            {
                btnPhanCong.Text = "Lưu";
                clearInPutControl();
                onControlInput();
                txtMsPhanCong.Enabled = false;
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