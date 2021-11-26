using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;
using Microsoft.Office.Tools;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_BaoCao
    {

        BUS_DonHang donHangBUS;
        public BUS_BaoCao() {
            donHangBUS = new BUS_DonHang();
        }


        // xuất data ra file excel
        public void ExporttoExcel(DataGridView data, string DirrectoryPath)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int k = 1; k < data.Columns.Count + 1; k++)
            {
                obj.Cells[1, k] = data.Columns[k - 1].HeaderText;
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    if (data.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(DirrectoryPath);
            obj.ActiveWorkbook.Saved = true;
        }

        // lấy đường dẫn excel
        public string GetLocationForExcel()
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Title = "Select Location";
                dlg.Filter = "Excel Worksheets|*.xlsx";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    return dlg.FileName.ToString();
                }
                else
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

       

        // xuat xuat don hàng + chi tiet don hang
        public bool ReportThongTinDonHang(DataGridView dgv, string directoryPath,string tuNgay, string denNgay)
        {
            if (dgv.DataSource == null) return false;

            //xuat ra file exce;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                // dat ten ng tao file
                package.Workbook.Properties.Author = "ASC team by canhcutcon";
                //dattieu de cho file
                package.Workbook.Properties.Title = "Báo cáo thống kê";

                // tạo sheet đê thao tác
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                if (worksheet == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return false;
                }
                // đặt tên cho sheet
                worksheet.Name = "ASC sheet";

                //fontsize mặc định cho cả sheet
                worksheet.Cells.Style.Font.Size = 12;

                //Tạo danh sách colums
                string[] arrColumnHeader =
                {
                    "STT",
                    "Mã đơn hàng",
                    "Ngày bắt đầu",
                    "Ngày kết thúc",
                    "Tên khách hàng",
                    "Số diện thoại khách hàng",
                    "Nội dung",
                    "Mã nhân viên",
                    "Tên nhân viên",
                    "Thành tiền"
                };


                // lấy ra số lượng cột cần dùng dựa vào số lượng header
                var countColHeader = arrColumnHeader.Count();

                // font family mặc định cho cả sheet
                worksheet.Cells.Style.Font.Name = "Times New Roman";
                DateTime _today = DateTime.Now;
                worksheet.Cells["B4"].Value = "                           Thành phố Hồ Chí Minh, ngày " + _today.Day + " tháng " + _today.Month + " năm " + _today.Year + "";
                worksheet.Cells["E8"].Value = "                     Kỳ báo cáo đơn hàng : Từ " + tuNgay + " Tới " + denNgay;

                //Xuất dòng Tiêu đề của File báo cáo 
                
                worksheet.Cells["E6:G7"].Merge = true;
                worksheet.Cells["E6:G7"].Value = "BẢNG THỐNG KÊ ĐƠN HÀNG";
                worksheet.Cells["E6:G7"].AutoFitColumns(30, 50);
                worksheet.Column(3).Width = 20;
                worksheet.Column(4).Width = 30;
                worksheet.Cells["E6:G7"].Style.Font.Size = 24;
                worksheet.Cells["E6:G7"].Style.Font.Bold = true;
                worksheet.Cells["E6:G7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                var modelCells = worksheet.Cells["B14"];
                var modelRows = 13 + dgv.Rows.Count - 1;
                string modelRange = "B13:K" + modelRows.ToString();
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
                    cell.AutoFitColumns(30,50);
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
                }
               // var i = 13;
                var index = 1;
                decimal tongTien = 0;
                // Export data 
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    int j = 0;
                    worksheet.Cells["B" + (i + 13)].Value = index;
                    worksheet.Cells["C" + (i + 13)].Value = dgv[0, i].Value;
                    worksheet.Cells["D" + (i + 13)].Value = ((DateTime)dgv[1, i].Value).ToString("dd/MM/yyyy");// ngaybd
                    worksheet.Cells["E" + (i + 13)].Value = ((DateTime)dgv[2, i].Value).ToString("dd/MM/yyyy");//ngaykt
                    worksheet.Cells["F" + (i + 13)].Value = dgv[3, i].Value;
                    worksheet.Cells["G" + (i + 13)].Value = dgv[4, i].Value;
                    worksheet.Cells["H" + (i + 13)].Value = dgv[5, i].Value;
                    worksheet.Cells["I" + (i + 13)].Value = dgv[6, i].Value;
                    worksheet.Cells["J" + (i + 13)].Value = dgv[7, i].Value;
                    worksheet.Cells["K" + (i + 13)].Value = string.Format("{0:N0}", dgv[8, i].Value) + " VNĐ";
                    tongTien += (decimal)dgv[8, i].Value;
                    index++;
                }

                worksheet.Cells["C10"].Value = "Số lượng đơn hàng:";
                worksheet.Cells["C10"].Style.Font.Bold = true;
                worksheet.Cells["D10"].Value = dgv.Rows.Count;

                worksheet.Cells["F10"].Value = "Tổng tiền: ";
                worksheet.Cells["F10"].Style.Font.Bold = true;
                worksheet.Cells["G10"].Value = string.Format("{0:N0}", tongTien) + " VNĐ";

                Stream stream = File.Create(directoryPath);
                package.SaveAs(stream);
                stream.Close();
            }                                                                                                                                                                                                                                                                                                                                                                                    
            return true;

        }

    }
}
