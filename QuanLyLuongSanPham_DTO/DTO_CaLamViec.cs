using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_CaLamViec
    {
        string maCa, ca;

        public DTO_CaLamViec() { 
        }
        public DTO_CaLamViec(string maCa, string ca)
        {
            this.MaCa = maCa;
            this.Ca = ca;
        }

        public string MaCa { get => maCa; set => maCa = value; }
        public string Ca { get => ca; set => ca = value; }
    }
}
