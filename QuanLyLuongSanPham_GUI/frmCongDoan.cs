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
    public partial class frmCongDoan : DevExpress.XtraEditors.XtraForm
    {
        public frmCongDoan()
        {
            InitializeComponent();
        }
        BUS_SanPham busSanPHam = new BUS_SanPham();
        BUS_CongDoanSanXuat busCongDoan = new BUS_CongDoanSanXuat();
        private void frmCongDoan_Load(object sender, EventArgs e)
        {
            offControlInput();
            this.dtgvDSCongDoan.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvDSSanPham.DefaultCellStyle.ForeColor = Color.Black;
            loadCbo();
            toolTipOpenFrmModel.SetToolTip(btnOpenFrmSanPham, "Thêm sản phẩm mới");
            loadDataSanPham();
            dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoan();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenFrmModel_Click(object sender, EventArgs e)
        {
            frmSanPham frm = new frmSanPham();
            frm.ShowDialog();
        }

        private void loadDataSanPham()
        {
            IEnumerable<SanPham> listSP = busSanPHam.GetSanPhams();
            foreach(var item in listSP)
            {
                dtgvDSSanPham.Rows.Add(item.maSanPham, item.tenSanPham, item.giaBan);
                dtgvDSSanPham.Rows[dtgvDSSanPham.RowCount - 1].Tag = item;
            }
        }
        private void tatBtn()
        {
            if (dtgvDSCongDoan.SelectedRows.Count > 0)
            {
                btnSuaCongDoan.Enabled = true;
                btnXoaCongDoan.Enabled = true;
            }
            else
            {
                btnSuaCongDoan.Enabled = false;
                btnXoaCongDoan.Enabled = false;
            }    
        }
        private void dtgvDSCongDoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tatBtn();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDSCongDoan.Rows[e.RowIndex];
                txtMaCongDoan.Text = row.Cells[0].Value.ToString();
                txtTenCongDoan.Text = row.Cells[1].Value.ToString();
                txtDonGia.Text = row.Cells[2].Value.ToString();
                cboMaSanPham.Text = row.Cells[3].Value.ToString();
                cboTenSanPhamm.Text = row.Cells[4].Value.ToString();
            }
        }
        private void offControlInput()
        {
            txtMaCongDoan.Enabled = false;
            txtTenCongDoan.Enabled = false;
            txtDonGia.Enabled = false;
            cboMaSanPham.Enabled = false;
            cboTenSanPhamm.Enabled = false;
        }
        private void onControlInput()
        {
            txtMaCongDoan.Enabled = true;
            txtTenCongDoan.Enabled = true;
            txtDonGia.Enabled = true;
            cboMaSanPham.Enabled = true;
            cboTenSanPhamm.Enabled = true;
        }
        private void clearControlInput()
        {
            txtMaCongDoan.Text = "";
            txtTenCongDoan.Text = "";
            txtDonGia.Text = "";
            cboMaSanPham.Text = "";
            cboTenSanPhamm.Text = "";
        }
        private void loadCbo()
        {
            IEnumerable<SanPham> listSP = busSanPHam.GetSanPhams();
            foreach(var item in listSP)
            {
                cboMaSanPham.Items.Add(item.maSanPham);
                cboTenSanPhamm.Items.Add(item.tenSanPham);
            }
        }

        private void cboMaSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<SanPham> listSP = busSanPHam.GetSanPhams();
            foreach (SanPham n in listSP)
            {
                if (cboMaSanPham.Text.Equals(n.maSanPham))
                {
                    cboTenSanPhamm.Text = n.tenSanPham;
                }
            }
        }
        private void cboTenSanPhamm_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<SanPham> listSP = busSanPHam.GetSanPhams();
            foreach (SanPham n in listSP)
            {
                if (cboTenSanPhamm.Text.Equals(n.tenSanPham))
                {
                    cboMaSanPham.Text = n.maSanPham;
                }
            }
        }
        private bool kiemTraNull()
        {
            if (txtMaCongDoan.Text == "" || txtTenCongDoan.Text == "" || txtDonGia.Text == "" || cboMaSanPham.Text == "")
            {
                return true;
            }
            return false;
        }

        private void btnThemCongDoan_Click(object sender, EventArgs e)
        {
            if(btnThemCongDoan.Text.Equals("Thêm công đoạn"))
            {
                onControlInput();
                clearControlInput();
                txtMaCongDoan.Focus();
                btnThemCongDoan.Text = "Lưu";
            }
            else if (kiemTraNull() == true)
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                btnThemCongDoan.Text = "Thêm công đoạn";
                offControlInput();
            }
            else
            {
                DTO_CongDoanSanXuat cd = new DTO_CongDoanSanXuat();
                cd.SoThuTu = Convert.ToInt32(txtMaCongDoan.Text);
                cd.TenCongDoan = txtTenCongDoan.Text;
                cd.DonGia =Convert.ToInt32( txtDonGia.Text);
                cd.MaSanPham = cboMaSanPham.Text;
                if (busCongDoan.addCongDoan(cd) == true)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busCongDoan.addCongDoan(cd);
                    dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoan();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                btnThemCongDoan.Text = "Thêm công đoạn";
                offControlInput();
            }
        }

        private void btnSuaCongDoan_Click(object sender, EventArgs e)
        {
            if (btnSuaCongDoan.Text.Equals("Sửa công đoạn"))
            {
                onControlInput();
                txtMaCongDoan.Enabled = false;
                btnSuaCongDoan.Text = "Lưu";
            }
            else if (kiemTraNull() == true)
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                btnThemCongDoan.Text = "Sửa công đoạn";
                offControlInput();
            }
            else
            {
                DTO_CongDoanSanXuat cd = new DTO_CongDoanSanXuat();
                cd.SoThuTu = Convert.ToInt32(txtMaCongDoan.Text);
                cd.TenCongDoan = txtTenCongDoan.Text;
                cd.DonGia = Convert.ToInt32(txtDonGia.Text);
                cd.MaSanPham = cboMaSanPham.Text;
                if (busCongDoan.upDateCongDoan(cd) == true)
                {
                    MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busCongDoan.upDateCongDoan(cd);
                    dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoan();
                }
                else
                {
                    MessageBox.Show("Fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Close();
                }
                offControlInput();
                btnSuaCongDoan.Text = "Thêm công đoạn";
            }

        }

        private void btnXoaCongDoan_Click(object sender, EventArgs e)
        {
            DialogResult dlgAnswer;
            if (dtgvDSCongDoan.SelectedRows.Count > 0)
            {
                dlgAnswer = MessageBox.Show("Bạn có muốn xóa ???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dlgAnswer == DialogResult.Yes)
                {
                    bool cd = busCongDoan.delCongDoan(Convert.ToInt32(txtMaCongDoan.Text));
                    if (cd == true)
                    {
                        MessageBox.Show("successful!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        dtgvDSCongDoan.DataSource = busCongDoan.layDSCongDoan();
                    }
                    else
                    {
                        MessageBox.Show("fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }




        //private void loadModel()
        //{
        //    bsPHModel.DataSource = sanPhamBUS.getDSModel();
        //    dgvModel.DataSource = bsPHModel;
        //    formatLuoiModel(dgvModel);
        //}

        //private void formatLuoiModel(DataGridView dgr)
        //{
        //    dgr.Columns["maModel"].HeaderText = "Mã model";
        //    dgr.Columns["tenModel"].HeaderText = "Tên model";
        //    dgr.Columns["tenModel"].Width = 120;
        //    dgr.Columns["trangThai"].HeaderText = "Trạng Thái";
        //}


    }
}