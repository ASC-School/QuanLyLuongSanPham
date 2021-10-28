using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_PhieuLuong
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_PhieuLuong()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

    }
}
