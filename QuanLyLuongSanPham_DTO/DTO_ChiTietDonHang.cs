using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_ChiTietDonHang
    {
        string maDonHang, maSanPham;
        int soLuong;
        decimal donGia;

        public DTO_ChiTietDonHang() { }
        public DTO_ChiTietDonHang(string maDonHang, string maSanPham, int soLuong, decimal donGia)
        {
            this.maDonHang = maDonHang;
            this.maSanPham = maSanPham;
            this.soLuong = soLuong;
            this.donGia = donGia;
        }

        public string MaDonHang { get => maDonHang; set => maDonHang = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal ThanhTien { get => donGia * soLuong; }
    }
}
