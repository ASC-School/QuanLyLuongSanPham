using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    public class DAO_SanPham
    {
        QuanLyLuongSanPhamDataContext dataBase;

        public DAO_SanPham()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }
        public IEnumerable<SanPham> getSanPhams()
        {
            IEnumerable<SanPham> q = from n in dataBase.SanPhams select n;
            return q;
        }

        public DTO_SanPham getSP(string maSanPham)
        {
            SanPham sanPham = dataBase.SanPhams.Where(p => p.maSanPham == maSanPham).FirstOrDefault();
            if (sanPham != null)
            {
                DTO_SanPham tmp = new DTO_SanPham();
                tmp.MaSanPham = sanPham.maSanPham;
                tmp.TenSanPham = sanPham.tenSanPham;
                tmp.TrangThai = sanPham.trangThai.Value;
                tmp.NamSanXuat = sanPham.namSanXuat.Value;
                tmp.GiaBan = sanPham.giaBan.Value;
                
                return tmp;
            }
            return null;
        }

        public bool checkExist(string maSanPham)
        {
            SanPham sanPham = dataBase.SanPhams.Where(p => p.maSanPham == maSanPham).FirstOrDefault();
            if (sanPham != null)
            {
                return true;
            }
            return false;
        }

        public List<DTO_SanPham> layToanBoDanhSachSanPham()
        {
            var dataLst = dataBase.SanPhams.Select(p => p).OrderBy(p => p.maSanPham);

            List<DTO_SanPham> lst = new List<DTO_SanPham>();
            foreach (SanPham sp in dataLst)
            {
                DTO_SanPham tmp = new DTO_SanPham();
                tmp.MaSanPham = sp.maSanPham;
                tmp.TenSanPham = sp.tenSanPham;
                tmp.NamSanXuat = sp.namSanXuat.Value;
                tmp.TrangThai = sp.trangThai.Value;
                tmp.GiaBan = sp.giaBan.Value;
                lst.Add(tmp);
            }
            return lst;
        }

        public List<object> layDSChiTietSanPham()
        {
            List<object> lstChiTietSanPham = new List<object>();
            var dataLst = (from model in dataBase.Models
                           join ctModel in dataBase.ChiTietModels on model.maModel equals ctModel.maModel
                           join sanPham in dataBase.SanPhams on ctModel.maSanPham equals sanPham.maSanPham
                           select new
                           {
                               maSanPham = sanPham.maSanPham,
                               tenSanPham = sanPham.tenSanPham,
                               namSanXuat = sanPham.namSanXuat,
                               trangThai = sanPham.trangThai,
                               giaBan = sanPham.giaBan,
                               thongSoKyThuat = ctModel.thongSoKiThuat,
                               moTa = ctModel.moTa,
                               maModel = model.maModel,
                               tenModel = model.tenModel,
                           }
                    ).OrderBy(p => p.maSanPham);
            foreach (var item in dataLst)
            {
                lstChiTietSanPham.Add(item);
            }
            return lstChiTietSanPham;
        }

        public bool themSanPham(DTO_SanPham sp, DTO_ChiTietModel ct)
        {
            if (checkExist(sp.MaSanPham))
                return false;

            SanPham sanPham = new SanPham();
            ChiTietModel chiTiet = new ChiTietModel();
            sanPham.maSanPham = sp.MaSanPham;
            sanPham.tenSanPham = sp.TenSanPham;
            sanPham.namSanXuat = (short)sp.NamSanXuat;
            sanPham.trangThai = sp.TrangThai;
            sanPham.giaBan = sp.GiaBan;

            chiTiet.maModel = ct.MaModel;
            chiTiet.maSanPham = ct.MaSanPham;
            chiTiet.thongSoKiThuat = ct.ThongSoKyThuat;
            chiTiet.moTa = ct.MoTa;
            dataBase.SanPhams.InsertOnSubmit(sanPham);
            dataBase.ChiTietModels.InsertOnSubmit(chiTiet);
            dataBase.SubmitChanges();
            return true;
        }

        public bool suaThongTinSanPham(DTO_SanPham sp, DTO_ChiTietModel chiTiet)
        {
            IQueryable<SanPham> sanPham = dataBase.SanPhams.Where(p => p.maSanPham == sp.MaSanPham);
            IQueryable<ChiTietModel> ctModel = dataBase.ChiTietModels.Where(p => p.maSanPham == sp.MaSanPham);
            if (sanPham.Count() >= 0)
            {
                sanPham.First().tenSanPham = sp.TenSanPham;
                sanPham.First().namSanXuat = (short)sp.NamSanXuat;
                sanPham.First().trangThai = sp.TrangThai;
                sanPham.First().giaBan = sp.GiaBan;

                ctModel.First().maModel = chiTiet.MaModel;
                ctModel.First().thongSoKiThuat = chiTiet.ThongSoKyThuat;
                ctModel.First().moTa = chiTiet.MoTa;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaSanPham(string maSanPham)
        {
            if (!checkExist(maSanPham))
                return false;
            SanPham sanPham = dataBase.SanPhams.Where(p => p.maSanPham == maSanPham).FirstOrDefault();
            ChiTietModel chiTiet = dataBase.ChiTietModels.Where(p => p.maSanPham == maSanPham).FirstOrDefault();
            if (sanPham != null)
            {
                dataBase.SanPhams.DeleteOnSubmit(sanPham);
                dataBase.ChiTietModels.DeleteOnSubmit(chiTiet);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }


    }
}
