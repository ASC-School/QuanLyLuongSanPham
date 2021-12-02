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
     * Tác giả: Đinh Quang Huy,Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 17/11/2021
     */
    public partial class frmPhat : Form
    {
        public frmPhat()
        {
            InitializeComponent();
        }
        BUS_PhatNhanVien busPhatNhanVien = new BUS_PhatNhanVien();
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        BUS_MucTienPhat busMTP = new BUS_MucTienPhat();

        Point LastPoint;
        private void FrmPhat_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            dtgvDsPhat.DefaultCellStyle.ForeColor = Color.Black;
            dtgvDsPhat.DataSource = busPhatNhanVien.layDSPhat();
            offConTrolIput();
            loadCbo();
        }

        private void FrmPhat_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmPhat_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }
        private void loadCbo()
        {
            IEnumerable<NhanVien> listNV = busNhanVien.layAllDSNV();
            IEnumerable<MucTienPhat> listMP = busMTP.layThongTinPhat();
            IEnumerable<PhatNhanVien> listP = busPhatNhanVien.layAllDS();
            foreach(var n in listNV)
            {
                cboMaNhanVien.Items.Add( n.maNhanVien);
                cboTenNhanVien.Items.Add(n.tenNhanVien);
            }
            foreach(var n in listMP)
            {
                cboMaPhat.Items.Add(n.soThuTu);
                cboMucPhat.Items.Add(n.tenKhoanPhat);
                cboTienPhat.Items.Add(n.mucTienPhat1);
            }
            foreach(var n in listP)
            {
                cboMaDonVi.Items.Add(n.maDonVi);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        private void dtgvDsPhat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvDsPhat.Rows[e.RowIndex];
                cboMaNhanVien.Text = row.Cells[0].Value.ToString();
                cboTenNhanVien.Text = row.Cells[1].Value.ToString();
                cboMaPhat.Text = row.Cells[2].Value.ToString();
                cboMucPhat.Text = row.Cells[3].Value.ToString();
                cboTienPhat.Text = row.Cells[4].Value.ToString();
                dtpNgayPhat.Text = row.Cells[5].Value.ToString();
                cboMaDonVi.Text = row.Cells[6].Value.ToString();
                txtMaPhat.Text = row.Cells[7].Value.ToString();
            }
        }
        private void onConTrolIput()
        {
            txtMaPhat.Enabled = true;
            cboMaNhanVien.Enabled = true;
            cboTenNhanVien.Enabled = true;
            cboMaPhat.Enabled = true;
            cboMucPhat.Enabled = true;
            cboMaDonVi.Enabled = true;
            dtpNgayPhat.Enabled = true;
        }
        private void offConTrolIput()
        {
            txtMaPhat.Enabled = false;
            cboMaNhanVien.Enabled = false;
            cboTenNhanVien.Enabled = false;
            cboMaPhat.Enabled = false;
            cboMucPhat.Enabled = false;
            cboMaDonVi.Enabled = false;
            dtpNgayPhat.Enabled = false;
        }
        private void clearControlInput()
        {
            txtMaPhat.Text ="";
            cboMaNhanVien.Text ="";
            cboTenNhanVien.Text ="";
            cboMaPhat.Text ="";
            cboMucPhat.Text = "";
            cboMaDonVi.Text ="";
            dtpNgayPhat.Text ="";
            cboTienPhat.Text = "";
        }
        private bool kiemTraNull()
        {
            if (txtMaPhat.Text == "" || cboMaNhanVien.Text == "" || cboMaPhat.Text == ""||cboMaDonVi.Text=="")
            {
                return true;
            }
            return false;
        }


        private void cboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> listNV = busNhanVien.layAllDSNV();
            foreach(var n in listNV)
            {
                if (cboMaNhanVien.Text.Equals(n.maNhanVien))
                    cboTenNhanVien.Text = n.tenNhanVien;
            }
        }

        private void cboTenNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<NhanVien> listNV = busNhanVien.layAllDSNV();
            foreach (var n in listNV)
            {
                if (cboTenNhanVien.Text.Equals(n.tenNhanVien))
                    cboMaNhanVien.Text = n.maNhanVien;
            }
        }

        private void cboMaPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<MucTienPhat> listMP = busMTP.layThongTinPhat();
            foreach(var n in listMP)
            {
                if (Convert.ToInt32(cboMaPhat.Text) == n.soThuTu)
                {
                    cboMucPhat.Text = n.tenKhoanPhat;
                    cboTienPhat.Text = n.mucTienPhat1.ToString();
                }
            }
        }

        private void cboMucPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<MucTienPhat> listMP = busMTP.layThongTinPhat();
            foreach (var n in listMP)
            {
                if (cboMucPhat.Text.Equals(n.tenKhoanPhat))
                {
                    cboMaPhat.Text = n.soThuTu.ToString();
                    cboTienPhat.Text = n.mucTienPhat1.ToString();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Thêm"))
            {
                onConTrolIput();
                clearControlInput();
                btnThem.Text = "Lưu";
            }
            else if (kiemTraNull()==true)
            {
                MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                btnThem.Text = "Thêm";
                offConTrolIput();
            }
            else
            {
                DTO_PhatNhanVien p = new DTO_PhatNhanVien();
                p.MaPhat = txtMaPhat.Text;
                p.MaNhanVien = cboMaNhanVien.Text;
                p.MaMucPhat = Convert.ToInt32(cboMaPhat.Text);
                p.NgayPhat = dtpNgayPhat.Value;
                p.MaDonVi = cboMaDonVi.Text;
                if (busPhatNhanVien.phatNv(p) == true)
                {
                    MessageBox.Show("Thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    busPhatNhanVien.phatNv(p);
                    dtgvDsPhat.DataSource = busPhatNhanVien.layDSPhat();
                }
                else
                {
                    MessageBox.Show("Thất bại", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dlgAnswer;
            if (dtgvDsPhat.SelectedRows.Count > 0)
            {
                dlgAnswer = MessageBox.Show("Bạn có muốn xóa ???", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if(dlgAnswer == DialogResult.Yes)
                {
                    bool p = busPhatNhanVien.xoaPhat(txtMaPhat.Text);
                    if (p == true)
                    {
                        MessageBox.Show("successful!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        dtgvDsPhat.DataSource = busPhatNhanVien.layDSPhat();
                    }
                    else
                    {
                        MessageBox.Show("fail", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Lưu"))
            {
                btnThem.Text="Thêm";
                clearControlInput();
                offConTrolIput();
            }
        }
    }
}
