using QuanLyLuongSanPham_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public IEnumerable<dynamic> layDSNVChamCongTheoDonVi(string strDonVi, string day)
        {
            if (strDonVi.Equals("Bộ Phận Nhân Viên Văn Phòng"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                      diLam = pcchc.diLam,
                                                      diTre = pcchc.diTre,      
                                                  };
                return dsChamCong;
            }
            else if (strDonVi.Equals("Bộ Phận Gia Công Sản Xuất"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcccn in dataBase.PhieuChamCongCongNhans
                                                  on nv.maNhanVien equals pcccn.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcccn.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcccn.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                      diLam = pcccn.diLam,
                                                      diTre = pcccn.diTre,
                                                      soLuongSP = pcccn.soLuongSP
                                                  };
                return dsChamCong;
            }
            else if (strDonVi.Equals("Bộ Phận Quản Lý Lương"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                      diLam = pcchc.diLam,
                                                      diTre = pcchc.diTre,
                                                  };
                return dsChamCong;
            }
            else if (strDonVi.Equals("Bộ Phận Quản Lý Nhân Sự"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                      diLam = pcchc.diLam,
                                                      diTre = pcchc.diTre,
                                                  };
                return dsChamCong;
            }
            else
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                      diLam = pcchc.diLam,
                                                      diTre = pcchc.diTre,
                                                  };
                return dsChamCong;
            }
        }

        public bool suaTTChamCong(DTO_PhieuChamCongCongNhan dto_PCCLCN, string date)
        {
            //IQueryable<PhieuChamCongCongNhan> lcn = dataBase.PhieuChamCongCongNhans.Where(x => x.maNhanVien.Trim().Equals(dto_PCCLCN.MaNhanVien) && dto_PCCLCN.NgayChamCong.Equals(date));
            IEnumerable<PhieuChamCongCongNhan> pcn = from pcccn in dataBase.PhieuChamCongCongNhans
                                                     where pcccn.maNhanVien.Equals(dto_PCCLCN.MaNhanVien) && pcccn.ngayChamCong.Equals(date)
                                                     select pcccn;
            if (pcn.Count() > 0)
            {
                pcn.First().soLuongSP = dto_PCCLCN.ISoLuongSPLamTrongNgay;
                pcn.First().diLam = dto_PCCLCN.DiLam;
                pcn.First().diTre = dto_PCCLCN.DiTre;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool themPCCHC(DTO_PhieuChamCongNhanVienHanhChanh newPhieuCCHC)
        {
            PhieuChamCongNhanVienHanhChanh temp = new PhieuChamCongNhanVienHanhChanh();
            temp.maPhieu = newPhieuCCHC.MaPhieu;
            temp.ngayChamCong = newPhieuCCHC.NgayChamCong;
            temp.diLam = newPhieuCCHC.DiLam;
            temp.diTre = newPhieuCCHC.DiTre;
            temp.trangThai = newPhieuCCHC.TrangThai;
            temp.maNhanVien = newPhieuCCHC.MaNhanVien;
            dataBase.PhieuChamCongNhanVienHanhChanhs.InsertOnSubmit(temp);
            dataBase.SubmitChanges();
            return true;
        }

        public string layDongCuoiMaPCCHC()
        {
            var tempFileName = dataBase.PhieuChamCongNhanVienHanhChanhs
                         .OrderByDescending(x => x.maPhieu)
                         .Take(1)
                         .Select(x => x.maPhieu)
                         .FirstOrDefault();
            return tempFileName;
        }

        public PhieuChamCongCongNhan checkIfExist(string strPhieu)
        {
            PhieuChamCongCongNhan temp = (from n in dataBase.PhieuChamCongCongNhans where n.maPhieu.Equals(strPhieu) select n).FirstOrDefault();
            if (temp != null)
                return temp;
            return null;
        }
        public bool themPCCCN(DTO_PhieuChamCongCongNhan newPhieuCCCN)
        {
            string str = newPhieuCCCN.MaPhieu;
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                PhieuChamCongCongNhan temp = new PhieuChamCongCongNhan();
                temp.maPhieu = newPhieuCCCN.MaPhieu;
                temp.ngayChamCong = newPhieuCCCN.NgayChamCong;
                temp.diLam = newPhieuCCCN.DiLam;
                temp.diTre = newPhieuCCCN.DiTre;
                temp.soLuongSP = newPhieuCCCN.ISoLuongSPLamTrongNgay;
                temp.trangThai = newPhieuCCCN.TrangThai;
                temp.maNhanVien = newPhieuCCCN.MaNhanVien;
                temp.maCa = newPhieuCCCN.MaCa;
                dataBase.PhieuChamCongCongNhans.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
        }

        public string layDongCuoiMaPCCCN()
        {
            //var query = myQuery.AsEnumerable();
            //var lastRow = query.OrderByDescending(o => Convert.ToInt32(o.Code)).FirstOrDefault().Code
            var tempFileName = dataBase.PhieuChamCongCongNhans
                         .OrderByDescending(x => x.maPhieu)
                         .Take(1)
                         .Select(x => x.maPhieu)
                         .FirstOrDefault();
            //int j = 0;
            //IEnumerable<DTO_PhieuChamCongCongNhan> tempFileName = (IEnumerable<DTO_PhieuChamCongCongNhan>)(from pcc in dataBase.PhieuChamCongCongNhans
            //                                                      let i = j + 1
            //                                                      select pcc);

            return tempFileName;
        }

        public object danhSachChamCongHC(string strDonVi)
        {
            IEnumerable<dynamic> chamCong = from dv in dataBase.DonViQuanLies
                                            join lnv in dataBase.LoaiNhanViens
                                            on dv.maLoai equals lnv.maLoai
                                            join nv in dataBase.NhanViens
                                            on lnv.maLoai equals nv.maLoai
                                            join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                            on nv.maNhanVien equals pcchc.maNhanVien
                                            where dv.tenBoPhan.Equals(strDonVi)
                                            select new
                                            {
                                                maNV = nv.maNhanVien,
                                                hoTen = nv.tenNhanVien
                                            };
            return chamCong;
        }

        public IEnumerable<dynamic> danhSachChamCongCN()
        {
            IEnumerable<dynamic> chamCong = from nv in dataBase.NhanViens
                                            join lcn in dataBase.LuongCongNhans
                                            on nv.maNhanVien equals lcn.maNhanVien
                                            select new
                                            {
                                                maNV = nv.maNhanVien,
                                                hoTen = nv.tenNhanVien
                                            };
            return chamCong;
        }

        public bool ChamCongDateNowNVHanhChanh(DTO_PhieuChamCongNhanVienHanhChanh dto_PhieuCCNVHC)
        {
            IQueryable<PhieuChamCongCongNhan> lcn = dataBase.PhieuChamCongCongNhans.Where(x => x.maNhanVien.Trim().Equals(dto_PhieuCCNVHC.MaNhanVien) && (x.ngayChamCong.Equals(dto_PhieuCCNVHC.NgayChamCong)));
            if (lcn.Count() > 0)
            {
                lcn.First().diLam = dto_PhieuCCNVHC.DiLam;
                lcn.First().diTre = dto_PhieuCCNVHC.DiTre;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool suaTTChamCongNVHC(DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC, string date)
        {
            IQueryable<DTO_PhieuChamCongNhanVienHanhChanh> lhc = (IQueryable<DTO_PhieuChamCongNhanVienHanhChanh>)dataBase.PhieuChamCongNhanVienHanhChanhs.Where(x => x.maNhanVien.Trim().Equals(phieuChamCongNVHC.MaNhanVien) && (x.ngayChamCong.Equals(date)));
            if (lhc.Count() > 0)
            {
                lhc.First().DiLam = phieuChamCongNVHC.DiLam;
                lhc.First().DiTre = phieuChamCongNVHC.DiTre;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool ChamCongDateNow(DTO_PhieuChamCongCongNhan dto_PhieuCCCN)
        {
            IQueryable<PhieuChamCongCongNhan> lcn = dataBase.PhieuChamCongCongNhans.Where(x => x.maNhanVien.Trim().Equals(dto_PhieuCCCN.MaNhanVien) && (x.ngayChamCong.Equals(dto_PhieuCCCN.NgayChamCong)));
            if (lcn.Count() > 0)
            {
                lcn.First().diLam = dto_PhieuCCCN.DiLam;
                lcn.First().diTre = dto_PhieuCCCN.DiTre;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public object layDSNVChamCongDateNow(string strDonVi, string day)
        {
            if (strDonVi.Equals("Bộ Phận Nhân Viên Văn Phòng"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                  };
                return dsChamCong;
            }
            else if (strDonVi.Equals("Bộ Phận Gia Công Sản Xuất"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcccn in dataBase.PhieuChamCongCongNhans
                                                  on nv.maNhanVien equals pcccn.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcccn.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcccn.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                  };
                return dsChamCong;
            }
            else if (strDonVi.Equals("Bộ Phận Quản Lý Lương"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                  };
                return dsChamCong;
            }
            else if (strDonVi.Equals("Bộ Phận Quản Lý Nhân Sự"))
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                  };
                return dsChamCong;
            }
            else
            {
                IEnumerable<dynamic> dsChamCong = from dv in dataBase.DonViQuanLies
                                                  join lnv in dataBase.LoaiNhanViens
                                                  on dv.maLoai equals lnv.maLoai
                                                  join nv in dataBase.NhanViens
                                                  on lnv.maLoai equals nv.maLoai
                                                  join pcchc in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                  on nv.maNhanVien equals pcchc.maNhanVien
                                                  where dv.tenBoPhan.Equals(strDonVi) && pcchc.ngayChamCong.Equals(day)
                                                  select new
                                                  {
                                                      maNV = pcchc.maNhanVien,
                                                      hoTen = nv.tenNhanVien,
                                                  };
                return dsChamCong;
            }
        }

        public bool suaTTChamCongCN(DTO_PhieuChamCongCongNhan phieuChamCongCN, string date)
        {
            IQueryable<PhieuChamCongCongNhan> lcn = dataBase.PhieuChamCongCongNhans.Where(x => x.maNhanVien.Trim().Equals(phieuChamCongCN.MaNhanVien) && (x.ngayChamCong.Equals(date)));
            if (lcn.Count() > 0)
            {
                lcn.First().diLam = phieuChamCongCN.DiLam;
                lcn.First().diTre = phieuChamCongCN.DiTre;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
