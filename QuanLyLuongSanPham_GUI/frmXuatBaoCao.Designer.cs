
namespace QuanLyLuongSanPham_GUI
{
    partial class frmChonDuongDan
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnChonDuongDan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDuongDan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.lblDuongDan);
            this.panelControl1.Controls.Add(this.btnChonDuongDan);
            this.panelControl1.Location = new System.Drawing.Point(12, 25);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(471, 64);
            this.panelControl1.TabIndex = 0;
            // 
            // btnChonDuongDan
            // 
            this.btnChonDuongDan.BackColor = System.Drawing.Color.Crimson;
            this.btnChonDuongDan.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnChonDuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonDuongDan.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChonDuongDan.ForeColor = System.Drawing.Color.Transparent;
            this.btnChonDuongDan.Location = new System.Drawing.Point(355, 27);
            this.btnChonDuongDan.Name = "btnChonDuongDan";
            this.btnChonDuongDan.Size = new System.Drawing.Size(110, 23);
            this.btnChonDuongDan.TabIndex = 1;
            this.btnChonDuongDan.Text = "Chọn đường dẫn";
            this.btnChonDuongDan.UseVisualStyleBackColor = false;
            this.btnChonDuongDan.Click += new System.EventHandler(this.btnChonDuongDan_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(18, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 28);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn đường dẫn:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Crimson;
            this.btnDong.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnDong.ForeColor = System.Drawing.Color.Transparent;
            this.btnDong.Location = new System.Drawing.Point(12, 96);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 23);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Crimson;
            this.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnOK.ForeColor = System.Drawing.Color.Transparent;
            this.btnOK.Location = new System.Drawing.Point(373, 96);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Đồng ý chọn";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.BackColor = System.Drawing.Color.White;
            this.lblDuongDan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDuongDan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDuongDan.Location = new System.Drawing.Point(10, 18);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(339, 32);
            this.lblDuongDan.TabIndex = 2;
            // 
            // frmChonDuongDan
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.Appearance.ForeColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 131);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmChonDuongDan";
            this.Text = "Xuất Báo Cáo";
            this.Load += new System.EventHandler(this.frmChonDuongDan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnChonDuongDan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblDuongDan;
    }
}