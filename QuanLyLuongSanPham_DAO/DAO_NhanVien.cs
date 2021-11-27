using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public IEnumerable<NhanVien> layAllDSNV()
        {
            IEnumerable<NhanVien> q = from n in dataBase.NhanViens select n;
            return q;
        }
        public IEnumerable<NhanVien> layTTNhanVienTheoMa(string maNhanVien)
        {
            IEnumerable<NhanVien> q = from n in dataBase.NhanViens where n.maNhanVien.Equals(maNhanVien) select n;
            return q;
        }

        public DTO_NhanVien layMotNhanVien(string maNhanVien)
        {
            NhanVien nvTemp = dataBase.NhanViens.Where(p => p.maNhanVien == maNhanVien).FirstOrDefault();
            if (nvTemp != null)
            {
                DTO_NhanVien nhanVien = new DTO_NhanVien();
                nhanVien.MaNhanVien = nvTemp.maNhanVien;
                nhanVien.MaLoai = nvTemp.maLoai;
                nhanVien.NgayBatDauCongTac = nvTemp.ngayBatDauCongTac;
                nhanVien.TenNhanVien = nvTemp.tenNhanVien;
                nhanVien.GioiTinh = nvTemp.gioiTinh;
                nhanVien.SoDienThoai = nvTemp.soDienThoai;
                nhanVien.DiaChi = nvTemp.diaChi;
                nhanVien.NgaySinh = nvTemp.ngaySinh;
                nhanVien.TrangThai = nvTemp.trangThai.Value;
                
                return nhanVien;
            }
            return null;
        }
        public IEnumerable<NhanVien> layDSCongNhan()
        {
            IEnumerable<NhanVien> q;
            q = (from nv in dataBase.NhanViens
                 join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                 where (loaiNV.maLoai.Equals("LNV002"))
                 select nv);
            return q;
        }
        public List<DTO_NhanVien> layToanBoDanhSachNhanVien()
        {
            var dataLst = (from nv in dataBase.NhanViens where (nv.maLoai.Equals("LNV001")) select nv);
            List<DTO_NhanVien> lst = new List<DTO_NhanVien>();
            foreach (NhanVien nv in dataLst)
            {
                DTO_NhanVien tmp = new DTO_NhanVien();
                tmp.MaNhanVien = nv.maNhanVien;
                tmp.TenNhanVien = nv.tenNhanVien;
                tmp.DiaChi = nv.diaChi;
                tmp.SoDienThoai = nv.soDienThoai;
                tmp.NgayBatDauCongTac = nv.ngayBatDauCongTac;
                tmp.NgaySinh = nv.ngaySinh;
                tmp.GioiTinh = nv.gioiTinh;
                tmp.TrangThai = (bool)nv.trangThai;
                tmp.LoaiNhanVien = nv.LoaiNhanVien.ToString();
                lst.Add(tmp);
            }
            return lst;
        }
        public IEnumerable<dynamic> getDanhSachNVToQLNS()
        {
            IEnumerable<dynamic> q;
            q = (from dsnv in dataBase.NhanViens
                 join loaiNV in dataBase.LoaiNhanViens on dsnv.maLoai equals loaiNV.maLoai
                 join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                 select new { Mã_nhân_viên = dsnv.maNhanVien, Tên_nhân_viên = dsnv.tenNhanVien, Giới_tính = dsnv.gioiTinh, SDT = dsnv.soDienThoai, Địa_chỉ = dsnv.diaChi, Ngày_sinh = dsnv.ngaySinh, Ngày_vào_làm = dsnv.ngayBatDauCongTac, Loại_Nv = loaiNV.loaiNhanVien1, Đơn_vị_quản_lí = donvi.tenBoPhan, Trạng_thái = dsnv.trangThai });
            return q;
        }
        public IEnumerable<dynamic> serchNhanVienLuongCN(string maNV, string tenNV, string strThang)
        {
            if (maNV != "" && tenNV != "dataSearchOne")
            {
                IEnumerable<dynamic> luongCNTheoThang = from dv in dataBase.DonViQuanLies
                                                        join lnv in dataBase.LoaiNhanViens
                                                        on dv.maLoai equals lnv.maLoai
                                                        join nv in dataBase.NhanViens
                                                        on lnv.maLoai equals nv.maLoai
                                                        join lcn in dataBase.LuongCongNhans
                                                        on nv.maNhanVien equals lcn.maNhanVien
                                                        join mtp in dataBase.MucTienPhats
                                                        on lcn.maTienPhat equals mtp.soThuTu
                                                        join cdsx in dataBase.CongDoanSanXuats
                                                        on lcn.maCongDoan equals cdsx.soThuTu
                                                        where nv.maNhanVien.Contains(maNV) && lcn.thangLuong.Equals(strThang)
                                                        select new
                                                        {
                                                            maNV = nv.maNhanVien,
                                                            tenNV = nv.tenNhanVien,
                                                            donVi = dv.tenBoPhan,
                                                            thang = lcn.thangLuong,
                                                            nam = lcn.namLuong,
                                                            congDoan = cdsx.tenCongDoan,
                                                            soLuongSPLamDuoc = lcn.soLuongSanPham,
                                                            phuCap = lcn.phuCap,
                                                            tienPhat = mtp.mucTienPhat1,
                                                            thue = lcn.thue,
                                                            tongLuongTT = ((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100) - mtp.mucTienPhat1),
                                                            tamUng = lcn.tienUng,
                                                            thucNhan = (((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - mtp.mucTienPhat1 - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100)) - lcn.tienUng)
                                                        };
                return luongCNTheoThang;
            }
            else if (maNV == "" && tenNV != "DataSearchOne")
            {
                IEnumerable<dynamic> luongCNTheoThang = from dv in dataBase.DonViQuanLies
                                                        join lnv in dataBase.LoaiNhanViens
                                                        on dv.maLoai equals lnv.maLoai
                                                        join nv in dataBase.NhanViens
                                                        on lnv.maLoai equals nv.maLoai
                                                        join lcn in dataBase.LuongCongNhans
                                                        on nv.maNhanVien equals lcn.maNhanVien
                                                        join mtp in dataBase.MucTienPhats
                                           on lcn.maTienPhat equals mtp.soThuTu
                                                        join cdsx in dataBase.CongDoanSanXuats
                                                        on lcn.maCongDoan equals cdsx.soThuTu
                                                        where nv.tenNhanVien.Contains(tenNV)
                                                        select new
                                                        {
                                                            maNV = nv.maNhanVien,
                                                            tenNV = nv.tenNhanVien,
                                                            donVi = dv.tenBoPhan,
                                                            thang = lcn.thangLuong,
                                                            nam = lcn.namLuong,
                                                            congDoan = cdsx.tenCongDoan,
                                                            soLuongSPLamDuoc = lcn.soLuongSanPham,
                                                            phuCap = lcn.phuCap,
                                                            tienPhat = mtp.mucTienPhat1,
                                                            thue = lcn.thue,
                                                            tongLuongTT = ((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100) - mtp.mucTienPhat1),
                                                            tamUng = lcn.tienUng,
                                                            thucNhan = (((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - mtp.mucTienPhat1 - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100)) - lcn.tienUng)
                                                        };
                return luongCNTheoThang;
            }
            else if (maNV != "" && tenNV != "dataSearchOne")
            {
                IEnumerable<dynamic> luongCNTheoThang = from dv in dataBase.DonViQuanLies
                                                        join lnv in dataBase.LoaiNhanViens
                                                        on dv.maLoai equals lnv.maLoai
                                                        join nv in dataBase.NhanViens
                                                        on lnv.maLoai equals nv.maLoai
                                                        join lcn in dataBase.LuongCongNhans
                                                        on nv.maNhanVien equals lcn.maNhanVien
                                                        join mtp in dataBase.MucTienPhats
                                                        on lcn.maTienPhat equals mtp.soThuTu
                                                        join cdsx in dataBase.CongDoanSanXuats
                                                        on lcn.maCongDoan equals cdsx.soThuTu
                                                        where nv.tenNhanVien.Equals(maNV)
                                                        select new
                                                        {
                                                            maNV = nv.maNhanVien,
                                                            tenNV = nv.tenNhanVien,
                                                            donVi = dv.tenBoPhan,
                                                            thang = lcn.thangLuong,
                                                            nam = lcn.namLuong,
                                                            congDoan = cdsx.tenCongDoan,
                                                            soLuongSPLamDuoc = lcn.soLuongSanPham,
                                                            phuCap = lcn.phuCap,
                                                            tienPhat = mtp.mucTienPhat1,
                                                            thue = lcn.thue,
                                                            tongLuongTT = ((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100) - mtp.mucTienPhat1),
                                                            tamUng = lcn.tienUng,
                                                            thucNhan = (((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - mtp.mucTienPhat1 - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100)) - lcn.tienUng)
                                                        };
                return luongCNTheoThang;
            }
            else if (maNV != "" && tenNV == "dataSearchOne" && strThang == "dataSearchSecond")
            {
                IEnumerable<dynamic> luongCNTheoThang = from dv in dataBase.DonViQuanLies
                                                        join lnv in dataBase.LoaiNhanViens
                                                        on dv.maLoai equals lnv.maLoai
                                                        join nv in dataBase.NhanViens
                                                        on lnv.maLoai equals nv.maLoai
                                                        join lcn in dataBase.LuongCongNhans
                                                        on nv.maNhanVien equals lcn.maNhanVien
                                                        join mtp in dataBase.MucTienPhats
                                           on lcn.maTienPhat equals mtp.soThuTu
                                                        join cdsx in dataBase.CongDoanSanXuats
                                                        on lcn.maCongDoan equals cdsx.soThuTu
                                                        where nv.maNhanVien.Equals(maNV)
                                                        select new
                                                        {
                                                            maNV = nv.maNhanVien,
                                                            tenNV = nv.tenNhanVien,
                                                            donVi = dv.tenBoPhan,
                                                            thang = lcn.thangLuong,
                                                            nam = lcn.namLuong,
                                                            congDoan = cdsx.tenCongDoan,
                                                            soLuongSPLamDuoc = lcn.soLuongSanPham,
                                                            phuCap = lcn.phuCap,
                                                            tienPhat = mtp.mucTienPhat1,
                                                            thue = lcn.thue,
                                                            tongLuongTT = ((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100) - mtp.mucTienPhat1),
                                                            tamUng = lcn.tienUng,
                                                            thucNhan = (((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - mtp.mucTienPhat1 - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100)) - lcn.tienUng)
                                                        };
                return luongCNTheoThang;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<NhanVien> layTenNhanVien()
        {
            IEnumerable<NhanVien> tenNV = (IEnumerable<NhanVien>)(from nv in dataBase.NhanViens
                                                                  join lcn in dataBase.LuongCongNhans
                                                                  on nv.maNhanVien equals lcn.maNhanVien
                                                                  where nv.maNhanVien.Contains(lcn.maNhanVien)
                                                                  select new
                                                                  {
                                                                      Mã_nhân_viên = nv.maNhanVien,
                                                                      Tên_nhân_viên = nv.tenNhanVien,
                                                                      Giới_tính = nv.gioiTinh,
                                                                      SDT = nv.soDienThoai,
                                                                      Địa_chỉ = nv.diaChi,
                                                                      Ngày_sinh = nv.ngaySinh,
                                                                      Ngày_vào_làm = nv.ngayBatDauCongTac,
                                                                      Trạng_thái = nv.trangThai
                                                                  }); ;
            return tenNV;
        }

        public IEnumerable<dynamic> getDanhSachNvSauLoc(string maLoai, string trangThai, DateTime starDate, DateTime endDate)
        {
            IEnumerable<dynamic> q;
            //Lọc theo ngày vào làm
            if (maLoai == null && trangThai.Equals("Tất cả"))
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }
            // Lọc theo ngày công tác và trạng thái đi làm
            else if (maLoai == null && trangThai.Equals("Đi làm"))
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     where (nv.trangThai == true)
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }
            //lọc theo ngày công tác và trạng thái nghỉ làm
            else if (maLoai == null && trangThai.Equals("Nghỉ làm"))
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     where (nv.trangThai == false)
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }
            //Lọc theo mã loại
            else if (maLoai != null && trangThai.Equals("Tất cả"))
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     where (loaiNV.maLoai.Equals(maLoai))
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }
            else if (maLoai != null && trangThai.Equals("Đi làm"))
            {
                if (maLoai.Contains("LNV002"))
                {
                    q = (from nv in dataBase.NhanViens
                         join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                         join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                         join pChamCong in dataBase.PhieuChamCongCongNhans on nv.maNhanVien equals pChamCong.maNhanVien
                         where (pChamCong.ngayChamCong >= starDate && pChamCong.ngayChamCong <= endDate && nv.maLoai.Equals(maLoai) && pChamCong.diLam == true)
                         select new
                         {
                             Mã_nhân_viên = nv.maNhanVien,
                             Tên_nhân_viên = nv.tenNhanVien,
                             Giới_tính = nv.gioiTinh,
                             SDT = nv.soDienThoai,
                             Địa_chỉ = nv.diaChi,
                             Ngày_sinh = nv.ngaySinh,
                             Ngày_vào_làm = nv.ngayBatDauCongTac,
                             Loại_Nv = loaiNV.loaiNhanVien1,
                             Đơn_vị_quản_lí = donvi.tenBoPhan,
                             Trạng_thái = nv.trangThai
                         });
                }
                else
                {
                    q = (from nv in dataBase.NhanViens
                         join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                         join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                         join pChamCong in dataBase.PhieuChamCongNhanVienHanhChanhs on nv.maNhanVien equals pChamCong.maNhanVien
                         where (pChamCong.ngayChamCong >= starDate && pChamCong.ngayChamCong <= endDate && loaiNV.maLoai.Equals(maLoai) && pChamCong.diLam == true)
                         select new
                         {
                             Mã_nhân_viên = nv.maNhanVien,
                             Tên_nhân_viên = nv.tenNhanVien,
                             Giới_tính = nv.gioiTinh,
                             SDT = nv.soDienThoai,
                             Địa_chỉ = nv.diaChi,
                             Ngày_sinh = nv.ngaySinh,
                             Ngày_vào_làm = nv.ngayBatDauCongTac,
                             Loại_Nv = loaiNV.loaiNhanVien1,
                             Đơn_vị_quản_lí = donvi.tenBoPhan,
                             Trạng_thái = nv.trangThai
                         });
                }
            }
            else if (maLoai != null && trangThai.Equals("Nghỉ làm"))
            {
                if (maLoai.Contains("LNV002"))
                {
                    q = (from nv in dataBase.NhanViens
                         join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                         join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                         join pChamCong in dataBase.PhieuChamCongCongNhans on nv.maNhanVien equals pChamCong.maNhanVien
                         where (pChamCong.ngayChamCong >= starDate && pChamCong.ngayChamCong <= endDate && loaiNV.maLoai.Equals(maLoai) && pChamCong.diLam == false)
                         select new
                         {
                             Mã_nhân_viên = nv.maNhanVien,
                             Tên_nhân_viên = nv.tenNhanVien,
                             Giới_tính = nv.gioiTinh,
                             SDT = nv.soDienThoai,
                             Địa_chỉ = nv.diaChi,
                             Ngày_sinh = nv.ngaySinh,
                             Ngày_vào_làm = nv.ngayBatDauCongTac,
                             Loại_Nv = loaiNV.loaiNhanVien1,
                             Đơn_vị_quản_lí = donvi.tenBoPhan,
                             Trạng_thái = nv.trangThai
                         });
                }
                else
                {
                    q = (from nv in dataBase.NhanViens
                         join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                         join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                         join pChamCong in dataBase.PhieuChamCongNhanVienHanhChanhs on nv.maNhanVien equals pChamCong.maNhanVien
                         where (pChamCong.ngayChamCong >= starDate && pChamCong.ngayChamCong <= endDate && loaiNV.maLoai.Equals(maLoai) && pChamCong.diLam == false)
                         select new
                         {
                             Mã_nhân_viên = nv.maNhanVien,
                             Tên_nhân_viên = nv.tenNhanVien,
                             Giới_tính = nv.gioiTinh,
                             SDT = nv.soDienThoai,
                             Địa_chỉ = nv.diaChi,
                             Ngày_sinh = nv.ngaySinh,
                             Ngày_vào_làm = nv.ngayBatDauCongTac,
                             Loại_Nv = loaiNV.loaiNhanVien1,
                             Đơn_vị_quản_lí = donvi.tenBoPhan,
                             Trạng_thái = nv.trangThai
                         });
                }
            }
            else
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }
            return q;
        }
        public IEnumerable<dynamic> serchNhanVien(string maNV, string tenNhanVien, string loaiNhanVien)
        {
            IEnumerable<dynamic> q;
            if (maNV == "" && tenNhanVien == "")
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     where (loaiNV.loaiNhanVien1.Contains(loaiNhanVien))
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            else if (maNV == "" && loaiNhanVien == "")
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     where (nv.tenNhanVien.Contains(tenNhanVien))
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }

            else if (tenNhanVien == "" && loaiNhanVien == "")
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     where (nv.maNhanVien.Contains(maNV))
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }
            else if (maNV != "" || tenNhanVien != "" || loaiNhanVien != "")
            {
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     where (nv.maNhanVien.Contains(maNV) && nv.tenNhanVien.Contains(tenNhanVien) && loaiNV.loaiNhanVien1.Contains(loaiNhanVien))
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });
            }
            else
                q = (from nv in dataBase.NhanViens
                     join loaiNV in dataBase.LoaiNhanViens on nv.maLoai equals loaiNV.maLoai
                     join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                     select new
                     {
                         Mã_nhân_viên = nv.maNhanVien,
                         Tên_nhân_viên = nv.tenNhanVien,
                         Giới_tính = nv.gioiTinh,
                         SDT = nv.soDienThoai,
                         Địa_chỉ = nv.diaChi,
                         Ngày_sinh = nv.ngaySinh,
                         Ngày_vào_làm = nv.ngayBatDauCongTac,
                         Loại_Nv = loaiNV.loaiNhanVien1,
                         Đơn_vị_quản_lí = donvi.tenBoPhan,
                         Trạng_thái = nv.trangThai
                     });

            return q;
        }
        public IEnumerable<NhanVien> layNvTheoMa(string maNV)
        {
            IEnumerable<NhanVien> q;
            q = from n in dataBase.NhanViens where (n.maNhanVien.Equals(maNV)) select n;
            return q;
        }
        public bool themNhanVien(DTO_NhanVien nv)
        {
            string str = nv.MaNhanVien;
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                NhanVien temp = new NhanVien();
                temp.maNhanVien = nv.MaNhanVien;
                temp.tenNhanVien = nv.TenNhanVien;
                temp.gioiTinh = nv.GioiTinh;
                temp.soDienThoai = nv.SoDienThoai;
                temp.ngaySinh = nv.NgaySinh;
                temp.ngayBatDauCongTac = nv.NgayBatDauCongTac;
                temp.trangThai = nv.TrangThai;
                temp.avatar = nv.Avatar;
                temp.diaChi = nv.DiaChi;
                temp.maLoai = nv.MaLoai;
                dataBase.NhanViens.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
        }

        public bool suaThongTinNhanVien(DTO_NhanVien nvUpdate)
        {
            IQueryable<NhanVien> nv = dataBase.NhanViens.Where(x => x.maNhanVien.Equals(nvUpdate.MaNhanVien));
            if (nv.Count() > 0)
            {
                nv.First().tenNhanVien = nvUpdate.TenNhanVien;
                nv.First().gioiTinh = nvUpdate.GioiTinh;
                nv.First().soDienThoai = nvUpdate.SoDienThoai;
                nv.First().ngaySinh = nvUpdate.NgaySinh;
                nv.First().ngayBatDauCongTac = nvUpdate.NgayBatDauCongTac;
                nv.First().trangThai = nvUpdate.TrangThai;
                nv.First().avatar = nvUpdate.Avatar;
                nv.First().diaChi = nvUpdate.DiaChi;
                nv.First().maLoai = nvUpdate.MaLoai;
                dataBase.SubmitChanges();
                return true;

            }
            return false;
        }
        public bool delNhanVien(string maNv)
        {
            NhanVien nvTemp = dataBase.NhanViens.Where(x => x.maNhanVien.Equals(maNv)).FirstOrDefault();
            if (nvTemp != null)
            {
                dataBase.NhanViens.DeleteOnSubmit(nvTemp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public NhanVien checkIfExist(string strMaNhanVien)
        {
            NhanVien nvTemp = (from n in dataBase.NhanViens where n.maNhanVien.Equals(strMaNhanVien) select n).FirstOrDefault();
            if (nvTemp != null)
                return nvTemp;
            return null;
        }
    }
}