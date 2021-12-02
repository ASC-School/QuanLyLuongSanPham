using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham_DTO
{
    /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
    public class DTO_ChiTietModel
    {
        string maModel, maSanPham, thongSoKyThuat,moTa;

        public DTO_ChiTietModel() { }
        public DTO_ChiTietModel(string maModel, string maSanPham, string thongSoKyThuat, string moTa)
        {
            this.MaModel = maModel;
            this.MaSanPham = maSanPham;
            this.ThongSoKyThuat = thongSoKyThuat;
            this.MoTa = moTa;
        }

        public string MaModel { get => maModel; set => maModel = value; }
        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string ThongSoKyThuat { get => thongSoKyThuat; set => thongSoKyThuat = value; }
        public string MoTa { get => moTa; set => moTa = value; }
    }
}
