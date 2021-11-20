using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyLuongSanPham_DAO;

namespace QuanLyLuongSanPham_BUS
{
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
