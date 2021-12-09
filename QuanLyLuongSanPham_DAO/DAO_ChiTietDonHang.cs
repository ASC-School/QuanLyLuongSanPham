using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
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
        public IEnumerable<ChiTietDonHang> layChiTietDonHangTheoSanPham(string strMaSanPham)
        {
            IEnumerable<ChiTietDonHang> q = from ctdh in dataBase.ChiTietDonHangs 
                                            join dh in dataBase.DonHangs on ctdh.maDonHang equals dh.maDonHang
                                            where ctdh.maSanPham.Equals(strMaSanPham) && dh.trangThai==false
                                            select ctdh;
            return q;
        }

        public List<DTO_ChiTietDonHang> lstCTDH(string maDonHang)
        {
            if (!maDonHang.Equals(""))
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
                                   maNhanVien = nhanVien.maNhanVien,
                                   trangThai = donHang.trangThai,
                                   tinhTrangDonHanf = donHang.tinhTrangDonHang
                               }
                ).OrderBy(p => p.maDonHang);
                List<DTO_ChiTietDonHang> lst = new List<DTO_ChiTietDonHang>();
                foreach (var item in dataLst)
                {
                    DTO_ChiTietDonHang tmp = new DTO_ChiTietDonHang();
                    tmp.MaDonHang = item.maDonHang;
                    tmp.MaSanPham = item.maSanPham;
                    tmp.SoLuong = item.soLuong.Value;
                    tmp.DonGia = item.donGiaSanPham.Value;
                    lst.Add(tmp);
                }
                return lst;
            }
            return null;
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
                              maNhanVien = nhanVien.maNhanVien,
                              trangThai = donHang.trangThai,
                              tinhTrangDonHanf = donHang.tinhTrangDonHang
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
                return null;
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
                                   maNhanVien = nhanVien.maNhanVien,
                                   trangThai = donHang.trangThai,
                                   tinhTrangDonHanf = donHang.tinhTrangDonHang
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
        public bool timKiemChiTietDonHang(string maSanPham, string maDonHang)
        {
            if (!maDonHang.Equals(""))
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
                                   maNhanVien = nhanVien.maNhanVien,
                                   trangThai = donHang.trangThai,
                                   tinhTrangDonHanf = donHang.tinhTrangDonHang
                               }
                 ).OrderBy(p => p.maDonHang);
                List<object> lst = new List<object>();
                foreach (var item in dataLst)
                {
                    if (item.maSanPham.Equals(maSanPham))
                        return true;
                }
            }
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
            IQueryable<ChiTietDonHang> ctDonHang = dataBase.ChiTietDonHangs.Where(p => p.maDonHang == chiTiet.MaDonHang);
            IQueryable<ChiTietDonHang> chiTietDH = ctDonHang.Where(p => p.maSanPham == chiTiet.MaSanPham);
            if (chiTietDH.Count() >= 0)
            {
                chiTietDH.First().maSanPham = chiTiet.MaSanPham;
                chiTietDH.First().soLuongBan = chiTiet.SoLuong;
                chiTietDH.First().donGia = chiTiet.DonGia;
              
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }


        public bool tangSoLuongSanPPham(DTO_ChiTietDonHang chiTiet)
        {
            if (!checkExist(chiTiet.MaDonHang))
                return false;
            IQueryable<ChiTietDonHang> ctDonHang = dataBase.ChiTietDonHangs.Where(p => p.maDonHang == chiTiet.MaDonHang);
            
            if (ctDonHang.Count() >= 0)
            {
                ChiTietDonHang chitTietDH = ctDonHang.Where(p => p.maSanPham == chiTiet.MaSanPham).FirstOrDefault();
                int soLuong =chitTietDH.soLuongBan.Value + chiTiet.SoLuong;
                chitTietDH.soLuongBan = soLuong;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool xoaChiTietDonHang(string maDonHang,string maSanPham)
        {
            IQueryable<ChiTietDonHang> ctDonHang = dataBase.ChiTietDonHangs.Where(p => p.maDonHang == maDonHang);
            ChiTietDonHang chiTiet = ctDonHang.Where(p => p.maSanPham == maSanPham).FirstOrDefault();
            if (chiTiet != null)
            {
                dataBase.ChiTietDonHangs.DeleteOnSubmit(chiTiet);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }


    }
}
