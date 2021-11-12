﻿using System;
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
            customizeMenu();
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

        

        private void customizeMenu()
        {
            //panelMenu.Visible = false;
            panelcapNhatSubmenu.Visible = false;
            panelHeThongSubmenu.Visible = false;
            panelDanhMucSubmenu.Visible = false;
            panelTraCuSubmenu.Visible = false;
            panelXuLySubmenu.Visible = false;
            pabelThongKeSubmenu.Visible = false;

        }

        private void hideSubmenu()
        {
            if (panelcapNhatSubmenu.Visible == true)
                panelcapNhatSubmenu.Visible = false;
            if (panelHeThongSubmenu.Visible == true)
                panelHeThongSubmenu.Visible = false;
            if (panelDanhMucSubmenu.Visible == true)
                panelDanhMucSubmenu.Visible = false;
            if (panelTraCuSubmenu.Visible == true)
                panelTraCuSubmenu.Visible = false;
            if (panelXuLySubmenu.Visible == true)
                panelXuLySubmenu.Visible = false;
            if (pabelThongKeSubmenu.Visible == true)
                pabelThongKeSubmenu.Visible = false;
        }

        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubmenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {

        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            showSubMenu(panelHeThongSubmenu);
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            frmGiaoDienPhanQuyen giaoDienPhanQuyen = new frmGiaoDienPhanQuyen();
            giaoDienPhanQuyen.ShowDialog();
            hideSubmenu();
        }

        private void btnDanhMuc_Click(object sender, EventArgs e)
        {
            showSubMenu(panelDanhMucSubmenu);
        }

     

        private void btnDanhMuc_DonViQuanLy_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnDanhMuc_CaLamViec_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnDanhMuc_CongDoan_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnDanhMuc_XemThongTin_Click(object sender, EventArgs e)
        {
            frmXemThongTin frm = new frmXemThongTin();
            frm.ShowDialog();
            hideSubmenu();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            showSubMenu(panelcapNhatSubmenu);
        }

        private void btnCapNhat_DonHang_Click(object sender, EventArgs e)
        {
            frmGDQLDonHang frm = new frmGDQLDonHang();
            frm.ShowDialog();
            hideSubmenu();
        }

        private void btnCapNhat_DonViQuanLy_Click(object sender, EventArgs e)
        {

            hideSubmenu();
        }

        private void btn_CapNhatNhanVien_Click(object sender, EventArgs e)
        {
            frmQLNhanSu frm = new frmQLNhanSu();
            frm.ShowDialog();
            hideSubmenu();
        }

       
        private void btnCapNhat_LuongNhanVien_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            showSubMenu(panelXuLySubmenu);
        }

        private void btnXuLy_TinhLuongNVHanhChanh_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnXuLy_TinhLuongCongNhan_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnXuLy_ChamCongNVHangChanh_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnXuLy_ChamCongCongNhan_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTraCuSubmenu);
        }

        private void btnTraCuu_NhanVien_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnTraCuu_DonHang_Click(object sender, EventArgs e)
        {
            frmTimKiemDonHang frm = new frmTimKiemDonHang();
            frm.ShowDialog();
            hideSubmenu();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(pabelThongKeSubmenu);
        }

        private void btnThongKe_NhanVien_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnThongKe_DonHang_Click(object sender, EventArgs e)
        {
            frmThongKeDonHang frm = new frmThongKeDonHang();
            frm.ShowDialog();
            hideSubmenu();
        }

        private void btnThongKe_LuongNhanVien_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }

        private void btnDanhMuc_SanPham_Click(object sender, EventArgs e)
        {
            hideSubmenu();
        }
    }
}