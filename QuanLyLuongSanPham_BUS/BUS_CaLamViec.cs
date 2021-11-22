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
    }
}
