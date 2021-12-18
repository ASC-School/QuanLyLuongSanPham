using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Võ Thị Trà Giang,Đinh Quang Huy,Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 25/10/2021
     */
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

        public bool checkIfExistNV(string maNhanVien)
        {
            TaiKhoan temp = (from n in dataBase.TaiKhoans where n.maNhanVien.Equals(maNhanVien) select n).FirstOrDefault();
            if (temp != null)
                return true;
            return false;
        }

        
        public IEnumerable<dynamic> layDSTKChuaDuocPhanQuyen()
        {
            IEnumerable<dynamic> lstTaiKhoan = from taiKhoan in dataBase.TaiKhoans
                                               join nhanVien in dataBase.NhanViens on taiKhoan.maNhanVien equals nhanVien.maNhanVien
                                               where taiKhoan.quyen == null
                                               select new
                                               {
                                                   tenTaiKhoan = taiKhoan.username,
                                                   maNhanVien = taiKhoan.maNhanVien,
                                                   tenNhanVien = nhanVien.tenNhanVien,
                                                   loaiNhanVien = nhanVien.LoaiNhanVien
                                               };
            if (lstTaiKhoan != null)
                return lstTaiKhoan;
            return null;
        }

        public IEnumerable<dynamic> layDSTKPhanQuyen()
        {
            IEnumerable<dynamic> lstTaiKhoan = from taiKhoan in dataBase.TaiKhoans
                                               join nhanVien in dataBase.NhanViens on taiKhoan.maNhanVien equals nhanVien.maNhanVien
                                               where taiKhoan.quyen != null
                                               select new
                                               {
                                                   tenTaiKhoan = taiKhoan.username,
                                                   maNhanVien = taiKhoan.maNhanVien,
                                                   tenNhanVien = nhanVien.tenNhanVien,
                                                   loaiNhanVien = nhanVien.LoaiNhanVien,
                                                   quyen = taiKhoan.quyen
                                               };
            if (lstTaiKhoan != null)
                return lstTaiKhoan;
            return null;
        }


        public bool themTaiKhoan(DTO_TaiKhoan newTk)
        {
            if (checkIfExist(newTk.TenTaiKhoan) != null)
                return false;
            TaiKhoan tk = new TaiKhoan();
            tk.maNhanVien = newTk.MaNhanVien;
            tk.username = newTk.TenTaiKhoan;
            tk.passwords = newTk.MatKhau;
            tk.quyen = newTk.Quyen;

            dataBase.TaiKhoans.InsertOnSubmit(tk);
            dataBase.SubmitChanges();
            return true;
        }

        public bool suaThongTinTaiKhoan(DTO_TaiKhoan tkUpdoate)
        {
            IQueryable<TaiKhoan> cd = dataBase.TaiKhoans.Where(x => x.maNhanVien.Equals(tkUpdoate.MaNhanVien));
            if (cd.Count() > 0)
            {
                cd.First().passwords = tkUpdoate.MatKhau;
                cd.First().quyen = tkUpdoate.Quyen;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaTaiKhoan(string tenTaiKhoan)
        {
            TaiKhoan taiKhoan = checkIfExist(tenTaiKhoan);
            if(taiKhoan != null)
            {
                dataBase.TaiKhoans.DeleteOnSubmit(taiKhoan);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public List<DTO_TaiKhoan> layToanBoDanhSachTaiKhoanNhanvien()
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

        public DTO_TaiKhoan getTKTheoMaNhanVien(string maNhanVien)
        {
            TaiKhoan temp = (from n in dataBase.TaiKhoans where n.maNhanVien.Equals(maNhanVien) select n).FirstOrDefault();
            DTO_TaiKhoan tmp = new DTO_TaiKhoan();
            if (temp != null)
            {
                tmp.MaNhanVien = temp.maNhanVien;
                tmp.TenTaiKhoan = temp.username;
                tmp.MatKhau = temp.passwords;
                tmp.Quyen = temp.quyen;
                return tmp;
            }
            return tmp;
        }

        public DTO_TaiKhoan layTaiKhoanTheoTenTaiKhoan(string tenTaiKhoan)
        {
            TaiKhoan dataLst = dataBase.TaiKhoans.Where(p => p.username.Equals(tenTaiKhoan)).FirstOrDefault();
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
        public IEnumerable<TaiKhoan> layTaiKHoanTheoMa(string maNV)
        {
            IEnumerable<TaiKhoan> tk =( from n in dataBase.TaiKhoans
                                        where n.maNhanVien.Equals(maNV)
                                        select n);
            return tk;
        }
    }
}
