using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_BUS;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmPhieuLuongCongNhan : Form
    {
        #region Propepties
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_LuongCongNhan lcn = new BUS_LuongCongNhan();
        BUS_CongDoanSanXuat cdsx = new BUS_CongDoanSanXuat();
        BUS_PhatNhanVien bus_PhatNV = new BUS_PhatNhanVien();
        public delegate void PhieuLuongCongNhan(string strMaNV, string strTenNV, string strDonVi, string strCongDoan, string strSoLuongSPLD, string strPhuCap, string strTienPhat, string strTienUng, string strThue, string strThang, string strNam);
        public PhieuLuongCongNhan phieuLuongCN;
        #endregion

        public frmPhieuLuongCongNhan()
        {
            InitializeComponent();
            phieuLuongCN = new PhieuLuongCongNhan(setPhieuLuongCongNhan);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        void setPhieuLuongCongNhan(string strMaNV, string strTenNV, string strDonVi, string strCongDoan, string strSoLuongSPLD, string strPhuCap, string strTienPhat, string strTienUng, string strThue, string strThang, string strNam)
        { 
            lblNgayXuatHHT.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
            lblDonViL.Text = strDonVi;
            lblThangBN.Text = strThang;
            lblNamBN.Text = strNam;
            lblTen.Text = strTenNV;
            lblMaNV.Text = strMaNV;
            lblCongDoan.Text = strCongDoan;
            lblSoLuongSPLD.Text = strSoLuongSPLD;
            lblPhuCap.Text = strPhuCap;
            lblThue.Text = strThue;
            lblTienUng.Text = strTienUng;

            IEnumerable<NhanVien> nv = busNV.getNhanVienTheoMa(strMaNV);
            foreach (NhanVien nVien in nv)
            {
                lblSDT.Text = nVien.soDienThoai;
            }
            IEnumerable<CongDoanSanXuat> cd = cdsx.layDonGiaCD(lblMaNV.Text);
            foreach (CongDoanSanXuat cdsx in cd)
            {
                {
                    lblLuongCongDoan.Text = cdsx.donGia.ToString();
                }
            }

            int iSoLuong = Convert.ToInt32(lblSoLuongSPLD.Text);
            int iLuongSP = Convert.ToInt32(lblLuongCongDoan.Text);
            int iPhuCap = (int)Convert.ToDecimal(strPhuCap);
            double iThue = Convert.ToDouble(strThue);
            int iThanhTien = iSoLuong * iLuongSP;
            lblTongTienLuongPC.Text = string.Format("{0:0,0}", iThanhTien + iPhuCap);
            lblThanhTienThue.Text = string.Format("{0:0,0}", iThanhTien * iThue);
            if(strTienUng.Trim() == "")
            {
                lblTienUng.Text = "0";
                lblThanhTienTienUng.Text = "0";
            }
            else
            {
                lblTienUng.Text = strTienUng;
                lblThanhTienTienUng.Text = strTienUng;
            }

            int iCount = 0;
            int iMaPhat = 1;
            IEnumerable<PhatNhanVien> phatNV = bus_PhatNV.laySoLuongViPhamDiTre(strMaNV, iMaPhat);
            foreach(PhatNhanVien phat in phatNV)
            {
                iCount++;
            }
            lblSLDiLamTre.Text = iCount.ToString();
        }

        private void frmPhieuLuongCongNhan_Load(object sender, EventArgs e)
        {

        }
    }
}
