using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_DonViQuanLy
    {
        string maDonVi, tenBoPhan,maLoaiNhanVien;
        int soLuongNhanVien;

        public DTO_DonViQuanLy() { }
        public DTO_DonViQuanLy(string maDonVi, string tenBoPhan, string maLoaiNhanVien, int soLuongNhanVien)
        {
            this.MaDonVi = maDonVi;
            this.TenBoPhan = tenBoPhan;
            this.MaLoaiNhanVien = maLoaiNhanVien;
            this.SoLuongNhanVien = soLuongNhanVien;
        }

        public string MaDonVi { get => maDonVi; set => maDonVi = value; }
        public string TenBoPhan { get => tenBoPhan; set => tenBoPhan = value; }
        public string MaLoaiNhanVien { get => maLoaiNhanVien; set => maLoaiNhanVien = value; }
        public int SoLuongNhanVien { get => soLuongNhanVien; set => soLuongNhanVien = value; }
    }
}
