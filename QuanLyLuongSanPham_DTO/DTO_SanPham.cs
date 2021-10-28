using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
   public class DTO_SanPham
    {
        string maSanPham, tenSanPham;
        int namSanXuat;
        decimal giaBan;
        bool trangThai;

        public DTO_SanPham() { }
        public DTO_SanPham(string maSanPham, string tenSanPham, int namSanXuat, decimal giaBan, bool trangThai)
        {
            this.MaSanPham = maSanPham;
            this.TenSanPham = tenSanPham;
            this.NamSanXuat = namSanXuat;
            this.GiaBan = giaBan;
            this.TrangThai = trangThai;
        }

        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int NamSanXuat { get => namSanXuat; set => namSanXuat = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
