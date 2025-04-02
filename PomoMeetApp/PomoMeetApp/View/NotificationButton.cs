using SiticoneNetCoreUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public class NotificationButton : Panel
    {
        private SiticoneNotificationButton btnNotify;

        public NotificationButton()
        {
            this.Size = new Size(50, 50);
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;

            btnNotify = CreateButton(0);
            this.Controls.Add(btnNotify);
        }

        private SiticoneNotificationButton CreateButton(int y)
        {
            var btnNotify = new SiticoneNotificationButton
            {
                Size = new Size(50, 50), // Kích thước của nút thông báo
                Location = new Point(0, y),
                BellColor = Color.Black,
                Text = "", // Xóa text vì đây là nút notification (chỉ có icon)
                Cursor = Cursors.Hand
            };
            btnNotify.Click += Button_Click; // Thêm sự kiện Click cho nút
            return btnNotify;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã chọn Notification!");
        }
    }
}
