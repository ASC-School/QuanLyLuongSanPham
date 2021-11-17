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
        public bool checkExist(string maDonHang)
        {
            DonHang donHang = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            if (donHang != null)
            {
                return true;
            }
            return false;
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

        public decimal tongTienDonHang(string maDonHang)
        {
            decimal tien = 0;
            if(!maDonHang.Equals(""))
            {
                var dataLst = (from donHang in dataBase.DonHangs
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
                foreach (var item in dataLst)
                {
                    tien = (decimal)(tien + item.thanhTien);
                }
            }
            return tien;
        }
        public bool timKiemChiTietDonHang(string maSanPham)
        {
            ChiTietDonHang chiTiet = dataBase.ChiTietDonHangs.Where(p => p.maSanPham == maSanPham).FirstOrDefault();
            if (chiTiet != null)
                return true;
            return false;
        }
        public bool themChiTietDonHang(string maDonHang, DTO_ChiTietDonHang chiTietDonHang)
        {
            if (!checkExist(maDonHang))
                return false;
            ChiTietDonHang chiTietDHTMP = new ChiTietDonHang();

            chiTietDHTMP.maDonHang = maDonHang;
            chiTietDHTMP.maSanPham = chiTietDonHang.MaSanPham;
            chiTietDHTMP.soLuongBan = chiTietDonHang.SoLuong;
            chiTietDHTMP.donGia = chiTietDonHang.DonGia;

            dataBase.ChiTietDonHangs.InsertOnSubmit(chiTietDHTMP);
            dataBase.SubmitChanges();
            return true;

        }

       public bool suaChiTietDonHang(DTO_ChiTietDonHang chiTiet)
        {
            if (!checkExist(chiTiet.MaDonHang))
                return false;
            IQueryable<ChiTietDonHang> ctDonHang = dataBase.ChiTietDonHangs.Where(p => p.maSanPham == chiTiet.MaSanPham);
            if(ctDonHang.Count() >= 0)
            {
                ctDonHang.First().maSanPham = chiTiet.MaSanPham;
                ctDonHang.First().soLuongBan = chiTiet.SoLuong;
                ctDonHang.First().donGia = chiTiet.DonGia;

                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public ChiTietDonHang getChiTietDonHang(string maSanPham)
        {
            IQueryable<ChiTietDonHang> ctDonHang = dataBase.ChiTietDonHangs.Where(p => p.maSanPham == maSanPham);
            return ctDonHang.First();
        }

        public bool tangSoLuongSanPPham(DTO_ChiTietDonHang chiTiet)
        {
            if (!checkExist(chiTiet.MaDonHang))
                return false;
            IQueryable<ChiTietDonHang> ctDonHang = dataBase.ChiTietDonHangs.Where(p => p.maSanPham == chiTiet.MaSanPham);
            if (ctDonHang.Count() >= 0)
            {
                int soLuong =ctDonHang.First().soLuongBan.Value + chiTiet.SoLuong;
                ctDonHang.First().soLuongBan = soLuong;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool xoaChiTietDonHang(string maSanPham)
        {
            ChiTietDonHang ctDonHang = dataBase.ChiTietDonHangs.Where(p => p.maSanPham == maSanPham).FirstOrDefault();
            if (ctDonHang != null)
            {
                dataBase.ChiTietDonHangs.DeleteOnSubmit(ctDonHang);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }


    }
}
