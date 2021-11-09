using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_DonHang
    {
        DAO_DonHang donHangDAO;
        DAO_ChiTietDonHang chiTietDHDAO;
        public BUS_DonHang()
        {
            donHangDAO = new DAO_DonHang();
            chiTietDHDAO = new DAO_ChiTietDonHang();
        }

        public List<object> getAllDonHang()
        {
            return donHangDAO.layDSDonHang();
        }

        

    }
}
