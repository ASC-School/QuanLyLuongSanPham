using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_ChiTietModel
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_ChiTietModel()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
    }
}
