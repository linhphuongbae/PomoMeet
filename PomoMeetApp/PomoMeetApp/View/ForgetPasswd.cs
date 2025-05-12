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

        private async void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = tbToEmail.Text.Trim();
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
            try
            {
                SendOTP(email, otp);
                MessageBox.Show($"Đã gửi OTP tới email: {email}");
            }
            catch (Exception ex) {
                MessageBox.Show("Gửi thất bại: " + ex.Message);
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
    }
}
