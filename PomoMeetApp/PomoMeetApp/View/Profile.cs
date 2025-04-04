using SiticoneNetCoreUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class Profile : BaseForm
    {
        public Profile()
        {
            InitializeComponent();
            InitializeProfileComponents();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            editAvatarButton.Click += BtnEditAvatar_Click;
        }
        private void InitializeProfileComponents()
        {

            // Gán sự kiện Click cho editAvatarButton
            editAvatarButton.Click += BtnEditAvatar_Click;
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
            }
        }

        private void UpdateControlPositions()
        {
            base.UpdateControlPositions(); // Gọi phương thức của lớp cha
        }
    }
}
