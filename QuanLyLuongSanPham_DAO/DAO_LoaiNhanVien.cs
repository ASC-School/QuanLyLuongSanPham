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
        public IEnumerable<LoaiNhanVien> layDanhSachLoaiNV()
        {
            IEnumerable<LoaiNhanVien> q = from n in dt.LoaiNhanViens select n;
            return q;
        }
    }
}
