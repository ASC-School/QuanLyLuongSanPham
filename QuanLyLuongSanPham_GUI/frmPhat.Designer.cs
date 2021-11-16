
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaNV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDonVi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMucPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTienPhat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridUngLuong = new DevExpress.XtraGrid.GridControl();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.txtDonVi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNV = new DevExpress.XtraEditors.LabelControl();
            this.lblTTDonVi = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.timeSpanChartRangeControlClient1 = new DevExpress.XtraEditors.TimeSpanChartRangeControlClient();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbbDonVi = new System.Windows.Forms.ComboBox();
            this.lblDonVi = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnXem = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.cbTheoNgay = new System.Windows.Forms.CheckBox();
            this.cbTatCa = new System.Windows.Forms.CheckBox();
            this.lblTheoNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblTatCa = new DevExpress.XtraEditors.LabelControl();
            this.lblXem = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUngLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanChartRangeControlClient1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.GroupPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colMaNV,
            this.colDonVi,
            this.colNgayPhat,
            this.colMucPhat,
            this.colTienPhat});
            this.gridView1.GridControl = this.gridUngLuong;
            this.gridView1.GroupPanelText = "DANH SÁCH NHÂN VIÊN BỊ PHẠT";
            this.gridView1.Name = "gridView1";
            // 
            // colSTT
            // 
            this.colSTT.Caption = "STT";
            this.colSTT.MinWidth = 25;
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 1;
            this.colSTT.Width = 94;
            // 
            // colMaNV
            // 
            this.colMaNV.Caption = "Mã NV";
            this.colMaNV.MinWidth = 25;
            this.colMaNV.Name = "colMaNV";
            this.colMaNV.Visible = true;
            this.colMaNV.VisibleIndex = 0;
            this.colMaNV.Width = 94;
            // 
            // colDonVi
            // 
            this.colDonVi.Caption = "Đơn Vị";
            this.colDonVi.MinWidth = 25;
            this.colDonVi.Name = "colDonVi";
            this.colDonVi.Visible = true;
            this.colDonVi.VisibleIndex = 2;
            this.colDonVi.Width = 94;
            // 
            // colNgayPhat
            // 
            this.colNgayPhat.Caption = "Ngày Phạt";
            this.colNgayPhat.MinWidth = 25;
            this.colNgayPhat.Name = "colNgayPhat";
            this.colNgayPhat.Visible = true;
            this.colNgayPhat.VisibleIndex = 3;
            this.colNgayPhat.Width = 94;
            // 
            // colMucPhat
            // 
            this.colMucPhat.Caption = "Mức Phạt";
            this.colMucPhat.MinWidth = 25;
            this.colMucPhat.Name = "colMucPhat";
            this.colMucPhat.Visible = true;
            this.colMucPhat.VisibleIndex = 4;
            this.colMucPhat.Width = 94;
            // 
            // colTienPhat
            // 
            this.colTienPhat.Caption = "Tiền Phạt";
            this.colTienPhat.MinWidth = 25;
            this.colTienPhat.Name = "colTienPhat";
            this.colTienPhat.Visible = true;
            this.colTienPhat.VisibleIndex = 5;
            this.colTienPhat.Width = 94;
            // 
            // gridUngLuong
            // 
            this.gridUngLuong.Location = new System.Drawing.Point(17, 127);
            this.gridUngLuong.MainView = this.gridView1;
            this.gridUngLuong.Name = "gridUngLuong";
            this.gridUngLuong.Size = new System.Drawing.Size(874, 497);
            this.gridUngLuong.TabIndex = 7;
            this.gridUngLuong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(114, 235);
            this.textEdit3.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit3.Properties.Appearance.Options.UseFont = true;
            this.textEdit3.Size = new System.Drawing.Size(304, 30);
            this.textEdit3.TabIndex = 2;
            // 
            // textEdit2
            // 
            this.textEdit2.Location = new System.Drawing.Point(114, 189);
            this.textEdit2.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit2.Properties.Appearance.Options.UseFont = true;
            this.textEdit2.Size = new System.Drawing.Size(304, 30);
            this.textEdit2.TabIndex = 2;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(114, 142);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit1.Properties.Appearance.Options.UseFont = true;
            this.textEdit1.Size = new System.Drawing.Size(304, 30);
            this.textEdit1.TabIndex = 2;
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(114, 39);
            this.txtDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonVi.Properties.Appearance.Options.UseFont = true;
            this.txtDonVi.Size = new System.Drawing.Size(304, 30);
            this.txtDonVi.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(7, 193);
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
            this.lblMaNV.Location = new System.Drawing.Point(29, 146);
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
            this.lblTTDonVi.Location = new System.Drawing.Point(29, 43);
            this.lblTTDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.lblTTDonVi.Name = "lblTTDonVi";
            this.lblTTDonVi.Size = new System.Drawing.Size(58, 21);
            this.lblTTDonVi.TabIndex = 1;
            this.lblTTDonVi.Text = "Đơn vị :";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnXoa);
            this.panelControl2.Controls.Add(this.btnLuu);
            this.panelControl2.Controls.Add(this.btnThem);
            this.panelControl2.Controls.Add(this.textEdit3);
            this.panelControl2.Controls.Add(this.textEdit2);
            this.panelControl2.Controls.Add(this.textEdit1);
            this.panelControl2.Controls.Add(this.textEdit4);
            this.panelControl2.Controls.Add(this.txtDonVi);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.labelControl6);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.lblMaNV);
            this.panelControl2.Controls.Add(this.lblTTDonVi);
            this.panelControl2.Location = new System.Drawing.Point(897, 187);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(440, 385);
            this.panelControl2.TabIndex = 8;
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(123)))), ((int)(((byte)(137)))));
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.Options.UseBackColor = true;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.Location = new System.Drawing.Point(307, 304);
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
            this.btnLuu.Location = new System.Drawing.Point(168, 304);
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
            this.btnThem.Location = new System.Drawing.Point(24, 304);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(104, 40);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            // 
            // textEdit4
            // 
            this.textEdit4.Location = new System.Drawing.Point(114, 92);
            this.textEdit4.Margin = new System.Windows.Forms.Padding(4);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEdit4.Properties.Appearance.Options.UseFont = true;
            this.textEdit4.Size = new System.Drawing.Size(304, 30);
            this.textEdit4.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Location = new System.Drawing.Point(8, 239);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(85, 21);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Mức phạt  :";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(28, 96);
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
            this.labelControl1.Location = new System.Drawing.Point(81, 17);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(221, 29);
            this.labelControl1.TabIndex = 34;
            this.labelControl1.Text = "MỨC TIỀN LƯƠNG";
            // 
            // cbbDonVi
            // 
            this.cbbDonVi.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDonVi.FormattingEnabled = true;
            this.cbbDonVi.Location = new System.Drawing.Point(325, 31);
            this.cbbDonVi.Name = "cbbDonVi";
            this.cbbDonVi.Size = new System.Drawing.Size(419, 29);
            this.cbbDonVi.TabIndex = 3;
            // 
            // lblDonVi
            // 
            this.lblDonVi.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonVi.Appearance.Options.UseFont = true;
            this.lblDonVi.Location = new System.Drawing.Point(231, 31);
            this.lblDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(58, 21);
            this.lblDonVi.TabIndex = 1;
            this.lblDonVi.Text = "Đơn vị :";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.btnXem);
            this.panelControl1.Controls.Add(this.date);
            this.panelControl1.Controls.Add(this.cbTheoNgay);
            this.panelControl1.Controls.Add(this.cbTatCa);
            this.panelControl1.Controls.Add(this.lblTheoNgay);
            this.panelControl1.Controls.Add(this.lblTatCa);
            this.panelControl1.Controls.Add(this.lblXem);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.gridUngLuong);
            this.panelControl1.Controls.Add(this.cbbDonVi);
            this.panelControl1.Controls.Add(this.lblDonVi);
            this.panelControl1.Location = new System.Drawing.Point(13, 50);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1343, 641);
            this.panelControl1.TabIndex = 32;
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(806, 73);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(85, 27);
            this.btnXem.TabIndex = 15;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            // 
            // date
            // 
            this.date.CustomFormat = "dd-MM-yyyy";
            this.date.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(567, 70);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(177, 28);
            this.date.TabIndex = 14;
            this.date.Value = new System.DateTime(2021, 11, 16, 0, 0, 0, 0);
            // 
            // cbTheoNgay
            // 
            this.cbTheoNgay.AutoSize = true;
            this.cbTheoNgay.Location = new System.Drawing.Point(444, 80);
            this.cbTheoNgay.Name = "cbTheoNgay";
            this.cbTheoNgay.Size = new System.Drawing.Size(18, 17);
            this.cbTheoNgay.TabIndex = 12;
            this.cbTheoNgay.UseVisualStyleBackColor = true;
            // 
            // cbTatCa
            // 
            this.cbTatCa.AutoSize = true;
            this.cbTatCa.Location = new System.Drawing.Point(323, 80);
            this.cbTatCa.Name = "cbTatCa";
            this.cbTatCa.Size = new System.Drawing.Size(18, 17);
            this.cbTatCa.TabIndex = 13;
            this.cbTatCa.UseVisualStyleBackColor = true;
            // 
            // lblTheoNgay
            // 
            this.lblTheoNgay.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheoNgay.Appearance.Options.UseFont = true;
            this.lblTheoNgay.Location = new System.Drawing.Point(469, 76);
            this.lblTheoNgay.Margin = new System.Windows.Forms.Padding(4);
            this.lblTheoNgay.Name = "lblTheoNgay";
            this.lblTheoNgay.Size = new System.Drawing.Size(77, 21);
            this.lblTheoNgay.TabIndex = 9;
            this.lblTheoNgay.Text = "Theo ngày";
            // 
            // lblTatCa
            // 
            this.lblTatCa.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTatCa.Appearance.Options.UseFont = true;
            this.lblTatCa.Location = new System.Drawing.Point(348, 76);
            this.lblTatCa.Margin = new System.Windows.Forms.Padding(4);
            this.lblTatCa.Name = "lblTatCa";
            this.lblTatCa.Size = new System.Drawing.Size(47, 21);
            this.lblTatCa.TabIndex = 10;
            this.lblTatCa.Text = "Tất cả";
            // 
            // lblXem
            // 
            this.lblXem.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXem.Appearance.Options.UseFont = true;
            this.lblXem.Location = new System.Drawing.Point(245, 76);
            this.lblXem.Margin = new System.Windows.Forms.Padding(4);
            this.lblXem.Name = "lblXem";
            this.lblXem.Size = new System.Drawing.Size(44, 21);
            this.lblXem.TabIndex = 11;
            this.lblXem.Text = "Xem :";
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(1325, 4);
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
            this.pictureBox2.Location = new System.Drawing.Point(13, 4);
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
            this.ClientSize = new System.Drawing.Size(1368, 726);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridUngLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSpanChartRangeControlClient1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraGrid.Columns.GridColumn colTienPhat;
        private DevExpress.XtraGrid.Columns.GridColumn colMucPhat;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayPhat;
        private DevExpress.XtraGrid.Columns.GridColumn colDonVi;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridUngLuong;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit txtDonVi;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.LabelControl lblTTDonVi;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.TimeSpanChartRangeControlClient timeSpanChartRangeControlClient1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cbbDonVi;
        private DevExpress.XtraEditors.LabelControl lblDonVi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.CheckBox cbTheoNgay;
        private System.Windows.Forms.CheckBox cbTatCa;
        private DevExpress.XtraEditors.LabelControl lblTheoNgay;
        private DevExpress.XtraEditors.LabelControl lblTatCa;
        private DevExpress.XtraEditors.LabelControl lblXem;
        private System.Windows.Forms.Button btnXem;
        private DevExpress.XtraGrid.Columns.GridColumn colMaNV;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}