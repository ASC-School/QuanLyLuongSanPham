using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_DonHang
    {
        string maDonHang,maNhanVien,noiDung;
        DateTime ngayBatDau, ngayKetThuc;

        public DTO_DonHang() { }
        public DTO_DonHang(string maDonHang, string maNhanVien, string noiDung, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            this.MaDonHang = maDonHang;
            this.MaNhanVien = maNhanVien;
            this.NoiDung = noiDung;
            this.NgayBatDau = ngayBatDau;
            this.NgayKetThuc = ngayKetThuc;
        }

        public string MaDonHang { get => maDonHang; set => maDonHang = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string NoiDung { get => noiDung; set => noiDung = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
    }
}
