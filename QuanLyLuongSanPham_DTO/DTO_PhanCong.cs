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
    public class DTO_PhanCong
    {
        string maPhanCong, maNhanVien, maCa,maNVPhanCong;
        int maCongDoan;
        DateTime ngayLam;

        public DTO_PhanCong()
        {
        }


        public DTO_PhanCong(string maPhanCong, string maNhanVien, string maCa, string maNVPhanCong, int maCongDoan, DateTime ngayLam)
        {
            this.MaPhanCong = maPhanCong;
            this.MaNhanVien = maNhanVien;
            this.MaCa = maCa;
            this.MaNVPhanCong = maNVPhanCong;
            this.MaCongDoan = maCongDoan;
            this.NgayLam = ngayLam;
        }

        public string MaPhanCong { get => maPhanCong; set => maPhanCong = value; }
        public string MaNhanVien { get => maNhanVien; set => maNhanVien = value; }
        public string MaCa { get => maCa; set => maCa = value; }
        public string MaNVPhanCong { get => maNVPhanCong; set => maNVPhanCong = value; }
        public int MaCongDoan { get => maCongDoan; set => maCongDoan = value; }
        public DateTime NgayLam { get => ngayLam; set => ngayLam = value; }
    }
}
