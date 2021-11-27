using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_DonHang
    {
        DAO_DonHang donHangDAO;
        DAO_ChiTietDonHang chiTietDHDAO;
        DAO_SanPham sanPhamDAO;
        public BUS_DonHang()
        {
            donHangDAO = new DAO_DonHang();
            chiTietDHDAO = new DAO_ChiTietDonHang();
            sanPhamDAO = new DAO_SanPham();
        }

        public string layNgayLonNhat()
        {
            return donHangDAO.ngayLonNhat();
        }
        public IEnumerable<dynamic> getAllDonHang()
        {
            return donHangDAO.layDSDonHang();
        }

        public IEnumerable<dynamic> getAllDonHangCoThanhTien()
        {
            return donHangDAO.layDSDonHangCoThanhTien();
        }

        public List<DTO_DonHang> getDSDonHang()
        {
            return donHangDAO.layToanBoDSDonHang();
        }

        public List<DTO_ChiTietDonHang> getCTDH(string maDonHang)
        {
            return chiTietDHDAO.lstCTDH(maDonHang);
        }

        public string getTenKhTheoSoDienThoai(string soDienThoai)
        {
            return donHangDAO.timTenKHTheoSDT(soDienThoai);
        }

        public IEnumerable<object> getAllChiTietDonHang(string maDonHang)
        {
            return chiTietDHDAO.layDanhSachTimKiemCTDH(maDonHang);
        }

        public bool checkTonTaiDonHang(string maDonHang)
        {
            return donHangDAO.checkExist(maDonHang);
        }
        
        public DTO_DonHang getDonHang(string maDonHang)
        {
            return donHangDAO.timKiemDonHang(maDonHang);
        }

        public List<DTO_SanPham> getDSSanPham()
        {
            return sanPhamDAO.layToanBoDanhSachSanPham();
        }

        public DTO_SanPham getMotSanPham(string maSanPham)
        {
            return sanPhamDAO.getSP(maSanPham);
        }

        public decimal tongTienDonHang(string maDonHang)
        {
            return chiTietDHDAO.tongTienDonHang(maDonHang);
        }

        public bool themDonHang(DTO_DonHang donHang)
        {
            return donHangDAO.themDonHang(donHang);
        }

        public bool suaDonHang(DTO_DonHang donHang)
        {
            return donHangDAO.suaDonhang(donHang);
        }

        public bool xoaDonHang(string maDonHang)
        {
            return donHangDAO.xoaDonHang(maDonHang);
        }

        public bool themChiTietDonHang(string maDonHang, DTO_ChiTietDonHang ctdh)
        {
            return chiTietDHDAO.themChiTietDonHang(maDonHang, ctdh);
        }

        public bool suaChiTietDonHang( DTO_ChiTietDonHang ctdh)
        {
            return chiTietDHDAO.suaChiTietDonHang(ctdh);
        }

        public bool xoaChiTietDonHang(string maSanPham, string maDonHang)
        {
            return chiTietDHDAO.xoaChiTietDonHang(maDonHang, maSanPham);
        }

        public bool checkExistChiTietDonHang(string maSanPham, string maDonHang)
        {
            return chiTietDHDAO.timKiemChiTietDonHang(maSanPham, maDonHang);
        }

        public bool tangSoLuongSanPham(DTO_ChiTietDonHang chiTiet)
        {
            return chiTietDHDAO.tangSoLuongSanPPham(chiTiet);
        }

        //====== tim kiem don hang
        public IEnumerable<dynamic> getDHTheoNhanVienKhachHangSanPhamMaDonHang(string maNhanVien,string tenKhachHang,string soDienThoaiKhachHang,string tenSanPham,string maDonHang)
        {
            return donHangDAO.timKiemDHTheoNhanVienVaKhachHangVaSanPhamVaDonHang(maNhanVien, soDienThoaiKhachHang, tenKhachHang, tenSanPham, maDonHang);
        }

        //============================= NHAN VIEN + KhachHang
        public IEnumerable<dynamic> getDHTheoNhanVien(string maNhanVien)
        {
            return donHangDAO.timKiemDonHangTheoNhanVien(maNhanVien);
        }

        public IEnumerable<dynamic> getDHTheoNhanVienCoThanhTien(string maNhanVien)
        {
            return donHangDAO.timKiemDonHangTheoNhanVienCoThanhTien(maNhanVien);
        }
        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau_SanPham(string maNhanVien,string tenKhachHang, string ngayBatDau, string tenSanPham) 
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau_SanPham(maNhanVien, tenKhachHang, ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham(string maNhanVien, string soDienThoaiKhachHang, string ngayBatDau, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham(maNhanVien, soDienThoaiKhachHang, ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_NgayBatDau_SanPham(string maNhanVien, string tenKhachHang,string soDienThoai, string ngayBatDau, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayBatDau_SanPham(maNhanVien, tenKhachHang,soDienThoai, ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayKetThuc_SanPham(string maNhanVien, string tenKhachHang, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayKetThuc_SanPham(maNhanVien, tenKhachHang, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SODienThoaiKH_NgayKetThuc_SanPham(string maNhanVien, string soDienThoai, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc_SanPham(maNhanVien, soDienThoai, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_NgayKetThuc_SanPham(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayKetThuc_SanPham(maNhanVien,tenKhachHang, soDienThoai, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham(string maNhanVien, string tenKhachHang,string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham(maNhanVien, tenKhachHang,ngayBatDau, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_SanPham(string maNhanVien, string tenKhachHang,string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_SanPham(maNhanVien, tenKhachHang,soDienThoai, ngayBatDau, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham(maNhanVien, soDienThoai, ngayBatDau, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau_MaDonHang(string maNhanVien, string tenKhachHang, string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau_MaDonHang(maNhanVien, tenKhachHang, ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_soDienThoaiKH_NgayBatDau_MaDonHang(string maNhanVien, string soDienThoai, string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_MaDonHang(maNhanVien, soDienThoai, ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KH_NgayBatDau_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayBatDau_MaDonHang(maNhanVien,tenKhachHang, soDienThoai, ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayKetThuc_MaDonHang(string maNhanVien, string tenKhachHang, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayKetThuc_MaDonHang(maNhanVien, tenKhachHang, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayKetThuc_MaDonHang(string maNhanVien, string soDienThoai, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc_MaDonHang(maNhanVien, soDienThoai, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_NgayKetThuc_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayKetThuc_MaDonHang(maNhanVien,tenKhachHang, soDienThoai, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_MaDonHang(string maNhanVien, string tenKhachHang,string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_MaDonHang(maNhanVien, tenKhachHang,ngayBatDau, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_MaDonHang(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_MaDonHang(maNhanVien, soDienThoai, ngayBatDau, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_MaDonHang(maNhanVien,tenKhachHang, soDienThoai, ngayBatDau, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string tenKhachHang, string ngayBatDau,string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau_SanPham_MaDonHang(maNhanVien, tenKhachHang, ngayBatDau,sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string tenKhachHang,string soDienThoai, string ngayBatDau, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayBatDau_SanPham_MaDonHang(maNhanVien, tenKhachHang,soDienThoai, ngayBatDau, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string soDienThoai, string ngayBatDau, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(maNhanVien, soDienThoai, ngayBatDau, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string tenKhachHang, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayKetThuc_SanPham_MaDonHang(maNhanVien, tenKhachHang, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string soDienThoai, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(maNhanVien, soDienThoai, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string tenKhachHang, string ngayBatDau,string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(maNhanVien, tenKhachHang, ngayBatDau,ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(maNhanVien, soDienThoai, ngayBatDau, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_ThoiGian_SanPham_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_ThoiGian_SanPham_MaDonHang(maNhanVien,tenKhachHang, soDienThoai, ngayBatDau, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau(string maNhanVien, string tenKhachHang, string ngayBatDau)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau(maNhanVien, tenKhachHang, ngayBatDau);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau(string maNhanVien, string soDienThoai, string ngayBatDau)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau(maNhanVien, soDienThoai, ngayBatDau);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayKetThuc(string maNhanVien, string tenKhachHang, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayKetThuc(maNhanVien, tenKhachHang, ngayKetThuc);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SODienThoaiKH_NgayKetThuc(string maNhanVien, string soDienThoai, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc(maNhanVien, soDienThoai, ngayKetThuc);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_NgayKetThuc(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_NgayKetThuc(maNhanVien,tenKhachHang, soDienThoai, ngayKetThuc);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_SanPham(string maNhanVien, string tenKhachHang, string sanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_SanPham(maNhanVien, tenKhachHang, sanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_SanPham(string maNhanVien, string soDienThoai, string sanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_SanPham(maNhanVien, soDienThoai, sanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_SanPham(string maNhanVien,string tenKhachHang, string soDienThoai, string sanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_SanPham(maNhanVien,tenKhachHang, soDienThoai, sanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_MaDonHang(string maNhanVien, string tenKhachHang, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_MaDonHang(maNhanVien, tenKhachHang, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_MaDonHang(string maNhanVien, string soDienThoai, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_MaDonHang(maNhanVien, soDienThoai, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_MaDonHang(string maNhanVien,string tenKhachHang ,string soDienThoai, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_MaDonHang(maNhanVien,tenKhachHang, soDienThoai, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH(string maNhanVien, string tenKhachHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH(maNhanVien, tenKhachHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH(string maNhanVien, string soDienThoaiKhachHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH(maNhanVien, soDienThoaiKhachHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang(string maNhanVien,string tenKhachHang, string soDienThoaiKhachHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang(maNhanVien,tenKhachHang, soDienThoaiKhachHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc(string maNhanVien, string tenKhachHang,string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc(maNhanVien, tenKhachHang,ngayBatDau, ngayKetThuc);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc(maNhanVien, soDienThoai, ngayBatDau, ngayKetThuc);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_KhachHang_ThoiGian(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_KhachHang_ThoiGian(maNhanVien,tenKhachHang, soDienThoai, ngayBatDau, ngayKetThuc);
        }
        //================= NHAN VIEN + THOI GIAN

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayBatDau_SanPham(string maNhanVien, string ngayBatDau, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayBatDau_SanPham(maNhanVien, ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayKetThuc_SanPham(string maNhanVien, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayKetThuc_SanPham(maNhanVien, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_ThoiGian_SanPham(string maNhanVien,string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_ThoiGian_SanPham(maNhanVien,ngayBatDau, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayBatDau_MaDonHang(string maNhanVien, string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayBatDau_MaDonHang(maNhanVien, ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayKetThuc_MaDonHang(string maNhanVien, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayKetThuc_MaDonHang(maNhanVien, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_ThoiGian_MaDonHang(string maNhanVien, string ngayBatDau,string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_ThoiGian_MaDonHang(maNhanVien, ngayBatDau,ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string ngayBatDau, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayBatDau_SanPham_MaDonHang(maNhanVien, ngayBatDau, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayKetThuc_SanPham_MaDonHang(maNhanVien, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_ThoiGian_SanPham_MaDonHang(string maNhanVien,string ngayBatDau, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_ThoiGian_SanPham_MaDonHang(maNhanVien,ngayBatDau, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayBatDau(string maNhanVien, string ngayBatDau)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayBatDau(maNhanVien, ngayBatDau);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_NgayKetThuc(string maNhanVien, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_NgayKetThuc(maNhanVien, ngayKetThuc);
        }

        public IEnumerable<dynamic> getDHTheoNhanVien_ThoiGian(string maNhanVien,string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNhanVien_ThoiGian(maNhanVien,ngayBatDau, ngayKetThuc);
        }

        //================ nhân viên + sản phẩm
        public IEnumerable<dynamic> getDHTheoNhanVien_SanPham(string maNhanVien,string sanPham)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SanPham(maNhanVien,sanPham);
        }

        //============= nhân viên + donHang
        public IEnumerable<dynamic> getDHTheoNhanVien_MaDonHang(string maNhanVien, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_MaDonHang(maNhanVien, maDonHang);
        }

        //================ nhân viên + sản phẩm + donHang
        public IEnumerable<dynamic> getDHTheoNhanVien_SanPham_DonHang(string maNhanVien, string sanPham,string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNhanVien_SanPham_MaDonHang(maNhanVien, sanPham,maDonHang);
        }

        //=================== KHACH HANG =============================
        //timdon hang theo ten khach hang + ngay bat dau
        public IEnumerable<dynamic> getDHTheoTenKH_NgayBatDau_SanPham( string tenKhachHang, string ngayBatDau, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayBatDau_SanPham(tenKhachHang, ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_NgayBatDau_MaDonHang(string tenKhachHang, string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayBatDau_MaDonHang(tenKhachHang, ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_NgayBatDau_SanPham_MaDonHang(string tenKhachHang, string ngayBatDau, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayBatDau_SanPham_MaDonHang( tenKhachHang, ngayBatDau, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_NgayBatDau(string tenKhachHang, string ngayBatDau)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayBatDau(tenKhachHang, ngayBatDau);
        }

        // tenKH + ngay ketThuc
        public IEnumerable<dynamic> getDHTheoTenKH_NgayKetThuc_SanPham(string tenKhachHang, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayKetThuc_SanPham(tenKhachHang, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_NgayKetThuc_MaDonHang(string tenKhachHang, string ngayKetthuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayKetThuc_MaDonHang(tenKhachHang, ngayKetthuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_NgayKetThuc_SanPham_MaDonHang(string tenKhachHang, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayKetThuc_SanPham_MaDonHang(tenKhachHang, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_NgayKetThuc(string tenKhachHang, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoTenKH_NgayKetThuc(tenKhachHang, ngayKetThuc);
        }

        //tenKH ngay bat dau + ngay ket Thuc
        public IEnumerable<dynamic> getDHTheoTenKH_ThoiGian_SanPham(string tenKhachHang, string ngayBatDau, string ngayKetThuc, string sanPham)
        {
            return donHangDAO.timKiemDhTheoTenKH_ThoiGian_SanPham(tenKhachHang, ngayBatDau, ngayKetThuc, sanPham);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_ThoiGian_MaDonHang(string tenKhachHang, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoTenKH_ThoiGian_SanPham(tenKhachHang, ngayBatDau, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_ThoiGian_SanPham_MaDonHang(string tenKhachHang, string ngayBatDau, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoTenKH_ThoiGian_SanPham_MaDonHang(tenKhachHang, ngayBatDau, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoTenKH_ThoiGian(string tenKhachHang, string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoTenKH_ThoiGian(tenKhachHang, ngayBatDau, ngayKetThuc);
        }

        // tenKH + sanpham
        public IEnumerable<dynamic> getDHTheoTenKH_SanPham(string tenKhachHang, string sanPham)
        {
            return donHangDAO.timKiemDhTheoTenKH_SanPham(tenKhachHang, sanPham);
        }
        //tenKH+ maDonHang
        public IEnumerable<dynamic> getDHTheoTenKH_MaDonHang(string tenKhachHang, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoTenKH_MaDonHang(tenKhachHang, maDonHang);
        }
        // tenKH
        public IEnumerable<dynamic> getDHTheoTenKH(string tenKhachHang)
        {
            return donHangDAO.timKiemDonHangTheoTenKhachHang(tenKhachHang);
        }

        public IEnumerable<dynamic> getDHTheoTenKHCoThanhTien(string tenKhachHang)
        {
            return donHangDAO.timKiemDonHangTheoTenKhachHangCoThanhTien(tenKhachHang);
        }

        //==== so dien thoai KH
        //timdon hang theo ten khach hang + ngay bat dau
        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayBatDau_SanPham(string soDienThoai, string ngayBatDau, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayBatDau_SanPham(soDienThoai, ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayBatDau_MaDonHang(string soDienThoai, string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayBatDau_MaDonHang(soDienThoai, ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(string soDienThoai, string ngayBatDau, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(soDienThoai, ngayBatDau, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayBatDau(string soDienThoai, string ngayBatDau)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayBatDau(soDienThoai, ngayBatDau);
        }

        // tenKH + ngay ketThuc
        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayKetThuc_SanPham(string sodienThoai, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayKetThuc_SanPham(sodienThoai, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayKetThuc_MaDonHang(string soDienThoai, string ngayKetthuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayKetThuc_MaDonHang(soDienThoai, ngayKetthuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(string soDienThoai, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(soDienThoai, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_NgayKetThuc(string soDienThoai, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_NgayKetThuc(soDienThoai, ngayKetThuc);
        }

        //tenKH ngay bat dau + ngay ket Thuc
        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_ThoiGian_SanPham(string soDienThoai, string ngayBatDau, string ngayKetThuc, string sanPham)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_ThoiGian_SanPham(soDienThoai, ngayBatDau, ngayKetThuc, sanPham);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_ThoiGian_MaDonHang(string soDienThoai, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_ThoiGian_MaDonHang(soDienThoai, ngayBatDau, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_ThoiGian_SanPham_MaDonHang(string soDienThoai, string ngayBatDau, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_ThoiGian_SanPham_MaDonHang(soDienThoai, ngayBatDau, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_ThoiGian(string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_ThoiGian(soDienThoai, ngayBatDau, ngayKetThuc);
        }

        // tenKH + sanpham
        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_SanPham(string soDienThoai, string sanPham)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_SanPham(soDienThoai, sanPham);
        }
        //tenKH+ maDonHang
        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH_MaDonHang(string soDienThoai, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSoDienThoaiKH_MaDonHang(soDienThoai, maDonHang);
        }
        // tenKH
        public IEnumerable<dynamic> getDHTheoSoDienThoaiKH(string soDienThoai)
        {
            return donHangDAO.timKiemDonHangTheoSoDienThoaiKhachHang(soDienThoai);
        }

        //======== tim theo khach hang(ten + soDienThoai)
        //timdon hang theo ten khach hang + ngay bat dau
        public IEnumerable<dynamic> getDHTheoKhachHang_NgayBatDau_SanPham(string tenKhachHang,string soDienThoai, string ngayBatDau, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoKhachHang_NgayBatDau_SanPham(tenKhachHang,soDienThoai, ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_NgayBatDau_MaDonHang(string tenKhachHang,string soDienThoai, string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoKhachHang_NgayBatDau_MaDonHang(tenKhachHang,soDienThoai, ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_NgayBatDau_SanPham_MaDonHang(string tenKhachHang,string soDienThoai, string ngayBatDau, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoKhachHang_NgayBatDau_SanPham_MaDonHang(tenKhachHang, soDienThoai, ngayBatDau, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_NgayBatDau(string tenKhachHang,string soDienThoai, string ngayBatDau)
        {
            return donHangDAO.timKiemDhTheoKhachHang_NgayBatDau(tenKhachHang,soDienThoai, ngayBatDau);
        }

        // tenKH + ngay ketThuc
        public IEnumerable<dynamic> getDHTheoKhachHang_NgayKetThuc_SanPham(string tenKhachHang,string sodienThoai, string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoKhachHang_NgayKetThuc_SanPham(tenKhachHang, sodienThoai, ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_NgayKetThuc_MaDonHang(string tenKhachHang,string soDienThoai, string ngayKetthuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoKhachHang_NgayKetThuc_MaDonHang(tenKhachHang,  soDienThoai, ngayKetthuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_NgayKetThuc_SanPham_MaDonHang(string tenKhachHang,string soDienThoai, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoKhachHang_NgayKetThuc_SanPham_MaDonHang(tenKhachHang, soDienThoai, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_NgayKetThuc(string tenKhachHang,string soDienThoai, string ngayKetThuc)
        {
             return donHangDAO.timKiemDhTheoKhachHang_NgayKetThuc(tenKhachHang, soDienThoai, ngayKetThuc);
        }

        //tenKH ngay bat dau + ngay ket Thuc
        public IEnumerable<dynamic> getDHTheoKhachHang_ThoiGian_SanPham(string tenKhachHang,string soDienThoai, string ngayBatDau, string ngayKetThuc, string sanPham)
        {
            return donHangDAO.timKiemDhTheoKhachHang_ThoiGian_SanPham(tenKhachHang, soDienThoai, ngayBatDau, ngayKetThuc, sanPham);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_ThoiGian_MaDonHang(string tenKhachHang,string soDienThoai, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoKhachHang_ThoiGian_MaDonHang( tenKhachHang, soDienThoai, ngayBatDau, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_ThoiGian_SanPham_MaDonHang(string tenKhachHang,string soDienThoai, string ngayBatDau, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoKhachHang_ThoiGian_SanPham_MaDonHang(tenKhachHang, soDienThoai, ngayBatDau, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoKhachHang_ThoiGian(string tenKhachHang,string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoKhachHang_ThoiGian(tenKhachHang,soDienThoai, ngayBatDau, ngayKetThuc);
        }

        // tenKH + sanpham
        public IEnumerable<dynamic> getDHTheoKhachHang_SanPham(string tenKhachHang,string soDienThoai, string sanPham)
        {
            return donHangDAO.timKiemDhTheoKhachHang_SanPham(tenKhachHang,soDienThoai, sanPham);
        }
        //tenKH+ maDonHang
        public IEnumerable<dynamic> getDHTheoKhachHang_MaDonHang(string tenKhachHang,string soDienThoai, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoKhachHang_MaDonHang( tenKhachHang,soDienThoai, maDonHang);
        }
        // tenKH
        public IEnumerable<dynamic> getDHKhachHang(string tenKhachHang,string soDienThoai)
        {
            return donHangDAO.timKiemDonHangTheoKhachHang(tenKhachHang,soDienThoai);
        }

        public IEnumerable<dynamic> getDHKhachHangCoThanhTien(string tenKhachHang, string soDienThoai)
        {
            return donHangDAO.timKiemDonHangTheoKhachHangCoThanhTien(tenKhachHang, soDienThoai);
        }

        //===================== THEO THOIGIAN =============================
        //NGAYBATDAU
        public IEnumerable<dynamic> getDHTheoNgayBatDau_SanPham(string ngayBatDau, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNgayBatDau_SanPham(ngayBatDau, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNgayBatDau_MaDonHang(string ngayBatDau, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNgayBatDau_MaDonHang( ngayBatDau, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNgayBatDau_SanPham_MaDonHang(string ngayBatDau, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNgayBatDau_SanPham_MaDonHang(ngayBatDau, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNgayBatDau(string ngayBatDau)
        {
            return donHangDAO.timKiemDhTheoNgayBatDau( ngayBatDau);
        }

        //  ngay ketThuc
        public IEnumerable<dynamic> getDHTheoNgayKetThuc_SanPham(string ngayKetThuc, string tenSanPham)
        {
            return donHangDAO.timKiemDhTheoNgayKetThuc_SanPham( ngayKetThuc, tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoNgayKetThuc_MaDonHang( string ngayKetthuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNgayKetThuc_MaDonHang(ngayKetthuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNgayKetThuc_SanPham_MaDonHang(string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoNgayKetThuc_SanPham_MaDonHang(ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoNgayKetThuc(string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoNgayKetThuc(ngayKetThuc);
        }

        // ngay bat dau + ngay ket Thuc
        public IEnumerable<dynamic> getDHTheoThoiGian_SanPham(string ngayBatDau, string ngayKetThuc, string sanPham)
        {
            return donHangDAO.timKiemDhTheoThoiGian_SanPham(ngayBatDau, ngayKetThuc, sanPham);
        }

        public IEnumerable<dynamic> getDHTheoThoiGian_MaDonHang(string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoThoiGian_MaDonHang(ngayBatDau, ngayKetThuc, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoThoiGian_SanPham_MaDonHang(string ngayBatDau, string ngayKetThuc, string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheThoiGian_SanPham_MaDonHang(ngayBatDau, ngayKetThuc, sanPham, maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoThoiGian(string ngayBatDau, string ngayKetThuc)
        {
            return donHangDAO.timKiemDhTheoThoiGian(ngayBatDau, ngayKetThuc);
        }

        //=== GET DON HANG THEO SAN PHAM + madon hang
        public IEnumerable<dynamic> getDHTheoSanPham( string tenSanPham)
        {
            return donHangDAO.timKiemDonHangTheoSanPham(tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoSanPhamCoThanhTien(string tenSanPham)
        {
            return donHangDAO.timKiemDonHangTheoSanPhamCoThanhTien(tenSanPham);
        }

        public IEnumerable<dynamic> getDHTheoMaDonHang(string maDonHang)
        {
            return donHangDAO.timKiemDhTheoMaDonHang(maDonHang);
        }

        public IEnumerable<dynamic> getDHTheoSanPham_MaDonHang(string sanPham, string maDonHang)
        {
            return donHangDAO.timKiemDhTheoSanPham_MaDonHang(sanPham, maDonHang);
        }

        //============================== thong ke don hang
        public IEnumerable<dynamic> thongKeDonHangTheoNhanVien(string ngayBatDau, string ngayKetThuc,string maNhanVien)
        {
            return donHangDAO.thongKeDonHangTheoNhanVien(ngayBatDau, ngayKetThuc,maNhanVien);
        }

        public IEnumerable<dynamic> thongKeDonHangTheoKhachHang(string ngayBatDau, string ngayKetThuc, string tenKhachHang, string soDienThoai)
        {
            return donHangDAO.thongKeDonHangTheoKhachHang(ngayBatDau, ngayKetThuc, tenKhachHang,soDienThoai);
        }

        public IEnumerable<dynamic> thongKeDonHangTheoSanPham(string ngayBatDau, string ngayKetThuc, string sanPham)
        {
            return donHangDAO.thongKeDonHangTheoSanPham(ngayBatDau, ngayKetThuc, sanPham);
        }

        public IEnumerable<dynamic> thongKeDonHangTheoDonGia(string ngayBatDau, string ngayKetThuc, string donGia)
        {
            return donHangDAO.thongKeDonHangTheoDonGia(ngayBatDau, ngayKetThuc, donGia);
        }

        public IEnumerable<dynamic> thongKeDonHangTheoDonGia( string donGia)
        {
            return donHangDAO.thongKeDonHangTheoDonGia(donGia);
        }
    }
}
