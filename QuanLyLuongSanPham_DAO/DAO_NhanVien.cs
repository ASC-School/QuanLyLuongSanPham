﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DTO;


namespace QuanLyLuongSanPham_DAO
{
    public class DAO_NhanVien
    {
        QuanLyLuongSanPhamDataContext dataBase;
        public DAO_NhanVien()
        {
            dataBase = new QuanLyLuongSanPhamDataContext();
        }

        public List<DTO_NhanVien> layToanBoDanhSachNhanVien()
        {
            var dataLst = dataBase.NhanViens.Select(p => p).OrderBy(p => p.maNhanVien);

            List<DTO_NhanVien> lst = new List<DTO_NhanVien>();
            foreach (NhanVien nv in dataLst)
            {
                DTO_NhanVien tmp = new DTO_NhanVien();
                tmp.MaNhanVien = nv.maNhanVien;
                tmp.TenNhanVien = nv.tenNhanVien;
                tmp.DiaChi = nv.diaChi;
                tmp.SoDienThoai = nv.soDienThoai;
                tmp.NgayBatDauCongTac = nv.ngayBatDauCongTac;
                tmp.NgaySinh = nv.ngaySinh;
                if (nv.gioiTinh == true)
                    tmp.GioiTinh = "nam";
                else
                    tmp.GioiTinh = "nữ";
                tmp.Avatar = nv.avatar.ToArray();
                lst.Add(tmp);
            }
            return lst;
        }
        public IEnumerable<dynamic> getDanhSachNVToQLNS()
        {
            IEnumerable<dynamic> q;
            q = (from dsnv in dataBase.NhanViens
                 join loaiNV in dataBase.LoaiNhanViens on dsnv.maLoai equals loaiNV.maLoai
                 join donvi in dataBase.DonViQuanLies on loaiNV.maLoai equals donvi.maLoai
                 select new { Mã_nhân_viên = dsnv.maNhanVien ,Tên_nhân_viên = dsnv.tenNhanVien ,Giới_tính = dsnv.gioiTinh, SDT = dsnv.soDienThoai, Địa_chỉ = dsnv.diaChi, Ngày_sinh = dsnv.ngaySinh, Ngày_vào_làm = dsnv.ngayBatDauCongTac, Loại_Nv = loaiNV.loaiNhanVien1, Đơn_vị_quản_lí = donvi.tenBoPhan,Trạng_thái=dsnv.trangThai });
            return q;
        }
        public IEnumerable<NhanVien> layNvTheoMa(string maNV)
        {
            IEnumerable<NhanVien> q;
            q= from n in dataBase.NhanViens where(n.maNhanVien.Equals(maNV)) select n;
            return q;
        }
        public bool themNhanVien(DTO_NhanVien nv)
        {
            string str = nv.MaNhanVien;
            if (checkIfExist(str) != null)
            {
                return false;
            }
            else
            {
                NhanVien temp = new NhanVien();
                temp.maNhanVien = nv.MaNhanVien;
                temp.tenNhanVien = nv.TenNhanVien;
                if (nv.GioiTinh.Equals("Nam"))
                    temp.gioiTinh = false;
                else
                    temp.gioiTinh = true;
                temp.soDienThoai = nv.SoDienThoai;
                temp.ngaySinh = nv.NgaySinh;
                temp.ngayBatDauCongTac = nv.NgayBatDauCongTac;
                temp.trangThai = nv.TrangThai;
                temp.avatar = nv.Avatar ;
                temp.diaChi = nv.DiaChi;
                temp.maLoai = nv.MaLoai;
                dataBase.NhanViens.InsertOnSubmit(temp);
                dataBase.SubmitChanges();
                return true;
            }
        }

        public NhanVien checkIfExist(string strMaNhanVien)
        {
            NhanVien nvTemp = (from n in dataBase.NhanViens where n.maNhanVien.Equals(strMaNhanVien) select n).FirstOrDefault();
            if (nvTemp != null)
                return nvTemp;
            return null;
        }
    }
}
