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
using NAudio.Wave;


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

        private System.Windows.Forms.Timer pomoTimer;
        private DateTime pomodoroStartTime;
        private int countdownTime;

        private Image[] backgroundImages;
        private byte[][] songBytes;

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFileReader;

        private System.Windows.Forms.Timer musicProgressTimer;
        private string cachedMusicPath = null;
        private int musicTotalSeconds;
        private int currentMusicSeconds;
        private long pausedMusicPosition = 0;

        private string[] songNames;
        private Image[] songImages;


        private int musicIndex;
        private int backgroundIndex;

        private bool isPomodoroRunning = false;

        private int breakDuration;  // Break minutes
        private bool isBreakTime;
        private readonly object memberStatesLock = new object();


        public MeetingRoom(string userId, string roomId)
        {
            InitializeComponent();
            currentUserId = userId;
            currentroomId = roomId;

            LoadUserData();
            InitializeUserProfile();
            InitializeMeetingRoomComponents();
            InitializeMediaResources();

            this.Load += MeetingRoom_Load;
            tb_FindParticipants.TextChanged += Tb_Search_TextChanged;


        }

        private async void MeetingRoom_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            InitializeAgora();
            ListenMessage();
        }

        private void InitializeMediaResources()
        {
            backgroundImages = new Image[]
            {
                Properties.Resources.Image,
                Properties.Resources.studyBackground1,
                Properties.Resources.studyBackground2,
                Properties.Resources.studyBackground3,
            };

            songNames = new string[] { "4'O Clock", "5-32PM", "Alone", "Beneath the Rain", "Better Days", "Childhood Dreams", "Your Smile" };
            songImages = new Image[] {
                Properties.Resources.musicImage1,
                Properties.Resources.musicImage2,
                Properties.Resources.musicImage3,
                Properties.Resources.musicImage4,
                Properties.Resources.musicImage5,
                Properties.Resources.musicImage6,
                Properties.Resources.musicImage7
            };
            songBytes = new byte[][] {
                Properties.Resources._4_O_Clock,
                Properties.Resources._5_32PM,
                Properties.Resources.Alone,
                Properties.Resources.BeneathTheRain,
                Properties.Resources.BetterDays,
                Properties.Resources.ChildhoodDreams,
                Properties.Resources.YourSmile
            };
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

            var PomodoroRef = FirebaseConfig.database.Collection("Pomodoro_Sessions").Document(currentroomId);
            PomodoroRef.Listen(snapshot =>
            {
                if (!snapshot.Exists) return;
                var data = snapshot.ToDictionary();

                SafeInvoke(() =>
                {
                    try
                    {
                        // 1. Background
                        if (data.TryGetValue("background_id", out var bgId) &&
                            int.TryParse(bgId?.ToString(), out int bgIndex))
                        {
                            backgroundIndex = bgIndex;
                            SetBackgroundFromArray(backgroundIndex);
                        }

                        // 2. Nhạc
                        if (data.TryGetValue("music_id", out var musicId) &&
                            int.TryParse(musicId?.ToString(), out int mIndex))
                        {
                            musicIndex = mIndex;
                        }

                        // 3. Thời gian Pomodoro và Break
                        if (data.TryGetValue("countdown_time", out var countdownObj) &&
                            int.TryParse(countdownObj?.ToString(), out int cdTime))
                        {
                            countdownTime = cdTime;
                        }
                        else
                        {
                            countdownTime = 25; // fallback mặc định
                        }

                        if (data.TryGetValue("break_time", out var breakObj) &&
                            int.TryParse(breakObj?.ToString(), out int bkTime))
                        {
                            breakDuration = bkTime;
                        }
                        else
                        {
                            breakDuration = 5; // fallback mặc định
                        }

                        // 4. Trạng thái break/pomodoro
                        if (data.TryGetValue("is_break_time", out var isBreakObj) && isBreakObj is bool isBreak)
                        {
                            isBreakTime = isBreak;
                        }

                        // 5. Trạng thái chạy
                        if (data.TryGetValue("is_running", out var isRunningObj) && isRunningObj is bool isRunning)
                        {
                            isPomodoroRunning = isRunning;
                        }

                        // 6. Parse thời gian
                        string startTimeStr = data.TryGetValue("start_time", out var s) ? s?.ToString() : null;
                        string pausedStr = data.TryGetValue("paused_time", out var p2) ? p2?.ToString() : null;

                        DateTime? startTime = DateTime.TryParse(startTimeStr, out var parsedStart) ? parsedStart.ToUniversalTime() : (DateTime?)null;
                        DateTime? pausedTime = DateTime.TryParse(pausedStr, out var parsedPause2) ? parsedPause2.ToUniversalTime() : (DateTime?)null;

                        // 7. Cập nhật nút Start
                        btn_Start.Text = isPomodoroRunning ? "Pause" : (pausedTime != null ? "Resume" : "Start");

                        // 8. Điều khiển logic hiển thị và chạy đếm ngược
                        if (isPomodoroRunning && startTime != null)
                        {
                            StartPomodoroCountdown(startTime.Value);
                        }
                        else if (!isPomodoroRunning && startTime != null && pausedTime != null)
                        {
                            PausePomodoro();
                        }
                        else
                        {
                            // Chưa start, chỉ mới chuyển Pomodoro/Break
                            StopPomodoro(resetUI: true);

                            int duration = isBreakTime ? breakDuration : countdownTime;
                            duration = Math.Max(0, Math.Min(360, duration)); // Clamp: tránh âm hoặc quá lớn

                            lb_time_counter.Text = TimeSpan.FromMinutes(duration).ToString(@"mm\:ss");

                            // Reset các thành phần UI liên quan nhạc
                            ProgressBarMusic.Value = 0;
                            lb_CurrentTime.Text = "00:00";
                            lb_TotalTime.Text = "--:--";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xử lý dữ liệu Pomodoro: " + ex.Message);
                    }
                });
            });


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

                lock (memberStatesLock)
                {
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
                }

                // Sau khi update xong, tạo bản sao an toàn để dùng
                var copy = new Dictionary<string, MemberState>();
                lock (memberStatesLock)
                {
                    foreach (var kvp in memberStates)
                    {
                        copy[kvp.Key] = kvp.Value;
                    }
                }

                SafeInvoke(() =>
                {
                    _ = UpdateUIAsync(copy, db);
                });

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

        private bool isUpdatingParticipants = false;

        Dictionary<string, (string Username, string AvatarKey)> userInfoMapGlobal = new();

        private async void UpdateParticipantsList(Dictionary<string, MemberState> members, FirestoreDb db)
        {
            if (this.IsDisposed || listViewParticipants.IsDisposed) return;
            if (isUpdatingParticipants) return;

            isUpdatingParticipants = true;
            listViewParticipants.BeginUpdate();

            try
            {
                // 1. Lấy host_id
                var roomRef = db.Collection("Room").Document(currentroomId);
                var roomSnapshot = await roomRef.GetSnapshotAsync();
                string currentHostId = roomSnapshot.Exists ? roomSnapshot.GetValue<string>("host_id") : hostId;

                // 2. Xoá tất cả item cũ
                listViewParticipants.Items.Clear();

                // 3. Chuẩn bị avatar
                var hostAvatarKey = $"host_{currentHostId}";
                Image hostAvatarImage = imageListAvatars.Images.ContainsKey(hostAvatarKey)
                    ? imageListAvatars.Images[hostAvatarKey]
                    : null;

                imageListAvatars.Images.Clear();
                imageListAvatars.Images.Add("avatar", Properties.Resources.avatar);
                imageListAvatars.Images.Add("mic_on", Properties.Resources.mic_on);
                imageListAvatars.Images.Add("mic_off", Properties.Resources.mic_off);
                imageListAvatars.Images.Add("cam_on", Properties.Resources.cam_on);
                imageListAvatars.Images.Add("cam_off", Properties.Resources.cam_off);

                if (hostAvatarImage != null)
                {
                    imageListAvatars.Images.Add(hostAvatarKey, hostAvatarImage);
                }

                // 4. Cập nhật userInfoMapGlobal nếu chưa có
                if (userInfoMapGlobal.Count == 0)
                {
                    var allUsers = await db.Collection("User").GetSnapshotAsync();
                    foreach (var doc in allUsers.Documents)
                    {
                        string userId = doc.Id;
                        var data = doc.ToDictionary();
                        string username = data.ContainsKey("Username") ? data["Username"].ToString() : "User";
                        string avatar = data.ContainsKey("Avatar") ? data["Avatar"]?.ToString() : null;

                        userInfoMapGlobal[userId] = (username, avatar);
                    }
                }

                // 5. Lọc thông tin user cho danh sách đang hiển thị
                var userInfoMapLocal = new Dictionary<string, (string Username, string AvatarKey)>();
                foreach (var id in members.Keys)
                {
                    if (userInfoMapGlobal.TryGetValue(id, out var info))
                    {
                        userInfoMapLocal[id] = info;
                    }
                }

                // 6. Thêm từng thành viên vào listview
                var orderedUserIds = members.Keys.OrderBy(id => id == currentHostId ? 0 : 1).ToList();

                foreach (var userId in orderedUserIds)
                {
                    if (!members.TryGetValue(userId, out var state)) continue;
                    if (!userInfoMapLocal.TryGetValue(userId, out var userInfo)) continue;

                    string username = userInfo.Username;
                    string avatarKey = userInfo.AvatarKey;
                    string imageKey = userId == currentHostId ? hostAvatarKey :
                                     (!string.IsNullOrEmpty(avatarKey) ? avatarKey : "avatar");

                    if (!imageListAvatars.Images.ContainsKey(imageKey) && !string.IsNullOrEmpty(avatarKey))
                    {
                        Image avatarImage = GetAvatarFromResources(avatarKey);
                        imageListAvatars.Images.Add(imageKey, avatarImage);
                    }

                    var item = new ListViewItem
                    {
                        ImageKey = imageKey,
                        Tag = userId,
                        Text = ""
                    };

                    item.SubItems.Add(username); // Tên
                    item.SubItems.Add("");       // Mic
                    item.SubItems[2].Tag = state.MicOn ? "mic_on" : "mic_off";
                    item.SubItems.Add("");       // Cam
                    item.SubItems[3].Tag = state.CameraOn ? "cam_on" : "cam_off";

                    listViewParticipants.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật danh sách thành viên: " + ex.Message);
            }
            finally
            {
                listViewParticipants.EndUpdate();
                isUpdatingParticipants = false;
            }
        }

        private void Tb_Search_TextChanged(object sender, EventArgs e)
        {
            string keyword = tb_FindParticipants.Text.Trim().ToLower();

            // Lọc ra các thành viên có tên khớp từ userInfoMapGlobal
            var filtered = memberStates
                .Where(kv =>
                {
                    string userId = kv.Key;
                    return userInfoMapGlobal.TryGetValue(userId, out var info) &&
                           (string.IsNullOrEmpty(keyword) || info.Username.ToLower().Contains(keyword));
                })
                .ToDictionary(kv => kv.Key, kv => kv.Value);

            // Cập nhật lại list
            UpdateParticipantsList(filtered, FirebaseConfig.database);
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
        }

        private void OnRemoteVideoStateChanged(uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnRemoteVideoStateChanged(remoteUid, state, reason, elapsed)));
                return;
            }

            string remoteUserId = FindUserIdByUid(remoteUid);
            if (!string.IsNullOrEmpty(remoteUserId))
            {
                // Xử lý khi có video stream
                if (state == REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STARTING ||
                    state == REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_DECODING)
                {

                    // Đảm bảo unmute remote video
                    rtcEngine.MuteRemoteVideoStream(remoteUid, false);

                }
                else if (state == REMOTE_VIDEO_STATE.REMOTE_VIDEO_STATE_STOPPED)
                {

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
                orientationMode = ORIENTATION_MODE.ORIENTATION_MODE_ADAPTIVE,
                mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED
            };
            rtcEngine.SetVideoEncoderConfiguration(videoConfig);

            rtcEngine.SetLocalRenderMode(RENDER_MODE_TYPE.RENDER_MODE_FIT,
                                         VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_ENABLED);


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
    .GroupBy(p => p.Name.Replace("panel_", ""))
    .ToDictionary(g => g.Key, g => g.First());


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
                this.Invoke(() =>
                {
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
                    rtcEngine.EnableVideo();

                    var videoCanvas = new VideoCanvas
                    {
                        uid = uid,
                        renderMode = RENDER_MODE_TYPE.RENDER_MODE_FIT,
                        view = panel.Handle,
                        mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED
                    };

                    int setupResult = rtcEngine.SetupLocalVideo(videoCanvas);
                    Debug.WriteLine($"SetupLocalVideo result: {setupResult}");

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
                        view = panel.Handle,
                        mirrorMode = VIDEO_MIRROR_MODE_TYPE.VIDEO_MIRROR_MODE_DISABLED
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

                    rtcEngine.DisableVideo();
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
                rtcEngine.EnableVideo();
                rtcEngine.MuteLocalVideoStream(false);
                rtcEngine.StartPreview();
            }
            else
            {
                rtcEngine.StopPreview();
                rtcEngine.MuteLocalVideoStream(true);
                rtcEngine.DisableVideo();
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
                onJoinSuccessCallback?.Invoke(connection.channelId, connection.localUid, elapsed);
            }

            public override void OnUserJoined(RtcConnection connection, uint remoteUid, int elapsed)
            {
                onUserJoinedCallback?.Invoke(remoteUid);
            }

            public override void OnUserOffline(RtcConnection connection, uint remoteUid, USER_OFFLINE_REASON_TYPE reason)
            {
                onUserOfflineCallback?.Invoke(remoteUid, reason);
            }

            public override void OnRemoteVideoStateChanged(RtcConnection connection, uint remoteUid, REMOTE_VIDEO_STATE state, REMOTE_VIDEO_STATE_REASON reason, int elapsed)
            {
                onRemoteVideoStateChangedCallback?.Invoke(remoteUid, state, reason, elapsed);
            }

            // Thêm callback để xử lý khi có first remote video frame
            public override void OnFirstRemoteVideoFrame(RtcConnection connection, uint remoteUid, int width, int height, int elapsed)
            {
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
        }

        // 5. Cập nhật callback OnUserJoined
        private void OnUserJoined(uint remoteUid)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnUserJoined(remoteUid)));
                return;
            }


            // Tìm userId từ remoteUid
            string remoteUserId = FindUserIdByUid(remoteUid);
            if (!string.IsNullOrEmpty(remoteUserId))
            {

                // Đảm bảo subscribe remote video stream
                rtcEngine.MuteRemoteVideoStream(remoteUid, false);
                rtcEngine.MuteRemoteAudioStream(remoteUid, false);
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
                    // Vẫn cần cleanup Agora resources
                    CleanupAgoraResources();
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

                // Cleanup Agora resources
                CleanupAgoraResources();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi rời phòng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Vẫn cần cleanup ngay cả khi có lỗi
                CleanupAgoraResources();
            }
            finally
            {
                isLeavingRoom = false;
            }
        }
        private void CleanupAgoraResources()
        {
            try
            {
                if (rtcEngine != null)
                {
                    Debug.WriteLine("Cleaning up Agora resources...");

                    // Tắt camera và mic trước khi leave channel
                    rtcEngine.MuteLocalVideoStream(true);
                    rtcEngine.MuteLocalAudioStream(true);

                    // Disable video và audio
                    rtcEngine.DisableVideo();
                    rtcEngine.DisableAudio();

                    // Leave channel
                    rtcEngine.LeaveChannel();

                    // Dispose engine
                    rtcEngine.Dispose();
                    rtcEngine = null;

                    Debug.WriteLine("Agora resources cleaned up successfully");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error cleaning up Agora resources: {ex.Message}");
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Chỉ xử lý khi user click X để đóng form
            if (e.CloseReason == CloseReason.UserClosing && !isLeavingRoom)
            {
                e.Cancel = true; // Ngăn form đóng tạm thời

                // Đảm bảo chạy trên UI thread
                _ = Task.Run(async () =>
                {
                    try
                    {
                        bool shouldClose = await HandleCancelCallAsync();

                        // Luôn luôn invoke về UI thread để đóng form
                        this.Invoke(() =>
                        {
                            if (shouldClose)
                            {
                                isLeavingRoom = true; // Set flag để tránh loop
                                this.Close(); // Đóng form thực sự
                            }
                            else
                            {
                                isLeavingRoom = false; // Reset flag nếu user hủy
                            }
                        });
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị lỗi trên UI thread
                        this.Invoke(() =>
                        {
                            MessageBox.Show($"Lỗi khi đóng form: {ex.Message}", "Lỗi",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isLeavingRoom = false; // Reset flag
                        });
                    }
                });

                return;
            }

            // Cleanup khi form thực sự đóng
            if (e.CloseReason != CloseReason.UserClosing)
            {
                CleanupAgoraResources();
            }

            base.OnFormClosing(e);
        }

        private async void sbtn_CancelCall_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = await HandleCancelCallAsync();
                if (result)
                {
                    isLeavingRoom = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Cleanup ngay cả khi có lỗi
                CleanupAgoraResources();
                isLeavingRoom = false;
            }
        }

        private async Task<bool> HandleCancelCallAsync()
        {
            // Kiểm tra trạng thái trước khi xử lý
            if (isLeavingRoom)
            {
                Debug.WriteLine("Already leaving room, skipping...");
                return false;
            }

            isLeavingRoom = true;

            try
            {
                if (currentUserId == hostId)
                {
                    // Sử dụng Invoke để đảm bảo MessageBox hiển thị trên UI thread
                    DialogResult result = DialogResult.No;

                    if (this.InvokeRequired)
                    {
                        this.Invoke(() =>
                        {
                            result = MessageBox.Show("Bạn là host. Bạn có muốn xóa phòng không? Tất cả thành viên sẽ bị rời phòng.",
                                                   "Xác nhận xóa phòng",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Warning);
                        });
                    }
                    else
                    {
                        result = MessageBox.Show("Bạn là host. Bạn có muốn xóa phòng không? Tất cả thành viên sẽ bị rời phòng.",
                                               "Xác nhận xóa phòng",
                                               MessageBoxButtons.YesNo,
                                               MessageBoxIcon.Warning);
                    }

                    if (result != DialogResult.Yes)
                    {
                        isLeavingRoom = false; // Reset flag
                        return false; // User hủy, không đóng form
                    }

                    // Debug log để kiểm tra
                    Debug.WriteLine("Host confirmed deletion, proceeding...");

                    await MarkRoomAsDeletedByHost();
                    await DeleteRoomFromFirestore();
                    await DeleteInvitationsOfRoom(currentroomId);
                    NotifyMembersRoomClosed();

                    // Cleanup Agora resources cho host
                    CleanupAgoraResources();

                    Debug.WriteLine("Room deletion completed successfully");
                }
                else
                {
                    // Tương tự cho member
                    DialogResult result = DialogResult.No;

                    if (this.InvokeRequired)
                    {
                        this.Invoke(() =>
                        {
                            result = MessageBox.Show("Bạn có chắc muốn rời phòng?", "Xác nhận",
                                                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        });
                    }
                    else
                    {
                        result = MessageBox.Show("Bạn có chắc muốn rời phòng?", "Xác nhận",
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (result != DialogResult.Yes)
                    {
                        isLeavingRoom = false; // Reset flag
                        return false; // User hủy, không đóng form
                    }

                    await LeaveRoom();
                }

                return true; // Xác nhận đóng form
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in HandleCancelCallAsync: {ex.Message}");
                Debug.WriteLine($"Stack trace: {ex.StackTrace}");

                // Hiển thị lỗi trên UI thread
                if (this.InvokeRequired)
                {
                    this.Invoke(() =>
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
                else
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Cleanup ngay cả khi có lỗi
                CleanupAgoraResources();

                isLeavingRoom = false; // Reset flag khi có lỗi
                return false;
            }
        }
        private async Task MarkRoomAsDeletedByHost()
        {
            try
            {
                Debug.WriteLine($"Marking room {currentroomId} as deleted by host...");

                var db = FirebaseConfig.database;
                var roomRef = db.Collection("Room").Document(currentroomId);

                await roomRef.UpdateAsync(new Dictionary<string, object>
        {
            { "deleted_by_host", true }, // Đánh dấu phòng bị xóa bởi host
            { "deleted_at", FieldValue.ServerTimestamp } // Thêm timestamp
        });

                Debug.WriteLine("Room marked as deleted successfully");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi đánh dấu phòng bị xóa: {ex.Message}");
                throw; // Re-throw để được xử lý ở caller
            }
        }

        private async Task DeletePomodoroSession()
        {
            try
            {
                Debug.WriteLine($"Deleting Pomodoro session for room {currentroomId}...");

                var db = FirebaseConfig.database;
                await db.Collection("Pomodoro_Sessions").Document(currentroomId).DeleteAsync();

                Debug.WriteLine("Pomodoro session deleted successfully");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi xóa Pomodoro_Session: {ex.Message}");
                throw; // Re-throw để được xử lý ở caller
            }
        }

        private async Task DeleteRoomFromFirestore()
        {
            try
            {
                Debug.WriteLine($"Deleting room {currentroomId} from Firestore...");

                FirestoreDb db = FirebaseConfig.database;
                DocumentReference roomRef = db.Collection("Room").Document(currentroomId);

                await DeletePomodoroSession(); // Xóa session trước
                await roomRef.DeleteAsync(); // Sau đó xóa room

                Debug.WriteLine("Room deleted successfully from Firestore");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi khi xóa phòng: {ex.Message}");
                throw; // Re-throw để được xử lý ở caller
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void btnSendMessages_Click(object sender, EventArgs e)
        {
            string msg = tbMessages.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
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

        private async void btn_Start_Click(object sender, EventArgs e)
        {
            if (currentUserId != hostId)
            {
                MessageBox.Show("Bạn không phải là Host.");
                return;
            }

            var PomodoroRef = FirebaseConfig.database.Collection("Pomodoro_Sessions").Document(currentroomId);
            var snapshot = await PomodoroRef.GetSnapshotAsync();
            var data = snapshot.ToDictionary();

            bool isRunning = data.ContainsKey("is_running") && Convert.ToBoolean(data["is_running"]);
            string startTimeStr = data.ContainsKey("start_time") ? data["start_time"]?.ToString() : null;
            DateTime? startTime = !string.IsNullOrEmpty(startTimeStr) ? DateTime.Parse(startTimeStr).ToUniversalTime() : (DateTime?)null;

            string pausedTimeStr = data.ContainsKey("paused_time") ? data["paused_time"]?.ToString() : null;
            DateTime? pausedTime = !string.IsNullOrEmpty(pausedTimeStr) ? DateTime.Parse(pausedTimeStr).ToUniversalTime() : (DateTime?)null;

            if (!isRunning && pausedTime == null)
            {
                await PomodoroRef.UpdateAsync(new Dictionary<string, object>
            {
                { "start_time", DateTime.UtcNow.ToString("o") },
                { "is_running", true },
                { "paused_time", null }
            });
            }
            else if (!isRunning && pausedTime != null && startTime != null)
            {
                var pauseDuration = DateTime.UtcNow - pausedTime.Value;
                var newStartTime = startTime.Value + pauseDuration;

                await PomodoroRef.UpdateAsync(new Dictionary<string, object>
            {
                { "start_time", newStartTime.ToString("o") },
                { "is_running", true },
                { "paused_time", null }
            });
            }
            else if (isRunning)
            {
                await PomodoroRef.UpdateAsync(new Dictionary<string, object>
            {
                { "is_running", false },
                { "paused_time", DateTime.UtcNow.ToString("o") }
            });
            }
        }

        private async void btn_Reset_Click(object sender, EventArgs e)
        {
            if (currentUserId != hostId)
            {
                MessageBox.Show("Bạn không phải là Host.");
                return;
            }

            var PomodoroRef = FirebaseConfig.database.Collection("Pomodoro_Sessions").Document(currentroomId);

            await PomodoroRef.UpdateAsync(new Dictionary<string, object>
        {
            { "is_running", false },
            { "start_time", null },
            { "paused_time", null }
        });

            StopPomodoro(resetUI: true);
        }

        private void SetBackgroundFromArray(int index)
        {
            if (index >= 0 && index < backgroundImages.Length)
            {
                pn_Background.BackgroundImage = backgroundImages[index];
            }
        }
        private void PlayMusicFromBytes(byte[] musicBytes, bool resume = false)
        {
            try
            {
                if (resume && audioFileReader != null && outputDevice != null)
                {
                    // Resume từ vị trí cũ nếu audio đã được tạo
                    audioFileReader.Position = pausedMusicPosition;
                    outputDevice.Play();
                    musicProgressTimer?.Start();
                    return;
                }

                // Nếu không phải resume hoặc chưa từng play -> tạo lại mới
                if (cachedMusicPath == null)
                {
                    cachedMusicPath = Path.Combine(Path.GetTempPath(), "pomomusic_" + Guid.NewGuid().ToString() + ".mp3");
                    File.WriteAllBytes(cachedMusicPath, musicBytes);
                }

                outputDevice?.Stop();
                outputDevice?.Dispose();
                audioFileReader?.Dispose();

                audioFileReader = new AudioFileReader(cachedMusicPath);
                audioFileReader.Position = 0;

                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFileReader);
                outputDevice.PlaybackStopped += (s, e) =>
                {
                    if (isPomodoroRunning && (DateTime.UtcNow - pomodoroStartTime).TotalSeconds < countdownTime * 60)
                    {
                        audioFileReader.Position = 0;
                        outputDevice.Play();
                        currentMusicSeconds = 0;
                        musicProgressTimer?.Start();
                    }
                };

                outputDevice.Play();

                musicTotalSeconds = (int)audioFileReader.TotalTime.TotalSeconds;
                currentMusicSeconds = (int)(audioFileReader.CurrentTime.TotalSeconds);
                ProgressBarMusic.Maximum = musicTotalSeconds;
                ProgressBarMusic.Value = currentMusicSeconds;
                lb_TotalTime.Text = TimeSpan.FromSeconds(musicTotalSeconds).ToString(@"mm\:ss");
                lb_CurrentTime.Text = TimeSpan.FromSeconds(currentMusicSeconds).ToString(@"mm\:ss");

                if (musicProgressTimer == null)
                {
                    musicProgressTimer = new System.Windows.Forms.Timer { Interval = 1000 };
                    musicProgressTimer.Tick += MusicProgressTimer_Tick;
                }

                musicProgressTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát nhạc: " + ex.Message);
            }
        }


        private void MusicProgressTimer_Tick(object sender, EventArgs e)
        {
            currentMusicSeconds++;

            if (currentMusicSeconds <= musicTotalSeconds)
            {
                SafeInvoke(() =>
                {
                    ProgressBarMusic.Value = currentMusicSeconds;
                    lb_CurrentTime.Text = TimeSpan.FromSeconds(currentMusicSeconds).ToString(@"mm\:ss");
                });
            }
            else
            {
                musicProgressTimer.Stop();
            }
        }


        private void StartPomodoroCountdown(DateTime startTime)
        {
            pomodoroStartTime = startTime;
            pomoTimer?.Stop();

            pomoTimer = new System.Windows.Forms.Timer { Interval = 1000 };
            pomoTimer.Tick += async (s, e) =>
            {
                var elapsed = (int)(DateTime.UtcNow - pomodoroStartTime).TotalSeconds;
                var total = isBreakTime ? breakDuration * 60 : countdownTime * 60;
                var remaining = total - elapsed;

                if (remaining <= 0)
                {
                    pomoTimer.Stop();
                    SafeInvoke(() =>
                    {
                        lb_time_counter.Text = "00:00";
                        outputDevice?.Stop();
                        musicProgressTimer?.Stop();
                        ProgressBarMusic.Value = 0;
                        lb_CurrentTime.Text = "00:00";
                    });

                    if (currentUserId == hostId)
                    {
                        var PomodoroRef = FirebaseConfig.database.Collection("Pomodoro_Sessions").Document(currentroomId);
                        var newBreakState = !isBreakTime;
                        var now = DateTime.UtcNow;

                        await PomodoroRef.UpdateAsync(new Dictionary<string, object>
                {
                    { "is_break_time", newBreakState },
                    { "is_running", true },
                    { "start_time", now.ToString("o") },
                    { "paused_time", null }
                });
                    }
                }
                else
                {
                    SafeInvoke(() =>
                    {
                        lb_time_counter.Text = TimeSpan.FromSeconds(Math.Max(0, remaining)).ToString(@"mm\:ss");
                    });
                }
            };

            pomoTimer.Start();

            if (musicIndex >= 0 && musicIndex < songBytes.Length)
            {
                PlayMusicFromBytes(songBytes[musicIndex], resume: true);
            }
        }

        private void PausePomodoro()
        {
            pomoTimer?.Stop();
            outputDevice?.Pause();
            musicProgressTimer?.Stop();

            if (audioFileReader != null)
            {
                pausedMusicPosition = audioFileReader.Position;
            }
        }

        private void StopPomodoro(bool resetUI = false)
        {
            pomoTimer?.Stop();
            outputDevice?.Stop();
            musicProgressTimer?.Stop();

            if (resetUI)
            {
                audioFileReader?.Dispose();
                audioFileReader = null;
                outputDevice?.Dispose();
                outputDevice = null;
                pausedMusicPosition = 0;
                currentMusicSeconds = 0;
                musicTotalSeconds = 0;

                if (!string.IsNullOrEmpty(cachedMusicPath) && File.Exists(cachedMusicPath))
                {
                    try { File.Delete(cachedMusicPath); } catch { }
                    cachedMusicPath = null;
                }

                SafeInvoke(() =>
                {
                    ProgressBarMusic.Value = 0;
                    lb_time_counter.Text = "--:--";
                    lb_CurrentTime.Text = "00:00";
                    lb_TotalTime.Text = "--:--";
                });
            }
        }

        private async void btn_pomodoro_Click(object sender, EventArgs e)
        {
            if (currentUserId != hostId)
            {
                MessageBox.Show("Chỉ host mới có thể chuyển sang Pomodoro thủ công.");
                return;
            }

            var PomodoroRef = FirebaseConfig.database.Collection("Pomodoro_Sessions").Document(currentroomId);

            await PomodoroRef.UpdateAsync(new Dictionary<string, object>
    {
        { "is_break_time", false },
        { "start_time", null },
        { "paused_time", null },
        { "is_running", false }
    });
        }

        private async void btn_Break_Click(object sender, EventArgs e)
        {
            if (currentUserId != hostId)
            {
                MessageBox.Show("Chỉ host mới có thể chuyển sang Break thủ công.");
                return;
            }

            var PomodoroRef = FirebaseConfig.database.Collection("Pomodoro_Sessions").Document(currentroomId);

            await PomodoroRef.UpdateAsync(new Dictionary<string, object>
    {
        { "is_break_time", true },
        { "start_time", null },
        { "paused_time", null },
        { "is_running", false }
    });
        }
    }
}
