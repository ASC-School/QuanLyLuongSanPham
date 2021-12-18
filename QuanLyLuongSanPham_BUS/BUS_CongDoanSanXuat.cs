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
     * Tác giả: Trần Vẵn Sỹ,Võ Thị Trà Giang,Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 13/11/2021
     */
    public class BUS_CongDoanSanXuat
    {
        DAO_CongDoanSanXuat cd = new DAO_CongDoanSanXuat();
        DAO_SanPhamSanXuat sanPhamSXDAO = new DAO_SanPhamSanXuat();
        public bool checkExist(List<string> lst, string tmp)
        {
            foreach(string item in lst)
            {
                if (item.Equals(tmp))
                    return true;
            }
            return false;
        }

        public bool kiemTraTonTaiCongDoanSanXuat(string maSanPhamSanXuat)
        {
            if (cd.layCongDoanSanXuatTheoSanPham(maSanPhamSanXuat) != null)
                return true;
            return false;
        }
        public DTO_DonHang layThongTinDonHang(string maSanPhamSanXuat)
        {
            return sanPhamSXDAO.layThongTinDonHangTheoMaSPSX(maSanPhamSanXuat);
        }

        
        public BUS_CongDoanSanXuat()
        {
            this.cd = new DAO_CongDoanSanXuat();
        }
        public IEnumerable<dynamic> layDSCongDoan()
        {
            return cd.layDSCongDoan();
        }

        public bool checkNgayThangCongDoan()
        {
            return true;
        }
        public bool addCongDoan(QuanLyLuongSanPham_DTO.DTO_CongDoanSanXuat cdnew)
        {
            try
            {
                if (kiemTraTrungCongDoan(cdnew.MaSanPhamSanXuat, cdnew.ThuTuCongDoan))
                    return false;
                return cd.themCongDoan(cdnew);
            }
            catch
            {
                
                return false;
            }
            
        }
        public bool upDateCongDoan(DTO_CongDoanSanXuat cdUpdate)
        {
            return cd.suaThongTinCongDoan(cdUpdate);
        }
        public bool delCongDoan(int maCongDoan)
        {
            return cd.xoaCongDoan(maCongDoan);
        }
        public IEnumerable<CongDoanSanXuat> layAllDsCD()
        {
            return cd.layAllDsCongDoan();
        }
        public bool kiemTraTrungCongDoan(string maSanPhamSanXuat, string congDoan)
        {
            List<DTO_CongDoanSanXuat> lst = cd.layCongDoanSanXuatTheoSanPham(maSanPhamSanXuat);
            if (lst == null) return false;
            foreach (DTO_CongDoanSanXuat item in lst)
            {
                if (item.ThuTuCongDoan.Equals(congDoan))
                {
                    return true;
                }
            }
            return false;
        }
        public List<DTO_SanPhamSanXuat> layDSSanPhamSanXuat()
        {
            return sanPhamSXDAO.layDSSanPhamSanXuat();
        }
        public List<string> layMaCongDoanTheoSanPhamSanXuat(string maSanPhamSanXuat)
        {
            List<string> maCongDoan = new List<string>();
            maCongDoan.Add("None");
            List<DTO_CongDoanSanXuat> lst = cd.layCongDoanSanXuatTheoSanPham(maSanPhamSanXuat);
            if (lst == null)
                return maCongDoan;
            foreach (var item in lst)
            {
                maCongDoan.Add(item.SoThuTu.ToString());
            }
            return maCongDoan;
        }

        public int laySoLuongSanPhamTheoSanPhamSanXuat(string maSanPhamSanXuat)
        {
            DTO_SanPhamSanXuat sanPhamSX = sanPhamSXDAO.layMotSanPhamSanXuat(maSanPhamSanXuat);
            if (sanPhamSX == null)
                return 0;
            else
                return sanPhamSX.SoLuongSanXuat;
        }
        public List<string> layTenSanPhamSX()
        {
            List<string> tenSanPham = new List<string>();
            tenSanPham.Add("None");
            foreach(var item in sanPhamSXDAO.layDSSanPhamSanXuat())
            {
                if (!checkExist(tenSanPham, item.TenSanPham))
                    tenSanPham.Add(item.TenSanPham);
            }
            return tenSanPham;
        }


        public List<string> layDSMaSanPhamSanXuat()
        {
            List<string> maSanPhamSX = new List<string>();
            maSanPhamSX.Add("None");
            foreach (var item in sanPhamSXDAO.layDSSanPhamSanXuat())
            {
                maSanPhamSX.Add(item.MaSanPhamSanXuat);
            }
            return maSanPhamSX;
        }

        public string timTenSanPhamSXTheoMa(string maSanPhamSX)
        {
            foreach (var item in sanPhamSXDAO.layDSSanPhamSanXuat())
            {
                if (item.MaSanPhamSanXuat.Equals(maSanPhamSX))
                    return item.TenSanPham;
            }
            return "None";
        }
        public IEnumerable<CongDoanSanXuat> layDonGiaCD(string strMaNV)
        {
            return cd.layDonGia(strMaNV);
        }
    }
}
