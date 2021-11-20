using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_LuongNhanVienHanhChanh
    {
        DAO_LuongHanhChanh luongHanhChanh;
        public BUS_LuongNhanVienHanhChanh()
        {
            luongHanhChanh = new DAO_LuongHanhChanh();
        }
    }
}
