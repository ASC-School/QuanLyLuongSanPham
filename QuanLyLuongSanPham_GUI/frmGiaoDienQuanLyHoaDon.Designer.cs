
namespace QuanLyLuongSanPham_GUI
{
    partial class frmGiaoDienQuanLyHoaDon
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnQuanLyDonhang = new DevExpress.XtraBars.BarButtonItem();
            this.btnThongKeDonHang = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnQuanLyDonhang,
            this.btnThongKeDonHang});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.OfficeUniversal;
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbon.Size = new System.Drawing.Size(1434, 102);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnQuanLyDonhang
            // 
            this.btnQuanLyDonhang.Caption = "Quản lý đơn hàng";
            this.btnQuanLyDonhang.Id = 1;
            this.btnQuanLyDonhang.ImageOptions.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.User_Interface_Menu_icon;
            this.btnQuanLyDonhang.Name = "btnQuanLyDonhang";
            this.btnQuanLyDonhang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnQuanLyDonhang_ItemClick);
            // 
            // btnThongKeDonHang
            // 
            this.btnThongKeDonHang.Caption = "Thống kê đơn hàng";
            this.btnThongKeDonHang.Id = 2;
            this.btnThongKeDonHang.ImageOptions.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.statistic_icon;
            this.btnThongKeDonHang.Name = "btnThongKeDonHang";
            this.btnThongKeDonHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThongKeDonHang_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnQuanLyDonhang);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnThongKeDonHang);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 579);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1434, 29);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmGiaoDienQuanLyHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 608);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmGiaoDienQuanLyHoaDon";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Giao Diện Quản Lý Đơn Hàng";
            this.Load += new System.EventHandler(this.frmGiaoDienQuanLyHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnQuanLyDonhang;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem btnThongKeDonHang;
    }
}