using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
    public class BUS_PhanQuyen
    {
        DAO_PhanQuyen pqnv;

        public BUS_PhanQuyen()
        {
            pqnv = new DAO_PhanQuyen();
        }

        public IEnumerable<PhanQuyen> layQuyenSuDungNV(string strMaLoai)
        {
            return pqnv.layQuyenNVTheoMa(strMaLoai);
        }
    }
}
