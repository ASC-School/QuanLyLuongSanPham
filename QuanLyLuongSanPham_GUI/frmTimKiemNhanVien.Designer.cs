
namespace QuanLyLuongSanPham_GUI
{
    partial class frmTimKiemNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimKiemNhanVien));
            this.btnThoat = new System.Windows.Forms.Button();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblMaNV = new DevExpress.XtraEditors.LabelControl();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.lblTenNV = new DevExpress.XtraEditors.LabelControl();
            this.txtTenNV = new DevExpress.XtraEditors.TextEdit();
            this.lblDonVi = new DevExpress.XtraEditors.LabelControl();
            this.txtDonVi = new DevExpress.XtraEditors.TextEdit();
            this.lblNgayBatDau = new DevExpress.XtraEditors.LabelControl();
            this.txtNgayBatDau = new DevExpress.XtraEditors.TextEdit();
            this.cbMaNV = new DevExpress.XtraEditors.CheckEdit();
            this.cbTenNV = new DevExpress.XtraEditors.CheckEdit();
            this.cbDonVi = new DevExpress.XtraEditors.CheckEdit();
            this.cbNgayBatDau = new DevExpress.XtraEditors.CheckEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTenNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNgayBatDau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(614, 7);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(38, 33);
            this.btnThoat.TabIndex = 22;
            this.btnThoat.Text = "          ";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnThoat);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinMaskColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.TouchUIMode = DevExpress.Utils.DefaultBoolean.False;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(659, 52);
            this.panelControl1.TabIndex = 23;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DarkRed;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(204, 13);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(268, 29);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "TÌM KIẾM NHÂN VIÊN";
            // 
            // lblMaNV
            // 
            this.lblMaNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Appearance.Options.UseFont = true;
            this.lblMaNV.Location = new System.Drawing.Point(92, 102);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(113, 21);
            this.lblMaNV.TabIndex = 24;
            this.lblMaNV.Text = "Mã Nhân Viên :";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(223, 99);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtMaNV.Properties.Appearance.Options.UseBackColor = true;
            this.txtMaNV.Size = new System.Drawing.Size(206, 22);
            this.txtMaNV.TabIndex = 25;
            // 
            // lblTenNV
            // 
            this.lblTenNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Appearance.Options.UseFont = true;
            this.lblTenNV.Location = new System.Drawing.Point(86, 140);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(119, 21);
            this.lblTenNV.TabIndex = 24;
            this.lblTenNV.Text = "Tên Nhân Viên :";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(223, 141);
            this.txtTenNV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtTenNV.Properties.Appearance.Options.UseBackColor = true;
            this.txtTenNV.Size = new System.Drawing.Size(206, 22);
            this.txtTenNV.TabIndex = 25;
            // 
            // lblDonVi
            // 
            this.lblDonVi.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonVi.Appearance.Options.UseFont = true;
            this.lblDonVi.Location = new System.Drawing.Point(147, 184);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(58, 21);
            this.lblDonVi.TabIndex = 24;
            this.lblDonVi.Text = "Đơn vị :";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(223, 185);
            this.txtDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtDonVi.Properties.Appearance.Options.UseBackColor = true;
            this.txtDonVi.Size = new System.Drawing.Size(206, 22);
            this.txtDonVi.TabIndex = 25;
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Appearance.Options.UseFont = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(95, 231);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(110, 21);
            this.lblNgayBatDau.TabIndex = 24;
            this.lblNgayBatDau.Text = "Ngày bắt đầu :";
            // 
            // txtNgayBatDau
            // 
            this.txtNgayBatDau.Location = new System.Drawing.Point(223, 232);
            this.txtNgayBatDau.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgayBatDau.Name = "txtNgayBatDau";
            this.txtNgayBatDau.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtNgayBatDau.Properties.Appearance.Options.UseBackColor = true;
            this.txtNgayBatDau.Size = new System.Drawing.Size(206, 22);
            this.txtNgayBatDau.TabIndex = 25;
            // 
            // cbMaNV
            // 
            this.cbMaNV.Location = new System.Drawing.Point(509, 102);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Properties.Caption = "";
            this.cbMaNV.Size = new System.Drawing.Size(20, 19);
            this.cbMaNV.TabIndex = 26;
            // 
            // cbTenNV
            // 
            this.cbTenNV.Location = new System.Drawing.Point(509, 144);
            this.cbTenNV.Name = "cbTenNV";
            this.cbTenNV.Properties.Caption = "";
            this.cbTenNV.Size = new System.Drawing.Size(20, 19);
            this.cbTenNV.TabIndex = 26;
            // 
            // cbDonVi
            // 
            this.cbDonVi.Location = new System.Drawing.Point(509, 188);
            this.cbDonVi.Name = "cbDonVi";
            this.cbDonVi.Properties.Caption = "";
            this.cbDonVi.Size = new System.Drawing.Size(20, 19);
            this.cbDonVi.TabIndex = 26;
            this.cbDonVi.CheckedChanged += new System.EventHandler(this.cbDonVi_CheckedChanged);
            // 
            // cbNgayBatDau
            // 
            this.cbNgayBatDau.Location = new System.Drawing.Point(509, 235);
            this.cbNgayBatDau.Name = "cbNgayBatDau";
            this.cbNgayBatDau.Properties.Caption = "";
            this.cbNgayBatDau.Size = new System.Drawing.Size(20, 19);
            this.cbNgayBatDau.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(473, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 33);
            this.button1.TabIndex = 27;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(473, 319);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 33);
            this.button2.TabIndex = 27;
            this.button2.Text = "Làm mới";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmTimKiemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(659, 364);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cbNgayBatDau);
            this.Controls.Add(this.cbDonVi);
            this.Controls.Add(this.cbTenNV);
            this.Controls.Add(this.cbMaNV);
            this.Controls.Add(this.txtNgayBatDau);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.txtDonVi);
            this.Controls.Add(this.lblDonVi);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.lblTenNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimKiemNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimKiemNhanVien";
            this.Load += new System.EventHandler(this.FrmTimKiemNhanVien_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmTimKiemNhanVien_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmTimKiemNhanVien_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgayBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTenNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbNgayBatDau.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.TextEdit txtMaNV;
        private DevExpress.XtraEditors.LabelControl lblTenNV;
        private DevExpress.XtraEditors.TextEdit txtTenNV;
        private DevExpress.XtraEditors.LabelControl lblDonVi;
        private DevExpress.XtraEditors.TextEdit txtDonVi;
        private DevExpress.XtraEditors.LabelControl lblNgayBatDau;
        private DevExpress.XtraEditors.TextEdit txtNgayBatDau;
        private DevExpress.XtraEditors.CheckEdit cbMaNV;
        private DevExpress.XtraEditors.CheckEdit cbTenNV;
        private DevExpress.XtraEditors.CheckEdit cbDonVi;
        private DevExpress.XtraEditors.CheckEdit cbNgayBatDau;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}