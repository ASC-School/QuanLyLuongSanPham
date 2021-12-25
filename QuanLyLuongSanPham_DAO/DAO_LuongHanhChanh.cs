using QuanLyLuongSanPham_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Đinh Quang Huy, Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 13/11/2021
     */
    public class DAO_LuongHanhChanh
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_LuongHanhChanh()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public IEnumerable<dynamic> layDSNVHanhChanh(int iMonth)
        {
            IEnumerable<dynamic> dsNVHC = from dv in dataBase.DonViQuanLies
                                          join lnv in dataBase.LoaiNhanViens
                                          on dv.maLoai equals lnv.maLoai
                                          join nv in dataBase.NhanViens
                                          on lnv.maLoai equals nv.maLoai
                                          join lhc in dataBase.LuongHanhChanhs
                                          on nv.maNhanVien equals lhc.maNhanVien
                                          join mtp in dataBase.MucTienPhats
                                          on lhc.maTienPhat equals mtp.soThuTu
                                          where lhc.thangLuong.Equals(iMonth)
                                          select new
                                          {
                                              maNV = nv.maNhanVien,
                                              tenNV = nv.tenNhanVien,
                                              donVi = dv.tenBoPhan,
                                              luongCoBan = lhc.luongCoBan,
                                              soNgayCongTT = lhc.soNgayLamDuoc,
                                              phuCap = lhc.phuCap,
                                              tienPhat = mtp.mucTienPhat1,
                                              thue = lhc.thue,
                                              tongLuongTT = ((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)),
                                              tienUng = lhc.tienUng,
                                              thucNhan = (((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap)) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)) - lhc.tienUng
                                          };
            return dsNVHC;
        }

        public object loadLuongHCTheoThangMoi(int iMonth, int iYear)
        {
            IEnumerable<dynamic> luongHCTheoThang = from dv in dataBase.DonViQuanLies
                                                    join lnv in dataBase.LoaiNhanViens
                                                    on dv.maLoai equals lnv.maLoai
                                                    join nv in dataBase.NhanViens
                                                    on lnv.maLoai equals nv.maLoai
                                                    join lhc in dataBase.LuongHanhChanhs
                                                    on nv.maNhanVien equals lhc.maNhanVien
                                                    join mtp in dataBase.MucTienPhats
                                                    on lhc.maTienPhat equals mtp.soThuTu
                                                    where lhc.thangLuong.Equals(iMonth)
                                                    select new
                                                    {
                                                        maNV = nv.maNhanVien,
                                                        tenNV = nv.tenNhanVien,
                                                        donVi = dv.tenBoPhan,
                                                        luongCoBan = lhc.luongCoBan,
                                                        soNgayCongTT = lhc.soNgayLamDuoc,
                                                        phuCap = lhc.phuCap,
                                                        tienPhat = mtp.mucTienPhat1,
                                                        thue = lhc.thue,
                                                        tongLuongTT = ((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)),
                                                        tienUng = lhc.tienUng,
                                                        thucNhan = (((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap)) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)) - lhc.tienUng
                                                    };
            return luongHCTheoThang;
        }

        public object layNVTimKiemTheoMa(string strMaNV)
        {
            IEnumerable<dynamic> luongCNTheoTimkiem = from dv in dataBase.DonViQuanLies
                                                      join lnv in dataBase.LoaiNhanViens
                                                      on dv.maLoai equals lnv.maLoai
                                                      join nv in dataBase.NhanViens
                                                      on lnv.maLoai equals nv.maLoai
                                                      join lhc in dataBase.LuongHanhChanhs
                                                      on nv.maNhanVien equals lhc.maNhanVien
                                                      join mtp in dataBase.MucTienPhats
                                                      on lhc.maTienPhat equals mtp.soThuTu
                                                      where lhc.maNhanVien.Equals(strMaNV)
                                                      select new
                                                      {
                                                          maNV = nv.maNhanVien,
                                                          tenNV = nv.tenNhanVien,
                                                          donVi = dv.tenBoPhan,
                                                          luongCoBan = lhc.luongCoBan,
                                                          soNgayCongTT = lhc.soNgayLamDuoc,
                                                          phuCap = lhc.phuCap,
                                                          tienPhat = mtp.mucTienPhat1,
                                                          thue = lhc.thue,
                                                          tongLuongTT = ((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)),
                                                          tienUng = lhc.tienUng,
                                                          thucNhan = (((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap)) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)) - lhc.tienUng
                                                      };
            return luongCNTheoTimkiem;
        }

        public bool suaTTNVHC(DTO_LuongHanhChanh lCN)
        {
            IQueryable<LuongHanhChanh> lhc = dataBase.LuongHanhChanhs.Where(x => x.maNhanVien.Trim().Equals(lCN.MaNhanVien) && x.thangLuong.Equals(lCN.ThangLuong) && x.namLuong.Equals(lCN.NamLuong));
            if (lhc.Count() > 0)
            {
                lhc.First().soNgayLamDuoc = lCN.SoNgayLamDuoc;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public object layDSNVHCTheoThangNam(int iMonth, int iYear)
        {
            IEnumerable<dynamic> luongHCTheoThang = from dv in dataBase.DonViQuanLies
                                                    join lnv in dataBase.LoaiNhanViens
                                                    on dv.maLoai equals lnv.maLoai
                                                    join nv in dataBase.NhanViens
                                                    on lnv.maLoai equals nv.maLoai
                                                    join lhc in dataBase.LuongHanhChanhs
                                                    on nv.maNhanVien equals lhc.maNhanVien
                                                    join mtp in dataBase.MucTienPhats
                                                    on lhc.maTienPhat equals mtp.soThuTu
                                                    where lhc.thangLuong.Equals(iMonth) && lhc.namLuong.Equals(iYear)
                                                    select new
                                                    {
                                                        maNV = nv.maNhanVien,
                                                        tenNV = nv.tenNhanVien,
                                                        donVi = dv.tenBoPhan,
                                                        luongCoBan = lhc.luongCoBan,
                                                        soNgayCongTT = lhc.soNgayLamDuoc,
                                                        phuCap = lhc.phuCap,
                                                        tienPhat = mtp.mucTienPhat1,
                                                        thue = lhc.thue,
                                                        tongLuongTT = ((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)),
                                                        tienUng = lhc.tienUng,
                                                        thucNhan = (((((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc) + lhc.phuCap)) - (((lhc.luongCoBan / 26) * lhc.soNgayLamDuoc * 10 / 100) + mtp.mucTienPhat1)) - lhc.tienUng
                                                    };
            return luongHCTheoThang;
        }
        public IEnumerable<LuongHanhChanh> layThongTinLuongCaNhan(string strMaNhanVien)
        {
            IEnumerable<LuongHanhChanh> luongCaNhan = from tt in dataBase.LuongHanhChanhs
                                                      where tt.maNhanVien.Equals(strMaNhanVien)
                                                      select tt;
            return luongCaNhan;
        }


        public IEnumerable<PhieuChamCongNhanVienHanhChanh> layDSCHamCong(string maNhanVien)
        {
            IEnumerable<PhieuChamCongNhanVienHanhChanh> q = from n in dataBase.PhieuChamCongNhanVienHanhChanhs
                                                            where n.maNhanVien.Contains(maNhanVien) 
                                                            select n;
            return q;
        }
    }
}
