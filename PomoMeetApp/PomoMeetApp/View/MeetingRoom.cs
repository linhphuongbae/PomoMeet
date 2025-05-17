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

            // Giả sử listViewParticipants đã được khởi tạo trong InitializeComponent()
            listViewParticipants.SmallImageList = imageListAvatars;
            listViewParticipants.DrawSubItem += listViewParticipants_DrawSubItem;

            // Thêm dữ liệu mẫu
            var item = new ListViewItem();
            item.ImageKey = "avatar";
            item.SubItems.Add("People 1");
            item.SubItems.Add("");
            item.SubItems.Add("");
            item.SubItems[2].Tag = "mic_on";
            item.SubItems[3].Tag = "cam_off";
            listViewParticipants.Items.Add(item);
        }

        private uint GetUidFromId(string id)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(id));
            return BitConverter.ToUInt32(hash, 0); // Lấy 4 byte đầu
        }

        Dictionary<string, MemberState> memberStates = new Dictionary<string, MemberState>();

        private void ListenToRoomRealtime()
        {
            var db = FirebaseConfig.database;
            var docRef = db.Collection("Room").Document(currentroomId);

            docRef.Listen(async snapshot =>
            {
                if (!snapshot.Exists)
                {
                    this.Invoke(() =>
                    {
                        MessageBox.Show("Phòng đã bị xóa!");
                        this.Close();
                    });
                    return;
                }

                if (!snapshot.TryGetValue("members_status", out Dictionary<string, object> membersStatus))
                    return;

                // Nếu bị kick khỏi phòng (user không còn trong members_status)
                if (!membersStatus.ContainsKey(currentUserId))
                {
                    this.Invoke(() =>
                    {
                        MessageBox.Show("Bạn đã bị đá khỏi phòng!");
                        this.Close();
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
                this.BeginInvoke(new Action(() =>
                {
                    _ = UpdateUIAsync(copy, db);
                }));
            });
        }
        private async Task UpdateUIAsync(Dictionary<string, MemberState> copy, FirestoreDb db)
        {
            UpdateParticipantsList(copy, db);
            await UpdatePanels(copy);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            roomListener?.StopAsync();
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void sbtn_CancelCall_Click(object sender, EventArgs e)
        {
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").Document(currentroomId);

            try
            {
                var snapshot = await roomRef.GetSnapshotAsync();
                if (snapshot.Exists && snapshot.TryGetValue("members_status", out Dictionary<string, object> membersStatus))
                {
                    if (membersStatus.ContainsKey(currentUserId))
                    {
                        membersStatus.Remove(currentUserId);  // Xóa key currentUserId khỏi dictionary
                        await roomRef.UpdateAsync("members_status", membersStatus);
                    }
                }

                this.DialogResult = DialogResult.OK; // Đóng form sau khi rời phòng
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi rời phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void UpdateParticipantsList(Dictionary<string, MemberState> members, FirestoreDb db)
        {
            if (this.IsDisposed || listViewParticipants.IsDisposed) return;

            listViewParticipants.Items.Clear();

            foreach (var entry in members)
            {
                string userId = entry.Key;
                MemberState state = entry.Value;

                // Lấy thông tin người dùng từ Firestore
                var userRef = db.Collection("User").Document(userId);
                var userDoc = await userRef.GetSnapshotAsync();

                if (userDoc.Exists)
                {
                    var userData = userDoc.ToDictionary();
                    string username = userData.ContainsKey("Username") ? userData["Username"].ToString() : "Unknown";
                    string avatarKey = userData.ContainsKey("Avatar") ? userData["Avatar"]?.ToString() : null;

                    // Nếu không có avatarKey thì dùng "default_avatar"
                    string imageKey = !string.IsNullOrEmpty(avatarKey) ? avatarKey : "default_avatar";

                    // Nếu ImageList chưa có ảnh này thì thêm vào
                    if (!listViewParticipants.SmallImageList.Images.ContainsKey(imageKey))
                    {
                        Image avatarImage = !string.IsNullOrEmpty(avatarKey)
                            ? GetAvatarFromResources(avatarKey)
                            : Properties.Resources.avatar;

                        listViewParticipants.SmallImageList.Images.Add(imageKey, avatarImage);
                    }

                    var item = new ListViewItem
                    {
                        ImageKey = imageKey
                    };

                    item.SubItems.Add(username);

                    var micState = state.MicOn ? "mic_on" : "mic_off";
                    var camState = state.CameraOn ? "cam_on" : "cam_off";

                    item.SubItems.Add(""); item.SubItems[2].Tag = micState;
                    item.SubItems.Add(""); item.SubItems[3].Tag = camState;

                    listViewParticipants.Items.Add(item);
                }
            }
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

        private async void InitializeAgora()
        {
            // 1. Khởi tạo Agora
            rtcEngine = RtcEngine.CreateAgoraRtcEngine();
            var context = new RtcEngineContext { appId = appId };
            rtcEngine.Initialize(context);

            // 2. Lấy thông tin thành viên từ Firestore
            await GetMembersFromFirestore();

            // 3. Tham gia kênh Agora
            rtcEngine.JoinChannel("", currentroomId, "", GetUidFromId(currentUserId));

            // 4. Khởi tạo panel cho chính mình (local panel)
            if (memberStates.TryGetValue(currentUserId, out MemberState myState))
            {
                Panel panel = await CreateRemotePanel(currentUserId, 0);
                localVideoPanel = panel;
            }

            // 5. Bắt đầu lắng nghe dữ liệu realtime từ Firestore
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

            this.Invoke(() =>
            {
                this.Controls.Add(panel);
                panel.BringToFront();
            });

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
