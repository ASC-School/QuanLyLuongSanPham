using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
    public class DTO_DonHang
    {
        string maDonHang,tenKhachHang,maNhanVien,noiDung,soDienThoaiKhachHang;
        DateTime ngayBatDau, ngayKetThuc;
        bool trangThai, tinhTrangDonHang;

        public DTO_DonHang() { }

        public DTO_DonHang(string maDonHang, string tenKhachHang, string maNhanVien, string noiDung, string soDienThoaiKhachHang, DateTime ngayBatDau, DateTime ngayKetThuc,bool trangThai,bool tinhTrangDonHang)
        {
            this.MaDonHang = maDonHang;
            this.TenKhachHang = tenKhachHang;
            this.maNhanVien = maNhanVien;
            this.noiDung = noiDung;
            this.SoDienThoaiKhachHang = soDienThoaiKhachHang;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.TrangThai = trangThai;
            this.TinhTrangDonHang = tinhTrangDonHang;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string MaDonHang { get => maDonHang; set => maDonHang = value; }
        public string SoDienThoaiKhachHang { get => soDienThoaiKhachHang; set => soDienThoaiKhachHang = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public bool TinhTrangDonHang { get => tinhTrangDonHang; set => tinhTrangDonHang = value; }
    }
}
