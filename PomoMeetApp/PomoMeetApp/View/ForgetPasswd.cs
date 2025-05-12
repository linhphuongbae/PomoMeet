using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PomoMeetApp.Classes;

namespace PomoMeetApp.View
{
    public partial class ForgetPasswd : Form
    {
        public ForgetPasswd()
        {
            InitializeComponent();
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {

        }

        private string sentOTP = "";
        private string sentEmail = "";

        private async void btnSendOTP_Click(object sender, EventArgs e)
        {

            string email = tbToEmail.Text.Trim();
            sentEmail = email;
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng nhập email.");
                return;
            }
            // check email tồn tại trong database 
            var db = FirebaseConfig.database;
            var emailDoc = await db.Collection("User").WhereEqualTo("Email", email).GetSnapshotAsync();    
            if (emailDoc.Documents.Count == 0)
            {
                MessageBox.Show("Email không khớp với bất kì tài khoản nào!");
                return;
            }
            // tạo otp
            string otp = new Random().Next(100000, 999999).ToString();
            sentOTP = otp;
            try
            {
                SendOTP(email, otp);
                MessageBox.Show($"Đã gửi OTP tới email: {email}");
                lbEmail.Visible = false;
                tbToEmail.Visible = false;
                lbOTP.Visible = true;
                tbOTP.Visible = true;
                btnSendOTP.Text = "Xác nhận OTP";
                btnSendOTP.Click -= btnSendOTP_Click;  // Hủy sự kiện cũ
                btnSendOTP.Click += btnConfirmOTP_Click; // Thêm sự kiện mới
            }
            catch (Exception ex) {
                MessageBox.Show("Gửi thất bại: " + ex.Message);
            }
                
        }
        private void btnConfirmOTP_Click(object sender, EventArgs e)
        {
            string otpEntered = tbOTP.Text.Trim();  // Lấy OTP người dùng nhập vào
            if (string.IsNullOrEmpty(otpEntered))
            {
                MessageBox.Show("Vui lòng nhập OTP.");
                return;
            }

            // Kiểm tra OTP
            if (otpEntered == sentOTP)
            {
                MessageBox.Show("OTP xác nhận thành công!");
                lbOTP.Visible = false;
                tbOTP.Visible = false;
                tbNewPass.Visible = true;
                lbNewpass.Visible = true;
                btnSendOTP.Click -= btnConfirmOTP_Click;  // Hủy sự kiện cũ
                btnSendOTP.Click += btnChangePassword_Click; // Thêm sự kiện mới để thay đổi mật khẩu
            }
            else
            {
                MessageBox.Show("OTP không khớp, vui lòng thử lại.");
            }
        }

        private void SendOTP(string email, string otp)
        {
            try
            {
                MailMessage msg = new MailMessage("dauducanphu1910@gmail.com", email);
                msg.Subject = "OTP phôi khục mật khẩu";
                msg.Body = $"OTP của bạn là: {otp}";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.Credentials = new NetworkCredential("dauducanphu1910@gmail.com", "msakerpnzkxsuxpf");
                smtpClient.EnableSsl = true;

                // gửi
                smtpClient.Send(msg);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }

        }
        // event đổi mk
        private async void btnChangePassword_Click(object sender, EventArgs e)
        {
            string newPasswd = tbNewPass.Text.Trim();   
            if (string.IsNullOrEmpty(newPasswd) )
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.");
                return;
            }

            var db = FirebaseConfig.database;
            var email = sentEmail;
            var docs = await db.Collection("User").WhereEqualTo("Email", email).GetSnapshotAsync();
            string encryptedPassword = Security.Encrypt(newPasswd);
            if (docs.Documents.Count > 0)
            {
                try
                {
                    var updateData = new Dictionary<string, object>
                    {
                        { "Password", encryptedPassword }
                    };
                    await docs.Documents[0].Reference.UpdateAsync(updateData);
                    MessageBox.Show("Đã cập nhật mật khẩu!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }
    }
}
