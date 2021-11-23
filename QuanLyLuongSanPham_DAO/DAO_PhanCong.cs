using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_PhanCong
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_PhanCong()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public IEnumerable<dynamic> layDSPhanCong()
        {
            IEnumerable<dynamic> q;
            q = (from nv in dataBase.NhanViens
                 join pc in dataBase.PhanCongs on nv.maNhanVien equals pc.maNhanVien
                 join cd in dataBase.CongDoanSanXuats on pc.maCongDoan equals cd.soThuTu
                 join ca in dataBase.CaLamViecs on pc.maCa equals ca.maCa
                 select new { maPhanCong = pc.maPhanCong, maNhanVien = nv.maNhanVien, tenNhanVien = nv.tenNhanVien, maCongDoan = pc.maCongDoan, tenCongDoan = cd.tenCongDoan,maCa=pc.maCa,tenCa=ca.ca,ngayLam = pc.ngayLam });
            return q;
        }
        public bool phanCong(DTO_PhanCong pc)
        {
            string str = pc.MaPhanCong;
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                PhanCong temp = new PhanCong();
                temp.maPhanCong = pc.MaPhanCong;
                temp.maNhanVien = pc.MaNhanVien;
                temp.maCongDoan = pc.MaCongDoan;
                temp.maCa = pc.MaCa;
                temp.ngayLam = pc.NgayLam;
                dataBase.PhanCongs.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
        }
        public bool suaThongTinPhanCong(DTO_PhanCong pcUpdate)
        {
            IQueryable<PhanCong> pc = dataBase.PhanCongs.Where(x => x.maPhanCong.Equals(pcUpdate.MaPhanCong));
            if (pc.Count() > 0)
            {
                pc.First().maPhanCong = pcUpdate.MaPhanCong;
                pc.First().maNhanVien = pcUpdate.MaNhanVien;
                pc.First().maCongDoan = pcUpdate.MaCongDoan;
                pc.First().maCa = pcUpdate.MaCa;
                pc.First().ngayLam = pcUpdate.NgayLam;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool xoaPhanCong(string maPhanCong)
        {
            PhanCong pcTemp = dataBase.PhanCongs.Where(x => x.maPhanCong.Equals(maPhanCong)).FirstOrDefault();
            if (pcTemp != null)
            {
                dataBase.PhanCongs.DeleteOnSubmit(pcTemp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }     
        public PhanCong checkIfExist(string strMaPhanCong)
        {
            PhanCong temp = (from n in dataBase.PhanCongs where n.maPhanCong.Equals(strMaPhanCong) select n).FirstOrDefault();
            if (temp != null)
                return temp;
            return null;
        }
    }
}
