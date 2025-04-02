using SiticoneNetCoreUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class Profile : Form
    {
        private NotificationButton notifyButton;
        private PictureBox avatar;
        private Label nameLabel;
        private ProfileDropdown profileDropdown;
        private SiticoneButton btnSave;

        public Profile()
        {
            InitializeComponent();
            InitializeCustomComponents();
            this.Resize += Profile_Resize;
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            editAvatarButton.Click += BtnEditAvatar_Click;
        }
        private void InitializeCustomComponents()
        {
            // Tạo nút thông báo
            notifyButton = new NotificationButton
            {
                Location = new Point(20, 20)
            };
            this.Controls.Add(notifyButton);

            // Tạo avatar
            avatar = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(notifyButton.Right + 10, 20),
                Image = Image.FromFile("D:/Downloads_D/HK4_UIT/LTM_NT106_P22_ANTT/backup/profile/avatar.jpg"),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent
            };
            this.Controls.Add(avatar);

            // Tạo tên tài khoản
            nameLabel = new Label
            {
                Text = "User",
                Location = new Point(avatar.Right + 10, 30),
                Font = new Font("Inter", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            nameLabel.Click += NameLabel_Click;
            this.Controls.Add(nameLabel);

            // Tạo dropdown menu (không cần truyền tên người dùng)
            profileDropdown = new ProfileDropdown
            {
                Location = new Point(nameLabel.Left, nameLabel.Bottom + 5),
                Visible = false
            };
            this.Controls.Add(profileDropdown);

            // Tạo nút Save ở dưới cùng form
            btnSave = new SiticoneButton
            {
                Text = "Save Changes",
                Size = new Size(100, 40),
                Location = new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height - 60),
                ButtonBackColor = Color.LightSkyBlue,
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            // Gán sự kiện Click cho editAvatarButton
            editAvatarButton.Click += BtnEditAvatar_Click;

            UpdateControlPositions();

        }
        private void BtnEditAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select Avatar",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_avatar.Image = Image.FromFile(openFileDialog.FileName);
                avatar.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void Profile_Resize(object sender, EventArgs e)
        {
            UpdateControlPositions();
        }

        private void UpdateControlPositions()
        {
            int rightMargin = 20;
            notifyButton.Location = new Point(this.ClientSize.Width - notifyButton.Width - rightMargin - 150, 20);
            avatar.Location = new Point(notifyButton.Right + 10, 20);
            nameLabel.Location = new Point(avatar.Right + 10, 30);
            profileDropdown.Location = new Point(nameLabel.Left - 10, nameLabel.Bottom + 5);
            btnSave.Location = new Point(this.ClientSize.Width / 2 - 130, this.ClientSize.Height - 60);
        }
        private void NameLabel_Click(object sender, EventArgs e)
        {
            profileDropdown.Visible = !profileDropdown.Visible;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã nhấn nút Save!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
