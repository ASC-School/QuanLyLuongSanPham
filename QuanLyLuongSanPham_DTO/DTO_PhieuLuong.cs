using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_PhieuLuong
    {
        string maPhieuLuong, maBangLuong, maNhanVien;
        DateTime ngayNhan;
        Decimal luongThucTe;
        public DTO_PhieuLuong() { }
        public DTO_PhieuLuong(string maPhieuLuong, string maBangLuong, string maNhanVien, DateTime ngayNhan, decimal luongThucTe)
        {
            this.MaPhieuLuong = maPhieuLuong;
            this.MaBangLuong = maBangLuong;
            this.MaNhanVien = maNhanVien;
            this.NgayNhan = ngayNhan;
            this.LuongThucTe = luongThucTe;
        }

        public string MaPhieuLuong { get => maPhieuLuong; set => maPhieuLuong = value; }
        public string MaBangLuong { get => maBangLuong; set => maBangLuong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayNhan { get => ngayNhan; set => ngayNhan = value; }
        public decimal LuongThucTe { get => luongThucTe; set => luongThucTe = value; }
    }
}
