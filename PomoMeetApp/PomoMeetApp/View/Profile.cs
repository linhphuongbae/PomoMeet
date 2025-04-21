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

        public Profile(string userId) // Thay đổi tham số từ username sang userId
        {
            InitializeComponent();
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
                    string username = userData.ContainsKey("Username") ? userData["Username"].ToString() : "";

                    // Cập nhật UI
                    tbUsername.Text = username;
                    lbl_Username.Text = username;

                    if (userData.ContainsKey("Email") && userData["Email"] != null)
                    {
                        tbEmail.Text = userData["Email"].ToString();
                    }

                    pictureBox_avatar.Image = Properties.Resources.avatar;

                    // Cập nhật user profile panel
                    userProfilePanel1.UpdateUserInfo(currentUserId, username, GetUserAvatar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeProfileComponents()
        {
            btnSave.Click += BtnSave_Click;
            editAvatarButton.Click += BtnEditAvatar_Click;
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            string newUsername = tbUsername.Text.Trim();

            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Please enter a username", "Warning",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var updates = new Dictionary<string, object>
                {
                    { "Username", newUsername },
                    { "lastUpdated", FieldValue.ServerTimestamp }
                };

                // Cập nhật document hiện tại bằng currentUserId
                await db.Collection("User").Document(currentUserId)
                          .UpdateAsync(updates);

                MessageBox.Show("Profile updated successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật UI
                lbl_Username.Text = newUsername;
                userProfilePanel1.UpdateUserInfo(currentUserId, newUsername, GetUserAvatar());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating profile: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnEditAvatar_Click(object sender, EventArgs e)
        {
            // Xử lý thay đổi avatar ở đây
        }
    }
}