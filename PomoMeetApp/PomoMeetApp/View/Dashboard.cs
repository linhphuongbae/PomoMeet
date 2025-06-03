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
        private FirestoreChangeListener _userListener;

        public Dashboard(string userId)
        {
            InitializeComponent();
            currentUserId = userId;
            InitializeUserProfile();
            this.FormClosed += Dashboard_FormClosed;
        }

        private async void InitializeUserProfile()
        {
            var db = FirebaseConfig.database;
            DocumentSnapshot snapshot = await db.Collection("User").Document(currentUserId).GetSnapshotAsync();
            string username = snapshot.GetValue<string>("Username");
            string avatarName = snapshot.ContainsField("Avatar") ? snapshot.GetValue<string>("Avatar") : null;

            // Load avatar đúng từ Resources
            Image avatarImage = LoadAvatarImage(avatarName);

            // Cập nhật UI ngay lần đầu
            userProfilePanel2.UpdateUserInfo(currentUserId, username, LoadAvatarImage(avatarName));

            // Load badge ngay khi vào app
            await userProfilePanel2.UpdateNotificationBadge();

            // Bật listener để theo dõi thay đổi sau này
            StartListeningForUserChanges(currentUserId);
        }
        private void StartListeningForUserChanges(string userId)
        {
            var db = FirebaseConfig.database;
            DocumentReference userRef = db.Collection("User").Document(userId);

            _userListener = userRef.Listen(snapshot =>
            {
                if (snapshot.Exists)
                {
                    string username = snapshot.GetValue<string>("Username");
                    string avatarName = snapshot.ContainsField("Avatar") ? snapshot.GetValue<string>("Avatar") : null;

                    // Cập nhật UI trên main thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        userProfilePanel2.UpdateUserInfo(userId, username, LoadAvatarImage(avatarName));
                    });
                }
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

        private void sbtn_CreateNewRoom_Click(object sender, EventArgs e)
        {
            CreateRoom createRoom = new CreateRoom(currentUserId);
            createRoom.ShowDialog();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            _userListener?.StopAsync(); // Dừng listener khi đóng form
            Application.Exit(); // Đảm bảo thoát toàn bộ ứng dụng
        }

        private void tbtn_JoinRoom_Click(object sender, EventArgs e)
        {
            Joinroom joinroom = new Joinroom(currentUserId);
            joinroom.ShowDialog();
        }
    }
}
