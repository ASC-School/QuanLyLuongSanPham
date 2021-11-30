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
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        BUS_SanPham sanPhamBUS;
        BindingSource bsPHSanPham;
        BindingSource bsPHModel;
        DTO_SanPham newSanPham;
        DTO_ChiTietModel newChiTiet;
        public frmSanPham()
        {
            InitializeComponent();
            sanPhamBUS = new BUS_SanPham();
            bsPHSanPham = new BindingSource();
            bsPHModel = new BindingSource();
            addLuoiSanPham(dgvSanPham);
            addLuoiModel(dgvModel);
        }
       
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            btnSuaSanPham.Enabled = false;
            btnXoaSanPham.Enabled = false;
            btnLuuSanPham.Enabled = false;
           
            loadChiTietSanPham();
            loadModel();
            loadCbo();
            toolTipOpenFrmModel.SetToolTip(btnOpenFrmModel, "Thêm model mới");
        }

        private void loadChiTietSanPham()
        {
            bsPHSanPham.DataSource = sanPhamBUS.getAllChiTietSanPham();
            dgvSanPham.DataSource = bsPHSanPham;
            bindingNavigatorSanPham.BindingSource = bsPHSanPham;
        }


        private void addLuoiSanPham(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maSanPham";
            dc.HeaderText = "Mã sản phẩm";
            dc.Name = "maSanPaham";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenSanPham";
            dc.HeaderText = "Tên sản phẩm";
            dc.Name = "tenSanPham";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "namSanXuat";
            dc.HeaderText = "Năm sản phẩm";
            dc.Name = "namSanPham";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "trangThai";
            dc.HeaderText = "Trạng thái";
            dc.Name = "trangThai";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "giaBan";
            dc.HeaderText = "Giá đơn hàng";
            dc.Name = "giaBan";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "thongSoKyThuat";
            dc.HeaderText = "Thông số kỹ thuật";
            dc.Name = "thongSoKyThuat";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "moTa";
            dc.HeaderText = "Mô tả";
            dc.Name = "moTa";
            dc.Visible = true;
            
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maModel";
            dc.HeaderText = "Mã model";
            dc.Name = "maModel";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenModel";
            dc.HeaderText = "Tên model";
            dc.Name = "tenModel";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

        }

        private void addLuoiModel(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maModel";
            dc.HeaderText = "Mã model";
            dc.Name = "maModel";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenModel";
            dc.HeaderText = "Tên model";
            dc.Name = "tenModel";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "trangThai";
            dc.HeaderText = "Trạng thái";
            dc.Name = "trangThai";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);
        }
        private void loadModel()
        {
            bsPHModel.DataSource = sanPhamBUS.getDSModel();
            dgvModel.DataSource = bsPHModel;
        }


        private void hienThongTin()
        {
            txtTenSanPham.Enabled = true;
            txtNamSanXuat.Enabled = true;
            txtGiaBan.Enabled = true;
            txtTrangThai.Enabled = true;
            cboTenModel.Enabled = true;
            txtThongSoKyThuat.Enabled = true;
            txtMoTa.Enabled = true;
        }

        private void anThongTin()
        {
            txtMaSanPham.Enabled = false;
            txtTenSanPham.Enabled = false;
            txtNamSanXuat.Enabled = false;
            txtGiaBan.Enabled = false;
            txtTrangThai.Enabled = false;
            cboMaModel.Enabled = false;
            cboTenModel.Enabled = false;
            txtThongSoKyThuat.Enabled = false;
            txtMoTa.Enabled = false;
        }

        public void formatTextBox()
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtNamSanXuat.Clear();
            txtGiaBan.Clear();
            txtTrangThai.Clear();
            cboMaModel.Text = "";
            cboTenModel.Text = "";
            txtThongSoKyThuat.Clear();
            txtMoTa.Clear();
        }

        private void loadCbo()
        {
            List<DTO_Model> lstModel = sanPhamBUS.getDSModel();
            List<string> maModel = new List<string>();
            List<string> tenModel = new List<string>();
            foreach(DTO_Model item in lstModel)
            {
                maModel.Add(item.MaModel);
                tenModel.Add(item.TenModel);
            }
            cboMaModel.DataSource = maModel;
            cboTenModel.DataSource = tenModel;

        }

        private DTO_SanPham taoSanPham()
        {
            DTO_SanPham sanPham = new DTO_SanPham();
            sanPham.MaSanPham = txtMaSanPham.Text;
            sanPham.TenSanPham = txtTenSanPham.Text;
            sanPham.NamSanXuat = Int32.Parse(txtNamSanXuat.Text);
            if (txtTrangThai.Text.Equals("Còn sản xuất"))
                sanPham.TrangThai = true;
            else
                sanPham.TrangThai = false;
            sanPham.GiaBan = decimal.Parse(txtGiaBan.Text);
            return sanPham;
        }

        private DTO_ChiTietModel taoChiTietModel()
        {
            DTO_ChiTietModel chiTiet = new DTO_ChiTietModel();
            chiTiet.MaModel = cboMaModel.Text;
            chiTiet.MaSanPham = txtMaSanPham.Text;
            chiTiet.ThongSoKyThuat = txtThongSoKyThuat.Text;
            chiTiet.MoTa = txtMoTa.Text;
            return chiTiet;
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemSanPham.Enabled = true;
            btnSuaSanPham.Enabled = true;
            btnXoaSanPham.Enabled = true;
            anThongTin();
            DataGridViewRow row = this.dgvSanPham.Rows[e.RowIndex];
            txtMaSanPham.Text = row.Cells[0].Value.ToString();
            txtTenSanPham.Text = row.Cells[1].Value.ToString();
            txtNamSanXuat.Text = row.Cells[2].Value.ToString();
            if (row.Cells[3].Value.ToString().Equals("True"))
                txtTrangThai.Text = "Còn sản xuất";
            else
                txtTrangThai.Text = "Không còn sản xuất";
            txtGiaBan.Text = row.Cells[4].Value.ToString();

            txtThongSoKyThuat.Text = row.Cells[5].Value.ToString();
            txtMoTa.Text = row.Cells[6].Value.ToString();
            cboMaModel.Text = row.Cells[7].Value.ToString();
            cboTenModel.Text = row.Cells[8].Value.ToString();
        }

        private void dgvModel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvModel.Rows[e.RowIndex];
            cboMaModel.Text = row.Cells[0].Value.ToString();
            cboTenModel.Text = row.Cells[1].Value.ToString();
        }

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            if (!btnThemSanPham.Text.Equals("Hủy thêm"))
            {
                btnLuuSanPham.Enabled = true;
                btnXoaSanPham.Enabled = false;
                btnSuaSanPham.Enabled = false;
                btnThemSanPham.Text = "Hủy thêm";
                formatTextBox();
                hienThongTin();
                txtMaSanPham.Enabled = true;
                cboMaModel.Enabled = true;
            }
            else
            {
                btnLuuSanPham.Enabled = false;
                btnThemSanPham.Text = "Thêm sản phảm";
                newSanPham = null;
                anThongTin();
            }
        }

        private void btnSuaSanPham_Click(object sender, EventArgs e)
        {
            if (!btnSuaSanPham.Text.Equals("Hủy sửa"))
            {
                btnThemSanPham.Enabled = false;
                btnLuuSanPham.Enabled = true;
                btnXoaSanPham.Enabled = false;
                btnSuaSanPham.Text = "Hủy sửa";
                hienThongTin();
                cboMaModel.Enabled = true;
            }
            else
            {
                btnLuuSanPham.Enabled = false;
                btnSuaSanPham.Text = "Sửa sản phảm";
                anThongTin();
            }
        }

        private void cboMaModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaModel.SelectedIndex == -1)
                return;
            else
            {
                if (cboTenModel.DataSource == null)
                    return;
                cboTenModel.SelectedIndex = cboMaModel.SelectedIndex;
              
            }
        }

        private void cboTenModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTenModel.SelectedIndex == -1)
                return;
            else
            {
                if (cboMaModel.DataSource == null)
                    return;
                cboMaModel.SelectedIndex = cboTenModel.SelectedIndex;
            }
        }

        private void btnLuuSanPham_Click(object sender, EventArgs e)
        {
            if (btnThemSanPham.Text.Equals("Hủy thêm"))
            {
                DialogResult hoiThem;
                hoiThem = MessageBox.Show("Bạn có muốn thêm?", "Hỏi thêm sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiThem == DialogResult.Yes)
                {
                    newSanPham = taoSanPham();
                    newChiTiet = taoChiTietModel();
                    if (newSanPham == null) MessageBox.Show("San pham bij null");
                    sanPhamBUS.themSanPham(newSanPham,newChiTiet);
                    formatTextBox();
                    btnLuuSanPham.Enabled = false;
                    btnThemSanPham.Text = "Thêm sản phảm";
                    newSanPham = null;
                    newChiTiet = null;
                    anThongTin();
                    loadChiTietSanPham();
                }
                else 
                {
                    MessageBox.Show("Thêm sản phẩm không thành công!!");
                }
            }
            else
                if (btnSuaSanPham.Text.Equals("Hủy sửa"))
            {
                newSanPham = taoSanPham();
                newChiTiet = taoChiTietModel();
                DialogResult hoiSua;
                hoiSua = MessageBox.Show("Bạn có muốn sửa thông tin?", "Hỏi sửa thông tin sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiSua == DialogResult.Yes)
                {
                    sanPhamBUS.suaSanPham(newSanPham,newChiTiet);
                    formatTextBox();
                    newSanPham = null;
                    btnLuuSanPham.Enabled = false;
                    btnSuaSanPham.Text = "Sửa sản phảm";
                    anThongTin();
                    loadChiTietSanPham();
                }
            }
        }


        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            loadModel();
        }

        private void btnLoadDSSanPham_Click(object sender, EventArgs e)
        {
            btnLuuSanPham.Enabled = false;
            btnSuaSanPham.Enabled = false;
            btnXoaSanPham.Enabled = false;
            loadChiTietSanPham();

        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoiXoa;
                if(dgvSanPham.SelectedCells.Count > 0)
                {
                    hoiXoa = MessageBox.Show("Bạn có muốn xóa?", "Hỏi xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if(hoiXoa == DialogResult.Yes)
                    {
                        errorLoi.Clear();
                        bool sanPham = sanPhamBUS.xoaSanPham(txtMaSanPham.Text);
                        if(sanPham)
                        {
                            MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadChiTietSanPham();
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }    
                    }    
                }    

            }catch(Exception)
            {
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnOpenFrmModel_Click(object sender, EventArgs e)
        {
            frmModel frm = new frmModel();
            frm.ShowDialog();
        }
    }
}