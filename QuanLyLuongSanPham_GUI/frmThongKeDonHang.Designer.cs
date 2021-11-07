
namespace QuanLyLuongSanPham_GUI
{
    partial class frmThongKeDonHang
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cboThongKeDonGia = new System.Windows.Forms.ComboBox();
            this.lvwThongKeDonHang = new System.Windows.Forms.ListView();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnInDonHang = new System.Windows.Forms.Button();
            this.btnLocDonHang = new System.Windows.Forms.Button();
            this.dateNgayKetThuc = new DevExpress.XtraEditors.DateEdit();
            this.dateNgayBatDau = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imgLon = new System.Windows.Forms.ImageList(this.components);
            this.imgNho = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panel1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1024, 601);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(27, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 46);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(72, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ ĐƠN HÀNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.cboThongKeDonGia);
            this.panelControl2.Controls.Add(this.lvwThongKeDonHang);
            this.panelControl2.Controls.Add(this.btnDong);
            this.panelControl2.Controls.Add(this.btnInDonHang);
            this.panelControl2.Controls.Add(this.btnLocDonHang);
            this.panelControl2.Controls.Add(this.dateNgayKetThuc);
            this.panelControl2.Controls.Add(this.dateNgayBatDau);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.label4);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.FireScrollEventOnMouseWheel = true;
            this.panelControl2.Location = new System.Drawing.Point(27, 71);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(973, 520);
            this.panelControl2.TabIndex = 0;
            // 
            // cboThongKeDonGia
            // 
            this.cboThongKeDonGia.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboThongKeDonGia.FormattingEnabled = true;
            this.cboThongKeDonGia.Location = new System.Drawing.Point(266, 87);
            this.cboThongKeDonGia.Name = "cboThongKeDonGia";
            this.cboThongKeDonGia.Size = new System.Drawing.Size(219, 33);
            this.cboThongKeDonGia.TabIndex = 5;
            // 
            // lvwThongKeDonHang
            // 
            this.lvwThongKeDonHang.HideSelection = false;
            this.lvwThongKeDonHang.Location = new System.Drawing.Point(19, 158);
            this.lvwThongKeDonHang.Name = "lvwThongKeDonHang";
            this.lvwThongKeDonHang.Size = new System.Drawing.Size(933, 268);
            this.lvwThongKeDonHang.TabIndex = 4;
            this.lvwThongKeDonHang.UseCompatibleStateImageBehavior = false;
            // 
            // btnDong
            // 
            this.btnDong.AutoSize = true;
            this.btnDong.BackColor = System.Drawing.Color.Crimson;
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(20, 454);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(230, 47);
            this.btnDong.TabIndex = 3;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnInDonHang
            // 
            this.btnInDonHang.BackColor = System.Drawing.Color.Crimson;
            this.btnInDonHang.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnInDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInDonHang.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnInDonHang.ForeColor = System.Drawing.Color.White;
            this.btnInDonHang.Location = new System.Drawing.Point(722, 454);
            this.btnInDonHang.Name = "btnInDonHang";
            this.btnInDonHang.Size = new System.Drawing.Size(230, 47);
            this.btnInDonHang.TabIndex = 3;
            this.btnInDonHang.Text = "In";
            this.btnInDonHang.UseVisualStyleBackColor = false;
            // 
            // btnLocDonHang
            // 
            this.btnLocDonHang.BackColor = System.Drawing.Color.Crimson;
            this.btnLocDonHang.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnLocDonHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocDonHang.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLocDonHang.ForeColor = System.Drawing.Color.White;
            this.btnLocDonHang.Location = new System.Drawing.Point(716, 79);
            this.btnLocDonHang.Name = "btnLocDonHang";
            this.btnLocDonHang.Size = new System.Drawing.Size(230, 47);
            this.btnLocDonHang.TabIndex = 3;
            this.btnLocDonHang.Text = "Lọc";
            this.btnLocDonHang.UseVisualStyleBackColor = false;
            this.btnLocDonHang.Click += new System.EventHandler(this.btnLocDonHang_Click);
            // 
            // dateNgayKetThuc
            // 
            this.dateNgayKetThuc.EditValue = null;
            this.dateNgayKetThuc.Location = new System.Drawing.Point(716, 22);
            this.dateNgayKetThuc.Name = "dateNgayKetThuc";
            this.dateNgayKetThuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dateNgayKetThuc.Properties.Appearance.Options.UseFont = true;
            this.dateNgayKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKetThuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayKetThuc.Size = new System.Drawing.Size(236, 32);
            this.dateNgayKetThuc.TabIndex = 1;
            // 
            // dateNgayBatDau
            // 
            this.dateNgayBatDau.EditValue = null;
            this.dateNgayBatDau.Location = new System.Drawing.Point(266, 23);
            this.dateNgayBatDau.Name = "dateNgayBatDau";
            this.dateNgayBatDau.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dateNgayBatDau.Properties.Appearance.Options.UseFont = true;
            this.dateNgayBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayBatDau.Size = new System.Drawing.Size(219, 32);
            this.dateNgayBatDau.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày bắt đầu:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(543, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày kết thúc:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(34, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(213, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Đơn giá đơn hàng:";
            // 
            // imgLon
            // 
            this.imgLon.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgLon.ImageSize = new System.Drawing.Size(48, 48);
            this.imgLon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imgNho
            // 
            this.imgNho.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgNho.ImageSize = new System.Drawing.Size(16, 16);
            this.imgNho.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmThongKeDonHang
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1024, 601);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.IconOptions.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmThongKeDonHang";
            this.Text = "Thống kê đơn hàng";
            this.Load += new System.EventHandler(this.frmThongKeDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayBatDau.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListView lvwThongKeDonHang;
        public System.Windows.Forms.Button btnInDonHang;
        public System.Windows.Forms.Button btnLocDonHang;
        public DevExpress.XtraEditors.DateEdit dateNgayKetThuc;
        public DevExpress.XtraEditors.DateEdit dateNgayBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imgLon;
        public System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.ImageList imgNho;
        private System.Windows.Forms.ComboBox cboThongKeDonGia;
    }
}