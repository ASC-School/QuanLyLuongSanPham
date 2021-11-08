using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_ChiTietDonHang
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_ChiTietDonHang()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public IEnumerable<dynamic> getChiTietDHThuocDH()
        {
            IEnumerable<dynamic> q;
            q = (from donHang in dataBase.DonHangs
                 join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                 join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                 join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                 select new
                 {
                     maDonHang = donHang.maDonHang,
                     tenKhachHang = donHang.tenKhachHang,
                     soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                     maSanPham = chiTietDonHang.maSanPham,
                     tenSanPham = sanPham.tenSanPham,
                     soLuong = chiTietDonHang.soLuongBan,
                     donGiaSanPham = sanPham.giaBan,
                     thanhTien = (chiTietDonHang.soLuongBan * chiTietDonHang.donGia),
                     maNhanVien = nhanVien.maNhanVien
                 }
                ).OrderBy(p => p.maDonHang);
            return q;
        }
    }
}
