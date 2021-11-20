using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
namespace QuanLyLuongSanPham_BUS
{
    public class BUS_CongDoanSanXuat
    {
        DAO_CongDoanSanXuat cd = new DAO_CongDoanSanXuat();
        public BUS_CongDoanSanXuat()
        {
            this.cd = new DAO_CongDoanSanXuat();
        }
        public IEnumerable<CongDoanSanXuat> layDSCongDoan()
        {
            return cd.layDSCongDoan();
        }
    }
}
