using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_SanPhamSanXuat
    {
        string maLuongNhanVien, maCongDoan;
        int soLuongSanPhamLamDuoc;

        public DTO_SanPhamSanXuat() { }
        public DTO_SanPhamSanXuat(string maLuongNhanVien, string maCongDoan, int soLuongSanPhamLamDuoc)
        {
            this.MaLuongNhanVien = maLuongNhanVien;
            this.MaCongDoan = maCongDoan;
            this.SoLuongSanPhamLamDuoc = soLuongSanPhamLamDuoc;
        }

        public string MaLuongNhanVien { get => maLuongNhanVien; set => maLuongNhanVien = value; }
        public string MaCongDoan { get => maCongDoan; set => maCongDoan = value; }
        public int SoLuongSanPhamLamDuoc { get => soLuongSanPhamLamDuoc; set => soLuongSanPhamLamDuoc = value; }
    }
}
