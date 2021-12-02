using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DAO_PhanQuyen
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_PhanQuyen()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public IEnumerable<PhanQuyen> layQuyenNVTheoMa(string strMaLoai)
        {
            IEnumerable<PhanQuyen> pqNV = from pq in dataBase.PhanQuyens
                                          join ml in dataBase.LoaiNhanViens
                                          on pq.maLoai equals ml.maLoai
                                          where pq.maLoai.Equals(strMaLoai)
                                          select pq;
            return pqNV;                               
        }
    }
}
