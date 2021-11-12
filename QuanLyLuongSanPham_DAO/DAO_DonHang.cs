using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_DonHang
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_DonHang()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public bool checkExist(string maDonHang)
        {
            DonHang donHang = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            if(donHang != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<dynamic> layDSDonHang()
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           select new {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien
                           }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        public DTO_DonHang timKiemDonHang(string maDonHang)
        {
            DonHang tmp = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            DTO_DonHang donHang = new DTO_DonHang();
            donHang.MaDonHang = tmp.maDonHang;
            donHang.NgayBatDau = DateTime.Parse(tmp.ngayBatDau.ToString());
            donHang.NgayKetThuc = DateTime.Parse(tmp.ngayKetThuc.ToString());
            donHang.TenKhachHang = tmp.tenKhachHang;
            donHang.SoDienThoaiKhachHang = tmp.soDienThoaiKhachHang;
            donHang.NoiDung = tmp.noiDung;
            donHang.MaNhanVien = tmp.maNhanVien;
            return donHang;
        }
        public bool suaDonhang(DTO_DonHang newDonHang)
        {
            IQueryable<DonHang> donHang = dataBase.DonHangs.Where(p => p.maDonHang == newDonHang.MaDonHang);
            if(donHang.Count() >= 0)
            {
                donHang.First().ngayBatDau = newDonHang.NgayBatDau;
                donHang.First().ngayKetThuc = newDonHang.NgayKetThuc;
                donHang.First().tenKhachHang = newDonHang.TenKhachHang;
                donHang.First().soDienThoaiKhachHang = newDonHang.SoDienThoaiKhachHang;
                donHang.First().noiDung = newDonHang.NoiDung;
                donHang.First().maNhanVien = newDonHang.MaNhanVien;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool themDonHang(DTO_DonHang donHang,DTO_ChiTietDonHang chiTietDonHang)
        {
            if (checkExist(donHang.MaDonHang))
                return false;
            DonHang donHangTMP = new DonHang();
            ChiTietDonHang chiTietDHTMP = new ChiTietDonHang();
            donHangTMP.maDonHang = donHang.MaDonHang;
            donHangTMP.ngayBatDau = donHang.NgayBatDau;
            donHangTMP.ngayKetThuc = donHang.NgayKetThuc;
            donHangTMP.tenKhachHang = donHang.TenKhachHang;
            donHangTMP.soDienThoaiKhachHang = donHang.SoDienThoaiKhachHang;
            donHangTMP.noiDung = donHang.NoiDung;
            donHangTMP.maNhanVien = donHang.MaNhanVien;

            chiTietDHTMP.maDonHang = chiTietDonHang.MaDonHang;
            chiTietDHTMP.maSanPham = chiTietDonHang.MaSanPham;
            chiTietDHTMP.soLuongBan = chiTietDonHang.SoLuong;
            chiTietDHTMP.donGia = chiTietDonHang.DonGia;

            dataBase.DonHangs.InsertOnSubmit(donHangTMP);
            dataBase.ChiTietDonHangs.InsertOnSubmit(chiTietDHTMP);
            dataBase.SubmitChanges();
            return true;

        }
         
        public bool xoaDonHang(string maDonHang)
        {
            DonHang donHangTmp = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            if(donHangTmp != null)
            {
                dataBase.DonHangs.DeleteOnSubmit(donHangTmp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
    
    }
}
