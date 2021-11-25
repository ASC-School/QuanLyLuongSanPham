using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLuongSanPham_BUS;
using QuanLyLuongSanPham_DAO;
using System.IO;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmXemThongTin : DevExpress.XtraEditors.XtraForm
    {
        BUS_NhanVien busNv = new BUS_NhanVien();
        BUS_LoaiNhanVien busLNV = new BUS_LoaiNhanVien();
        BUS_DonViQuanLy busDV = new BUS_DonViQuanLy();
        public frmXemThongTin()
        {
            InitializeComponent();
        }
        string maNhanVien = "";
        public frmXemThongTin(string strMaNhanVien) : this()
        {
            maNhanVien = strMaNhanVien;
        }
        private void frmXemThongTin_Load(object sender, EventArgs e)
        {
            loadThongTinNhanVien();
        }
        public void loadThongTinNhanVien()
        {
            IEnumerable<NhanVien> nv = busNv.layNhanVienTheoMa(maNhanVien);
            IEnumerable<LoaiNhanVien> lnv = busLNV.getNhanVienForQLNS();
            IEnumerable<DonViQuanLy> dv = busDV.getDSDonVi();
            lblMaNV.Text = "Mã nhân viên:" + " " + maNhanVien;
            foreach (var n in nv)
            {
                lblTenNv.Text = "Họ và tên:" + " " + n.tenNhanVien;
                DateTime time = n.ngaySinh;
                String.Format("{0:dd/MM/yyyy}", n.ngaySinh);
                lblNgaySinh.Text = "Ngày sinh:" + " " + n.ngaySinh.ToString();
                lblGIoiTinh.Text = "Giới tính: " + n.gioiTinh;
                lblDiaChi.Text = "Địa chỉ: " + n.diaChi;
                lblSoDienThoai.Text = "Số điện thoại: " + n.soDienThoai;
                foreach(var m in lnv)
                {
                    if (m.maLoai.Equals(n.maLoai))
                    {
                        lblLoaiNV.Text = "Loại nhân viên: " + m.loaiNhanVien1;
                    }
                }
                foreach(var m in dv)
                {
                    if (m.maLoai.Equals(n.maLoai))
                    {
                        lblDonViQuanLi.Text = "Đơn vị quản lí: " + m.tenBoPhan;
                    }
                }
                if (n.avatar == null)
                {
                    Avata.Image = null;

                }
                else
                {
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream(n.avatar.ToArray());
                        Image img = Image.FromStream(memoryStream);
                        if (img != null)
                        {
                            Avata.Image = img;
                        }
                    }
                    catch (Exception ex)
                    {
                        Avata.Image = null;
                    }

                }
            }
            
        }
    }
}