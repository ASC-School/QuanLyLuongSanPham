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
     * Tác giả: Trần Văn Sỹ,VÕ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 19/11/2021
     */
    public class BUS_PhanCong
    {

        DAO_PhanCong daoPhanCong;
        public BUS_PhanCong()
        {
            this.daoPhanCong = new DAO_PhanCong();
        }
        public IEnumerable<dynamic> layDSPhanCong()
        {
            return daoPhanCong.layDSPhanCong();
        }
        public bool phanCong(QuanLyLuongSanPham_DTO.DTO_PhanCong list)
        {
            return daoPhanCong.phanCong(list);
        }
        public bool suaPhanCong(QuanLyLuongSanPham_DTO.DTO_PhanCong pcUpdate)
        {
            return daoPhanCong.suaThongTinPhanCong(pcUpdate);
        }
        public bool xoaPhanCong(string maPhanCong)
        {
            return daoPhanCong.xoaPhanCong(maPhanCong);
        }
        public IEnumerable<PhanCong> layAllPhanCong()
        {
            return daoPhanCong.layAllPhanCong();
        }

        public IEnumerable<dynamic> layAllPhanCongTheoThangTheoCongNhan(string maNhanVien,int thang)
        {
            return daoPhanCong.layDSPhanCongTheoThangTheoCongNhan(maNhanVien, thang);
        }

        public IEnumerable<dynamic> layAllPhanCongTheoNgayTheoCongNhan(string maNhanVien, DateTime ngay)
        {
            return daoPhanCong.layDSPhanCongTheoNgayTheoCongNhan(maNhanVien, ngay);
        }

        public bool checkExist(List<string> lst, string maNhanVien)
        {
            foreach(string item in lst)
            {
                if (item.Equals(maNhanVien))
                    return true;
            }
            return false;
        }
        public int getSoLuongNhanVienCoTrongCongDoan(string  maCongDoan)
        {
            int soLuongNhanVien = 0;
            List<DTO_PhanCong> lstPhanCongThuocCongDoan = daoPhanCong.layDSPhanCongTheoCongDoan(maCongDoan);
            if (lstPhanCongThuocCongDoan == null) return 0;
            List<string> maNhanVien = new List<string>();
            foreach(var item in lstPhanCongThuocCongDoan)
            {
                if (!checkExist(maNhanVien, item.MaNhanVien))
                    maNhanVien.Add(item.MaNhanVien);
            }
            soLuongNhanVien = maNhanVien.Count();
            return soLuongNhanVien;
        }

        

    }
}
