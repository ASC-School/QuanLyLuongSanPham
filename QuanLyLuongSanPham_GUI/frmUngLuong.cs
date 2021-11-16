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
    public partial class frmUngLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmUngLuong()
        {
            InitializeComponent();
        }

        Point LastPoint;
        private void FrmUngLuong_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
        }

        private void FrmUngLuong_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmUngLuong_MouseMove(object sender, MouseEventArgs e)
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

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
