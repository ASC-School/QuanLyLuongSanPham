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
        /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
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
        public CaLamViec checkIfExist(string strMaCa)
        {
            CaLamViec temp = (from n in dataBase.CaLamViecs where n.maCa.Equals(strMaCa) select n).FirstOrDefault();
            if (temp != null)
                return temp;
            return null;
        }
        public bool xoaCa(string strMaCa)
        {
            CaLamViec pcTemp = dataBase.CaLamViecs.Where(x => x.maCa.Equals(strMaCa)).FirstOrDefault();
            if (pcTemp != null)
            {
                dataBase.CaLamViecs.DeleteOnSubmit(pcTemp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool themCa(DTO_CaLamViec ca)
        {
            string str = ca.MaCa;
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                CaLamViec temp = new CaLamViec();
                temp.maCa = ca.MaCa;
                temp.ca = ca.Ca;
                dataBase.CaLamViecs.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool suaThongTin(DTO_CaLamViec ca)
        {
            IQueryable<CaLamViec> pc = dataBase.CaLamViecs.Where(x => x.maCa.Equals(ca.MaCa));
            if (pc.Count() > 0)
            {
                pc.First().maCa = ca.MaCa;
                pc.First().ca = ca.Ca;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
