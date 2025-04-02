using SiticoneNetCoreUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public class ProfileDropdown : Panel
    {
        private SiticoneButton btnProfile;

        public ProfileDropdown()
        {
            this.Size = new Size(200, 50);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;

            btnProfile = CreateButton("View Profile", 0);
            this.Controls.Add(btnProfile);
        }

        private SiticoneButton CreateButton(string text, int y)
        {
            var button = new SiticoneButton
            {
                Text = text,
                Size = new Size(100, 40),
                Font = new Font("Inter", 9, FontStyle.Bold),
                Location = new Point(10, y),
                CornerRadiusBottomLeft = 10,
                CornerRadiusBottomRight = 10,
                CornerRadiusTopLeft = 10,
                CornerRadiusTopRight = 10,
                PressedBackColor = Color.DarkSeaGreen,
                PressedFontStyle = FontStyle.Bold,
                HoverBackColor = Color.DarkSeaGreen,
                BorderColor = Color.DarkSeaGreen,
                ButtonBackColor = Color.DarkSeaGreen,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            button.Click += Button_Click;
            return button;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn 'View Profile'!");
        }
    }
}
