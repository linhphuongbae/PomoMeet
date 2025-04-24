using Google.Cloud.Firestore;
using Microsoft.VisualBasic.ApplicationServices;
using PomoMeetApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class Dashboard : Form
    {
        private string currentUserId;
        public Dashboard(string userId)
        {
            InitializeComponent();
            currentUserId = userId;
            InitializeUserProfile();
        }
        private async void InitializeUserProfile()
        {
            var db = FirebaseConfig.database;
            DocumentSnapshot snapshot = await db.Collection("User").Document(currentUserId).GetSnapshotAsync();
            string username = snapshot.GetValue<string>("Username");
            string avatarName = snapshot.ContainsField("Avatar") ? snapshot.GetValue<string>("Avatar") : null;

            // Load avatar đúng từ Resources
            Image avatarImage = LoadAvatarImage(avatarName);

            userProfilePanel2.UpdateUserInfo(currentUserId, username, avatarImage);

            userProfilePanel2.SetProfileClickCallback(async (userId) =>
            {
                var profileForm = new Profile(userId);
                profileForm.ShowDialog();

                // Refresh sau khi đóng profile
                snapshot = await db.Collection("User").Document(currentUserId).GetSnapshotAsync();
                username = snapshot.GetValue<string>("Username");
                avatarName = snapshot.ContainsField("Avatar") ? snapshot.GetValue<string>("Avatar") : null;
                avatarImage = LoadAvatarImage(avatarName);

                userProfilePanel2.UpdateUserInfo(currentUserId, username, avatarImage);
            });
        }

        private Image LoadAvatarImage(string avatarName)
        {
            if (string.IsNullOrEmpty(avatarName))
            {
                return Properties.Resources.avatar; // fallback
            }

            try
            {
                var resourceManager = Properties.Resources.ResourceManager;
                return (Image)resourceManager.GetObject(avatarName) ?? Properties.Resources.avatar;
            }
            catch
            {
                return Properties.Resources.avatar;
            }
        }

        private Image GetUserAvatar()
        {
            return Properties.Resources.avatar; // Fallback image
        }
    }
}
