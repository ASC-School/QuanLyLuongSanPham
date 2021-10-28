using System;
using System.Collections.Generic;
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

        List<DTO_TaiKhoan> layToanBoDanhSachTaiKhoanNhanvien()
        {
            var dataLst = dataBase.TaiKhoans.Select(p => p).OrderBy(p => p.username);

            List<DTO_TaiKhoan> lst = new List<DTO_TaiKhoan>();

            foreach (TaiKhoan tai_khoan in dataLst)
            {
                DTO_TaiKhoan tmp = new DTO_TaiKhoan();
                tmp.MaNhanVien = tai_khoan.maNhanVien;
                tmp.TenTaiKhoan = tai_khoan.username;
                tmp.MaKhau = tai_khoan.passwords;
                tmp.Quyen = tai_khoan.quyen;
                lst.Add(tmp);
            }
            return lst;
        }

        //List<DTO_TaiKhoan> layDanhSachTaiKhoanTheoLoaiNhanVien()
        //{

        //}

    }
}
