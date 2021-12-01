using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_PhatNhanVien
    {
        string maNhanVien;
        int maMucPhat;
        string maDonVi;
        DateTime ngayPhat;

        public DTO_PhatNhanVien()
        {
        }

        public DTO_PhatNhanVien(string maNhanVien, int maMucPhat, string maDonVi, DateTime ngayPhat)
        {
            this.maNhanVien = maNhanVien;
            this.maMucPhat = maMucPhat;
            this.maDonVi = maDonVi;
            this.ngayPhat = ngayPhat;
        }

        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public int MaMucPhat { get => maMucPhat; set => maMucPhat = value; }
        public string MaDonVi { get => maDonVi; set => maDonVi = value; }
        public DateTime NgayPhat { get => ngayPhat; set => ngayPhat = value; }
    }
}
