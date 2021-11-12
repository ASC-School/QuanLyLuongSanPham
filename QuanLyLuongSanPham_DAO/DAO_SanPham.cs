using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_SanPham
    {
        QuanLyLuongSanPhamDataContext dataBase;

        public DAO_SanPham()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public List<DTO_SanPham> layToanBoDanhSachSanPham()
        {
            var dataLst = dataBase.SanPhams.Select(p => p).OrderBy(p => p.maSanPham);

            List<DTO_SanPham> lst = new List<DTO_SanPham>();
            foreach (SanPham sp in dataLst)
            {
                DTO_SanPham tmp = new DTO_SanPham();
                tmp.MaSanPham = sp.maSanPham;
                tmp.TenSanPham = sp.tenSanPham;
                tmp.NamSanXuat = sp.namSanXuat.Value;
                tmp.TrangThai =sp.trangThai.Value;
                tmp.GiaBan = sp.giaBan.Value;
                lst.Add(tmp);
            }
            return lst;
        }


    }
}
