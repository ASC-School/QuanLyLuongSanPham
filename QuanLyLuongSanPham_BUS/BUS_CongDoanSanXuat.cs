using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;
namespace QuanLyLuongSanPham_BUS
{
    public class BUS_CongDoanSanXuat
    {
        DAO_CongDoanSanXuat cd = new DAO_CongDoanSanXuat();
        public BUS_CongDoanSanXuat()
        {
            this.cd = new DAO_CongDoanSanXuat();
        }
        public IEnumerable<dynamic> layDSCongDoan()
        {
            return cd.layDSCongDoan();
        }
        public bool addCongDoan(QuanLyLuongSanPham_DTO.DTO_CongDoanSanXuat cdnew)
        {
            return cd.themCongDoan(cdnew);
        }
        public bool upDateCongDoan(DTO_CongDoanSanXuat cdUpdate)
        {
            return cd.suaThongTinCongDoan(cdUpdate);
        }
    }
}
