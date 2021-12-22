using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_CaLamViec
    {
        DAO_CaLamViec caLamViec;
        public BUS_CaLamViec()
        {
            this.caLamViec = new DAO_CaLamViec();
        }
        public IEnumerable<CaLamViec> layDSCa()
        {
            return caLamViec.layCaLamViec();
        }
        public bool themCa (QuanLyLuongSanPham_DTO.DTO_CaLamViec ca)
        {
            return caLamViec.themCa(ca);
        }
        public bool suaCa(QuanLyLuongSanPham_DTO.DTO_CaLamViec ca)
        {
            return caLamViec.suaThongTin(ca);
        }
        public bool xoaCa(string strMaCa)
        {
            return caLamViec.xoaCa(strMaCa);
        }
    }
}
