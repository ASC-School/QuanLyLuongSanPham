﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;



namespace QuanLyLuongSanPham_BUS
{
    /**
     * Tác giả: Trần Văn Sỹ,Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 27/11/2021
     */
    public class BUS_LuongCongNhan
    {
        DAO_LuongCongNhan luongCongNhan;
        public BUS_LuongCongNhan()
        {
            luongCongNhan = new DAO_LuongCongNhan();
        }

        public IEnumerable<dynamic> loadLuongCN(int iMonth)
        {
            return luongCongNhan.loadLuongCN(iMonth);
        }

        public bool suaThongTin(DTO_LuongCongNhan LCN)
        {
            return luongCongNhan.suaTTNV(LCN);
        }

        public IEnumerable<dynamic> luongCNTheoThang(int iMonth, int iYear)
        {
            return luongCongNhan.loadLuongCNTheoThang(iMonth, iYear);
        }

        public object layNVTheoTimKiem(string maNVTK, string strThang, string strNam)
        {
            return luongCongNhan.layLuongNVTheoTimKiem(maNVTK, strThang, strNam);
        }

        public IEnumerable<LuongCongNhan> layNVTheoMa(string strMaNV)
        {
            return luongCongNhan.layNVTheoMa(strMaNV);
        }
        public IEnumerable<LuongCongNhan> layThongTinLuong(string maNhanVien)
        {
            return luongCongNhan.layThongTinLuong(maNhanVien);
        }
        public IEnumerable<PhieuChamCongCongNhan> layDSChamCong(string maNhanVien)
        {
            return luongCongNhan.layDSChamCong(maNhanVien);
        }

        public object luongCNTheoThangMoi(int iMonth, int iYear)
        {
            return luongCongNhan.loadLuongCNTheoThangMoi(iMonth, iYear);
        }
        public IEnumerable<LuongCongNhan> layThongTinCaNhan(string maNV)
        {
            return luongCongNhan.layThongTinLuongCaNhan(maNV);
        }
    }
}
