using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

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

        public List<DTO_DonHang > getAllDonHang()
        {
            return donHangDAO.layDSDonHang();
        }

        public IEnumerable<dynamic> getAllChiTietDonHang()
        {
            return chiTietDHDAO.layChiTietDHThuocDH();
        }
        


    }
}
