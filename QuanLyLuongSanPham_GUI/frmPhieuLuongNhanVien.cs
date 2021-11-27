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
using System.Globalization;

namespace QuanLyLuongSanPham_GUI
{
    public partial class frmPhieuLuongNhanVien : Form
    {
        public frmPhieuLuongNhanVien()
        {
            InitializeComponent();
            phieuLuongCN = new PhieuLuongNhanVien(setPhieuLuongCongNhan);
        }

        #region Propepties
        Point LastPoint;
        BUS_NhanVien busNV = new BUS_NhanVien();
        BUS_LuongCongNhan lcn = new BUS_LuongCongNhan();
        BUS_CongDoanSanXuat cdsx = new BUS_CongDoanSanXuat();
        BUS_PhatNhanVien bus_PhatNV = new BUS_PhatNhanVien();
        public delegate void PhieuLuongNhanVien(int iForm,string strMaNV, string strTenNV, string strLuongCoBan, string strSoNgayCongTT, string strDonVi, string strCongDoan, string strSoLuongSPLD, string strPhuCap, string strTienPhat, string strTienUng, string strThue, string strThang, string strNam, string strThucNhan);
        public PhieuLuongNhanVien phieuLuongCN;
        #endregion 
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Util.EndAnimate(this, Util.Effect.Center, 150, 30);
            this.Close();
        }

        #region Methos
        void setPhieuLuongCongNhan(int iForm, string strMaNV, string strTenNV, string strDonVi, string strLuongCoBan, string strSoNgayCongTT, string strCongDoan, string strSoLuongSPLD, string strPhuCap, string strTienPhat, string strTienUng, string strThue, string strThang, string strNam, String strThucNhan)
        {
            if (iForm == 2)
            {
                lblNgayXuatHHT.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                lblDonViL.Text = strDonVi;
                lblThangBN.Text = strThang;
                lblNamBN.Text = strNam;
                lblTen.Text = strTenNV;
                lblMaNV.Text = strMaNV;
                lblCDoan.Text = "Công Đoạn :";
                lblCongDoan.Text = strCongDoan;
                lblSoLuongSPLD.Text = strSoLuongSPLD;
                lblPhuCap.Text = strPhuCap;
                lblThue.Text = strThue;
                lblTienUng.Text = strTienUng;
                lblTongTatCa.Text = strThucNhan;

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

                int iSoLuong = Convert.ToInt32(strSoLuongSPLD);
                int iLuongSP = Convert.ToInt32(lblLuongCongDoan.Text);
                int iPhuCap = (int)Convert.ToDecimal(strPhuCap);
                double iThue = Convert.ToDouble(strThue);
                int iThanhTien = iSoLuong * iLuongSP;
                int iTongTienLuongPC = iThanhTien + iPhuCap;
                lblTongTienLuongPC.Text = string.Format("{0:0,0}", iTongTienLuongPC);
                lblThanhTienThue.Text = string.Format("{0:0,0}", iThanhTien * iThue);

                if (strTienUng.Trim() == "")
                {
                    lblTienUng.Text = "0";
                    lblThanhTienTienUng.Text = "0";
                }
                else
                {
                    lblTienUng.Text = strTienUng;
                    lblThanhTienTienUng.Text = strTienUng;
                }

                int iCountDiTre = 0;
                int iCountNghiKhongPhep = 0;
                int iMaPhat = 1;
                int iPhatNghiKhongPhep = 2;
                IEnumerable<PhatNhanVien> phatNVDiTre = bus_PhatNV.laySoLuongViPhamDiTre(strMaNV, iMaPhat);
                foreach (PhatNhanVien phat in phatNVDiTre)
                {
                    iCountDiTre++;
                }
                IEnumerable<PhatNhanVien> phatNVNghiKhongPhep = bus_PhatNV.laySoLuongViPhamNghiKhongPhep(strMaNV, iPhatNghiKhongPhep);
                foreach (PhatNhanVien phat in phatNVNghiKhongPhep)
                {
                    iCountNghiKhongPhep++;
                }
                lblSLDiLamTre.Text = iCountDiTre.ToString();
                lblThanhTienDiTre.Text = string.Format("{0:0,0}", 100000 * iCountDiTre);
                lblSLNghiKhongPhep.Text = iCountNghiKhongPhep.ToString();
                lblNghiKhongPhep.Text = string.Format("{0:0,0}", 100000 * iCountNghiKhongPhep);
                int iTemp = int.Parse(lblTongTatCa.Text.Trim(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                int iTongTienKhauTru_Phat = iTongTienLuongPC - iTemp;
                lblTongTienKhauTru_Phat.Text = string.Format("{0:0,0}", iTongTienKhauTru_Phat);
            }
            else if(iForm == 1)
            {
                lblNgayXuatHHT.Text = string.Format("{0:dd-MM-yyyy}", DateTime.Now);
                lblDonViL.Text = strDonVi;
                lblThangBN.Text = strThang;
                lblNamBN.Text = strNam;
                lblTen.Text = strTenNV;
                lblMaNV.Text = strMaNV;
                lblCDoan.Text = "Chức Vụ :";
                lblLuongCD.Text = "Lương Cơ Bản";
                lblLuongCongDoan.Text = strLuongCoBan;
                lblSoLuongSPLD.Text = strSoNgayCongTT;
                lblPhuCap.Text = strPhuCap;
                lblThue.Text = strThue;
                lblTienUng.Text = strTienUng;
                lblTongTatCa.Text = strThucNhan;

                IEnumerable<NhanVien> nv = busNV.getNhanVienTheoMa(strMaNV);
                foreach (NhanVien nVien in nv)
                {
                    lblSDT.Text = nVien.soDienThoai;
                }
                IEnumerable<LoaiNhanVien> lnv = busNV.getLoaiNhanVienTheoMa(strMaNV);
                foreach(LoaiNhanVien loainv in lnv)
                {
                    lblCongDoan.Text = loainv.loaiNhanVien1;
                }    
                foreach (NhanVien nVien in nv)
                {
                    lblSDT.Text = nVien.soDienThoai;
                }

                int iSoLuong = Convert.ToInt32(strSoNgayCongTT.Trim());
                int iLuongCB = int.Parse(strLuongCoBan.Trim(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                int iPhuCap = (int)Convert.ToDecimal(strPhuCap);
                double iThue = Convert.ToDouble(strThue);
                int iThanhTien = (iLuongCB / 26) * iSoLuong;
                int iTongTienLuongPC = iThanhTien + iPhuCap;
                lblTongTienLuongPC.Text = string.Format("{0:0,0}", iTongTienLuongPC);
                lblThanhTienThue.Text = string.Format("{0:0,0}", iThanhTien * iThue);

                if (strTienUng.Trim() == "")
                {
                    lblTienUng.Text = "0";
                    lblThanhTienTienUng.Text = "0";
                }
                else
                {
                    lblTienUng.Text = strTienUng;
                    lblThanhTienTienUng.Text = strTienUng;
                }

                int iCountDiTre = 0;
                int iCountNghiKhongPhep = 0;
                int iMaPhat = 1;
                int iPhatNghiKhongPhep = 2;
                IEnumerable<PhatNhanVien> phatNVDiTre = bus_PhatNV.laySoLuongViPhamDiTre(strMaNV, iMaPhat);
                foreach (PhatNhanVien phat in phatNVDiTre)
                {
                    iCountDiTre++;
                }
                IEnumerable<PhatNhanVien> phatNVNghiKhongPhep = bus_PhatNV.laySoLuongViPhamNghiKhongPhep(strMaNV, iPhatNghiKhongPhep);
                foreach (PhatNhanVien phat in phatNVNghiKhongPhep)
                {
                    iCountNghiKhongPhep++;
                }
                lblSLDiLamTre.Text = iCountDiTre.ToString();
                lblThanhTienDiTre.Text = string.Format("{0:0,0}", 100000 * iCountDiTre);
                lblSLNghiKhongPhep.Text = iCountNghiKhongPhep.ToString();
                lblNghiKhongPhep.Text = string.Format("{0:0,0}", 100000 * iCountNghiKhongPhep);
                int iTemp = int.Parse(lblTongTatCa.Text.Trim(), NumberStyles.AllowThousands, new CultureInfo("en-au"));
                int iTongTienKhauTru_Phat = iTongTienLuongPC - iTemp;
                lblTongTienKhauTru_Phat.Text = string.Format("{0:0,0}", iTongTienKhauTru_Phat);
            }    
        }
        private void frmPhieuLuongNhanVien_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void frmPhieuLuongNhanVien_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - LastPoint.X;
                this.Top += e.Y - LastPoint.Y;
            }
        }
        #endregion
    }
}
