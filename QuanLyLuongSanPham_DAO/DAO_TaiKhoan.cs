using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_TaiKhoan
    {
        QuanLyLuongSanPhamDataContext dataBase;

        public DAO_TaiKhoan()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public TaiKhoan checkIfExist(string username)
        {
            TaiKhoan temp = (from n in dataBase.TaiKhoans where n.username.Equals(username) select n).FirstOrDefault();
            if (temp != null)
                return temp;
            return null;
        }

        public bool suaThongTinTaiKhoan(DTO_TaiKhoan tkUpdoate)
        {
            IQueryable<TaiKhoan> cd = dataBase.TaiKhoans.Where(x => x.username.Equals(tkUpdoate.TenTaiKhoan));
            if (cd.Count() > 0)
            {
                cd.First().maNhanVien = tkUpdoate.MaNhanVien;
                cd.First().username = tkUpdoate.TenTaiKhoan;
                cd.First().passwords = tkUpdoate.MatKhau;
                cd.First().quyen = tkUpdoate.Quyen;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        List<DTO_TaiKhoan> layToanBoDanhSachTaiKhoanNhanvien()
        {
            var dataLst = dataBase.TaiKhoans.Select(p => p).OrderBy(p => p.username);

            List<DTO_TaiKhoan> lst = new List<DTO_TaiKhoan>();

            foreach (TaiKhoan tai_khoan in dataLst)
            {
                DTO_TaiKhoan tmp = new DTO_TaiKhoan();
                tmp.MaNhanVien = tai_khoan.maNhanVien;
                tmp.TenTaiKhoan = tai_khoan.username;
                tmp.MatKhau = tai_khoan.passwords;
                tmp.Quyen = tai_khoan.quyen;
                lst.Add(tmp);
            }
            return lst;
        }

        public DTO_TaiKhoan layTaiKhoanTheoTenTaiKhoan(string tenTaiKhoan)
        {
            TaiKhoan dataLst = dataBase.TaiKhoans.Where(p => p.username == tenTaiKhoan).FirstOrDefault();
            if(dataLst != null)
            {
                DTO_TaiKhoan tmp = new DTO_TaiKhoan();
                tmp.MaNhanVien = dataLst.maNhanVien;
                tmp.TenTaiKhoan = dataLst.username;
                tmp.MatKhau = dataLst.passwords;
                tmp.Quyen = dataLst.quyen;
                return tmp;
            }
            return null;
        }

        public IEnumerable<LoaiNhanVien> layLoaiNVTheoMa(string maNV)
        {
            IEnumerable<LoaiNhanVien> loaiNVTheoMa = from lnv in dataBase.LoaiNhanViens
                                                     join nv in dataBase.NhanViens
                                                     on lnv.maLoai equals nv.maLoai
                                                    where nv.maNhanVien.Equals(maNV)
                                                    select lnv;
            return loaiNVTheoMa;
        }

        public IEnumerable<NhanVien> layNVTheoMa(string maNV)
        {
            IEnumerable<NhanVien> nvTheoMa = from nv in dataBase.NhanViens
                                               where nv.maNhanVien.Equals(maNV)
                                               select nv;
            return nvTheoMa;
        }

        public IEnumerable<TaiKhoan> layDSTK()
        {
            IEnumerable<TaiKhoan> dsTKNV = from tk in dataBase.TaiKhoans
                                            select tk;
            return dsTKNV;
        }
    }
}
