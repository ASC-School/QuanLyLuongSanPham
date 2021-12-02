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
    public class DTO_Model
    {
        string maModel, tenModel;
        bool trangThai;

        public DTO_Model() { }
        public DTO_Model(string maModel, string tenModel, bool trangThai)
        {
            this.MaModel = maModel;
            this.TenModel = tenModel;
            this.TrangThai = trangThai;
        }

        public string MaModel { get => maModel; set => maModel = value; }
        public string TenModel { get => tenModel; set => tenModel = value; }
        public bool TrangThai { get => trangThai; set => trangThai = value; }
    }
}
