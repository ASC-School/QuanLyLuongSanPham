using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DAO_Model = new DAO_Model();
            DAO_ChiTietModel = new DAO_ChiTietModel();
        }
        public List<DTO_SanPham> getAllSanPham()
        {
            return sanPhamDAO.layToanBoDanhSachSanPham();
        }

    }
}
