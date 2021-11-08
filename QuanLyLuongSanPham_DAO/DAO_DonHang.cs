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

        private bool checkExist(string maDonHang)
        {
            DonHang donHang = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            if(donHang != null)
            {
                return true;
            }
            return false;
        }

        public List<DTO_DonHang> layDSDonHang()
        {
            var dataLst = dataBase.DonHangs.Select(p => p).OrderBy(p => p.maDonHang);

            List<DTO_DonHang> lstDonHang = new List<DTO_DonHang>();
            foreach(DonHang dh in dataLst)
            {
                DTO_DonHang tmp = new DTO_DonHang();
                tmp.MaDonHang = dh.maDonHang;
                tmp.NgayBatDau = (DateTime)dh.ngayBatDau;
                tmp.NgayKetThuc = (DateTime)dh.ngayKetThuc;
                tmp.TenKhachHang = dh.tenKhachHang;
                tmp.SoDienThoaiKhachHang = dh.soDienThoaiKhachHang;
                tmp.NoiDung = dh.noiDung;
                tmp.MaNhanVien = dh.maNhanVien;
                lstDonHang.Add(tmp);
            }
            return lstDonHang;
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
