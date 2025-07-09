using Google.Cloud.Firestore;
using Microsoft.VisualBasic.ApplicationServices;
using PomoMeetApp.Classes;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomoMeetApp.View
{
    public partial class NotificationItem : UserControl
    {
        private string inviteId;
        private string roomId;
        private string currentUserId;
        private Action<string, string, string> onResponse;

        public NotificationItem(string senderName, string time, Image avatar, string inviteId, string roomId, string userId, Action<string, string, string> callback)
        {
            InitializeComponent();
            this.inviteId = inviteId;
            this.roomId = roomId;
            this.currentUserId = userId;
            this.onResponse = callback;

            lblText.Text = senderName;
            lblTime.Text = time;
            picAvatar.Image = avatar ?? Properties.Resources.avatar;
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;

            btnAccept.Click += async (s, e) => await HandleAcceptAsync();
            btnDecline.Click += async (s, e) => await HandleDeclineAsync();
        }

        private async Task HandleAcceptAsync()
        {
            await HandleResponseAsync("Accepted", async () =>
            {
                var db = FirebaseConfig.database;
                if (db == null) throw new Exception("Kết nối cơ sở dữ liệu chưa được khởi tạo.");

                var docRef = db.Collection("Invitations").Document(inviteId);
                var snapshot = await docRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    throw new Exception("Lời mời không tồn tại.");
                }

                // Update the invitation status to "Accepted"
                await docRef.UpdateAsync("status", "Accepted");

                // Set user status to online when they accept the invitation
                await UserStatusManager.Instance.UpdateUserStatus(currentUserId, "online");
            });
        }

        private async Task HandleDeclineAsync()
        {
            await HandleResponseAsync("Rejected", async () =>
            {
                var db = FirebaseConfig.database;
                if (db == null) throw new Exception("Kết nối cơ sở dữ liệu chưa được khởi tạo.");

                var docRef = db.Collection("Invitations").Document(inviteId);
                var snapshot = await docRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    throw new Exception("Lời mời không tồn tại.");
                }

                // Update the invitation status to "Rejected"
                await docRef.UpdateAsync("status", "Rejected");
            });
        }
        private async Task HandleResponseAsync(string response, Func<Task> action)
        {
            try
            {
                // Disable buttons to prevent duplicate actions
                btnAccept.Enabled = false;
                btnDecline.Enabled = false;

                var db = FirebaseConfig.database;
                if (db == null) throw new Exception("Kết nối cơ sở dữ liệu chưa được khởi tạo.");

                // First check if the document exists
                var docRef = db.Collection("Invitations").Document(inviteId);
                var snapshot = await docRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    CustomMessageBox.Show("Lời mời không tồn tại");
                    this.Dispose();
                    return;
                }

                // Perform the action (e.g., update status)
                await action();

                // Notify the parent control about the response
                onResponse?.Invoke(inviteId, roomId, response);

                // Remove the notification item from the UI
                this.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi xử lý hành động {response.ToLower()}: {ex.Message}");
                btnAccept.Enabled = true;
                btnDecline.Enabled = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }
    }
}