using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_LuongCongNhan
    {
        DAO_LuongCongNhan luongCongNhan;
        public BUS_LuongCongNhan()
        {
            luongCongNhan = new DAO_LuongCongNhan();
        }

        public IEnumerable<dynamic> loadLuongCN()
        {
            return luongCongNhan.loadLuongCN();
        }
    }
}
