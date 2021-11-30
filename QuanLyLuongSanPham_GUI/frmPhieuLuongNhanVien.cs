using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_BUS;
using System.Globalization;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using System.Diagnostics;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmPhieuLuongNhanVien : Form
    {
        public frmPhieuLuongNhanVien()
        {
            InitializeComponent();
            phieuLuongCN = new PhieuLuongNhanVien(setPhieuLuongCongNhan);
        }

        #region Propepties
        private int iExportExcelForForm = 0;
        Point LastPoint;
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_BaoCao busBC = new BUS_BaoCao();
        BUS_LuongCongNhan lcn = new BUS_LuongCongNhan();
        BUS_CongDoanSanXuat cdsx = new BUS_CongDoanSanXuat();
        BUS_PhatNhanVien bus_PhatNV = new BUS_PhatNhanVien();
        public delegate void PhieuLuongNhanVien(int iForm, string strMaNV, string strTenNV, string strLuongCoBan, string strSoNgayCongTT, string strDonVi, string strCongDoan, string strSoLuongSPLD, string strPhuCap, string strTienPhat, string strTienUng, string strThue, string strThang, string strNam, string strThucNhan);
        public PhieuLuongNhanVien phieuLuongCN;
        #endregion 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        #region Methos
        void setPhieuLuongCongNhan(int iForm, string strMaNV, string strTenNV, string strDonVi, string strLuongCoBan, string strSoNgayCongTT, string strCongDoan, string strSoLuongSPLD, string strPhuCap, string strTienPhat, string strTienUng, string strThue, string strThang, string strNam, String strThucNhan)
        {
            iExportExcelForForm = iForm;
            if (iForm == 2)
            {
                lblNgayXuatHHT.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                lblDonViL.Text = strDonVi;
                lblThangBN.Text = strThang;
                lblNamBN.Text = strNam;
                lblTen.Text = strTenNV;
                lblMaNV.Text = strMaNV;
                lblCDoan.Text = "Công Đoạn :";
                lblCongDoan.Text = strCongDoan;
                lblSoLuongSPLD.Text = strSoLuongSPLD;
                lblPhuCap.Text = strPhuCap;
                lblThue.Text = strThue;
                lblTienUng.Text = strTienUng;
                lblTongTatCa.Text = strThucNhan;

                IEnumerable<NhanVien> nv = busNV.getNhanVienTheoMa(strMaNV);
                foreach (NhanVien nVien in nv)
                {
                    lblSDT.Text = nVien.soDienThoai;
                }
                IEnumerable<CongDoanSanXuat> cd = cdsx.layDonGiaCD(lblMaNV.Text);
                foreach (CongDoanSanXuat cdsx in cd)
                {
                    {
                        lblLuongCongDoan.Text = cdsx.donGia.ToString();
                    }
                }

                int iSoLuong = Convert.ToInt32(strSoLuongSPLD);
                int iLuongSP = Convert.ToInt32(lblLuongCongDoan.Text);
                int iPhuCap = (int)Convert.ToDecimal(strPhuCap);
                double iThue = Convert.ToDouble(strThue);
                int iThanhTien = iSoLuong * iLuongSP;
                int iTongTienLuongPC = iThanhTien + iPhuCap;
                lblTongTienLuongPC.Text = string.Format("{0:0,0}", iTongTienLuongPC);
                lblThanhTienThue.Text = string.Format("{0:0,0}", iThanhTien * iThue);

                if (strTienUng.Trim() == "")
                {
                    lblTienUng.Text = "0";
                    lblThanhTienTienUng.Text = "0";
                }
                else
                {
                    lblTienUng.Text = strTienUng;
                    lblThanhTienTienUng.Text = strTienUng;
                }

                int iCountDiTre = 0;
                int iCountNghiKhongPhep = 0;
                int iMaPhat = 1;
                int iPhatNghiKhongPhep = 2;
                IEnumerable<PhatNhanVien> phatNVDiTre = bus_PhatNV.laySoLuongViPhamDiTre(strMaNV, iMaPhat);
                foreach (PhatNhanVien phat in phatNVDiTre)
                {
                    iCountDiTre++;
                }
                IEnumerable<PhatNhanVien> phatNVNghiKhongPhep = bus_PhatNV.laySoLuongViPhamNghiKhongPhep(strMaNV, iPhatNghiKhongPhep);
                foreach (PhatNhanVien phat in phatNVNghiKhongPhep)
                {
                    iCountNghiKhongPhep++;
                }
                lblSLDiLamTre.Text = iCountDiTre.ToString();
                lblThanhTienDiTre.Text = string.Format("{0:0,0}", 100000 * iCountDiTre);
                lblSLNghiKhongPhep.Text = iCountNghiKhongPhep.ToString();
                lblNghiKhongPhep.Text = string.Format("{0:0,0}", 100000 * iCountNghiKhongPhep);
                int iTemp = int.Parse(lblTongTatCa.Text.Trim(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                int iTongTienKhauTru_Phat = iTongTienLuongPC - iTemp;
                lblTongTienKhauTru_Phat.Text = string.Format("{0:0,0}", iTongTienKhauTru_Phat);
            }
            else if (iForm == 1)
            {
                lblNgayXuatHHT.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                lblDonViL.Text = strDonVi;
                lblThangBN.Text = strThang;
                lblNamBN.Text = strNam;
                lblTen.Text = strTenNV;
                lblMaNV.Text = strMaNV;
                lblCDoan.Text = "Chức Vụ :";
                lblLuongCD.Text = "Lương Cơ Bản";
                lblsoLuongSPPLD.Text = "Số ngày công thực tế";
                lbldonViLuong.Text = "VNĐ";
                lbldonViSP.Text = "Ngày";
                lblLuongCongDoan.Text = strLuongCoBan;
                lblSoLuongSPLD.Text = strSoNgayCongTT;
                lblPhuCap.Text = strPhuCap;
                lblThue.Text = strThue;
                lblTienUng.Text = strTienUng;
                lblTongTatCa.Text = strThucNhan;

                IEnumerable<NhanVien> nv = busNV.getNhanVienTheoMa(strMaNV);
                foreach (NhanVien nVien in nv)
                {
                    lblSDT.Text = nVien.soDienThoai;
                }
                IEnumerable<LoaiNhanVien> lnv = busNV.getLoaiNhanVienTheoMa(strMaNV);
                foreach (LoaiNhanVien loainv in lnv)
                {
                    lblCongDoan.Text = loainv.loaiNhanVien1;
                }
                foreach (NhanVien nVien in nv)
                {
                    lblSDT.Text = nVien.soDienThoai;
                }

                int iSoLuong = Convert.ToInt32(strSoNgayCongTT.Trim());
                int iLuongCB = int.Parse(strLuongCoBan.Trim(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                int iPhuCap = (int)Convert.ToDecimal(strPhuCap);
                double iThue = Convert.ToDouble(strThue);
                int iThanhTien = (iLuongCB / 26) * iSoLuong;
                int iTongTienLuongPC = iThanhTien + iPhuCap;
                lblTongTienLuongPC.Text = string.Format("{0:0,0}", iTongTienLuongPC);
                lblThanhTienThue.Text = string.Format("{0:0,0}", iThanhTien * iThue);

                if (strTienUng.Trim() == "")
                {
                    lblTienUng.Text = "0";
                    lblThanhTienTienUng.Text = "0";
                }
                else
                {
                    lblTienUng.Text = strTienUng;
                    lblThanhTienTienUng.Text = strTienUng;
                }

                int iCountDiTre = 0;
                int iCountNghiKhongPhep = 0;
                int iMaPhat = 1;
                int iPhatNghiKhongPhep = 2;
                IEnumerable<PhatNhanVien> phatNVDiTre = bus_PhatNV.laySoLuongViPhamDiTre(strMaNV, iMaPhat);
                foreach (PhatNhanVien phat in phatNVDiTre)
                {
                    iCountDiTre++;
                }
                IEnumerable<PhatNhanVien> phatNVNghiKhongPhep = bus_PhatNV.laySoLuongViPhamNghiKhongPhep(strMaNV, iPhatNghiKhongPhep);
                foreach (PhatNhanVien phat in phatNVNghiKhongPhep)
                {
                    iCountNghiKhongPhep++;
                }
                lblSLDiLamTre.Text = iCountDiTre.ToString();
                lblThanhTienDiTre.Text = string.Format("{0:0,0}", 100000 * iCountDiTre);
                lblSLNghiKhongPhep.Text = iCountNghiKhongPhep.ToString();
                lblNghiKhongPhep.Text = string.Format("{0:0,0}", 100000 * iCountNghiKhongPhep);
                int iTemp = int.Parse(lblTongTatCa.Text.Trim(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                int iTongTienKhauTru_Phat = iTongTienLuongPC - iTemp;
                lblTongTienKhauTru_Phat.Text = string.Format("{0:0,0}", iTongTienKhauTru_Phat);
            }
        }
        private void frmPhieuLuongNhanVien_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void frmPhieuLuongNhanVien_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }
        #endregion

        #region Event
        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
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

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage p = new ExcelPackage())
            {
                // đặt tên người tạo file
                p.Workbook.Properties.Author = "HuyDinhSE";

                // đặt tiêu đề cho file
                p.Workbook.Properties.Title = "Báo cáo thống kê lương nhân viên";

                //Tạo một sheet để làm việc trên đó
                p.Workbook.Worksheets.Add("ASC sheet");

                // lấy sheet vừa add ra để thao tác
                ExcelWorksheet ws = p.Workbook.Worksheets[0];
                if (ws == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return;
                }

                // đặt tên cho sheet
                if(iExportExcelForForm == 1)
                {
                    ws.Name = "Lương NV Hành Chánh";
                }  
                else
                {
                    ws.Name = "Lương Công Nhân";
                }    
               
                // fontsize mặc định cho cả sheet
                ws.Cells.Style.Font.Size = 12;
                // font family mặc định cho cả sheet
                ws.Cells.Style.Font.Name = "Times New Roman";

                // Tạo danh sách các column header
                //string[] arrColumnHeader = {
                //"Họ tên",
                // "Năm sinh"

                // lấy ra số lượng cột cần dùng dựa vào số lượng header
                //var countColHeader = arrColumnHeader.Count();
                DateTime Dtoday = DateTime.Now;
                // merge các column
                ws.Cells["A1:C2"].Merge = true;
                ws.Cells["A3:C3"].Merge = true;
                ws.Cells["G1:I1"].Merge = true;
                ws.Cells["G2:I3"].Merge = true;
                ws.Cells["D4:F5"].Merge = true;
                ws.Cells["D6:E6"].Merge = true;
                ws.Cells["F6:G6"].Merge = true;
                ws.Cells["B8:D8"].Merge = true;
                ws.Cells["B9:D9"].Merge = true;
                ws.Cells["F8:I8"].Merge = true;
                ws.Cells["F9:H9"].Merge = true;
                ws.Cells["B11:H11"].Merge = true;
                ws.Cells["B17:H17"].Merge = true;
                ws.Cells["B12:D12"].Merge = true;
                ws.Cells["E12:F12"].Merge = true;
                ws.Cells["E13:F13"].Merge = true;
                ws.Cells["E14:F14"].Merge = true;
                ws.Cells["E15:F15"].Merge = true;
                ws.Cells["E18:F18"].Merge = true;
                ws.Cells["E19:F19"].Merge = true;
                ws.Cells["E20:F20"].Merge = true;
                ws.Cells["E21:F21"].Merge = true;
                ws.Cells["E22:F22"].Merge = true;
                ws.Cells["E23:F23"].Merge = true;
                ws.Cells["G12:H12"].Merge = true;
                ws.Cells["G13:H13"].Merge = true;
                ws.Cells["G14:H14"].Merge = true;
                ws.Cells["G15:H15"].Merge = true;
                ws.Cells["G18:H18"].Merge = true;
                ws.Cells["G19:H19"].Merge = true;
                ws.Cells["G20:H20"].Merge = true;
                ws.Cells["G21:H21"].Merge = true;
                ws.Cells["G22:H22"].Merge = true;
                ws.Cells["G23:H23"].Merge = true;
                ws.Cells["B13:D13"].Merge = true;
                ws.Cells["B14:D14"].Merge = true;
                ws.Cells["B15:D15"].Merge = true;
                ws.Cells["B16:D16"].Merge = true;
                ws.Cells["B18:D18"].Merge = true;
                ws.Cells["B19:D19"].Merge = true;
                ws.Cells["B20:D20"].Merge = true;
                ws.Cells["B21:D21"].Merge = true;
                ws.Cells["B22:D22"].Merge = true;
                ws.Cells["B23:D23"].Merge = true;
                ws.Cells["B24:D24"].Merge = true;
                ws.Cells["E16:H16"].Merge = true;
                ws.Cells["E24:H24"].Merge = true;
                ws.Cells["C26:H26"].Merge = true;
                ws.Cells["D27:G27"].Merge = true;
                ws.Cells["B29:C29"].Merge = true;
                ws.Cells["B30:C30"].Merge = true;
                ws.Cells["G29:H29"].Merge = true;
                ws.Cells["G30:H30"].Merge = true;

                // gán giá trị cho cell vừa merge
                ws.Cells["A1"].Value = "CÔNG TY TNHH MÁY TRỢ THÍNH HSG";
                ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                ws.Cells["A1"].Style.VerticalAlignment  = ExcelVerticalAlignment.Center;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A3"].Value = "MST : 169797979";
                ws.Cells["A3"].Style.Font.Bold = true;
                ws.Cells["G1"].Value = "Ngày Xuất : " + Dtoday.ToString("dd/MM/yyyy");
                ws.Cells["G1"].Style.Font.Bold = true;
                ws.Cells["G2"].Value = "Đơn vị: " + lblDonViL.Text;
                ws.Cells["G2"].Style.Font.Bold = true;
                ws.Cells["G2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Justify;
                ws.Cells["D4"].Value = "PHIẾU LƯƠNG";
                ws.Cells["D4"].Style.Font.Size = 16;
                ws.Cells["D4"].Style.Font.Bold = true;
                ws.Cells["D4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                ws.Cells["D6"].Value = "Tháng: " + lblThangBN.Text;
                ws.Cells["D6"].Style.Font.Bold = true;
                ws.Cells["F6"].Value = "Năm: " + lblNamBN.Text;
                ws.Cells["F6"].Style.Font.Bold = true;
                ws.Cells["B8"].Value = "Họ Tên: " + lblTen.Text;

                ws.Cells["B8"].Style.Font.Bold = true;
                ws.Cells["F8"].Value = (iExportExcelForForm == 2 ? ("Công Đoạn: " + lblCongDoan.Text) : ("Chức Vụ: " + lblCongDoan.Text));
                ws.Cells["F8"].Style.Font.Bold = true;
                ws.Cells["B9"].Value = "Mã NV: " + lblMaNV.Text;
                ws.Cells["B9"].Style.Font.Bold = true;
                ws.Cells["F9"].Value = "SĐT: " + lblSDT.Text;
                ws.Cells["F9"].Style.Font.Bold = true;
                ws.Cells["B11"].Value = "1.Lương - Phụ Cấp";
                ws.Cells["B11"].Style.Font.Bold = true;
                ws.Cells["B12"].Value = "Nội Dung";
                ws.Cells["B12"].Style.Font.Bold = true;
                ws.Cells["B13"].Value =(iExportExcelForForm == 2 ? ("Lương công đoạn") : ("Lương cơ bản"));
                ws.Cells["B14"].Value = (iExportExcelForForm == 2 ? ("Số lượng sản phẩm làm được") : ("Số ngày công thực tế"));
                ws.Cells["B15"].Value = "Phụ cấp";
                ws.Cells["B16"].Value = "Thành Tiền (1)";
                ws.Cells["B16"].Style.Font.Bold = true;
                ws.Cells["B17"].Value = "2. Các khoảng Trừ";
                ws.Cells["B17"].Style.Font.Bold = true;
                ws.Cells["B18"].Value = "  2.1 Khấu trừ";
                ws.Cells["B18"].Style.Font.Bold = true;
                ws.Cells["B19"].Value = "Thuế";
                ws.Cells["B20"].Value = "Tiền Ứng";
                ws.Cells["B21"].Value = "  2.2 Phạt";
                ws.Cells["B21"].Style.Font.Bold = true;
                ws.Cells["B22"].Value = "Đi làm trễ";
                ws.Cells["B23"].Value = "Nghỉ không phép";
                ws.Cells["B24"].Value = "Thành Tiền (2)";
                ws.Cells["B24"].Style.Font.Bold = true;
                ws.Cells["E12"].Value = "Đơn giá_Số Lượng";
                ws.Cells["E12"].Style.Font.Bold = true;
                ws.Cells["E13"].Value = lblLuongCongDoan.Text;
                ws.Cells["E13"].Style.Font.Size = 12;
                ws.Cells["E14"].Value = lblSoLuongSPLD.Text;
                ws.Cells["E14"].Style.Font.Size = 12;
                ws.Cells["E15"].Value = lblPhuCap.Text;
                ws.Cells["E15"].Style.Font.Size = 12;
                ws.Cells["E16"].Value = lblTongTienLuongPC.Text;
                ws.Cells["E16"].Style.Font.Bold = true;
                ws.Cells["E16"].Style.Font.Size = 13;
                ws.Cells["E18"].Value = "Mức Khấu Trừ";
                ws.Cells["E18"].Style.Font.Bold = true;
                ws.Cells["E19"].Value = lblThue.Text;
                ws.Cells["E19"].Style.Font.Size = 12;
                ws.Cells["E20"].Value = lblTienUng.Text;
                ws.Cells["E20"].Style.Font.Size = 12;
                ws.Cells["E21"].Value = "Số Lượng";
                ws.Cells["E21"].Style.Font.Bold = true;
                ws.Cells["E22"].Value = lblSLDiLamTre.Text;
                ws.Cells["E22"].Style.Font.Size = 12;
                ws.Cells["E23"].Value = lblSLNghiKhongPhep.Text;
                ws.Cells["E23"].Style.Font.Size = 12;
                ws.Cells["E24"].Value = lblTongTienKhauTru_Phat.Text;
                ws.Cells["E24"].Style.Font.Bold = true;
                ws.Cells["E24"].Style.Font.Size = 13;
                ws.Cells["G12"].Value = "Đơn vị";
                ws.Cells["G12"].Style.Font.Bold = true;
                ws.Cells["G13"].Value = (iExportExcelForForm == 2 ? ("/Sản Phẩm") : ("VNĐ"));
                ws.Cells["G14"].Value = (iExportExcelForForm == 2 ? ("Sản Phẩm") : ("Ngày"));
                ws.Cells["G15"].Value = "VNĐ";
                ws.Cells["G18"].Value = "Thành Tiền";
                ws.Cells["G18"].Style.Font.Bold = true;
                ws.Cells["G19"].Value = lblThanhTienThue.Text;
                ws.Cells["G19"].Style.Font.Size = 12;
                ws.Cells["G20"].Value = lblThanhTienTienUng.Text;
                ws.Cells["G20"].Style.Font.Size = 12;
                ws.Cells["G21"].Value = "Thành Tiền";
                ws.Cells["G21"].Style.Font.Bold = true;
                ws.Cells["G22"].Value = lblThanhTienDiTre.Text;
                ws.Cells["G22"].Style.Font.Size = 12;
                ws.Cells["G23"].Value = lblNghiKhongPhep.Text;
                ws.Cells["G23"].Style.Font.Size = 12;
                ws.Cells["C26"].Value = "TỔNG TIỀN = THÀNH TIỀN (1) - THÀNH TIỀN (2)";
                ws.Cells["C26"].Style.Font.Bold = true;
                ws.Cells["D27"].Value = "=" + lblTongTatCa.Text + "  VNĐ";
                ws.Cells["D27"].Style.Font.Bold = true;
                ws.Cells["D27"].Style.Font.Size = 13;
                ws.Cells["B29"].Value = "Người Lập";
                ws.Cells["G29"].Value = "Người Nhận";
                ws.Cells["B30"].Value = "(Ký tên)";
                ws.Cells["G30"].Value = "(Ký tên)";

                string modelRange1 = "B11:H24";
                var modelTable1 = ws.Cells[modelRange1];

                // Sua Border
                modelTable1.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                modelTable1.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                modelTable1.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                modelTable1.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                modelTable1.AutoFitColumns();

                string modelRange2 = "B12:H16";
                var modelTable2 = ws.Cells[modelRange2];
                modelTable2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                modelTable2.AutoFitColumns();

                string modelRange3 = "B18:H24";
                var modelTable3 = ws.Cells[modelRange3];
                modelTable3.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                modelTable3.AutoFitColumns();

                //ws.Cells["A1,I34"].Style.Border = Border.al
                //ws.Cells[1, 1, 1, countColHeader].Merge = true;
                // in đậm
                //ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                // căn giữa
                //ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //int colIndex = 1;
                //int rowIndex = 2;

                ////tạo các header từ column header đã tạo từ bên trên
                //foreach (var item in arrColumnHeader)
                //{
                //    var cell = ws.Cells[rowIndex, colIndex];

                //    //set màu thành gray
                //    var fill = cell.Style.Fill;
                //    fill.PatternType = ExcelFillStyle.Solid;
                //    fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                //    //căn chỉnh các border
                //    var border = cell.Style.Border;
                //    border.Bottom.Style =
                //        border.Top.Style =
                //        border.Left.Style =
                //        border.Right.Style = ExcelBorderStyle.Thin;

                //    //gán giá trị
                //    cell.Value = item;

                //    colIndex++;
                //}

                //// lấy ra danh sách UserInfo từ ItemSource của DataGrid
                //List<UserInfo> userList = dtgExcel.ItemsSource.Cast<UserInfo>().ToList();

                //// với mỗi item trong danh sách sẽ ghi trên 1 dòng
                //foreach (var item in userList)
                //{
                //    // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                //    colIndex = 1;

                //    // rowIndex tương ứng từng dòng dữ liệu
                //    rowIndex++;

                //    //gán giá trị cho từng cell                      
                //    ws.Cells[rowIndex, colIndex++].Value = item.Name;

                //    // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                //    ws.Cells[rowIndex, colIndex++].Value = item.Birthday.ToShortDateString();

                //}

                //Lưu file lại
                //Byte[] bin = p.GetAsByteArray();
                //File.WriteAllBytes(filePath, bin);
                Stream stream = File.Create(filePath);
                p.SaveAs(stream);
                stream.Close();     
            }
            MessageBox.Show("Xuất excel thành công!");
            DialogResult dResult = MessageBox.Show("Bạn có muốn mở file excel vừa rồi không?","Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dResult == DialogResult.Yes)
            {
                Process.Start(filePath);
            }            
        }
    }
    #endregion
}

