using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class StartApp : Form
    {
        private System.Windows.Forms.Timer fadeTimer = new System.Windows.Forms.Timer();
        private float opacityValue = 1.0f; // Độ trong suốt của logo (1.0 = không mờ)
        public StartApp()
        {
            InitializeComponent();
            fadeTimer.Interval = 50; // Mỗi 50ms giảm độ mờ
            fadeTimer.Tick += FadeOutLogo;
            fadeTimer.Start(); // Bắt đầu hiệu ứng mờ dần
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void FadeOutLogo(object sender, EventArgs e)
        {
            if (opacityValue > 0)
            {
                opacityValue -= 0.05f; // Giảm opacity dần dần
                LogoPomoMeet.Image = ChangeOpacity(LogoPomoMeet.Image, opacityValue);
            }
            else
            {
                fadeTimer.Stop();
                OpenSignInForm(); // Chuyển sang form đăng nhập
            }
        }

        private void OpenSignInForm()
        {
            SignIn signinForm = new SignIn();
            signinForm.FormClosed += (sender, e) =>
            {
                this.Close(); // Đóng Form Logo khi Form Đăng Ký đóng
            };
            signinForm.Show(); // Mở Form Đăng Ký
            this.Hide(); // Ẩn Form Logo
        }

        private Image ChangeOpacity(Image img, float opacity)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity; // Điều chỉnh độ trong suốt
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        private void LogoPomoMeet_Click(object sender, EventArgs e)
        {

        }

        private void StartApp_Load(object sender, EventArgs e)
        {

        }
    }
}
