using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */

    public class DAO_SanPhamSanXuat
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_SanPhamSanXuat()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public List<DTO_SanPhamSanXuat> layDSSanPhamSanXuat()
        {
            var dateLst = dataBase.SanPhamSanXuats.Where(p => p.trangThai == false).OrderBy(p => p.maSanPhamSanXuat);

            if(dateLst != null)
            {
                List<DTO_SanPhamSanXuat> lstSanPham = new List<DTO_SanPhamSanXuat>();
                foreach (var item in dateLst)
                {
                    DTO_SanPhamSanXuat sp = new DTO_SanPhamSanXuat();
                    sp.MaSanPhamSanXuat = item.maSanPhamSanXuat;
                    sp.MaDonHang = item.maDonHang;
                    sp.TenSanPham = item.tenSanPham;
                    sp.SoLuongSanXuat = item.soLuongSanXuat.Value;
                    sp.TrangThai = item.trangThai.Value;
                    lstSanPham.Add(sp);
                }
                return lstSanPham;
            }
            return null;
        }
        public bool checkExist(string maSanPham)
        {
            SanPhamSanXuat sanPham = dataBase.SanPhamSanXuats.Where(p => p.maSanPhamSanXuat == maSanPham).FirstOrDefault();
            if (sanPham != null)
            {
                return true;
            }
            return false;
        }

        public DTO_SanPhamSanXuat layMotSanPhamSanXuat(string maSanPhamSX)
        {
            SanPhamSanXuat sanPhamSX = dataBase.SanPhamSanXuats.Where(p => p.maSanPhamSanXuat.Equals(maSanPhamSX)).FirstOrDefault();

            if(sanPhamSX != null)
            {
                DTO_SanPhamSanXuat buffer = new DTO_SanPhamSanXuat();
                buffer.MaSanPhamSanXuat = sanPhamSX.maSanPhamSanXuat;
                buffer.MaDonHang = sanPhamSX.maDonHang;
                buffer.TenSanPham = sanPhamSX.tenSanPham;
                buffer.SoLuongSanXuat = sanPhamSX.soLuongSanXuat.Value;
                buffer.TrangThai = sanPhamSX.trangThai.Value;
                return buffer;
            }
            return null;
        }
        public bool themSanPhamSanXuat(DTO_SanPhamSanXuat sanPhamSX)
        {
            if (checkExist(sanPhamSX.MaSanPhamSanXuat))
                return false;

            SanPhamSanXuat sanPham = new SanPhamSanXuat();
            sanPham.maSanPhamSanXuat = sanPhamSX.MaSanPhamSanXuat;
            sanPham.tenSanPham = sanPhamSX.TenSanPham;
            sanPham.maDonHang = sanPhamSX.MaDonHang;
            sanPham.trangThai = sanPhamSX.TrangThai;
            sanPham.soLuongSanXuat = sanPhamSX.SoLuongSanXuat;

            dataBase.SanPhamSanXuats.InsertOnSubmit(sanPham);
            dataBase.SubmitChanges();
            return true;
        }

        public bool suaThongTinSanPhamSanXuat(DTO_SanPhamSanXuat sp)
        {
            IQueryable<SanPhamSanXuat> sanPham = dataBase.SanPhamSanXuats.Where(p => p.maSanPhamSanXuat == sp.MaSanPhamSanXuat);
            if (sanPham.Count() >= 0)
            {
                sanPham.First().tenSanPham = sp.TenSanPham;
                sanPham.First().maDonHang = sp.MaDonHang;
                sanPham.First().trangThai = sp.TrangThai;
                sanPham.First().soLuongSanXuat = sp.SoLuongSanXuat;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaSanPhamSanXuat(string maSanPham)
        {
            if (!checkExist(maSanPham))
                return false;
            SanPhamSanXuat sanPham = dataBase.SanPhamSanXuats.Where(p => p.maSanPhamSanXuat == maSanPham).FirstOrDefault();
            if (sanPham != null)
            {
                dataBase.SanPhamSanXuats.DeleteOnSubmit(sanPham);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

    }
}
