using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    /**
     * Tác giả: Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DTO_CongDoanSanXuat
    {
        int soThuTu;
        string tenCongDoan;
        string maSanPham;
        decimal donGia;
        int soLuongSanPhamSanXuat;

        public DTO_CongDoanSanXuat() { }
        public DTO_CongDoanSanXuat(int soThuTu, string tenCongDoan, string maSanPham, decimal donGia,int soLuongSanPhamSanXuat)
        {
            this.SoThuTu = soThuTu;
            this.TenCongDoan = tenCongDoan;
            this.MaSanPham = maSanPham;
            this.DonGia = donGia;
            this.SoLuongSanPhamSanXuat = soLuongSanPhamSanXuat;
        }

        public int SoThuTu { get => soThuTu; set => soThuTu = value; }
        public string TenCongDoan { get => tenCongDoan; set => tenCongDoan = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public int SoLuongSanPhamSanXuat { get => soLuongSanPhamSanXuat; set => soLuongSanPhamSanXuat = value; }
    }
}
