using Google.Cloud.Firestore;
using PomoMeetApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PomoMeetApp.View.CustomMessageBox;

namespace PomoMeetApp.View
{
    public partial class Host : Form
    {
        private string currentUserId;
        private string currentroomId;
        public Host(string userId, string roomId)
        {
            InitializeComponent();
            currentUserId = userId;
            currentroomId = roomId;
            tlp_ListMembers.AutoSize = true;
            tlp_ListMembers.AutoScroll = true;
            tlp_ListMembers.GrowStyle = TableLayoutPanelGrowStyle.AddRows;


            LoadParticipants();
            tb_FindMembers.TextChanged += tb_FindMembers_Changed;
        }

        private void Host_Load(object sender, EventArgs e)
        {

        }

        private void siticonePanel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private async Task TransferHost(string newHostId)
        {
            try
            {
                // Lấy thông tin phòng từ Firestore
                var db = FirebaseConfig.database;
                var roomRef = db.Collection("Room").Document(currentroomId);
                var snapshot = await roomRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    CustomMessageBox.Show("Phòng không tồn tại!");
                    return;
                }

                var roomData = snapshot.ToDictionary();
                string hostId = roomData["host_id"].ToString(); // Lấy hostId từ Firestore

                // Kiểm tra nếu người hiện tại có phải là host không
                if (currentUserId != hostId)
                {
                    CustomMessageBox.Show("Chỉ host hiện tại mới có quyền chuyển host.");
                    return;
                }

                // Kiểm tra nếu người được chọn đã là host
                if (newHostId == hostId)
                {
                    CustomMessageBox.Show("Thành viên này đã là host.");
                    return;
                }

                // Cập nhật host trong Firestore
                await roomRef.UpdateAsync("host_id", newHostId);  // Cập nhật host_id mới
                CustomMessageBox.Show("Host đã được chuyển thành công!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi chuyển host: {ex.Message}");
            }
        }

        private async void LoadParticipants()
        {
            var db = FirebaseConfig.database;
            DocumentReference roomRef = db.Collection("Room").Document(currentroomId);
            DocumentSnapshot snapshot = await roomRef.GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                MessageBox.Show("Không tìm thấy phòng với room_id: " + currentroomId);
                return;
            }

            // Lấy thông tin từ trường members_status
            if (!snapshot.TryGetValue<Dictionary<string, object>>("members_status", out var membersDict))
            {
                MessageBox.Show("Không tìm thấy trường 'members_status' trong Firestore.");
                return;
            }

            tlp_ListMembers.Controls.Clear(); // Xóa hết các dòng cũ nếu có

            foreach (var entry in membersDict)
            {
                string userId = entry.Key;

                var userRef = db.Collection("User").Document(userId);
                var userDoc = await userRef.GetSnapshotAsync();
                if (!userDoc.Exists) continue;

                var userData = userDoc.ToDictionary();
                string username = userData["Username"].ToString();
                string avatarKey = userData.ContainsKey("Avatar") ? userData["Avatar"]?.ToString() : null;

                // Lấy avatar từ resource
                Image avatarImage = GetAvatarFromResources(avatarKey);

                // Gọi AddMemberRow để thêm thành viên vào TableLayoutPanel, truyền cả userId
                AddMemberRow(userId, username, avatarImage);
            }
        }

        private void AddMemberRow(string userId, string username, Image avatar)
        {
            int rowIndex = tlp_ListMembers.RowCount;
            tlp_ListMembers.RowCount = rowIndex + 1;

            tlp_ListMembers.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            tlp_ListMembers.BorderStyle = BorderStyle.None;

            var pb = new PictureBox()
            {
                Image = avatar,
                Width = 40,
                Height = 40,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            var lbl = new Label()
            {
                Text = username,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleLeft,
                Anchor = AnchorStyles.Left
            };

            var btnTransfer = new Button()
            {
                Text = "Chuyển host",
                AutoSize = true,
                BackColor = Color.FromArgb(117, 164, 127),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnTransfer.FlatAppearance.BorderSize = 0;

            var btnKick = new Button()
            {
                Text = "Đá",
                AutoSize = true,
                BackColor = Color.FromArgb(117, 164, 127),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnKick.FlatAppearance.BorderSize = 0;

            btnTransfer.Click += async (s, e) => await TransferHost(userId);
            btnKick.Click += async (s, e) => await KickMember(userId);

            tlp_ListMembers.Controls.Add(pb, 0, rowIndex);
            tlp_ListMembers.Controls.Add(lbl, 1, rowIndex);
            tlp_ListMembers.Controls.Add(btnTransfer, 2, rowIndex);
            tlp_ListMembers.Controls.Add(btnKick, 3, rowIndex);
        }


        private Image GetAvatarFromResources(string avatarKey)
        {
            if (string.IsNullOrEmpty(avatarKey)) return Properties.Resources.avatar; // Avatar mặc định nếu không có avatar

            switch (avatarKey)
            {
                case "avt1":
                    return Properties.Resources.avt1; // Avatar từ Resources
                case "avt2":
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt3":
                    return Properties.Resources.avt3; // Avatar từ Resources
                case "avt4":
                    return Properties.Resources.avt4; // Avatar từ Resources
                case "avt5":
                    return Properties.Resources.avt5; // Avatar từ Resources
                case "avt6":
                    return Properties.Resources.avt6; // Avatar từ Resources
                case "avt7":
                    return Properties.Resources.avt7; // Avatar từ Resources
                case "avt8":
                    return Properties.Resources.avt8; // Avatar từ Resources
                case "avt9":
                    return Properties.Resources.avt9; // Avatar từ Resources
                case "avt10":
                    return Properties.Resources.avt10; // Avatar từ Resources
                default:
                    return Properties.Resources.avatar; // Avatar mặc định nếu không tìm thấy
            }
        }

        private async Task KickMember(string userId)
        {
            try
            {
                // Lấy thông tin phòng từ Firestore
                var db = FirebaseConfig.database;
                var roomRef = db.Collection("Room").Document(currentroomId);
                var snapshot = await roomRef.GetSnapshotAsync();

                if (!snapshot.Exists)
                {
                    CustomMessageBox.Show("Phòng không tồn tại!");
                    return;
                }

                var roomData = snapshot.ToDictionary();
                string hostId = roomData["host_id"].ToString();

                // Kiểm tra quyền host
                if (currentUserId != hostId)
                {
                    CustomMessageBox.Show("Chỉ host hiện tại mới có quyền kick.");
                    return;
                }

                if (userId == currentUserId)
                {
                    CustomMessageBox.Show("Không thể tự mời chính mình ra khỏi phòng.");
                    return;
                }

                // Lấy trường members_status
                if (!snapshot.TryGetValue<Dictionary<string, object>>("members_status", out var membersStatus))
                {
                    CustomMessageBox.Show("Không tìm thấy trường 'members_status' trong phòng.");
                    return;
                }

                // Xóa userId khỏi members_status
                if (membersStatus.ContainsKey(userId))
                {
                    membersStatus.Remove(userId);

                    // CẬP NHẬT FIRESTORE TRƯỚC - quan trọng!
                    await roomRef.UpdateAsync("members_status", membersStatus);

                    // Cập nhật trạng thái user về offline
                    await UserStatusManager.Instance.UpdateUserStatus(userId, "offline");

                    CustomMessageBox.Show("Thành viên đã bị mời ra khỏi phòng!");

                    // Reload danh sách participants
                    LoadParticipants();

                    // QUAN TRỌNG: Sau khi update Firestore, listener của MeetingRoom sẽ tự động 
                    // phát hiện user không còn trong members_status và tự đóng form
                    // Không cần phải manually tìm và đóng form nữa
                }
                else
                {
                    CustomMessageBox.Show("Thành viên không tồn tại trong phòng.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi đá thành viên: {ex.Message}");
            }
        }


        private async void tb_FindMembers_Changed(object sender, EventArgs e)
        {
            string searchKeyword = tb_FindMembers.Text.ToLower(); // Lấy từ khóa tìm kiếm

            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                LoadParticipants(); // Nếu không có từ khóa, load lại toàn bộ danh sách
                return;
            }

            var db = FirebaseConfig.database;
            DocumentReference roomRef = db.Collection("Room").Document(currentroomId);
            var snapshot = await roomRef.GetSnapshotAsync();

            if (!snapshot.Exists)
            {
                MessageBox.Show("Không tìm thấy phòng với room_id: " + currentroomId);
                return;
            }

            // Lấy danh sách thành viên từ members_status
            if (!snapshot.TryGetValue<Dictionary<string, object>>("members_status", out var membersStatus))
            {
                MessageBox.Show("Không tìm thấy trường 'members_status' trong Firestore.");
                return;
            }

            tlp_ListMembers.Controls.Clear(); // Xóa danh sách cũ

            foreach (var entry in membersStatus)
            {
                string userId = entry.Key;

                var userRef = db.Collection("User").Document(userId);
                var userDoc = await userRef.GetSnapshotAsync();
                if (!userDoc.Exists) continue;

                var userData = userDoc.ToDictionary();
                string username = userData["Username"].ToString();
                string compareUsername = username.ToLower();
                string avatarKey = userData.ContainsKey("Avatar") ? userData["Avatar"]?.ToString() : null;

                if (compareUsername.Contains(searchKeyword))
                {
                    // Lấy avatar từ resource
                    Image avatarImage = GetAvatarFromResources(avatarKey);

                    // Thêm vào danh sách hiển thị
                    AddMemberRow(userId, username, avatarImage);
                }
            }
        }


        private void sbtn_ChangeHost_Click(object sender, EventArgs e)
        {

        }
    }
}