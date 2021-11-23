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
        public bool ReportThongTinDonHang(DTO_DonHang donHang, string directoryPath)
        {
            var chiTietDonHangData = donHangBUS.getAllChiTietDonHang(donHang.MaDonHang);
            if (!chiTietDonHangData.Any())
                return false;

            // set duowng dan
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string dbPath = appPath + "\\FileBaoCao\\donHang.xlsx";
            string Paths = Path.Combine(appPath, dbPath);

            var fileExcelTemp = System.IO.Path.GetFullPath(Paths);

            FileInfo fileTemp = new FileInfo(fileExcelTemp);
            if(!fileTemp.Exists)
            {
                // neu file da ton tai
                throw new Exception("Mẫu ile báo cáo đang tồn tại!");
            }
            //xuat ra file exce;
            using (ExcelPackage package = new ExcelPackage(fileTemp))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];


            }                                                                                                                                                                                                                                                                                                                                                                                    
            return true;

        }

    }
}
