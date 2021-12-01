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
namespace QuanLyLuongSanPham_GUI
{
    public partial class frmPhat : Form
    {
        public frmPhat()
        {
            InitializeComponent();
        }
        BUS_PhatNhanVien busPhatNhanVien = new BUS_PhatNhanVien();
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        BUS_MucTienPhat busMTP = new BUS_MucTienPhat();

        Point LastPoint;
        private void FrmPhat_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            dtgvDsPhat.DefaultCellStyle.ForeColor = Color.Black;
            dtgvDsPhat.DataSource = busPhatNhanVien.layDSPhat();
            loadCbo();
        }

        private void FrmPhat_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmPhat_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }
        private void loadCbo()
        {
            IEnumerable<NhanVien> listNV = busNhanVien.layAllDSNV();
            IEnumerable<MucTienPhat> listMP = busMTP.layThongTinPhat();
            IEnumerable<PhatNhanVien> listP = busPhatNhanVien.layAllDS();
            foreach(var n in listNV)
            {
                cboMaNhanVien.Items.Add( n.maNhanVien);
                cboTenNhanVien.Items.Add(n.tenNhanVien);
            }
            foreach(var n in listMP)
            {
                cboMaPhat.Items.Add(n.soThuTu);
                cboMucPhat.Items.Add(n.tenKhoanPhat);
                cboTienPhat.Items.Add(n.mucTienPhat1);
            }
            foreach(var n in listP)
            {
                cboMaDonVi.Items.Add(n.maDonVi);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        private void dtgvDsPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDsPhat.Rows[e.RowIndex];
                cboMaNhanVien.Text = row.Cells[0].Value.ToString();
                cboTenNhanVien.Text = row.Cells[1].Value.ToString();
                cboMaPhat.Text = row.Cells[2].Value.ToString();
                cboMucPhat.Text = row.Cells[3].Value.ToString();
                cboTienPhat.Text = row.Cells[4].Value.ToString();
                dtpNgayPhat.Text = row.Cells[5].Value.ToString();
                cboMaDonVi.Text = row.Cells[6].Value.ToString();
            }
        }

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> listNV = busNhanVien.layAllDSNV();
            foreach(var n in listNV)
            {
                if (cboMaNhanVien.Text.Equals(n.maNhanVien))
                    cboTenNhanVien.Text = n.tenNhanVien;
            }
        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> listNV = busNhanVien.layAllDSNV();
            foreach (var n in listNV)
            {
                if (cboTenNhanVien.Text.Equals(n.tenNhanVien))
                    cboMaNhanVien.Text = n.maNhanVien;
            }
        }

        private void cboMaPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //IEnumerable<>
        }
    }
}
