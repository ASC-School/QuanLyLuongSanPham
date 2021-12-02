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
    public class DTO_PhanQuyen
    {
        string tenPhanQuyen, maLoaiNhanVien;
        bool fullCN, xemThongTin, xoaThongTin, suaThongTin;

        public DTO_PhanQuyen()
        { }
        public DTO_PhanQuyen(string tenPhanQuyen, string maLoaiNhanVien, bool fullCN, bool xemThongTin, bool xoaThongTin, bool suaThongTin)
        {
            this.TenPhanQuyen = tenPhanQuyen;
            this.MaLoaiNhanVien = maLoaiNhanVien;
            this.FullCN = fullCN;
            this.XemThongTin = xemThongTin;
            this.XoaThongTin = xoaThongTin;
            this.SuaThongTin = suaThongTin;
        }

        public string TenPhanQuyen { get => tenPhanQuyen; set => tenPhanQuyen = value; }
        public string MaLoaiNhanVien { get => maLoaiNhanVien; set => maLoaiNhanVien = value; }
        public bool FullCN { get => fullCN; set => fullCN = value; }
        public bool XemThongTin { get => xemThongTin; set => xemThongTin = value; }
        public bool XoaThongTin { get => xoaThongTin; set => xoaThongTin = value; }
        public bool SuaThongTin { get => suaThongTin; set => suaThongTin = value; }
    }
}
