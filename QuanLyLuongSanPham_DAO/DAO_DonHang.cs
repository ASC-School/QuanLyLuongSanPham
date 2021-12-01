using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_DonHang
    {
        QuanLyLuongSanPhamDataContext dataBase;
        DAO_ChiTietDonHang chiTietDAO;
        public DAO_DonHang()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
            chiTietDAO = new DAO_ChiTietDonHang();
        }

        public string ngayLonNhat()
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }).OrderByDescending(p => p.ngayBatDau);

            string ngay = dataLst.First().ngayBatDau;
            return ngay;
        }
        public bool checkExist(string maDonHang)
        {
            DonHang donHang = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            if(donHang != null)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<dynamic> layDSDonHang()
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           select new {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien,
                               trangThai = donHang.trangThai
                           }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        public IEnumerable<dynamic> layDSDonHangCoThanhTien()
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien,
                                                thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang),
                                                trangThai = donHang.trangThai
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        public List<DTO_DonHang> layToanBoDSDonHang()
        {
            var dataLSt = dataBase.DonHangs.Select(p => p).OrderBy(p => p.maDonHang);
            List<DTO_DonHang> lstDonHang = new List<DTO_DonHang>();

            foreach(var item in dataLSt)
            {
                DTO_DonHang donHang = new DTO_DonHang();
                donHang.MaDonHang = item.maDonHang;
                donHang.MaNhanVien = item.maNhanVien;
                donHang.NgayBatDau = item.ngayBatDau.Value;
                donHang.NgayKetThuc = item.ngayKetThuc.Value;
                donHang.NoiDung = item.noiDung;
                donHang.SoDienThoaiKhachHang = item.soDienThoaiKhachHang;
                donHang.TenKhachHang = item.tenKhachHang;
                donHang.TrangThai = item.trangThai.Value;
                lstDonHang.Add(donHang);
            }
            return lstDonHang;
        }

        public DTO_DonHang timKiemDonHang(string maDonHang)
        {
            DonHang tmp = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            DTO_DonHang donHang = new DTO_DonHang();
            donHang.MaDonHang = tmp.maDonHang;
            donHang.NgayBatDau = DateTime.Parse(tmp.ngayBatDau.ToString());
            donHang.NgayKetThuc = DateTime.Parse(tmp.ngayKetThuc.ToString());
            donHang.TenKhachHang = tmp.tenKhachHang;
            donHang.SoDienThoaiKhachHang = tmp.soDienThoaiKhachHang;
            donHang.NoiDung = tmp.noiDung;
            donHang.MaNhanVien = tmp.maNhanVien;
            donHang.TrangThai = tmp.trangThai.Value;
            return donHang;
        }
        public bool suaDonhang(DTO_DonHang newDonHang)
        {
            IQueryable<DonHang> donHang = dataBase.DonHangs.Where(p => p.maDonHang == newDonHang.MaDonHang);
            if(donHang.Count() >= 0)
            {
                donHang.First().ngayBatDau = newDonHang.NgayBatDau;
                donHang.First().ngayKetThuc = newDonHang.NgayKetThuc;
                donHang.First().tenKhachHang = newDonHang.TenKhachHang;
                donHang.First().soDienThoaiKhachHang = newDonHang.SoDienThoaiKhachHang;
                donHang.First().noiDung = newDonHang.NoiDung;
                donHang.First().maNhanVien = newDonHang.MaNhanVien;
                donHang.First().trangThai = newDonHang.TrangThai;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool themDonHang(DTO_DonHang donHang)
        {
            if (checkExist(donHang.MaDonHang))
                return false;
            DonHang donHangTMP = new DonHang();
           
            donHangTMP.maDonHang = donHang.MaDonHang;
            donHangTMP.ngayBatDau = donHang.NgayBatDau;
            donHangTMP.ngayKetThuc = donHang.NgayKetThuc;
            donHangTMP.tenKhachHang = donHang.TenKhachHang;
            donHangTMP.soDienThoaiKhachHang = donHang.SoDienThoaiKhachHang;
            donHangTMP.noiDung = donHang.NoiDung;
            donHangTMP.maNhanVien = donHang.MaNhanVien;
            donHangTMP.trangThai = donHang.TrangThai;

            dataBase.DonHangs.InsertOnSubmit(donHangTMP);
            dataBase.SubmitChanges();
            return true;

        }
         
        public bool xoaDonHang(string maDonHang)
        {
            DonHang donHangTmp = dataBase.DonHangs.Where(p => p.maDonHang == maDonHang).FirstOrDefault();
            IQueryable<ChiTietDonHang> lstChiTietDonHang = dataBase.ChiTietDonHangs.Where(p => p.maDonHang == maDonHang);
            if(donHangTmp != null)
            {
                dataBase.DonHangs.DeleteOnSubmit(donHangTmp);
                dataBase.SubmitChanges();
                if(lstChiTietDonHang.Count() > 0)
                {
                    foreach(ChiTietDonHang item in lstChiTietDonHang )
                    {
                        dataBase.ChiTietDonHangs.DeleteOnSubmit(item);
                        dataBase.SubmitChanges();
                    }
                    return true;
                }
                return true;
            }
            return false;
        }

        public string timTenKHTheoSDT(string soDienThoai)
        {
            DonHang tmp = dataBase.DonHangs.Where(p => p.soDienThoaiKhachHang == soDienThoai).FirstOrDefault();
            if (tmp == null) return null;
            DTO_DonHang donHang = new DTO_DonHang();
            donHang.MaDonHang = tmp.maDonHang;
            donHang.NgayBatDau = DateTime.Parse(tmp.ngayBatDau.ToString());
            donHang.NgayKetThuc = DateTime.Parse(tmp.ngayKetThuc.ToString());
            donHang.TenKhachHang = tmp.tenKhachHang;
            donHang.SoDienThoaiKhachHang = tmp.soDienThoaiKhachHang;
            donHang.NoiDung = tmp.noiDung;
            donHang.MaNhanVien = tmp.maNhanVien;
            donHang.TrangThai = tmp.trangThai.Value;
            return donHang.TenKhachHang;
        }
        //================== loc tim don hang


        public IEnumerable<dynamic> timKiemDHTheoNhanVienVaKhachHang(string maNhanVien, string tenKhachHang, string soDienThoaiKhachHang)
        {
            IEnumerable<dynamic> dataLst = null;
            if (tenKhachHang.Equals(""))
            {
                dataLst = (from donHang in dataBase.DonHangs
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           where donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang) && donHang.maNhanVien.Equals(maNhanVien)
                           select new
                           {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien
                           }).OrderBy(p => p.maDonHang);

            }else if (soDienThoaiKhachHang.Equals(""))
            {
                dataLst = (from donHang in dataBase.DonHangs
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.maNhanVien.Equals(maNhanVien)
                           select new
                           {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien
                           }).OrderBy(p => p.maDonHang);
            }
            else
            {
                dataLst = (from donHang in dataBase.DonHangs
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang)
                           select new
                           {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien
                           }).OrderBy(p => p.maDonHang);
            }
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDHTheoNhanVienVaKhachHangVaSanPhamVaDonHang(string maNhanVien, string soDienThoaiKhachHang,string tenKhachHang,string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = null;
            IEnumerable<dynamic> tmp = timKiemDHTheoNhanVienVaKhachHang(maNhanVien, tenKhachHang, soDienThoaiKhachHang);
            dataLst = tmp.Where(p => p.tenSanPham == tenSanPham && p.maDonHang == maDonHang);
            return dataLst;
        }
    
        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau_SanPham(string maNhanVien, string tenKhachHang, string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayKetThuc_SanPham(string maNhanVien, string tenKhachHang, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham(string maNhanVien, string soDienThoai, string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayBatDau_SanPham(string maNhanVien, string tenKhachHang,string soDienThoai, string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc_SanPham(string maNhanVien, string soDienThoaiKhachHang, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayKetThuc_SanPham(string maNhanVien,string tenKhachHang, string soDienThoaiKhachHang, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham(string maNhanVien, string tenKhachHang,string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_SanPham(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
       
        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau_MaDonHang(string maNhanVien, string tenKhachHang, string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_MaDonHang(string maNhanVien, string soDienThoaiKhachHang, string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayBatDau_MaDonHang(string maNhanVien,string ten, string soDienThoaiKhachHang, string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(ten) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_MaDonHang(string maNhanVien, string tenKhachHang, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_MaDonHang(string maNhanVien, string soDienThoai, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH(string maNhanVien, string tenKhachHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH(string maNhanVien, string soDienThoai)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang(string maNhanVien,string tenKhachHang, string soDienThoai)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayKetThuc_MaDonHang(string maNhanVien, string tenKhachHang, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc_MaDonHang(string maNhanVien, string soDienThoai, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }


        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayKetThuc_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_MaDonHang(string maNhanVien, string tenKhachHang, string ngayBatDau,string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_MaDonHang(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayBatDau_NgayKetThuc_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string tenKhachHang, string ngayBatDau,string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) &&sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string tenKhachHang,string soDienThoai, string ngayBatDau, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string soDienThoai, string ngayBatDau, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
       
        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string tenKhachHang, string ngayKerThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKerThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string soDienThoai, string ngayKerThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKerThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string tenKhachHang, string ngayBatDau,string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_ThoiGian_SanPham_MaDonHang(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) &&donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau(string maNhanVien, string tenKhachHang, string ngayBatDau)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) 
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau(string maNhanVien, string soDienThoai, string ngayBatDau)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayKetThuc(string maNhanVien, string tenKhachHang, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayKetThuc(string maNhanVien, string soDienThoai, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_NgayKetThuc(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_NgayBatDau_NgayKetThuc(string maNhanVien, string tenKhachHang, string ngayBatDau,string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_NgayBatDau_NgayKetThuc(string maNhanVien, string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_ThoiGian(string maNhanVien,string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(soDienThoai) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_TenKH_SanPham(string maNhanVien, string tenKhachHang, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang)  && sanPham.tenSanPham.Equals(tenSanPham) 
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SoDienThoaiKH_SanPham(string maNhanVien, string soDienThoai, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_KhachHang_SanPham(string maNhanVien,string tenKhachHang, string soDienThoai, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        //================== nhan vien + thoi gian
        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayBatDau_SanPham(string maNhanVien, string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayKetThuc_SanPham(string maNhanVien, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_ThoiGian_SanPham(string maNhanVien,string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) &&donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayBatDau_MaDonHang(string maNhanVien, string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayKetThuc_MaDonHang(string maNhanVien, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_ThoiGian_MaDonHang(string maNhanVien,string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayBatDau_SanPham_MaDonHang(string maNhanVien, string ngayBatDau, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayKetThuc_SanPham_MaDonHang(string maNhanVien, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_ThoiGian_SanPham_MaDonHang(string maNhanVien,string ngayBatDau, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayBatDau(string maNhanVien, string ngayBatDau)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayBatDau.Equals(ngayBatDau)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_NgayKetThuc(string maNhanVien, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNhanVien_ThoiGian(string maNhanVien,string ngayBatDau, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // ============== nhan  vien + sanPham
        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SanPham(string maNhanVien, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // =========== nhan vien + maDonHang
        public IEnumerable<dynamic> timKiemDhTheoNhanVien_MaDonHang(string maNhanVien, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // ============== nhan  vien + sanPham + donHang
        public IEnumerable<dynamic> timKiemDhTheoNhanVien_SanPham_MaDonHang(string maNhanVien, string tenSanPham,string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where nhanVien.maNhanVien.Equals(maNhanVien) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }


        //=================== KHACH HANG ================
        // get don hang theo ngaybat dau
        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayBatDau_SanPham(string tenKhachHang, string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayBatDau_MaDonHang(string tenKhachHang, string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayBatDau_SanPham_MaDonHang(string tenKhachHang, string ngayBatDau, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayBatDau(string tenKhachHang, string ngayBatDau)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // get don hangf ten+ ngay ket thuc
        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayKetThuc_SanPham(string tenKhachHang, string ngayKethuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKethuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayKetThuc_MaDonHang(string tenKhachHang, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayKetThuc_SanPham_MaDonHang(string tenKhachHang, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_NgayKetThuc(string tenKhachHang, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
        // tenKH + thoiGian
        public IEnumerable<dynamic> timKiemDhTheoTenKH_ThoiGian_SanPham(string tenKhachHang, string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_ThoiGian_MaDonHang(string tenKhachHang, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_ThoiGian_SanPham_MaDonHang(string tenKhachHang, string ngayBatDau, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoTenKH_ThoiGian(string tenKhachHang, string ngayBatDau, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        //tenkh + sanpham
        public IEnumerable<dynamic> timKiemDhTheoTenKH_SanPham(string tenKhachHang, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenSanPham) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // =========== tenKhachHang + maDonHang
        public IEnumerable<dynamic> timKiemDhTheoTenKH_MaDonHang(string tenKhachHang, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDonHangTheoTenKhachHang(string tenKhachHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDonHangTheoTenKhachHangCoThanhTien(string tenKhachHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien,
                                                thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        //==== sodienthoai khach hang
        // get don hang theo ngaybat dau
        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayBatDau_SanPham(string soDienThoai, string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayBatDau_MaDonHang(string soDienThoai, string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayBatDau_SanPham_MaDonHang(string soDienThoai, string ngayBatDau, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayBatDau(string soDIenThoai, string ngayBatDau)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDIenThoai) && donHang.ngayBatDau.Equals(ngayBatDau)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // get don hangf ten+ ngay ket thuc
        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayKetThuc_SanPham(string soDienThoai, string ngayKethuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKethuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayKetThuc_MaDonHang(string soDienThoai, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayKetThuc_SanPham_MaDonHang(string soDienThoai, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_NgayKetThuc(string soDienThoai, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
        // tenKH + thoiGian
        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_ThoiGian_SanPham(string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_ThoiGian_MaDonHang(string soDienThoai, string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_ThoiGian_SanPham_MaDonHang(string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_ThoiGian(string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang .Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        //tenkh + sanpham
        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_SanPham(string soDienThoai, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // =========== tenKhachHang + maDonHang
        public IEnumerable<dynamic> timKiemDhTheoSoDienThoaiKH_MaDonHang(string soDienThoai, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDonHangTheoSoDienThoaiKhachHang(string soDienThoaiKhachHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        //======================== khachHang(ten+sodienThoai)

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayBatDau_SanPham(string tenKhachHang,string soDienThoai, string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayBatDau_MaDonHang(string tenKhachHang, string soDienThoai, string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayBatDau_SanPham_MaDonHang(string tenKhachHang, string soDienThoai, string ngayBatDau, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayBatDau(string tenKhachHang, string soDienThoai,string ngayBatDau)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // get don hangf ten+ ngay ket thuc
        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayKetThuc_SanPham(string tenKhachHang, string soDienThoai, string ngayKethuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.tenKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKethuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayKetThuc_MaDonHang(string tenKhachHang, string soDienThoai,string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayKetThuc_SanPham_MaDonHang(string tenKhachHang, string soDienThoai, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_NgayKetThuc(string tenKhachHang, string soDienThoai, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
        // tenKH + thoiGian
        public IEnumerable<dynamic> timKiemDhTheoKhachHang_ThoiGian_SanPham(string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_ThoiGian_MaDonHang(string tenKhachHang, string soDienThoai,string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_ThoiGian_SanPham_MaDonHang(string tenKhachHang, string soDienThoai,string ngayBatDau, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoKhachHang_ThoiGian(string tenKhachHang, string soDienThoai, string ngayBatDau, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        //tenkh + sanpham
        public IEnumerable<dynamic> timKiemDhTheoKhachHang_SanPham(string tenKhachHang, string soDienThoai, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // =========== tenKhachHang + maDonHang
        public IEnumerable<dynamic> timKiemDhTheoKhachHang_MaDonHang(string tenKhachHang, string soDienThoai, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDonHangTheoKhachHang(string tenKhachHang, string soDienThoai)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDonHangTheoKhachHangCoThanhTien(string tenKhachHang, string soDienThoai)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoai)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien,
                                                thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }
        //======================================================================

        public IEnumerable<dynamic> timKiemDonHangTheoNhanVien(string maNhanVien)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.maNhanVien.Equals(maNhanVien)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDonHangTheoNhanVienCoThanhTien(string maNhanVien)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.maNhanVien.Equals(maNhanVien)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien,
                                                thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                            }).OrderBy(p => p.maDonHang);
            return dataLst;
        }

        //=========== tim khiem don hang theo thoi gian

        public IEnumerable<dynamic> timKiemDhTheoNgayBatDau_SanPham(string ngayBatDau, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNgayBatDau_MaDonHang(string ngayBatDau, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNgayBatDau_SanPham_MaDonHang(string ngayBatDau, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNgayBatDau(string ngayBatDau)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        // get don hang ngay ket thuc
        public IEnumerable<dynamic> timKiemDhTheoNgayKetThuc_SanPham(string ngayKethuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayKetThuc.Equals(ngayKethuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNgayKetThuc_MaDonHang(string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNgayKetThuc_SanPham_MaDonHang(string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoNgayKetThuc(string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
        // thoiGian
        public IEnumerable<dynamic> timKiemDhTheoThoiGian_SanPham(string ngayBatDau, string ngayKetThuc, string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoThoiGian_MaDonHang(string ngayBatDau, string ngayKetThuc, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheThoiGian_SanPham_MaDonHang(string ngayBatDau, string ngayKetThuc, string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc) && sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoThoiGian(string ngayBatDau, string ngayKetThuc)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.ngayBatDau.Equals(ngayBatDau) && donHang.ngayKetThuc.Equals(ngayKetThuc)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
        //=====================================
        public IEnumerable<dynamic> timKiemDonHangTheoSanPham(string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where sanPham.tenSanPham.Equals(tenSanPham)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
               ).OrderBy(p => p.maDonHang);

            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDonHangTheoSanPhamCoThanhTien(string tenSanPham)
        {
            IEnumerable<dynamic> dataLst = dataLst = (from donHang in dataBase.DonHangs
                                                      join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                                      join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                                      join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                                      where sanPham.tenSanPham.Equals(tenSanPham)
                                                      select new
                                                      {
                                                          maDonHang = donHang.maDonHang,
                                                          ngayBatDau = donHang.ngayBatDau,
                                                          ngayKetThuc = donHang.ngayKetThuc,
                                                          tenKhachHang = donHang.tenKhachHang,
                                                          soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                          noiDung = donHang.noiDung,
                                                          maNhanVien = donHang.maNhanVien,
                                                          tenNhanVien = nhanVien.tenNhanVien,
                                                          thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                                      }
                ).OrderBy(p => p.maDonHang);

            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoMaDonHang(string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }

        public IEnumerable<dynamic> timKiemDhTheoSanPham_MaDonHang(string tenSanPham, string maDonHang)
        {
            IEnumerable<dynamic> dataLst = (from donHang in dataBase.DonHangs
                                            join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                            join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                            join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                            where sanPham.tenSanPham.Equals(tenSanPham) && donHang.maDonHang.Equals(maDonHang)
                                            select new
                                            {
                                                maDonHang = donHang.maDonHang,
                                                ngayBatDau = donHang.ngayBatDau,
                                                ngayKetThuc = donHang.ngayKetThuc,
                                                tenKhachHang = donHang.tenKhachHang,
                                                soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                                noiDung = donHang.noiDung,
                                                maNhanVien = donHang.maNhanVien,
                                                tenNhanVien = nhanVien.tenNhanVien
                                            }
                ).OrderBy(p => p.maDonHang);
            if (dataLst == null) return null;
            return dataLst;
        }
        //================================
        public IEnumerable<dynamic> thongKeDonHangTheoNhanVien(string ngayBatDau,string ngayCuoi,string maNhanVien)
        {
            IEnumerable<dynamic> dataLst = null;
            if(!ngayBatDau.Equals("") && ngayCuoi.Equals("")) // thong ke theo ngay bat dau den ngay hien tai
            {
                try
                {
                    DateTime ngayBD = DateTime.Parse(ngayBatDau);
                    dataLst = (from donHang in dataBase.DonHangs
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau >= ngayBD && donHang.maNhanVien.Equals(maNhanVien)
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                ).OrderBy(p => p.maDonHang);
                }
                catch
                {

                }

            }
            else if(ngayBatDau.Equals("") && !ngayCuoi.Equals("")) // thong ke theo ngay cuoi tro ve truoc
            {
                DateTime ngayKT = DateTime.Parse(ngayCuoi);
                dataLst = (from donHang in dataBase.DonHangs
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           where donHang.ngayBatDau <= ngayKT && donHang.maNhanVien.Equals(maNhanVien)
                           select new
                           {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien,
                               thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                           }
                ).OrderBy(p => p.maDonHang);
            }
            else // thong ke don hang tu ngay bat dau den ngay ket thuc
            {
                try
                {
                    DateTime ngayBD = DateTime.Parse(ngayBatDau);
                    DateTime ngayKT = DateTime.Parse(ngayCuoi);
                    if (DateTime.Compare(ngayBD, ngayKT) < 0) return null;
                    dataLst = (from donHang in dataBase.DonHangs
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau >= ngayBD && donHang.ngayBatDau <= ngayKT && donHang.maNhanVien.Equals(maNhanVien)
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                    ).OrderBy(p => p.maDonHang);
                }
                catch
                {
                    
                }
                
            }
            return dataLst;
        }

        public IEnumerable<dynamic> thongKeDonHangTheoKhachHang(string ngayBatDau, string ngayCuoi, string tenKhachHang,string soDienThoaiKhachHang)
        {
            IEnumerable<dynamic> dataLst = null;
            if(!tenKhachHang.Equals("") && soDienThoaiKhachHang.Equals(""))// thong ke  theo ten khach hang ngay bat dau den ngay hien tai 
            {
                if (!ngayBatDau.Equals("") && ngayCuoi.Equals("")) 
                {
                    //DateTime ngayBD = DateTime.Parse(ngayBatDau);
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        dataLst = (from donHang in dataBase.DonHangs
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD && donHang.tenKhachHang.Equals(tenKhachHang)
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                   }
                    ).OrderBy(p => p.maDonHang);
                    }
                    catch
                    {

                    }

                }
                else if (ngayBatDau.Equals("") && !ngayCuoi.Equals("")) // thong ke theo tenkhachhang tu ngay cuoi tro ve truoc
                {
                    DateTime ngayKT = DateTime.Parse(ngayCuoi);
                    dataLst = (from donHang in dataBase.DonHangs
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau <= ngayKT && donHang.tenKhachHang.Equals(tenKhachHang)
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                    ).OrderBy(p => p.maDonHang);
                }
                else // thong ke don hang theo tenkh tu ngay bat dau den ngay ket thuc
                {
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        DateTime ngayKT = DateTime.Parse(ngayCuoi);
                        if (DateTime.Compare(ngayBD, ngayKT) < 0) return null;
                        dataLst = (from donHang in dataBase.DonHangs
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD && donHang.ngayBatDau <= ngayKT && donHang.tenKhachHang.Equals(tenKhachHang)
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                   }
                        ).OrderBy(p => p.maDonHang);
                    }
                    catch
                    {

                    }

                }
            }
            else // thong ke  theo khach hang(ten + so dien thoai) ngay bat dau den ngay hien tai 
            {
                if (!ngayBatDau.Equals("") && ngayCuoi.Equals("")) // thong ke theo ngay bat dau den ngay hien tai
                {
                    //DateTime ngayBD = DateTime.Parse(ngayBatDau);
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        dataLst = (from donHang in dataBase.DonHangs
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang)
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                   }
                    ).OrderBy(p => p.maDonHang);
                    }
                    catch
                    {

                    }

                }
                else if (ngayBatDau.Equals("") && !ngayCuoi.Equals("")) // thong ke theo ngay cuoi tro ve truoc
                {
                    DateTime ngayKT = DateTime.Parse(ngayCuoi);
                    dataLst = (from donHang in dataBase.DonHangs
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau <= ngayKT && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang)
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                    ).OrderBy(p => p.maDonHang);
                }
                else // thong ke don hang tu ngay bat dau den ngay ket thuc
                {
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        DateTime ngayKT = DateTime.Parse(ngayCuoi);
                        if (DateTime.Compare(ngayBD, ngayKT) < 0) return null;
                        dataLst = (from donHang in dataBase.DonHangs
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD && donHang.ngayBatDau <= ngayKT && donHang.tenKhachHang.Equals(tenKhachHang) && donHang.soDienThoaiKhachHang.Equals(soDienThoaiKhachHang)
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                   }
                        ).OrderBy(p => p.maDonHang);
                    }
                    catch
                    {

                    }

                }
            }
            

            return dataLst;
        }

        public IEnumerable<dynamic> thongKeDonHangTheoDonGia(string ngayBatDau, string ngayCuoi, string donGia)
        {
            IEnumerable<dynamic> dataLst = null;
            if(donGia.Equals("Từ thấp đến cao"))
            {
                if (!ngayBatDau.Equals("") && ngayCuoi.Equals("")) // thong ke theo dongia tu thap den cao ngay bat dau den ngay hien tai
                {
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        dataLst = (from donHang in dataBase.DonHangs
                                   join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                   join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD 
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)

                                   }
                    ).OrderBy(p => p.thanhTien);
                    }
                    catch
                    {

                    }

                }
                else if (ngayBatDau.Equals("") && !ngayCuoi.Equals("")) // thong ke theo sanpham ngay cuoi tro ve truoc
                {
                    DateTime ngayKT = DateTime.Parse(ngayCuoi);
                    dataLst = (from donHang in dataBase.DonHangs
                               join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                               join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau <= ngayKT
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                    ).OrderBy(p => p.thanhTien);
                }
                else // thong ke don hang theo sanpham tu ngay bat dau den ngay ket thuc
                {
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        DateTime ngayKT = DateTime.Parse(ngayCuoi);
                        if (DateTime.Compare(ngayBD, ngayKT) < 0) return null;
                        dataLst = (from donHang in dataBase.DonHangs
                                   join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                   join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD && donHang.ngayBatDau <= ngayKT 
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                   }
                        ).OrderBy(p => p.thanhTien);
                    }
                    catch
                    {

                    }

                }
            }
            else
            {
                if (!ngayBatDau.Equals("") && ngayCuoi.Equals("")) // thong ke theo dongia tu thap den cao ngay bat dau den ngay hien tai
                {
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        dataLst = (from donHang in dataBase.DonHangs
                                   join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                   join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)

                                   }
                    ).OrderByDescending(p => p.thanhTien);
                    }
                    catch
                    {

                    }

                }
                else if (ngayBatDau.Equals("") && !ngayCuoi.Equals("")) // thong ke theo sanpham ngay cuoi tro ve truoc
                {
                    DateTime ngayKT = DateTime.Parse(ngayCuoi);
                    dataLst = (from donHang in dataBase.DonHangs
                               join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                               join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau <= ngayKT
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                    ).OrderByDescending(p => p.thanhTien);
                }
                else // thong ke don hang theo sanpham tu ngay bat dau den ngay ket thuc
                {
                    try
                    {
                        DateTime ngayBD = DateTime.Parse(ngayBatDau);
                        DateTime ngayKT = DateTime.Parse(ngayCuoi);
                        if (DateTime.Compare(ngayBD, ngayKT) < 0) return null;
                        dataLst = (from donHang in dataBase.DonHangs
                                   join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                                   join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                                   join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                                   where donHang.ngayBatDau >= ngayBD && donHang.ngayBatDau <= ngayKT
                                   select new
                                   {
                                       maDonHang = donHang.maDonHang,
                                       ngayBatDau = donHang.ngayBatDau,
                                       ngayKetThuc = donHang.ngayKetThuc,
                                       tenKhachHang = donHang.tenKhachHang,
                                       soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                       noiDung = donHang.noiDung,
                                       maNhanVien = donHang.maNhanVien,
                                       tenNhanVien = nhanVien.tenNhanVien,
                                       thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                                   }
                        ).OrderByDescending(p => p.thanhTien);
                    }
                    catch
                    {

                    }

                }
            }
            
            return dataLst;
        }

        public IEnumerable<dynamic> thongKeDonHangTheoDonGia( string donGia)
        {
            IEnumerable<dynamic> dataLst = null;
            if (donGia.Equals("Từ thấp đến cao"))
            {
                dataLst = (from donHang in dataBase.DonHangs
                           join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                           join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           
                           select new
                           {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien,
                               thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                           }

                      ).OrderBy(p => p.maDonHang);
            }
            else
            {
                dataLst = (from donHang in dataBase.DonHangs
                           join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                           join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           
                           select new
                           {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien,
                               thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)

                           }
                     ).OrderBy(p => p.maDonHang);
            }

            return dataLst;
        }

        public IEnumerable<dynamic> thongKeDonHangTheoSanPham(string ngayBatDau, string ngayCuoi, string maSanPham)
        {
            IEnumerable<dynamic> dataLst = null;
            if (!ngayBatDau.Equals("") && ngayCuoi.Equals("")) // thong ke theo sanpham ngay bat dau den ngay hien tai
            {
                try
                {
                    DateTime ngayBD = DateTime.Parse(ngayBatDau);
                    dataLst = (from donHang in dataBase.DonHangs
                               join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                               join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau >= ngayBD && sanPham.tenSanPham.Equals(maSanPham)
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                ).OrderBy(p => p.maDonHang);
                }
                catch
                {

                }

            }
            else if (ngayBatDau.Equals("") && !ngayCuoi.Equals("")) // thong ke theo sanpham ngay cuoi tro ve truoc
            {
                DateTime ngayKT = DateTime.Parse(ngayCuoi);
                dataLst = (from donHang in dataBase.DonHangs
                           join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                           join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                           join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                           where donHang.ngayBatDau <= ngayKT && sanPham.tenSanPham.Equals(maSanPham)
                           select new
                           {
                               maDonHang = donHang.maDonHang,
                               ngayBatDau = donHang.ngayBatDau,
                               ngayKetThuc = donHang.ngayKetThuc,
                               tenKhachHang = donHang.tenKhachHang,
                               soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                               noiDung = donHang.noiDung,
                               maNhanVien = donHang.maNhanVien,
                               tenNhanVien = nhanVien.tenNhanVien,
                               thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                           }
                ).OrderBy(p => p.maDonHang);
            }
            else // thong ke don hang theo sanpham tu ngay bat dau den ngay ket thuc
            {
                try
                {
                    DateTime ngayBD = DateTime.Parse(ngayBatDau);
                    DateTime ngayKT = DateTime.Parse(ngayCuoi);
                    if (DateTime.Compare(ngayBD, ngayKT) < 0) return null;
                    dataLst = (from donHang in dataBase.DonHangs
                               join chiTietDonHang in dataBase.ChiTietDonHangs on donHang.maDonHang equals chiTietDonHang.maDonHang
                               join sanPham in dataBase.SanPhams on chiTietDonHang.maSanPham equals sanPham.maSanPham
                               join nhanVien in dataBase.NhanViens on donHang.maNhanVien equals nhanVien.maNhanVien
                               where donHang.ngayBatDau >= ngayBD && donHang.ngayBatDau <= ngayKT && sanPham.tenSanPham.Equals(maSanPham)
                               select new
                               {
                                   maDonHang = donHang.maDonHang,
                                   ngayBatDau = donHang.ngayBatDau,
                                   ngayKetThuc = donHang.ngayKetThuc,
                                   tenKhachHang = donHang.tenKhachHang,
                                   soDienThoaiKhachHang = donHang.soDienThoaiKhachHang,
                                   noiDung = donHang.noiDung,
                                   maNhanVien = donHang.maNhanVien,
                                   tenNhanVien = nhanVien.tenNhanVien,
                                   thanhTien = chiTietDAO.tongTienDonHang(donHang.maDonHang)
                               }
                    ).OrderBy(p => p.maDonHang);
                }
                catch
                {

                }

            }
            return dataLst;
        }
    }
}
