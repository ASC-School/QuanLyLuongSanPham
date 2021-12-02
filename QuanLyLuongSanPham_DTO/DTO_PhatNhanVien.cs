using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    /**
     * Tác giả: Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 10/11/2021
     */
    public class DTO_PhatNhanVien
    {

        string maNhanVien;
        int maMucPhat;
        string maDonVi;
        DateTime ngayPhat;
        string maPhat;

        public DTO_PhatNhanVien()
        {
        }

        public DTO_PhatNhanVien(string maNhanVien, int maMucPhat, string maDonVi, DateTime ngayPhat, string maPhat)
        {
            this.MaNhanVien = maNhanVien;
            this.MaMucPhat = maMucPhat;
            this.MaDonVi = maDonVi;
            this.NgayPhat = ngayPhat;
            this.MaPhat = maPhat;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public int MaMucPhat { get => maMucPhat; set => maMucPhat = value; }
        public string MaDonVi { get => maDonVi; set => maDonVi = value; }
        public DateTime NgayPhat { get => ngayPhat; set => ngayPhat = value; }
        public string MaPhat { get => maPhat; set => maPhat = value; }
    }
}
