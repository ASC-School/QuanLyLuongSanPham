using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_LuongHanhChanh
    {
        string maLuong, maNhanVien, maChungChi, maPhieuChamCong;
        int phuCap, tienUng,tienPhat, soNgayLamDuoc;
        float thue;
        decimal luongCoBan;
        public DTO_LuongHanhChanh() { }

        public DTO_LuongHanhChanh(string maLuong, string maNhanVien, string maChungChi, string maPhieuChamCong, int phuCap, int tienUng, int tienPhat, int soNgayLamDuoc, float thue, decimal luongCoBan)
        {
            this.maLuong = maLuong;
            this.maNhanVien = maNhanVien;
            this.maChungChi = maChungChi;
            this.maPhieuChamCong = maPhieuChamCong;
            this.phuCap = phuCap;
            this.tienUng = tienUng;
            this.TienPhat = tienPhat;
            this.SoNgayLamDuoc = soNgayLamDuoc;
            this.thue = thue;
            this.luongCoBan = luongCoBan;
        }

        public string MaLuong { get => maLuong; set => maLuong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaChungChi { get => maChungChi; set => maChungChi = value; }
        public string MaPhieuChamCong { get => maPhieuChamCong; set => maPhieuChamCong = value; }
        public int PhuCap { get => phuCap; set => phuCap = value; }
        public int TienUng { get => tienUng; set => tienUng = value; }
        public float Thue { get => thue; set => thue = value; }
        public decimal LuongCoBan { get => luongCoBan; set => luongCoBan = value; }
        public int TienPhat { get => tienPhat; set => tienPhat = value; }
        public int SoNgayLamDuoc { get => soNgayLamDuoc; set => soNgayLamDuoc = value; }
    }
}
