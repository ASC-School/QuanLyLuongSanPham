using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_PhieuChamCongCongNhan
    {
        string maPhieu, maCa, maNhanVien;
        DateTime ngayChamCong;
        bool diLam, diTre, trangThai;
        int iSoLuongSPLamTrongNgay;

        public DTO_PhieuChamCongCongNhan() { }
        public DTO_PhieuChamCongCongNhan(string maPhieu, string maCa, string maNhanVien, string maPhanCong, bool diLam, bool diTre, DateTime ngayChamCong)
        {
            this.maPhieu = maPhieu;
            this.maCa = maCa;
            this.maNhanVien = maNhanVien;
            this.diLam = diLam;
            this.diTre = diTre;
            this.ngayChamCong = ngayChamCong;
        }

        public string MaPhieu { get => maPhieu; set => maPhieu = value; }
        public string MaCa { get => maCa; set => maCa = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public DateTime NgayChamCong { get => ngayChamCong; set => ngayChamCong = value; }
        public bool DiLam { get => diLam; set => diLam = value; }
        public bool DiTre { get => diTre; set => diTre = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public int ISoLuongSPLamTrongNgay { get => iSoLuongSPLamTrongNgay; set => iSoLuongSPLamTrongNgay = value; }
    }
}
