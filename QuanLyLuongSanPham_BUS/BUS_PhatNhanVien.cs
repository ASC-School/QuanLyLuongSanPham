using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_BUS;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_PhatNhanVien
    {
        DAO_PhatNhanVien daoPhatNV;
        public BUS_PhatNhanVien()
        {
            daoPhatNV = new DAO_PhatNhanVien();
        }

        public IEnumerable<PhatNhanVien> laySoLuongViPhamDiTre(string strMaNV, int iMaPhat)
        {
            return daoPhatNV.laySoLuongViPhamNV(strMaNV, iMaPhat);
        }
    }
}
