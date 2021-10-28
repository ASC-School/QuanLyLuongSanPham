using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_BangLuong
    {
        string maBangLuong, tenBang, maDonVi, maLoaiBangLuong;

        public DTO_BangLuong() { }
        public DTO_BangLuong(string maBangLuong, string tenBang, string maDonVi, string maLoaiBangLuong)
        {
            this.MaBangLuong = maBangLuong;
            this.TenBang = tenBang;
            this.MaDonVi = maDonVi;
            this.MaLoaiBangLuong = maLoaiBangLuong;
        }

        public string MaBangLuong { get => maBangLuong; set => maBangLuong = value; }
        public string TenBang { get => tenBang; set => tenBang = value; }
        public string MaDonVi { get => maDonVi; set => maDonVi = value; }
        public string MaLoaiBangLuong { get => maLoaiBangLuong; set => maLoaiBangLuong = value; }
    }
}
