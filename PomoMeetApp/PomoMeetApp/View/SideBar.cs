using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using PomoMeetApp.Classes;

namespace PomoMeetApp.View
{
    public partial class SideBar : UserControl
    {
        string curUserId = UserSession.CurrentUser.UserId;
        public SideBar()
        {
            InitializeComponent();
        }

        private void siticonePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {

            CreateRoom cr = new CreateRoom(curUserId);
            cr.ShowDialog();
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            Friends fr = new Friends();
            fr.Show();
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            Setting st = new Setting();
            st.Show();
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard(curUserId);
            db.ShowDialog();
        }

        private async void siticoneButton5_Click(object sender, EventArgs e)
        {
            // Cập nhật trạng thái người dùng thành "offline" khi đăng xuất
            if (UserSession.CurrentUser != null)
            {
                await UserStatusManager.Instance.UpdateUserStatus(UserSession.CurrentUser.UserId, "offline");
            }

            // Xóa thông tin người dùng trong session
            UserSession.CurrentUser = null;

            // Lấy form cha (form chính)
            Form parent = this.FindForm();

            // Tạo form đăng nhập và chuyển về
            SignIn sg = new SignIn();
            await FormTransition.FadeTo(parent, sg);

            // Ẩn form cha (form chính)
            parent.Hide();
        }

    }
}
