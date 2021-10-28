using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_NhanVien
    {
        string maNhanVien, tenNhanVien, gioiTinh, loaiNhanVien;
        DateTime ngaySinh, ngayBatDauCongTac;
        bool trangThai;
        public DTO_NhanVien() { }
        public DTO_NhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, string loaiNhanVien, DateTime ngaySinh, DateTime ngayBatDauCongTac,bool trangThai)
        {
            this.MaNhanVien = maNhanVien;
            this.TenNhanVien = tenNhanVien;
            this.GioiTinh = gioiTinh;
            this.LoaiNhanVien = loaiNhanVien;
            this.NgaySinh = ngaySinh;
            this.NgayBatDauCongTac = ngayBatDauCongTac;
            this.TrangThai = trangThai;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string LoaiNhanVien { get => loaiNhanVien; set => loaiNhanVien = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime NgayBatDauCongTac { get => ngayBatDauCongTac; set => ngayBatDauCongTac = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
