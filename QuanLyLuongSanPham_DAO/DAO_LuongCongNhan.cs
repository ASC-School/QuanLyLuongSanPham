﻿using QuanLyLuongSanPham_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DAO_LuongCongNhan
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_LuongCongNhan()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public IEnumerable<dynamic> loadLuongCN(int iMonth)
        {
            IEnumerable<dynamic> luongCN = from dv in dataBase.DonViQuanLies
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
                                           where lnv.maLoai == "LNV002" && lcn.thangLuong.Equals(iMonth)
                                           select new
                                           {
                                               maNV = nv.maNhanVien,
                                               tenNV = nv.tenNhanVien,
                                               donVi = dv.tenBoPhan,
                                               congDoan = cdsx.tenCongDoan,
                                               soLuongSPLamDuoc = lcn.soLuongSanPham,
                                               phuCap = lcn.phuCap,
                                               tienPhat = mtp.mucTienPhat1,
                                               thue = lcn.thue,
                                               tongLuongTT = ((((cdsx.donGia * lcn.soLuongSanPham) + lcn.phuCap)) - ((cdsx.donGia * lcn.soLuongSanPham * 10 / 100) + mtp.mucTienPhat1)),
                                               tamUng = lcn.tienUng,
                                               thucNhan = (((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - mtp.mucTienPhat1 - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100)) - lcn.tienUng)
                                           };
            return luongCN;
        }
        public IEnumerable<PhieuChamCongCongNhan> layDSChamCong(string maNhanVien)
        {
            IEnumerable<PhieuChamCongCongNhan> q = from n in dataBase.PhieuChamCongCongNhans
                                                   where n.maNhanVien.Contains(maNhanVien)
                                                   select n;
            return q;
        }
        public IEnumerable<LuongCongNhan> layThongTinLuongCaNhan(string strMaNhanVien)
        {
            IEnumerable<LuongCongNhan> luongCaNhan = from tt in dataBase.LuongCongNhans
                                                      where tt.maNhanVien.Equals(strMaNhanVien)
                                                      select tt;
            return luongCaNhan;
        }

        public object loadLuongCNTheoThangMoi(int iMonth, int iYear)
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
                                                    where lcn.thangLuong.Equals(iMonth) && lcn.namLuong.Equals(iYear) && lnv.maLoai == "LNV002"
                                                    select new
                                                    {
                                                        maNV = nv.maNhanVien,
                                                        tenNV = nv.tenNhanVien,
                                                        donVi = dv.tenBoPhan,
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

        public IEnumerable<LuongCongNhan> layNVTheoMa(string strMaNV)
        {
            IEnumerable<LuongCongNhan> luongCN = from lcn in dataBase.LuongCongNhans
                                                 where lcn.maNhanVien.Equals(strMaNV)
                                                 select lcn;
            return luongCN;
        }

        public IEnumerable<LuongHanhChanh> layMNVLuongHC()
        {
            IEnumerable<LuongHanhChanh> maNVLHC = (IEnumerable<LuongHanhChanh>)(from lcn in dataBase.LuongHanhChanhs
                                                                              select lcn);
            return maNVLHC;
        }

        public IEnumerable<LuongCongNhan> layMNVLuongCN()
        {
            IEnumerable<LuongCongNhan> maNVLCN = from lcn in dataBase.LuongCongNhans
                                                 select lcn;
            return maNVLCN;
        }

        public object layLuongNVTheoTimKiem(string maNVTK, string strThang, string strNam)
        {
            IEnumerable<dynamic> luongCNTheoTimkiem = from dv in dataBase.DonViQuanLies
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
                                                      where lcn.maNhanVien.Equals(maNVTK) && lnv.maLoai == "LNV002" && lcn.thangLuong.Equals(strThang) && lcn.namLuong.Equals(strNam)
                                                      select new
                                                      {
                                                          maNV = nv.maNhanVien,
                                                          tenNV = nv.tenNhanVien,
                                                          donVi = dv.tenBoPhan,
                                                          congDoan = cdsx.tenCongDoan,
                                                          soLuongSPLamDuoc = lcn.soLuongSanPham,
                                                          phuCap = lcn.phuCap,
                                                          tienPhat = mtp.mucTienPhat1,
                                                          thue = lcn.thue,
                                                          tongLuongTT = ((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100) - mtp.mucTienPhat1),
                                                          tamUng = lcn.tienUng,
                                                          thucNhan = (((cdsx.donGia * lcn.soLuongSanPham + lcn.phuCap) - mtp.mucTienPhat1 - (cdsx.donGia * lcn.soLuongSanPham * 10 / 100)) - lcn.tienUng)
                                                      };
            return luongCNTheoTimkiem;
        }

        public IEnumerable<dynamic> loadLuongCNTheoThang(int iMonth, int iYear)
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
                                                    where lcn.thangLuong.Equals(iMonth) && lcn.namLuong.Equals(iYear) && lnv.maLoai == "LNV002"
                                                    select new
                                                    {
                                                        maNV = nv.maNhanVien,
                                                        tenNV = nv.tenNhanVien,
                                                        donVi = dv.tenBoPhan,
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

        public bool suaTTNV(DTO_LuongCongNhan updateLCN)
        {
            IQueryable<LuongCongNhan> lcn = dataBase.LuongCongNhans.Where(x => x.maNhanVien.Trim().Equals(updateLCN.MaNhanVien) && x.thangLuong.Equals(updateLCN.ThangLuong) && x.namLuong.Equals(updateLCN.NamLuong));
            if (lcn.Count() > 0)
            {
                lcn.First().soLuongSanPham = updateLCN.SoLuongSanPhamLamDuoc;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<LuongCongNhan> layThongTinLuong(string maNhanVien)
        {
            IEnumerable<LuongCongNhan> q = from lcn in dataBase.LuongCongNhans
                                           where lcn.maNhanVien.Equals(maNhanVien)
                                           select lcn;
            return q;
        }
    }
}
