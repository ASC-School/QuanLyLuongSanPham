using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_CongDoanSanXuat
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_CongDoanSanXuat()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public IEnumerable<CongDoanSanXuat> layDSCongDoan()
        {
            IEnumerable<CongDoanSanXuat> q = from n in dataBase.CongDoanSanXuats select n;
            return q;
        }
    }
}
