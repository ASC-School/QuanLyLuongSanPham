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
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public partial class frmPhanQuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmPhanQuyen()
        {
            InitializeComponent();
            addLuoiDSNhanVien(dgvDSNhanVienChuaCoTaiKhoan);
            addLuoiDSTaiKhoanChuaPQ(dgvTkChuaPhanQuyen);
            addLuoiDSTaiKhoan(dgvTK);
        }

        BUS_PhanQuyen phanQuyenBUS = new BUS_PhanQuyen();
        BUS_TaiKhoan taiKhoanBUS = new BUS_TaiKhoan();
        BindingSource bsNhanVien = new BindingSource();
        BindingSource bsTaiKhoan = new BindingSource();
        BindingSource bsTaiKhoanChuaPhanQuyen = new BindingSource();
        DTO_TaiKhoan newTk = new DTO_TaiKhoan();
        private void frmPhanQuyen_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.dgvDSNhanVienChuaCoTaiKhoan.DefaultCellStyle.ForeColor = Color.Black;
            loadDSNhanVienToDataGridView();
            loadDSTaiKhoanChuaPhanQuyenToDataGridView();
            loadDSTaiKhoanToDataGridView();
            tatButton();
            loadCbo();
            cboLoaiNhanVien.Enabled = false;
        }

        private void addLuoiDSNhanVien(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
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
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "gioiTinh";
            dc.HeaderText = "Giới tính";
            dc.Name = "gioiTinh";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "loaiNhanVien";
            dc.HeaderText = "Loại nhân viên";
            dc.Name = "loaiNhanVien";
            dc.Width = 300;
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "soDienThoai";
            dc.HeaderText = "Số điện thoại";
            dc.Name = "soDienThoai";
            dc.Width = 100;
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "ngaySinh";
            dc.HeaderText = "Ngày sinh";
            dc.Name = "ngaySinh";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "ngayBatDauCongTac";
            dc.HeaderText = "Ngày bắt đàu công tác";
            dc.Name = "ngayBatDauCongTac";
            dc.Visible = true;
            dc.Width = 200;
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
            dc.DataPropertyName = "avatar";
            dc.HeaderText = "Ảnh đại diện";
            dc.Name = "avatar";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "diaChi";
            dc.HeaderText = "Địa chỉ";
            dc.Name = "diaChi";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "maLoai";
            dc.HeaderText = "Mã Loại";
            dc.Name = "maLoai";
            dc.Visible = true;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

        }

        private void tatButton()
        {
            btnDoiMatKhau.Enabled = false;
            btnPhanQuyen.Enabled = false;
           // btnSua.Enabled = false;
            btnXoaTaiKhoan.Enabled = false;
        }

        private void moButton()
        {
            btnDoiMatKhau.Enabled = true;
            btnPhanQuyen.Enabled = true;
            //btnSua.Enabled = true;
            btnXoaTaiKhoan.Enabled = true;
        }

        private void formatThongTinTaiKhoan()
        {
            txtTenTaiKhoan.Clear();
            cboMaNhanVien.Text = "";
            cboTenNhanVien.Text = "";
            cboLoaiNhanVien.Text = "";
        }

        private void formatPhanQuyen()
        {
            cboTenNhanVien.Text = "";
            cboQuyen.Text = "";
        }

        private void anThongTinTaiKhoan()
        {
            txtTenTaiKhoan.Enabled = false;
            cboMaNhanVien.Enabled = false;
            cboTenNhanVien.Enabled = false;
            cboLoaiNhanVien.Enabled = false;
        }

        private void anThongTinPhanQuyen()
        {
           
            cboTenTaiKhoan.Enabled = false;
            cboQuyen.Enabled = false;
        }

        private void hienThongTinTaiKhoan()
        {
            txtTenTaiKhoan.Enabled = true;
            cboMaNhanVien.Enabled = true;
            cboTenNhanVien.Enabled = true;
            cboLoaiNhanVien.Enabled = true;
        }

        private void loadCbo()
        {
            List<string> lstPhanQuyen = phanQuyenBUS.layTenPhanQuyen();
            cboQuyen.DataSource = lstPhanQuyen;

            List<string> lstMaNhanVien = taiKhoanBUS.maNhanVien();
            cboMaNhanVien.DataSource = lstMaNhanVien;

            List<string> lstTenNhanVien = taiKhoanBUS.tenNhanVien();
            cboTenNhanVien.DataSource = lstTenNhanVien;

        }

        private void addLuoiDSTaiKhoanChuaPQ(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenTaiKhoan";
            dc.HeaderText = "Tên tài khoản";
            dc.Name = "tenTaiKhoan";
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
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "loaiNhanVien";
            dc.HeaderText = "Loại nhân viên";
            dc.Name = "loaiNhanVien";
            dc.Visible = true;
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);
        }

        private void addLuoiDSTaiKhoan(DataGridView dgr)
        {
            DataGridViewTextBoxColumn dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "tenTaiKhoan";
            dc.HeaderText = "Tên tài khoản";
            dc.Name = "tenTaiKhoan";
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
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "loaiNhanVien";
            dc.HeaderText = "Loại nhân viên";
            dc.Name = "loaiNhanVien";
            dc.Visible = true;
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);

            dc = new DataGridViewTextBoxColumn();
            dc.DataPropertyName = "quyen";
            dc.HeaderText = "Quyền";
            dc.Name = "quyen";
            dc.Visible = true;
            dc.Width = 300;
            dc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgr.Columns.Add(dc);
        }

        private void loadDSNhanVienToDataGridView()
        {
            bsNhanVien.DataSource = taiKhoanBUS.layDSNhanVienChuaCoTaiKhoan();
            dgvDSNhanVienChuaCoTaiKhoan.DataSource = bsNhanVien;
        }

        private void loadDSTaiKhoanToDataGridView()
        {
            bsTaiKhoan.DataSource = taiKhoanBUS.layDanhSachTaiKhoan();
            dgvTK.DataSource = bsTaiKhoan;
        }

        private void loadDSTaiKhoanChuaPhanQuyenToDataGridView()
        {
            bsTaiKhoanChuaPhanQuyen.DataSource = taiKhoanBUS.layDSTaiKhoanChuaPhanQuyen();
            dgvTkChuaPhanQuyen.DataSource = bsTaiKhoanChuaPhanQuyen;
        }

        private void dgvDSNhanVienChuaCoTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //anThongTinTaiKhoan();
            //txtTenTaiKhoan.Enabled = true;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDSNhanVienChuaCoTaiKhoan.Rows[e.RowIndex];
                cboMaNhanVien.Text = row.Cells[0].Value.ToString();
                cboTenNhanVien.Text = row.Cells[1].Value.ToString();
                cboLoaiNhanVien.Text = row.Cells[3].Value.ToString();
            }
        }

        private void dgvTkChuaPhanQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //anThongTinPhanQuyen();
            moButton();
            anThongTinPhanQuyen();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvTkChuaPhanQuyen.Rows[e.RowIndex];
                cboTenTaiKhoan.Text = row.Cells[0].Value.ToString();
                cboQuyen.Text = "";
            }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            anThongTinPhanQuyen();
            moButton();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvTK.Rows[e.RowIndex];
                cboTenTaiKhoan.Text = row.Cells[0].Value.ToString();
                cboQuyen.Text = row.Cells[4].Value.ToString();
            }
        }

        private DTO_TaiKhoan taoTaiKhoan()
        {
            DTO_TaiKhoan taiKhoan = new DTO_TaiKhoan();
            taiKhoan.TenTaiKhoan = txtTenTaiKhoan.Text;
            taiKhoan.MaNhanVien = cboMaNhanVien.Text;
            taiKhoan.Quyen = null;
            taiKhoan.MatKhau = "123456";
            return taiKhoan;
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (btnTaoTaiKhoan.Text.Equals("Tạo tài khoản"))
            {
                hienThongTinTaiKhoan();
                formatThongTinTaiKhoan();
                txtTenTaiKhoan.Focus();
                btnTaoTaiKhoan.Text = "Lưu";
                tatButton();

            }
            else
            {
                DTO_TaiKhoan taiKhoan = taoTaiKhoan();
                bool ketQua = taiKhoanBUS.themTaiKhoan(taiKhoan);
                if (ketQua)
                {
                    MessageBox.Show("Thêm thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    loadDSTaiKhoanChuaPhanQuyenToDataGridView();
                    moButton();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                btnTaoTaiKhoan.Text = "Tạo tài khoản";
                formatThongTinTaiKhoan();
                loadDSNhanVienToDataGridView();
                
            }
        }

        private void btnLoadDSNhanVien_Click(object sender, EventArgs e)
        {
            loadDSNhanVienToDataGridView();
        }

        private void btnLoadDSTKChuaPhanQuen_Click(object sender, EventArgs e)
        {
            loadDSTaiKhoanChuaPhanQuyenToDataGridView();
        }

        private void btnLoadDSTK_Click(object sender, EventArgs e)
        {
            loadDSTaiKhoanToDataGridView();
        }

        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            if(!btnPhanQuyen.Text.Equals("Lưu"))
            {
                cboTenTaiKhoan.Enabled = false;
                cboQuyen.Enabled = true;
                //btnSua.Enabled = false;
                btnXoaTaiKhoan.Enabled = false;
                btnDoiMatKhau.Enabled = false;
                btnPhanQuyen.Text = "Lưu";
            }
            else
            {
                DialogResult hoiThem;
                hoiThem = MessageBox.Show("Bạn có muốn lưu?", "Phân quyền", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiThem == DialogResult.Yes)
                {
                    if (cboTenTaiKhoan.Text.Equals("") || cboQuyen.Text.Equals(""))
                    {
                        MessageBox.Show("Vui lòng nhập đày đủ thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        DTO_TaiKhoan tkPhanQuyen = taiKhoanBUS.getThongTinTaiKhoanTheoTenTaiKhoan(cboTenTaiKhoan.Text);
                        if (tkPhanQuyen != null)
                        {
                            if (!cboQuyen.Text.Equals(""))
                            {
                                tkPhanQuyen.Quyen = cboQuyen.Text.Trim();
                                bool ketQua = taiKhoanBUS.suaThongTinTaiKhoan(tkPhanQuyen);
                                if (ketQua)
                                {
                                    MessageBox.Show("Phân quyền thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                    loadDSTaiKhoanChuaPhanQuyenToDataGridView();
                                    loadDSTaiKhoanToDataGridView();
                                }
                                else
                                {
                                    MessageBox.Show("Phân quyền không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                }
                                moButton();
                                formatPhanQuyen();
                                btnPhanQuyen.Text = "Phân quyền";
                            }
                            else
                            {
                                MessageBox.Show("Bạn cần chọn quyền để phân quyền!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                btnPhanQuyen.Text = "Phân quyền";
                                moButton();
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Phân quyền không thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    moButton();
                }


            }


        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult hoiXoa;
                btnPhanQuyen.Enabled = false;
                //btnSua.Enabled = false;
                btnTaoTaiKhoan.Enabled = false;
                btnDoiMatKhau.Enabled = false;
                if (dgvTK.SelectedCells.Count > 0 || dgvTkChuaPhanQuyen.SelectedCells.Count > 0)
                {
                    hoiXoa = MessageBox.Show("Bạn có muốn xóa?", "Hỏi xóa chi tiết đơn hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (hoiXoa == DialogResult.Yes)
                    {
                        if(cboTenTaiKhoan.Text.Equals(""))
                        {
                            MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                        }
                        else
                        {
                            bool tmp = taiKhoanBUS.xoaTaiKhoan(cboTenTaiKhoan.Text);
                            if (tmp)
                            {
                                MessageBox.Show("Xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadDSTaiKhoanToDataGridView();
                                loadDSTaiKhoanChuaPhanQuyenToDataGridView();
                                moButton();
                                formatPhanQuyen();
                            }
                            else
                            {
                                MessageBox.Show("Xóa không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                moButton();
                                formatPhanQuyen();

                            }
                        }
                        
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!");
                moButton();
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(cboTenTaiKhoan.Text);
            _ = frm.ShowDialog();
        }

        //private void btnSua_Click(object sender, EventArgs e)
        //{
        //    if (!btnSua.Text.Equals("Lưu"))
        //    {
        //        btnPhanQuyen.Enabled = false;
        //        btnDoiMatKhau.Enabled = false;
        //        btnXoaTaiKhoan.Enabled = false;
        //        btnTaoTaiKhoan.Enabled = false;
        //        btnSua.Text = "Lưu";
        //        cboQuyen.Enabled = true;
        //    }
        //    else
        //    {
        //        btnSua.Text = "Sửa";
        //        DialogResult hoiThem;
        //        hoiThem = MessageBox.Show("Bạn có muốn sửa?", "Hỏi sửa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        //        if (hoiThem == DialogResult.Yes)
        //        {
        //            if (!cboTenTaiKhoan.Text.Equals("") && !cboQuyen.Text.Equals("")) // tai khoan chua phan quyen
        //            {
        //                DTO_TaiKhoan tk = taiKhoanBUS.getThongTinTaiKhoanTheoTenTaiKhoan(cboTenTaiKhoan.Text);
        //                tk.Quyen = cboQuyen.Text;
        //                bool ketQua = taiKhoanBUS.suaThongTinTaiKhoan(tk);
        //                if (ketQua)
        //                {
        //                    formatPhanQuyen();
        //                    anThongTinPhanQuyen();
        //                    loadDSTaiKhoanChuaPhanQuyenToDataGridView();
        //                    loadDSTaiKhoanToDataGridView();
        //                    MessageBox.Show("Sửa thông tin thành công!");
        //                    moButton();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("Sửa thông tin không thành công!");
        //                    moButton();
        //                }

        //            }
        //            else if (cboTenTaiKhoan.Text.Equals("") && !cboQuyen.Text.Equals(""))
        //            {
        //                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
        //                moButton();
        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("Sửa thông tin không thành công!");
        //            moButton();
        //        }


        //    }
        //}
    }
}