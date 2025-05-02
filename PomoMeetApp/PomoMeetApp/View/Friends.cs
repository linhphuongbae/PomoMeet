using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PomoMeetApp.Classes;

namespace PomoMeetApp.View
{
    public partial class Friends : Form
    {
        public Friends()
        {
            InitializeComponent();
        }

        private void btn_AllFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "All Friends";
            pnAllFriends.Visible = true;
            pnFriendRequests.Visible = false;
            pnFindFriends.Visible = false;

        }

        private void btn_OnlineFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Online Friends";
            pnAllFriends.Visible = false;
            pnFriendRequests.Visible = false;
            pnFindFriends.Visible = false;
        }

        private void btn_FriendRequests_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Friends Requests";
            pnAllFriends.Visible = false;
            pnFriendRequests.Visible = true;
            pnFindFriends.Visible = false;
        }

        private async void btn_FindFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Results";
            pnAllFriends.Visible = false;
            pnFriendRequests.Visible = false;
            pnFindFriends.Visible = true;

            // bắt đầu logic tìm người dùng từ đây
            pnFindFriends.Controls.Clear();
            string searchQuery = txtFindFriends.Text.Trim();
            if (string.IsNullOrEmpty(searchQuery))
            {
                MessageBox.Show("Vui lòng nhập username.");
                return;
            }
            // connect database nè
            var db = FirebaseConfig.database;
            var userSnapshot = await db.Collection("User").WhereEqualTo("Username", searchQuery).GetSnapshotAsync();

            if (userSnapshot.Documents.Count == 0)
            {
                MessageBox.Show("Không tìm thấy người dùng.");
                return;
            }
            foreach (var doc in userSnapshot.Documents)
            {
                string userId = doc.Id;
                string username = doc.GetValue<string>("Username");
                string avatarId = doc.ContainsField("Avatar") ? doc.GetValue<string>("Avatar") : "avt1"; // fallback

                // Load ảnh avatar từ Firebase Storage nếu có, hoặc từ local nếu là mã như "avt1"
                Image avatarImage = LoadLocalAvatar(avatarId);

                // Panel chứa avatar và tên
                Panel card = new Panel
                {
                    Width = 200,
                    Height = 200,
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.None,
                    Margin = new Padding(5)
                };
                // Tạo SiticoneCirclePictureBox
                PictureBox pic = new PictureBox
                {
                    Width = 100,
                    Height = 100,
                    Location = new Point((card.Width - 100) / 2, 10),
                    Image = avatarImage,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent,
                };


                // Tạo Label tên người dùng
                Label lbl = new Label
                {
                    Text = username,
                    Location = new Point((card.Width - TextRenderer.MeasureText(username, new Font("Segoe UI", 10, FontStyle.Bold)).Width) / 2, 120),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                // Button Add Friend
                var btnAdd = new SiticoneNetCoreUI.SiticoneButton
                {
                    Text = "Add Friend",
                    Width = 100,
                    Height = 30,
                    Location = new Point((card.Width - 100) / 2, 150),
                    ForeColor = Color.Black,
                    GlowColor = Color.FromArgb(117, 164, 127),
                    CornerRadiusBottomLeft = 10,
                    CornerRadiusBottomRight = 10,
                    CornerRadiusTopLeft = 10,
                    CornerRadiusTopRight = 10,
                    BorderWidth = 2,
                    ButtonBackColor = Color.White,
                    HoverBackColor = Color.FromArgb(252, 255, 224),
                    GradientColor = Color.FromArgb(117, 164, 127),
                    BorderColor = Color.FromArgb(117, 164, 127),
                    TextColor = Color.FromArgb(117, 164, 127),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };


                card.Controls.Add(pic);
                card.Controls.Add(lbl);
                card.Controls.Add(btnAdd);

                // Thêm vào pnFindFriends
                pnFindFriends.Controls.Add(card);
            }
        }

        private Image LoadLocalAvatar(string avatarId)
        {

            try
            {
                return (Image)Properties.Resources.ResourceManager.GetObject(avatarId) ?? Properties.Resources.avt6;
            }
            catch
            {
                return Properties.Resources.avt1;
            }

        }


        private void Friends_Load(object sender, EventArgs e)
        {

        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {

        }

        private void siticoneTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
