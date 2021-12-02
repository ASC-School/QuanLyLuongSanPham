using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
namespace QuanLyLuongSanPham_BUS
{
    /**
     * Tác giả: Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class BUS_LoaiNhanVien
    {
        DAO_LoaiNhanVien loaiNV = new DAO_LoaiNhanVien();
        public BUS_LoaiNhanVien()
        {
            this.loaiNV = new DAO_LoaiNhanVien();
        }
        public IEnumerable<LoaiNhanVien> getNhanVienForQLNS()
        {
            return loaiNV.layDanhSachLoaiNV();
        }
    }
}
