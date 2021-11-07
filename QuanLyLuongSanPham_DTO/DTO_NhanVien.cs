using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_NhanVien
    {
        string maNhanVien, tenNhanVien, gioiTinh, loaiNhanVien,soDienThoai,diaChi, maLoai;
        DateTime ngaySinh, ngayBatDauCongTac;
        bool trangThai;
        byte avatar;                                                                                                                                                                                                                         
        public DTO_NhanVien() { }

        public DTO_NhanVien(string maNhanVien, string tenNhanVien, string gioiTinh, string loaiNhanVien, string soDienThoai, string diaChi, string maLoai, DateTime ngaySinh, DateTime ngayBatDauCongTac, bool trangThai, byte avatar)
        {
            this.maNhanVien = maNhanVien;
            this.tenNhanVien = tenNhanVien;
            this.gioiTinh = gioiTinh;
            this.loaiNhanVien = loaiNhanVien;
            this.soDienThoai = soDienThoai;
            this.DiaChi = diaChi;
            this.MaLoai = maLoai;
            this.ngaySinh = ngaySinh;
            this.ngayBatDauCongTac = ngayBatDauCongTac;
            this.trangThai = trangThai;
            this.Avatar = avatar;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenNhanVien { get => tenNhanVien; set => tenNhanVien = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string LoaiNhanVien { get => loaiNhanVien; set => loaiNhanVien = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime NgayBatDauCongTac { get => ngayBatDauCongTac; set => ngayBatDauCongTac = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
        public byte Avatar { get => avatar; set => avatar = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string MaLoai { get => maLoai; set => maLoai = value; }
    }
}
