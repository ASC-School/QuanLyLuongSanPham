using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DAO
{
    /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
    public class DAO_ChiTietModel
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_ChiTietModel()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public List<object> getChiTietModelTheoMa(string maModel)
        {
            List<object> lstChiTietModel = new List<object>();
            if (!maModel.Equals(""))
            {
                var dataLst = (from model in dataBase.Models
                               join ctModel in dataBase.ChiTietModels on model.maModel equals ctModel.maModel
                               join sanPham in dataBase.SanPhams on ctModel.maSanPham equals sanPham.maSanPham
                               where model.maModel.Equals(maModel)
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
                    ).OrderBy(p => p.maModel);
               
                foreach(var item in dataLst)
                {
                    lstChiTietModel.Add(item);
                }
            }
            return lstChiTietModel;
        }
    }
}
