
namespace QuanLyLuongSanPham_GUI
{
    partial class frmTimKiemLuongTheoLoai
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemLuongTheoLoai));
            this.label2 = new System.Windows.Forms.Label();
            this.lblError3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTimKiemTenNV = new System.Windows.Forms.TextBox();
            this.txtTimKiemMaNV = new System.Windows.Forms.TextBox();
            this.ccbTimKiemTheoLoai = new System.Windows.Forms.ComboBox();
            this.cbbLuongThang = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTenNV = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNV = new DevExpress.XtraEditors.LabelControl();
            this.lblError1 = new DevExpress.XtraEditors.LabelControl();
            this.dtgvDanhSachTimKiem = new System.Windows.Forms.DataGridView();
            this.maNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.congDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongSPLamDuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongLuongTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tamUng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thucNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBangLuongCN = new DevExpress.XtraEditors.LabelControl();
            this.ccbNam = new System.Windows.Forms.ComboBox();
            this.lblError4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(2, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1272, 46);
            this.label2.TabIndex = 86;
            this.label2.Text = "TÌM KIẾM NHÂN VIÊN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblError3
            // 
            this.lblError3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblError3.Appearance.Options.UseFont = true;
            this.lblError3.Appearance.Options.UseForeColor = true;
            this.lblError3.Location = new System.Drawing.Point(601, 155);
            this.lblError3.Margin = new System.Windows.Forms.Padding(4);
            this.lblError3.Name = "lblError3";
            this.lblError3.Size = new System.Drawing.Size(13, 24);
            this.lblError3.TabIndex = 85;
            this.lblError3.Text = "*";
            this.lblError3.ToolTip = "Bắt buộc";
            this.lblError3.Visible = false;
            // 
            // txtTimKiemTenNV
            // 
            this.txtTimKiemTenNV.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemTenNV.Location = new System.Drawing.Point(466, 238);
            this.txtTimKiemTenNV.Name = "txtTimKiemTenNV";
            this.txtTimKiemTenNV.Size = new System.Drawing.Size(305, 28);
            this.txtTimKiemTenNV.TabIndex = 82;
            // 
            // txtTimKiemMaNV
            // 
            this.txtTimKiemMaNV.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemMaNV.Location = new System.Drawing.Point(466, 195);
            this.txtTimKiemMaNV.Name = "txtTimKiemMaNV";
            this.txtTimKiemMaNV.Size = new System.Drawing.Size(305, 28);
            this.txtTimKiemMaNV.TabIndex = 83;
            this.txtTimKiemMaNV.TextChanged += new System.EventHandler(this.txtTimKiemMaNV_TextChanged);
            this.txtTimKiemMaNV.Leave += new System.EventHandler(this.txtTimKiemMaNV_Leave);
            // 
            // ccbTimKiemTheoLoai
            // 
            this.ccbTimKiemTheoLoai.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbTimKiemTheoLoai.FormattingEnabled = true;
            this.ccbTimKiemTheoLoai.Location = new System.Drawing.Point(466, 66);
            this.ccbTimKiemTheoLoai.Name = "ccbTimKiemTheoLoai";
            this.ccbTimKiemTheoLoai.Size = new System.Drawing.Size(305, 29);
            this.ccbTimKiemTheoLoai.TabIndex = 79;
            this.ccbTimKiemTheoLoai.SelectedIndexChanged += new System.EventHandler(this.ccbTimKiemTheoLoai_SelectedIndexChanged);
            this.ccbTimKiemTheoLoai.Leave += new System.EventHandler(this.ccbTimKiemTheoLoai_Leave);
            // 
            // cbbLuongThang
            // 
            this.cbbLuongThang.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLuongThang.FormattingEnabled = true;
            this.cbbLuongThang.Location = new System.Drawing.Point(466, 150);
            this.cbbLuongThang.Name = "cbbLuongThang";
            this.cbbLuongThang.Size = new System.Drawing.Size(128, 29);
            this.cbbLuongThang.TabIndex = 80;
            this.cbbLuongThang.Leave += new System.EventHandler(this.cbbLuongThang_Leave);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(370, 71);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 21);
            this.labelControl3.TabIndex = 73;
            this.labelControl3.Text = "Theo loại :";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Crimson;
            this.btnTimKiem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimKiem.Location = new System.Drawing.Point(847, 150);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(133, 46);
            this.btnTimKiem.TabIndex = 77;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(336, 150);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 21);
            this.labelControl2.TabIndex = 74;
            this.labelControl2.Text = "Lương Tháng :";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Crimson;
            this.btnLamMoi.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(847, 214);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(133, 46);
            this.btnLamMoi.TabIndex = 78;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTenNV
            // 
            this.lblTenNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTenNV.Appearance.Options.UseFont = true;
            this.lblTenNV.Appearance.Options.UseForeColor = true;
            this.lblTenNV.Location = new System.Drawing.Point(330, 238);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(119, 21);
            this.lblTenNV.TabIndex = 75;
            this.lblTenNV.Text = "Tên Nhân Viên :";
            // 
            // lblMaNV
            // 
            this.lblMaNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblMaNV.Appearance.Options.UseFont = true;
            this.lblMaNV.Appearance.Options.UseForeColor = true;
            this.lblMaNV.Location = new System.Drawing.Point(336, 195);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(113, 21);
            this.lblMaNV.TabIndex = 76;
            this.lblMaNV.Text = "Mã Nhân Viên :";
            // 
            // lblError1
            // 
            this.lblError1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblError1.Appearance.Options.UseFont = true;
            this.lblError1.Appearance.Options.UseForeColor = true;
            this.lblError1.Location = new System.Drawing.Point(776, 71);
            this.lblError1.Margin = new System.Windows.Forms.Padding(4);
            this.lblError1.Name = "lblError1";
            this.lblError1.Size = new System.Drawing.Size(13, 24);
            this.lblError1.TabIndex = 85;
            this.lblError1.Text = "*";
            this.lblError1.ToolTip = "Bắt buộc";
            this.lblError1.Visible = false;
            // 
            // dtgvDanhSachTimKiem
            // 
            this.dtgvDanhSachTimKiem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgvDanhSachTimKiem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvDanhSachTimKiem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDanhSachTimKiem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDanhSachTimKiem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvDanhSachTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDanhSachTimKiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maNV,
            this.tenNV,
            this.donVi,
            this.thang,
            this.nam,
            this.congDoan,
            this.soLuongSPLamDuoc,
            this.phuCap,
            this.tienPhat,
            this.thue,
            this.tongLuongTT,
            this.tamUng,
            this.thucNhan});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDanhSachTimKiem.DefaultCellStyle = dataGridViewCellStyle14;
            this.dtgvDanhSachTimKiem.EnableHeadersVisualStyles = false;
            this.dtgvDanhSachTimKiem.Location = new System.Drawing.Point(12, 359);
            this.dtgvDanhSachTimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgvDanhSachTimKiem.Name = "dtgvDanhSachTimKiem";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDanhSachTimKiem.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dtgvDanhSachTimKiem.RowHeadersVisible = false;
            this.dtgvDanhSachTimKiem.RowHeadersWidth = 51;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dtgvDanhSachTimKiem.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dtgvDanhSachTimKiem.RowTemplate.Height = 24;
            this.dtgvDanhSachTimKiem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDanhSachTimKiem.Size = new System.Drawing.Size(1251, 309);
            this.dtgvDanhSachTimKiem.TabIndex = 112;
            this.dtgvDanhSachTimKiem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSachTimKiem_CellDoubleClick);
            // 
            // maNV
            // 
            this.maNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.maNV.DataPropertyName = "maNV";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maNV.DefaultCellStyle = dataGridViewCellStyle3;
            this.maNV.FillWeight = 30F;
            this.maNV.HeaderText = "Mã Nhân Viên";
            this.maNV.MinimumWidth = 6;
            this.maNV.Name = "maNV";
            this.maNV.ReadOnly = true;
            this.maNV.Width = 109;
            // 
            // tenNV
            // 
            this.tenNV.DataPropertyName = "tenNV";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tenNV.DefaultCellStyle = dataGridViewCellStyle4;
            this.tenNV.HeaderText = "Họ Tên";
            this.tenNV.MinimumWidth = 6;
            this.tenNV.Name = "tenNV";
            this.tenNV.ReadOnly = true;
            // 
            // donVi
            // 
            this.donVi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.donVi.DataPropertyName = "donVi";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.donVi.DefaultCellStyle = dataGridViewCellStyle5;
            this.donVi.HeaderText = "Đơn Vị";
            this.donVi.MinimumWidth = 6;
            this.donVi.Name = "donVi";
            this.donVi.ReadOnly = true;
            this.donVi.Width = 63;
            // 
            // thang
            // 
            this.thang.DataPropertyName = "thang";
            this.thang.HeaderText = "Tháng";
            this.thang.MinimumWidth = 6;
            this.thang.Name = "thang";
            // 
            // nam
            // 
            this.nam.DataPropertyName = "nam";
            this.nam.HeaderText = "Năm";
            this.nam.MinimumWidth = 6;
            this.nam.Name = "nam";
            // 
            // congDoan
            // 
            this.congDoan.DataPropertyName = "congDoan";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "dd/MM/yyyy";
            this.congDoan.DefaultCellStyle = dataGridViewCellStyle6;
            this.congDoan.HeaderText = "Công Đoạn";
            this.congDoan.MinimumWidth = 6;
            this.congDoan.Name = "congDoan";
            this.congDoan.ReadOnly = true;
            // 
            // soLuongSPLamDuoc
            // 
            this.soLuongSPLamDuoc.DataPropertyName = "soLuongSPLamDuoc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.soLuongSPLamDuoc.DefaultCellStyle = dataGridViewCellStyle7;
            this.soLuongSPLamDuoc.HeaderText = "SLSP Làm Được";
            this.soLuongSPLamDuoc.MinimumWidth = 6;
            this.soLuongSPLamDuoc.Name = "soLuongSPLamDuoc";
            // 
            // phuCap
            // 
            this.phuCap.DataPropertyName = "phuCap";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phuCap.DefaultCellStyle = dataGridViewCellStyle8;
            this.phuCap.HeaderText = "Phụ Cấp";
            this.phuCap.MinimumWidth = 6;
            this.phuCap.Name = "phuCap";
            // 
            // tienPhat
            // 
            this.tienPhat.DataPropertyName = "tienPhat";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.tienPhat.DefaultCellStyle = dataGridViewCellStyle9;
            this.tienPhat.HeaderText = "Tiền Phạt";
            this.tienPhat.MinimumWidth = 6;
            this.tienPhat.Name = "tienPhat";
            // 
            // thue
            // 
            this.thue.DataPropertyName = "thue";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.thue.DefaultCellStyle = dataGridViewCellStyle10;
            this.thue.HeaderText = "Thuế (%)";
            this.thue.MinimumWidth = 6;
            this.thue.Name = "thue";
            // 
            // tongLuongTT
            // 
            this.tongLuongTT.DataPropertyName = "tongLuongTT";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.tongLuongTT.DefaultCellStyle = dataGridViewCellStyle11;
            this.tongLuongTT.HeaderText = "Tổng Lương TT";
            this.tongLuongTT.MinimumWidth = 6;
            this.tongLuongTT.Name = "tongLuongTT";
            // 
            // tamUng
            // 
            this.tamUng.DataPropertyName = "tamUng";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.tamUng.DefaultCellStyle = dataGridViewCellStyle12;
            this.tamUng.HeaderText = "Tạm Ứng";
            this.tamUng.MinimumWidth = 6;
            this.tamUng.Name = "tamUng";
            // 
            // thucNhan
            // 
            this.thucNhan.DataPropertyName = "thucNhan";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Format = "N0";
            dataGridViewCellStyle13.NullValue = null;
            this.thucNhan.DefaultCellStyle = dataGridViewCellStyle13;
            this.thucNhan.HeaderText = "Thực Nhận";
            this.thucNhan.MinimumWidth = 6;
            this.thucNhan.Name = "thucNhan";
            // 
            // lblBangLuongCN
            // 
            this.lblBangLuongCN.Appearance.BackColor = System.Drawing.Color.Silver;
            this.lblBangLuongCN.Appearance.BorderColor = System.Drawing.Color.Black;
            this.lblBangLuongCN.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBangLuongCN.Appearance.Options.UseBackColor = true;
            this.lblBangLuongCN.Appearance.Options.UseBorderColor = true;
            this.lblBangLuongCN.Appearance.Options.UseFont = true;
            this.lblBangLuongCN.Appearance.Options.UseTextOptions = true;
            this.lblBangLuongCN.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBangLuongCN.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBangLuongCN.LineColor = System.Drawing.Color.Black;
            this.lblBangLuongCN.Location = new System.Drawing.Point(12, 320);
            this.lblBangLuongCN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblBangLuongCN.Name = "lblBangLuongCN";
            this.lblBangLuongCN.Size = new System.Drawing.Size(1251, 45);
            this.lblBangLuongCN.TabIndex = 111;
            this.lblBangLuongCN.Text = "BẢNG LƯƠNG CÔNG NHÂN";
            // 
            // ccbNam
            // 
            this.ccbNam.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ccbNam.FormattingEnabled = true;
            this.ccbNam.Location = new System.Drawing.Point(643, 147);
            this.ccbNam.Name = "ccbNam";
            this.ccbNam.Size = new System.Drawing.Size(128, 29);
            this.ccbNam.TabIndex = 80;
            this.ccbNam.Text = "2021";
            this.ccbNam.Leave += new System.EventHandler(this.ccbNam_Leave);
            // 
            // lblError4
            // 
            this.lblError4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblError4.Appearance.Options.UseFont = true;
            this.lblError4.Appearance.Options.UseForeColor = true;
            this.lblError4.Location = new System.Drawing.Point(776, 150);
            this.lblError4.Margin = new System.Windows.Forms.Padding(4);
            this.lblError4.Name = "lblError4";
            this.lblError4.Size = new System.Drawing.Size(13, 24);
            this.lblError4.TabIndex = 85;
            this.lblError4.Text = "*";
            this.lblError4.ToolTip = "Bắt buộc";
            this.lblError4.Visible = false;
            // 
            // frmTimKiemLuongTheoLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 682);
            this.Controls.Add(this.dtgvDanhSachTimKiem);
            this.Controls.Add(this.lblBangLuongCN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblError4);
            this.Controls.Add(this.lblError1);
            this.Controls.Add(this.lblError3);
            this.Controls.Add(this.txtTimKiemTenNV);
            this.Controls.Add(this.txtTimKiemMaNV);
            this.Controls.Add(this.ccbTimKiemTheoLoai);
            this.Controls.Add(this.ccbNam);
            this.Controls.Add(this.cbbLuongThang);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.lblTenNV);
            this.Controls.Add(this.lblMaNV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTimKiemLuongTheoLoai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TÌM KIẾM";
            this.Load += new System.EventHandler(this.FrmTimKiemNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl lblError3;
        private System.Windows.Forms.TextBox txtTimKiemTenNV;
        private System.Windows.Forms.TextBox txtTimKiemMaNV;
        private System.Windows.Forms.ComboBox ccbTimKiemTheoLoai;
        private System.Windows.Forms.ComboBox cbbLuongThang;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Button btnTimKiem;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Button btnLamMoi;
        private DevExpress.XtraEditors.LabelControl lblTenNV;
        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.LabelControl lblError1;
        private System.Windows.Forms.DataGridView dtgvDanhSachTimKiem;
        private DevExpress.XtraEditors.LabelControl lblBangLuongCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn donVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn thang;
        private System.Windows.Forms.DataGridViewTextBoxColumn nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn congDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongSPLamDuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn thue;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongLuongTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn tamUng;
        private System.Windows.Forms.DataGridViewTextBoxColumn thucNhan;
        private System.Windows.Forms.ComboBox ccbNam;
        private DevExpress.XtraEditors.LabelControl lblError4;
    }
}