﻿    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Microsoft.VisualBasic.ApplicationServices;
using PomoMeetApp.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PomoMeetApp.View
{
    public partial class Friends : Form
    {
        public Friends()
        {
            InitializeComponent();
            txtFindFriends.TextChanged += txtFindFriends_TextChanged;
        }

        private async void btn_AllFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "All Friends";
            pnFriends.Visible = true;

            pnFriends.Controls.Clear(); 
            // logic sẽ dùng query những đứa trong friendship mà status : Accepted
            var db = FirebaseConfig.database;
            string curUserId = UserSession.CurrentUser.UserId;
            // Lấy những mối quan hệ bạn bè đã accepted, gồm cả 2 chiều
            var Requester = await db.Collection("FriendShips")
                .WhereEqualTo("requester_id", curUserId)
                .WhereEqualTo("status", "Accepted")
                .GetSnapshotAsync();

            var Receiver = await db.Collection("FriendShips")
                .WhereEqualTo("receiver_id", curUserId)
                .WhereEqualTo("status", "Accepted")
                .GetSnapshotAsync();
            var friend = Requester.Documents.Concat(Receiver.Documents).ToList();
            int x = 10;
            foreach (var item in friend)
            {
                string requesterId = item.GetValue<string>("requester_id");
                string receiverId = item.GetValue<string>("receiver_id");
                string friendId = requesterId == curUserId ? receiverId : requesterId;

                // Lấy thông tin người gửi từ bảng User
                var userSnap = await db.Collection("User").Document(friendId).GetSnapshotAsync();
                if (!userSnap.Exists) continue;

                string fromUsername = userSnap.GetValue<string>("Username");
                string avatarId = userSnap.ContainsField("Avatar") ? userSnap.GetValue<string>("Avatar") : "avt1"; // fallback


                // Load ảnh avatar từ Firebase Storage nếu có, hoặc từ local nếu là mã như "avt1"
                Image avatarImage = LoadLocalAvatar(avatarId);

                // Panel chứa avatar và tên
                Panel card = new Panel
                {
                    Width = 200,
                    Height = 400,
                    Location = new Point(x, 10),
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
                    Text = fromUsername,
                    Location = new Point((card.Width - TextRenderer.MeasureText(fromUsername, new Font("Segoe UI", 10, FontStyle.Bold)).Width) / 2, 120),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                var btnRemove = new SiticoneNetCoreUI.SiticoneButton
                {
                    Text = "Remove",

                    // thiết kế
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
                    BorderColor = Color.FromArgb(240, 128, 128),
                    TextColor = Color.FromArgb(240, 128, 128),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };
                var currentCard = card;
                btnRemove.Click += async (s, args) =>
                {
                    try
                    {
                        await db.Collection("FriendShips").Document(item.Id).DeleteAsync();

                        MessageBox.Show("Đã xóa bạn!");

                        // xóa card khỏi giao diện
                        pnFriends.Controls.Remove(currentCard);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                };

                card.Controls.Add(pic);
                card.Controls.Add(lbl);
                card.Controls.Add(btnRemove);

                // Thêm vào pnFindFriends
                pnFriends.Controls.Add(card);
                x += card.Width + 10;
            }
        }

        private void btn_OnlineFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Online Friends";
            pnFriends.Visible = true;
        }

        private async void btn_FriendRequests_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Friends Requests";
            pnFriends.Visible = true;

            // logic view friendrequests
            pnFriends.Controls.Clear();
            string curUserId = UserSession.CurrentUser.UserId;
            var db = FirebaseConfig.database;
            // lấy receiver_id == current user id
            var request = await db.Collection("FriendShips").WhereEqualTo("receiver_id", curUserId).WhereEqualTo("status", "Pending").GetSnapshotAsync();

            int x = 10;
            foreach ( var item in request.Documents)
            {
                string requesterId = item.GetValue<string>("requester_id");

                // Lấy thông tin người gửi từ bảng User
                var userSnap = await db.Collection("User").Document(requesterId).GetSnapshotAsync();
                if (!userSnap.Exists) continue;

                string fromUsername = userSnap.GetValue<string>("Username");
                string avatarId = userSnap.ContainsField("Avatar") ? userSnap.GetValue<string>("Avatar") : "avt1"; // fallback


                // Load ảnh avatar từ Firebase Storage nếu có, hoặc từ local nếu là mã như "avt1"
                Image avatarImage = LoadLocalAvatar(avatarId);

                // Panel chứa avatar và tên
                Panel card = new Panel
                {
                    Width = 200,
                    Height = 400,
                    Location = new Point(x, 10),
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
                    Text = fromUsername,
                    Location = new Point((card.Width - TextRenderer.MeasureText(fromUsername, new Font("Segoe UI", 10, FontStyle.Bold)).Width) / 2, 120),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                var btnAccept = new SiticoneNetCoreUI.SiticoneButton
                {
                    Text = "Accept",

                    // thiết kế
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
                var btnDecline = new SiticoneNetCoreUI.SiticoneButton
                {
                    Text = "Decline",

                    // thiết kế
                    Width = 100,
                    Height = 30,
                    Location = new Point((card.Width - 100) / 2, 185),
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
                    BorderColor = Color.FromArgb(240, 128, 128),
                    TextColor = Color.FromArgb(240, 128, 128),
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                btnAccept.Click += async (s, args) =>
                {
                    try
                    {
                        await db.Collection("FriendShips").Document(item.Id).UpdateAsync(new Dictionary<string, object>
                        {
                            { "status", "Accepted" }
                        });

                        MessageBox.Show($"You are now friends with {fromUsername}!", "Friend Accepted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // xóa card khỏi giao diện
                        pnFriends.Controls.Remove(card);
                    } 
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    } 
                    
                };
                btnDecline.Click += async (s, args) =>
                {
                    try
                    {
                        await db.Collection("FriendShips").Document(item.Id).DeleteAsync();
                        MessageBox.Show("Đã từ chối kết bạn!");
                        pnFriends.Controls.Remove(card);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                };
                card.Controls.Add(pic);
                card.Controls.Add(lbl);
                card.Controls.Add(btnAccept);
                card.Controls.Add(btnDecline);

                // Thêm vào pnFindFriends
                pnFriends.Controls.Add(card);
                x += card.Width + 10;
            }     
        }

        private async void btn_FindFriends_Click(object sender, EventArgs e)
        {
            lbAllFriends.Text = "Results";
            pnFriends.Visible = true;


            // bắt đầu logic tìm người dùng từ đây
            pnFriends.Controls.Clear();
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

                    // thiết kế
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

                // logic bấm nút

                btnAdd.Click += async (s, args) =>
                {
                    if (userId == UserSession.CurrentUser.UserId)
                    {
                        MessageBox.Show("Bạn không thể kết bạn với chính mình.");
                        return;
                    };

                        var existing = await db.Collection("FriendShips")
                        .WhereEqualTo("requester_id", UserSession.CurrentUser.UserId)
                        .WhereEqualTo("receiver_id", userId)
                        .GetSnapshotAsync();

                        var reverse = await db.Collection("FriendShips")
                            .WhereEqualTo("requester_id", userId)
                            .WhereEqualTo("receiver_id", UserSession.CurrentUser.UserId)
                            .GetSnapshotAsync();
                        if (existing.Count > 0 || reverse.Count > 0)
                        {
                            MessageBox.Show("Đã tồn tại yêu cầu kết bạn hoặc đã là bạn bè.");
                            return;
                        }

                    string friendshipId = Guid.NewGuid().ToString();

                    // data
                    var data = new Dictionary<string, object>
                    {
                        { "friendship_id", friendshipId },
                        { "requester_id", UserSession.CurrentUser.UserId },
                        { "receiver_id", userId },
                        { "status", "Pending" },
                        { "created_at", FieldValue.ServerTimestamp },
                        { "removed_at", "" }
                    };

                    await db.Collection("FriendShips").Document(friendshipId).SetAsync(data);

                    btnAdd.Text = "Đã gửi";
                    btnAdd.Enabled = false;

                    MessageBox.Show("Đã gửi lời mời kết bạn!");
                };
                card.Controls.Add(pic);
                card.Controls.Add(lbl);
                card.Controls.Add(btnAdd);

                // Thêm vào pnFindFriends
                pnFriends.Controls.Add(card);
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
        // lắng nghe sự kiện text changed
        private void txtFindFriends_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFindFriends.Text))
            {
                pnFriends.Controls.Clear();
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
