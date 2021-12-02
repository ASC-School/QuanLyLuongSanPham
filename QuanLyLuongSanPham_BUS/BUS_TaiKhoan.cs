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
        public IEnumerable<TaiKhoan> layTKTheoMa(string maNv)
        {
            return taiKhoan.layTaiKHoanTheoMa(maNv);
        }
    }
}
