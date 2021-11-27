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
using QuanLyLuongSanPham_DAO;
using DevExpress.XtraEditors.Mask;
using System.Data.OleDb;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmLuongCongNhan : DevExpress.XtraEditors.XtraForm
    {
        public frmLuongCongNhan()
        {
            InitializeComponent();
        }

        BUS_LuongCongNhan busLuongCongNhan = new BUS_LuongCongNhan();
        BUS_DonViQuanLy busDVQL = new BUS_DonViQuanLy();
        BUS_NhanVien busNV = new BUS_NhanVien();

        bool bCheckNVTimKiem = false;
        private void button1_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        Point LastPoint;
        private void FrmLuongCongNhan_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            anTextBox();
            loadCBBThangNam();
            loadLuongCongNhan();
        }


         void loadNVTimKiem(bool bCheck, string maNVTK, string strThang, string strNam)
        {
            bCheckNVTimKiem = bCheck;
            if(bCheckNVTimKiem)
            {
                dtgvLuongCongNhan.DataSource = busLuongCongNhan.layNVTheoTimKiem(maNVTK);
                this.dtgvLuongCongNhan.SelectionMode = DataGridViewSelectionMode.CellSelect;
                ccbThang.Text = strThang;
                ccbNam.Text = strNam;
            }    
        }
        private void loadCBBThangNam()
        {
            for(int i = 1; i <= 12; i++)
            {
                _ = ccbThang.Items.Add(i);
            }
            ccbNam.Items.Add(2021);
            ccbNam.Items.Add(2022);
        }

        private void loadLuongCongNhan()
        {
            btnHuy.Enabled = false;
            this.dtgvLuongCongNhan.DefaultCellStyle.ForeColor = Color.Black;
            dtgvLuongCongNhan.DataSource = busLuongCongNhan.loadLuongCN();
        }

        private void FrmLuongCongNhan_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmLuongCongNhan_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void dtgvLuongCongNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvLuongCongNhan.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtDonVi.Text = row.Cells[2].Value.ToString();
                txtCongDoan.Text = row.Cells[3].Value.ToString();
                txtSLSPLamDuoc.Text = row.Cells[4].Value.ToString();
                txtPhuCap.Text = row.Cells[5].Value.ToString();
                txtTienPhat.Text = row.Cells[6].Value.ToString();
                txtThue.Text = row.Cells[7].Value.ToString();
                txtTongLuongTT.Text = row.Cells[8].Value.ToString();
                txtTamUng.Text = row.Cells[9].Value.ToString();
                txtThucNhan.Text = row.Cells[10].Value.ToString();
            }
        }

        private void anTextBox()
        {
            txtMaNV.Enabled = false;
            txtHoTen.Enabled = false;   
            txtCongDoan.Enabled = false;
            txtDonVi.Enabled = false;
            txtPhuCap.Enabled = false;
            txtSLSPLamDuoc.Enabled = false;
            txtTienPhat.Enabled = false;
            txtThue.Enabled = false;
            txtTongLuongTT.Enabled = false;
            txtTamUng.Enabled = false;
        }

        private void moTextBox()
        { 
            txtSLSPLamDuoc.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            moTextBox();
            if(btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnHuy.Enabled = true;
            }   
            else if(btnSua.Text =="Lưu")
            {
                if(txtSLSPLamDuoc.Text == "")
                {
                    MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }    
                else
                {
                    DTO_LuongCongNhan dto_LCN = new DTO_LuongCongNhan();
                    dto_LCN.MaNhanVien = txtMaNV.Text;
                    dto_LCN.SoLuongSanPhamLamDuoc = Convert.ToInt32(txtSLSPLamDuoc.Text);
                    if (busLuongCongNhan.suaThongTin(dto_LCN) == true)
                    {
                        busLuongCongNhan.suaThongTin(dto_LCN);
                        MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if(dtgvLuongCongNhan.Rows.Count == 1)
                        {
                            string strMaNV = txtMaNV.Text.Trim();
                            dtgvLuongCongNhan.DataSource = busNV.serchNhanVienLuong(strMaNV, "dataSearchOne", "dataSearchSecond");
                        }   
                        else
                        {
                            dtgvLuongCongNhan.DataSource = busLuongCongNhan.loadLuongCN();
                        }    
                        btnSua.Text = "Sửa";
                        txtSLSPLamDuoc.Enabled = false;
                        btnHuy.Enabled = false;
                    }
                }    
            }    
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnSua.Text = "Sửa";
            txtSLSPLamDuoc.Enabled = false;
        }

        private void ccbThang_TextChanged(object sender, EventArgs e)
        {
            int iMonth = Convert.ToInt32(ccbThang.Text);
            int iYear = Convert.ToInt32(ccbNam.Text);
            this.dtgvLuongCongNhan.DefaultCellStyle.ForeColor = Color.Black;
            dtgvLuongCongNhan.DataSource = busLuongCongNhan.luongCNTheoThang(iMonth, iYear);         
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimKiemLuongTheoLoai fTimKiemNV = new frmTimKiemLuongTheoLoai();
                fTimKiemNV.nvTimKiemLuongCN = loadNVTimKiem;
                fTimKiemNV.ShowDialog();
            }
            catch (Exception) {}
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            dtgvLuongCongNhan.DataSource = busLuongCongNhan.loadLuongCN();
        }
        private void btnChiTietLuong_Click(object sender, EventArgs e)
        {
            frmPhieuLuongCongNhan fPhieuLuong = new frmPhieuLuongCongNhan();
            fPhieuLuong.phieuLuongCN(txtMaNV.Text, txtHoTen.Text, txtDonVi.Text, txtCongDoan.Text, txtSLSPLamDuoc.Text, txtPhuCap.Text, txtTienPhat.Text, txtTamUng.Text,txtThue.Text, ccbThang.Text, ccbNam.Text);
            fPhieuLuong.ShowDialog();
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            //{
            //    string path = "";
            //    List<string> listSheet = new List<string>();
            //    //string namefile;
            //    OpenFileDialog dlg = new OpenFileDialog();
            //    dlg.Filter = "Excel Files (.xls*)|*.xls*|All Files (*.*)|*.*";
            //    dlg.Multiselect = false;

            //    DialogResult dlgResult = dlg.ShowDialog();
            //    if (dlgResult == DialogResult.OK)
            //    {
            //        txtFilePath.Text = dlg.FileName;
            //        if (txtFilePath.Text.Equals(""))
            //        {
            //            lblMsg.Text = "Please Load File First!!!";
            //            return;
            //        }
            //        if (!File.Exists(txtFilePath.Text))
            //        {
            //            lblMsg.Text = "Can not Open File!!!";
            //            return;
            //        }
            //        String filePath = txtFilePath.Text;
            //        string excelcon;
            //        if (filePath.Substring(filePath.LastIndexOf('.')).ToLower() == ".xlsx")
            //        {
            //            excelcon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties='Excel 12.0;HDR=NO;IMEX=1'";
            //        }
            //        else
            //        {
            //            excelcon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1'";
            //        }
            //        OleDbConnection conexcel = new OleDbConnection(excelcon);

            //        try
            //        {
            //            conexcel.Open();
            //            DataTable dtExcel = conexcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            //            string sheetName = dtExcel.Rows[0]["Table_Name"].ToString();
            //            OleDbCommand cmdexcel1 = new OleDbCommand();
            //            cmdexcel1.Connection = conexcel;
            //            cmdexcel1.CommandText = "select * from[" + sheetName + "]";
            //            DataTable dt = new DataTable();
            //            OleDbDataAdapter da = new OleDbDataAdapter();
            //            da.SelectCommand = cmdexcel1;
            //            da.Fill(dt);
            //            conexcel.Close();
            //            gridviewImportExcel.DataSource = dt;
            //            gridviewImportExcel.Rows.RemoveAt(0);
            //        }
            //        catch (Exception ex)
            //        {
            //            conexcel.Close();
            //            MessageBox.Show(ex.ToString());
            //        }
            //    }
            //}
        }
    }
}
