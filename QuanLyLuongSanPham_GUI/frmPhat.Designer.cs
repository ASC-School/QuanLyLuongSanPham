
namespace QuanLyLuongSanPham_GUI
{
    partial class frmPhat
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhat));
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNV = new DevExpress.XtraEditors.LabelControl();
            this.lblTTDonVi = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cboMucPhat = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboMaDonVi = new System.Windows.Forms.ComboBox();
            this.dtpNgayPhat = new System.Windows.Forms.DateTimePicker();
            this.cboTienPhat = new System.Windows.Forms.ComboBox();
            this.cboMaPhat = new System.Windows.Forms.ComboBox();
            this.cboTenNhanVien = new System.Windows.Forms.ComboBox();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.timeSpanChartRangeControlClient1 = new DevExpress.XtraEditors.TimeSpanChartRangeControlClient();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.dtgvDsPhat = new System.Windows.Forms.DataGridView();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maMucPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenMucPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tienPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayPhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanChartRangeControlClient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDsPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(9, 276);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(86, 21);
            this.labelControl6.TabIndex = 1;
            this.labelControl6.Text = "Ngày phạt :";
            // 
            // lblMaNV
            // 
            this.lblMaNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Appearance.Options.UseFont = true;
            this.lblMaNV.Location = new System.Drawing.Point(35, 97);
            this.lblMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(60, 21);
            this.lblMaNV.TabIndex = 1;
            this.lblMaNV.Text = "Họ tên :";
            // 
            // lblTTDonVi
            // 
            this.lblTTDonVi.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTTDonVi.Appearance.Options.UseFont = true;
            this.lblTTDonVi.Location = new System.Drawing.Point(37, 320);
            this.lblTTDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.lblTTDonVi.Name = "lblTTDonVi";
            this.lblTTDonVi.Size = new System.Drawing.Size(58, 21);
            this.lblTTDonVi.TabIndex = 1;
            this.lblTTDonVi.Text = "Đơn vị :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.cboMucPhat);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.cboMaDonVi);
            this.panelControl2.Controls.Add(this.dtpNgayPhat);
            this.panelControl2.Controls.Add(this.cboTienPhat);
            this.panelControl2.Controls.Add(this.cboMaPhat);
            this.panelControl2.Controls.Add(this.cboTenNhanVien);
            this.panelControl2.Controls.Add(this.cboMaNhanVien);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.btnXoa);
            this.panelControl2.Controls.Add(this.btnLuu);
            this.panelControl2.Controls.Add(this.btnThem);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.lblMaNV);
            this.panelControl2.Controls.Add(this.lblTTDonVi);
            this.panelControl2.Location = new System.Drawing.Point(740, 6);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(440, 437);
            this.panelControl2.TabIndex = 8;
            // 
            // cboMucPhat
            // 
            this.cboMucPhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMucPhat.FormattingEnabled = true;
            this.cboMucPhat.Location = new System.Drawing.Point(127, 189);
            this.cboMucPhat.Name = "cboMucPhat";
            this.cboMucPhat.Size = new System.Drawing.Size(294, 24);
            this.cboMucPhat.TabIndex = 14;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(10, 187);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 21);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "Mức phạt  :";
            // 
            // cboMaDonVi
            // 
            this.cboMaDonVi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaDonVi.FormattingEnabled = true;
            this.cboMaDonVi.Location = new System.Drawing.Point(126, 318);
            this.cboMaDonVi.Name = "cboMaDonVi";
            this.cboMaDonVi.Size = new System.Drawing.Size(294, 24);
            this.cboMaDonVi.TabIndex = 12;
            // 
            // dtpNgayPhat
            // 
            this.dtpNgayPhat.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayPhat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayPhat.Location = new System.Drawing.Point(126, 275);
            this.dtpNgayPhat.Name = "dtpNgayPhat";
            this.dtpNgayPhat.Size = new System.Drawing.Size(294, 23);
            this.dtpNgayPhat.TabIndex = 11;
            // 
            // cboTienPhat
            // 
            this.cboTienPhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTienPhat.FormattingEnabled = true;
            this.cboTienPhat.Location = new System.Drawing.Point(126, 231);
            this.cboTienPhat.Name = "cboTienPhat";
            this.cboTienPhat.Size = new System.Drawing.Size(294, 24);
            this.cboTienPhat.TabIndex = 10;
            // 
            // cboMaPhat
            // 
            this.cboMaPhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaPhat.FormattingEnabled = true;
            this.cboMaPhat.Location = new System.Drawing.Point(126, 146);
            this.cboMaPhat.Name = "cboMaPhat";
            this.cboMaPhat.Size = new System.Drawing.Size(294, 24);
            this.cboMaPhat.TabIndex = 9;
            this.cboMaPhat.SelectedIndexChanged += new System.EventHandler(this.cboMaPhat_SelectedIndexChanged);
            // 
            // cboTenNhanVien
            // 
            this.cboTenNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenNhanVien.FormattingEnabled = true;
            this.cboTenNhanVien.Location = new System.Drawing.Point(126, 98);
            this.cboTenNhanVien.Name = "cboTenNhanVien";
            this.cboTenNhanVien.Size = new System.Drawing.Size(294, 24);
            this.cboTenNhanVien.TabIndex = 8;
            this.cboTenNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboTenNhanVien_SelectedIndexChanged);
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(126, 46);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(294, 24);
            this.cboMaNhanVien.TabIndex = 7;
            this.cboMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboMaNhanVien_SelectedIndexChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(10, 230);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(81, 21);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Tiền phạt :";
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(123)))), ((int)(((byte)(137)))));
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseBackColor = true;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(309, 373);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(111, 40);
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Text = "Xóa";
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(123)))), ((int)(((byte)(137)))));
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.Options.UseBackColor = true;
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(170, 373);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(108, 40);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            // 
            // btnThem
            // 
            this.btnThem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(123)))), ((int)(((byte)(137)))));
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.Options.UseBackColor = true;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.Location = new System.Drawing.Point(26, 373);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 40);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(24, 145);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(71, 21);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Mã phạt :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(36, 45);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(59, 21);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Mã NV :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(77, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(213, 29);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "PHẠT NHÂN VIÊN";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.dtgvDsPhat);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Location = new System.Drawing.Point(7, 50);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1193, 453);
            this.panelControl1.TabIndex = 32;
            // 
            // dtgvDsPhat
            // 
            this.dtgvDsPhat.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtgvDsPhat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDsPhat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maNhanVien,
            this.tenNhanVien,
            this.maMucPhat,
            this.tenMucPhat,
            this.tienPhat,
            this.ngayPhat,
            this.maDonVi});
            this.dtgvDsPhat.Location = new System.Drawing.Point(6, 6);
            this.dtgvDsPhat.Name = "dtgvDsPhat";
            this.dtgvDsPhat.RowHeadersWidth = 51;
            this.dtgvDsPhat.RowTemplate.Height = 24;
            this.dtgvDsPhat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDsPhat.Size = new System.Drawing.Size(728, 437);
            this.dtgvDsPhat.TabIndex = 9;
            this.dtgvDsPhat.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDsPhat_CellClick);
            // 
            // maNhanVien
            // 
            this.maNhanVien.DataPropertyName = "maNhanVien";
            this.maNhanVien.HeaderText = "Mã nhân viên";
            this.maNhanVien.MinimumWidth = 6;
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.Width = 125;
            // 
            // tenNhanVien
            // 
            this.tenNhanVien.DataPropertyName = "tenNhanVien";
            this.tenNhanVien.HeaderText = "Tên nhân viên";
            this.tenNhanVien.MinimumWidth = 6;
            this.tenNhanVien.Name = "tenNhanVien";
            this.tenNhanVien.Width = 125;
            // 
            // maMucPhat
            // 
            this.maMucPhat.DataPropertyName = "maMucPhat";
            this.maMucPhat.HeaderText = "Mã mức phạt";
            this.maMucPhat.MinimumWidth = 6;
            this.maMucPhat.Name = "maMucPhat";
            this.maMucPhat.Width = 125;
            // 
            // tenMucPhat
            // 
            this.tenMucPhat.DataPropertyName = "tenMucPhat";
            this.tenMucPhat.HeaderText = "Tên mức phạt";
            this.tenMucPhat.MinimumWidth = 6;
            this.tenMucPhat.Name = "tenMucPhat";
            this.tenMucPhat.Width = 125;
            // 
            // tienPhat
            // 
            this.tienPhat.DataPropertyName = "tienPhat";
            this.tienPhat.HeaderText = "Tiền phạt";
            this.tienPhat.MinimumWidth = 6;
            this.tienPhat.Name = "tienPhat";
            this.tienPhat.Width = 125;
            // 
            // ngayPhat
            // 
            this.ngayPhat.DataPropertyName = "ngayPhat";
            this.ngayPhat.HeaderText = "Ngày phạt";
            this.ngayPhat.MinimumWidth = 6;
            this.ngayPhat.Name = "ngayPhat";
            this.ngayPhat.Width = 125;
            // 
            // maDonVi
            // 
            this.maDonVi.DataPropertyName = "donVi";
            this.maDonVi.HeaderText = "Mã đơn vị";
            this.maDonVi.MinimumWidth = 6;
            this.maDonVi.Name = "maDonVi";
            this.maDonVi.Width = 125;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(1160, 10);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(40, 33);
            this.btnThoat.TabIndex = 31;
            this.btnThoat.Text = "          ";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(7, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // frmPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(1205, 512);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPhat";
            this.Load += new System.EventHandler(this.FrmPhat_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmPhat_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmPhat_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanChartRangeControlClient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDsPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.LabelControl lblTTDonVi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.TimeSpanChartRangeControlClient timeSpanChartRangeControlClient1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.DataGridView dtgvDsPhat;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.DateTimePicker dtpNgayPhat;
        private System.Windows.Forms.ComboBox cboTienPhat;
        private System.Windows.Forms.ComboBox cboMaPhat;
        private System.Windows.Forms.ComboBox cboTenNhanVien;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
        private System.Windows.Forms.ComboBox cboMaDonVi;
        private System.Windows.Forms.ComboBox cboMucPhat;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn maMucPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMucPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn tienPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayPhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn maDonVi;
    }
}