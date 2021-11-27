using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    public class DTO_PhanCong
    {
        string maPhanCong, maNhanVien, maCa;
        int maCongDoan;
        DateTime ngayLam;

        public DTO_PhanCong()
        {
        }

        public DTO_PhanCong(string maPhanCong, string maNhanVien, string maCa, int maCongDoan, DateTime ngayLam)
        {
            this.maPhanCong = maPhanCong;
            this.maNhanVien = maNhanVien;
            this.maCa = maCa;
            this.maCongDoan = maCongDoan;
            this.ngayLam = ngayLam;
        }

        public string MaPhanCong { get => maPhanCong; set => maPhanCong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaCa { get => maCa; set => maCa = value; }
        public int MaCongDoan { get => maCongDoan; set => maCongDoan = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
    }
}
