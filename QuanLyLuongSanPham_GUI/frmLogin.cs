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
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_BUS;
using System.Collections;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool bCheckViewPass = false;
        public delegate void Login(bool bTrangThai, string strHoTen, string strChucVu, string strMaLoai,string strMaNhanVien);
        public Login login;
        //public static DTO_TaiKhoan tkDangNhap_ToanCuc = null;

        BUS_TaiKhoan busTK = new BUS_TaiKhoan();
        public static TaiKhoan tkSelected = null;
        private void frmLogin_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            lblError1.Visible = false;
            lblError2.Visible = false;

            txtUsername.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;
            btnThoat.TabIndex = 3;
            txtUsername.Focus();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Util.EndAnimate(this, Util.Effect.Center, 150, 30);
                Close();
                frmHome fHome = (frmHome)Application.OpenForms["frmHome"];
                fHome.Close();
            }
        }

        Point LastPoint;
        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Ten Tai Khoan")
            {
                txtUsername.Text = "";
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Ten Tai Khoan";
                lblError1.Visible = true;
            }
            else
            {
                lblError1.Visible = false;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mat Khau")
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Mat Khau";
                lblError2.Visible = true;
            }
            else
            {
                lblError2.Visible = false;
            }
        }

        private void btnCheckViewPass_Click(object sender, EventArgs e)
        {
            if (bCheckViewPass == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                bCheckViewPass = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                bCheckViewPass = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty || txtUsername.Text == "Ten Tai Khoan")
            {
                XtraMessageBox.Show("Bạn chưa nhập tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtUsername.Focus();
            }
            else if (txtPassword.Text == string.Empty || txtPassword.Text == "Mat Khau")
            {
                XtraMessageBox.Show("Bạn chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtPassword.Focus();
            }
            else
            {
                lblError1.Visible = lblError2.Visible = false;
                IEnumerable<TaiKhoan> lstTK = busTK.loadDSTK();
                bool bCheckTK = false;
                bool bCheckMK = false;
                foreach (TaiKhoan tk in lstTK)
                {
                    if (txtUsername.Text.Equals(tk.username))
                    {
                        bCheckTK = true;
                        if (txtPassword.Text.Equals(tk.passwords))
                        {
                            bCheckMK = true;
                            tkSelected = tk;
                            break;
                        }
                    }
                }

                if (bCheckTK && bCheckMK)
                {
                    string hoTenNVLoad = "";
                    string loaiNVLoad = "";
                    string maLoai = "";
                    string maNVLoad = "";
                    IEnumerable<NhanVien> nvTheoMa = busTK.loadNVTheoMa(tkSelected.maNhanVien);
                    IEnumerable<LoaiNhanVien> loaiNVTheoMa = busTK.loadLoaiNVTheoMa(tkSelected.maNhanVien);
                    foreach (NhanVien nv in nvTheoMa)
                    {
                        maNVLoad = nv.maNhanVien;
                        hoTenNVLoad = nv.tenNhanVien;
                        foreach(LoaiNhanVien loainv in loaiNVTheoMa)
                        {
                            loaiNVLoad = loainv.loaiNhanVien1;
                            maLoai = loainv.maLoai;
                        }
                    }
                        login(true, hoTenNVLoad, loaiNVLoad, maLoai,maNVLoad);
                        this.Close();
                }
                else if (!bCheckTK)
                {
                    XtraMessageBox.Show("Sai Tài Khoản!", "Thông Báo");
                    lblError1.Visible = true;
                    txtUsername.Focus();
                }
                else if (!bCheckMK)
                {
                    XtraMessageBox.Show("Sai Mật Khẩu!", "Thông Báo");
                    lblError2.Visible = true;
                    txtPassword.Focus();
                }
            }
        }

        private void lblQuenMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmQuenMatKhau frm = new frmQuenMatKhau(txtUsername.Text);
            frm.ShowDialog();
        }
    }
}
