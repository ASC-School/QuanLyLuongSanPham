
namespace QuanLyLuongSanPham_GUI
{
    partial class frmDonViQuanLy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDonViQuanLy));
            this.btnXoaCongDoan = new System.Windows.Forms.Button();
            this.btnSuaCongDoan = new System.Windows.Forms.Button();
            this.btnThemCongDoan = new System.Windows.Forms.Button();
            this.cboMaLoai = new System.Windows.Forms.ComboBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtTenBoPhan = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTipOpenFrmModel = new System.Windows.Forms.ToolTip(this.components);
            this.dtgvDonVi = new System.Windows.Forms.DataGridView();
            this.maCongDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenCongDoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maModel1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvLoaiNhanVien = new System.Windows.Forms.DataGridView();
            this.maModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOpenFrmSanPham = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDonVi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLoaiNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoaCongDoan
            // 
            this.btnXoaCongDoan.BackColor = System.Drawing.Color.Crimson;
            this.btnXoaCongDoan.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnXoaCongDoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaCongDoan.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoaCongDoan.ForeColor = System.Drawing.Color.White;
            this.btnXoaCongDoan.Location = new System.Drawing.Point(616, 200);
            this.btnXoaCongDoan.Name = "btnXoaCongDoan";
            this.btnXoaCongDoan.Size = new System.Drawing.Size(147, 33);
            this.btnXoaCongDoan.TabIndex = 68;
            this.btnXoaCongDoan.Text = "Xóa";
            this.btnXoaCongDoan.UseVisualStyleBackColor = false;
            this.btnXoaCongDoan.Click += new System.EventHandler(this.btnXoaCongDoan_Click);
            // 
            // btnSuaCongDoan
            // 
            this.btnSuaCongDoan.BackColor = System.Drawing.Color.Crimson;
            this.btnSuaCongDoan.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnSuaCongDoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaCongDoan.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSuaCongDoan.ForeColor = System.Drawing.Color.White;
            this.btnSuaCongDoan.Location = new System.Drawing.Point(616, 143);
            this.btnSuaCongDoan.Name = "btnSuaCongDoan";
            this.btnSuaCongDoan.Size = new System.Drawing.Size(147, 33);
            this.btnSuaCongDoan.TabIndex = 67;
            this.btnSuaCongDoan.Text = "Sửa";
            this.btnSuaCongDoan.UseVisualStyleBackColor = false;
            this.btnSuaCongDoan.Click += new System.EventHandler(this.btnSuaCongDoan_Click);
            // 
            // btnThemCongDoan
            // 
            this.btnThemCongDoan.BackColor = System.Drawing.Color.Crimson;
            this.btnThemCongDoan.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnThemCongDoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemCongDoan.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemCongDoan.ForeColor = System.Drawing.Color.White;
            this.btnThemCongDoan.Location = new System.Drawing.Point(616, 82);
            this.btnThemCongDoan.Name = "btnThemCongDoan";
            this.btnThemCongDoan.Size = new System.Drawing.Size(147, 33);
            this.btnThemCongDoan.TabIndex = 66;
            this.btnThemCongDoan.Text = "Thêm";
            this.btnThemCongDoan.UseVisualStyleBackColor = false;
            this.btnThemCongDoan.Click += new System.EventHandler(this.btnThemCongDoan_Click);
            // 
            // cboMaLoai
            // 
            this.cboMaLoai.FormattingEnabled = true;
            this.cboMaLoai.Location = new System.Drawing.Point(222, 180);
            this.cboMaLoai.Name = "cboMaLoai";
            this.cboMaLoai.Size = new System.Drawing.Size(273, 24);
            this.cboMaLoai.TabIndex = 63;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(222, 153);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(273, 23);
            this.txtSoLuong.TabIndex = 62;
            // 
            // txtTenBoPhan
            // 
            this.txtTenBoPhan.Location = new System.Drawing.Point(223, 126);
            this.txtTenBoPhan.Name = "txtTenBoPhan";
            this.txtTenBoPhan.Size = new System.Drawing.Size(273, 23);
            this.txtTenBoPhan.TabIndex = 61;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(222, 99);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(273, 23);
            this.txtDonVi.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(38, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 74;
            this.label5.Text = "Mã loại";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(38, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 23);
            this.label4.TabIndex = 73;
            this.label4.Text = "Số lượng nhân viên:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(38, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 23);
            this.label3.TabIndex = 72;
            this.label3.Text = "Tên bộ phận:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 23);
            this.label2.TabIndex = 44;
            this.label2.Text = "Đơn vị quản lý";
            // 
            // dtgvDonVi
            // 
            this.dtgvDonVi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvDonVi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvDonVi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDonVi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maCongDoan,
            this.tenCongDoan,
            this.maModel1,
            this.maSanPham});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvDonVi.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvDonVi.Location = new System.Drawing.Point(10, 25);
            this.dtgvDonVi.Name = "dtgvDonVi";
            this.dtgvDonVi.RowHeadersWidth = 51;
            this.dtgvDonVi.RowTemplate.Height = 24;
            this.dtgvDonVi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDonVi.Size = new System.Drawing.Size(435, 222);
            this.dtgvDonVi.TabIndex = 0;
            this.dtgvDonVi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDonVi_CellClick);
            // 
            // maCongDoan
            // 
            this.maCongDoan.DataPropertyName = "maCongDoan";
            this.maCongDoan.HeaderText = "Mã đơn vị";
            this.maCongDoan.MinimumWidth = 6;
            this.maCongDoan.Name = "maCongDoan";
            this.maCongDoan.Width = 125;
            // 
            // tenCongDoan
            // 
            this.tenCongDoan.DataPropertyName = "tenCongDoan";
            this.tenCongDoan.HeaderText = "Tên đơn vị";
            this.tenCongDoan.MinimumWidth = 6;
            this.tenCongDoan.Name = "tenCongDoan";
            this.tenCongDoan.Width = 150;
            // 
            // maModel1
            // 
            this.maModel1.DataPropertyName = "donGia";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.maModel1.DefaultCellStyle = dataGridViewCellStyle2;
            this.maModel1.HeaderText = "Số lượng nhân viên";
            this.maModel1.MinimumWidth = 6;
            this.maModel1.Name = "maModel1";
            this.maModel1.Width = 125;
            // 
            // maSanPham
            // 
            this.maSanPham.DataPropertyName = "maSanPham";
            this.maSanPham.HeaderText = "Mã loại";
            this.maSanPham.MinimumWidth = 6;
            this.maSanPham.Name = "maSanPham";
            this.maSanPham.Width = 125;
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.panelControl3.Appearance.Options.UseBorderColor = true;
            this.panelControl3.Controls.Add(this.dtgvDonVi);
            this.panelControl3.Controls.Add(this.label2);
            this.panelControl3.Location = new System.Drawing.Point(466, 254);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(454, 253);
            this.panelControl3.TabIndex = 71;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 23);
            this.label1.TabIndex = 44;
            this.label1.Text = "Loại nhân viên";
            // 
            // dtgvLoaiNhanVien
            // 
            this.dtgvLoaiNhanVien.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvLoaiNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvLoaiNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvLoaiNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maModel,
            this.tenModel,
            this.trangThai});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvLoaiNhanVien.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvLoaiNhanVien.Location = new System.Drawing.Point(10, 25);
            this.dtgvLoaiNhanVien.Name = "dtgvLoaiNhanVien";
            this.dtgvLoaiNhanVien.RowHeadersWidth = 51;
            this.dtgvLoaiNhanVien.RowTemplate.Height = 24;
            this.dtgvLoaiNhanVien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvLoaiNhanVien.Size = new System.Drawing.Size(438, 222);
            this.dtgvLoaiNhanVien.TabIndex = 0;
            // 
            // maModel
            // 
            this.maModel.DataPropertyName = "maLoai";
            this.maModel.HeaderText = "Mã loại";
            this.maModel.MinimumWidth = 6;
            this.maModel.Name = "maModel";
            this.maModel.Width = 125;
            // 
            // tenModel
            // 
            this.tenModel.DataPropertyName = "loaiNhanVien";
            this.tenModel.HeaderText = "Loại nhân viên";
            this.tenModel.MinimumWidth = 6;
            this.tenModel.Name = "tenModel";
            this.tenModel.Width = 150;
            // 
            // trangThai
            // 
            this.trangThai.DataPropertyName = "Trạng thái";
            this.trangThai.HeaderText = "Trạng thái";
            this.trangThai.MinimumWidth = 6;
            this.trangThai.Name = "trangThai";
            this.trangThai.Width = 75;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(38, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 23);
            this.label6.TabIndex = 70;
            this.label6.Text = "Mã đơn vị:";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.panelControl2.Appearance.Options.UseBorderColor = true;
            this.panelControl2.Controls.Add(this.dtgvLoaiNhanVien);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Location = new System.Drawing.Point(6, 254);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(454, 253);
            this.panelControl2.TabIndex = 69;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(71, 15);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(208, 29);
            this.labelControl1.TabIndex = 24;
            this.labelControl1.Text = "ĐƠN VỊ QUẢN LÝ";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Controls.Add(this.pictureBox2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(928, 54);
            this.panelControl1.TabIndex = 64;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(886, 7);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(40, 37);
            this.btnThoat.TabIndex = 33;
            this.btnThoat.Text = "          ";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(6, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // btnOpenFrmSanPham
            // 
            this.btnOpenFrmSanPham.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenFrmSanPham.BackgroundImage")));
            this.btnOpenFrmSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFrmSanPham.Location = new System.Drawing.Point(511, 178);
            this.btnOpenFrmSanPham.Name = "btnOpenFrmSanPham";
            this.btnOpenFrmSanPham.Size = new System.Drawing.Size(32, 27);
            this.btnOpenFrmSanPham.TabIndex = 76;
            this.btnOpenFrmSanPham.UseVisualStyleBackColor = true;
            // 
            // frmDonViQuanLy
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 513);
            this.Controls.Add(this.btnOpenFrmSanPham);
            this.Controls.Add(this.btnXoaCongDoan);
            this.Controls.Add(this.btnSuaCongDoan);
            this.Controls.Add(this.btnThemCongDoan);
            this.Controls.Add(this.cboMaLoai);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtTenBoPhan);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmDonViQuanLy";
            this.Text = "frmDonViQuanLy";
            this.Load += new System.EventHandler(this.frmDonViQuanLy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDonVi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLoaiNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFrmSanPham;
        private System.Windows.Forms.Button btnXoaCongDoan;
        private System.Windows.Forms.Button btnSuaCongDoan;
        private System.Windows.Forms.Button btnThemCongDoan;
        private System.Windows.Forms.ComboBox cboMaLoai;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TextBox txtTenBoPhan;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTipOpenFrmModel;
        private System.Windows.Forms.DataGridView dtgvDonVi;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvLoaiNhanVien;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn maModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn maCongDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenCongDoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn maModel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSanPham;
    }
}