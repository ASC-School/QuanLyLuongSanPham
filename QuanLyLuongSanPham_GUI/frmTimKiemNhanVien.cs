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
        string maLoai;
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
            IEnumerable<LoaiNhanVien> dsLoai = busLoaiNV.getNhanVienForQLNS();
            IEnumerable<NhanVien> dsNV = busNV.layAllDSNV();
            foreach (LoaiNhanVien lnv in dsLoai)
            {
                cboDonVi.Items.Add(lnv.loaiNhanVien1);
                
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

        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> dsNV = busNV.layAllDSNV();
            IEnumerable<LoaiNhanVien> dsLoai = busLoaiNV.getNhanVienForQLNS();
            foreach (NhanVien n in dsNV)
            {
                if (cboMaNhanVien.Text.Equals(n.maNhanVien))
                {
                    cboTenNhanVien.Text = n.tenNhanVien;
                    maLoai = n.maLoai;
                    dtpTime.Value = n.ngayBatDauCongTac;
                    
                }
                foreach (LoaiNhanVien lnv in dsLoai)
                {
                    if (lnv.maLoai.Equals(maLoai))
                    {
                        cboDonVi.Text = lnv.loaiNhanVien1;
                    }
                }
            }
        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> dsNV = busNV.layAllDSNV();
            foreach (NhanVien n in dsNV)
            {
                if (cboTenNhanVien.Text.Equals(n.tenNhanVien))
                {
                    cboMaNhanVien.Text = n.maNhanVien;
                    maLoai = n.maLoai;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cboMaNhanVien.Text = null;
            cboDonVi.Text = null;
            cboTenNhanVien.Text = null;
            cboMaNhanVien.Focus();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvDanhSachTimKiem.DataSource = busNV.searchNhanVien(cboMaNhanVien.Text,cboTenNhanVien.Text, cboDonVi.Text, dtpTime.Value);
        }
    }
}
