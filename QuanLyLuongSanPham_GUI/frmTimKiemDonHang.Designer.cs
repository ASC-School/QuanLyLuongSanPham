
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
            this.imgNho = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.cboMaNhanVien = new System.Windows.Forms.ComboBox();
            this.cboMaDonHang = new System.Windows.Forms.ComboBox();
            this.btnCapNhatDonHang = new System.Windows.Forms.Button();
            this.btnTimKimDonHang = new System.Windows.Forms.Button();
            this.lvwDonHang = new System.Windows.Forms.ListView();
            this.txtSoDienThoaiKhachHang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenKhachHang = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboNgayBatDau = new System.Windows.Forms.ComboBox();
            this.cboNgayKetThuc = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // imgNho
            // 
            this.imgNho.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgNho.ImageSize = new System.Drawing.Size(16, 16);
            this.imgNho.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboSanPham);
            this.panel2.Controls.Add(this.cboMaNhanVien);
            this.panel2.Controls.Add(this.cboNgayKetThuc);
            this.panel2.Controls.Add(this.cboNgayBatDau);
            this.panel2.Controls.Add(this.cboMaDonHang);
            this.panel2.Controls.Add(this.btnCapNhatDonHang);
            this.panel2.Controls.Add(this.btnTimKimDonHang);
            this.panel2.Controls.Add(this.lvwDonHang);
            this.panel2.Controls.Add(this.txtSoDienThoaiKhachHang);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTenKhachHang);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtTenNhanVien);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 394);
            this.panel2.TabIndex = 3;
            // 
            // cboSanPham
            // 
            this.cboSanPham.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(752, 119);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(274, 31);
            this.cboSanPham.TabIndex = 4;
            // 
            // cboMaNhanVien
            // 
            this.cboMaNhanVien.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboMaNhanVien.FormattingEnabled = true;
            this.cboMaNhanVien.Location = new System.Drawing.Point(265, 13);
            this.cboMaNhanVien.Name = "cboMaNhanVien";
            this.cboMaNhanVien.Size = new System.Drawing.Size(278, 31);
            this.cboMaNhanVien.TabIndex = 4;
            // 
            // cboMaDonHang
            // 
            this.cboMaDonHang.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboMaDonHang.FormattingEnabled = true;
            this.cboMaDonHang.Location = new System.Drawing.Point(752, 9);
            this.cboMaDonHang.Name = "cboMaDonHang";
            this.cboMaDonHang.Size = new System.Drawing.Size(274, 31);
            this.cboMaDonHang.TabIndex = 4;
            // 
            // btnCapNhatDonHang
            // 
            this.btnCapNhatDonHang.BackColor = System.Drawing.Color.Crimson;
            this.btnCapNhatDonHang.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnCapNhatDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatDonHang.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCapNhatDonHang.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatDonHang.Location = new System.Drawing.Point(27, 328);
            this.btnCapNhatDonHang.Name = "btnCapNhatDonHang";
            this.btnCapNhatDonHang.Size = new System.Drawing.Size(115, 33);
            this.btnCapNhatDonHang.TabIndex = 3;
            this.btnCapNhatDonHang.Text = "Cập nhật";
            this.btnCapNhatDonHang.UseVisualStyleBackColor = false;
            // 
            // btnTimKimDonHang
            // 
            this.btnTimKimDonHang.BackColor = System.Drawing.Color.Crimson;
            this.btnTimKimDonHang.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnTimKimDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKimDonHang.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimKimDonHang.ForeColor = System.Drawing.Color.White;
            this.btnTimKimDonHang.Location = new System.Drawing.Point(911, 328);
            this.btnTimKimDonHang.Name = "btnTimKimDonHang";
            this.btnTimKimDonHang.Size = new System.Drawing.Size(115, 33);
            this.btnTimKimDonHang.TabIndex = 3;
            this.btnTimKimDonHang.Text = "Tìm kiếm";
            this.btnTimKimDonHang.UseVisualStyleBackColor = false;
            // 
            // lvwDonHang
            // 
            this.lvwDonHang.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lvwDonHang.HideSelection = false;
            this.lvwDonHang.Location = new System.Drawing.Point(27, 182);
            this.lvwDonHang.Name = "lvwDonHang";
            this.lvwDonHang.Size = new System.Drawing.Size(999, 131);
            this.lvwDonHang.TabIndex = 2;
            this.lvwDonHang.UseCompatibleStateImageBehavior = false;
            // 
            // txtSoDienThoaiKhachHang
            // 
            this.txtSoDienThoaiKhachHang.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtSoDienThoaiKhachHang.Location = new System.Drawing.Point(265, 122);
            this.txtSoDienThoaiKhachHang.Name = "txtSoDienThoaiKhachHang";
            this.txtSoDienThoaiKhachHang.Size = new System.Drawing.Size(278, 30);
            this.txtSoDienThoaiKhachHang.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(565, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 23);
            this.label9.TabIndex = 0;
            this.label9.Text = "Sản phẩm:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số điện thoại khách hàng:";
            // 
            // txtTenKhachHang
            // 
            this.txtTenKhachHang.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenKhachHang.Location = new System.Drawing.Point(265, 86);
            this.txtTenKhachHang.Name = "txtTenKhachHang";
            this.txtTenKhachHang.Size = new System.Drawing.Size(278, 30);
            this.txtTenKhachHang.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(565, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ngày kết thúc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(23, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tên khách hàng:";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTenNhanVien.Location = new System.Drawing.Point(265, 50);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(278, 30);
            this.txtTenNhanVien.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(565, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày bắt đầu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên nhân viên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(565, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã đơn hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(23, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã nhân viên:";
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
            // cboNgayBatDau
            // 
            this.cboNgayBatDau.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboNgayBatDau.FormattingEnabled = true;
            this.cboNgayBatDau.Location = new System.Drawing.Point(752, 47);
            this.cboNgayBatDau.Name = "cboNgayBatDau";
            this.cboNgayBatDau.Size = new System.Drawing.Size(274, 31);
            this.cboNgayBatDau.TabIndex = 4;
            // 
            // cboNgayKetThuc
            // 
            this.cboNgayKetThuc.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboNgayKetThuc.FormattingEnabled = true;
            this.cboNgayKetThuc.Location = new System.Drawing.Point(752, 82);
            this.cboNgayKetThuc.Name = "cboNgayKetThuc";
            this.cboNgayKetThuc.Size = new System.Drawing.Size(274, 31);
            this.cboNgayKetThuc.TabIndex = 4;
            // 
            // frmTimKiemDonHang
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.IconOptions.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmTimKiemDonHang";
            this.Text = "Tìm Kiếm Đơn Hàng";
            this.Load += new System.EventHandler(this.frmTimKiemDonHang_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imgNho;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSoDienThoaiKhachHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenKhachHang;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.ComboBox cboMaNhanVien;
        private System.Windows.Forms.ComboBox cboMaDonHang;
        private System.Windows.Forms.Button btnCapNhatDonHang;
        private System.Windows.Forms.Button btnTimKimDonHang;
        private System.Windows.Forms.ListView lvwDonHang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboNgayKetThuc;
        private System.Windows.Forms.ComboBox cboNgayBatDau;
    }
}