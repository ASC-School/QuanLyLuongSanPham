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
    public partial class frmModel : DevExpress.XtraEditors.XtraForm
    {
        BindingSource bsModel;
        BUS_SanPham sanPhamBUS;
        DTO_Model newModel;
        
        public frmModel()
        {
            InitializeComponent();
            bsModel = new BindingSource();
            sanPhamBUS = new BUS_SanPham();
            
        }
       
        private void frmModel_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            loadDSModelToDataGridView();
        }
        private void loadDSModelToDataGridView()
        {
            bsModel.DataSource = sanPhamBUS.getDSModel();
            dgvModel.DataSource = bsModel;
            bindingNavigatorModel.BindingSource = bsModel;
            formatLuoiModel(dgvModel);
            anThongTin();
            loadCbo();
        }
        private void formatLuoiModel(DataGridView dgr)
        {
            dgr.Columns["maModel"].HeaderText = "Mã model";
            dgr.Columns["tenModel"].HeaderText = "Tên model";
            dgr.Columns["tenModel"].Width = 200;
            dgr.Columns["trangThai"].HeaderText = "Trạng Thái";
        }
        private void hienThongTin()
        {
            txtTrangThai.Enabled = true;
            cboTenModel.Enabled = true;
        }

        private void anThongTin()
        {
            txtTrangThai.Enabled = false;
            cboTenModel.Enabled = false;
            cboMaModel.Enabled = false;
        }

        private void formatTextBox()
        {
            txtTrangThai.Clear();
            cboTenModel.Text = "";
            cboMaModel.Text = "";
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DTO_Model taoModel()
        {
            DTO_Model model = new DTO_Model();
            model.MaModel = cboMaModel.Text;
            model.TenModel = cboTenModel.Text;
            if (txtTrangThai.Text.Equals("Còn sản xuất"))
                model.TrangThai = true;
            else
                model.TrangThai = false;
            return model;
        }
        private string trangThaiModel(string maModel)
        {
            List<DTO_Model> lstModel = sanPhamBUS.getDSModel();
            foreach(DTO_Model item in lstModel)
            {
                if (item.TrangThai == true)
                    return "Còn sản xuất";
            }
            return "Không còn sản xuất";
        }
        private void loadCbo()
        {
            List<DTO_Model> lstModel = sanPhamBUS.getDSModel();
            List<string> maModel = new List<string>();
            List<string> tenModel = new List<string>();
            foreach (DTO_Model item in lstModel)
            {
                maModel.Add(item.MaModel);
                tenModel.Add(item.TenModel);
            }
            cboMaModel.DataSource = maModel;
            cboTenModel.DataSource = tenModel;

        }
        private void dgvModel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dgvModel.Rows[e.RowIndex];
            cboMaModel.Text = row.Cells[0].Value.ToString();
            cboTenModel.Text = row.Cells[1].Value.ToString();
            if (row.Cells[2].Value.ToString().Equals("True"))
            {
                txtTrangThai.Text = "Còn sản xuất";
            }
            else
            {
                txtTrangThai.Text = "Không còn sản xuất";
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
                txtTrangThai.Text = trangThaiModel(cboMaModel.Text);
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
                txtTrangThai.Text = trangThaiModel(cboMaModel.Text);
            }
        }

        private void btnThemModel_Click(object sender, EventArgs e)
        {
            if (!btnThemModel.Text.Equals("Lưu"))
            {
                btnSuaModel.Enabled = false;
                btnXoaModel.Enabled = false;
                btnThemModel.Text = "Lưu";
                hienThongTin();
                formatTextBox();
                cboMaModel.Enabled = true;
            }
            else
            {
                btnThemModel.Text = "Thêm sản phảm";
                btnSuaModel.Enabled = true;
                btnXoaModel.Enabled = true;
                DialogResult hoiThem;
                hoiThem = MessageBox.Show("Bạn có muốn thêm?", "Hỏi thêm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiThem == DialogResult.Yes)
                {
                    newModel = taoModel();
                    if (sanPhamBUS.checkExistModel(newModel.MaModel))
                    {
                        MessageBox.Show("Model đã tồn tại!!");
                    }
                    else
                    {
                        sanPhamBUS.themModel(newModel);
                    }
                    formatTextBox();
                    anThongTin();
                    loadDSModelToDataGridView();
                    MessageBox.Show("Thêm thành công!");
                }
                else
                {
                    MessageBox.Show("Thêm không thành công!");
                }
            }
        }

        private void btnSuaModel_Click(object sender, EventArgs e)
        {
            if (!btnSuaModel.Text.Equals("Lưu"))
            {
                btnThemModel.Enabled = false;
                btnXoaModel.Enabled = false;
                btnSuaModel.Text = "Lưu";
                hienThongTin();
            }
            else
            {
                btnSuaModel.Text = "Sửa model";
                btnThemModel.Enabled = true;
                btnXoaModel.Enabled = true;
                DialogResult hoiThem;
                hoiThem = MessageBox.Show("Bạn có muốn sửa?", "Hỏi sửa thông tin model", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiThem == DialogResult.Yes)
                {
                    newModel = taoModel();
                    sanPhamBUS.suaThongTinModel(newModel);
                    formatTextBox();
                    anThongTin();
                    loadDSModelToDataGridView();
                    MessageBox.Show("Sửa thông tin thành công!");
                }
                else
                {
                    MessageBox.Show("Sửa thông tin không thành công!");
                }
            }
        }

        private void btnXoaModel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult hoiXoa;
                if (dgvModel.SelectedCells.Count > 0)
                {
                    hoiXoa = MessageBox.Show("Bạn có muốn xóa?", "Hỏi xóa chi tiết đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (hoiXoa == DialogResult.Yes)
                    {
                        errLoi.Clear();
                        DTO_Model model = taoModel();
                        bool tmp = sanPhamBUS.xoaModel(model.MaModel);
                        if (tmp)
                        {
                            MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadDSModelToDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Xóa thất bại!!!");
            }
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            loadDSModelToDataGridView();
        }
    }
}