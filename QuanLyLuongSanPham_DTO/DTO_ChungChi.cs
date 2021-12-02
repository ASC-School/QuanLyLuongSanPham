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
     * Thời gian tạo: 10/11/2021
     */
     
    public class DTO_ChungChi
    {
        int soThuTu;
        string tenChungChi;

        public DTO_ChungChi()
        {

        }
        public DTO_ChungChi(int soThuTu, string tenChungChi)
        {
            this.SoThuTu = soThuTu;
            this.TenChungChi = tenChungChi;
        }

        public int SoThuTu { get => soThuTu; set => soThuTu = value; }
        public string TenChungChi { get => tenChungChi; set => tenChungChi = value; }
    }
}
