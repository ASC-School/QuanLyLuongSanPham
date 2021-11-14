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

public bool themSanPham(DTO_SanPham sp)
{
    if (checkExist(sp.MaSanPham))
        return false;
    SanPham sanPham = new SanPham();
    sanPham.maSanPham = sp.MaSanPham;
    sanPham.tenSanPham = sp.TenSanPham;
    sanPham.namSanXuat = (short)sp.NamSanXuat;
    sanPham.trangThai = sp.TrangThai;
    sanPham.giaBan = sp.GiaBan;
    dataBase.SanPhams.InsertOnSubmit(sanPham);
    dataBase.SubmitChanges();
    return true;
}

public bool suaThongTinSanPham(DTO_SanPham sp)
{
    IQueryable<SanPham> sanPham = dataBase.SanPhams.Where(p => p.maSanPham == sp.MaSanPham);
    if (sanPham.Count() >= 0)
    {
        sanPham.First().tenSanPham = sp.TenSanPham;
        sanPham.First().namSanXuat = (short)sp.NamSanXuat;
        sanPham.First().trangThai = sp.TrangThai;
        sanPham.First().giaBan = sp.GiaBan;
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
    if (sanPham != null)
    {
        dataBase.SanPhams.DeleteOnSubmit(sanPham);
        dataBase.SubmitChanges();
        return true;
    }
    return false;
}


    }
}
