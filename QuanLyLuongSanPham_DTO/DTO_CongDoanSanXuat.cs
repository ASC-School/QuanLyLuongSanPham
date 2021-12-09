using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    /**
     * Tác giả: Trần Văn Sỹ,Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DTO_CongDoanSanXuat
    {
        int soThuTu;
        string tenCongDoan;
        string maSanPhamSanXuat;
        decimal donGia;
        string thuTuCongDoan,maRangBuoc;
        DateTime ngayBatDau, ngayKetThuc;
        bool trangThai;
        public DTO_CongDoanSanXuat() { }

        public DTO_CongDoanSanXuat(int soThuTu, string tenCongDoan, string maSanPhamSanXuat, decimal donGia, string thuTuCongDoan, string maRangBuoc, DateTime ngayBatDau, DateTime ngayKetThuc, bool trangThai)
        {
            this.SoThuTu = soThuTu;
            this.TenCongDoan = tenCongDoan;
            this.MaSanPhamSanXuat = maSanPhamSanXuat;
            this.DonGia = donGia;
            this.ThuTuCongDoan = thuTuCongDoan;
            this.MaRangBuoc = maRangBuoc;
            this.NgayBatDau = ngayBatDau;
            this.NgayKetThuc = ngayKetThuc;
            this.TrangThai = trangThai;
        }

        public int SoThuTu { get => soThuTu; set => soThuTu = value; }
        public string TenCongDoan { get => tenCongDoan; set => tenCongDoan = value; }
        public string MaSanPhamSanXuat { get => maSanPhamSanXuat; set => maSanPhamSanXuat = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public string ThuTuCongDoan { get => thuTuCongDoan; set => thuTuCongDoan = value; }
        public string MaRangBuoc { get => maRangBuoc; set => maRangBuoc = value; }
        public DateTime NgayBatDau { get => ngayBatDau; set => ngayBatDau = value; }
        public DateTime NgayKetThuc { get => ngayKetThuc; set => ngayKetThuc = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
