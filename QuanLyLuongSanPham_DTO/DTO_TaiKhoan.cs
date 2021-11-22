﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_TaiKhoan
    {
        string maNhanVien, tenTaiKhoan, matKhau, quyen;
        public DTO_TaiKhoan() { }
        public DTO_TaiKhoan(string maNhanVien, string tenTaiKhoan, string matKhau, string quyen)
        {
            this.maNhanVien = maNhanVien;
            this.TenTaiKhoan = tenTaiKhoan;
            this.MatKhau = matKhau;
            this.Quyen = quyen;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
    }
}
