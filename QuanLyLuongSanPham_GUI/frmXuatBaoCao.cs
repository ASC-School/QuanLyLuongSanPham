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
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmChonDuongDan : DevExpress.XtraEditors.XtraForm
    {
        private static int pageIndex;
        private static double Total_Page;
        private static int pageSize;
        private static string LocationExcel = null;
        BUS_BaoCao baoCaoBUS;
        public frmChonDuongDan()
        {
            InitializeComponent();
            baoCaoBUS = new BUS_BaoCao();
        }

        private void btnChonDuongDan_Click(object sender, EventArgs e)
        {
            //LocationExcel = baoCaoBUS.getDuongDanExportExcel();
            lblDuongDan.Text = "=>" + LocationExcel;
        }

        private void frmChonDuongDan_Load(object sender, EventArgs e)
        {

        }
    }
}