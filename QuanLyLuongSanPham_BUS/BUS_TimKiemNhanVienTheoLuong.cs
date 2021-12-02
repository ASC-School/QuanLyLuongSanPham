using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    /**
     * Tác giả: Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class BUS_TimKiemNhanVienTheoLuong
    {
        DAO_LuongCongNhan luongCN;

        public BUS_TimKiemNhanVienTheoLuong()
        {
            luongCN = new DAO_LuongCongNhan();
        }

        public IEnumerable<LuongCongNhan> layMNVLuongCN()
        {
            return luongCN.layMNVLuongCN();
        }
        public IEnumerable<LuongHanhChanh> layMNVLuongHC()
        {
            return luongCN.layMNVLuongHC();
        }
    }
}
