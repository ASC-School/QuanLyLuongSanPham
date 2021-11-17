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
    public partial class frmTimKiemNhanVien : Form
    {
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_LoaiNhanVien busLoaiNV = new BUS_LoaiNhanVien();
        BUS_DonViQuanLy busDonVi = new BUS_DonViQuanLy();
        public frmTimKiemNhanVien()
        {
            InitializeComponent();
        }

        Point LastPoint;
        private void FrmTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            loadDataToCbo();
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

        private void cbDonVi_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void loadDataToCbo()
        {
            IEnumerable<DonViQuanLy> dsDonVi = busDonVi.getDSDonVi();
            IEnumerable<NhanVien> dsNV = busNV.layAllDSNV();
            foreach (DonViQuanLy lnv in dsDonVi)
            {
                cboDonVi.Items.Add(lnv.tenBoPhan);
                
            }
            foreach(NhanVien nv in dsNV)
            {
                cboMaNhanVien.Items.Add(nv.maNhanVien);
                cboTenNhanVien.Items.Add(nv.tenNhanVien);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }
    }
}
