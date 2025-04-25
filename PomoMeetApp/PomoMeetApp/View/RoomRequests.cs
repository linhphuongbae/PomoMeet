using SiticoneNetCoreUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebaseAdmin;
using Google.Cloud.Firestore;
using PomoMeetApp.Classes;

namespace PomoMeetApp.View
{
    public partial class RoomRequests : Form
    {
        private string _inviteCode;
        private string _roomId;
        private string _currentUserId;

        public RoomRequests(string inviteCode, string roomId, string currentUserId)
        {
            InitializeComponent();
            _inviteCode = inviteCode;
            _roomId = roomId;
            _currentUserId = currentUserId;

            tbMamoi.Text = _inviteCode;
            btCopy.TargetControl = tbMamoi;
            siticoneButton2.Click += siticoneButton2_Click;
            siticonePanel2.BringToFront();
            siticonePanel2.Visible = true;
            // Load danh sách bạn bè khi form khởi tạo
            LoadFriendsList();
        }

        private async void LoadFriendsList()
        {
            try
            {
                var db = FirebaseConfig.database;
                if (db == null)
                {
                    MessageBox.Show("Database connection is not initialized.");
                    return;
                }

                // Query friendships where the current user is either the requester or receiver
                var friendships = new List<DocumentSnapshot>();

                // Query where the user is the requester
                var requesterQuery = db.Collection("FriendShips")
                    .WhereEqualTo("status", "Accepted")
                    .WhereEqualTo("requester_id", _currentUserId);

                // Query where the user is the receiver
                var receiverQuery = db.Collection("FriendShips")
                    .WhereEqualTo("status", "Accepted")
                    .WhereEqualTo("receiver_id", _currentUserId);

                // Execute both queries
                var requesterSnapshotTask = requesterQuery.GetSnapshotAsync();
                var receiverSnapshotTask = receiverQuery.GetSnapshotAsync();

                await Task.WhenAll(requesterSnapshotTask, receiverSnapshotTask);

                // Combine results
                friendships.AddRange(requesterSnapshotTask.Result.Documents);
                friendships.AddRange(receiverSnapshotTask.Result.Documents);

                // Debug: Log the number of friendships found
                MessageBox.Show($"Found {friendships.Count} friendships.");

                // Clear existing controls
                siticonePanel2.Controls.Clear();

                int yPos = 20;
                foreach (var doc in friendships)
                {
                    string requesterId = doc.GetValue<string>("requester_id");
                    string receiverId = doc.GetValue<string>("receiver_id");

                    // Determine the friend's ID (the one that isn't the current user)
                    string friendId = requesterId == _currentUserId ? receiverId : requesterId;

                    if (string.IsNullOrEmpty(friendId))
                    {
                        MessageBox.Show("Friend ID is null or empty. Skipping this friendship.");
                        continue;
                    }

                    // Fetch user details for the friend
                    var userDoc = await db.Collection("User").Document(friendId).GetSnapshotAsync();
                    if (userDoc.Exists)
                    {
                        string userName = userDoc.GetValue<string>("Username");

                        // Create a checkbox for each friend
                        var friendCheckbox = new SiticoneCheckBox
                        {
                            Text = userName,
                            Tag = friendId, // Store the friend's ID in the Tag property
                            Location = new Point(23, yPos),
                            Size = new Size(222, 30),
                            Font = new Font("Inter", 10.8F, FontStyle.Bold),
                            CheckedBackColor = Color.FromArgb(117, 164, 127),
                            UncheckedBackColor = Color.FromArgb(117, 164, 127)
                        };

                        siticonePanel2.Controls.Add(friendCheckbox);
                        yPos += 40;
                    }
                    else
                    {
                        MessageBox.Show($"User document for friend ID {friendId} does not exist. Skipping this friend.");
                    }
                }

                if (siticonePanel2.Controls.Count == 0)
                {
                    MessageBox.Show("No friends found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading friends list: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void siticoneButton2_Click(object? sender, EventArgs e)
        {
            var selectedFriends = new List<string>();

            foreach (Control control in siticonePanel2.Controls)
            {
                if (control is SiticoneCheckBox checkbox && checkbox.Checked)
                {
                    if (checkbox.Tag != null)
                    {
                        selectedFriends.Add(checkbox.Tag.ToString());
                    }
                    else
                    {
                        MessageBox.Show("A selected friend's ID is missing.");
                    }
                }
            }

            if (selectedFriends.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một người bạn để mời");
                return;
            }

            await SendInvitations(selectedFriends);
        }

        private async Task SendInvitations(List<string> friendIds)
        {
            try
            {
                var db = FirebaseConfig.database;
                if (db == null)
                {
                    MessageBox.Show("Database connection is not initialized.");
                    return;
                }

                int successCount = 0;

                foreach (var receiverId in friendIds)
                {
                    var existingInviteQuery = db.Collection("Invitations")
                        .WhereEqualTo("room_id", _roomId)
                        .WhereEqualTo("sender_id", _currentUserId)
                        .WhereEqualTo("receiver_id", receiverId)
                        .Limit(1);

                    var existingSnapshot = await existingInviteQuery.GetSnapshotAsync();

                    if (existingSnapshot.Count > 0)
                    {
                        MessageBox.Show($"Đã gửi lời mời đến người dùng này trước đó");
                        continue;
                    }

                    string invitationId = Guid.NewGuid().ToString();

                    var invitation = new
                    {
                        invite_id = invitationId,
                        invite_code = _inviteCode,
                        room_id = _roomId,
                        sender_id = _currentUserId,
                        receiver_id = receiverId,
                        status = "Pending",
                        created_at = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                        removed_at = ""
                    };

                    await db.Collection("Invitations").Document(invitationId).SetAsync(invitation);
                    successCount++;
                }

                MessageBox.Show($"Đã gửi thành công {successCount}/{friendIds.Count} lời mời");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi lời mời: {ex.Message}");
            }
        }
    }
}