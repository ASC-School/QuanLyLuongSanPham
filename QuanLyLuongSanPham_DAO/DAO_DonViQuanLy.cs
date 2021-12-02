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
    public class DAO_DonViQuanLy
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_DonViQuanLy()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public IEnumerable<DonViQuanLy> layDanhSachDonViQUanLy()
        {
            IEnumerable<DonViQuanLy> q = from n in dataBase.DonViQuanLies select n;
            return q;
        }
        public DonViQuanLy checkIfExist(string strMaDonVi)
        {
            DonViQuanLy temp = (from n in dataBase.DonViQuanLies where n.maDonVi.Equals(strMaDonVi) select n).FirstOrDefault();
            if (temp != null)
                return temp;
            return null;
        }
        public bool themDonVi(DTO_DonViQuanLy dv)
        {
            string str = dv.MaDonVi;
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                DonViQuanLy temp = new DonViQuanLy();
                temp.maDonVi = dv.MaDonVi;
                temp.tenBoPhan = dv.TenBoPhan;
                temp.soLuongNhanVien = dv.SoLuongNhanVien;
                temp.maLoai = dv.MaLoaiNhanVien;
                dataBase.DonViQuanLies.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
        }
        public bool suaDonVi(DTO_DonViQuanLy dvUpdate)
        {
            IQueryable<DonViQuanLy> dv = dataBase.DonViQuanLies.Where(x => x.maDonVi.Equals(dvUpdate.MaDonVi));
            if (dv.Count() > 0)
            {
                dv.First().tenBoPhan = dvUpdate.TenBoPhan;
                dv.First().soLuongNhanVien = dvUpdate.SoLuongNhanVien;
                dv.First().maLoai = dvUpdate.MaLoaiNhanVien;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool xoaDonVi(string maDonVi)
        {
            DonViQuanLy dvTemp = dataBase.DonViQuanLies.Where(x => x.maDonVi.Equals(maDonVi)).FirstOrDefault();
            if(dvTemp!=null)
            {
                dataBase.DonViQuanLies.DeleteOnSubmit(dvTemp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
