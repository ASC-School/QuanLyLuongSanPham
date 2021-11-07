using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_DonHang
    {
        string maDonHang,tenKhachHang,maNhanVien,noiDung,soDienThoaiKhachHang;
        DateTime ngayBatDau, ngayKetThuc;

        public DTO_DonHang() { }

        public DTO_DonHang(string maDonHang, string tenKhachHang, string maNhanVien, string noiDung, string soDienThoaiKhachHang, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.MaDonHang = maDonHang;
            this.TenKhachHang = tenKhachHang;
            this.maNhanVien = maNhanVien;
            this.noiDung = noiDung;
            this.SoDienThoaiKhachHang = soDienThoaiKhachHang;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public string MaDonHang { get => maDonHang; set => maDonHang = value; }
        public string SoDienThoaiKhachHang { get => soDienThoaiKhachHang; set => soDienThoaiKhachHang = value; }
    }
}
