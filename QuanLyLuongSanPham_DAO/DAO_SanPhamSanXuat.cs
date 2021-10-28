using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_SanPhamSanXuat
    {
        QuanLyLuongSanPhamDataContext dataBase;

        public DAO_SanPhamSanXuat()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }


    }
}
