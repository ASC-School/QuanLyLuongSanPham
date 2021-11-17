
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
            this.lblTenNV = new DevExpress.XtraEditors.LabelControl();
            this.lblDonVi = new DevExpress.XtraEditors.LabelControl();
            this.lblNgayBatDau = new DevExpress.XtraEditors.LabelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboDonVi = new System.Windows.Forms.ComboBox();
            this.cboTenNhanVien = new System.Windows.Forms.ComboBox();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(880, 9);
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
            this.panelControl1.Size = new System.Drawing.Size(925, 52);
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
            this.labelControl1.Location = new System.Drawing.Point(303, 13);
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
            this.lblMaNV.Location = new System.Drawing.Point(95, 80);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(113, 21);
            this.lblMaNV.TabIndex = 24;
            this.lblMaNV.Text = "Mã Nhân Viên :";
            // 
            // lblTenNV
            // 
            this.lblTenNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Appearance.Options.UseFont = true;
            this.lblTenNV.Location = new System.Drawing.Point(86, 124);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(119, 21);
            this.lblTenNV.TabIndex = 24;
            this.lblTenNV.Text = "Tên Nhân Viên :";
            // 
            // lblDonVi
            // 
            this.lblDonVi.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonVi.Appearance.Options.UseFont = true;
            this.lblDonVi.Location = new System.Drawing.Point(147, 165);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(58, 21);
            this.lblDonVi.TabIndex = 24;
            this.lblDonVi.Text = "Đơn vị :";
            // 
            // lblNgayBatDau
            // 
            this.lblNgayBatDau.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBatDau.Appearance.Options.UseFont = true;
            this.lblNgayBatDau.Location = new System.Drawing.Point(95, 207);
            this.lblNgayBatDau.Name = "lblNgayBatDau";
            this.lblNgayBatDau.Size = new System.Drawing.Size(110, 21);
            this.lblNgayBatDau.TabIndex = 24;
            this.lblNgayBatDau.Text = "Ngày bắt đầu :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(702, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 46);
            this.button1.TabIndex = 27;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(702, 166);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 46);
            this.button2.TabIndex = 27;
            this.button2.Text = "Làm mới";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 255);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(907, 184);
            this.dataGridView1.TabIndex = 28;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd,MM,yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(223, 206);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(348, 22);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // cboDonVi
            // 
            this.cboDonVi.FormattingEnabled = true;
            this.cboDonVi.Items.AddRange(new object[] {
            "Tất cả phòng ban"});
            this.cboDonVi.Location = new System.Drawing.Point(223, 166);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Size = new System.Drawing.Size(348, 24);
            this.cboDonVi.TabIndex = 30;
            this.cboDonVi.Text = "Tất cả phòng ban";
            // 
            // cboTenNhanVien
            // 
            this.cboTenNhanVien.FormattingEnabled = true;
            this.cboTenNhanVien.Items.AddRange(new object[] {
            "Tất cả nhân viên"});
            this.cboTenNhanVien.Location = new System.Drawing.Point(223, 125);
            this.cboTenNhanVien.Name = "cboTenNhanVien";
            this.cboTenNhanVien.Size = new System.Drawing.Size(348, 24);
            this.cboTenNhanVien.TabIndex = 31;
            this.cboTenNhanVien.Text = "Tất cả nhân viên";
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(223, 81);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(348, 24);
            this.cboMaNhanVien.TabIndex = 32;
            this.cboMaNhanVien.Text = "Mã nhân viên";
            // 
            // frmTimKiemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(925, 447);
            this.Controls.Add(this.cboMaNhanVien);
            this.Controls.Add(this.cboTenNhanVien);
            this.Controls.Add(this.cboDonVi);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblNgayBatDau);
            this.Controls.Add(this.lblDonVi);
            this.Controls.Add(this.lblTenNV);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.LabelControl lblTenNV;
        private DevExpress.XtraEditors.LabelControl lblDonVi;
        private DevExpress.XtraEditors.LabelControl lblNgayBatDau;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboDonVi;
        private System.Windows.Forms.ComboBox cboTenNhanVien;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
    }
}