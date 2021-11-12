﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_NhanVien
    {
        DAO_NhanVien nv = new DAO_NhanVien();

        public BUS_NhanVien()
        {
            this.nv = new DAO_NhanVien();
        }
        public IEnumerable<dynamic> getNhanVienForQLNS()
        {
            return nv.getDanhSachNVToQLNS();
        }

        public List<DTO_NhanVien> getDSNhanVienForDonHang()
        {
            return nv.layToanBoDanhSachNhanVien();
        }
    }
}
