using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyLuongSanPham_DAO;
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_BUS
{
    public class BUS_ChamCong
    {
        DAO_PhieuChamCong chamCong;
        public BUS_ChamCong()
        {
            chamCong = new DAO_PhieuChamCong();
        }
        public IEnumerable<dynamic> layDSTheoCBB(string strDonVi, string date)
        {
            return chamCong.layDSNVChamCongTheoDonVi(strDonVi, date);
        }

        public bool suaThongTinChamCongCN(DTO_PhieuChamCongCongNhan phieuChamCongCN, string date)
        {
            return chamCong.suaTTChamCongCN(phieuChamCongCN, date);
        }

        public object layDSChamCongNow(string strDonVi, string date)
        {
            return chamCong.layDSNVChamCongDateNow(strDonVi, date);
        }

        public bool ChamCongDateNow(DTO_PhieuChamCongCongNhan dto_PhieuCCCN)
        {
            return chamCong.ChamCongDateNow(dto_PhieuCCCN);
        }

        public bool suaThongTinChamCongNVHC(DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC, string date)
        {
            return chamCong.suaTTChamCongNVHC(phieuChamCongNVHC, date);
        }

        public bool ChamCongDateNowNCHC(DTO_PhieuChamCongNhanVienHanhChanh dto_PhieuCCNVHC)
        {
            return chamCong.ChamCongDateNowNVHanhChanh(dto_PhieuCCNVHC);
        }
        public IEnumerable<dynamic> layDSChamCongCN()
        {
            return chamCong.danhSachChamCongCN();
        }

        public object layDSChamCongHC(string strDonVi)
        {
            return chamCong.danhSachChamCongHC(strDonVi);
        }

        public string layDongCuoiPCCCN()
        {
            return chamCong.layDongCuoiMaPCCCN();
        }

        public bool themPhieuChamCongCN(DTO_PhieuChamCongCongNhan newPhieuCCCN)
        {
            return chamCong.themPCCCN(newPhieuCCCN);
        }

        public bool themPhieuChamCongHC(DTO_PhieuChamCongNhanVienHanhChanh newPhieuCCHC)
        {
            return chamCong.themPCCHC(newPhieuCCHC);
        }

        public string layDongCuoiPCCHC()
        {
            return chamCong.layDongCuoiMaPCCHC();
        }

        public bool suaThongTin(DTO_PhieuChamCongCongNhan dto_PCCLCN, string date)
        {
            return chamCong.suaTTChamCong(dto_PCCLCN, date);
        }

        public bool suaThongTinHC(DTO_PhieuChamCongNhanVienHanhChanh dto_PCCLHC, string date)
        {
            return chamCong.suaTTChamCongHC(dto_PCCLHC, date);
        }
    }
}
