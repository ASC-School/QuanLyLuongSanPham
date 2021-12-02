using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
    /**
    * Tác giả: Võ Thị Trà Giang
    * Phiên bản: 1.0
    * Thời gian tạo: 25/10/2021
    */
    public class BUS_Model
    {
        DAO_Model md = new DAO_Model();
        public BUS_Model()
        {
            this.md = new DAO_Model();
        }
        public IEnumerable<Model> layDSModel()
        {
            return md.layDanhSacModel();
        }
    }
}
