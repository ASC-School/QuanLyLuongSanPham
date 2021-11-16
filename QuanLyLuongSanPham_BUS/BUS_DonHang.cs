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

        public bool themDonHang(DTO_DonHang donHang)
        {
            return donHangDAO.themDonHang(donHang);
        }

        public bool suaDonHang(DTO_DonHang donHang)
        {
            return donHangDAO.suaDonhang(donHang);
        }

        public bool xoaDonHang(string maDonHang)
        {
            return donHangDAO.xoaDonHang(maDonHang);
        }

        public bool themChiTietDonHang(string maDonHang, DTO_ChiTietDonHang ctdh)
        {
            return chiTietDHDAO.themChiTietDonHang(maDonHang, ctdh);
        }

        public bool suaChiTietDonHang( DTO_ChiTietDonHang ctdh)
        {
            return chiTietDHDAO.suaChiTietDonHang(ctdh);
        }

        public bool xoaChiTietDonHang(string maSanPham)
        {
            return chiTietDHDAO.xoaChiTietDonHang(maSanPham);
        }

        public bool checkExistChiTietDonHang(string maSanPham)
        {
            return chiTietDHDAO.timKiemChiTietDonHang(maSanPham);
        }

        public bool tangSoLuongSanPham(DTO_ChiTietDonHang chiTiet)
        {
            return chiTietDHDAO.tangSoLuongSanPPham(chiTiet);
        }
    }
}
