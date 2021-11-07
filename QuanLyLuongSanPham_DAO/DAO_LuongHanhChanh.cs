using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_LuongHanhChanh
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_LuongHanhChanh()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
    }
}
