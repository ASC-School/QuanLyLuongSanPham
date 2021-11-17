using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_KetNoi
    {
        QuanLyLuongSanPhamDataContext dt;
        public QuanLyLuongSanPhamDataContext getQuanLyLuongSanPham()
        {
            string str = @"Data Source=DESKTOP-50F1KAT\PEGUIN;Initial Catalog=QuanLyLuongSanPham;Integrated Security=True";
            dt = new QuanLyLuongSanPhamDataContext(str);
            dt.Connection.Open();
            return dt;
        }
    }
}
