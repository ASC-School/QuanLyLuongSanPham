﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DTO_PhieuChamCong
    {
        string maPhieuChamCong, maCa, maNhanVien;
        int soGioTangCa;
        bool diLam, diTre;

        public DTO_PhieuChamCong() { }
        public DTO_PhieuChamCong(string maPhieuChamCong, string maCa, string maNhanVien, int soGioTangCa, bool diLam, bool diTre)
        {
            this.maPhieuChamCong = maPhieuChamCong;
            this.maCa = maCa;
            this.maNhanVien = maNhanVien;
            this.soGioTangCa = soGioTangCa;
            this.diLam = diLam;
            this.diTre = diTre;
        }

        public string MaPhieuChamCong { get => maPhieuChamCong; set => maPhieuChamCong = value; }
        public string MaCa { get => maCa; set => maCa = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public int SoGioTangCa { get => soGioTangCa; set => soGioTangCa = value; }
        public bool DiLam { get => diLam; set => diLam = value; }
        public bool DiTre { get => diTre; set => diTre = value; }
    }
}
