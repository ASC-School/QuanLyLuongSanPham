using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuongSanPham_GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //try
            //{
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmDoiMatKhau("NV019_GiangVo"));
            //}
            //catch (Exception)
            //{
             //   MessageBox.Show("Server có vấn đề - Nên chạy lại!!!");
            //}
        }
    }
}
