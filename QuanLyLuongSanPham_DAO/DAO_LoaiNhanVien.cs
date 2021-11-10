using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    
    public class DAO_LoaiNhanVien
    {
        QuanLyLuongSanPhamDataContext dt;
        public DAO_LoaiNhanVien()
        {
            dt = new QuanLyLuongSanPhamDataContext();
        }
        public List<DTO_LoaiNhanVien> layDanhSachLoaiNV()
        {
            var dataLst = dt.LoaiNhanViens.Select(p => p).OrderBy(p => p.maLoai);

            List<DTO_LoaiNhanVien> lst = new List<DTO_LoaiNhanVien>();
            foreach (LoaiNhanVien nv in dataLst)
            {
                DTO_LoaiNhanVien tmp = new DTO_LoaiNhanVien();
                tmp.LoaiNhanVien = nv.loaiNhanVien1;
            }
            return lst;
        }
    }
}
