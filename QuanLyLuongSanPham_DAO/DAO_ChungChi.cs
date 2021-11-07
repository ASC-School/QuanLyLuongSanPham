using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_ChungChi
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_ChungChi()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        List<DTO_ChungChi> layDanhSachChungChi()
        {
            var dataLst = dataBase.ChungChis.Select(p => p).OrderBy(p => p.soThuTu);

            List<DTO_ChungChi> lstChungChi = new List<DTO_ChungChi>();
            foreach(ChungChi chungChi in dataLst)
            {
                DTO_ChungChi tmp = new DTO_ChungChi();
                tmp.SoThuTu = chungChi.soThuTu;
                tmp.TenChungChi = chungChi.tenChungChi;
                lstChungChi.Add(tmp);
            }

            return lstChungChi;
        }
    }
}
