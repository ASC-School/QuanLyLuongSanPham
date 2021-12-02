using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using QuanLyLuongSanPham_BUS;
using QuanLyLuongSanPham_DTO;
namespace QuanLyLuongSanPham_GUI

{
    /**
     * Tác giả: Võ Thị Trà Giang
     * Phiên bản: 1.0
     * Thời gian tạo: 16/11/2021
     */
    public partial class frmQuenMatKhau : DevExpress.XtraEditors.XtraForm
    {
        //congfig sms 
        DTO_TaiKhoan taiKhoanDTO;
        BUS_TaiKhoan taiKhoanBUS = new BUS_TaiKhoan();
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }
        public frmQuenMatKhau(string username)
        {
            InitializeComponent();
            taiKhoanDTO = taiKhoanBUS.getThongTinTaiKhoanTheoTenTaiKhoan(username);
        }
        string maOTP = null;

        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            txtOTP.Enabled = false;
            btnXacNhan.Enabled = false;
        }

        private string taoMaOTP()
        {
            string UpperCase = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string LowerCase = "qwertyuiopasdfghjklzxcvbnm";
            string Digits = "1234567890";
            string allCharacters = UpperCase + LowerCase + Digits;
            //Random will give random charactors for given length  
            Random r = new Random();
            String password = "";
            for (int i = 0; i < 8; i++)
            {
                double rand = r.NextDouble();
                if (i == 0)
                {
                    password += UpperCase.ToCharArray()[(int)Math.Floor(rand * UpperCase.Length)];
                }
                else
                {
                    password += allCharacters.ToCharArray()[(int)Math.Floor(rand * allCharacters.Length)];
                }
            }
            return password;
        }

        private void btnGuiMaOTP_Click(object sender, EventArgs e)
        {

            if(txtEmail.Text.Trim().Equals(""))
            {
                MessageBox.Show("Vui lòng điền email!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            maOTP = taoMaOTP();
            // tạo một tin nhắn và thêm những thông tin cần thiết như: ai gửi, người nhận, tên tiêu đề, và có đôi lời gì cần nhắn nhủ
            MailMessage mail = new MailMessage();
            // mail người gửi
            mail.From = new MailAddress("utauhosina2001@gmail.com");
            mail.Sender = new MailAddress("utauhosina2001@gmail.com");
            // mail ngưởi nhận
            mail.To.Add(txtEmail.Text);
            mail.IsBodyHtml = true;
            // tiêu đề mail
            mail.Subject = "Email Sent OTP";
            // nội dung mail
            mail.Body = "Vui lòng không để lộ mã này cho bất kỳ ai: " + maOTP ;
            //vì sử dụng Gmail nên mình dùng port 587
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            //ta không dùng cái mặc định đâu, mà sẽ dùng cái của riêng mình
            smtp.UseDefaultCredentials = false;
            // thêm vào credential vì SMTP server cần nó để biết được email + password của email đó mà bạn đang dùng
            smtp.Credentials = new System.Net.NetworkCredential("utauhosina2001@gmail.com", "bosscave123");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //vì ta cần thiết lập kết nối SSL với SMTP server nên cần gán nó bằng true
            smtp.EnableSsl = true;

            smtp.Timeout = 30000;
            try
            {
                smtp.Send(mail);
                MessageBox.Show("Đã gửi tin nhắn thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch
            {
                MessageBox.Show("Đã gửi tin nhắn thất bại!", "Thông báo", MessageBoxButtons.OK);
            }
            txtOTP.Enabled = true;
            btnXacNhan.Enabled = true;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOTP.Text.Equals(maOTP))
                {
                    this.Hide();
                    frmDoiMatKhau frm = new frmDoiMatKhau(taiKhoanDTO.TenTaiKhoan);
                    frm.ShowDialog();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Không đúng mã!!");
                return;
            }
           
        }
    }
}