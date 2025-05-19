using Google.Cloud.Firestore;
using Microsoft.VisualBasic.ApplicationServices;
using PomoMeetApp.Classes;
using SiticoneNetCoreUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using Agora.Rtc;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Grpc.Core;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Drawing.Drawing2D;


namespace PomoMeetApp.View
{
    public partial class MeetingRoom : Form
    {
        private ImageList imageListAvatars;
        private string currentUserId;
        private string currentroomId;
        private FirestoreChangeListener roomListener;

        private string appId = "9ff5da05a52c4f6e8e33448631ecc267";
        private IRtcEngine rtcEngine;
        private string hostId;
        private Panel localVideoPanel;

        private bool isLeavingRoom = false;
        private DateTime lastKickCheck = DateTime.MinValue;

        private DateTime joinTime = DateTime.MinValue;
        private bool isInitialCheck = true;

        public MeetingRoom(string userId, string roomId)
        {
            InitializeComponent();
            currentUserId = userId;
            currentroomId = roomId;

            LoadUserData();
            InitializeUserProfile();
            InitializeAgora();
            InitializeMeetingRoomComponents();
        }
        private Image GetUserAvatar()
        {
            return Properties.Resources.avatar; // Fallback image
        }

        private async void LoadUserData()
        {
            var db = FirebaseConfig.database;
            try
            {
                DocumentReference docRef = db.Collection("User").Document(currentUserId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Dictionary<string, object> userData = snapshot.ToDictionary();
                    string username = userData.ContainsKey("Username") ? userData["Username"]?.ToString() ?? "" : "";
                    string avatarName = userData.ContainsKey("Avatar") ? userData["Avatar"]?.ToString() ?? null : null;

                    // Load avatar
                    Image avatarImage = LoadAvatarImage(avatarName);

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

        private void InitializeMeetingRoomComponents()
        {
            // Khởi tạo ImageList
            imageListAvatars = new ImageList();
            imageListAvatars.ImageSize = new Size(16, 16);
            imageListAvatars.Images.Add("avatar", Properties.Resources.avatar);
            imageListAvatars.Images.Add("mic_on", Properties.Resources.mic_on);
            imageListAvatars.Images.Add("mic_off", Properties.Resources.mic_off);
            imageListAvatars.Images.Add("cam_on", Properties.Resources.cam_on);
            imageListAvatars.Images.Add("cam_off", Properties.Resources.cam_off);

            // Thiết lập ListView
            listViewParticipants.SmallImageList = imageListAvatars;
            listViewParticipants.View = System.Windows.Forms.View.Details;
            listViewParticipants.HeaderStyle = ColumnHeaderStyle.Nonclickable; // Hoặc ColumnHeaderStyle.Clickable nếu muốn có thể click vào header
            listViewParticipants.DrawSubItem += listViewParticipants_DrawSubItem;

            // Đặt chiều rộng cho các cột
            listViewParticipants.Columns.Add("Avatar", 60); // Cột Avatar
            listViewParticipants.Columns.Add("Name", 100);  // Cột Tên
            listViewParticipants.Columns.Add("Mic", 50);    // Cột Mic
            listViewParticipants.Columns.Add("Camera", 50); // Cột Camera
        }

        private uint GetUidFromId(string id)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(id));
            return BitConverter.ToUInt32(hash, 0); // Lấy 4 byte đầu
        }

        Dictionary<string, MemberState> memberStates = new Dictionary<string, MemberState>();

        private void ListenToRoomRealtime()
        {
            joinTime = DateTime.Now; // Ghi lại thời điểm vào phòng

            var db = FirebaseConfig.database;
            var docRef = db.Collection("Room").Document(currentroomId);

            roomListener = docRef.Listen(async snapshot =>
            {
                if (isLeavingRoom) return; // Bỏ qua nếu đang rời phòng

                // Phòng bị xóa
                if (!snapshot.Exists)
                {
                    SafeInvoke(() =>
                    {
                        if (!this.IsDisposed)
                        {
                            // Đánh dấu đang rời phòng do host đóng
                            isLeavingRoom = true;

                            MessageBox.Show("Phòng đã bị xóa bởi host!", "Thông báo",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    });
                    return;
                }

                if (!snapshot.TryGetValue("members_status", out Dictionary<string, object> membersStatus))
                    return;

                // Bỏ qua kiểm tra đầu tiên trong 3 giây đầu tiên
                if ((DateTime.Now - joinTime).TotalSeconds < 3 && isInitialCheck)
                {
                    isInitialCheck = false;
                    return;
                }

                // Kiểm tra nếu thành viên bị đá (không còn trong phòng)
                if (!membersStatus.ContainsKey(currentUserId))
                {
                    // Kiểm tra nếu có đánh dấu is_leaving thì không hiển thị thông báo
                    if (membersStatus.TryGetValue(currentUserId, out object memberData) &&
                        memberData is Dictionary<string, object> data &&
                        data.ContainsKey("is_leaving") &&
                        Convert.ToBoolean(data["is_leaving"]))
                        {
                            return;
                        }

                    SafeInvoke(() =>
                    {
                        if (!this.IsDisposed && !this.Disposing && !isLeavingRoom)
                        {
                            var result = MessageBox.Show("Bạn đã bị đá khỏi phòng!", "Thông báo",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                    });
                    return;
                }

                // Xóa những user không còn trong Firestore
                var currentIds = new HashSet<string>(membersStatus.Keys);
                var keysToRemove = memberStates.Keys.Where(id => !currentIds.Contains(id)).ToList();
                foreach (var id in keysToRemove)
                {
                    memberStates.Remove(id);
                }

                // Cập nhật trạng thái từng người hiện tại
                foreach (var entry in membersStatus)
                {
                    string userId = entry.Key;
                    var data = entry.Value as Dictionary<string, object>;
                    if (data == null) continue;

                    bool cameraOn = data.ContainsKey("camera_on") && Convert.ToBoolean(data["camera_on"]);
                    bool micOn = data.ContainsKey("mic_on") && Convert.ToBoolean(data["mic_on"]);
                    bool speakerOn = data.ContainsKey("speaker_on") && Convert.ToBoolean(data["speaker_on"]);

                    memberStates[userId] = new MemberState
                    {
                        UserId = userId,
                        CameraOn = cameraOn,
                        MicOn = micOn,
                        SpeakerOn = speakerOn
                    };
                }

                // Tạo bản sao tránh lỗi đa luồng
                var copy = new Dictionary<string, MemberState>(memberStates);
                this.SafeInvoke(new Action(() =>
                {
                    _ = UpdateUIAsync(copy, db);
                }));
            });
        }
        // Helper method to safely invoke on UI thread
        private void SafeInvoke(Action action)
        {
            try
            {
                if (this.IsDisposed || !this.IsHandleCreated || this.Disposing)
                {
                    // Form is disposed or disposing, don't execute the action
                    return;
                }

                if (this.InvokeRequired)
                {
                    // Use BeginInvoke instead of Invoke to avoid deadlocks
                    this.BeginInvoke(new Action(() =>
                    {
                        // Double-check disposal state before executing
                        if (!this.IsDisposed && this.IsHandleCreated && !this.Disposing)
                        {
                            action();
                        }
                    }));
                }
                else
                {
                    if (!this.IsDisposed && this.IsHandleCreated && !this.Disposing)
                    {
                        action();
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                // Silently catch if the form was disposed during the check
                return;
            }
            catch (InvalidOperationException)
            {
                // Handle might not be created yet or other invalidation issues
                return;
            }
        }

        private async Task UpdateUIAsync(Dictionary<string, MemberState> copy, FirestoreDb db)
        {
            UpdateParticipantsList(copy, db);
            await UpdatePanels(copy);
        }


        protected override async void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isLeavingRoom)
            {
                e.Cancel = true;
                isLeavingRoom = true;
                sbtn_CancelCall.PerformClick();
                return;
            }

            // Cleanup
            try
            {
                roomListener?.StopAsync();

                if (rtcEngine != null)
                {
                    rtcEngine.LeaveChannel();
                    rtcEngine.Dispose();
                    rtcEngine = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during cleanup: {ex.Message}");
            }

            base.OnFormClosing(e);
        }


        private void listViewParticipants_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3) // Mic or Camera column
            {
                string iconKey = e.SubItem.Tag as string;
                if (!string.IsNullOrEmpty(iconKey) && imageListAvatars.Images.ContainsKey(iconKey))
                {
                    var icon = imageListAvatars.Images[iconKey];
                    e.Graphics.DrawImage(icon, e.Bounds.X + 5, e.Bounds.Y + 2, 16, 16); // Vẽ icon
                }
            }
            else
            {
                e.DrawDefault = true; // Vẽ mặc định cho các cột khác
            }
        }
        private async Task DeleteInvitationsOfRoom(string roomId)
        {
            try
            {
                var db = FirebaseConfig.database;
                var query = db.Collection("Invitations").WhereEqualTo("room_id", roomId);
                var snapshot = await query.GetSnapshotAsync();

                foreach (var doc in snapshot.Documents)
                {
                    await doc.Reference.DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi xóa invitations của phòng: {ex.Message}");
            }
        }

        private async void sbtn_CancelCall_Click(object sender, EventArgs e)
        {

            // Kiểm tra nếu người dùng là host
            if (currentUserId == hostId)
            {
                // Hiển thị thông báo xác nhận xóa phòng
                var result = MessageBox.Show("Bạn là host. Bạn có muốn xóa phòng không? Tất cả thành viên sẽ bị rời phòng.",
                                             "Xác nhận xóa phòng",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Đánh dấu phòng bị xóa bởi host
                    await MarkRoomAsDeletedByHost();

                    await DeleteRoomFromFirestore();
                    await DeleteInvitationsOfRoom(currentroomId); // Xoa cac loi moi cua host doi voi nhung nguoi chua vao phong
                    NotifyMembersRoomClosed();

                    isLeavingRoom = true;
                    this.Close();
                }

            }
            else
            {
                var result = MessageBox.Show("Bạn có chắc muốn rời phòng?", "Xác nhận",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Rời phòng
                    await LeaveRoom();

                    isLeavingRoom = true;
                    this.Close();
                }
            }
        }
        private async Task MarkRoomAsDeletedByHost()
        {
            try
            {
                var db = FirebaseConfig.database;
                var roomRef = db.Collection("Room").Document(currentroomId);

                await roomRef.UpdateAsync(new Dictionary<string, object>
                {
                    { "deleted_by_host", true } // Đánh dấu phòng bị xóa bởi host
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi đánh dấu phòng bị xóa: {ex.Message}");
            }
        }
        private async Task DeletePomodoroSession()
        {
            try
            {
                var db = FirebaseConfig.database;
                await db.Collection("Pomodoro_Sessions").Document(currentroomId).DeleteAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi xóa Pomodoro_Session: {ex.Message}");
            }
        }
        private async Task DeleteRoomFromFirestore()
        {
            isLeavingRoom = true; // Đánh dấu đang rời phòng

            try
            {
                FirestoreDb db = FirebaseConfig.database;
                DocumentReference roomRef = db.Collection("Room").Document(currentroomId);
                await roomRef.DeleteAsync();
                await DeletePomodoroSession();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLeavingRoom = false;
            }
        }
        private void NotifyMembersRoomClosed()
        {
            foreach (var member in memberStates)
            {
                if (member.Key != currentUserId) // Không gửi cho chính host
                {
                    Debug.WriteLine($"Thông báo: Thành viên {member.Key} đã được thông báo phòng đã bị xóa.");

                    // Gửi thông báo thực sự qua Firestore
                    SendNotificationToMember(member.Key);
                }
            }
        }

        private async void SendNotificationToMember(string memberId)
        {
            try
            {
                var db = FirebaseConfig.database;
                var notificationsRef = db.Collection("Notifications").Document(memberId);

                await notificationsRef.SetAsync(new
                {
                    message = "Phòng họp đã bị đóng bởi host",
                    roomId = currentroomId,
                    timestamp = FieldValue.ServerTimestamp,
                    isRead = false
                }, SetOptions.MergeAll);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi gửi thông báo: {ex.Message}");
            }
        }

        private async Task LeaveRoom()
        {
            isLeavingRoom = true;
            try
            {
                var db = FirebaseConfig.database;
                var roomRef = db.Collection("Room").Document(currentroomId);

                var snapshot = await roomRef.GetSnapshotAsync();

                // Nếu phòng đã bị xóa bởi host thì không cần cập nhật trạng thái
                bool deletedByHost = false;
                if (snapshot.TryGetValue("deleted_by_host", out bool flag))
                {
                    deletedByHost = flag;
                }

                if (!snapshot.Exists || deletedByHost)
                {
                    return;
                }

                // Cập nhật trạng thái trước khi xóa
                var updates = new Dictionary<string, object>
                {
                    { $"members_status.{currentUserId}.is_leaving", true }
                };
                await roomRef.UpdateAsync(updates);

                // Xóa user khỏi phòng
                updates = new Dictionary<string, object>
                {
                    { $"members_status.{currentUserId}", FieldValue.Delete }
                };
                await roomRef.UpdateAsync(updates);

                rtcEngine.LeaveChannel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi rời phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLeavingRoom = false;
            }
        }


private async void UpdateParticipantsList(Dictionary<string, MemberState> members, FirestoreDb db)
{
    if (this.IsDisposed || listViewParticipants.IsDisposed) return;

    // Get current host ID
    var roomRef = db.Collection("Room").Document(currentroomId);
    var roomSnapshot = await roomRef.GetSnapshotAsync();
    string currentHostId = roomSnapshot.Exists ? roomSnapshot.GetValue<string>("host_id") : hostId;

    // Create a list of current user IDs in the ListView
    var currentListViewIds = new HashSet<string>();
    var itemsToKeep = new List<ListViewItem>();

    // First pass: identify items to keep and remove duplicates
    foreach (ListViewItem item in listViewParticipants.Items)
    {
        if (item.Tag is string userId)
        {
            if (members.ContainsKey(userId) && !currentListViewIds.Contains(userId))
            {
                // Valid user that should be kept (first occurrence)
                currentListViewIds.Add(userId);
                itemsToKeep.Add(item);
            }
            else
            {
                // Either user no longer exists or is a duplicate
                listViewParticipants.Items.Remove(item);
            }
        }
    }

    listViewParticipants.BeginUpdate();

    // Clear and reinitialize image list but preserve host avatar if exists
    var hostAvatarKey = $"host_{currentHostId}";
    Image hostAvatarImage = null;
    
    if (imageListAvatars.Images.ContainsKey(hostAvatarKey))
    {
        hostAvatarImage = imageListAvatars.Images[hostAvatarKey];
    }

    imageListAvatars.Images.Clear();
    
    // Re-add standard icons
    imageListAvatars.Images.Add("avatar", Properties.Resources.avatar);
    imageListAvatars.Images.Add("mic_on", Properties.Resources.mic_on);
    imageListAvatars.Images.Add("mic_off", Properties.Resources.mic_off);
    imageListAvatars.Images.Add("cam_on", Properties.Resources.cam_on);
    imageListAvatars.Images.Add("cam_off", Properties.Resources.cam_off);
    
    // Re-add host avatar if it existed
    if (hostAvatarImage != null)
    {
        imageListAvatars.Images.Add(hostAvatarKey, hostAvatarImage);
    }

    var memberIds = members.Keys.ToHashSet();
    var allUsers = await db.Collection("User").GetSnapshotAsync();

    Dictionary<string, (string Username, string AvatarKey)> userInfoMap = new();

    // Process host first to ensure their avatar is loaded correctly
    if (!string.IsNullOrEmpty(currentHostId) && memberIds.Contains(currentHostId))
    {
        var hostDoc = await db.Collection("User").Document(currentHostId).GetSnapshotAsync();
        if (hostDoc.Exists)
        {
            var hostData = hostDoc.ToDictionary();
            string username = hostData.ContainsKey("Username") ? hostData["Username"].ToString() : "Host";
            string avatar = hostData.ContainsKey("Avatar") ? hostData["Avatar"]?.ToString() : null;
            
            userInfoMap[currentHostId] = (username, avatar);
            
            // Add host avatar with special key
            if (!string.IsNullOrEmpty(avatar) && !imageListAvatars.Images.ContainsKey(hostAvatarKey))
            {
                Image avatarImage = GetAvatarFromResources(avatar);
                imageListAvatars.Images.Add(hostAvatarKey, avatarImage);
            }
        }
    }

    // Process other users
    foreach (var doc in allUsers.Documents)
    {
        string userId = doc.Id;
        if (userId == currentHostId || !memberIds.Contains(userId)) continue;

        var data = doc.ToDictionary();
        string username = data.ContainsKey("Username") ? data["Username"].ToString() : "User";
        string avatar = data.ContainsKey("Avatar") ? data["Avatar"]?.ToString() : null;

        userInfoMap[userId] = (username, avatar);
    }

    // Update or add members - ensure host is first
    var orderedUserIds = members.Keys.OrderBy(id => id == currentHostId ? 0 : 1).ToList();

    foreach (var userId in orderedUserIds)
    {
        if (!members.TryGetValue(userId, out MemberState state)) continue;
        if (!userInfoMap.TryGetValue(userId, out var userInfo)) continue;

        string username = userInfo.Username;
        string avatarKey = userInfo.AvatarKey;
        string imageKey = userId == currentHostId ? hostAvatarKey : 
                         (!string.IsNullOrEmpty(avatarKey) ? avatarKey : "default_avatar");

        // Find existing item (if any)
        ListViewItem existingItem = itemsToKeep.FirstOrDefault(item => item.Tag as string == userId);

        if (existingItem != null)
        {
            // Update existing item
            existingItem.SubItems[1].Text = username;
            
            // Special handling for host
            if (userId == currentHostId)
            {
                existingItem.ImageKey = hostAvatarKey;
            }
            
            existingItem.SubItems[2].Tag = state.MicOn ? "mic_on" : "mic_off";
            existingItem.SubItems[3].Tag = state.CameraOn ? "cam_on" : "cam_off";
        }
        else
        {
            // Add new item
            if (!listViewParticipants.SmallImageList.Images.ContainsKey(imageKey))
            {
                Image avatarImage = !string.IsNullOrEmpty(avatarKey)
                    ? GetAvatarFromResources(avatarKey)
                    : Properties.Resources.avatar;

                listViewParticipants.SmallImageList.Images.Add(imageKey, avatarImage);
            }

            var item = new ListViewItem { 
                ImageKey = imageKey, 
                Tag = userId 
            };
            item.SubItems.Add(username);
            item.SubItems.Add(""); item.SubItems[2].Tag = state.MicOn ? "mic_on" : "mic_off";
            item.SubItems.Add(""); item.SubItems[3].Tag = state.CameraOn ? "cam_on" : "cam_off";

            listViewParticipants.Items.Add(item);
        }
    }

    listViewParticipants.EndUpdate();
}

        private Image GetAvatarFromResources(string avatarKey)
        {
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

        private async Task EnsureCurrentUserInRoom(FirestoreDb db)
        {
            var roomRef = db.Collection("Room").Document(currentroomId);
            var snapshot = await roomRef.GetSnapshotAsync();

            if (snapshot.Exists &&
                snapshot.TryGetValue<Dictionary<string, object>>("members_status", out var membersDict))
            {
                if (!membersDict.ContainsKey(currentUserId))
                {
                    var updates = new Dictionary<string, object>
            {
                { $"members_status.{currentUserId}", new Dictionary<string, object>
                    {
                        { "camera_on", false },
                        { "mic_on", false },
                        { "speaker_on", true }
                    }
                }
            };
                    await roomRef.UpdateAsync(updates);
                }
            }
        }

        private async void InitializeAgora()
        {
            // 1. Khởi tạo Agora
            rtcEngine = RtcEngine.CreateAgoraRtcEngine();

            var context = new RtcEngineContext { appId = appId };
            int initResult = rtcEngine.Initialize(context);

            // Thêm chính mình vào nếu chưa có
            var db = FirebaseConfig.database;
            await EnsureCurrentUserInRoom(db);

            // 2. Lấy thông tin thành viên từ Firestore
            await GetMembersFromFirestore();

            // 3. Tham gia kênh Agora
            if (rtcEngine != null)
            {
                rtcEngine.JoinChannel("", currentroomId, "", GetUidFromId(currentUserId));
            }
            else
            {

            }

            // 4. Khởi tạo panel cho chính mình (local panel)
            if (memberStates.TryGetValue(currentUserId, out MemberState myState))
            {
                Panel panel = await CreateRemotePanel(currentUserId, 0);
                localVideoPanel = panel;
            }

            // Gọi UI lần đầu luôn để hiển thị ListView và panel ngay
            var copy = new Dictionary<string, MemberState>(memberStates);
            await UpdateUIAsync(copy, db);

            // 5. Bắt đầu lắng nghe dữ liệu realtime từ Firestore
            // Thêm delay 2 giây trước khi bắt đầu lắng nghe
            await Task.Delay(2000);
            ListenToRoomRealtime();

        }


        private Point GetPanelLocation(int index)
        {
            int panelWidth = 230;
            int spacing = 35;
            int startX = 313; // vị trí x của panel đầu tiên
            int y = 617;

            int x = startX + (panelWidth + spacing) * index;
            return new Point(x, y);
        }

        private async Task<Panel> CreateRemotePanel(string userId, int index)
        {
            var panel = new Panel
            {
                Name = $"panel_{userId}",
                Tag = userId,
                Size = new Size(230, 151),
                BackColor = Color.FromArgb(117, 164, 127),
                Location = GetPanelLocation(index),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Wait until the form handle is created
            while (!this.IsHandleCreated && !this.IsDisposed)
            {
                await Task.Delay(100);
            }

            if (!this.IsDisposed)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (!this.IsDisposed && panel != null)
                    {
                        this.Controls.Add(panel);
                        panel.BringToFront();
                    }
                });
            }

            return panel;
        }
        private void CreateExtraPanel(int index, int remainingCount)
        {
            Panel panel = new Panel
            {
                Name = "panel_extra",
                Size = new Size(230, 151),
                BackColor = Color.FromArgb(117, 164, 127),
                Location = GetPanelLocation(index),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label label = new Label
            {
                Text = $"+{remainingCount} người",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point((panel.Width - 120) / 2, (panel.Height - 30) / 2)
            };

            panel.Controls.Add(label);

            this.Invoke(new Action(() =>
            {
                this.Controls.Add(panel);
                panel.BringToFront();
            }));
        }

        private Image MakeRoundedAvatar(Image original, Size size)
        {
            Bitmap rounded = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(rounded))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, size.Width, size.Height);
                    g.SetClip(path);
                    g.DrawImage(original, 0, 0, size.Width, size.Height);
                }
            }
            return rounded;
        }


        private async Task UpdatePanels(Dictionary<string, MemberState> updatedMemberStates)
        {
            int totalMembers = updatedMemberStates.Count;
            int index = 0;

            // Lấy các panel hiện có (trừ panel_extra)
            var currentPanels = this.Controls.OfType<Panel>()
                .Where(p => p.Name.StartsWith("panel_") && p.Name != "panel_extra")
                .ToDictionary(p => p.Name.Replace("panel_", ""), p => p);

            // Xóa các panel không còn trong danh sách
            foreach (var userId in currentPanels.Keys.Except(updatedMemberStates.Keys).ToList())
            {
                this.Invoke(() =>
                {
                    this.Controls.Remove(currentPanels[userId]);
                    currentPanels[userId].Dispose();
                });
            }

            // 👉 Xử lý sắp xếp: hostId lên đầu, currentUserId thứ hai, nếu trùng thì chọn người kế tiếp
            var others = updatedMemberStates.Keys
                .Where(id => id != hostId && id != currentUserId)
                .ToList();

            List<string> orderedIds = new List<string>();

            if (updatedMemberStates.ContainsKey(hostId))
                orderedIds.Add(hostId);

            if (currentUserId != hostId && updatedMemberStates.ContainsKey(currentUserId))
                orderedIds.Add(currentUserId);
            else if (others.Count > 0)
            {
                orderedIds.Add(others[0]); // người kế tiếp nếu currentUserId == hostId
                others.RemoveAt(0);
            }

            // Thêm phần còn lại nếu cần (chỉ hiển thị tối đa 2 người)
            while (orderedIds.Count < 2 && others.Count > 0)
            {
                orderedIds.Add(others[0]);
                others.RemoveAt(0);
            }

            // 👉 Hiển thị tối đa 2 panel người
            foreach (var userId in orderedIds)
            {
                MemberState state = updatedMemberStates[userId];

                Panel panel;
                if (!currentPanels.TryGetValue(userId, out panel))
                {
                    panel = await CreateRemotePanel(userId, index);
                }

                var location = GetPanelLocation(index);
                this.Invoke(() => panel.Location = location);

                await UpdatePanelContent(panel, userId, state);
                index++;
            }

            // 👉 Xử lý panel_extra nếu dư người
            int extraCount = totalMembers - orderedIds.Count;
            var oldExtraPanel = this.Controls.Find("panel_extra", true).FirstOrDefault() as Panel;

            if (extraCount > 0)
            {
                CreateExtraPanel(index, extraCount); // index = 2
            }
            else if (oldExtraPanel != null)
            {
                this.Invoke(() =>
                {
                    this.Controls.Remove(oldExtraPanel);
                    oldExtraPanel.Dispose();
                });
            }
        }


        // Hàm cập nhật trạng thái camera/avatar của panel (gọi trong UpdatePanels)
        private async Task UpdatePanelContent(Panel panel, string userId, MemberState state)
        {
            // Xóa avatar cũ nếu có
            this.Invoke(() =>
            {
                var oldAvatar = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                if (oldAvatar != null)
                {
                    panel.Controls.Remove(oldAvatar);
                    oldAvatar.Dispose();
                }
            });

            // Dừng video hiện tại để set lại
            if (userId == currentUserId)
            {
                rtcEngine.StopPreview();
            }
            else
            {
                rtcEngine.SetupRemoteVideo(new VideoCanvas
                {
                    uid = GetUidFromId(userId),
                    view = IntPtr.Zero // Tắt video remote cũ
                });
            }

            // Cập nhật lại theo trạng thái camera
            if (state.CameraOn)
            {
                var videoCanvas = new VideoCanvas
                {
                    uid = GetUidFromId(userId),
                    renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT,
                    view = panel.Handle
                };

                if (userId == currentUserId)
                {
                    rtcEngine.SetupLocalVideo(videoCanvas);
                    rtcEngine.StartPreview();
                }
                else
                {
                    rtcEngine.SetupRemoteVideo(videoCanvas);
                }
            }
            else
            {
                // Nếu camera tắt, hiển thị avatar
                PictureBox newAvatar = new PictureBox
                {
                    Size = new Size(100, 100),
                    Location = new Point((panel.Width - 100) / 2, (panel.Height - 100) / 2),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.Transparent
                };

                var db = FirebaseConfig.database;
                var userRef = db.Collection("User").Document(userId);
                var userDoc = await userRef.GetSnapshotAsync();

                string avatarKey = userDoc.Exists && userDoc.ContainsField("Avatar")
                    ? userDoc.GetValue<string>("Avatar")
                    : null;

                Image avatarImage = !string.IsNullOrEmpty(avatarKey)
                    ? GetAvatarFromResources(avatarKey)
                    : Properties.Resources.avatar;

                newAvatar.Image = MakeRoundedAvatar(avatarImage, newAvatar.Size);

                this.Invoke(() =>
                {
                    panel.Controls.Add(newAvatar);
                });
            }

            // Refresh panel UI
            this.Invoke(() =>
            {
                panel.Refresh();
            });
        }



        private async Task GetMembersFromFirestore()
        {
            var db = FirebaseConfig.database;
            DocumentReference roomRef = db.Collection("Room").Document(currentroomId);
            DocumentSnapshot snapshot = await roomRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                // Lấy host_id
                hostId = snapshot.GetValue<string>("host_id");

                // Lấy thông tin thành viên từ members_status
                if (snapshot.TryGetValue<Dictionary<string, object>>("members_status", out var membersDict))
                {
                    foreach (var entry in membersDict)
                    {
                        string userId = entry.Key;
                        var data = entry.Value as Dictionary<string, object>;
                        if (data == null) continue;

                        bool cameraOn = data.ContainsKey("camera_on") && Convert.ToBoolean(data["camera_on"]);
                        bool micOn = data.ContainsKey("mic_on") && Convert.ToBoolean(data["mic_on"]);
                        bool speakerOn = data.ContainsKey("speaker_on") && Convert.ToBoolean(data["speaker_on"]);

                        memberStates[userId] = new MemberState
                        {
                            UserId = userId,
                            CameraOn = cameraOn,
                            MicOn = micOn,
                            SpeakerOn = speakerOn
                        };
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy trường 'members_status' trong Firestore.");
                }
            }
            else
            {
                MessageBox.Show("Phòng không tồn tại.");
            }
        }

        private async Task UpdateCameraStateAsync(string userId, bool turnOn)
        {
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").Document(currentroomId);

            // Cập nhật trạng thái camera cho user trong members_status
            await roomRef.UpdateAsync($"members_status.{userId}.camera_on", turnOn);
        }

        private async void btn_Camera_Click(object sender, EventArgs e)
        {
            bool currentCameraState = memberStates.ContainsKey(currentUserId) && memberStates[currentUserId].CameraOn;
            bool newCameraState = !currentCameraState;

            // Cập nhật trạng thái camera trên Firestore
            await UpdateCameraStateAsync(currentUserId, newCameraState);

            // Cập nhật trạng thái trong bộ nhớ local
            if (memberStates.ContainsKey(currentUserId))
            {
                memberStates[currentUserId].CameraOn = newCameraState;
            }

            // Đổi icon nút camera
            btn_Camera.BackgroundImage = newCameraState ? Properties.Resources.videocam : Properties.Resources.videocam_off;

            // Tìm lại panel đã gán cho chính người dùng hiện tại
            var panel = this.Controls.Find($"panel_{currentUserId}", true).FirstOrDefault() as Panel;
            if (panel != null)
            {
                await UpdatePanelContent(panel, currentUserId, memberStates[currentUserId]);
            }
        }

        class MemberState
        {
            public string UserId { get; set; }
            public bool CameraOn { get; set; }
            public bool MicOn { get; set; }
            public bool SpeakerOn { get; set; }
        }

        private void sbtn_ChangeHost_Click(object sender, EventArgs e)
        {
            Host host = new Host(currentUserId, currentroomId);
            host.ShowDialog();
        }

        private async Task UpdateMicStateAsync(string userId, bool turnOn)
        {
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").Document(currentroomId);

            // Cập nhật trạng thái mic cho user trong members_status
            await roomRef.UpdateAsync($"members_status.{userId}.mic_on", turnOn);
        }

        private async void btn_Mic_Click(object sender, EventArgs e)
        {
            bool currentMicState = memberStates.ContainsKey(currentUserId) && memberStates[currentUserId].MicOn;
            bool newMicState = !currentMicState;

            // Cập nhật trạng thái mic trong Firestore
            await UpdateMicStateAsync(currentUserId, newMicState);

            // Cập nhật trạng thái local
            if (memberStates.ContainsKey(currentUserId))
            {
                memberStates[currentUserId].MicOn = newMicState;
            }

            // Đổi icon nút mic
            btn_Mic.BackgroundImage = newMicState ? Properties.Resources.mic : Properties.Resources.videomic_off;

            // Bật hoặc tắt mic
            rtcEngine.MuteLocalAudioStream(!newMicState);
        }

        private async Task UpdateSpeakerStateAsync(string userId, bool turnOn)
        {
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").Document(currentroomId);

            // Cập nhật trạng thái loa cho user trong members_status
            await roomRef.UpdateAsync($"members_status.{userId}.speaker_on", turnOn);
        }

        private async void btn_Speaker_Click(object sender, EventArgs e)
        {
            bool currentSpeakerState = memberStates.ContainsKey(currentUserId) && memberStates[currentUserId].SpeakerOn;
            bool newSpeakerState = !currentSpeakerState;

            // 1. Cập nhật trạng thái loa trong Firestore
            await UpdateSpeakerStateAsync(currentUserId, newSpeakerState);

            // 2. Cập nhật trạng thái loa trong bộ nhớ local
            if (memberStates.ContainsKey(currentUserId))
            {
                memberStates[currentUserId].SpeakerOn = newSpeakerState;
            }

            // 3. Thay đổi icon nút loa theo trạng thái
            btn_Speaker.BackgroundImage = newSpeakerState
                ? Properties.Resources.icon_sound_on   // icon loa đang bật
                : Properties.Resources.speaker_mute; // icon loa đang tắt

            // 4. Xử lý bật/tắt âm thanh 
            if (newSpeakerState)
            {
                rtcEngine.SetEnableSpeakerphone(true); // bật loa ngoài
            }
            else
            {
                rtcEngine.SetEnableSpeakerphone(false); // tắt loa ngoài, chuyển sang tai nghe nếu có
            }
        }
    }
}
