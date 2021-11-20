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
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmLuongCongNhan : DevExpress.XtraEditors.XtraForm
    {
        public frmLuongCongNhan()
        {
            InitializeComponent();
        }

        BUS_LuongCongNhan busLuongCongNhan = new BUS_LuongCongNhan();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point LastPoint;
        private void FrmLuongCongNhan_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            anTextBox();
            loadLuongCongNhan();
        }

        private void loadLuongCongNhan()
        {
            this.dtgvLuongCongNhan.DefaultCellStyle.ForeColor = Color.Black;
            dtgvLuongCongNhan.DataSource = busLuongCongNhan.loadLuongCN();
        }

        private void FrmLuongCongNhan_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmLuongCongNhan_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void dtgvLuongCongNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvLuongCongNhan.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtDonVi.Text = row.Cells[2].Value.ToString();
                txtCongDoan.Text = row.Cells[3].Value.ToString();
                txtSLSPLamDuoc.Text = row.Cells[4].Value.ToString();
                txtTienPhat.Text = row.Cells[5].Value.ToString();
                txtThue.Text = row.Cells[6].Value.ToString();
                txtTongLuongTT.Text = row.Cells[7].Value.ToString();
                txtTamUng.Text = row.Cells[8].Value.ToString();
                txtThucNhan.Text = row.Cells[9].Value.ToString();
            }
        }

        private void anTextBox()
        {
            txtMaNV.Enabled = false;
            txtHoTen.Enabled = false;
            txtDonVi.Enabled = false;
            txtCongDoan.Enabled = false;
            txtSLSPLamDuoc.Enabled = false;
            txtTienPhat.Enabled = false;
            txtThue.Enabled = false;
            txtTongLuongTT.Enabled = false;
            txtTamUng.Enabled = false;
        }
    }
}
