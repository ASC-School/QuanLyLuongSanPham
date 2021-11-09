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
namespace QuanLyLuongSanPham_GUI
{
    public partial class frmQLNhanSu : DevExpress.XtraEditors.XtraForm
    {
        public frmQLNhanSu()
        {
            InitializeComponent();
        }
        BUS_NhanVien busNV= new BUS_NhanVien();



        private void frmQLNhanSu_Load(object sender, EventArgs e)
        {
            loadDSNVtoDTGV();
        }
        private void loadDSNVtoDTGV()
        {
            this.dtgvDSNV.DefaultCellStyle.ForeColor = Color.Black;
            dtgvDSNV.DataSource = busNV.getNhanVienForQLNS();
        }
    }
}