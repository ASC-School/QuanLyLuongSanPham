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

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 27/12/2021
     */
    public partial class frmHoTro : DevExpress.XtraEditors.XtraForm
    {
        public frmHoTro()
        {
            InitializeComponent();
        }

        bool KiemTraTonTaiForm(string frmTenForm)
        {
            //MdiParent.MdiChildren tap cac con
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(frm))
                {
                    frm.Activate();//sang len
                    return true;
                }
            }
            return false;
        }
        private void btnTaiLieu_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTaiForm("frmPDF") == false)
            {
                frmPDF frm = new frmPDF();
                frm.Name = "frmPDF";
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void frmHoTro_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }
    }
}