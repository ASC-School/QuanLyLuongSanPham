
namespace QuanLyLuongSanPham_GUI
{
    partial class frmTimKiemDonHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoDienThoaiKhachHang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lvwTimKiemDonHang = new System.Windows.Forms.ListView();
            this.btnTimKiemDonHang = new System.Windows.Forms.Button();
            this.btnCapNhatDonHang = new System.Windows.Forms.Button();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.cboMaDonHang = new System.Windows.Forms.ComboBox();
            this.dateNgayBatDau = new DevExpress.XtraEditors.DateEdit();
            this.dateNgayKetThuc = new DevExpress.XtraEditors.DateEdit();
            this.imgNho = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(117, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tìm kiếm đơn hàng";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(99, 50);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(99, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(31, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(31, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên nhân viên:";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(294, 110);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(257, 33);
            this.txtTenNhanVien.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên khách hàng:";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Location = new System.Drawing.Point(294, 149);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(257, 33);
            this.txtTenKhachHang.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(31, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "Số điện thoại khách hàng:";
            // 
            // txtSoDienThoaiKhachHang
            // 
            this.txtSoDienThoaiKhachHang.Location = new System.Drawing.Point(294, 188);
            this.txtSoDienThoaiKhachHang.Name = "txtSoDienThoaiKhachHang";
            this.txtSoDienThoaiKhachHang.Size = new System.Drawing.Size(257, 33);
            this.txtSoDienThoaiKhachHang.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(612, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Mã đơn hàng:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(612, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "Ngày bắt đầu:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(612, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(149, 25);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ngày kết thúc:";
            // 
            // lvwTimKiemDonHang
            // 
            this.lvwTimKiemDonHang.HideSelection = false;
            this.lvwTimKiemDonHang.Location = new System.Drawing.Point(27, 243);
            this.lvwTimKiemDonHang.Name = "lvwTimKiemDonHang";
            this.lvwTimKiemDonHang.Size = new System.Drawing.Size(1028, 110);
            this.lvwTimKiemDonHang.TabIndex = 5;
            this.lvwTimKiemDonHang.UseCompatibleStateImageBehavior = false;
            // 
            // btnTimKiemDonHang
            // 
            this.btnTimKiemDonHang.BackColor = System.Drawing.Color.Crimson;
            this.btnTimKiemDonHang.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnTimKiemDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiemDonHang.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemDonHang.Location = new System.Drawing.Point(936, 367);
            this.btnTimKiemDonHang.Name = "btnTimKiemDonHang";
            this.btnTimKiemDonHang.Size = new System.Drawing.Size(119, 38);
            this.btnTimKiemDonHang.TabIndex = 6;
            this.btnTimKiemDonHang.Text = "Tìm kiếm";
            this.btnTimKiemDonHang.UseVisualStyleBackColor = false;
            // 
            // btnCapNhatDonHang
            // 
            this.btnCapNhatDonHang.BackColor = System.Drawing.Color.Crimson;
            this.btnCapNhatDonHang.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnCapNhatDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatDonHang.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatDonHang.Location = new System.Drawing.Point(27, 367);
            this.btnCapNhatDonHang.Name = "btnCapNhatDonHang";
            this.btnCapNhatDonHang.Size = new System.Drawing.Size(119, 38);
            this.btnCapNhatDonHang.TabIndex = 6;
            this.btnCapNhatDonHang.Text = "Cập nhật";
            this.btnCapNhatDonHang.UseVisualStyleBackColor = false;
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(294, 74);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(257, 33);
            this.cboMaNhanVien.TabIndex = 7;
            // 
            // cboMaDonHang
            // 
            this.cboMaDonHang.FormattingEnabled = true;
            this.cboMaDonHang.Location = new System.Drawing.Point(798, 73);
            this.cboMaDonHang.Name = "cboMaDonHang";
            this.cboMaDonHang.Size = new System.Drawing.Size(257, 33);
            this.cboMaDonHang.TabIndex = 8;
            // 
            // dateNgayBatDau
            // 
            this.dateNgayBatDau.EditValue = null;
            this.dateNgayBatDau.Location = new System.Drawing.Point(798, 121);
            this.dateNgayBatDau.Name = "dateNgayBatDau";
            this.dateNgayBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBatDau.Size = new System.Drawing.Size(257, 20);
            this.dateNgayBatDau.TabIndex = 9;
            // 
            // dateNgayKetThuc
            // 
            this.dateNgayKetThuc.EditValue = null;
            this.dateNgayKetThuc.Location = new System.Drawing.Point(798, 162);
            this.dateNgayKetThuc.Name = "dateNgayKetThuc";
            this.dateNgayKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKetThuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKetThuc.Size = new System.Drawing.Size(257, 20);
            this.dateNgayKetThuc.TabIndex = 9;
            // 
            // imgNho
            // 
            this.imgNho.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgNho.ImageSize = new System.Drawing.Size(16, 16);
            this.imgNho.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmTimKiemDonHang
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 423);
            this.Controls.Add(this.dateNgayKetThuc);
            this.Controls.Add(this.dateNgayBatDau);
            this.Controls.Add(this.cboMaDonHang);
            this.Controls.Add(this.cboMaNhanVien);
            this.Controls.Add(this.btnCapNhatDonHang);
            this.Controls.Add(this.btnTimKiemDonHang);
            this.Controls.Add(this.lvwTimKiemDonHang);
            this.Controls.Add(this.txtSoDienThoaiKhachHang);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenKhachHang);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenNhanVien);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.IconOptions.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmTimKiemDonHang";
            this.Text = "Tìm Kiếm Đơn Hàng";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoDienThoaiKhachHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvwTimKiemDonHang;
        private System.Windows.Forms.Button btnTimKiemDonHang;
        private System.Windows.Forms.Button btnCapNhatDonHang;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
        private System.Windows.Forms.ComboBox cboMaDonHang;
        private DevExpress.XtraEditors.DateEdit dateNgayBatDau;
        private DevExpress.XtraEditors.DateEdit dateNgayKetThuc;
        private System.Windows.Forms.ImageList imgNho;
    }
}