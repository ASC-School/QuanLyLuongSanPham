using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_TaiKhoan
    {
        string maNhanVien, tenTaiKhoan, maKhau, quyen;
        public DTO_TaiKhoan() { }
        public DTO_TaiKhoan(string maNhanVien, string tenTaiKhoan, string maKhau, string quyen)
        {
            this.maNhanVien = maNhanVien;
            this.TenTaiKhoan = tenTaiKhoan;
            this.MaKhau = maKhau;
            this.Quyen = quyen;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MaKhau { get => maKhau; set => maKhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}
