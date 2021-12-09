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
    public class DTO_SanPhamSanXuat
    {
        string maSanPhamSanXuat, maDonHang, tenSanPham;
        int soLuongSanXuat;
        bool trangThai;

        public DTO_SanPhamSanXuat() { }
        public DTO_SanPhamSanXuat(string maSanPhamSanXuat, string maDonHang, string tenSanPham, int soLuongSanXuat, bool trangThai)
        {
            this.MaSanPhamSanXuat = maSanPhamSanXuat;
            this.MaDonHang = maDonHang;
            this.TenSanPham = tenSanPham;
            this.SoLuongSanXuat = soLuongSanXuat;
            this.TrangThai = trangThai;
        }

        public string MaSanPhamSanXuat { get => maSanPhamSanXuat; set => maSanPhamSanXuat = value; }
        public string MaDonHang { get => maDonHang; set => maDonHang = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int SoLuongSanXuat { get => soLuongSanXuat; set => soLuongSanXuat = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
