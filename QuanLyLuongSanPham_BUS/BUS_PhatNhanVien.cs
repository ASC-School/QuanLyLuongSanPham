using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_BUS;
using QuanLyLuongSanPham_DTO;

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

        public IEnumerable<PhatNhanVien> laySoLuongViPhamNghiKhongPhep(string strMaNV, int iPhatNghiKhongPhep)
        {
            return daoPhatNV.laySoLuongViPhamNVNghiKhongPhep(strMaNV, iPhatNghiKhongPhep);
        }
        public IEnumerable<PhatNhanVien> layThongTinPhat(string maNhanVien)
        {
            return daoPhatNV.layThongTinPhat(maNhanVien);
        }
        public IEnumerable<dynamic> layDSPhat()
        {
            return daoPhatNV.layDSPhat();
        }
        public IEnumerable<PhatNhanVien> layAllDS()
        {
            return daoPhatNV.layAllDS();
        }
        public bool phatNv(DTO_PhatNhanVien phat)
        {
            return daoPhatNV.phatNV(phat);
        }
        public bool suaPhat(DTO_PhatNhanVien phat)
        {
            return daoPhatNV.suaPhat(phat);
        }
        public bool xoaPhat(string strMaPhat)
        {
            return daoPhatNV.xoaPhat(strMaPhat);
        }
    }
}
