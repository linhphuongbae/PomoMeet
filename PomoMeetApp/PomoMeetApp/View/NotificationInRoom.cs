using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class NotificationInRoom : UserControl
    {
        public NotificationInRoom()
        {
            InitializeComponent();
            this.Visible = false;  // Ban đầu thông báo ẩn
        }
        public void SetNotification(string message, string iconType)
        {
            // Cập nhật nội dung thông báo
            lblNotification.Text = message;

            // Cập nhật icon từ Resources
            picNotificationIcon.Image = GetIconFromResource(iconType);

            // Hiển thị thông báo
            this.Visible = true;

            Task.Delay(5000).ContinueWith(t =>
            {
                if (this.IsHandleCreated && !this.IsDisposed && !this.Disposing)
                {
                    this.Invoke(new Action(() =>
                    {
                        // Double-check ngay cả trong Invoke, phòng trường hợp control vừa Dispose
                        if (!this.IsDisposed && this.IsHandleCreated && !this.Disposing)
                            this.Visible = false;
                    }));
                }
            });
        }

        private Image GetIconFromResource(string iconType)
        {
            // Lấy icon từ Resources
            switch (iconType)
            {
                case "new_exit":
                    return Properties.Resources.new_exit;  // Icon người rời phòng
                case "new_join":
                    return Properties.Resources.new_join;  // Icon người tham gia phòng
                case "rest_time":
                    return Properties.Resources.rest_time;  // Icon thời gian nghỉ
                case "done_pomodoro":
                    return Properties.Resources.done_pomodoro;  // Icon hoàn thành Pomodoro
                default:
                    return Properties.Resources.new_join;  // Icon mặc định nếu không có loại nào khớp
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;

        }
    }
}
