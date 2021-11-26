using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_NhanVien
    {
        DAO_NhanVien nv = new DAO_NhanVien();

        public BUS_NhanVien()
        {
            this.nv = new DAO_NhanVien();
        }
        public IEnumerable<dynamic> getNhanVienForQLNS()
        {
            return nv.getDanhSachNVToQLNS();
        }

        public DTO_NhanVien getMotNhanVien(string maNhanVien)
        {
            return nv.layMotNhanVien(maNhanVien);
        }

        public List<DTO_NhanVien> getDSNhanVienForDonHang()
        {
            return nv.layToanBoDanhSachNhanVien();
        }
        public bool themNhanVien(QuanLyLuongSanPham_DTO.DTO_NhanVien nvNew)
        {
            return nv.themNhanVien(nvNew);
        }
        public IEnumerable<NhanVien> getNhanVienTheoMa(string maNV)
        {
            return nv.layNvTheoMa(maNV);
        }
        public bool suaThongTin(DTO_NhanVien nvSelect)
        {
            return nv.suaThongTinNhanVien(nvSelect);
        }
        public bool xoaNhanVien(string maNv)
        {
            return nv.delNhanVien(maNv);
        }
        public IEnumerable<dynamic> getNhanVienForLoc(string maLoai, string trangThai, DateTime startDate, DateTime endDate)
        {
            return nv.getDanhSachNvSauLoc(maLoai, trangThai, startDate, endDate);
        }
        public IEnumerable<NhanVien> layAllDSNV()
        {
            return nv.layAllDSNV();
        }
        public IEnumerable<dynamic> searchNhanVien(string maNV, string tenNV, string loaiNv)
        {
            return nv.serchNhanVien(maNV, tenNV, loaiNv);
        }
        public IEnumerable<NhanVien> layDanhSachCongNhan()
        {
            return nv.layDSCongNhan();
        }
        public IEnumerable<NhanVien> layNhanVienTheoMa(string strMaNhanVien)
        {
            return nv.layTTNhanVienTheoMa(strMaNhanVien);
        }
    }
}
