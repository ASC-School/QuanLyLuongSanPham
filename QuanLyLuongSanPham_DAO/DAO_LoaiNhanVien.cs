using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
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
