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

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Trần Văn Sỹ, Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 13/11/2021
     */
    public partial class frmXemPhanCong : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bsPHPhanCong;
        IEnumerable<dynamic> lstPhanCong = null;
        BUS_PhanCong phanCongBUS;
        BUS_NhanVien nhanVienBUS;
        DTO_NhanVien nhanVien;
        DateTime ngayHienTai;
        public frmXemPhanCong(string maNhanVien)
        {
            InitializeComponent();
            addLuoiPhanCong(dgvLichPhanCong);
            bsPHPhanCong = new BindingSource();
            phanCongBUS = new BUS_PhanCong();
            nhanVienBUS = new BUS_NhanVien();
            nhanVien = nhanVienBUS.getMotNhanVien(maNhanVien);
        }

        private void frmXemPhanCong_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.dgvLichPhanCong.DefaultCellStyle.Font = new Font("Tahoma", 12);
            this.dgvLichPhanCong.DefaultCellStyle.ForeColor = Color.Black;

            txtMaNhanVien.Text = nhanVien.MaNhanVien;
            txtTenNhanVien.Text = nhanVien.TenNhanVien;
            txtMaNhanVien.Enabled = false;
            txtTenNhanVien.Enabled = false;
            loadCbo();
            ngayHienTai = DateTime.Today;
            try
            {
                cboThangPhanCong.SelectedIndex = (int)ngayHienTai.Month;
                if (dateNgayPhanCong.Text.Equals(""))
                {
                    lstPhanCong = phanCongBUS.layAllPhanCongTheoThangTheoCongNhan(nhanVien.MaNhanVien, ngayHienTai.Month);
                }
                else
                {
                    DateTime ngay = DateTime.Parse(dateNgayPhanCong.Text);
                    lstPhanCong = phanCongBUS.layAllPhanCongTheoNgayTheoCongNhan(nhanVien.MaNhanVien, ngay);
                }

                if (lstPhanCong != null)
                {
                    loadDSPhanCong(lstPhanCong);
                }
            }
            catch
            {

            }
          
        }

        private void loadDSPhanCong(IEnumerable<dynamic> lstPhanCong)
        {
            bsPHPhanCong.DataSource = lstPhanCong;
            dgvLichPhanCong.DataSource = bsPHPhanCong;
            bindingNavigatorPhanCong.BindingSource = bsPHPhanCong;
        }

        private void loadCbo()
        {
            List<string> thang = new List<string>();
            thang.Add("None");
            for (int i = 1; i <= 12; i++)
                thang.Add(i.ToString());
            cboThangPhanCong.DataSource = thang;
        }

        private void addLuoiPhanCong(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maPhanCong";
            dc.HeaderText = "Mã Phân Công";
            dc.Name = "maPhanCong";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maNhanVien";
            dc.HeaderText = "Mã nhân viên";
            dc.Name = "maNhanVien";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenNhanVien";
            dc.HeaderText = "Tên nhân viên";
            dc.Name = "tenNhanVien";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maCongDoan";
            dc.HeaderText = "Mã công đoạn";
            dc.Name = "maCongDoan";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenCongDoan";
            dc.HeaderText = "Tên công đoạn";
            dc.Name = "tenCongDoan";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maCa";
            dc.HeaderText = "Mã ca";
            dc.Name = "maCa";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenCa";
            dc.HeaderText = "Ca";
            dc.Name = "tenCa";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "ngayLam";
            dc.HeaderText = "Ngày làm";
            dc.Name = "ngayLam";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dateNgayPhanCong.Text.Equals(""))
                {
                    lstPhanCong = phanCongBUS.layAllPhanCongTheoThangTheoCongNhan(nhanVien.MaNhanVien, ngayHienTai.Month);
                }
                loadDSPhanCong(lstPhanCong);
            }
            catch
            {

            }
            
        }

        private void dateNgayPhanCong_EditValueChanged(object sender, EventArgs e)
        {
            cboThangPhanCong.SelectedIndex = 0;
        }

        private void cboThangPhanCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!cboThangPhanCong.Text.Equals("None"))
                {
                    int thang = Int32.Parse(cboThangPhanCong.Text);
                    lstPhanCong = phanCongBUS.layAllPhanCongTheoThangTheoCongNhan(nhanVien.MaNhanVien, thang);
                    loadDSPhanCong(lstPhanCong);
                    dateNgayPhanCong.Text = "";
                }

            }
            catch
            {

            }
           
        }
    }
}