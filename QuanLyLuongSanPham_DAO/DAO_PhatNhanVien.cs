using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_PhatNhanVien
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_PhatNhanVien()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public IEnumerable<PhatNhanVien> laySoLuongViPhamNV(string strMaNV, int iMaPhat)
        {
            IEnumerable<PhatNhanVien> phat = from phatNV in dataBase.PhatNhanViens
                                             where phatNV.maNhanVien.Equals(strMaNV) && phatNV.maMucPhat == iMaPhat
                                             select phatNV;
            return phat;
        }

        public IEnumerable<PhatNhanVien> laySoLuongViPhamNVNghiKhongPhep(string strMaNV, int iPhatNghiKhongPhep)
        {
            IEnumerable<PhatNhanVien> phatNghi = from phatNV in dataBase.PhatNhanViens
                                             where phatNV.maNhanVien.Equals(strMaNV) && phatNV.maMucPhat == iPhatNghiKhongPhep
                                                 select phatNV;
            return phatNghi;
        }
        public IEnumerable<PhatNhanVien> layThongTinPhat(string maNhanVien)
        {
            IEnumerable<PhatNhanVien> phat = from n in dataBase.PhatNhanViens
                                             where n.maNhanVien.Equals(maNhanVien)
                                             select n;
            return phat;
        }
        public IEnumerable<dynamic> layDSPhat()
        {
            IEnumerable<dynamic> list = from p in dataBase.PhatNhanViens
                                        join mp in dataBase.MucTienPhats on p.maMucPhat equals mp.soThuTu
                                        join nv in dataBase.NhanViens on p.maNhanVien equals nv.maNhanVien
                                        select new { maNhanVien = nv.maNhanVien, tenNhanVien = nv.tenNhanVien, maMucPhat = mp.soThuTu, tenMucPhat = mp.tenKhoanPhat, tienPhat = mp.mucTienPhat1, ngayPhat = p.ngayPhat, donVi = p.maDonVi,maPhat=p.maPhat };
            return list;
        }
        public IEnumerable<PhatNhanVien> layAllDS()
        {
            IEnumerable<PhatNhanVien> q = from n in dataBase.PhatNhanViens select n;
            return q;
        }
        public bool phatNV(DTO_PhatNhanVien phat)
        {
            string str = phat.MaPhat;
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                PhatNhanVien temp = new PhatNhanVien();
                temp.maPhat = phat.MaPhat;
                temp.maNhanVien = phat.MaNhanVien;
                temp.maMucPhat = phat.MaMucPhat;
                temp.ngayPhat = phat.NgayPhat;
                temp.maDonVi = phat.MaDonVi;
                dataBase.PhatNhanViens.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }    

        }
        public bool suaPhat(DTO_PhatNhanVien phatUpdate)
        {
            IQueryable<PhatNhanVien> phat = dataBase.PhatNhanViens.Where(x => x.maPhat.Equals(phatUpdate.MaPhat));
            if(phat.Count()>0)
            {
                phat.First().maPhat = phatUpdate.MaPhat;
                phat.First().maNhanVien = phatUpdate.MaNhanVien;
                phat.First().maMucPhat = phatUpdate.MaMucPhat;
                phat.First().ngayPhat = phatUpdate.NgayPhat;
                phat.First().maDonVi = phatUpdate.MaDonVi;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool xoaPhat(string maPhat)
        {
            PhatNhanVien temp = dataBase.PhatNhanViens.Where(x => x.maPhat.Equals(maPhat)).FirstOrDefault();
            if(temp!= null)
            {
                dataBase.PhatNhanViens.DeleteOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public PhatNhanVien checkIfExist(string strMaPhat)
        {
            PhatNhanVien temp = (from n in dataBase.PhatNhanViens where n.maPhat.Equals(strMaPhat) select n).FirstOrDefault();
            if (temp != null)
                return temp;
            return null;
        }
    }
}
