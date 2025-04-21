using SiticoneNetCoreUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public class UserProfilePanel : Panel
    {
        // Components
        private SiticoneNotificationButton btnNotify;
        private PictureBox avatar;
        private Label lblUserName;
        private SiticoneButton btnProfile;
        private Panel dropdownPanel;
        private Action<string> profileClickCallback; // Callback now expects userId

        // Store current userId
        private string currentUserId;

        public void SetProfileClickCallback(Action<string> callback)
        {
            profileClickCallback = callback;
        }

        public UserProfilePanel()
        {
            InitializePanel();
            InitializeComponents();
        }

        private void InitializePanel()
        {
            this.Size = new Size(250, 60); // Kích thước tổng
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
        }

        private void InitializeComponents()
        {
            // 1. Notification Button (Bên trái)
            btnNotify = new SiticoneNotificationButton
            {
                Size = new Size(50, 50),
                Location = new Point(0, 5),
                BellColor = Color.Black,
                Text = "",
                Cursor = Cursors.Hand
            };
            this.Controls.Add(btnNotify);

            // 2. Avatar (Ảnh đại diện)
            avatar = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(60, 5),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = Properties.Resources.avatar, // Thay bằng avatar mặc định
                Cursor = Cursors.Hand
            };
            avatar.Click += ToggleDropdown;
            this.Controls.Add(avatar);

            // 3. Tên người dùng
            lblUserName = new Label
            {
                Text = "Username",
                Font = new Font("Inter", 10, FontStyle.Bold),
                Location = new Point(120, 20),
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            lblUserName.Click += ToggleDropdown;
            this.Controls.Add(lblUserName);

            // 4. Dropdown Panel (Ẩn ban đầu)
            dropdownPanel = new SiticoneFlatPanel
            {
                Size = new Size(150, 50),
                Location = new Point(120, 50),
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,
                Visible = false
            };

            // Nút "View Profile" trong dropdown
            btnProfile = new SiticoneButton
            {
                Text = "View Profile",
                Size = new Size(140, 40),
                Location = new Point(5, 5),
                Font = new Font("Inter", 10, FontStyle.Bold),
                ButtonBackColor = Color.DarkSeaGreen,
                ForeColor = Color.White,
                Cursor = Cursors.Hand,
                RippleColor = Color.DarkSeaGreen,
                HoverBackColor = Color.DarkSeaGreen,
                CornerRadiusBottomLeft = 10,
                CornerRadiusBottomRight = 10,
                CornerRadiusTopLeft = 10,
                CornerRadiusTopRight = 10,
                BorderColor = Color.DarkSeaGreen,
                PressedBackColor = Color.SeaGreen
            };
            btnProfile.Click += (sender, e) =>
            {
                profileClickCallback?.Invoke(currentUserId); // Pass userId instead of username
                dropdownPanel.Visible = false;
            };
            dropdownPanel.Controls.Add(btnProfile);

            this.Controls.Add(dropdownPanel);
        }

        // Hiển thị/Ẩn dropdown
        private void ToggleDropdown(object sender, EventArgs e)
        {
            dropdownPanel.Visible = !dropdownPanel.Visible;
            this.Height = dropdownPanel.Visible ? 110 : 60; // Điều chỉnh chiều cao
        }

        // Cập nhật thông tin người dùng
        public void UpdateUserInfo(string userId, string userName, Image avatarImage)
        {
            currentUserId = userId; // Store the userId
            lblUserName.Text = userName;
            avatar.Image = avatarImage ?? Properties.Resources.avatar;
        }
    }
}