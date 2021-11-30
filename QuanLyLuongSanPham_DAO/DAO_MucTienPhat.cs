using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_MucTienPhat
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_MucTienPhat()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public IEnumerable<MucTienPhat> layThongTinPhat()
        {
            IEnumerable<MucTienPhat> phat = from n in dataBase.MucTienPhats select n;
            return phat;
        }
    }
}
