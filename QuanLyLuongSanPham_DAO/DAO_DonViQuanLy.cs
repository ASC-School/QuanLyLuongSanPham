using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_DonViQuanLy
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_DonViQuanLy()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public IEnumerable<DonViQuanLy> layDanhSachDonViQUanLy()
        {
            IEnumerable<DonViQuanLy> q = from n in dataBase.DonViQuanLies select n;
            return q;
        }
    }
}
