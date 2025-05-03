using Google.Cloud.Firestore;
using PomoMeetApp.Classes;
using System;
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
                if (db == null) throw new Exception("Database connection is not initialized.");

                // Update the invitation status to "Accepted"
                await db.Collection("Invitations").Document(inviteId).UpdateAsync("status", "Accepted");

                OpenMeetingRoom(currentUserId, roomId);
            });
        }
        private async void OpenMeetingRoom(string userId, string roomId)
        {
            // Gọi form phòng học truyền dữ liệu người tham gia
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").Document(roomId);

            // Cập nhật mảng members, thêm ID người tham gia vào
            try
            {
                await roomRef.UpdateAsync("members", FieldValue.ArrayUnion(currentUserId));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thành viên vào phòng: " + ex.Message);
            }

            MeetingRoom meetingRoom = new MeetingRoom(userId, roomId);
            meetingRoom.ShowDialog();
            this.Dispose();
        }
        private async Task HandleDeclineAsync()
        {
            await HandleResponseAsync("Rejected", async () =>
            {
                var db = FirebaseConfig.database;
                if (db == null) throw new Exception("Database connection is not initialized.");

                // Update the invitation status to "Rejected"
                await db.Collection("Invitations").Document(inviteId).UpdateAsync("status", "Rejected");
            });
        }

        private async Task HandleResponseAsync(string response, Func<Task> action)
        {
            try
            {
                // Disable buttons to prevent duplicate actions
                btnAccept.Enabled = false;
                btnDecline.Enabled = false;

                // Perform the action
                await action();

                // Notify the parent control about the response
                onResponse?.Invoke(inviteId, roomId, response);

                // Remove the notification item from the UI
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing {response.ToLower()} action: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAccept.Enabled = true;
                btnDecline.Enabled = true;
            }
        }
    }
}