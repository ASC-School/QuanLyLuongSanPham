using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_ChiTietDonHang
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_ChiTietDonHang()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public IEnumerable<dynamic> layChiTietDHThuocDH()
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

        public IEnumerable<ChiTietDonHang> layThongTinCTDonHang()
        {
            IEnumerable<ChiTietDonHang> lstCTDH = from ctdh in dataBase.ChiTietDonHangs select ctdh;
            return lstCTDH;
        }

        public List<object> layDanhSachTimKiemCTDH(string maDonHang)
        {
            if (!maDonHang.Equals(""))
            {
                var dataLst = ( from donHang in dataBase.DonHangs
                          join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                          join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                          join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                          where donHang.maDonHang.Equals(maDonHang)
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
                List<object> lst = new List<object>();
                foreach(var item in dataLst)
                {
                    lst.Add(item);
                }
                return lst;
            }
            else
            {
                List<object> lst = new List<object>();
                return lst;
            }
        }

        //public bool themCTDonHang() {

        //}

    }
}
