using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_DAO
{
    /**
     * Tác giả: Đinh Quang Huy,Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DAO_PhanQuyen
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_PhanQuyen()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public IEnumerable<PhanQuyen> layQuyenNVTheoMa(string strMaLoai)
        {
            IEnumerable<PhanQuyen> pqNV = from pq in dataBase.PhanQuyens
                                          join ml in dataBase.LoaiNhanViens
                                          on pq.maLoai equals ml.maLoai
                                          where pq.maLoai.Equals(strMaLoai)
                                          select pq;
            return pqNV;                               
        }

        public List<DTO_PhanQuyen> layDSPhanQuyen()
        {
            var dateLst = dataBase.PhanQuyens.Select(p => p).OrderBy(p => p.tenPhanQuyen);

            if(dateLst != null)
            {
                List<DTO_PhanQuyen> lst = new List<DTO_PhanQuyen>();
                foreach(var item in dateLst)
                {
                    DTO_PhanQuyen tmp = new DTO_PhanQuyen();
                    tmp.TenPhanQuyen = item.tenPhanQuyen;
                    tmp.MaLoaiNhanVien = item.maLoai;
                    tmp.FullCN = item.fullChucNang.Value;
                    tmp.XemThongTin = item.xem.Value;
                    tmp.SuaThongTin = item.sua.Value;
                    tmp.XoaThongTin = item.xoa.Value;
                    lst.Add(tmp);
                }
                return lst;
            }
            return null;
        }


        public bool checkExit(string maPhanQuyen)
        {
            var phanQuyen = dataBase.PhanQuyens.Where(p => p.tenPhanQuyen == maPhanQuyen).FirstOrDefault();
            if (phanQuyen != null)
                return true;
            return false;
        }

        
        public bool themPhanQuyen(DTO_PhanQuyen newPhanQuyen)
        {
            if (checkExit(newPhanQuyen.TenPhanQuyen))
                return false;
            PhanQuyen tmp = new PhanQuyen();
            tmp.tenPhanQuyen = newPhanQuyen.TenPhanQuyen;
            tmp.maLoai = newPhanQuyen.MaLoaiNhanVien;
            tmp.fullChucNang = newPhanQuyen.FullCN;
            tmp.xem = newPhanQuyen.XemThongTin;
            tmp.xoa = newPhanQuyen.XoaThongTin;
            tmp.sua = newPhanQuyen.SuaThongTin;

            dataBase.PhanQuyens.InsertOnSubmit(tmp);
            dataBase.SubmitChanges();
            return true;
        }

        public bool suaPhanQuyen(DTO_PhanQuyen newPhanQuyen)
        {
            if (!checkExit(newPhanQuyen.TenPhanQuyen))
                return false;
            IQueryable<PhanQuyen> tmp = dataBase.PhanQuyens.Where(p => p.tenPhanQuyen == newPhanQuyen.TenPhanQuyen);

            if(tmp.Count() > 0)
            {
                tmp.First().fullChucNang = newPhanQuyen.FullCN;
                tmp.First().xem = newPhanQuyen.XemThongTin;
                tmp.First().sua = newPhanQuyen.SuaThongTin;
                tmp.First().xoa = newPhanQuyen.XoaThongTin;

                dataBase.SubmitChanges();
            }
                return true;
        }


        public bool xoaPhanQuyen(string tenPhanQuyen)
        {
            if (!checkExit(tenPhanQuyen))
                return false;
            PhanQuyen tmp = dataBase.PhanQuyens.Where(p => p.tenPhanQuyen == tenPhanQuyen).FirstOrDefault();
            
            if(tmp != null)
            {
                dataBase.PhanQuyens.DeleteOnSubmit(tmp);
                dataBase.SubmitChanges();
                return true;
            }
            return false;
        }

    }
}
