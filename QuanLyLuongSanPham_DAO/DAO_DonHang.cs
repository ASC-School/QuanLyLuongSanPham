using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_DonHang
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_DonHang()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        //public List<object> layDSDonHang()
        //{
        //    var dataLst = dataBase.DonHangs.Select(p => p).OrderBy(p => p.maDonHang);

        //    return 
        //}
    }
}
