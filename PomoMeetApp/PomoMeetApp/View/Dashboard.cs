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
            // Lấy username từ Firestore dựa trên userId
            var db = FirebaseConfig.database;
            DocumentSnapshot snapshot = await db.Collection("User").Document(currentUserId).GetSnapshotAsync();
            string username = snapshot.GetValue<string>("Username");

            // Truyền cả userId và username
            userProfilePanel2.UpdateUserInfo(currentUserId, username, GetUserAvatar());

            userProfilePanel2.SetProfileClickCallback(async (userId) =>
            {
                var profileForm = new Profile(userId);
                profileForm.ShowDialog();

                // Refresh sau khi đóng profile
                snapshot = await db.Collection("User").Document(currentUserId).GetSnapshotAsync();
                username = snapshot.GetValue<string>("Username");
                userProfilePanel2.UpdateUserInfo(currentUserId, username, GetUserAvatar());
            });
        }
        private Image GetUserAvatar()
        {
            return Properties.Resources.avatar; // Fallback image
        }
    }
}
