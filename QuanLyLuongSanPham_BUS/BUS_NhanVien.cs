using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_NhanVien
    {
        DAO_NhanVien nv = new DAO_NhanVien();

        public BUS_NhanVien()
        {
            this.nv = new DAO_NhanVien();
        }
        public IEnumerable<dynamic> getNhanVienForQLNS()
        {
            return nv.getDanhSachNVToQLNS();
        }
        public bool themNhanVien(QuanLyLuongSanPham_DTO.DTO_NhanVien nvNew)
        {
            return nv.themNhanVien(nvNew);
        }
    }
}
