using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_GUI.Regular_Expression
{
    public class regularExpression
    {
        public bool checkMaDonHang(string maDonHang)
        {
            return Regex.Match(maDonHang, @"^DH\d{3}$").Success;
        }
        public bool checkSoDienThoai(string soDienThoai)
        {
            return Regex.Match(soDienThoai, @"^([0][0-9]{2}[0-9]{7})$").Success;
        }
        public bool checkMaNhanVien(string maNV)
        {
            return Regex.Match(maNV, @"^NV\d+$").Success;
        }
        public  bool checkDiaChi(string diaChi)
        {
            return Regex.Match(diaChi, @"^[^{}+=?!@#$%`~^&\*()]+$").Success;
        }
        public bool checkName(string name)
        {
            return Regex.Match(name, @"^([A-Z][a-zA-Z]+(\s[A-Z][a-zA-Z]+)+)$").Success;
        }
    }
}
