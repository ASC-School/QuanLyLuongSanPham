using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
    public partial class frmLuongNhanVienHanhChanh : DevExpress.XtraEditors.XtraForm
    {
        public frmLuongNhanVienHanhChanh()
        {
            InitializeComponent();
        }


        #region Propepties
        Point LastPoint;
        BUS_LuongNhanVienHanhChanh bus_LuongNVHC = new BUS_LuongNhanVienHanhChanh();
        BUS_DonViQuanLy busDVQL = new BUS_DonViQuanLy();
        BUS_NhanVien busNV = new BUS_NhanVien();
        bool bCheckNVTimKiem = false;
        #endregion

        #region Methos
        private void loadCBBThangNam()
        {
            for (int i = 1; i <= 12; i++)
            {
                _ = ccbThang.Items.Add(i);
            }
            ccbNam.Items.Add(2021);
            ccbNam.Items.Add(2020);
            toolTip1.SetToolTip(btnLayNgayCongThucTe, "Tính ngày công thực tế");
        }
        private int loadNgayChamCong(string maNhanVien,string thang, string nam)
        {
            int ngayChamCong = 0;
            IEnumerable<PhieuChamCongNhanVienHanhChanh> listChamCong = bus_LuongNVHC.layDSChamCong(maNhanVien);
            foreach(PhieuChamCongNhanVienHanhChanh n in listChamCong)
            {
                if (n.diLam == true&&n.ngayChamCong.Value.ToString("MM").Equals(thang)&& n.ngayChamCong.Value.ToString("yyyy").Equals(nam))
                    ngayChamCong ++;
                else
                    ngayChamCong += 0;
            }
            return ngayChamCong; 
        }
        private void loadLuongNVHanhChanh()
        {
            btnHuy.Enabled = false;
            this.dtgvLuongHanhChanh.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongHanhChanh.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.loadLuongHC();
        }

        private void clearTextBox()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtLuongCoBan.Text = "";
            txtDonVi.Text = "";
            txtPhuCap.Text = "";
            txtSoNgayCongTT.Text = "";
            txtTienPhat.Text = "";
            txtThue.Text = "";
            txtTongLuongTT.Text = "";
            txtTamUng.Text = "";
            txtThucNhan.Text = "";
        }
        private void toolTip()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnChiTietLuong, "Xem chi tiết lương");
            ToolTip2.SetToolTip(this.btnReLoad, "Tải lại trang");
        }

        private void offEnTextBox(bool bCheck)
        {
            txtMaNV.Enabled = bCheck;
            txtHoTen.Enabled = bCheck;
            txtDonVi.Enabled = bCheck;
            txtLuongCoBan.Enabled = bCheck;
            txtSoNgayCongTT.Enabled = bCheck;
            txtPhuCap.Enabled = bCheck;
            txtTienPhat.Enabled = bCheck;
            txtThue.Enabled = bCheck;
            txtTongLuongTT.Enabled = bCheck;
            txtTamUng.Enabled = bCheck;
            txtThucNhan.Enabled = bCheck;
        }
        #endregion

        #region Event
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        private void FrmLuongNhanVienHanhChanh_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            loadLuongNVHanhChanh();
            offEnTextBox(false);
            toolTip();
            loadCBBThangNam();
        }

        private void FrmLuongNhanVienHanhChanh_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void FrmLuongNhanVienHanhChanh_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTimKiemLuongTheoLoai fTimKiemNVHC = new frmTimKiemLuongTheoLoai();
                fTimKiemNVHC.nvTimKiemLuongCN = loadNVTimKiem;
                _ = fTimKiemNVHC.ShowDialog();
            }
            catch (Exception) { }
        }

        private void loadNVTimKiem(bool bCheck, string strMaNV, string strThang, string strNam)
        {
            if (bCheck)
            {
                dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.layNVTheoTimKiem(strMaNV);
                this.dtgvLuongHanhChanh.SelectionMode = DataGridViewSelectionMode.CellSelect;
                ccbThang.Text = strThang;
                ccbNam.Text = strNam;
            }
        }

        private void dtgvLuongHanhChanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvLuongHanhChanh.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtHoTen.Text = row.Cells[1].Value.ToString();
                txtDonVi.Text = row.Cells[2].Value.ToString();
                txtLuongCoBan.Text = row.Cells[3].Value.ToString();
                txtSoNgayCongTT.Text = row.Cells[4].Value.ToString();
                txtPhuCap.Text = row.Cells[5].Value.ToString();
                txtTienPhat.Text = row.Cells[6].Value.ToString();
                txtThue.Text = row.Cells[7].Value.ToString();
                txtTongLuongTT.Text = row.Cells[8].Value.ToString();
                txtTamUng.Text = row.Cells[9].Value.ToString();
                txtThucNhan.Text = row.Cells[10].Value.ToString();
            }
        }
        #endregion

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            this.dtgvLuongHanhChanh.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongHanhChanh.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            this.dtgvLuongHanhChanh.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.loadLuongHC();
        }

        private void btnChiTietLuong_Click(object sender, EventArgs e)
        {
            frmPhieuLuongNhanVien fPhieuLuong = new frmPhieuLuongNhanVien();
            fPhieuLuong.phieuLuongCN(1, txtMaNV.Text, txtHoTen.Text, txtDonVi.Text, txtLuongCoBan.Text, txtSoNgayCongTT.Text, "", "", txtPhuCap.Text, txtTienPhat.Text, txtTamUng.Text, txtThue.Text, ccbThang.Text, ccbNam.Text, txtThucNhan.Text);
            fPhieuLuong.ShowDialog();
        }

        private void ccbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearTextBox();
            int iMonth = Convert.ToInt32(ccbThang.Text);
            int iYear = Convert.ToInt32(ccbNam.Text);
            this.dtgvLuongHanhChanh.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongHanhChanh.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.luongHCTheoThang(iMonth, iYear);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtSoNgayCongTT.Enabled = true;
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnHuy.Enabled = true;
                btnLayNgayCongThucTe.Enabled = true;
            }
            else if (btnSua.Text == "Lưu")
            {
                if (txtSoNgayCongTT.Text == "")
                {
                    MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    DTO_LuongHanhChanh dto_LHC = new DTO_LuongHanhChanh();
                    dto_LHC.MaNhanVien = txtMaNV.Text;
                    dto_LHC.SoNgayLamDuoc = Convert.ToInt32(txtSoNgayCongTT.Text);
                    if (bus_LuongNVHC.suaThongTin(dto_LHC) == true)
                    {
                        bus_LuongNVHC.suaThongTin(dto_LHC);
                        MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dtgvLuongHanhChanh.Rows.Count == 1)
                        {
                            string strMaNV = txtMaNV.Text.Trim();
                            dtgvLuongHanhChanh.DataSource = busNV.serchNhanVienLuongHChanh(strMaNV, "dataSearchOne", "dataSearchSecond", "dataSearchThirst");
                        }
                        else
                        {
                            dtgvLuongHanhChanh.DataSource = bus_LuongNVHC.loadLuongHC();
                        }
                        btnSua.Text = "Sửa";
                        txtSoNgayCongTT.Enabled = false;
                        btnHuy.Enabled = false;
                        btnLayNgayCongThucTe.Enabled = false;
                    }
                }
            }
        }

        private void btnXuatBC_Click(object sender, EventArgs e)
        {
            if (dtgvLuongHanhChanh.DataSource == null) return;

            string filePath = "";
            // tạo SaveFileDialog để lưu file excel
            SaveFileDialog dialog = new SaveFileDialog();

            // chỉ lọc ra các file có định dạng Excel
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
            dialog.ShowDialog();
            filePath = dialog.FileName;

            // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                return;
            }

            //xuat ra file exce;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                // dat ten ng tao file
                package.Workbook.Properties.Author = "ASC team";
                //dattieu de cho file
                package.Workbook.Properties.Title = "Báo cáo thống kê Lương Nhân Viên";

                // tạo sheet đê thao tác
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Lương Công Nhân");
                if (worksheet == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return;
                }
                // đặt tên cho sheet
                worksheet.Name = "Danh Sách Lương Công Nhân";

                //fontsize mặc định cho cả sheet
                worksheet.Cells.Style.Font.Size = 12;

                string[] arrColumnHeader =
                {
                    "STT",
                    "Mã Nhân Viên",
                    "Họ Tên",
                    "Đơn Vị",
                    "Lương Cơ Bản",
                    "Số Ngày Công Thực Tế",
                    "Phụ Cấp",
                    "Tên Phạt",
                    "Thuế(%)",
                    "Tổng Lương Thực Tế",
                    "Tạm Ứng",
                    "Thực Nhận"
                };

                // lấy ra số lượng cột cần dùng dựa vào số lượng header
                var countColHeader = arrColumnHeader.Count();

                // font family mặc định cho cả sheet
                worksheet.Cells.Style.Font.Name = "Times New Roman";
                DateTime _today = DateTime.Now;
                var firstDayOfMonth = new DateTime(_today.Year, _today.Month, 1);
                var lastDayOfMonth = new DateTime(_today.Year, _today.Month, DateTime.DaysInMonth(_today.Year, _today.Month));
                worksheet.Cells["B4"].Value = "                           Thành phố Hồ Chí Minh, ngày " + _today.Day + " tháng " + _today.Month + " năm " + _today.Year + "";
                worksheet.Cells["D8"].Value = "                                   Kỳ báo cáo lương : Từ " + firstDayOfMonth + "   Đến   " + lastDayOfMonth;
                //Xuất dòng Tiêu đề của File báo cáo 

                worksheet.Cells["C1:D2"].Merge = true;
                worksheet.Cells["C1"].Value = "CÔNG TY TNHH MÁY TRỢ THÍNH HSG";
                worksheet.Cells["C1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                worksheet.Cells["C1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["C1"].Style.Font.Bold = true;
                worksheet.Cells["D6:J7"].Merge = true;
                worksheet.Cells["D6:J7"].Value = "BẢNG THỐNG KÊ LƯƠNG NHÂN VIÊN HÀNH CHÁNH";
                worksheet.Cells["D6:J7"].AutoFitColumns(30, 50);
                worksheet.Column(3).Width = worksheet.Column(4).Width = worksheet.Column(5).Width = 30;
                worksheet.Column(6).Width = 30;
                for (int i = 7; i < 14; i++)
                {
                    worksheet.Column(i).Width = 15;
                }
                worksheet.Column(14).Width = 30;
                worksheet.Cells["D6:J7"].Style.Font.Size = 24;
                worksheet.Cells["D6:J7"].Style.Font.Bold = true;
                worksheet.Cells["D6:J7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                var modelCells = worksheet.Cells["B14"];
                var modelRows = 13 + dtgvLuongHanhChanh.Rows.Count - 1;
                string modelRange = "B13:M" + modelRows.ToString();
                var modelTable = worksheet.Cells[modelRange];

                // Assign borders
                modelTable.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                int colIndex = 2;
                int rowIndex = 12;
                foreach (var item in arrColumnHeader)
                {
                    var cell = worksheet.Cells[rowIndex, colIndex];
                    cell.AutoFitColumns();

                    // set mau
                    var fill = cell.Style.Fill;
                    fill.PatternType = ExcelFillStyle.Solid;
                    fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                    //căn chỉnh các border
                    var border = cell.Style.Border;
                    border.Bottom.Style =
                        border.Top.Style =
                        border.Left.Style =
                        border.Right.Style = ExcelBorderStyle.Thin;


                    // căn chỉnh font
                    var font = cell.Style.Font;
                    font.Size = 12;
                    font.Bold = true;
                    //gán giá trị
                    cell.Value = item;

                    colIndex++;

                    // var i = 13;
                    var index = 1;
                    decimal tongTien = 0;
                    // Export data 
                    for (int i = 0; i < dtgvLuongHanhChanh.Rows.Count; i++)
                    {
                        worksheet.Cells["B" + (i + 13)].Value = index;
                        worksheet.Cells["C" + (i + 13)].Value = dtgvLuongHanhChanh[0, i].Value;
                        worksheet.Cells["D" + (i + 13)].Value = dtgvLuongHanhChanh[1, i].Value;
                        worksheet.Cells["E" + (i + 13)].Value = dtgvLuongHanhChanh[2, i].Value;
                        worksheet.Cells["F" + (i + 13)].Value = dtgvLuongHanhChanh[3, i].Value;
                        worksheet.Cells["G" + (i + 13)].Value = dtgvLuongHanhChanh[4, i].Value;
                        worksheet.Cells["H" + (i + 13)].Value = dtgvLuongHanhChanh[5, i].Value;
                        worksheet.Cells["I" + (i + 13)].Value = dtgvLuongHanhChanh[6, i].Value;
                        worksheet.Cells["J" + (i + 13)].Value = dtgvLuongHanhChanh[7, i].Value;
                        worksheet.Cells["K" + (i + 13)].Value = dtgvLuongHanhChanh[8, i].Value;
                        worksheet.Cells["L" + (i + 13)].Value = dtgvLuongHanhChanh[9, i].Value;
                        worksheet.Cells["M" + (i + 13)].Value = string.Format("{0:N0}", dtgvLuongHanhChanh[10, i].Value) + " VNĐ";
                        tongTien += (decimal)dtgvLuongHanhChanh[8, i].Value;
                        index++;
                    }

                    worksheet.Cells["C10"].Value = "Số lượng nhân viên:" + dtgvLuongHanhChanh.Rows.Count;
                    worksheet.Cells["C10"].Style.Font.Bold = true;
                    worksheet.Cells["C10"].Style.Font.Size = 14;
                    worksheet.Cells["L10"].Value = "Tổng tiền TT: " + string.Format("{0:N0}", tongTien) + " VNĐ"; ;
                    worksheet.Cells["L10"].Style.Font.Bold = true;
                    worksheet.Cells["L10"].Style.Font.Size = 14;

                    string modelRange2 = "B12:N25";
                    var modelTable2 = worksheet.Cells[modelRange2];
                    modelTable2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    modelTable2.AutoFitColumns();

                    Stream stream = File.Create(filePath);
                    package.SaveAs(stream);
                    stream.Close();
                }
                MessageBox.Show("Xuất excel thành công!");
                DialogResult dResult = MessageBox.Show("Bạn có muốn mở file excel vừa rồi không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dResult == DialogResult.Yes)
                {
                    Process.Start(filePath);
                }
                else
                {
                    MessageBox.Show("File được lưu trong " + filePath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLayNgayCongThucTe_Click(object sender, EventArgs e)
        {
            txtSoNgayCongTT.Text =loadNgayChamCong(txtMaNV.Text, ccbThang.Text, ccbNam.Text).ToString();
        }
    }
}
