﻿using DevExpress.XtraEditors;
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
using System.IO;
using System.Drawing.Imaging;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmQLNhanSu : DevExpress.XtraEditors.XtraForm
    {
        public frmQLNhanSu()
        {
            InitializeComponent();
        }


        BUS_NhanVien busNV= new BUS_NhanVien();
        private static string ImageLocation;
        BUS_LoaiNhanVien busLoaiNV = new BUS_LoaiNhanVien();
        BUS_DonViQuanLy busDonVi = new BUS_DonViQuanLy();
        string maLoaiNV;
        private void frmQLNhanSu_Load(object sender, EventArgs e)
        {
            loadDSNVtoDTGV();
            loadDataToCbo();
        }
        // Load data từ database lên datagrid view
        private void loadDSNVtoDTGV()
        {
            offTextbox();
            this.dtgvDSNV.DefaultCellStyle.ForeColor = Color.Black;
            dtgvDSNV.DataSource = busNV.getNhanVienForQLNS();
        }

        // Đưa dữ liệu từ datagird view lên textbox
        private void dtgvDSNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDSNV.Rows[e.RowIndex];
                txtMaNv.Text = row.Cells[0].Value.ToString();
                txtTenNv.Text = row.Cells[1].Value.ToString();
                if (row.Cells[2].Value.ToString().Equals("True"))
                {
                    cboGioiTinh.Text = "Nữ";
                }
                else
                    cboGioiTinh.Text = "Nam";
                txtSDT.Text = row.Cells[3].Value.ToString();
                txtDiaChi.Text = row.Cells[4].Value.ToString();
                dateTimeDayofBirth.Text = row.Cells[5].Value.ToString();
                dateTimeNgayVaoLam.Text = row.Cells[6].Value.ToString();
                cboLoaiNhanVien.Text = row.Cells[7].Value.ToString();
                txtDonViQuanLy.Text = row.Cells[8].Value.ToString();
                if (row.Cells[9].Value.ToString().Equals("True"))
                {
                    cboTrangThai.Text = "Đi làm";
                }
                else
                    cboTrangThai.Text = "Nghỉ làm";
            }
        }
        // ẩn các textbox và combo box
        private void offTextbox()
        {
            txtMaNv.Enabled = false;
            txtTenNv.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            dateTimeDayofBirth.Enabled = false;
            dateTimeNgayVaoLam.Enabled = false;
            cboLoaiNhanVien.Enabled = false;
            btnThemAvata.Enabled = false;
            cboTrangThai.Enabled = false;
        }
        // hiện các textbox và combo box
        private void onTextbox()
        {
            txtMaNv.Enabled = true;
            txtTenNv.Enabled = true;
            cboGioiTinh.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            dateTimeDayofBirth.Enabled = true;
            dateTimeNgayVaoLam.Enabled = true;
            cboLoaiNhanVien.Enabled = true;
            btnThemAvata.Enabled = true;
            cboTrangThai.Enabled = true;
        }
        // kiểm tra dữ liệu null trong textbox và combo box
        private bool kiemTraNull()
        {
            if (txtMaNv.Text.Length == 0 | txtTenNv.Text.Length == 0 | cboGioiTinh.SelectedIndex == null | txtSDT.Text.Length == 0 | txtDiaChi.Text.Length == 0 | dateTimeDayofBirth.Value == null | dateTimeNgayVaoLam.Value == null | cboLoaiNhanVien.SelectedIndex == null)
                return true;
            return false;
        }
        private void btnThemAvata_Click(object sender, EventArgs e)
        {
            try
            {
                imageLocation(ref ImageLocation, ref Avata);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Mở hộ thoại chọn ảnh từ thiết bị
        public static void imageLocation(ref string ImageLocation, ref PictureBox picture)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            dlg.Title = "Select Student Picture";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ImageLocation = dlg.FileName.ToString();
                picture.ImageLocation = ImageLocation;
            }
        }
        // Load danh sách loại nhân viên lên cbo
        public void loadDataToCbo()
        {
            IEnumerable<LoaiNhanVien> dsLoaiNV = busLoaiNV.getNhanVienForQLNS();
            cboLoaiNhanVien.Items.Clear();
            foreach(LoaiNhanVien lnv in dsLoaiNV)
            {
                cboLoaiNhanVien.Items.Add(lnv.loaiNhanVien1);
            }
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            
            IEnumerable<LoaiNhanVien> dsLoaiNV = busLoaiNV.getNhanVienForQLNS();
            IEnumerable<DonViQuanLy> dsDonVi = busDonVi.getDSDonVi();
            if (btnThemNV.Text.Equals("Thêm nhân viên"))
            {
                btnThemNV.Text = "Lưu";
                onTextbox();
            }
            else if (kiemTraNull() == true)
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                btnThemNV.Text = "Thêm nhân viên";
                offTextbox();
            }
            else
            {
                foreach(LoaiNhanVien lnv in dsLoaiNV)
                {
                    if (cboLoaiNhanVien.Text.Equals(lnv.loaiNhanVien1))
                    {
                        maLoaiNV = lnv.maLoai;
                    }
                }
                MemoryStream stream = new MemoryStream();
                DTO_NhanVien nv = new DTO_NhanVien();
                nv.MaNhanVien = txtMaNv.Text;
                nv.TenNhanVien = txtTenNv.Text;
                nv.GioiTinh = cboGioiTinh.Text;
                nv.SoDienThoai = txtSDT.Text;
                nv.NgaySinh = dateTimeDayofBirth.Value;
                nv.NgayBatDauCongTac = dateTimeNgayVaoLam.Value;
                if (cboTrangThai.SelectedIndex == 0)
                {
                    nv.TrangThai = true;
                }
                else
                    nv.TrangThai = false;
                if (Avata.Image == null)
                {
                    nv.Avatar = null;
                }
                else
                {
                    Avata.Image.Save(stream, ImageFormat.Jpeg);
                    nv.Avatar = stream.ToArray();
                }
                nv.DiaChi = txtDiaChi.Text;
                nv.MaLoai = maLoaiNV;
                if (busNV.themNhanVien(nv) == true)
                {
                    MessageBox.Show("successful!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busNV.themNhanVien(nv);
                    dtgvDSNV.DataSource = busNV.getNhanVienForQLNS();
                }
                else
                {
                    MessageBox.Show("Fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                btnThemNV.Text = "Thêm nhân viên";
                offTextbox();
            }    
            
        }
    }
}