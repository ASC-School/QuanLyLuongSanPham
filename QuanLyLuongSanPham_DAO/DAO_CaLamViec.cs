using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_DAO;
namespace QuanLyLuongSanPham_DAO
{
    public class DAO_CaLamViec
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_CaLamViec()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        List<DTO_CaLamViec> layDSCaLamViec()
        {
            var dataLst = dataBase.CaLamViecs.Select(p => p).OrderBy(p => p.maCa);

            List<DTO_CaLamViec> lstCaLamViec = new List<DTO_CaLamViec>();

            foreach(CaLamViec ca in dataLst)
            {
                DTO_CaLamViec tmp = new DTO_CaLamViec();
                tmp.MaCa = ca.maCa;
                tmp.Ca = ca.ca;
                lstCaLamViec.Add(tmp);
            }
            return lstCaLamViec;
        }
        public IEnumerable<CaLamViec> layCaLamViec()
        {
            IEnumerable <CaLamViec> q = from n in dataBase.CaLamViecs select n;
            return q;
        }


    }
}
