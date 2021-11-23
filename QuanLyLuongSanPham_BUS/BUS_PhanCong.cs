using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_PhanCong
    {
        DAO_PhanCong daoPhanCong;
        public BUS_PhanCong()
        {
            this.daoPhanCong = new DAO_PhanCong();
        }
        public IEnumerable<dynamic> layDSPhanCong()
        {
            return daoPhanCong.layDSPhanCong();
        }
    }
}
