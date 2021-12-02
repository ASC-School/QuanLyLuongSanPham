using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_BUS
{
    /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
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
        public IEnumerable<SanPham> GetSanPhams()
        {
            return sanPhamDAO.getSanPhams();
        }

        public List<DTO_Model> getDSModel()
        {
            return modelDAO.layDSModel();
        }

        public bool checkExistModel(string model)
        {
            return modelDAO.checkExist(model);
        }

        public bool themModel(DTO_Model model)
        {
            return modelDAO.themModel(model);
        }

        public bool suaThongTinModel(DTO_Model model)
        {
            return modelDAO.suaModel(model);
        }

        public bool xoaModel(string maModel)
        {
            return modelDAO.xoaModel(maModel);
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
