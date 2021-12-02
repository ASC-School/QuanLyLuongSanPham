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
    public class BUS_TaiKhoan
    {
        DAO_TaiKhoan taiKhoan;

        public BUS_TaiKhoan()
        {
            taiKhoan = new DAO_TaiKhoan();
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

        public bool suaThongTinTaiKhoan(DTO_TaiKhoan tkUpload)
        {
            return taiKhoan.suaThongTinTaiKhoan(tkUpload);
        }
    }
}
