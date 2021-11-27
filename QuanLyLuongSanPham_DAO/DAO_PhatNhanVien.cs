using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
