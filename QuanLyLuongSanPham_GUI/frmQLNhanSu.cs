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
        private void frmQLNhanSu_Load(object sender, EventArgs e)
        {
            loadDSNVtoDTGV();
            loadDataToCbo();
        }
        private void loadDSNVtoDTGV()
        {
            offTextbox();
            this.dtgvDSNV.DefaultCellStyle.ForeColor = Color.Black;
            dtgvDSNV.DataSource = busNV.getNhanVienForQLNS();
        }


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
                cboDonViQuanLy.Text = row.Cells[8].Value.ToString();
                if (row.Cells[9].Value.ToString().Equals("True"))
                {
                    cboTrangThai.Text = "Đi làm";
                }
                else
                    cboTrangThai.Text = "Nghỉ làm";
            }
        }
        private void offTextbox()
        {
            txtMaNv.Enabled = false;
            txtTenNv.Enabled = false;
            cboGioiTinh.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            dateTimeDayofBirth.Enabled = false;
            dateTimeNgayVaoLam.Enabled = false;
            cboDonViQuanLy.Enabled = false;
            cboLoaiNhanVien.Enabled = false;
            btnThemAvata.Enabled = false;
            cboTrangThai.Enabled = false;
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
        public void loadDataToCbo()
        {
            IEnumerable<LoaiNhanVien> dsLoaiNV = busLoaiNV.getNhanVienForQLNS();
            IEnumerable<DonViQuanLy> dsDonVi = busDonVi.getDSDonVi();
            cboDonViQuanLy.Items.Clear();
            cboLoaiNhanVien.Items.Clear();
            foreach(LoaiNhanVien lnv in dsLoaiNV)
            {
                cboLoaiNhanVien.Items.Add(lnv.loaiNhanVien1);
            }
            foreach(DonViQuanLy tenDonVi in dsDonVi)
            {
                cboDonViQuanLy.Items.Add(tenDonVi.tenBoPhan);
            }
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {            
            //MemoryStream stream = new MemoryStream();
            //if (Avata != null)
            //{
            //    Avata.Image.Save(stream, ImageFormat.Jpeg);
            //}
            //else
            //    stream = null;
            
            //DTO_NhanVien nv = new DTO_NhanVien();
            //nv.MaNhanVien = txtMaNv.Text;
            //nv.TenNhanVien = txtTenNv.Text;
            //nv.GioiTinh = cboGioiTinh.Text;
            //nv.SoDienThoai = txtSDT.Text;
            //nv.NgaySinh = dateTimeDayofBirth.Value;
            //nv.NgayBatDauCongTac = dateTimeNgayVaoLam.Value;
            //nv.TrangThai = true;
            //nv.Avatar =Convert.ToByte(stream.ToArray());
            //nv.DiaChi = txtDiaChi.Text;

        }
    }
}