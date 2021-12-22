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
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_BUS;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmCaLamViec : DevExpress.XtraEditors.XtraForm
    {
        public frmCaLamViec()
        {
            InitializeComponent();
        }
        BUS_CaLamViec busCa = new BUS_CaLamViec();
        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCaLamViec_Load(object sender, EventArgs e)
        {
            loadDataToDTGV();
            this.dtgvCaLamViec.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void loadDataToDTGV()
        {
            dtgvCaLamViec.Rows.Clear();
            IEnumerable<CaLamViec> listCa = busCa.layDSCa();
            foreach (var n in listCa)
            {
                dtgvCaLamViec.Rows.Add(n.maCa, n.ca);
                dtgvCaLamViec.Rows[dtgvCaLamViec.RowCount - 1].Tag = n;
            }
        }

        private void dtgvCaLamViec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dtgvCaLamViec.Rows[e.RowIndex];
                    if (row.Cells[0].Value!= null)
                        txtMaCa.Text = row.Cells[0].Value.ToString();
                    else
                        txtMaCa.Text = null;
                    if (row.Cells[1].Value != null)
                        txtTenCa.Text = row.Cells[1].Value.ToString();
                    else
                        txtTenCa.Text = null;
                }
                catch
                {
                    txtMaCa.Text = null;
                    txtTenCa.Text = null;
                }
            }
        }
        private bool kiemTraNull()
        {
            if (txtMaCa.Text.Length == 0 || txtTenCa.Text.Length == 0)
                return true;
            else
                return false;
        }
        private void xoaConTrol()
        {
            txtMaCa.Text = null;
            txtTenCa.Text = null;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Contains("Thêm"))
            {
                btnThem.Text = "Lưu";
                xoaConTrol();
            }
            else
                if (kiemTraNull())
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                btnThem.Text = "Thêm";
            }
            else
            {
                DTO_CaLamViec ca = new DTO_CaLamViec();
                ca.MaCa = txtMaCa.Text;
                ca.Ca = txtTenCa.Text;
                if (busCa.themCa(ca))
                {
                    MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busCa.themCa(ca);
                    loadDataToDTGV();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                btnThem.Text = "Thêm";
            }
                
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlg;
            if (dtgvCaLamViec.SelectedRows.Count > 0)
            {
                dlg = MessageBox.Show("Are you sure delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dlg == DialogResult.Yes)
                {
                    bool xoa = busCa.xoaCa(txtMaCa.Text);
                    if (xoa == true)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        loadDataToDTGV();
                    }
                    else
                    {
                        MessageBox.Show("fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Contains("Sửa"))
            {
                btnSua.Text = "Lưu";
                //xoaConTrol();
            }
            else
                if (kiemTraNull())
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                btnSua.Text = "Thêm";
            }
            else
            {
                DTO_CaLamViec ca = new DTO_CaLamViec();
                ca.MaCa = txtMaCa.Text;
                ca.Ca = txtTenCa.Text;
                if (busCa.suaCa(ca))
                {
                    MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busCa.suaCa(ca);
                    loadDataToDTGV();
                }
                else
                {
                    MessageBox.Show("Thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                btnSua.Text = "Sửa";
            }
        }
    }
}