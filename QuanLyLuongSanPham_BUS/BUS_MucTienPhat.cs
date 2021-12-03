using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_BUS;


namespace QuanLyLuongSanPham_BUS
{
    /**
     * Tác giả: Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class BUS_MucTienPhat
    {
        DAO_MucTienPhat daoPhatNV;
        public BUS_MucTienPhat()
        {
            daoPhatNV = new DAO_MucTienPhat();
        }
        public IEnumerable<MucTienPhat> layThongTinPhat()
        {
            return daoPhatNV.layThongTinPhat();
        }
    }
}
