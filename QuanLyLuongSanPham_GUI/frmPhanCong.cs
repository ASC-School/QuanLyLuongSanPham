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
            }
        }
    }
}