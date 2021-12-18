using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_BUS
{
    /**
    * Tác giả: Võ Thị Trà Giang,Đinh Quang Huy
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
    public class BUS_TaiKhoan
    {
        DAO_TaiKhoan taiKhoan;
        DAO_NhanVien nhanVienDAO;
        public BUS_TaiKhoan()
        {
            taiKhoan = new DAO_TaiKhoan();
            nhanVienDAO = new DAO_NhanVien();
        }
        public IEnumerable<TaiKhoan> loadDSTK()
        {
            return taiKhoan.layDSTK();
        }

        public IEnumerable<NhanVien> loadNVTheoMa(string maNhanVien)
        {
            return taiKhoan.layNVTheoMa(maNhanVien);
        }

        public IEnumerable<LoaiNhanVien> loadLoaiNVTheoMa(string maNhanVien)
        {
            return taiKhoan.layLoaiNVTheoMa(maNhanVien);
        }

        public DTO_TaiKhoan getThongTinTaiKhoanTheoTenTaiKhoan(string username)
        {
            return taiKhoan.layTaiKhoanTheoTenTaiKhoan(username);
        }

        public IEnumerable<dynamic> layDanhSachTaiKhoan()
        {
            return taiKhoan.layDSTKPhanQuyen();
        }

        public IEnumerable<dynamic>  layDSTaiKhoanChuaPhanQuyen()
        {
            return taiKhoan.layDSTKChuaDuocPhanQuyen();
        }

        public DTO_TaiKhoan getTKTheoNhanVien(string maNhanVien)
        {
            return taiKhoan.getTKTheoMaNhanVien(maNhanVien);
        }
        public List<DTO_NhanVien> layDSNhanVienChuaCoTaiKhoan()
        {
            List<DTO_NhanVien> lstNhanVien = nhanVienDAO.layDSAllNhanVien();
            List<DTO_NhanVien> lstNhanVienChuaCotaiKhoan = new List<DTO_NhanVien>();
            foreach(DTO_NhanVien item in lstNhanVien)
            {
                if (!taiKhoan.checkIfExistNV(item.MaNhanVien))
                    lstNhanVienChuaCotaiKhoan.Add(item);
            }
            ////if (lstNhanVienChuaCotaiKhoan.Count > 0)
            ////    return lstNhanVienChuaCotaiKhoan;
            return lstNhanVienChuaCotaiKhoan;
        }

        public List<string> maNhanVien()
        {
            List<string> lst = new List<string>();
            List<DTO_NhanVien> lstNhanVien = layDSNhanVienChuaCoTaiKhoan();
            foreach(DTO_NhanVien item in lstNhanVien)
            {
                lst.Add(item.MaNhanVien);
            }
            return lst;    
        }

        public List<string> tenNhanVien()
        {
            List<string> lst = new List<string>();
            List<DTO_NhanVien> lstNhanVien = layDSNhanVienChuaCoTaiKhoan();
            foreach (DTO_NhanVien item in lstNhanVien)
            {
                lst.Add(item.TenNhanVien);
            }
            return lst;
        }

        public bool suaThongTinTaiKhoan(DTO_TaiKhoan tkUpload)
        {
            return taiKhoan.suaThongTinTaiKhoan(tkUpload);
        }

        public bool themTaiKhoan(DTO_TaiKhoan newTaiKhoan)
        {
            return taiKhoan.themTaiKhoan(newTaiKhoan);
        }

        public bool xoaTaiKhoan(string tenTaiKhoan)
        {
            return taiKhoan.xoaTaiKhoan(tenTaiKhoan);
        }


        public IEnumerable<TaiKhoan> layTKTheoMa(string maNv)
        {
            return taiKhoan.layTaiKHoanTheoMa(maNv);
        }

        public DTO_TaiKhoan layTaiKhoanTheoTenTK(string username)
        {
            return taiKhoan.layTaiKhoanTheoTenTaiKhoan(username);
        }
    }
}
