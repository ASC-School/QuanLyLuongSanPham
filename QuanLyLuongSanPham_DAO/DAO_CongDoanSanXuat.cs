using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Trần Văn Sỹ,Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DAO_CongDoanSanXuat
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_CongDoanSanXuat()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        
        public IEnumerable<dynamic> layDSCongDoan()
        {
            IEnumerable<dynamic> data;
            data = from congDoan in dataBase.CongDoanSanXuats
                   join sanPhamSX in dataBase.SanPhamSanXuats on congDoan.maSanPhamSanXuat equals sanPhamSX.maSanPhamSanXuat
                   
                   select new
                   {
                       soThuTu = congDoan.soThuTu,
                       tenCongDoan = congDoan.tenCongDoan,
                       donGia = congDoan.donGia,
                       thuTuCongDoan = congDoan.thuTuCongDoan,
                       maSanPhamSanXuat = sanPhamSX.maSanPhamSanXuat,
                       tenSanPhamSanXuat = sanPhamSX.tenSanPham,
                       soLuongSanXuat = sanPhamSX.soLuongSanXuat,
                       maRangBuoc = congDoan.maRangBuoc,
                       ngayBatDau = congDoan.ngayBatDau,
                       ngayKetThuc = congDoan.ngayKetThuc,
                       trangThai = congDoan.trangThai
                   };

            return data;
        }
        public IEnumerable<dynamic> layDSCongDoanChuaHoanThanh()
        {
            IEnumerable<dynamic> data;
            data = from congDoan in dataBase.CongDoanSanXuats
                   join sanPhamSX in dataBase.SanPhamSanXuats on congDoan.maSanPhamSanXuat equals sanPhamSX.maSanPhamSanXuat
                   where congDoan.trangThai == false
                   select new
                   {
                       soThuTu = congDoan.soThuTu,
                       tenCongDoan = congDoan.tenCongDoan,
                       donGia = congDoan.donGia,
                       thuTuCongDoan = congDoan.thuTuCongDoan,
                       maSanPhamSanXuat = sanPhamSX.maSanPhamSanXuat,
                       tenSanPhamSanXuat = sanPhamSX.tenSanPham,
                       soLuongSanXuat = sanPhamSX.soLuongSanXuat,
                       maRangBuoc = congDoan.maRangBuoc,
                       ngayBatDau = congDoan.ngayBatDau,
                       ngayKetThuc = congDoan.ngayKetThuc,
                       trangThai = congDoan.trangThai
                   };

            return data;
        }

        public CongDoanSanXuat checkIfExist(string strMaCongDoan)
        {
            CongDoanSanXuat temp = (from n in dataBase.CongDoanSanXuats where n.soThuTu.Equals(strMaCongDoan) select n).FirstOrDefault();
            if (temp != null)
                return temp;
            return null;
        }

        public IEnumerable<CongDoanSanXuat> layDonGia(string strmaNV)
        {
            IEnumerable<CongDoanSanXuat> cdsx = from lcn in dataBase.LuongCongNhans
                                                join cd in dataBase.CongDoanSanXuats
                                                on lcn.maCongDoan equals cd.soThuTu
                                                where lcn.maNhanVien.Equals(strmaNV)
                                                select cd;
            return cdsx;
        }

        public List<DTO_CongDoanSanXuat> layCongDoanSanXuatTheoSanPham(string maSanPhamSanXuat)
        {
            IEnumerable<CongDoanSanXuat> cdsx = dataBase.CongDoanSanXuats.Where(p => p.maSanPhamSanXuat.Equals(maSanPhamSanXuat));
            if(cdsx != null)
            {
                List<DTO_CongDoanSanXuat> lstCongDoan = new List<DTO_CongDoanSanXuat>();
                foreach (var item in cdsx)
                {
                    DTO_CongDoanSanXuat temp = new DTO_CongDoanSanXuat();
                    temp.SoThuTu = item.soThuTu;
                    temp.TenCongDoan = item.tenCongDoan;
                    temp.DonGia = item.donGia.Value;
                    temp.ThuTuCongDoan = item.thuTuCongDoan;
                    temp.MaSanPhamSanXuat = item.maSanPhamSanXuat;
                    temp.MaRangBuoc = item.maRangBuoc;
                    temp.NgayBatDau = item.ngayBatDau.Value;
                    temp.NgayKetThuc = item.ngayKetThuc.Value;
                    temp.TrangThai = item.trangThai.Value;
                    lstCongDoan.Add(temp);
                    
                }
                return lstCongDoan;
            }
            return null;
        }
        public bool themCongDoan(DTO_CongDoanSanXuat cd)
        {
            string str = cd.SoThuTu.ToString();
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                CongDoanSanXuat temp = new CongDoanSanXuat();
                temp.soThuTu = cd.SoThuTu;
                temp.tenCongDoan = cd.TenCongDoan;
                temp.donGia = cd.DonGia;
                temp.maSanPhamSanXuat = cd.MaSanPhamSanXuat;
                temp.maRangBuoc = cd.MaRangBuoc;
                temp.thuTuCongDoan = cd.ThuTuCongDoan;
                temp.ngayBatDau = cd.NgayBatDau;
                temp.ngayKetThuc = cd.NgayKetThuc;
                temp.trangThai = cd.TrangThai;
                dataBase.CongDoanSanXuats.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
        }
        public bool suaThongTinCongDoan(DTO_CongDoanSanXuat cdUpdate)
        {
            IQueryable<CongDoanSanXuat> cd = dataBase.CongDoanSanXuats.Where(x => x.soThuTu.Equals(cdUpdate.SoThuTu));
            if (cd.Count() > 0)
            {
                cd.First().tenCongDoan = cdUpdate.TenCongDoan;
                cd.First().donGia = cdUpdate.DonGia;
                cd.First().maSanPhamSanXuat = cdUpdate.MaSanPhamSanXuat;
                cd.First().maRangBuoc = cdUpdate.MaRangBuoc;
                cd.First().ngayBatDau = cdUpdate.NgayBatDau;
                cd.First().ngayKetThuc = cdUpdate.NgayKetThuc;
                cd.First().trangThai = cdUpdate.TrangThai;
                dataBase.SubmitChanges();
                return true;

            }
            return false;
        }
        public bool xoaCongDoan(int maCongDoan)
        {
            CongDoanSanXuat cdTemp = dataBase.CongDoanSanXuats.Where(x => x.soThuTu == maCongDoan).FirstOrDefault();
            if(cdTemp!= null)
            {
                dataBase.CongDoanSanXuats.DeleteOnSubmit(cdTemp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public IEnumerable<CongDoanSanXuat> layALLDsCD()
        {
            IEnumerable<CongDoanSanXuat> q = from n in dataBase.CongDoanSanXuats select n;
            return q;
        }
        public IEnumerable<CongDoanSanXuat> layALLDsCongDoanChuaHoanThanh()
        {
            IEnumerable<CongDoanSanXuat> q = from n in dataBase.CongDoanSanXuats where n.trangThai==false select n;
            return q;
        }
    }
}
