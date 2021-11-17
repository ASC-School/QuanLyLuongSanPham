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

            }

            //txtTrangThai.Text = 
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
    }
}