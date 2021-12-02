
namespace QuanLyLuongSanPham_GUI
{
    partial class frmHoTro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHoTro));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.btnTaiLieu = new DevExpress.XtraEditors.SimpleButton();
            this.btnCauHoi = new DevExpress.XtraEditors.SimpleButton();
            this.nativeMdiView1 = new DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeMdiView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.btnCauHoi);
            this.panelControl1.Controls.Add(this.btnTaiLieu);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(200, 471);
            this.panelControl1.TabIndex = 0;
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.View = this.nativeMdiView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.nativeMdiView1});
            // 
            // btnTaiLieu
            // 
            this.btnTaiLieu.Appearance.BackColor = System.Drawing.Color.Crimson;
            this.btnTaiLieu.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnTaiLieu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiLieu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTaiLieu.Appearance.Options.UseBackColor = true;
            this.btnTaiLieu.Appearance.Options.UseBorderColor = true;
            this.btnTaiLieu.Appearance.Options.UseFont = true;
            this.btnTaiLieu.Appearance.Options.UseForeColor = true;
            this.btnTaiLieu.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTaiLieu.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTaiLieu.AppearancePressed.Options.UseBackColor = true;
            this.btnTaiLieu.AppearancePressed.Options.UseFont = true;
            this.btnTaiLieu.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnTaiLieu.Location = new System.Drawing.Point(0, 67);
            this.btnTaiLieu.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnTaiLieu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTaiLieu.Name = "btnTaiLieu";
            this.btnTaiLieu.Size = new System.Drawing.Size(200, 54);
            this.btnTaiLieu.TabIndex = 2;
            this.btnTaiLieu.Text = "Tài liệu hướng dẫn";
            this.btnTaiLieu.Click += new System.EventHandler(this.btnTaiLieu_Click);
            // 
            // btnCauHoi
            // 
            this.btnCauHoi.Appearance.BackColor = System.Drawing.Color.Crimson;
            this.btnCauHoi.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnCauHoi.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCauHoi.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCauHoi.Appearance.Options.UseBackColor = true;
            this.btnCauHoi.Appearance.Options.UseBorderColor = true;
            this.btnCauHoi.Appearance.Options.UseFont = true;
            this.btnCauHoi.Appearance.Options.UseForeColor = true;
            this.btnCauHoi.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCauHoi.AppearancePressed.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCauHoi.AppearancePressed.Options.UseBackColor = true;
            this.btnCauHoi.AppearancePressed.Options.UseFont = true;
            this.btnCauHoi.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.btnCauHoi.Location = new System.Drawing.Point(0, 127);
            this.btnCauHoi.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnCauHoi.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCauHoi.Name = "btnCauHoi";
            this.btnCauHoi.Size = new System.Drawing.Size(200, 54);
            this.btnCauHoi.TabIndex = 2;
            this.btnCauHoi.Text = "Câu hỏi thường gặp";
            // 
            // frmHoTro
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 471);
            this.Controls.Add(this.panelControl1);
            this.IsMdiContainer = true;
            this.Name = "frmHoTro";
            this.Text = "Giao Diện Hỗ Trợ";
            this.Load += new System.EventHandler(this.frmHoTro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nativeMdiView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCauHoi;
        private DevExpress.XtraEditors.SimpleButton btnTaiLieu;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.NativeMdi.NativeMdiView nativeMdiView1;
    }
}