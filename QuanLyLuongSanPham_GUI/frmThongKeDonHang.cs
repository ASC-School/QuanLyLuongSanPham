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
    public partial class frmThongKeDonHang : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeDonHang()
        {
            InitializeComponent();
        }

        private void frmThongKeDonHang_Load(object sender, EventArgs e)
        {
            lvwThongKeDonHang.LargeImageList = imgLon;
            lvwThongKeDonHang.SmallImageList = imgNho;

            taoTieuDeCot(lvwThongKeDonHang);

        }

        public void taoTieuDeCot(ListView lvw)
        {
            lvw.Columns.Add("Mã đơn hàng", 100);
            lvw.Columns.Add("Tên khách hàng", 200);
            lvw.Columns.Add("Ngày bắt đầu", 200);
            lvw.Columns.Add("Ngày kết thúc", 200);
            lvw.Columns.Add("Tên sản phẩm", 300);
            lvw.Columns.Add("Số lượng", 100);
            lvw.Columns.Add("Đơn giá", 120);
            lvw.Columns.Add("Nội dung", 200);
            lvw.Columns.Add("Mã nhân viên", 100);
            lvw.Columns.Add("Tên nhân viên", 200);
            lvw.Columns.Add("Thành tiền", 120);

            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLocDonHang_Click(object sender, EventArgs e)
        {

        }
    }
}