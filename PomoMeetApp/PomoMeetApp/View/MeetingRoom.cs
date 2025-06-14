﻿using Google.Cloud.Firestore;
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
        private FirestoreChangeListener messageListener;

        private string appId = "4b8519068a154d67981912816c14c56f";
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
            this.Load += MeetingRoom_Load;
            
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
                messageListener?.StopAsync();
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

                    var item = new ListViewItem
                    {
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

        // Class event handler
        public class MyRtcEngineEventHandler : RtcEngineEventHandler
        {
            private readonly Action<string, uint, int> onJoinSuccessCallback;
            private readonly Action<uint> onUserJoinedCallback;
            private readonly Action<uint, USER_OFFLINE_REASON_TYPE> onUserOfflineCallback;
            private readonly Action<uint, REMOTE_VIDEO_STATE, REMOTE_VIDEO_STATE_REASON, int> onRemoteVideoStateChangedCallback;

            public MyRtcEngineEventHandler(
                Action<string, uint, int> onJoinSuccess,
                Action<uint> onUserJoined = null,
                Action<uint, USER_OFFLINE_REASON_TYPE> onUserOffline = null,
                Action<uint, REMOTE_VIDEO_STATE, REMOTE_VIDEO_STATE_REASON, int> onRemoteVideoStateChanged = null)
            {
                onJoinSuccessCallback = onJoinSuccess;
                onUserJoinedCallback = onUserJoined;
                onUserOfflineCallback = onUserOffline;
                onRemoteVideoStateChangedCallback = onRemoteVideoStateChanged;
            }

            public override void OnJoinChannelSuccess(RtcConnection connection, int elapsed)
            {
                Debug.WriteLine($"OnJoinChannelSuccess: channel={connection.channelId}, uid={connection.localUid}");
                onJoinSuccessCallback?.Invoke(connection.channelId, connection.localUid, elapsed);
            }

            public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
            {
                Debug.WriteLine($"OnUserJoined: uid={remoteUid}");
                onUserJoinedCallback?.Invoke(remoteUid);
            }

            public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
            {
                Debug.WriteLine($"OnUserOffline: uid={remoteUid}, reason={reason}");
                onUserOfflineCallback?.Invoke(remoteUid, reason);
            }

            public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
            {
                Debug.WriteLine($"OnRemoteVideoStateChanged: uid={remoteUid}, state={state}, reason={reason}");
                onRemoteVideoStateChangedCallback?.Invoke(remoteUid, state, reason, elapsed);
            }

            // Thêm callback để xử lý khi có first remote video frame
            public override void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
            {
                Debug.WriteLine($"OnFirstRemoteVideoFrame: uid={remoteUid}, size={width}x{height}");
                base.OnFirstRemoteVideoFrame(connection, remoteUid, width, height, elapsed);
            }
        }

        // Callback xử lý khi join thành công, đảm bảo chạy trên UI thread
        private void OnJoinSuccess(string channelId, uint uid, int elapsed)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnJoinSuccess(channelId, uid, elapsed)));
                return;
            }
            MessageBox.Show($"Đã join channel {channelId} thành công với uid {uid}, elapsed = {elapsed}ms");
        }

        // 5. Cập nhật callback OnUserJoined
        private void OnUserJoined(uint remoteUid)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnUserJoined(remoteUid)));
                return;
            }

            Debug.WriteLine($"Remote user joined: {remoteUid}");

            // Tìm userId từ remoteUid
            string remoteUserId = FindUserIdByUid(remoteUid);
            if (!string.IsNullOrEmpty(remoteUserId))
            {
                Debug.WriteLine($"Found user ID: {remoteUserId} for UID: {remoteUid}");

                // Đảm bảo subscribe remote video stream
                rtcEngine.MuteRemoteVideoStream(remoteUid, false);
                rtcEngine.MuteRemoteAudioStream(remoteUid, false);

                // Trigger update UI để setup remote video
                if (memberStates.ContainsKey(remoteUserId))
                {
                    var copy = new Dictionary<string, MemberState>(memberStates);
                    _ = UpdateUIAsync(copy, FirebaseConfig.database);
                }
            }
        }

        // 6. Thêm helper function để tìm userId từ uid
        private string FindUserIdByUid(uint uid)
        {
            foreach (var userId in memberStates.Keys)
            {
                if (GetUidFromId(userId) == uid)
                {
                    return userId;
                }
            }
            return null;
        }

        private void OnUserOffline(uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnUserOffline(remoteUid, reason)));
                return;
            }
            MessageBox.Show($"Remote user offline: {remoteUid}, reason: {reason}");
        }

        private void OnRemoteVideoStateChanged(uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnRemoteVideoStateChanged(remoteUid, state, reason, elapsed)));
                return;
            }

            Debug.WriteLine($"Remote video state changed: uid={remoteUid}, state={state}, reason={reason}");

            string remoteUserId = FindUserIdByUid(remoteUid);
            if (!string.IsNullOrEmpty(remoteUserId))
            {
                // Xử lý khi có video stream
                if (state == REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STARTING ||
                    state == REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_DECODING)
                {
                    Debug.WriteLine($"Remote video starting/decoding for user: {remoteUserId}");

                    // Đảm bảo unmute remote video
                    rtcEngine.MuteRemoteVideoStream(remoteUid, false);

                    // Update UI
                    var copy = new Dictionary<string, MemberState>(memberStates);
                    _ = UpdateUIAsync(copy, FirebaseConfig.database);
                }
                else if (state == REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STOPPED)
                {
                    Debug.WriteLine($"Remote video stopped for user: {remoteUserId}");

                    // Update UI to show avatar
                    var copy = new Dictionary<string, MemberState>(memberStates);
                    _ = UpdateUIAsync(copy, FirebaseConfig.database);
                }
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
            // 1. Tạo handler event
            var handler = new MyRtcEngineEventHandler(
                OnJoinSuccess,
                OnUserJoined,
                OnUserOffline,
                OnRemoteVideoStateChanged
            );

            // 2. Khởi tạo Agora engine
            rtcEngine = RtcEngine.CreateAgoraRtcEngine();

            var context = new RtcEngineContext
            {
                appId = appId,
                logConfig = new LogConfig
                {
                    filePath = "agora.log",
                    level = LOG_LEVEL.LOG_LEVEL_INFO
                }
            };

            int initResult = rtcEngine.Initialize(context);
            Debug.WriteLine($"RTC Engine Initialize result: {initResult}");

            // 3. Gán handler event
            rtcEngine.InitEventHandler(handler);

            // 4. Cấu hình video
            rtcEngine.EnableVideo();
            rtcEngine.EnableAudio();

            var videoDeviceManager = rtcEngine.GetVideoDeviceManager();
            var devices = videoDeviceManager.EnumerateVideoDevices();
            foreach (var device in devices)
            {
                if (device.deviceName.ToLower().Contains("obs"))
                {
                    videoDeviceManager.SetDevice(device.deviceId);
                    break;
                }
            }

            // 5. Cấu hình video encoding
            var videoConfig = new VideoEncoderConfiguration
            {
                dimensions = new VideoDimensions(640, 480),
                frameRate = 15,
                bitrate = 400,
                orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE
            };
            rtcEngine.SetVideoEncoderConfiguration(videoConfig);

            // 6. Cấu hình channel profile và client role
            rtcEngine.SetChannelProfile(CHANNEL_PROFILE_TYPE.CHANNEL_PROFILE_COMMUNICATION);
            rtcEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_BROADCASTER);

            // 7. Đảm bảo subscribe tất cả remote streams
            rtcEngine.SetDefaultMuteAllRemoteVideoStreams(false);
            rtcEngine.SetDefaultMuteAllRemoteAudioStreams(false);

            // Enable dual stream mode để có thể receive remote video
            rtcEngine.EnableDualStreamMode(true);

            // 8. Thêm user vào Firestore nếu chưa có
            var db = FirebaseConfig.database;
            await EnsureCurrentUserInRoom(db);

            // 9. Lấy thông tin thành viên
            await GetMembersFromFirestore();

            // 10. Tham gia kênh
            uint localUid = GetUidFromId(currentUserId);
            int result = rtcEngine.JoinChannel("", currentroomId, "", localUid);
            Debug.WriteLine($"Join Channel result: {result}, LocalUID: {localUid}");

            // 11. Tắt mic và camera mặc định
            rtcEngine.MuteLocalAudioStream(true);
            rtcEngine.MuteLocalVideoStream(true);

            // 12. Lắng nghe realtime Firestore
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

        private Panel CreateRemotePanel(string userId, int index)
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
                    panel = CreateRemotePanel(userId, index);
                }

                var location = GetPanelLocation(index);
                this.Invoke(() => {
                    panel.Location = location;
                    panel.BringToFront(); // Đảm bảo panel này nằm trên cùng
                });

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

            uint uid = GetUidFromId(userId);

            if (state.CameraOn)
            {
                if (userId == currentUserId)
                {
                    // Xử lý video local
                    var videoCanvas = new VideoCanvas
                    {
                        uid = uid,
                        renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT,
                        view = panel.Handle
                    };

                    int setupResult = rtcEngine.SetupLocalVideo(videoCanvas);
                    Debug.WriteLine($"SetupLocalVideo result: {setupResult}");

                    // Bật preview và unmute local video
                    rtcEngine.StartPreview();
                    rtcEngine.MuteLocalVideoStream(false);
                }
                else
                {
                    // Xử lý video remote
                    var remoteVideoCanvas = new VideoCanvas
                    {
                        uid = uid,
                        renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT,
                        view = panel.Handle
                    };

                    int result = rtcEngine.SetupRemoteVideo(remoteVideoCanvas);
                    Debug.WriteLine($"SetupRemoteVideo for uid {uid}: result = {result}");

                    // Đảm bảo unmute remote video
                    rtcEngine.MuteRemoteVideoStream(uid, false);

                    // Set remote video stream type
                    rtcEngine.SetRemoteVideoStreamType(uid, VIDEO_STREAM_TYPE.VIDEO_STREAM_HIGH);
                }
            }
            else
            {
                // Tắt video và hiển thị avatar
                if (userId == currentUserId)
                {
                    rtcEngine.StopPreview();
                    rtcEngine.MuteLocalVideoStream(true);

                    // Clear local video canvas
                    var emptyCanvas = new VideoCanvas
                    {
                        uid = uid,
                        view = IntPtr.Zero
                    };
                    rtcEngine.SetupLocalVideo(emptyCanvas);
                }
                else
                {
                    // Mute và clear remote video canvas
                    rtcEngine.MuteRemoteVideoStream(uid, true);

                    var emptyCanvas = new VideoCanvas
                    {
                        uid = uid,
                        view = IntPtr.Zero
                    };
                    rtcEngine.SetupRemoteVideo(emptyCanvas);
                }

                // Hiển thị avatar
                await ShowAvatarOnPanel(panel, userId);
            }

            // Refresh UI
            this.Invoke(() =>
            {
                panel.Refresh();
            });
        }

        private async Task ShowAvatarOnPanel(Panel panel, string userId)
        {
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

            Debug.WriteLine($"Camera button clicked: {currentCameraState} -> {newCameraState}");

            // Cập nhật trạng thái camera trên Firestore
            await UpdateCameraStateAsync(currentUserId, newCameraState);

            // Cập nhật trạng thái trong bộ nhớ local
            if (memberStates.ContainsKey(currentUserId))
            {
                memberStates[currentUserId].CameraOn = newCameraState;
            }

            // Đổi icon nút camera
            btn_Camera.BackgroundImage = newCameraState ? Properties.Resources.videocam : Properties.Resources.videocam_off;

            // Xử lý bật/tắt camera ngay lập tức
            if (newCameraState)
            {
                rtcEngine.MuteLocalVideoStream(false);
            }
            else
            {
                rtcEngine.MuteLocalVideoStream(true);
                rtcEngine.StopPreview();
            }

            // Tìm lại panel đã gán cho chính người dùng hiện tại và cập nhật
            var copy = new Dictionary<string, MemberState>(memberStates);
            await UpdateUIAsync(copy, FirebaseConfig.database);
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

            Debug.WriteLine($"Mic button clicked: {currentMicState} -> {newMicState}");

            // Cập nhật trạng thái mic trong Firestore
            await UpdateMicStateAsync(currentUserId, newMicState);

            // Cập nhật trạng thái local
            if (memberStates.ContainsKey(currentUserId))
            {
                memberStates[currentUserId].MicOn = newMicState;
            }

            // Đổi icon nút mic
            btn_Mic.BackgroundImage = newMicState ? Properties.Resources.mic : Properties.Resources.videomic_off;

            // Bật hoặc tắt mic ngay lập tức
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void MeetingRoom_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Loaded");
            ListenMessage();
        }
        private async void btnSendMessages_Click(object sender, EventArgs e)
        {
            string msg = tbMessages.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("Message is empty, button disabled.", "btnSendMessages_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                string messageId = Guid.NewGuid().ToString();
                var message = new Dictionary<string, object>
                {
                    { "room_id", currentroomId },
                    { "user_id", currentUserId },
                    { "message", msg },
                    { "created_at", Timestamp.GetCurrentTimestamp() }
                };
                var db = FirebaseConfig.database;
                var messageRef = db.Collection("Messages").Document(messageId);
                await messageRef.SetAsync(message);
                MessageBox.Show($"Sent message: {msg}, Document ID: {messageId}", "btnSendMessages_Click", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbMessages.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "btnSendMessages_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // hàm lấy realtime message
        private void ListenMessage()
        {
            var db = FirebaseConfig.database;
            var messagesRef = db.Collection("Messages")
                               .WhereEqualTo("room_id", currentroomId)
                               .OrderBy("created_at");

            Debug.WriteLine($"[ListenMessage] Starting listener for room: {currentroomId}");

            messageListener = messagesRef.Listen(async snapshot =>
            {
                Debug.WriteLine($"[ListenMessage] Snapshot received with {snapshot.Changes.Count} changes.");

                if (isLeavingRoom)
                {
                    Debug.WriteLine("[ListenMessage] Skipped: Room is being left.");
                    return;
                }

                await Task.Run(async () =>
                {
                    var db = FirebaseConfig.database;

                    foreach (var doc in snapshot.Documents)
                    {
                        var messageData = doc.ToDictionary();
                        string userId = messageData.GetValueOrDefault("user_id", "").ToString();
                        string messageText = messageData.GetValueOrDefault("message", "").ToString();
                        var createdAt = messageData.ContainsKey("created_at") && messageData["created_at"] is Timestamp
                            ? ((Timestamp)messageData["created_at"]).ToDateTime().ToString("HH:mm")
                            : DateTime.Now.ToString("HH:mm");

                        // Lấy username
                        string username = "Unknown";
                        try
                        {
                            var userRef = db.Collection("User").Document(userId);
                            var userDoc = await userRef.GetSnapshotAsync();
                            if (userDoc.Exists)
                                username = userDoc.GetValue<string>("Username") ?? "Unknown";
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"[ListenMessage] Error fetching username: {ex.Message}");
                        }

                        
                        this.Invoke(new Action(() =>
                        {
                            if (tbDisplayMsg == null || tbDisplayMsg.IsDisposed) return;

                            tbDisplayMsg.SelectionStart = tbDisplayMsg.TextLength;
                            tbDisplayMsg.SelectionColor = userId == currentUserId ? Color.Blue : Color.Black;
                            tbDisplayMsg.AppendText($"[{createdAt}] {username}: {messageText}\n");

                            tbDisplayMsg.SelectionStart = tbDisplayMsg.Text.Length;
                            tbDisplayMsg.ScrollToCaret();
                        }));
                    }
                });
            });
        }


    }
}
