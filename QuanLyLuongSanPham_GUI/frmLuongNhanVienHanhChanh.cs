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
    public partial class frmLuongNhanVienHanhChanh : DevExpress.XtraEditors.XtraForm
    {
        public frmLuongNhanVienHanhChanh()
        {
            InitializeComponent();
        }

        #region Propepties
        Point LastPoint;
        BUS_LuongNhanVienHanhChanh bus_LuongNVHC = new BUS_LuongNhanVienHanhChanh();
        BUS_DonViQuanLy busDVQL = new BUS_DonViQuanLy();
        BUS_NhanVien busNV = new BUS_NhanVien();
        bool bCheckNVTimKiem = false;
        #endregion

        #region Methos
        private void loadCBBThangNam()
        {
            for (int i = 1; i <= 12; i++)
            {
                _ = ccbThang.Items.Add(i);
            }
            ccbNam.Items.Add(2021);
            ccbNam.Items.Add(2020);
        }
        private void loadLuongNVHanhChanh()
        {
            btnHuy.Enabled = false;
            this.dtgvLuongHanhChanh.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongHanhChanh.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.loadLuongHC();
        }

        private void clearTextBox()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtLuongCoBan.Text = "";
            txtDonVi.Text = "";
            txtPhuCap.Text = "";
            txtSoNgayCongTT.Text = "";
            txtTienPhat.Text = "";
            txtThue.Text = "";
            txtTongLuongTT.Text = "";
            txtTamUng.Text = "";
            txtThucNhan.Text = "";
        }
        private void toolTip()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnChiTietLuong, "Xem chi tiết lương");
            ToolTip2.SetToolTip(this.btnReLoad, "Tải lại trang");
        }

        private void offEnTextBox(bool bCheck)
        {
            txtMaNV.Enabled = bCheck;
            txtHoTen.Enabled = bCheck;
            txtDonVi.Enabled = bCheck;
            txtLuongCoBan.Enabled = bCheck;
            txtSoNgayCongTT.Enabled = bCheck;
            txtPhuCap.Enabled = bCheck;
            txtTienPhat.Enabled = bCheck;
            txtThue.Enabled = bCheck;
            txtTongLuongTT.Enabled = bCheck;
            txtTamUng.Enabled = bCheck;
            txtThucNhan.Enabled = bCheck;
        }
        #endregion

        #region Event
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        private void FrmLuongNhanVienHanhChanh_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            loadLuongNVHanhChanh();
            offEnTextBox(false);
            toolTip();
            loadCBBThangNam();
        }

        private void FrmLuongNhanVienHanhChanh_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmLuongNhanVienHanhChanh_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimKiemLuongTheoLoai fTimKiemNVHC = new frmTimKiemLuongTheoLoai();
                fTimKiemNVHC.nvTimKiemLuongCN = loadNVTimKiem;
                _ = fTimKiemNVHC.ShowDialog();
            }
            catch (Exception) { }
        }

        private void loadNVTimKiem(bool bCheck, string strMaNV, string strThang, string strNam)
        {
            if (bCheck)
            {
                dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.layNVTheoTimKiem(strMaNV);
                this.dtgvLuongHanhChanh.SelectionMode = DataGridViewSelectionMode.CellSelect;
                ccbThang.Text = strThang;
                ccbNam.Text = strNam;
            }
        }

        private void dtgvLuongHanhChanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvLuongHanhChanh.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtDonVi.Text = row.Cells[2].Value.ToString();
                txtLuongCoBan.Text = row.Cells[3].Value.ToString();
                txtSoNgayCongTT.Text = row.Cells[4].Value.ToString();
                txtPhuCap.Text = row.Cells[5].Value.ToString();
                txtTienPhat.Text = row.Cells[6].Value.ToString();
                txtThue.Text = row.Cells[7].Value.ToString();
                txtTongLuongTT.Text = row.Cells[8].Value.ToString();
                txtTamUng.Text = row.Cells[9].Value.ToString();
                txtThucNhan.Text = row.Cells[10].Value.ToString();
            }
        }
        #endregion

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            this.dtgvLuongHanhChanh.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongHanhChanh.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.loadLuongHC();
        }

        private void btnChiTietLuong_Click(object sender, EventArgs e)
        {
            frmPhieuLuongNhanVien fPhieuLuong = new frmPhieuLuongNhanVien();
            fPhieuLuong.phieuLuongCN(1, txtMaNV.Text, txtHoTen.Text, txtDonVi.Text, txtLuongCoBan.Text, txtSoNgayCongTT.Text, "", "", txtPhuCap.Text, txtTienPhat.Text, txtTamUng.Text, txtThue.Text, ccbThang.Text, ccbNam.Text, txtThucNhan.Text);
            fPhieuLuong.ShowDialog();
        }

        private void ccbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearTextBox();
            int iMonth = Convert.ToInt32(ccbThang.Text);
            int iYear = Convert.ToInt32(ccbNam.Text);
            this.dtgvLuongHanhChanh.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongHanhChanh.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.luongHCTheoThang(iMonth, iYear);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtSoNgayCongTT.Enabled = true;
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnHuy.Enabled = true;
            }
            else if (btnSua.Text == "Lưu")
            {
                if (txtSoNgayCongTT.Text == "")
                {
                    MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    DTO_LuongHanhChanh dto_LHC = new DTO_LuongHanhChanh();
                    dto_LHC.MaNhanVien = txtMaNV.Text;
                    dto_LHC.SoNgayLamDuoc = Convert.ToInt32(txtSoNgayCongTT.Text);
                    if (bus_LuongNVHC.suaThongTin(dto_LHC) == true)
                    {
                        bus_LuongNVHC.suaThongTin(dto_LHC);
                        MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dtgvLuongHanhChanh.Rows.Count == 1)
                        {
                            string strMaNV = txtMaNV.Text.Trim();
                            dtgvLuongHanhChanh.DataSource = busNV.serchNhanVienLuongHChanh(strMaNV, "dataSearchOne", "dataSearchSecond", "dataSearchThirst");
                        }
                        else
                        {
                            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.loadLuongHC();
                        }
                        btnSua.Text = "Sửa";
                        txtSoNgayCongTT.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                }
            }
        }
    }
}
