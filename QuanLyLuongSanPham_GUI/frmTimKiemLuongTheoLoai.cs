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
using QuanLyLuongSanPham_BUS;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmTimKiemLuongTheoLoai : Form
    {
        #region Properties
        bool bCheck = false;
        public delegate void nvTimKiem(bool bCheck, string strMaNV, string strThang, string strNam);
        public nvTimKiem nvTimKiemLuongCN;
        Point LastPoint;
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_LoaiNhanVien busLoaiNV = new BUS_LoaiNhanVien();
        BUS_LuongCongNhan busLuongCN = new BUS_LuongCongNhan();
        BUS_TimKiemNhanVienTheoLuong bus_TimKiemNVTheoLuong = new BUS_TimKiemNhanVienTheoLuong();
        #endregion

        #region Methos
        public frmTimKiemLuongTheoLoai()
        {
            InitializeComponent();
        }
        private void loadCBBThangNam()
        {
            for (int i = 1; i <= 12; i++)
            {
                cbbLuongThang.Items.Add(i);
            }
        }

        private void loadCBBNam()
        {
            ccbNam.Items.Add("2020");
            ccbNam.Items.Add("2021");
        }
        private void loadAutoComplete()
        {
            txtTimKiemMaNV.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiemMaNV.AutoCompleteMode = AutoCompleteMode.Suggest;

            txtTimKiemTenNV.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTimKiemTenNV.AutoCompleteMode = AutoCompleteMode.Suggest;
        }
        private void loadCBBTimKiemTheo()
        {
            ccbTimKiemTheoLoai.Text = "Lương Nhân viên Hành Chánh";
            ccbTimKiemTheoLoai.Items.Add("Lương Công Nhân");
            ccbTimKiemTheoLoai.Items.Add("Lương Nhân viên Hành Chánh");
        }
        private void AppliedFilter()
        {
            if (ccbTimKiemTheoLoai.Text == "Lương Công Nhân" && cbbLuongThang.Text != "" && ccbNam.Text != "")
            {
                dtgvDanhSachTimKiem.DataSource = busNV.serchNhanVienLuongCNhan(txtTimKiemMaNV.Text, txtTimKiemTenNV.Text, cbbLuongThang.Text, ccbNam.Text);
            }
            else if (ccbTimKiemTheoLoai.Text == "Lương Nhân viên Hành Chánh" && cbbLuongThang.Text != "" && ccbNam.Text != "")
            {
                dtgvDanhSachTimKiem.Columns[5].HeaderText = "Lương Cơ Bản";
                dtgvDanhSachTimKiem.Columns[5].DataPropertyName = "luongCoBan";
                dtgvDanhSachTimKiem.Columns[6].HeaderText = "Số Ngày Công TT";
                dtgvDanhSachTimKiem.Columns[6].DataPropertyName = "soNgayCongTT";
                dtgvDanhSachTimKiem.DataSource = busNV.serchNhanVienLuongHChanh(txtTimKiemMaNV.Text, txtTimKiemTenNV.Text, cbbLuongThang.Text, ccbNam.Text);
            }
            else
            {
                lblError1.Visible = true;
                MessageBox.Show("Vui lòng điền đầy đủ các mục (*) !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);    
            }
        }
        private void offText(bool bText)
        {
            txtTimKiemMaNV.Enabled = bText;
            txtTimKiemTenNV.Enabled = bText;
            cbbLuongThang.Enabled = bText;
            btnLamMoi.Enabled = bText;
            btnTimKiem.Enabled = bText;
        }
        private void loadError()
        {
            lblError1.Visible = false;
            lblError3.Visible = true;
        }
        private void clearText()
        {
            txtTimKiemMaNV.Clear();
            txtTimKiemTenNV.Clear();
        }
        #endregion

        #region Event
        private void FrmTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            loadError();
            this.dtgvDanhSachTimKiem.DefaultCellStyle.ForeColor = Color.Black;
            Util.Animate(this, Util.Effect.Center, 150, 180);
            loadCBBTimKiemTheo();
            loadCBBThangNam();
            loadCBBNam();
            loadAutoComplete();
        }
        private void FrmTimKiemNhanVien_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }
        private void FrmTimKiemNhanVien_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }
        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> dsNV = busNV.layAllDSNV();
            foreach (NhanVien n in dsNV)
            {
                if (txtTimKiemMaNV.Text.Equals(n.maNhanVien))
                {
                    txtTimKiemTenNV.Text = n.tenNhanVien;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtTimKiemMaNV.Text = null;
            txtTimKiemTenNV.Text = null;
            txtTimKiemTenNV.Focus();
            dtgvDanhSachTimKiem.DataSource = null;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            AppliedFilter();
        }
        private void dtgvDanhSachTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bCheck = true;
            string maNVTimKiem = "";
            string strThang = "";
            string strNam = "";
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDanhSachTimKiem.Rows[e.RowIndex];
                maNVTimKiem = row.Cells[0].Value.ToString();
                strThang = row.Cells[3].Value.ToString();
                strNam = row.Cells[4].Value.ToString();
            }
            nvTimKiemLuongCN(bCheck, maNVTimKiem, strThang, strNam);
            this.Close();
        }

        private void txtTimKiemMaNV_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ccbTimKiemTheoLoai.Text == "Lương Công Nhân")
                {
                    IEnumerable<LuongCongNhan> lstlcn = bus_TimKiemNVTheoLuong.layMNVLuongCN();
                    txtTimKiemMaNV.AutoCompleteCustomSource.Clear();
                    foreach (LuongCongNhan lcn in lstlcn)
                    {
                        try
                        {
                            txtTimKiemMaNV.AutoCompleteCustomSource.Add(lcn.maNhanVien.ToString().Trim());
                        }
                        catch (Exception) { }
                    }
                }
                else
                {
                    IEnumerable<LuongHanhChanh> lstlcn = bus_TimKiemNVTheoLuong.layMNVLuongHC();
                    txtTimKiemMaNV.AutoCompleteCustomSource.Clear();
                    foreach (LuongHanhChanh lcn in lstlcn)
                    {
                        try
                        {
                            txtTimKiemMaNV.AutoCompleteCustomSource.Add(lcn.maNhanVien.ToString().Trim());
                        }
                        catch (Exception) { }
                    }
                }    
            }
            catch (Exception) { }
        }
        private void ccbTimKiemTheoLoai_Leave(object sender, EventArgs e)
        {
            if (ccbTimKiemTheoLoai.Text == "")
            {
                lblError1.Visible = true;
                offText(false);
            }
            else
            {
                lblError1.Visible = false;
            }
        }

        private void txtTimKiemMaNV_Leave(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> dsNV = busNV.layAllDSNV();
            foreach (NhanVien n in dsNV)
            {
                if (txtTimKiemMaNV.Text.Equals(n.maNhanVien.Trim()))
                {
                    txtTimKiemTenNV.Text = n.tenNhanVien;
                }
            }
        }
        private void ccbTimKiemTheoLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            offText(true);
            clearText();
        }
        private void cbbLuongThang_Leave(object sender, EventArgs e)
        {
            if (cbbLuongThang.Text != "")
            {
                lblError3.Visible = false;
            }
            else
            {
                lblError3.Visible = true;
            }    
        }
        private void ccbNam_Leave(object sender, EventArgs e)
        {
            if (ccbNam.Text != "")
            {
                lblError4.Visible = false;
            }
            else
            {
                lblError4.Visible = true;
            }
        }
        #endregion
    }
}

