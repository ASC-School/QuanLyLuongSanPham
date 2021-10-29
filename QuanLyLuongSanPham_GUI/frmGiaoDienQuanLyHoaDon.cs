using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmGiaoDienQuanLyHoaDon : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmGiaoDienQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void frmGiaoDienQuanLyHoaDon_Load(object sender, EventArgs e)
        {

        }

        bool kiemTraTonTaiForm(string frmTenForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(frm))
                {
                    frm.Activate();
                    return true;
                }
            }
            return false;
        }
        private void btnQuanLyDonhang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (kiemTraTonTaiForm("frmGDQLDonHang") == false)
            {
                frmGDQLDonHang frm = new frmGDQLDonHang();
                frm.Name = "frmGDQLDonHang";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void btnThongKeDonHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (kiemTraTonTaiForm("frmThongKeDonHang") == false)
            {
                frmThongKeDonHang frm = new frmThongKeDonHang();
                frm.Name = "frmThongKeDonHang";
                frm.MdiParent = this;
                frm.Show();
            }
        }
    }
}