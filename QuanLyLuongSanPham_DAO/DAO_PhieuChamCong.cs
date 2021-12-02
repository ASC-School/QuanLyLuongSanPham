using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DAO_PhieuChamCong
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_PhieuChamCong()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
    }
}
