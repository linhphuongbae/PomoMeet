using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Firebase.Storage;
using PomoMeetApp.Classes;

namespace PomoMeetApp.View
{
    public partial class Profile : Form
    {
        private string currentUserId;
        private FirestoreDb db;

        public Profile(string userId)
        {
            InitializeComponent();
            // Clear the password fields
            tbNewPassword.Text = string.Empty;
            tbConfirmPassword.Text = string.Empty;
            currentUserId = userId; // Sửa từ currentUserId = userId (trước đó sai)
            db = FirebaseConfig.database;
            InitializeProfileComponents();
            LoadUserData();
            InitializeUserProfile();
        }

        private void InitializeUserProfile()
        {
            // 1. Configure the user profile panel
            // Cần load username trước khi gọi UpdateUserInfo
            // Sẽ được cập nhật trong LoadUserData()
            userProfilePanel1.UpdateUserInfo(currentUserId, "", GetUserAvatar());

            // 2. Set up the profile click callback
            userProfilePanel1.SetProfileClickCallback(userId => // Sửa từ username sang userId
            {
                var profileForm = new Profile(userId);
                profileForm.ShowDialog();

                // Optional: Refresh user info after returning from profile
                LoadUserData(); // Tải lại dữ liệu sau khi đóng form profile
            });
        }

        private Image GetUserAvatar()
        {
            return Properties.Resources.avatar; // Fallback image
        }

        private async void LoadUserData()
        {
            try
            {
                DocumentReference docRef = db.Collection("User").Document(currentUserId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> userData = snapshot.ToDictionary();
                    string username = userData.ContainsKey("Username") ? userData["Username"]?.ToString() ?? "" : "";
                    string avatarName = userData.ContainsKey("Avatar") ? userData["Avatar"]?.ToString() ?? null : null;

                    // Update UI
                    tbUsername.Text = username;
                    lbl_Username.Text = username;

                    if (userData.ContainsKey("Email") && userData["Email"] != null)
                    {
                        tbEmail.Text = userData["Email"].ToString(); // Reload the email
                    }

                    // Load avatar
                    Image avatarImage = LoadAvatarImage(avatarName);
                    pictureBox_avatar.Image = avatarImage;

                    // Update user profile panel
                    userProfilePanel1.UpdateUserInfo(currentUserId, username, avatarImage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Image LoadAvatarImage(string avatarName)
        {
            if (string.IsNullOrEmpty(avatarName))
            {
                return Properties.Resources.avatar; // Avatar mặc định
            }

            try
            {
                // Lấy avatar từ Resources theo tên
                var resourceManager = Properties.Resources.ResourceManager;
                return (Image)resourceManager.GetObject(avatarName) ?? Properties.Resources.avatar;
            }
            catch
            {
                return Properties.Resources.avatar; // Fallback nếu có lỗi
            }
        }

        private void InitializeProfileComponents()
        {
            btnSave.Click += BtnSave_Click;
            editAvatarButton.Click += BtnEditAvatar_Click;
            // Set password textbox to mask characters
            tbNewPassword.UseSystemPasswordChar = true;
            tbConfirmPassword.UseSystemPasswordChar = true;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string newUsername = tbUsername.Text.Trim();
            string newEmail = tbEmail.Text.Trim(); // Get the updated email
            string newPassword = tbNewPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Please enter a username", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(newPassword) || !string.IsNullOrEmpty(confirmPassword))
            {
                if (newPassword != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match", "Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                var updates = new Dictionary<string, object>
        {
            { "Username", newUsername },
            { "Email", newEmail }, // Include the email in the update
            { "lastUpdated", FieldValue.ServerTimestamp }
        };

                if (!string.IsNullOrEmpty(newPassword) && newPassword == confirmPassword)
                {
                    string encryptedPassword = Security.Encrypt(newPassword);
                    updates.Add("Password", encryptedPassword);
                }

                await db.Collection("User").Document(currentUserId)
                          .UpdateAsync(updates);

                MessageBox.Show("Profile updated successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                lbl_Username.Text = newUsername;
                userProfilePanel1.UpdateUserInfo(currentUserId, newUsername, pictureBox_avatar.Image);

                tbNewPassword.Text = "";
                tbConfirmPassword.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void BtnEditAvatar_Click(object sender, EventArgs e)
        {
            // Tạo form chọn avatar
            var avatarSelector = new Form
            {
                Text = "Select Avatar",
                Size = new Size(400, 400),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent
            };

            FlowLayoutPanel flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            avatarSelector.Controls.Add(flowPanel);

            // Tạo 10 avatar để chọn (avt1 đến avt10)
            for (int i = 1; i <= 10; i++)
            {
                string avatarName = $"avt{i}";
                var avatarImage = LoadAvatarImage(avatarName);

                var avatarButton = new Button
                {
                    Size = new Size(100, 100),
                    Margin = new Padding(10),
                    BackgroundImage = avatarImage,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Tag = avatarName
                };

                avatarButton.Click += (s, ev) =>
                {
                    // Lưu avatar được chọn vào Firestore
                    SaveSelectedAvatar(avatarName);
                    avatarSelector.Close();
                };

                flowPanel.Controls.Add(avatarButton);
            }

            avatarSelector.ShowDialog(this);
        }

        private async void SaveSelectedAvatar(string avatarName)
        {
            try
            {
                // Cập nhật avatar trong Firestore
                await db.Collection("User").Document(currentUserId)
                    .UpdateAsync("Avatar", avatarName);

                // Cập nhật UI
                Image selectedAvatar = LoadAvatarImage(avatarName);
                pictureBox_avatar.Image = selectedAvatar;
                userProfilePanel1.UpdateUserInfo(currentUserId, lbl_Username.Text, selectedAvatar);

                MessageBox.Show("Avatar updated successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating avatar: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}