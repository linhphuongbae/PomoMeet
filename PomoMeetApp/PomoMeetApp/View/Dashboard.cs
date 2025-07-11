using Google.Cloud.Firestore;
using Google.Type;
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
using static PomoMeetApp.View.CustomMessageBox;

namespace PomoMeetApp.View
{
    public partial class Dashboard : Form
    {
        public string currentUserId;
        private FirestoreChangeListener _userListener;

        private bool isClosing = false;
        private bool isListenerStopped = false;

        private Dictionary<string, (Panel panel, Label lblName, Label lblCount, PictureBox picLock)> roomPanels =
    new Dictionary<string, (Panel, Label, Label, PictureBox)>();

        private Dictionary<string, (Panel panel, Label lblName, Label lblCount, PictureBox picLock)> fullRoomPanels =
    new Dictionary<string, (Panel, Label, Label, PictureBox)>();

        private int currentPageIndex = 0;
        private const int RoomsPerPage = 6;

        private FirestoreChangeListener roomListListener;

        private Button btnNext, btnPrev;

        private Image[] backgroundImages =
        {
            Properties.Resources.Image,
                Properties.Resources.studyBackground1,
                Properties.Resources.studyBackground2,
                Properties.Resources.studyBackground3,
        };

        public Dashboard(string userId)
        {
            InitializeComponent();
            currentUserId = userId;

            // Khởi tạo các button pagination ngay từ đầu
            InitializePaginationButtons();

            InitializeUserProfile();
            this.FormClosed += Dashboard_FormClosed;

            // SỬA: Gọi async method đúng cách
            _ = Task.Run(async () => await ListenToRoomsRealtime());

            tb_Search.TextChanged += Tb_Search_TextChanged;
        }

        private void InitializePaginationButtons()
        {
            // Tạo nút Prev ở vị trí (325, 893)
            btnPrev = new Button
            {
                Text = "Trang trước",
                Location = new Point(325, 910),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink, // Để button co dãn đúng cách
                BackColor = System.Drawing.Color.FromArgb(117, 164, 127),
                ForeColor = System.Drawing.Color.White,
                Font = new Font("Inter", 10, FontStyle.Bold),
                Visible = false
            };

            btnPrev.Click += (s, e) => { currentPageIndex--; RenderPage(currentPageIndex); };
            this.Controls.Add(btnPrev);

            // Tạo nút Next ở vị trí (1268, 893)
            btnNext = new Button
            {
                Text = "Trang sau",
                Location = new Point(1268, 910),
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                BackColor = System.Drawing.Color.FromArgb(117, 164, 127),
                ForeColor = System.Drawing.Color.White,
                Font = new Font("Inter", 10, FontStyle.Bold),
                Visible = false
            };

            btnNext.Click += (s, e) => { currentPageIndex++; RenderPage(currentPageIndex); };
            this.Controls.Add(btnNext);
        }

        private async Task InitializeUserProfile()
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

            userProfilePanel2.SetProfileClickCallback(userId =>
            {
                // Kiểm tra xem form Profile đã mở chưa
                var existingProfileForm = Application.OpenForms.OfType<Profile>().FirstOrDefault();

                if (existingProfileForm == null) // Nếu chưa có Profile form đang mở
                {
                    var profileForm = new Profile(userId);
                    profileForm.ShowDialog();  // Mở form Profile
                }
                else
                {
                    // Nếu form Profile đã mở, có thể đưa form đó lên trước (active)
                    existingProfileForm.BringToFront();
                }
            });

            // Cập nhật trạng thái người dùng thành "online"
            await UserStatusManager.Instance.UpdateUserStatus(currentUserId, "online");

            // Bắt đầu lắng nghe thay đổi dữ liệu người dùng
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
            if (!isListenerStopped)
            {
                isListenerStopped = true;
                _ = Task.Run(async () =>
                {
                    try
                    {
                        if (roomListListener != null)
                            await roomListListener.StopAsync();
                        if (_userListener != null)
                            await _userListener.StopAsync();
                    }
                    catch { }
                });
            }
        }

        private void tbtn_JoinRoom_Click(object sender, EventArgs e)
        {
            Joinroom joinRoom = new Joinroom(currentUserId);
            joinRoom.ShowDialog();
        }

        public void SafeInvoke(Action action)
        {
            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();
        }

        private async Task ListenToRoomsRealtime()
        {
            var db = FirebaseConfig.database;
            var roomsRef = db.Collection("Room");

            // SỬA: Load dữ liệu ban đầu trước
            await LoadInitialRoomsData();

            // Sau đó mới bắt đầu listener cho real-time updates
            roomListListener = roomsRef.Listen(snapshot =>
            {
                SafeInvoke(async () =>
                {
                    List<Task> tasks = new List<Task>();

                    foreach (var change in snapshot.Changes)
                    {
                        var doc = change.Document;
                        string roomId = doc.Id;

                        if (change.ChangeType == DocumentChange.Type.Removed)
                        {
                            if (roomPanels.TryGetValue(roomId, out var panelData))
                            {
                                var (panel, lblName, lblCount, picLock) = panelData;

                                this.Controls.Remove(panel);
                                this.Controls.Remove(lblName);
                                this.Controls.Remove(lblCount);
                                this.Controls.Remove(picLock);

                                roomPanels.Remove(roomId);
                                fullRoomPanels.Remove(roomId);
                            }
                            continue;
                        }

                        var data = doc.ToDictionary();
                        if (data.TryGetValue("deleted_by_host", out var deleted) && Convert.ToBoolean(deleted))
                            continue;

                        string roomName = data.ContainsKey("room_name") ? data["room_name"].ToString() : "Phòng không tên";
                        string type = data.ContainsKey("type") ? data["type"].ToString() : "Public";
                        string password = data.ContainsKey("password") ? data["password"].ToString() : "";
                        bool isPrivate = type == "Private" || !string.IsNullOrEmpty(password);
                        int memberCount = data.ContainsKey("members_status") ? ((Dictionary<string, object>)data["members_status"]).Count : 0;

                        tasks.Add(LoadAndAddRoomPanelAsync(roomId, roomName, isPrivate, memberCount));
                    }

                    // Đợi toàn bộ task load xong panel
                    await Task.WhenAll(tasks);

                    // Sau khi thêm xong, mới render
                    RenderPage(currentPageIndex);
                });
            });
        }

        // SỬA: Thêm method mới để load dữ liệu ban đầu
        private async Task LoadInitialRoomsData()
        {
            try
            {
                var db = FirebaseConfig.database;
                var roomsSnapshot = await db.Collection("Room").GetSnapshotAsync();

                List<Task> tasks = new List<Task>();

                foreach (var doc in roomsSnapshot.Documents)
                {
                    var data = doc.ToDictionary();
                    if (data.TryGetValue("deleted_by_host", out var deleted) && Convert.ToBoolean(deleted))
                        continue;

                    string roomId = doc.Id;
                    string roomName = data.ContainsKey("room_name") ? data["room_name"].ToString() : "Phòng không tên";
                    string type = data.ContainsKey("type") ? data["type"].ToString() : "Public";
                    string password = data.ContainsKey("password") ? data["password"].ToString() : "";
                    bool isPrivate = type == "Private" || !string.IsNullOrEmpty(password);
                    int memberCount = data.ContainsKey("members_status") ? ((Dictionary<string, object>)data["members_status"]).Count : 0;

                    tasks.Add(LoadAndAddRoomPanelAsync(roomId, roomName, isPrivate, memberCount));
                }

                // Đợi toàn bộ task load xong
                await Task.WhenAll(tasks);

                // Render ngay sau khi load xong
                SafeInvoke(() => RenderPage(currentPageIndex));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading initial rooms data: {ex.Message}");
            }
        }


        private async Task LoadAndAddRoomPanelAsync(string roomId, string roomName, bool isPrivate, int memberCount)
        {
            int backgroundId = 0;
            try
            {
                var snapshot = await FirebaseConfig.database.Collection("Pomodoro_Sessions").Document(roomId).GetSnapshotAsync();
                if (snapshot.Exists && snapshot.TryGetValue<int>("background_id", out var bgObj))
                {
                    backgroundId = bgObj;
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                Console.WriteLine("Lỗi khi lấy background_id: " + ex.Message);
            }

            SafeInvoke(() =>
            {
                // SỬA: Kiểm tra và cập nhật thay vì bỏ qua
                if (roomPanels.ContainsKey(roomId) || fullRoomPanels.ContainsKey(roomId))
                {
                    // Nếu đã tồn tại, cập nhật thông tin
                    UpdateExistingRoomPanel(roomId, roomName, isPrivate, memberCount, backgroundId);
                    return;
                }

                Point location = CalculateRoomLocation(fullRoomPanels.Count);
                AddRoomPanel(roomId, roomName, isPrivate, memberCount, backgroundId, location);
            });
        }

        // SỬA: Thêm method mới để cập nhật panel đã tồn tại
        private void UpdateExistingRoomPanel(string roomId, string roomName, bool isPrivate, int memberCount, int backgroundId)
        {
            try
            {
                if (fullRoomPanels.TryGetValue(roomId, out var roomData))
                {
                    var (panel, lblName, lblCount, picLock) = roomData;

                    // Cập nhật thông tin
                    lblName.Text = roomName ?? "Phòng không tên";
                    lblCount.Text = $"{memberCount} người tham gia";
                    picLock.Visible = isPrivate;
                    panel.BackgroundImage = GetBackgroundByIndex(backgroundId);

                    // Cập nhật lại roomPanels nếu cần
                    roomPanels[roomId] = roomData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating room panel for {roomId}: {ex.Message}");
            }
        }

        private Point CalculateRoomLocation(int index)
        {
            int col = index % 3;
            int row = index / 3;
            int x = 325 + col * 363; // 688 - 325 = 363 (khoảng cách giữa các cột)
            int y = 275 + row * 320; // Giữ nguyên khoảng cách giữa các hàng
            return new Point(x, y);
        }

        private void AddRoomPanel(string roomId, string roomName, bool isPrivate, int memberCount, int backgroundIndex, Point location)
        {
            try
            {
                Panel panelRoom = new Panel
                {
                    Size = new Size(320, 240),
                    Location = location,
                    BorderStyle = BorderStyle.None,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackgroundImage = GetBackgroundByIndex(backgroundIndex),
                    Cursor = Cursors.Hand
                };

                Button btnJoin = new Button
                {
                    Text = "Tham gia",
                    Size = new Size(100, 35),
                    Location = new Point((panelRoom.Width - 100) / 2, (panelRoom.Height - 35) / 2),
                    BackColor = System.Drawing.Color.FromArgb(117, 164, 127),
                    ForeColor = System.Drawing.Color.White,
                    Font = new Font("Inter", 10, FontStyle.Bold),
                    Visible = false
                };

                Label lblRoomName = new Label
                {
                    Text = $"{roomName ?? "Phòng không tên"}",
                    Font = new Font("Inter", 12, FontStyle.Bold),
                    AutoSize = true,                                  // Cho phép tự giãn chiều cao
                    Location = new Point(10, panelRoom.Height + 5)
                };



                Label lblMemberCount = new Label
                {
                    Text = $"{memberCount} người tham gia",
                    Font = new Font("Inter", 10),
                    AutoSize = true,
                    Location = new Point(10, panelRoom.Height + 30)
                };

                PictureBox picLock = new PictureBox
                {
                    Size = new Size(24, 24),
                    Location = new Point(lblRoomName.Right + 5, lblRoomName.Top),
                    Image = Properties.Resources.Lock,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Visible = isPrivate
                };

                panelRoom.MouseEnter += (s, e) => btnJoin.Visible = true;
                btnJoin.MouseEnter += (s, e) => btnJoin.Visible = true;

                panelRoom.MouseLeave += (s, e) => CheckMouseLeave();
                btnJoin.MouseLeave += (s, e) => CheckMouseLeave();

                void CheckMouseLeave()
                {
                    // Lấy tọa độ chuột tính theo form
                    Point mousePos = this.PointToClient(Cursor.Position);

                    // Nếu chuột không nằm trong panelRoom và không nằm trong btnJoin thì mới ẩn
                    if (!panelRoom.Bounds.Contains(mousePos) && !btnJoin.Bounds.Contains(mousePos))
                    {
                        btnJoin.Visible = false;
                    }
                }


                btnJoin.Click += (s, e) =>
                {
                    if (isPrivate)
                    {
                        PrivateRoom privateRoomForm = new PrivateRoom(currentUserId, roomId);
                        privateRoomForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        JoinRoom(roomId);
                    }
                };

                panelRoom.Controls.Add(btnJoin);

                // Kiểm tra tất cả control đã được tạo thành công
                if (panelRoom != null && lblRoomName != null && lblMemberCount != null && picLock != null)
                {
                    var controls = (panelRoom, lblRoomName, lblMemberCount, picLock);
                    // SỬA: Thêm vào cả hai dictionary cùng lúc
                    roomPanels[roomId] = controls;
                    fullRoomPanels[roomId] = controls;
                }
                else
                {
                    Console.WriteLine($"Không thể tạo giao diện cho phòng học {roomId}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo giao diện phòng cho {roomId}: {ex.Message}");
            }
        }

        private void RenderPage(int pageIndex)
        {
            // SỬA: Sử dụng fullRoomPanels để remove controls
            foreach (var item in fullRoomPanels.Values.ToList())
            {
                try
                {
                    if (item.panel != null && this.Controls.Contains(item.panel))
                        this.Controls.Remove(item.panel);
                    if (item.lblName != null && this.Controls.Contains(item.lblName))
                        this.Controls.Remove(item.lblName);
                    if (item.lblCount != null && this.Controls.Contains(item.lblCount))
                        this.Controls.Remove(item.lblCount);
                    if (item.picLock != null && this.Controls.Contains(item.picLock))
                        this.Controls.Remove(item.picLock);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xóa các thành phần giao diện: {ex.Message}");
                }
            }

            int startIndex = pageIndex * RoomsPerPage;
            int endIndex = startIndex + RoomsPerPage;

            // SỬA: Sử dụng roomPanels (filtered) để hiển thị
            var rooms = roomPanels.Keys.ToList();
            int totalRooms = rooms.Count;

            for (int i = startIndex; i < endIndex && i < totalRooms; i++)
            {
                try
                {
                    string roomId = rooms[i];
                    if (string.IsNullOrEmpty(roomId) || !roomPanels.ContainsKey(roomId))
                        continue;

                    var roomData = roomPanels[roomId];
                    var (panel, lblName, lblCount, picLock) = roomData;

                    // Kiểm tra null trước khi sử dụng
                    if (panel == null || lblName == null || lblCount == null || picLock == null)
                    {
                        Console.WriteLine($"Không tìm thấy control cho phòng {roomId}, đang xóa khỏi danh sách quản lý.");
                        roomPanels.Remove(roomId);
                        fullRoomPanels.Remove(roomId);
                        continue;
                    }

                    Point location = CalculateRoomLocation(i - startIndex);

                    panel.Location = location;
                    lblName.Location = new Point(location.X + 10, location.Y + 240 + 5);
                    lblCount.Location = new Point(location.X + 10, location.Y + 240 + 30);
                    picLock.Location = new Point(lblName.Right + 5, lblName.Top);

                    if (!this.Controls.Contains(panel))
                        this.Controls.Add(panel);
                    if (!this.Controls.Contains(lblName))
                        this.Controls.Add(lblName);
                    if (!this.Controls.Contains(lblCount))
                        this.Controls.Add(lblCount);
                    if (!this.Controls.Contains(picLock))
                        this.Controls.Add(picLock);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi thêm các thành phần giao diện cho phòng: {ex.Message}");
                }
            }

            // Cập nhật hiển thị nút phân trang
            try
            {
                if (btnPrev != null)
                    btnPrev.Visible = pageIndex > 0;

                if (btnNext != null)
                    btnNext.Visible = totalRooms > RoomsPerPage && endIndex < totalRooms;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật các nút phân trang: {ex.Message}");
            }

            // Debug: In ra console để kiểm tra
            Console.WriteLine($"Tổng số phòng: {totalRooms}, Trang hiện tại: {pageIndex}, Bắt đầu: {startIndex}, Kết thúc: {endIndex}");
            Console.WriteLine($"btnPrev visible: {btnPrev?.Visible}, btnNext visible: {btnNext?.Visible}");
        }

        private Image GetBackgroundByIndex(int index)
        {
            return backgroundImages[index];
        }

        private void Tb_Search_TextChanged(object sender, EventArgs e)
        {
            string keyword = tb_Search.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu không có từ khóa, hiển thị lại toàn bộ phòng
                roomPanels = new Dictionary<string, (Panel, Label, Label, PictureBox)>(fullRoomPanels);
            }
            else
            {
                // Lọc các phòng theo roomId hoặc tên phòng
                roomPanels = fullRoomPanels
                    .Where(pair =>
                        pair.Key.ToLower().Contains(keyword) ||
                        pair.Value.lblName.Text.ToLower().Contains(keyword))
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
            }

            // Reset về trang đầu và render lại
            currentPageIndex = 0;
            RenderPage(currentPageIndex);
        }

        private async void JoinRoom(string roomId)
        {
            // Hiển thị form MeetingRoom
            MeetingRoom form = new MeetingRoom(currentUserId, roomId);

            // Ẩn Dashboard trước khi hiển thị MeetingRoom
            this.Hide();

            // Cập nhật trạng thái người dùng là "in call"
            await UserStatusManager.Instance.UpdateUserStatus(currentUserId, "in call");

            // Theo dõi sự kiện đóng form MeetingRoom
            form.FormClosed += async (s, e) =>
            {
                // Khi form MeetingRoom đóng (bao gồm cả trường hợp bị kick), hiển thị lại Dashboard
                this.ShowDashboard();

                // Cập nhật trạng thái người dùng về "online"
                await UserStatusManager.Instance.UpdateUserStatus(currentUserId, "online");

                // Hiển thị thông báo nếu bị kick
                if (form.isBeingKicked && !form.hasShownKickNotification)
                {
                    CustomMessageBox.Show("Bạn đã bị kick khỏi phòng!", "Thông báo", MessageBoxMode.OK);
                    form.hasShownKickNotification = true;
                }
            };

            // Sử dụng ShowDialog() thay vì Show() để đảm bảo xử lý tuần tự
            form.ShowDialog();
        }

        public void HideDashboard()
        {
            this.Hide();
        }
        public void ShowDashboard()
        {
            this.Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Normal; // Đảm bảo form không bị minimized

            // Kiểm tra flag
            if (MeetingRoom.RoomDeletedByHost)
            {
                MeetingRoom.RoomDeletedByHost = false; // Reset lại flag sau khi hiện
                CustomMessageBox.Show("Phòng đã bị xóa bởi chủ phòng.", "Thông báo", MessageBoxMode.OK);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !isClosing)
            {
                e.Cancel = true; // Cancel việc đóng form tạm thời
                isClosing = true; // Đánh dấu đang trong quá trình đóng

                // Disable các control để tránh user tương tác
                this.Enabled = false;

                // Chạy cleanup trong background thread
                Task.Run(async () =>
                {
                    try
                    {
                        // Cập nhật trạng thái user về offline
                        await UserStatusManager.Instance.UpdateUserStatus(currentUserId, "offline");

                        // Stop các listener
                        if (!isListenerStopped)
                        {
                            isListenerStopped = true;

                            // Stop room listener
                            if (roomListListener != null)
                                await roomListListener.StopAsync();

                            // Stop user listener
                            if (_userListener != null)
                                await _userListener.StopAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log lỗi nhưng vẫn tiếp tục đóng app
                        Console.WriteLine($"Lỗi khi cleanup: {ex.Message}");
                    }
                    finally
                    {
                        // Quay về UI thread để đóng form
                        this.Invoke(() =>
                        {
                            try
                            {
                                // Đóng tất cả các form khác
                                var openForms = Application.OpenForms.Cast<Form>().ToList();
                                foreach (Form frm in openForms)
                                {
                                    if (frm != this && !frm.IsDisposed)
                                    {
                                        try
                                        {
                                            frm.Close();
                                        }
                                        catch { }
                                    }
                                }

                                // Cuối cùng mới exit application
                                Application.Exit();
                            }
                            catch
                            {
                                // Nếu có lỗi, force exit
                                Environment.Exit(0);
                            }
                        });
                    }
                });
            }
            else
            {
                // Nếu đang trong quá trình đóng hoặc không phải user close
                if (!isListenerStopped)
                {
                    isListenerStopped = true;
                    // Stop listeners (không await vì đang ở UI thread)
                    _ = Task.Run(async () =>
                    {
                        try
                        {
                            if (roomListListener != null)
                                await roomListListener.StopAsync();
                            if (_userListener != null)
                                await _userListener.StopAsync();
                        }
                        catch { }
                    });
                }

                base.OnFormClosing(e);
            }
        }





    }
}