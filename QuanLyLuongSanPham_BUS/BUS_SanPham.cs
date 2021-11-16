using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_SanPham
    {
        DAO_SanPham sanPhamDAO;
        DAO_Model modelDAO;
        DAO_ChiTietModel chitTietModelDAO;

        public BUS_SanPham()
        {
            sanPhamDAO = new DAO_SanPham();
            modelDAO = new DAO_Model();
            chitTietModelDAO = new DAO_ChiTietModel();
        }
        public List<DTO_SanPham> getAllSanPham()
        {
            return sanPhamDAO.layToanBoDanhSachSanPham();
        }

        public List<DTO_Model> getDSModel()
        {
            return modelDAO.layDSModel();
        }

        public List<object> getAllChiTietSanPham()
        {
            return sanPhamDAO.layDSChiTietSanPham();
        }

        public bool themSanPham(DTO_SanPham sp, DTO_ChiTietModel ct)
        {
            return sanPhamDAO.themSanPham(sp,ct);
        }

        public bool suaSanPham(DTO_SanPham sp, DTO_ChiTietModel chiTiet)
        {
            return sanPhamDAO.suaThongTinSanPham(sp,chiTiet);
        }

        public bool xoaSanPham(string maSanPham)
        {
            return sanPhamDAO.xoaSanPham(maSanPham);
        }

    }
}
