using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_LuongNhanVien
    {
        string maLuong, maNhanVien, maChungChi, maBangLuong, maPhieuChamCong;
        int phuCap, tienUng, soNgayLam;
        float thue;
        decimal luongCoBan;
        public DTO_LuongNhanVien() { }

        public DTO_LuongNhanVien(string maLuong, string maNhanVien, string maChungChi, string maBangLuong, string maPhieuChamCong, int phuCap, int tienUng, int soNgayLam, float thue, decimal luongCoBan)
        {
            this.maLuong = maLuong;
            this.maNhanVien = maNhanVien;
            this.maChungChi = maChungChi;
            this.maBangLuong = maBangLuong;
            this.maPhieuChamCong = maPhieuChamCong;
            this.phuCap = phuCap;
            this.tienUng = tienUng;
            this.soNgayLam = soNgayLam;
            this.thue = thue;
            this.luongCoBan = luongCoBan;
        }

        public string MaLuong { get => maLuong; set => maLuong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaChungChi { get => maChungChi; set => maChungChi = value; }
        public string MaBangLuong { get => maBangLuong; set => maBangLuong = value; }
        public string MaPhieuChamCong { get => maPhieuChamCong; set => maPhieuChamCong = value; }
        public int PhuCap { get => phuCap; set => phuCap = value; }
        public int TienUng { get => tienUng; set => tienUng = value; }
        public int SoNgayLam { get => soNgayLam; set => soNgayLam = value; }
        public float Thue { get => thue; set => thue = value; }
        public decimal LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
    }
}
