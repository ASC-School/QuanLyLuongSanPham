using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
namespace QuanLyLuongSanPham_BUS
{
    public class BUS_DonViQuanLy
    {
        DAO_DonViQuanLy donVi = new DAO_DonViQuanLy();
        public BUS_DonViQuanLy()
        {
            this.donVi = new DAO_DonViQuanLy();
        }
        public IEnumerable<DonViQuanLy> getDSDonVi()
        {
            return donVi.layDanhSachDonViQUanLy();
        }
        public bool themDonVi(QuanLyLuongSanPham_DTO.DTO_DonViQuanLy dv)
        {
            return donVi.themDonVi(dv);
        }
        public bool suaDonVi(QuanLyLuongSanPham_DTO.DTO_DonViQuanLy dv)
        {
            return donVi.suaDonVi(dv);
        }
        public bool xoaDonVi(string str)
        {
            return donVi.xoaDonVi(str);
        }
    }
}
