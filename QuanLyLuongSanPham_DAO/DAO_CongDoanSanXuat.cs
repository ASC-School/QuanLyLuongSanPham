using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Trần Văn Sỹ
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
            IEnumerable<dynamic> q;
            q = (
                from cd in dataBase.CongDoanSanXuats
                join sp in dataBase.SanPhams on cd.maSanPham equals sp.maSanPham
                select new { maCongDoan = cd.soThuTu, tenCongDoan = cd.tenCongDoan,donGia=cd.donGia, maSanPham = sp.maSanPham, tenSanPham = sp.tenSanPham, soLuongSanXuat = cd.soLuongSanPhamSanXuat });
            return q;
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
                temp.maSanPham = cd.MaSanPham;
                temp.soLuongSanPhamSanXuat = cd.SoLuongSanPhamSanXuat;
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
                cd.First().maSanPham = cdUpdate.MaSanPham;
                cd.First().soLuongSanPhamSanXuat = cdUpdate.SoLuongSanPhamSanXuat;
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
        public IEnumerable<CongDoanSanXuat> layAllDsCongDoan()
        {
            IEnumerable<CongDoanSanXuat> q = from n in dataBase.CongDoanSanXuats select n;
            return q;
        }
    }
}
