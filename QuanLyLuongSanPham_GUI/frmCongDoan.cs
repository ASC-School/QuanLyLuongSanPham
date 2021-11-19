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

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmCongDoan : DevExpress.XtraEditors.XtraForm
    {
        public frmCongDoan()
        {
            InitializeComponent();
        }
        BUS_Model busModel = new BUS_Model();
        private void frmCongDoan_Load(object sender, EventArgs e)
        {
            dtgvDSModel.DataSource = busModel.layDSModel();
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