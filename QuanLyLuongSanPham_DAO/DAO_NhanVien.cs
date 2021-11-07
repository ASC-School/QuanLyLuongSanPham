using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;


namespace QuanLyLuongSanPham_DAO
{
    public class DAO_NhanVien
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_NhanVien()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        List<DTO_NhanVien> layToanBoDanhSachNhanVien()
        {
            var dataLst = dataBase.NhanViens.Select(p => p).OrderBy(p => p.maNhanVien);

            List<DTO_NhanVien> lst = new List<DTO_NhanVien>();
            foreach (NhanVien nv in dataLst)
            {
                DTO_NhanVien tmp = new DTO_NhanVien();
                tmp.MaNhanVien = nv.maNhanVien;
                tmp.TenNhanVien = nv.tenNhanVien;

            }
            return lst;
        }
    }
}
