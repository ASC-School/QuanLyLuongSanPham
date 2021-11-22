using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_LuongCongNhan
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_LuongCongNhan()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public IEnumerable<dynamic> loadLuongCN()
        {
            IEnumerable<dynamic> luongCN = from dv in dataBase.DonViQuanLies
                                           join lnv in dataBase.LoaiNhanViens
                                           on dv.maLoai equals lnv.maLoai
                                           join nv in dataBase.NhanViens
                                           on lnv.maLoai equals nv.maLoai
                                           join lcn in dataBase.LuongCongNhans
                                           on nv.maNhanVien equals lcn.maNhanVien
                                           join cdsx in dataBase.CongDoanSanXuats
                                           on lcn.maCongDoan equals cdsx.soThuTu
                                           join mtp in dataBase.MucTienPhats
                                           on lcn.maCongDoan equals mtp.soThuTu
                                           select new
                                           {
                                               maNV = nv.maNhanVien,
                                               tenNV = nv.tenNhanVien,
                                               donVi = dv.tenBoPhan,
                                               congDoan = cdsx.tenCongDoan,
                                               soLuongSPLamDuoc = lcn.soLuongSanPham,
                                               tienPhat = mtp.mucTienPhat1,
                                               thue = lcn.thue,
                                               tongLuongTT = ((cdsx.donGia * lcn.soLuongSanPham) - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100) - mtp.mucTienPhat1),
                                               tamUng = lcn.tienUng,
                                               thucNhan = (((cdsx.donGia * lcn.soLuongSanPham) - mtp.mucTienPhat1 - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100)) - lcn.tienUng)
                                           };
            return luongCN;
        }
    }
}
