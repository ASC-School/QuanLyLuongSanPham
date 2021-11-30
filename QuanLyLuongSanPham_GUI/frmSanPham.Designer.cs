
namespace QuanLyLuongSanPham_GUI
{
    partial class frmSanPham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPham));
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.dgvModel = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bindingNavigatorSanPham = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLuuSanPham = new System.Windows.Forms.Button();
            this.btnXoaSanPham = new System.Windows.Forms.Button();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.btnSuaSanPham = new System.Windows.Forms.Button();
            this.btnOpenFrmModel = new System.Windows.Forms.Button();
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnLoadDSSanPham = new System.Windows.Forms.Button();
            this.cboTenModel = new System.Windows.Forms.ComboBox();
            this.cboMaModel = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThongSoKyThuat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNamSanXuat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.errorLoi = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTipOpenFrmModel = new System.Windows.Forms.ToolTip(this.components);
            this.bindingSourceModel = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceSanPham = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorSanPham)).BeginInit();
            this.bindingNavigatorSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorLoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSanPham)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSanPham
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(9, 277);
            this.dgvSanPham.Name = "dgvSanPham";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSanPham.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSanPham.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSanPham.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSanPham.Size = new System.Drawing.Size(1077, 140);
            this.dgvSanPham.TabIndex = 0;
            this.dgvSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSanPham_CellClick);
            // 
            // dgvModel
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvModel.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModel.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvModel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvModel.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvModel.GridColor = System.Drawing.Color.Black;
            this.dgvModel.Location = new System.Drawing.Point(637, 34);
            this.dgvModel.Name = "dgvModel";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModel.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvModel.RowHeadersWidth = 51;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvModel.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvModel.Size = new System.Drawing.Size(440, 155);
            this.dgvModel.TabIndex = 0;
            this.dgvModel.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvModel_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã sản phẩm:";
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Location = new System.Drawing.Point(105, 10);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(229, 23);
            this.txtMaSanPham.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.panelControl1.Appearance.BorderColor = System.Drawing.Color.Crimson;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Appearance.Options.UseBorderColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.bindingNavigatorSanPham);
            this.panelControl1.Controls.Add(this.btnLuuSanPham);
            this.panelControl1.Controls.Add(this.btnXoaSanPham);
            this.panelControl1.Controls.Add(this.btnThemSanPham);
            this.panelControl1.Controls.Add(this.btnSuaSanPham);
            this.panelControl1.Controls.Add(this.btnOpenFrmModel);
            this.panelControl1.Controls.Add(this.btnLoadModel);
            this.panelControl1.Controls.Add(this.btnLoadDSSanPham);
            this.panelControl1.Controls.Add(this.cboTenModel);
            this.panelControl1.Controls.Add(this.cboMaModel);
            this.panelControl1.Controls.Add(this.label11);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.label10);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.txtThongSoKyThuat);
            this.panelControl1.Controls.Add(this.dgvModel);
            this.panelControl1.Controls.Add(this.label9);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.txtTrangThai);
            this.panelControl1.Controls.Add(this.txtMoTa);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.txtGiaBan);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.txtNamSanXuat);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txtTenSanPham);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txtMaSanPham);
            this.panelControl1.Controls.Add(this.dgvSanPham);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1092, 427);
            this.panelControl1.TabIndex = 3;
            // 
            // bindingNavigatorSanPham
            // 
            this.bindingNavigatorSanPham.AddNewItem = this.bindingNavigatorAddNewItem1;
            this.bindingNavigatorSanPham.CountItem = this.bindingNavigatorCountItem1;
            this.bindingNavigatorSanPham.DeleteItem = this.bindingNavigatorDeleteItem1;
            this.bindingNavigatorSanPham.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigatorSanPham.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigatorSanPham.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorAddNewItem1,
            this.bindingNavigatorDeleteItem1});
            this.bindingNavigatorSanPham.Location = new System.Drawing.Point(9, 248);
            this.bindingNavigatorSanPham.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.bindingNavigatorSanPham.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.bindingNavigatorSanPham.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.bindingNavigatorSanPham.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.bindingNavigatorSanPham.Name = "bindingNavigatorSanPham";
            this.bindingNavigatorSanPham.PositionItem = this.bindingNavigatorPositionItem1;
            this.bindingNavigatorSanPham.Size = new System.Drawing.Size(302, 31);
            this.bindingNavigatorSanPham.TabIndex = 9;
            this.bindingNavigatorSanPham.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem1
            // 
            this.bindingNavigatorAddNewItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem1.Image")));
            this.bindingNavigatorAddNewItem1.Name = "bindingNavigatorAddNewItem1";
            this.bindingNavigatorAddNewItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem1.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorAddNewItem1.Text = "Add new";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(45, 28);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem1
            // 
            this.bindingNavigatorDeleteItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem1.Image")));
            this.bindingNavigatorDeleteItem1.Name = "bindingNavigatorDeleteItem1";
            this.bindingNavigatorDeleteItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem1.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem1.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // btnLuuSanPham
            // 
            this.btnLuuSanPham.BackColor = System.Drawing.Color.Crimson;
            this.btnLuuSanPham.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnLuuSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuSanPham.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuuSanPham.ForeColor = System.Drawing.Color.White;
            this.btnLuuSanPham.Location = new System.Drawing.Point(856, 197);
            this.btnLuuSanPham.Name = "btnLuuSanPham";
            this.btnLuuSanPham.Size = new System.Drawing.Size(165, 33);
            this.btnLuuSanPham.TabIndex = 7;
            this.btnLuuSanPham.Text = "Lưu sản phẩm";
            this.btnLuuSanPham.UseVisualStyleBackColor = false;
            this.btnLuuSanPham.Click += new System.EventHandler(this.btnLuuSanPham_Click);
            // 
            // btnXoaSanPham
            // 
            this.btnXoaSanPham.BackColor = System.Drawing.Color.Crimson;
            this.btnXoaSanPham.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnXoaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSanPham.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoaSanPham.ForeColor = System.Drawing.Color.White;
            this.btnXoaSanPham.Location = new System.Drawing.Point(685, 198);
            this.btnXoaSanPham.Name = "btnXoaSanPham";
            this.btnXoaSanPham.Size = new System.Drawing.Size(165, 33);
            this.btnXoaSanPham.TabIndex = 7;
            this.btnXoaSanPham.Text = "Xóa sản phẩm";
            this.btnXoaSanPham.UseVisualStyleBackColor = false;
            this.btnXoaSanPham.Click += new System.EventHandler(this.btnXoaSanPham_Click);
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.BackColor = System.Drawing.Color.Crimson;
            this.btnThemSanPham.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnThemSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSanPham.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThemSanPham.ForeColor = System.Drawing.Color.White;
            this.btnThemSanPham.Location = new System.Drawing.Point(343, 198);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(165, 33);
            this.btnThemSanPham.TabIndex = 7;
            this.btnThemSanPham.Text = "Thêm sản phẩm";
            this.btnThemSanPham.UseVisualStyleBackColor = false;
            this.btnThemSanPham.Click += new System.EventHandler(this.btnThemSanPham_Click);
            // 
            // btnSuaSanPham
            // 
            this.btnSuaSanPham.BackColor = System.Drawing.Color.Crimson;
            this.btnSuaSanPham.FlatAppearance.BorderColor = System.Drawing.Color.Crimson;
            this.btnSuaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuaSanPham.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSuaSanPham.ForeColor = System.Drawing.Color.White;
            this.btnSuaSanPham.Location = new System.Drawing.Point(514, 198);
            this.btnSuaSanPham.Name = "btnSuaSanPham";
            this.btnSuaSanPham.Size = new System.Drawing.Size(165, 33);
            this.btnSuaSanPham.TabIndex = 7;
            this.btnSuaSanPham.Text = "Sửa sản phẩm";
            this.btnSuaSanPham.UseVisualStyleBackColor = false;
            this.btnSuaSanPham.Click += new System.EventHandler(this.btnSuaSanPham_Click);
            // 
            // btnOpenFrmModel
            // 
            this.btnOpenFrmModel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOpenFrmModel.BackgroundImage")));
            this.btnOpenFrmModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFrmModel.Location = new System.Drawing.Point(343, 156);
            this.btnOpenFrmModel.Name = "btnOpenFrmModel";
            this.btnOpenFrmModel.Size = new System.Drawing.Size(32, 27);
            this.btnOpenFrmModel.TabIndex = 6;
            this.btnOpenFrmModel.UseVisualStyleBackColor = true;
            this.btnOpenFrmModel.Click += new System.EventHandler(this.btnOpenFrmModel_Click);
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadModel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadModel.BackgroundImage")));
            this.btnLoadModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadModel.Location = new System.Drawing.Point(1045, 4);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(32, 27);
            this.btnLoadModel.TabIndex = 6;
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnLoadDSSanPham
            // 
            this.btnLoadDSSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDSSanPham.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLoadDSSanPham.BackgroundImage")));
            this.btnLoadDSSanPham.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadDSSanPham.Location = new System.Drawing.Point(1054, 248);
            this.btnLoadDSSanPham.Name = "btnLoadDSSanPham";
            this.btnLoadDSSanPham.Size = new System.Drawing.Size(32, 27);
            this.btnLoadDSSanPham.TabIndex = 6;
            this.btnLoadDSSanPham.UseVisualStyleBackColor = true;
            this.btnLoadDSSanPham.Click += new System.EventHandler(this.btnLoadDSSanPham_Click);
            // 
            // cboTenModel
            // 
            this.cboTenModel.FormattingEnabled = true;
            this.cboTenModel.Location = new System.Drawing.Point(105, 159);
            this.cboTenModel.Name = "cboTenModel";
            this.cboTenModel.Size = new System.Drawing.Size(229, 24);
            this.cboTenModel.TabIndex = 4;
            this.cboTenModel.SelectedIndexChanged += new System.EventHandler(this.cboTenModel_SelectedIndexChanged);
            // 
            // cboMaModel
            // 
            this.cboMaModel.FormattingEnabled = true;
            this.cboMaModel.Location = new System.Drawing.Point(105, 134);
            this.cboMaModel.Name = "cboMaModel";
            this.cboMaModel.Size = new System.Drawing.Size(229, 24);
            this.cboMaModel.TabIndex = 4;
            this.cboMaModel.SelectedIndexChanged += new System.EventHandler(this.cboMaModel_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(724, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(326, 33);
            this.label11.TabIndex = 3;
            this.label11.Text = "BẢNG THÔNG TIN MODEL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.Crimson;
            this.label8.Location = new System.Drawing.Point(414, 248);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(367, 33);
            this.label8.TabIndex = 3;
            this.label8.Text = "BẢNG THÔNG TIN SẢN PHẨM";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(6, 188);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "Thông số kỹ thuật:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(6, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Trạng thái:";
            // 
            // txtThongSoKyThuat
            // 
            this.txtThongSoKyThuat.Location = new System.Drawing.Point(105, 183);
            this.txtThongSoKyThuat.Name = "txtThongSoKyThuat";
            this.txtThongSoKyThuat.Size = new System.Drawing.Size(229, 23);
            this.txtThongSoKyThuat.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Tên model:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Mô tả:";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(105, 110);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(229, 23);
            this.txtTrangThai.TabIndex = 2;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(105, 208);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(229, 23);
            this.txtMoTa.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Giá bán:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(6, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mã model:";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(105, 85);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(229, 23);
            this.txtGiaBan.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Năm sản xuất:";
            // 
            // txtNamSanXuat
            // 
            this.txtNamSanXuat.Location = new System.Drawing.Point(105, 60);
            this.txtNamSanXuat.Name = "txtNamSanXuat";
            this.txtNamSanXuat.Size = new System.Drawing.Size(229, 23);
            this.txtNamSanXuat.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sản phẩm:";
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Location = new System.Drawing.Point(105, 35);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(229, 23);
            this.txtTenSanPham.TabIndex = 2;
            // 
            // errorLoi
            // 
            this.errorLoi.ContainerControl = this;
            // 
            // frmSanPham
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(222)))), ((int)(((byte)(223)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 451);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.IconOptions.Image = global::QuanLyLuongSanPham_GUI.Properties.Resources.logo;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSanPham";
            this.Text = "Sản Phẩm";
            this.Load += new System.EventHandler(this.frmSanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorSanPham)).EndInit();
            this.bindingNavigatorSanPham.ResumeLayout(false);
            this.bindingNavigatorSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorLoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSanPham)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.DataGridView dgvModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNamSanXuat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTenModel;
        private System.Windows.Forms.ComboBox cboMaModel;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtThongSoKyThuat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnOpenFrmModel;
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Button btnLoadDSSanPham;
        private System.Windows.Forms.Button btnLuuSanPham;
        private System.Windows.Forms.Button btnXoaSanPham;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.Button btnSuaSanPham;
        private System.Windows.Forms.BindingNavigator bindingNavigatorSanPham;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.BindingSource bindingSourceModel;
        private System.Windows.Forms.BindingSource bindingSourceSanPham;
        private System.Windows.Forms.ErrorProvider errorLoi;
        private System.Windows.Forms.ToolTip toolTipOpenFrmModel;
    }
}