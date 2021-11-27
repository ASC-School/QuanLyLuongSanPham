
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
            this.lblMaNV = new DevExpress.XtraEditors.LabelControl();
            this.lblTenNV = new DevExpress.XtraEditors.LabelControl();
            this.lblLoaiNV = new DevExpress.XtraEditors.LabelControl();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtgvDanhSachTimKiem = new System.Windows.Forms.DataGridView();
            this.cboDonVi = new System.Windows.Forms.ComboBox();
            this.cboTenNhanVien = new System.Windows.Forms.ComboBox();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaNV
            // 
            this.lblMaNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaNV.Appearance.Options.UseFont = true;
            this.lblMaNV.Location = new System.Drawing.Point(282, 124);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(113, 21);
            this.lblMaNV.TabIndex = 24;
            this.lblMaNV.Text = "Mã Nhân Viên :";
            // 
            // lblTenNV
            // 
            this.lblTenNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNV.Appearance.Options.UseFont = true;
            this.lblTenNV.Location = new System.Drawing.Point(273, 168);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Size = new System.Drawing.Size(119, 21);
            this.lblTenNV.TabIndex = 24;
            this.lblTenNV.Text = "Tên Nhân Viên :";
            // 
            // lblLoaiNV
            // 
            this.lblLoaiNV.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiNV.Appearance.Options.UseFont = true;
            this.lblLoaiNV.Location = new System.Drawing.Point(280, 210);
            this.lblLoaiNV.Name = "lblLoaiNV";
            this.lblLoaiNV.Size = new System.Drawing.Size(112, 21);
            this.lblLoaiNV.TabIndex = 24;
            this.lblLoaiNV.Text = "Loại nhân viên:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.Crimson;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimKiem.Location = new System.Drawing.Point(846, 124);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(152, 46);
            this.btnTimKiem.TabIndex = 27;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(846, 188);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 46);
            this.button2.TabIndex = 27;
            this.button2.Text = "Làm mới";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtgvDanhSachTimKiem
            // 
            this.dtgvDanhSachTimKiem.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvDanhSachTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDanhSachTimKiem.Location = new System.Drawing.Point(12, 305);
            this.dtgvDanhSachTimKiem.Name = "dtgvDanhSachTimKiem";
            this.dtgvDanhSachTimKiem.RowHeadersWidth = 51;
            this.dtgvDanhSachTimKiem.RowTemplate.Height = 24;
            this.dtgvDanhSachTimKiem.Size = new System.Drawing.Size(1156, 269);
            this.dtgvDanhSachTimKiem.TabIndex = 28;
            // 
            // cboDonVi
            // 
            this.cboDonVi.FormattingEnabled = true;
            this.cboDonVi.Location = new System.Drawing.Point(410, 210);
            this.cboDonVi.Name = "cboDonVi";
            this.cboDonVi.Size = new System.Drawing.Size(348, 24);
            this.cboDonVi.TabIndex = 30;
            // 
            // cboTenNhanVien
            // 
            this.cboTenNhanVien.FormattingEnabled = true;
            this.cboTenNhanVien.Location = new System.Drawing.Point(410, 169);
            this.cboTenNhanVien.Name = "cboTenNhanVien";
            this.cboTenNhanVien.Size = new System.Drawing.Size(348, 24);
            this.cboTenNhanVien.TabIndex = 31;
            this.cboTenNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboTenNhanVien_SelectedIndexChanged);
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(410, 125);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(348, 24);
            this.cboMaNhanVien.TabIndex = 32;
            this.cboMaNhanVien.SelectedIndexChanged += new System.EventHandler(this.cboMaNhanVien_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(68, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1032, 46);
            this.label1.TabIndex = 33;
            this.label1.Text = "TÌM KIẾM NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(1154, 1);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(35, 34);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.Text = "          ";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmTimKiemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.ClientSize = new System.Drawing.Size(1187, 595);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMaNhanVien);
            this.Controls.Add(this.cboTenNhanVien);
            this.Controls.Add(this.cboDonVi);
            this.Controls.Add(this.dtgvDanhSachTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lblLoaiNV);
            this.Controls.Add(this.lblTenNV);
            this.Controls.Add(this.lblMaNV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTimKiemNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTimKiemNhanVien";
            this.Load += new System.EventHandler(this.FrmTimKiemNhanVien_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmTimKiemNhanVien_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmTimKiemNhanVien_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl lblMaNV;
        private DevExpress.XtraEditors.LabelControl lblTenNV;
        private DevExpress.XtraEditors.LabelControl lblLoaiNV;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dtgvDanhSachTimKiem;
        private System.Windows.Forms.ComboBox cboDonVi;
        private System.Windows.Forms.ComboBox cboTenNhanVien;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
    }
}