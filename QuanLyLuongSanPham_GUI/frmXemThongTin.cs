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
    /**
     * Tác giả:Trần Văn Sỹ
     * Phiên bản: 1.0
     * Thời gian tạo: 17/11/2021
     */
    public partial class frmXemThongTin : DevExpress.XtraEditors.XtraForm
    {
        double tongTru = 0;
        double tongNhan = 0;
        double thucNhan = 0;
        BUS_NhanVien busNv = new BUS_NhanVien();
        BUS_LoaiNhanVien busLNV = new BUS_LoaiNhanVien();
        BUS_DonViQuanLy busDV = new BUS_DonViQuanLy();
        BUS_LuongNhanVienHanhChanh busLuongHC = new BUS_LuongNhanVienHanhChanh();
        BUS_LuongCongNhan busLuongCN = new BUS_LuongCongNhan();
        BUS_CongDoanSanXuat busCongDoan = new BUS_CongDoanSanXuat();
        BUS_PhatNhanVien busPhat = new BUS_PhatNhanVien();
        BUS_MucTienPhat busMucPhat = new BUS_MucTienPhat();
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
            dtgvTienPhat.DefaultCellStyle.ForeColor = Color.Black;
            dtgvTienUng.DefaultCellStyle.ForeColor = Color.Black;
            loadData();
            thucNhan = tongNhan - tongTru;
            lblTongTru.Text = "Tổng trừ: " + String.Format("{0:#,##0.0}", tongTru).ToString() + " VNĐ";
            lblThucNhan.Text = "Thực nhận: " + String.Format("{0:#,##0.0}", thucNhan).ToString() + " VNĐ";

        }
        private void loadData()
        {
            dtgvTienPhat.Rows.Clear();
            IEnumerable<PhatNhanVien> listP = busPhat.layThongTinPhat(maNhanVien);
            IEnumerable<MucTienPhat> listMP = busMucPhat.layThongTinPhat();
            IEnumerable<LuongHanhChanh> lhc = busLuongHC.layThongTinLuongCaNhan(maNhanVien);
            double tongPhat = 0;
            double tongUng = 0;
            foreach (var item in listP)
            {
                foreach (var n in listMP)
                {
                    if (n.soThuTu == item.maMucPhat)
                    {
                        dtgvTienPhat.Rows.Add(item.ngayPhat,n.tenKhoanPhat,Convert.ToDouble( n.mucTienPhat1));
                        tongPhat = tongPhat + Convert.ToDouble(n.mucTienPhat1);
                    }
                }
            }
            lblTienPhat.Text = "Tổng trừ: " + String.Format("{0:#,##0.0}", tongPhat).ToString() + " VNĐ";
            foreach(var item in lhc)
            {
                string ngayUng = "25/" + item.thangLuong.ToString() + "/" + item.namLuong.ToString();
                dtgvTienUng.Rows.Add(ngayUng, item.tienUng);
                tongUng = tongUng + Convert.ToDouble(item.tienUng);
            }
            lblLuongUng.Text = "Tổng trừ: " + String.Format("{0:#,##0.0}", tongUng).ToString() + " VNĐ";
            tongTru = tongPhat + tongUng;
        }
        public void loadThongTinNhanVien()
        {
            IEnumerable<NhanVien> nv = busNv.layNhanVienTheoMa(maNhanVien);
            IEnumerable<LoaiNhanVien> lnv = busLNV.getNhanVienForQLNS();
            IEnumerable<DonViQuanLy> dv = busDV.getDSDonVi();
            IEnumerable<LuongHanhChanh> lhc = busLuongHC.layThongTinLuongCaNhan(maNhanVien);
            IEnumerable<LuongCongNhan> lcn = busLuongCN.layThongTinLuong(maNhanVien);
            IEnumerable<CongDoanSanXuat> cd = busCongDoan.layAllDsCD();
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
                if (!n.maLoai.Contains("LNV002"))
                {
                    foreach (var m in lhc)
                    {

                        lblLuong.Text = "Lương cơ bản: " + String.Format("{0:#,##0.0}", m.luongCoBan).ToString() + " VNĐ";
                        lblPhuCap.Text = "Phụ cấp: " + String.Format("{0:#,##0.0}", m.phuCap).ToString() + " VNĐ";
                        if (m.tienTangCa == null)
                            lblTienThuong.Text = "Tiền tăng ca: 0 VNĐ";
                        else
                            lblTienThuong.Text = "Tiền tăng ca: " + String.Format("{0:#,##0.0}", m.tienTangCa).ToString() + " VNĐ";
                        lblSoNgayCong.Text = "Số ngày công: " + m.soNgayLamDuoc.ToString() + " ngày";
                        lblThue.Text = "Thuế: " + (m.thue * 100).ToString() + " %";
                        double lUongCoBan = Convert.ToDouble((m.luongCoBan/26)*m.soNgayLamDuoc);
                        double thucNhan =Convert.ToDouble((lUongCoBan * (1 - m.thue) + m.phuCap));
                        tongNhan = thucNhan;
                        lblTongNhan.Text = "Thực nhận: " + String.Format("{0:#,##0.0}", thucNhan).ToString() + " VNĐ";
                    }
                }
                else
                {
                    foreach(var m in lcn)
                    {
                        double LuongCoBan = 0;
                        double thucnhan = 0;
                        foreach(var k in cd)
                        {
                            if (m.maCongDoan == k.soThuTu)
                            {
                                lblLuong.Text = "Lương: " + k.donGia.ToString() + "VNĐ/1 sản phảm";
                                LuongCoBan = Convert.ToDouble(k.donGia * m.soLuongSanPham);
                                thucnhan = Convert.ToDouble(LuongCoBan * (1.0 - m.thue) + m.phuCap);
                            }
                        }
                        lblPhuCap.Text= "Phụ cấp: " + String.Format("{0:#,##0.0}", m.phuCap).ToString() + " VNĐ";
                        lblThue.Text= "Thuế: " + (m.thue * 100).ToString() + " %";
                        lblTienThuong.Text = "Tiền thưởng: 0 VNĐ";
                        lblSoNgayCong.Text = "Số lượng sản phẩm: " + m.soLuongSanPham.ToString() + " cái";
                        lblTongNhan.Text = "Thực nhận: " + String.Format("{0:#,##0.0}", thucnhan).ToString() + " VNĐ";
                        tongNhan = thucNhan;
                    }
                }
            }
            
        }
    }
}