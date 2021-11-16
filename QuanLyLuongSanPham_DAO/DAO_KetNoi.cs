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
<<<<<<< HEAD
            string str = @"Data Source=DESKTOP-50F1KAT\PEGUIN;Initial Catalog=QuanLyLuongSanPham;Integrated Security=True";
=======
            string str = @"Data Source=LAPTOP-27HK0FFM\SQLEXPRESS;Initial Catalog=QuanLyLuongSanPham;Integrated Security=True";
>>>>>>> 37504ffd58136ff394fae7c126db076a03c98b0e
            dt = new QuanLyLuongSanPhamDataContext(str);
            dt.Connection.Open();
            return dt;
        }
    }
}
