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
using QuanLyLuongSanPham_DTO;

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Đinh Quang Huy
     * Phiên bản: 1.0
     * Thời gian tạo: 17/11/2021
     */
    public partial class frmChamCong : Form
    {
        public frmChamCong()
        {
            InitializeComponent();
        }

        #region Propepties
        BUS_DonViQuanLy bus_DVQL = new BUS_DonViQuanLy();
        BUS_ChamCong bus_ChamCong = new BUS_ChamCong();
        DateTime today = DateTime.Now;
        bool statusCheckCN = false;
        bool statusCheckHC = false;
        bool statusCheckNS = false;
        bool statusCheck4HT = false;
        bool statusCheck5L = false;
        #endregion

        #region Methos
        private void loadDSDonVi()
        {
            IEnumerable<DonViQuanLy> dsdv = bus_DVQL.getDSDonVi();
            foreach (DonViQuanLy dv in dsdv)
            {
                cbbDonVi.Items.Add(dv.tenBoPhan);
            }
        }
        #endregion

        #region Event
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmChamCong_Load(object sender, EventArgs e)
        {
            loadDSDonVi();
            statusText(false);
            date.Value = DateTime.Now;
            loadColumn();
        }

        private void loadColumn()
        {
            dtgvChamCong.Columns["soLuongSP"].Visible = true;
            this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
            dtgvChamCong.Columns.Add(checkWorking1);
            checkWorking1.HeaderText = "Đi Làm";
            checkWorking1.Name = "DiLamTemp";
            checkWorking1.ReadOnly = false;

            DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
            dtgvChamCong.Columns.Add(checkWorking2);
            checkWorking2.HeaderText = "Đi Trễ";
            checkWorking2.Name = "DiTreTemp";
            checkWorking2.ReadOnly = false;
            dtgvChamCong.Columns["DiLamTemp"].Visible = false;
            dtgvChamCong.Columns["DiTreTemp"].Visible = false;
        }

        private void statusText(bool bStatus)
        {
            txtMaNV.Enabled = false;
            txtHoTen.Enabled = false;
            cbDiLam.Enabled = bStatus;
            cbDiTre.Enabled = bStatus;
            cbDiLamHet.Enabled = false;
            //txtSoLuong.Enabled = false;
        }

        private void cbbDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
        }
        private void btnChamCong_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            if (date.Value.ToString("MM/dd/yyyy") == today.ToString("MM/dd/yyyy"))
            {    
                cbDiLamHet.Enabled = true;
                if (cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất")
                {
                    if (statusCheckCN)
                    {
                        MessageBox.Show("Ngày hôm nay đã được chấm công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dtgvChamCong.Columns["soLuongSP"].Visible = true;
                    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
                    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongCN();
                    if (dtgvChamCong.Columns.Count > 5)
                    {

                    }
                    else
                    {
                        dtgvChamCong.Columns["diLam"].Visible = false;
                        dtgvChamCong.Columns["diTre"].Visible = false;
                        this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking1);
                        checkWorking1.HeaderText = "Đi Làm1";
                        checkWorking1.Name = "DiLamTemp";
                        checkWorking1.ReadOnly = false;

                        DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking2);
                        checkWorking2.HeaderText = "Đi Trễ1";
                        checkWorking2.Name = "DiTreTemp";
                        checkWorking2.ReadOnly = false;
                    }
                }
                else if (cbbDonVi.Text == "Bộ Phận Nhân Viên Văn Phòng")
                {
                    if (statusCheckHC)
                    {
                        MessageBox.Show("Ngày hôm nay đã được chấm công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
                    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongHC(cbbDonVi.Text);
                    if (dtgvChamCong.Columns.Count > 5)
                    {

                    }
                    else
                    {
                        dtgvChamCong.Columns["soLuongSP"].Visible = true;
                        dtgvChamCong.Columns["diLam"].Visible = false;
                        dtgvChamCong.Columns["diTre"].Visible = false;   
                        this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking1);
                        checkWorking1.HeaderText = "Đi Làm";
                        checkWorking1.Name = "DiLamTemp";
                        checkWorking1.ReadOnly = false;

                        DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking2);
                        checkWorking2.HeaderText = "Đi Trễ";
                        checkWorking2.Name = "DiTreTemp";
                        checkWorking2.ReadOnly = false;
                    }
                }
                else if (cbbDonVi.Text == "Bộ Phận Quản Lý Lương")
                {
                    if (statusCheck5L)
                    {
                        MessageBox.Show("Ngày hôm nay đã được chấm công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dtgvChamCong.Columns["soLuongSP"].Visible = false;
                    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
                    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongHC(cbbDonVi.Text);
                    if (dtgvChamCong.Columns.Count > 5)
                    {

                    }
                    else
                    {
                        dtgvChamCong.Columns["diLam"].Visible = false;
                        dtgvChamCong.Columns["diTre"].Visible = false;
                        this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking1);
                        checkWorking1.HeaderText = "Đi Làm";
                        checkWorking1.Name = "DiLamTemp";
                        checkWorking1.ReadOnly = false;

                        DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking2);
                        checkWorking2.HeaderText = "Đi Trễ";
                        checkWorking2.Name = "DiTreTemp";
                        checkWorking2.ReadOnly = false;
                    }
                }
                else if (cbbDonVi.Text == "Bộ Phận Quản Lý Hệ Thống")
                {
                    if (statusCheck4HT)
                    {
                        MessageBox.Show("Ngày hôm nay đã được chấm công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dtgvChamCong.Columns["soLuongSP"].Visible = false;
                    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
                    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongHC(cbbDonVi.Text);
                    if (dtgvChamCong.Columns.Count > 5)
                    {

                    }
                    else
                    {
                        dtgvChamCong.Columns["diLam"].Visible = false;
                        dtgvChamCong.Columns["diTre"].Visible = false;
                        this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking1);
                        checkWorking1.HeaderText = "Đi Làm";
                        checkWorking1.Name = "DiLamTemp";
                        checkWorking1.ReadOnly = false;

                        DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking2);
                        checkWorking2.HeaderText = "Đi Trễ";
                        checkWorking2.Name = "DiTreTemp";
                        checkWorking2.ReadOnly = false;
                    }
                }
                else if (cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự")
                {
                    if (statusCheckNS)
                    {
                        MessageBox.Show("Ngày hôm nay đã được chấm công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    dtgvChamCong.Columns["soLuongSP"].Visible = false;
                    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
                    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongHC(cbbDonVi.Text);
                    if (dtgvChamCong.Columns.Count > 5)
                    {

                    }
                    else
                    {
                        dtgvChamCong.Columns["diLam"].Visible = false;
                        dtgvChamCong.Columns["diTre"].Visible = false;
                        this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
                        DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking1);
                        checkWorking1.HeaderText = "Đi Làm";
                        checkWorking1.Name = "DiLamTemp";
                        checkWorking1.ReadOnly = false;

                        DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
                        dtgvChamCong.Columns.Add(checkWorking2);
                        checkWorking2.HeaderText = "Đi Trễ";
                        checkWorking2.Name = "DiTreTemp";
                        checkWorking2.ReadOnly = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ngày hiện tại để chấm công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //int iTemp = 0;
            //DateTime today = DateTime.Now;
            //if (date.Value.ToString("MM/dd/yyyy") == today.ToString("MM/dd/yyyy"))
            //{
            //    cbDiLamHet.Enabled = true;
            //    if (cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất" && statusChamCongCNNow == false)
            //    {
            //        cbDiLamHet.Enabled = true;
            //        dtgvChamCong.AutoGenerateColumns = false;
            //        dtgvChamCong.Columns["diLam"].Visible = false;
            //        dtgvChamCong.Columns["diTre"].Visible = false;
            //        //Tạo 2 cột   
            //        if (iTemp == 0)
            //        {
            //            if (dtgvChamCong.Columns.Count > 4)
            //            {

            //            }
            //            else
            //            {
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //                DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking1);
            //                checkWorking1.HeaderText = "Đi Làm1";
            //                checkWorking1.Name = "DiLamTemp";
            //                checkWorking1.ReadOnly = false;
            //                DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking2);
            //                checkWorking2.HeaderText = "Đi Trễ1";
            //                checkWorking2.Name = "DiTreTemp";
            //                checkWorking2.ReadOnly = false;
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //                this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //                this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongNow(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
            //            }
            //        }
            //    }
            //    else if (cbbDonVi.Text == "Bộ Phận Nhân Viên Văn Phòng" && statusChamCongHCNow == false)
            //    {
            //        cbDiLamHet.Enabled = true;
            //        dtgvChamCong.AutoGenerateColumns = false;
            //        dtgvChamCong.Columns["diLam"].Visible = false;
            //        dtgvChamCong.Columns["diTre"].Visible = false;
            //        //Tạo 2 cột   
            //        if (iTemp == 0)
            //        {
            //            if (dtgvChamCong.Columns.Count > 4)
            //            {

            //            }
            //            else
            //            {
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //                DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking1);
            //                checkWorking1.HeaderText = "Đi Làm1";
            //                checkWorking1.Name = "DiLamTemp";
            //                checkWorking1.ReadOnly = false;
            //                DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking2);
            //                checkWorking2.HeaderText = "Đi Trễ1";
            //                checkWorking2.Name = "DiTreTemp";
            //                checkWorking2.ReadOnly = false;
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //                this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //                this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongNow(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
            //                iTemp = 1;
            //            }
            //        }
            //    }
            //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Lương" && statusChamCongLuongNow == false)
            //    {
            //        cbDiLamHet.Enabled = true;
            //        dtgvChamCong.AutoGenerateColumns = false;
            //        dtgvChamCong.Columns["diLam"].Visible = false;
            //        dtgvChamCong.Columns["diTre"].Visible = false;
            //        //Tạo 2 cột   
            //        if (iTemp == 0)
            //        {
            //            if (dtgvChamCong.Columns.Count > 4)
            //            {

            //            }
            //            else
            //            {
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //                DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking1);
            //                checkWorking1.HeaderText = "Đi Làm1";
            //                checkWorking1.Name = "DiLamTemp";
            //                checkWorking1.ReadOnly = false;
            //                DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking2);
            //                checkWorking2.HeaderText = "Đi Trễ1";
            //                checkWorking2.Name = "DiTreTemp";
            //                checkWorking2.ReadOnly = false;
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //                this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //                this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongNow(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
            //                iTemp = 1;
            //            }
            //        }
            //    }
            //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự" && statusChamCongNhanSuNow == false)
            //    {
            //        cbDiLamHet.Enabled = true;
            //        dtgvChamCong.AutoGenerateColumns = false;
            //        dtgvChamCong.Columns["diLam"].Visible = false;
            //        dtgvChamCong.Columns["diTre"].Visible = false;
            //        //Tạo 2 cột   
            //        if (iTemp == 0)
            //        {
            //            if (dtgvChamCong.Columns.Count > 4)
            //            {

            //            }
            //            else
            //            {
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //                DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking1);
            //                checkWorking1.HeaderText = "Đi Làm1";
            //                checkWorking1.Name = "DiLamTemp";
            //                checkWorking1.ReadOnly = false;
            //                DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking2);
            //                checkWorking2.HeaderText = "Đi Trễ1";
            //                checkWorking2.Name = "DiTreTemp";
            //                checkWorking2.ReadOnly = false;
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //                this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //                this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongNow(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
            //                iTemp = 1;
            //            }
            //        }
            //    }
            //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Hệ Thống" && statusChamCongHeThongNow == false)
            //    {
            //        cbDiLamHet.Enabled = true;
            //        dtgvChamCong.AutoGenerateColumns = false;
            //        dtgvChamCong.Columns["diLam"].Visible = false;
            //        dtgvChamCong.Columns["diTre"].Visible = false;
            //        //Tạo 2 cột   
            //        if (iTemp == 0)
            //        {
            //            if (dtgvChamCong.Columns.Count > 4)
            //            {

            //            }
            //            else
            //            {
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //                DataGridViewCheckBoxColumn checkWorking1 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking1);
            //                checkWorking1.HeaderText = "Đi Làm1";
            //                checkWorking1.Name = "DiLamTemp";
            //                checkWorking1.ReadOnly = false;
            //                DataGridViewCheckBoxColumn checkWorking2 = new DataGridViewCheckBoxColumn();
            //                dtgvChamCong.Columns.Add(checkWorking2);
            //                checkWorking2.HeaderText = "Đi Trễ1";
            //                checkWorking2.Name = "DiTreTemp";
            //                checkWorking2.ReadOnly = false;
            //                this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //                this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //                this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //                dtgvChamCong.DataSource = bus_ChamCong.layDSChamCongNow(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
            //                iTemp = 1;
            //            }
            //        }
            //    }
            //}
            //else if (date.Value.ToString("MM/dd/yyyy") != today.ToString("MM/dd/yyyy"))
            //{
            //    if (dtgvChamCong.Columns["diLam"].Visible == false)
            //    {
            //        dtgvChamCong.Columns.Remove("DiLamTemp");
            //        dtgvChamCong.Columns.Remove("DiTreTemp");
            //    }
            //    dtgvChamCong.Columns["diLam"].Visible = true;
            //    dtgvChamCong.Columns["diTre"].Visible = true;
            //    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //    dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
            //}
            //else if(date.Value.ToString("MM/dd/yyyy") == today.ToString("MM/dd/yyyy") && (statusChamCongCNNow || statusChamCongLuongNow || statusChamCongNhanSuNow || statusChamCongHeThongNow || statusChamCongHCNow))
            //{
            //    dtgvChamCong.Columns["diLam"].Visible = true;
            //    dtgvChamCong.Columns["diTre"].Visible = true;
            //    if (dtgvChamCong.Columns.Count == 6)
            //    {
            //        dtgvChamCong.Columns.Remove("DiLamTemp");
            //        dtgvChamCong.Columns.Remove("DiTreTemp");
            //    }
            //    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
            //    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
            //    dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
            //}
        }
        private void dtgvChamCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (btnSua.Text == "Lưu Sửa")
                {
                    if (cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất")
                    {
                        DataGridViewRow row = this.dtgvChamCong.Rows[e.RowIndex];
                        txtMaNV.Text = row.Cells[2].Value.ToString();
                        txtHoTen.Text = row.Cells[3].Value.ToString();
                        cbDiLam.Checked = (row.Cells[4].Value.ToString() == "True") ? true : false;
                        cbDiTre.Checked = (row.Cells[5].Value.ToString() == "True") ? true : false;
                        txtSoLuong.Text = row.Cells[6].Value.ToString();
                    }
                    else if (cbbDonVi.Text == "Bộ Phận Nhân Viên Văn Phòng")
                    {
                        DataGridViewRow row = this.dtgvChamCong.Rows[e.RowIndex];
                        txtMaNV.Text = row.Cells[2].Value.ToString();
                        txtHoTen.Text = row.Cells[3].Value.ToString();
                        cbDiLam.Checked = (row.Cells[4].Value.ToString() == "True") ? true : false;
                        cbDiTre.Checked = (row.Cells[5].Value.ToString() == "True") ? true : false;
                    }
                    //else if (cbbDonVi.Text == "Bộ Phận Quản Lý Lương")
                    //{
                    //    DataGridViewRow row = this.dtgvChamCong.Rows[e.RowIndex];
                    //    txtMaNV.Text = row.Cells[2].Value.ToString();
                    //    txtHoTen.Text = row.Cells[3].Value.ToString();
                    //    cbDiLam.Checked = (row.Cells[4].Value.ToString() == "True") ? true : false;
                    //    cbDiTre.Checked = (row.Cells[5].Value.ToString() == "True") ? true : false;
                    //}
                    //else if (cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự")
                    //{
                    //    DataGridViewRow row = this.dtgvChamCong.Rows[e.RowIndex];
                    //    txtMaNV.Text = row.Cells[2].Value.ToString();
                    //    txtHoTen.Text = row.Cells[3].Value.ToString();
                    //    cbDiLam.Checked = (row.Cells[4].Value.ToString() == "True") ? true : false;
                    //    cbDiTre.Checked = (row.Cells[5].Value.ToString() == "True") ? true : false;
                    //}
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            statusText(true);
            if (btnSua.Text == "Sửa")
            {
                btnChamCong.Enabled = false;
                btnSua.Text = "Lưu Sửa";
                statusTextClear();
            }
            else if (btnSua.Text == "Lưu Sửa")
            {
                statusText(false);
                txtSoLuong.Enabled = true;
                if (txtSoLuong.Text == "")
                {
                    MessageBox.Show("Không để trống dữ liệu", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    btnSua.Text = "Lưu Sửa";
                }
                else
                {
                    DTO_PhieuChamCongCongNhan dto_PCCLCN = new DTO_PhieuChamCongCongNhan();
                    dto_PCCLCN.MaNhanVien = txtMaNV.Text;
                    dto_PCCLCN.ISoLuongSPLamTrongNgay = Convert.ToInt32(txtSoLuong.Text);
                    dto_PCCLCN.DiLam = cbDiLam.Checked;
                    dto_PCCLCN.DiTre = cbDiTre.Checked;    
                    if (bus_ChamCong.suaThongTin(dto_PCCLCN, date.Value.ToString("yyyy-MM-dd")) == true)
                    {
                        bus_ChamCong.suaThongTin(dto_PCCLCN, date.Value.ToString("yyyy-MM-dd"));
                        MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                        btnSua.Text = "Sửa";
                        txtSoLuong.Enabled = false;
                        btnChamCong.Enabled = true;
                    }
                }
                btnSua.Text = "Sửa";
            }
        }
        private void statusTextClear()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            cbDiLam.Checked = false;
            cbDiTre.Checked = false;
        }
        #endregion

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn lưu thay đổi ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (rs == DialogResult.Yes)
            {
                if (date.Value.ToString("MM/dd/yyyy") == today.ToString("MM/dd/yyyy"))
                {
                    try
                    {
                        if (cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất")
                        {
                            string lastRow = bus_ChamCong.layDongCuoiPCCCN().Trim(); string strNumber = lastRow.Substring(5, 2);
                            int iNumber = Convert.ToInt32(strNumber) + 1;
                            bool chamCong = false;
                            bool diLam = true;
                            bool diTre = true;
                            DTO_PhieuChamCongCongNhan newPhieuCCCN = new DTO_PhieuChamCongCongNhan();
                            for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                            {
                                newPhieuCCCN.MaPhieu = "PCCCN" + (iNumber++);
                                newPhieuCCCN.NgayChamCong = DateTime.Now;
                                if (dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value == null)
                                {
                                    diLam = false;
                                }
                                if (dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value == null)
                                {
                                    diTre = false;
                                }
                                newPhieuCCCN.DiLam = (diLam == true) ? true : false;
                                newPhieuCCCN.DiTre = (diTre == true) ? true : false;
                                string strSoLuong = (string)dtgvChamCong.Rows[i].Cells["soLuongSP"].Value;
                                newPhieuCCCN.ISoLuongSPLamTrongNgay = Convert.ToInt32(strSoLuong.Trim());
                                newPhieuCCCN.TrangThai = true;
                                newPhieuCCCN.MaNhanVien = (string)dtgvChamCong.Rows[i].Cells["maNV"].Value;
                                newPhieuCCCN.MaCa = "CA001";
                                bus_ChamCong.themPhieuChamCongCN(newPhieuCCCN);
                                chamCong = true;
                            }
                            if (chamCong == true)
                            {
                                MessageBox.Show("Đã chấm công xong .", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                cbDiLamHet.Enabled = false;
                                statusCheckCN = true;
                            }
                            else
                            {
                                MessageBox.Show("Chấm công thất bại. Thử lại !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else if (cbbDonVi.Text == "Bộ Phận Nhân Viên Văn Phòng")
                        {
                            string lastRow = bus_ChamCong.layDongCuoiPCCHC().Trim();
                            string strNumber = lastRow.Substring(7, 2);
                            int iNumber = Convert.ToInt32(strNumber) + 1;
                            bool chamCong = false;
                            bool diLam = true;
                            bool diTre = true;
                            DTO_PhieuChamCongNhanVienHanhChanh newPhieuCCHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                            for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                            {
                                newPhieuCCHC.MaPhieu = "PCCNVHC" + (iNumber++);
                                newPhieuCCHC.NgayChamCong = DateTime.Now;
                                if (dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value == null)
                                {
                                    diLam = false;
                                }
                                if (dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value == null)
                                {
                                    diTre = false;
                                }
                            newPhieuCCHC.DiLam = (diLam == true) ? true : false;
                            newPhieuCCHC.DiTre = (diTre == true) ? true : false;
                                newPhieuCCHC.TrangThai = true;
                                newPhieuCCHC.MaNhanVien = (string)dtgvChamCong.Rows[i].Cells["maNV"].Value;
                                bus_ChamCong.themPhieuChamCongHC(newPhieuCCHC);
                                chamCong = true;
                            }
                            if (chamCong == true)
                            {
                                MessageBox.Show("Đã chấm công xong .", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                cbDiLamHet.Enabled = false;
                                statusCheckHC = true;
                            }
                            else
                            {
                                MessageBox.Show("Chấm công thất bại. Thử lại !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else if (cbbDonVi.Text == "Bộ Phận Quản Lý Lương")
                        {
                            string lastRow = bus_ChamCong.layDongCuoiPCCHC().Trim();
                            string strNumber = lastRow.Substring(7, 2);
                            int iNumber = Convert.ToInt32(strNumber) + 10;
                            bool chamCong = false;
                            bool diLam = true;
                            bool diTre = true;
                            DTO_PhieuChamCongNhanVienHanhChanh newPhieuCCHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                            for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                            {
                                newPhieuCCHC.MaPhieu = "PCCNVHC" + (iNumber++);
                                newPhieuCCHC.NgayChamCong = DateTime.Now;
                                if (dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value == null)
                                {
                                    diLam = false;
                                }
                                if (dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value == null)
                                {
                                    diTre = false;
                                }
                            newPhieuCCHC.DiLam = (diLam == true) ? true : false;
                            newPhieuCCHC.DiTre = (diTre == true) ? true : false;
                            newPhieuCCHC.TrangThai = true;
                                newPhieuCCHC.MaNhanVien = (string)dtgvChamCong.Rows[i].Cells["maNV"].Value;
                                bus_ChamCong.themPhieuChamCongHC(newPhieuCCHC);
                                chamCong = true;
                            }
                            if (chamCong == true)
                            {
                                MessageBox.Show("Đã chấm công xong .", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                cbDiLamHet.Enabled = false;
                                statusCheck5L = true;
                            }
                            else
                            {
                                MessageBox.Show("Chấm công thất bại. Thử lại !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else if (cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự")
                        {
                            string lastRow = bus_ChamCong.layDongCuoiPCCHC().Trim();
                            string strNumber = lastRow.Substring(7, 2);
                            int iNumber = Convert.ToInt32(strNumber) + 1;
                            bool chamCong = false;
                            bool diLam = true;
                            bool diTre = true;
                            DTO_PhieuChamCongNhanVienHanhChanh newPhieuCCHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                            for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                            {
                                newPhieuCCHC.MaPhieu = "PCCNVHC" + (iNumber++);
                                newPhieuCCHC.NgayChamCong = DateTime.Now;
                                if (dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value == null)
                                {
                                    diLam = false;
                                }
                                if (dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value == null)
                                {
                                    diTre = false;
                                }
                            newPhieuCCHC.DiLam = (diLam == true) ? true : false;
                            newPhieuCCHC.DiTre = (diTre == true) ? true : false;
                            newPhieuCCHC.TrangThai = true;
                                newPhieuCCHC.MaNhanVien = (string)dtgvChamCong.Rows[i].Cells["maNV"].Value;
                                bus_ChamCong.themPhieuChamCongHC(newPhieuCCHC);
                                chamCong = true;
                            }
                            if (chamCong == true)
                            {
                                MessageBox.Show("Đã chấm công xong .", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                cbDiLamHet.Enabled = false;
                                statusCheckNS = true;
                            }
                            else
                            {
                                MessageBox.Show("Chấm công thất bại. Thử lại !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else if (cbbDonVi.Text == "Bộ Phận Quản Lý Hệ Thống")
                        {
                            string lastRow = bus_ChamCong.layDongCuoiPCCHC().Trim();
                            string strNumber = lastRow.Substring(7, 2);
                            int iNumber = Convert.ToInt32(strNumber) + 1;
                            bool chamCong = false;
                            bool diLam = true;
                            bool diTre = true;
                            DTO_PhieuChamCongNhanVienHanhChanh newPhieuCCHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                            for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                            {
                                newPhieuCCHC.MaPhieu = "PCCNVHC" + (iNumber++);
                                newPhieuCCHC.NgayChamCong = DateTime.Now;
                                if (dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value == null)
                                {
                                    diLam = false;
                                }
                                if (dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value == null)
                                {
                                    diTre = false;
                                }
                            newPhieuCCHC.DiLam = (diLam == true) ? true : false;
                            newPhieuCCHC.DiTre = (diTre == true) ? true : false;
                                newPhieuCCHC.TrangThai = true;
                                newPhieuCCHC.MaNhanVien = (string)dtgvChamCong.Rows[i].Cells["maNV"].Value;
                                bus_ChamCong.themPhieuChamCongHC(newPhieuCCHC);
                                chamCong = true;
                            }
                            if (chamCong == true)
                            {
                                MessageBox.Show("Đã chấm công xong .", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                                cbDiLamHet.Enabled = false;
                                statusCheck4HT = true;
                            }
                            else
                            {
                                MessageBox.Show("Chấm công thất bại. Thử lại !", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Dữ liệu chưa đúng!");
                    }
                }
                //    {
                //if (date.Value.ToString("MM/dd/yyyy") != today.ToString("MM/dd/yyyy"))
                //{
                //    if (cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất")
                //    {
                //        DTO_PhieuChamCongCongNhan phieuChamCongCN = new DTO_PhieuChamCongCongNhan();
                //        phieuChamCongCN.DiLam = cbDiLam.Checked;
                //        phieuChamCongCN.DiTre = cbDiTre.Checked;
                //        phieuChamCongCN.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongCN(phieuChamCongCN, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongCN(phieuChamCongCN, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            //cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Nhân Viên Văn Phòng")
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Lương")
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự")
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Hệ Thống")
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //}
                //else if(date.Value.ToString("MM/dd/yyyy") == today.ToString("MM/dd/yyyy"))
                //{
                //    if (cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất" && statusChamCongCNNow == true)
                //    {
                //        DTO_PhieuChamCongCongNhan phieuChamCongCN = new DTO_PhieuChamCongCongNhan();
                //        phieuChamCongCN.DiLam = cbDiLam.Checked;
                //        phieuChamCongCN.DiTre = cbDiTre.Checked;
                //        phieuChamCongCN.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongCN(phieuChamCongCN, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongCN(phieuChamCongCN, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Nhân Viên Văn Phòng" && statusChamCongHCNow == true)
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Lương" && statusChamCongLuongNow == true)
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự" && statusChamCongNhanSuNow == true)
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);
                //        }
                //    }
                //    else if (cbbDonVi.Text == "Bộ Phận Quản Lý Hệ Thống" && statusChamCongHeThongNow == true)
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh phieuChamCongNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        phieuChamCongNVHC.DiLam = cbDiLam.Checked;
                //        phieuChamCongNVHC.DiTre = cbDiTre.Checked;
                //        phieuChamCongNVHC.MaNhanVien = txtMaNV.Text;
                //        if (bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd")) == true)
                //        {
                //            bus_ChamCong.suaThongTinChamCongNVHC(phieuChamCongNVHC, date.Value.ToString("yyyy-MM-dd"));
                //            MessageBox.Show("Sửa thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //            dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //            btnSua.Text = "Sửa";
                //            cbDiLamHet.Checked = false;
                //            statusText(false);

                //        }
                //    }
                //}
                //else if(date.Value.ToString("MM/dd/yyyy") == today.ToString("MM/dd/yyyy"))
                //{
                //    if(cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất")
                //    {
                //        DTO_PhieuChamCongCongNhan dto_PhieuCCCN = new DTO_PhieuChamCongCongNhan();
                //        bool diLam = true;
                //        bool diTre = true;
                //        for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                //        {
                //            dto_PhieuCCCN.MaNhanVien = (string)dtgvChamCong.Rows[i].Cells["maNV"].Value;
                //            dto_PhieuCCCN.NgayChamCong = Convert.ToDateTime(date.Value.ToString("yyyy-MM-dd"));
                //            //diLam = (bool)dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value;
                //            //diTre = (bool)dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value;
                //            if (dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value == null)
                //            {
                //                diLam = false;
                //            }
                //            if (dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value == null)
                //            {
                //                diTre = false;
                //            }
                //            dto_PhieuCCCN.DiLam = (diLam == true) ? true : false;
                //            dto_PhieuCCCN.DiTre = (diTre == true) ? true : false;
                //            bus_ChamCong.ChamCongDateNow(dto_PhieuCCCN);
                //        }
                //        MessageBox.Show("Đã chấm công xong .", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //        cbDiLamHet.Enabled = false;
                //        statusChamCongCNNow = true;
                //        dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //    }
                //    else if(cbbDonVi.Text == "Bộ Phận Nhân Viên Văn Phòng" || cbbDonVi.Text == "Bộ Phận Quản Lý Lương" || cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự" || cbbDonVi.Text == "Bộ Phận Quản Lý Hệ Thống")
                //    {
                //        DTO_PhieuChamCongNhanVienHanhChanh dto_PhieuCCNVHC = new DTO_PhieuChamCongNhanVienHanhChanh();
                //        bool diLam = true;
                //        bool diTre = true;
                //        for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                //        {
                //            dto_PhieuCCNVHC.MaNhanVien = (string)dtgvChamCong.Rows[i].Cells["maNV"].Value;
                //            dto_PhieuCCNVHC.NgayChamCong = Convert.ToDateTime(date.Value.ToString("yyyy-MM-dd"));
                //            //diLam = (bool)dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value;
                //            //diTre = (bool)dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value;
                //            if (dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value == null)
                //            {
                //                diLam = false;
                //            }
                //            if (dtgvChamCong.Rows[i].Cells["DiTreTemp"].Value == null)
                //            {
                //                diTre = false;
                //            }
                //            dto_PhieuCCNVHC.DiLam = (diLam == true) ? true : false;
                //            dto_PhieuCCNVHC.DiTre = (diTre == true) ? true : false;
                //            bus_ChamCong.ChamCongDateNowNCHC(dto_PhieuCCNVHC);
                //        }
                //        MessageBox.Show("Đã chấm công xong .", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                //        cbDiLamHet.Enabled = false;
                //        statusChamCongHCNow = true;
                //        statusChamCongLuongNow = true;
                //        statusChamCongNhanSuNow = true;
                //        statusChamCongHeThongNow = true;
                //        dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                //    }
                //}
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            //if (date.Value.ToString("MM/dd/yyyy") != today.ToString("MM/dd/yyyy"))
            //{
            try
            {
                if(dtgvChamCong.Columns.Count > 5)
                {

                }
                {
                    dtgvChamCong.Columns["DiLamTemp"].Visible = false;
                    dtgvChamCong.Columns["DiTreTemp"].Visible = false;
                    //dtgvChamCong.Columns["soLuongSP"].Visible = false;
                    //if (cbbDonVi.Text == "Bộ Phận Gia Công Sản Xuất")
                    //{
                    //    dtgvChamCong.Columns["soLuongSP"].Visible = true;
                    //}    
                    //if(cbbDonVi.Text == "Bộ Phận Quản Lý Lương")
                    //{
                    //    dtgvChamCong.Columns["soLuongSP"].Visible = false;
                    //}      
                    //if(cbbDonVi.Text == "Bộ Phận Quản Lý Nhân Sự")
                    //{
                    //    dtgvChamCong.Columns["soLuongSP"].Visible = false;
                    //} 
                    //if(cbbDonVi.Text == "Bộ Phận Quản Lý Hệ Thống")
                    //{
                    //    dtgvChamCong.Columns["soLuongSP"].Visible = false;
                    //}    
                    dtgvChamCong.Columns["diLam"].Visible = true;
                    dtgvChamCong.Columns["diTre"].Visible = true;
                    this.dtgvChamCong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dtgvChamCong.DefaultCellStyle.ForeColor = Color.Black;
                    this.dtgvChamCong.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    this.dtgvChamCong.DefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold);
                    dtgvChamCong.DataSource = bus_ChamCong.layDSTheoCBB(cbbDonVi.Text, date.Value.ToString("yyyy-MM-dd"));
                }        
            }
            catch(Exception)
            { }
            //}
        }

        private void cbDiLamHet_CheckedChanged(object sender, EventArgs e)
        {
            if (dtgvChamCong.Rows.Count == 0)
            {
                MessageBox.Show("Không có gì cả !");
            }
            else if (cbDiLamHet.Checked == true)
            {
                for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                {
                    dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < dtgvChamCong.Rows.Count; i++)
                {
                    dtgvChamCong.Rows[i].Cells["DiLamTemp"].Value = false;
                }
            }
        }
    }
}
