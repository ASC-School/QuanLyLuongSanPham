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
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmHome : Form
    {
        /**
     * Tác giả: Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
        public frmHome()
        {
            InitializeComponent();
            //customizeMenu();
        }

        #region Properties
        public delegate void Home(string strMaNhanVien);
        public Home home;
        string maNhanVien = "";
        bool bTrangThaiDangNhap = false;
        BUS_PhanQuyen busPQNV = new BUS_PhanQuyen();
        #endregion

        #region Methods
        private void timer1_Tick(object sender, EventArgs e)
        {
            tiDateTime.Elements[0].Text = string.Format("{0:HH:mm:ss}", DateTime.Now);
            tiDateTime.Elements[1].Text = string.Format("{0:dddd}", DateTime.Now);
            tiDateTime.Elements[2].Text = string.Format("{0:MM/yyyy}", DateTime.Now);
            tiDateTime.Elements[3].Text = string.Format("{0:dd}", DateTime.Now);
        }

        private void phanQuyenNV(string strMaLoai)
        { 
            if(strMaLoai.Trim().Equals("LNV001"))
            {
                msNhanSu.Enabled = false;
                msTienLuong.Enabled = false;
                msChamCong.Enabled = false;
                msHeThong.Enabled = false;
            }   
            else if (strMaLoai.Trim().Equals("LNV002"))
            {
                msNhanSu.Enabled = false;
                msSanPham.Enabled = false;
                msDonHang.Enabled = false;
                msTienLuong.Enabled = false;
                msChamCong.Enabled = false;
                msHeThong.Enabled = false;
            }   
            else if (strMaLoai.Trim().Equals("LNV003"))
            {
                msNhanSu.Enabled = false;
                msSanPham.Enabled = false;
                msDonHang.Enabled = false;
                msHeThong.Enabled = false;
            }   
            else if (strMaLoai.Trim().Equals("LNV004"))
            {
                msSanPham.Enabled = false;
                msDonHang.Enabled = false;
                msHeThong.Enabled = false;
                msTienLuong.Enabled = false;
            }    
            else if (strMaLoai.Trim().Equals("LNV005"))
            {
                msNhanSu.Enabled = false;
                msSanPham.Enabled = false;
                msDonHang.Enabled = false;
                msTienLuong.Enabled = false;
                msChamCong.Enabled = false;
            }    
        }

        void SetStatusLogin(bool BStatus, string strHoTen, string strChucVu, string strMaLoai,string strMaNhanVien)
        {
            bTrangThaiDangNhap = BStatus;
            if (bTrangThaiDangNhap)
            {
                tiTTNV.Elements[2].Text = strHoTen;
                tiTTNV.Elements[3].Text = strChucVu;
                phanQuyenNV(strMaLoai);
            }   
            else
            {
                tiTTNV.Elements[2].Text = "";
                tiTTNV.Elements[3].Text = "";
            }
            maNhanVien = strMaNhanVien;
        }
        private void ofEntable()
        {
            msTaiKhoan.Enabled = true;
            msNhanSu.Enabled = true;
            msSanPham.Enabled = true;
            msDonHang.Enabled = true;
            msTienLuong.Enabled = true;
            msChamCong.Enabled = true;
            msTienIch.Enabled = true;
            msHeThong.Enabled = true;
        }
        #endregion

        #region Events
        private void frmHome_Load(object sender, EventArgs e)
        {
            timer1.Start();
            frmLogin fLogin = new frmLogin();
            fLogin.login = SetStatusLogin;
            fLogin.ShowDialog();
        }

        private void msTaiKhoan_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void msTienLuong_HanhChanh_Click(object sender, EventArgs e)
        {
            frmLuongNhanVienHanhChanh frmLuongHC = new frmLuongNhanVienHanhChanh();
            _ = frmLuongHC.ShowDialog();
        }

        private void msTienLuong_CongNhan_Click(object sender, EventArgs e)
        {
            frmLuongCongNhan frmLuongCN = new frmLuongCongNhan();
            _ = frmLuongCN.ShowDialog();
        }

        private void msTienLuong_Phat_Click(object sender, EventArgs e)
        {
            frmPhat fPhat = new frmPhat();
            _ = fPhat.ShowDialog();
        }

        private void msChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong fChamCong = new frmChamCong();
            _ = fChamCong.ShowDialog();
        }

        private void msTienIch_TTNV_Click(object sender, EventArgs e)
        {
            frmXemThongTin frmXemTT = new frmXemThongTin(maNhanVien);
            _ = frmXemTT.ShowDialog();
        }

        private void msSanPham_Mau_Click(object sender, EventArgs e)
        {
            frmModel fModel = new frmModel();
            _ = fModel.ShowDialog();
        }

        private void msHeThong_PhanQuyen_Click(object sender, EventArgs e)
        {
            frmPhanQuyen fPhanQuyen = new frmPhanQuyen();
            _ = fPhanQuyen.ShowDialog();
        }

        private void msDonHang_QuanLyDH_Click(object sender, EventArgs e)
        {
            frmGDQLDonHang fDonHang = new frmGDQLDonHang();
            _ = fDonHang.ShowDialog();
        }

        private void msNhanSu_QuanLyNhanSu_Click(object sender, EventArgs e)
        {
            frmQLNhanSu frmNhanSu = new frmQLNhanSu();
            _ = frmNhanSu.ShowDialog();
        }

        private void msTaiKhoan_DangXuat_Click(object sender, EventArgs e)
        {
            bTrangThaiDangNhap = false;
            ofEntable();
            SetStatusLogin(false, "", "", "","");
            frmHome_Load(sender, e);
        }

        private void tHỐNGKÊĐƠNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongKeDonHang frm = new frmThongKeDonHang();
            _ = frm.ShowDialog();
        }

        private void tÌMKIẾMĐƠNHÀNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimKiemDonHang frm = new frmTimKiemDonHang();
            _ = frm.ShowDialog();
        }

        private void msSanPham_QuanLySP_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            _ = frm.ShowDialog();
        }


        private void msNhanSu_TimKiemNhanVien_Click(object sender, EventArgs e)
        {
            frmTimKiemNhanVien frm = new frmTimKiemNhanVien();
            _ = frm.ShowDialog();
        }

        #endregion

    }
}
