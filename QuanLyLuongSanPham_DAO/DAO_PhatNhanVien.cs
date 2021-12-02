using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Trần Văn Sỹ,Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
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
                                        select new { maNhanVien = nv.maNhanVien, tenNhanVien = nv.tenNhanVien, maMucPhat = mp.soThuTu, tenMucPhat = mp.tenKhoanPhat, tienPhat = mp.mucTienPhat1, ngayPhat = p.ngayPhat, donVi = p.maDonVi };
            return list;
        }
        public IEnumerable<PhatNhanVien> layAllDS()
        {
            IEnumerable<PhatNhanVien> q = from n in dataBase.PhatNhanViens select n;
            return q;
        }
    }
}
