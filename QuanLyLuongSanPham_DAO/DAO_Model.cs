using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;


namespace QuanLyLuongSanPham_DAO
{
    public class DAO_Model
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_Model()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public bool checkExist(string maModel)
        {
            Model model = dataBase.Models.Where(p => p.maModel == maModel).FirstOrDefault();
            if (model != null)
            {
                return true;
            }
            return false;
        }

        public  List<DTO_Model> layDSModel()
        {
            var dataLst = dataBase.Models.Select(p => p).OrderBy(p => p.maModel);
            List<DTO_Model> lstModel = new List<DTO_Model>();
            foreach(Model item in dataLst)
            {
                DTO_Model model = new DTO_Model();
                model.MaModel = item.maModel;
                model.MaModel = item.tenModel;
                model.TrangThai = item.trangThai.Value;
                lstModel.Add(model);
            }
            return lstModel;
        }

        public bool themModel(DTO_Model model, DTO_ChiTietModel ctModel)
        {
            if (checkExist(model.MaModel))
                return false;
            Model newModel = new Model();
            ChiTietModel newCTModel = new ChiTietModel();

            newModel.maModel = model.MaModel;
            newModel.tenModel = model.TenModel;
            newModel.trangThai = model.TrangThai;

            newCTModel.maSanPham = ctModel.MaModel;
            newCTModel.maModel = ctModel.MaModel;
            newCTModel.thongSoKiThuat = ctModel.ThongSoKyThuat;
            newCTModel.moTa = ctModel.MoTa;

            dataBase.Models.InsertOnSubmit(newModel);
            dataBase.ChiTietModels.InsertOnSubmit(newCTModel);
            dataBase.SubmitChanges();
            return true;
        }

        public bool suaModel(DTO_Model newModel)
        {
            if (!checkExist(newModel.MaModel))
                return false;
            IQueryable<Model> model = dataBase.Models.Where(p => p.maModel == newModel.MaModel);
            if(model.Count() >= 0)
            {
                model.First().tenModel = newModel.TenModel;
                model.First().trangThai = newModel.TrangThai;
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool xoaModel(string maModel)
        {
            Model tmp = dataBase.Models.Where(p => p.maModel == maModel).FirstOrDefault();
            if(tmp != null)
            {
                dataBase.Models.DeleteOnSubmit(tmp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }
    }
}
