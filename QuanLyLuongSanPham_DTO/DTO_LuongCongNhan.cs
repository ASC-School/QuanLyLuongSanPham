using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_LuongCongNhan
    {
        string maLuong, maNhanVien, maPhieuChamCong;
        float thue;
        int phuCap, tienUng, tienPhat, soLuongSanPhamLamDuoc, maCongDoan;
        int thangLuong, namLuong;

        public DTO_LuongCongNhan() { }
        public DTO_LuongCongNhan(string maLuong, string maNhanVien, string maPhieuChamCong, float thue, int phuCap, int tienUng, int tienPhat, int soLuongSanPhamLamDuoc, int maCongDoan, int thangLuong, int namLuong)
        {
            this.MaLuong = maLuong;
            this.MaNhanVien = maNhanVien;
            this.MaPhieuChamCong = maPhieuChamCong;
            this.Thue = thue;
            this.PhuCap = phuCap;
            this.TienUng = tienUng;
            this.TienPhat = tienPhat;
            this.SoLuongSanPhamLamDuoc = soLuongSanPhamLamDuoc;
            this.MaCongDoan = maCongDoan;
            this.thangLuong = thangLuong;
            this.namLuong = namLuong;
        }

        public string MaLuong { get => maLuong; set => maLuong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaPhieuChamCong { get => maPhieuChamCong; set => maPhieuChamCong = value; }
        public float Thue { get => thue; set => thue = value; }
        public int PhuCap { get => phuCap; set => phuCap = value; }
        public int TienUng { get => tienUng; set => tienUng = value; }
        public int TienPhat { get => tienPhat; set => tienPhat = value; }
        public int SoLuongSanPhamLamDuoc { get => soLuongSanPhamLamDuoc; set => soLuongSanPhamLamDuoc = value; }
        public int MaCongDoan { get => maCongDoan; set => maCongDoan = value; }
        public int ThangLuong { get => thangLuong; set => thangLuong = value; }
        public int NamLuong { get => namLuong; set => namLuong = value; }
    }
}
