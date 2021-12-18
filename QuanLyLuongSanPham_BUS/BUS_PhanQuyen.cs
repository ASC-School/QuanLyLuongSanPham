using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_PhanQuyen
    {
        DAO_PhanQuyen phanQuyenDAO = new DAO_PhanQuyen();
        DAO_TaiKhoan taiKhoanDAO = new DAO_TaiKhoan();
        public BUS_PhanQuyen()
        {

        }

        public bool themPhanQuyen(DTO_PhanQuyen newPhanQuyen)
        {
            return phanQuyenDAO.themPhanQuyen(newPhanQuyen);
        }

        public List<string> layTenPhanQuyen()
        {
            List<DTO_PhanQuyen> lst = layDanhSachPhanQuyen();
            List<string> lstPhanQuyen = new List<string>();
            foreach(DTO_PhanQuyen item in lst)
            {
                lstPhanQuyen.Add(item.TenPhanQuyen);
            }
            return lstPhanQuyen;
        }

        public bool suaPhanQuyen(DTO_PhanQuyen newPhanQuyen)
        {
            return phanQuyenDAO.suaPhanQuyen(newPhanQuyen);
        }

        public bool xoaPhanQuyen(string tenPhanQuyen)
        {
            return phanQuyenDAO.xoaPhanQuyen(tenPhanQuyen);
        }

        public List<DTO_PhanQuyen> layDanhSachPhanQuyen()
        {
            return phanQuyenDAO.layDSPhanQuyen();
        }
    }
}
