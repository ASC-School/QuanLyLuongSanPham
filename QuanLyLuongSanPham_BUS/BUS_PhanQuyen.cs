using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
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
