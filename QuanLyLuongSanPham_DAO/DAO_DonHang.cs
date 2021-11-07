using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanLyLuongSanPham_DAO
{
    public class DAO_DonHang
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_DonHang()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
    }
}
