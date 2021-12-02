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
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;
namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 17/11/2021
     */
    public partial class frmDonViQuanLy : DevExpress.XtraEditors.XtraForm
    {
        public frmDonViQuanLy()
        {
            InitializeComponent();
        }
        string tt;
        BUS_LoaiNhanVien busLNV = new BUS_LoaiNhanVien();
        BUS_DonViQuanLy busDVQL = new BUS_DonViQuanLy();
        private void frmDonViQuanLy_Load(object sender, EventArgs e)
        {
            this.dtgvLoaiNhanVien.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvDonVi.DefaultCellStyle.ForeColor = Color.Black;
            loadData();
        }
        private void loadData()
        {
            dtgvDonVi.Rows.Clear();
            IEnumerable<LoaiNhanVien> listLNV = busLNV.getNhanVienForQLNS();
            IEnumerable<DonViQuanLy> listDOnVi = busDVQL.getDSDonVi();
            foreach (var item in listLNV)
            {
                if (item.trangThai == true)
                    tt = "Hoạt động";
                else
                    tt = "Không hoạt động";
                dtgvLoaiNhanVien.Rows.Add(item.maLoai, item.loaiNhanVien1,tt);            
            }
            foreach(var item in listDOnVi)
            {
                dtgvDonVi.Rows.Add(item.maDonVi, item.tenBoPhan, item.soLuongNhanVien.ToString(), item.maLoai);
            }                
        }

        private void dtgvDonVi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                DataGridViewRow row = this.dtgvDonVi.Rows[e.RowIndex];
                txtDonVi.Text = row.Cells[0].Value.ToString();
                txtTenBoPhan.Text = row.Cells[1].Value.ToString();
                txtSoLuong.Text = row.Cells[2].Value.ToString();
                cboMaLoai.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnThemCongDoan_Click(object sender, EventArgs e)
        {
            QuanLyLuongSanPham_DTO.DTO_DonViQuanLy dv = new DTO_DonViQuanLy();
            dv.MaDonVi = txtDonVi.Text;
            dv.TenBoPhan = txtTenBoPhan.Text;
            dv.SoLuongNhanVien = Convert.ToInt32(txtSoLuong.Text);
            dv.MaLoaiNhanVien = cboMaLoai.Text;
            if (busDVQL.themDonVi(dv) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                busDVQL.themDonVi(dv);
                loadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnSuaCongDoan_Click(object sender, EventArgs e)
        {
            DTO_DonViQuanLy dv = new DTO_DonViQuanLy();
            dv.MaDonVi = txtDonVi.Text;
            dv.TenBoPhan = txtTenBoPhan.Text;
            dv.SoLuongNhanVien = Convert.ToInt32(txtSoLuong.Text);
            dv.MaLoaiNhanVien = cboMaLoai.Text;
            if (busDVQL.suaDonVi(dv) == true)
            {
                MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                busDVQL.suaDonVi(dv);
                loadData();
            }
            else
            {
                MessageBox.Show("Thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            
        }

        private void btnXoaCongDoan_Click(object sender, EventArgs e)
        {
            DialogResult dlgAnswer;
            if (dtgvDonVi.SelectedRows.Count > 0)
            {
                dlgAnswer = MessageBox.Show("Bạn có muốn xóa ???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dlgAnswer == DialogResult.Yes)
                {
                    bool cd = busDVQL.xoaDonVi(txtDonVi.Text);
                    if (cd == true)
                    {
                        MessageBox.Show("successful!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}