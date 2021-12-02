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
     * Tác giả: Trần Văn Sỹ, Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class BUS_LuongNhanVienHanhChanh
    {
        DAO_LuongHanhChanh luongHanhChanh;
        public BUS_LuongNhanVienHanhChanh()
        {
            luongHanhChanh = new DAO_LuongHanhChanh();
        }

        public IEnumerable<dynamic> loadLuongHC()
        {
            return luongHanhChanh.layDSNVHanhChanh();
        }

        public object luongHCTheoThang(int iMonth, int iYear)
        {
            return luongHanhChanh.layDSNVHCTheoThangNam(iMonth, iYear);
        }

        public bool suaThongTin(DTO_LuongHanhChanh LCN)
        {
            return luongHanhChanh.suaTTNVHC(LCN);
        }

        public object layNVTheoTimKiem(string strMaNV)
        {
            return luongHanhChanh.layNVTimKiemTheoMa(strMaNV);
        }
        public IEnumerable<LuongHanhChanh> layThongTinLuongCaNhan(string strMaNhanVien)
        {
            return luongHanhChanh.layThongTinLuongCaNhan(strMaNhanVien);
        }
        public IEnumerable<PhieuChamCongNhanVienHanhChanh> layDSChamCong(string maNhanVien)
        {
            return luongHanhChanh.layDSCHamCong(maNhanVien);
        }
    }
}
