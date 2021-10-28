using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_LoaiBangLuong
    {
        string maLoaiBangLuong, tenLoaiBangLuong;

        public DTO_LoaiBangLuong() { }
        public DTO_LoaiBangLuong(string maLoaiBangLuong, string tenLoaiBangLuong)
        {
            this.MaLoaiBangLuong = maLoaiBangLuong;
            this.TenLoaiBangLuong = tenLoaiBangLuong;
        }

        public string MaLoaiBangLuong { get => maLoaiBangLuong; set => maLoaiBangLuong = value; }
        public string TenLoaiBangLuong { get => tenLoaiBangLuong; set => tenLoaiBangLuong = value; }
    }
}
