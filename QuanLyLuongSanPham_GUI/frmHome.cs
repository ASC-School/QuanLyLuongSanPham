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
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        #region Properties
        #endregion

        #region Methods
        private void timer1_Tick(object sender, EventArgs e)
        {
            titleItemDateTime.Elements[0].Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
            titleItemDateTime.Elements[1].Text = string.Format("{0:dddd}", DateTime.Now);
            titleItemDateTime.Elements[2].Text = string.Format("{0:MM/yyyy}", DateTime.Now);
            titleItemDateTime.Elements[3].Text = string.Format("{0:dd}", DateTime.Now);
        }
        #endregion

        #region Events
        private void frmHome_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void lblThoat_Click(object sender, EventArgs e)
         {
            this.Close();
         }
        private void lblDangXuat_Click(object sender, EventArgs e)
        {

        }
        private void spbMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 200)
            {
                panelMenu.Size = new Size(38, 619);
            }
            else
            {
                panelMenu.Size = new Size(200, 619);
            }
        }
        #endregion

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }
    }
}
