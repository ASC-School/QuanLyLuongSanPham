using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DTO_LoaiNhanVien
    {
        string maLoai, loaiNhanVien;
        bool trangThai;

        public DTO_LoaiNhanVien() { }
        public DTO_LoaiNhanVien(string maLoai, string loaiNhanVien, bool trangThai)
        {
            this.MaLoai = maLoai;
            this.LoaiNhanVien = loaiNhanVien;
            this.TrangThai = trangThai;
        }

        public string MaLoai { get => maLoai; set => maLoai = value; }
        public string LoaiNhanVien { get => loaiNhanVien; set => loaiNhanVien = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
