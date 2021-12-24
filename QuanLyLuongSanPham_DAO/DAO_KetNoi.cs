using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Võ Thị Trà Giang, Đinh Quang Huy,Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DAO_KetNoi
    {
        QuanLyLuongSanPhamDataContext dt;
        public QuanLyLuongSanPhamDataContext getQuanLyLuongSanPham()
        {
            string str = @"Data Source=HUYDINH;Initial Catalog=QuanLyLuongSanPham;Integrated Security=True";
            dt = new QuanLyLuongSanPhamDataContext(str);
            dt.Connection.Open();
            return dt;
        }
    }
}
