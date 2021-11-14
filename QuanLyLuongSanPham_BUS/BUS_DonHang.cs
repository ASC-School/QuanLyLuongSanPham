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
        DAO_SanPham sanPhamDAO;
        public BUS_DonHang()
        {
            donHangDAO = new DAO_DonHang();
            chiTietDHDAO = new DAO_ChiTietDonHang();
            sanPhamDAO = new DAO_SanPham();
        }

        public IEnumerable<dynamic> getAllDonHang()
        {
            return donHangDAO.layDSDonHang();
        }

        public IEnumerable<object> getAllChiTietDonHang(string maDonHang)
        {
            return chiTietDHDAO.layDanhSachTimKiemCTDH(maDonHang);
        }

        public bool checkTonTaiDonHang(string maDonHang)
        {
            return donHangDAO.checkExist(maDonHang);
        }
        
        public DTO_DonHang getDonHang(string maDonHang)
        {
            return donHangDAO.timKiemDonHang(maDonHang);
        }

        public List<DTO_SanPham> getDSSanPham()
        {
            return sanPhamDAO.layToanBoDanhSachSanPham();
        }

        public decimal tongTienDonHang(string maDonHang)
        {
            return chiTietDHDAO.tongTienDonHang(maDonHang);
        }

    }
}
