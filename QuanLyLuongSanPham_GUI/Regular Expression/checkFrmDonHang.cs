using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QuanLyLuongSanPham_GUI.Regular_Expression
{
    public class checkFrmDonHang
    {
        public bool checkMaDonHang(string maDonHang)
        {
            return Regex.Match(maDonHang, @"^DH\d{3}$").Success;
        }

        public bool checkMaNhanVien(string maNhanVien)
        {
            return Regex.Match(maNhanVien, @"^NV\d{3}$").Success;
        }



    }
}
