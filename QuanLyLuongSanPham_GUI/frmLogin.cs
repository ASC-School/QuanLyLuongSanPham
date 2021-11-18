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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool bCheckViewPass = false;

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có muốn thoát ứng dụng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
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
            if(txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }      
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
            }
        }

        private void btnCheckViewPass_Click(object sender, EventArgs e)
        {
            if(bCheckViewPass == true)
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

        //private void btnCheckViewPass_Click(object sender, EventArgs e)
        //{
        //    if (checkViewPass.Checked == true)
        //    {
        //        txtPassword.UseSystemPasswordChar = false;
        //    }
        //    else
        //    {
        //        txtPassword.UseSystemPasswordChar = true;
        //    }
        //}
    }
}
