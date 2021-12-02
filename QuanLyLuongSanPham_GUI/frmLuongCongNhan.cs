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
using DevExpress.XtraEditors.Mask;
using System.Data.OleDb;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmLuongCongNhan : DevExpress.XtraEditors.XtraForm
    {
        #region Propepties
        Point LastPoint;
        BUS_LuongCongNhan busLuongCongNhan = new BUS_LuongCongNhan();
        BUS_DonViQuanLy busDVQL = new BUS_DonViQuanLy();
        BUS_NhanVien busNV = new BUS_NhanVien();

        public delegate void tenNVDangNhap(string strTenNVDangNhap);
        public tenNVDangNhap tenNVDN;

        bool bCheckNVTimKiem = false;
        string strTenNVDN = "";
        #endregion

        #region Methos
        public frmLuongCongNhan()
        {
            InitializeComponent();
            tenNVDN = new tenNVDangNhap(setTenNV);
        }
        void setTenNV(string TenNVDN)
        {
            strTenNVDN = TenNVDN;
        }
        private void statusTextBox(bool bStatus)
        {
            txtMaNV.Enabled = bStatus;
            txtHoTen.Enabled = bStatus;
            txtCongDoan.Enabled = bStatus;
            txtDonVi.Enabled = bStatus;
            txtPhuCap.Enabled = bStatus;
            txtSLSPLamDuoc.Enabled = bStatus;
            txtTienPhat.Enabled = bStatus;
            txtThue.Enabled = bStatus;
            txtTongLuongTT.Enabled = bStatus;
            txtTamUng.Enabled = bStatus;
        }

        private void clearTextBox()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtCongDoan.Text = "";
            txtDonVi.Text = "";
            txtPhuCap.Text = "";
            txtSLSPLamDuoc.Text = "";
            txtTienPhat.Text = "";
            txtThue.Text = "";
            txtTongLuongTT.Text = "";
            txtTamUng.Text = "";
            txtThucNhan.Text = "";
        }
        private void moTextBox()
        {
            txtSLSPLamDuoc.Enabled = true;
        }
        void loadNVTimKiem(bool bCheck, string maNVTK, string strThang, string strNam)
        {
            bCheckNVTimKiem = bCheck;
            if (bCheckNVTimKiem)
            {
                dtgvLuongCongNhan.DataSource = busLuongCongNhan.layNVTheoTimKiem(maNVTK);
                this.dtgvLuongCongNhan.SelectionMode = DataGridViewSelectionMode.CellSelect;
                ccbThang.Text = strThang;
                ccbNam.Text = strNam;
            }
        }
        private void loadCBBThangNam()
        {
            for (int i = 1; i <= 12; i++)
            {
                _ = ccbThang.Items.Add(i);
            }
            ccbNam.Items.Add(2021);
            ccbNam.Items.Add(2020);
        }

        private void loadLuongCongNhan()
        {
            btnHuy.Enabled = false;
            this.dtgvLuongCongNhan.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongCongNhan.DefaultCellStyle.Font = new Font("Tahoma", 10);
            this.dtgvLuongCongNhan.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongCongNhan.DataSource = busLuongCongNhan.loadLuongCN();
        }
        #endregion

        #region
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        private void toolTip()
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            System.Windows.Forms.ToolTip ToolTip2 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.btnChiTietLuong, "Xem chi tiết lương");
            ToolTip2.SetToolTip(this.btnReLoad, "Tải lại trang");
        }
        private void FrmLuongCongNhan_Load(object sender, EventArgs e)
        {
            Util.Animate(this, Util.Effect.Center, 150, 180);
            statusTextBox(false);
            toolTip();
            loadCBBThangNam();
            loadLuongCongNhan();
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
        private void btnSua_Click(object sender, EventArgs e)
        {
            moTextBox();
            if (btnSua.Text == "Sửa")
            {
                btnSua.Text = "Lưu";
                btnHuy.Enabled = true;
            }
            else if (btnSua.Text == "Lưu")
            {
                if (txtSLSPLamDuoc.Text == "")
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
                        if (dtgvLuongCongNhan.Rows.Count == 1)
                        {
                            string strMaNV = txtMaNV.Text.Trim();
                            dtgvLuongCongNhan.DataSource = busNV.serchNhanVienLuongCNhan(strMaNV, "dataSearchOne", "dataSearchSecond", "dataSearchThirst");
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
            clearTextBox();
            int iMonth = Convert.ToInt32(ccbThang.Text);
            int iYear = Convert.ToInt32(ccbNam.Text);
            this.dtgvLuongCongNhan.DefaultCellStyle.ForeColor = Color.Black;
            this.dtgvLuongCongNhan.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            dtgvLuongCongNhan.DataSource = busLuongCongNhan.luongCNTheoThang(iMonth, iYear);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemLuongTheoLoai fTimKiemNV = new frmTimKiemLuongTheoLoai();
            fTimKiemNV.nvTimKiemLuongCN = loadNVTimKiem;
            try
            {
                fTimKiemNV.ShowDialog();
            }
            catch (Exception) { }
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            dtgvLuongCongNhan.DataSource = busLuongCongNhan.loadLuongCN();
        }
        private void btnChiTietLuong_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                frmPhieuLuongNhanVien fPhieuLuong = new frmPhieuLuongNhanVien();
                fPhieuLuong.phieuLuongCN(2, txtMaNV.Text, txtHoTen.Text, txtDonVi.Text, "", "", txtCongDoan.Text, txtSLSPLamDuoc.Text, txtPhuCap.Text, txtTienPhat.Text, txtTamUng.Text, txtThue.Text, ccbThang.Text, ccbNam.Text, txtThucNhan.Text);
                fPhieuLuong.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn cần phải chọn một nhân viên để xem chi tiết lương", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            // tạo ra danh sách DTO rỗng để hứng dữ liệu.
            List<DTO_DonViQuanLy> donVi = new List<DTO_DonViQuanLy>();
            List<DTO_LoaiNhanVien> loaiNV = new List<DTO_LoaiNhanVien>();
            List<DTO_NhanVien> nv = new List<DTO_NhanVien>();
            List<DTO_LuongCongNhan> luongCongNhan = new List<DTO_LuongCongNhan>();
            List<DTO_MucPhat> mucPhat = new List<DTO_MucPhat>();
            List<DTO_CongDoanSanXuat> congDoan = new List<DTO_CongDoanSanXuat>();
            try
            {
                // mở file excel
                var package = new ExcelPackage(new FileInfo("DanhSachLuongCongNhan.xlsx"));

                // lấy ra sheet đầu tiên để thao tác
                ExcelWorksheet workSheet = package.Workbook.Worksheets[0];

                // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    try
                    {
                        // biến j biểu thị cho một column trong file
                        int j = 1;

                        // lấy ra cột họ tên tương ứng giá trị tại vị trí [i, 1]. i lần đầu là 2
                        // tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                        string name = workSheet.Cells[i, j++].Value.ToString();

                        // lấy ra cột ngày sinh tương ứng giá trị tại vị trí [i, 2]. i lần đầu là 2
                        // tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                        // lấy ra giá trị ngày tháng và ép kiểu thành DateTime                      
                        var birthdayTemp = workSheet.Cells[i, j++].Value;
                        DateTime birthday = new DateTime();
                        if (birthdayTemp != null)
                        {
                            birthday = (DateTime)birthdayTemp;
                        }

                        /*                         

                        Đừng lười biến mà dùng đoạn code này sẽ gây ra lỗi nếu giá trị value không thỏa kiểu DateTime

                        DateTime birthday = (DateTime)workSheet.Cells[i, j++].Value;

                         */


                        // tạo UserInfo từ dữ liệu đã lấy được
                        //UserInfo user = new UserInfo()
                        //{
                        //    Name = name,
                        //    Birthday = birthday
                        //};

                        // add UserInfo vào danh sách userList
                       // userList.Add(user);

                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error!");
            }

            //dtgvLuongCongNhan.DataSource = userList;

        }
        private void btnExcelBC_Click(object sender, EventArgs e)
        {
            if (dtgvLuongCongNhan.DataSource == null) return;

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
                    "Công Đoạn",
                    "SLSP Làm Được",
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
                worksheet.Cells["E8"].Value = "                      Kỳ báo cáo lương : Từ " + firstDayOfMonth + "   Đến   " + lastDayOfMonth;
                //Xuất dòng Tiêu đề của File báo cáo 

                worksheet.Cells["C1:D2"].Merge = true;
                worksheet.Cells["C1"].Value = "CÔNG TY TNHH MÁY TRỢ THÍNH HSG";
                worksheet.Cells["C1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                worksheet.Cells["C1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["C1"].Style.Font.Bold = true;
                worksheet.Cells["D6:K7"].Merge = true;
                worksheet.Cells["D6"].Value = "BẢNG THỐNG KÊ LƯƠNG CÔNG NHÂN";
                worksheet.Cells["D6:K7"].AutoFitColumns(30, 50);
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
                var modelRows = 13 + dtgvLuongCongNhan.Rows.Count - 1;
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
                    for (int i = 0; i < dtgvLuongCongNhan.Rows.Count; i++)
                    {
                        worksheet.Cells["B" + (i + 13)].Value = index;
                        worksheet.Cells["C" + (i + 13)].Value = dtgvLuongCongNhan[0, i].Value;
                        worksheet.Cells["D" + (i + 13)].Value = dtgvLuongCongNhan[1, i].Value;
                        worksheet.Cells["E" + (i + 13)].Value = dtgvLuongCongNhan[2, i].Value;
                        worksheet.Cells["F" + (i + 13)].Value = dtgvLuongCongNhan[3, i].Value;
                        worksheet.Cells["G" + (i + 13)].Value = dtgvLuongCongNhan[4, i].Value;
                        worksheet.Cells["H" + (i + 13)].Value = dtgvLuongCongNhan[5, i].Value;
                        worksheet.Cells["I" + (i + 13)].Value = dtgvLuongCongNhan[6, i].Value;
                        worksheet.Cells["J" + (i + 13)].Value = dtgvLuongCongNhan[7, i].Value;
                        worksheet.Cells["K" + (i + 13)].Value = dtgvLuongCongNhan[8, i].Value;
                        worksheet.Cells["L" + (i + 13)].Value = dtgvLuongCongNhan[9, i].Value;
                        worksheet.Cells["M" + (i + 13)].Value = string.Format("{0:N0}", dtgvLuongCongNhan[10, i].Value) + " VNĐ";
                        tongTien += (decimal)dtgvLuongCongNhan[8, i].Value;
                        index++;
                    }

                    worksheet.Cells["C10"].Value = "Số lượng nhân viên:" + dtgvLuongCongNhan.Rows.Count;
                    worksheet.Cells["C10"].Style.Font.Bold = true;

                    worksheet.Cells["L10"].Value = "Tổng tiền TT: " + string.Format("{0:N0}", tongTien) + " VNĐ"; ;
                    worksheet.Cells["L10"].Style.Font.Bold = true;
                    worksheet.Cells["L10"].Style.Font.Size = 14;
                    worksheet.Cells["K29"].Value = "Xác nhận của đơn vị";
                    worksheet.Cells["K30"].Value = "(Ký tên)";
                    worksheet.Cells["D29"].Value = "Người Lập";
                    worksheet.Cells["D30"].Value = "(Ký tên)";
                    worksheet.Cells["D30"].Value = "(Ký tên)";
                    worksheet.Cells["D32"].Value = strTenNVDN;
                    worksheet.Cells["D32"].Style.Font.Bold = true;
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
            #endregion
        }
    }
}
