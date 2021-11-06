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
    public partial class frmGDQLDonHang : DevExpress.XtraEditors.XtraForm
    {
        public frmGDQLDonHang()
        {
            InitializeComponent();
        }


        private void frmGDQLDonHang_Load(object sender, EventArgs e)
        {
            // ẩn nút
            btnLuuDonHang.Enabled = false;
            btnHuyDonHang.Enabled = false;
            btnInDonHang.Enabled = false;

            lvwDSDonHang.LargeImageList = imgLon;
            lvwDSDonHang.SmallImageList = imgNho;

            taoTieuDeCot(lvwDSDonHang);

            
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

        private void btnDongGD_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            if(!btnThemDonHang.Text.Equals("Hủy thêm"))
            {
                btnLuuDonHang.Enabled = true;
                btnThemDonHang.Text = "Hủy thêm";
            }
            else
            {
                btnLuuDonHang.Enabled = false;
                btnThemDonHang.Text = "Thêm đơn hàng";
            }
        }

        private void radMaDonHang_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}