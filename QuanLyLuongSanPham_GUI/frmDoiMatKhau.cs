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
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        DTO_TaiKhoan taiKhoanDTO;
        BUS_TaiKhoan taiKhoanBUS;
        public frmDoiMatKhau(string username)
        {
            InitializeComponent();
            taiKhoanBUS = new BUS_TaiKhoan();
            taiKhoanDTO = taiKhoanBUS.getThongTinTaiKhoanTheoTenTaiKhoan(username);
            lblTaiKhoan.Text = taiKhoanDTO.TenTaiKhoan;
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            lblTaiKhoan.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bạn có muốn thoát?", "Hỏi thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialog == DialogResult.Yes)
                this.Close();
        }

        private bool checkThongTin()
        {
            if(txtMKMoi.Text.Equals("") || txtNhapLaiMKMoi.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!");
                return false;
            }
            else
            {
                if(!txtMKMoi.Text.Equals(txtNhapLaiMKMoi.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khảu trùng khớp với nhau!!");
                    return false;
                }
                return true;
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if(checkThongTin())
                {
                    taiKhoanDTO.MatKhau = txtMKMoi.Text;
                    bool doiMK = taiKhoanBUS.suaThongTinTaiKhoan(taiKhoanDTO);
                    if(doiMK)
                    {
                       
                        MessageBox.Show("Đổi mật khẩu thành công!!");
                        this.Hide();
                        frmLogin frm = new frmLogin();
                        frm.ShowDialog();
                        this.Close();
                    }    
                    else
                        MessageBox.Show("Đổi mật khẩu không thành công!!");
                }    
            }
            catch
            {
                MessageBox.Show("Có lỗi!!");
            }
        }
    }
}