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
     * Tác giả: Trần Vẵn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 13/11/2021
     */
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
        public bool delCongDoan(int maCongDoan)
        {
            return cd.xoaCongDoan(maCongDoan);
        }
        public IEnumerable<CongDoanSanXuat> layAllDsCD()
        {
            return cd.layAllDsCongDoan();
        }

        public IEnumerable<CongDoanSanXuat> layDonGiaCD(string strMaNV)
        {
            return cd.layDonGia(strMaNV);
        }
    }
}
