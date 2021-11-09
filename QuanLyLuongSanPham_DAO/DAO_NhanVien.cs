using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;


namespace QuanLyLuongSanPham_DAO
{
    public class DAO_NhanVien
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_NhanVien()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        List<DTO_NhanVien> layToanBoDanhSachNhanVien()
        {
            var dataLst = dataBase.NhanViens.Select(p => p).OrderBy(p => p.maNhanVien);

            List<DTO_NhanVien> lst = new List<DTO_NhanVien>();
            foreach (NhanVien nv in dataLst)
            {
                DTO_NhanVien tmp = new DTO_NhanVien();
                tmp.MaNhanVien = nv.maNhanVien;
                tmp.TenNhanVien = nv.tenNhanVien;

            }
            return lst;
        }
        public IEnumerable<dynamic> getDanhSachNVToQLNS()
        {
            IEnumerable<dynamic> q;
            q = (from dsnv in dataBase.NhanViens
                 join loaiNV in dataBase.LoaiNhanViens on dsnv.maLoai equals loaiNV.maLoai
                 join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                 select new { Mã_nhân_viên = dsnv.maNhanVien , Tên_nhân_viên = dsnv.tenNhanVien ,Giới_tính = dsnv.gioiTinh, SDT = dsnv.soDienThoai, Địa_chỉ = dsnv.diaChi, Ngày_sinh = dsnv.ngaySinh, Ngày_vào_làm = dsnv.ngayBatDauCongTac, Loại_Nv = loaiNV.loaiNhanVien1, Đơn_vị_quản_lí = donvi.tenBoPhan });
            return q;
        }
    }
}
