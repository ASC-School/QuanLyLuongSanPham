using DevExpress.XtraEditors;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuongSanPham_GUI
{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 27/12/2021
     */
    public partial class frmPDF : DevExpress.XtraEditors.XtraForm
    {
        OpenFileDialog openFile = new OpenFileDialog();
        public frmPDF()
        {
            InitializeComponent();
        }

        private void frmPDF_Load(object sender, EventArgs e)
        {

        }
    }
}