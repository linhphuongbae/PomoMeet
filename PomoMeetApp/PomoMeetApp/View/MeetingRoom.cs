using Google.Cloud.Firestore;
using PomoMeetApp.Classes;
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
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PomoMeetApp.View
{
    public partial class MeetingRoom : Form
    {
        private ImageList imageListAvatars;
        private string currentUserId;
        private string currentroomId;


        public MeetingRoom(string userId, string roomId)
        {
            InitializeComponent();
            currentUserId = userId;
            currentroomId = roomId;

            InitializeMeetingRoomComponents();
            JoinRoomAndUpdateParticipants();
            ListenToRoomChanges(currentUserId, currentroomId);

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


        private void ListenToRoomChanges(string currentUserId, string roomId)
        {
            var db = FirebaseConfig.database; // FirestoreDb instance
            var docRef = db.Collection("Room").Document(roomId);

            docRef.Listen(snapshot =>
            {
                if (snapshot.Exists)
                {
                    var data = snapshot.ToDictionary();

                    if (data.TryGetValue("members", out object membersObj) && membersObj is IList<object> membersList)
                    {
                        var members = membersList.Select(m => m.ToString()).ToList();

                        if (!members.Contains(currentUserId))
                        {
                            // Thông báo và đóng form
                            this.Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show("Bạn đã bị đá khỏi phòng!");
                                this.Close();
                            });
                        }
                    }
                }
            });
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

        private void MeetingRoom_Load(object sender, EventArgs e)
        {

        }

        private void sbtn_CancelCall_Click(object sender, EventArgs e)
        {

        }

        private async void JoinRoomAndUpdateParticipants()
        {
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").Document(currentroomId);

            roomRef.Listen(async snapshot =>
            {
                if (!snapshot.Exists)
                {
                    MessageBox.Show("Phòng đã bị xóa!");
                    return;
                }

                var roomData = snapshot.ToDictionary();
                var members = roomData["members"] as List<object> ?? new List<object>();

                if (listViewParticipants.InvokeRequired)
                {
                    // Nếu không phải UI thread, dùng Invoke để thực thi trên UI thread
                    listViewParticipants.Invoke(new Action(() =>
                    {
                        UpdateParticipantsList(members, db);
                    }));
                }
                else
                {
                    // Nếu đang trên UI thread, trực tiếp gọi hàm cập nhật danh sách
                    UpdateParticipantsList(members, db);
                }
            });

        }

        private async void UpdateParticipantsList(List<object> members, FirestoreDb db)
        {
            listViewParticipants.Items.Clear();

            foreach (string userId in members)
            {
                var userRef = db.Collection("User").Document(userId);
                var userDoc = await userRef.GetSnapshotAsync();

                if (userDoc.Exists)
                {
                    var userData = userDoc.ToDictionary();
                    string username = userData.ContainsKey("Username") ? userData["Username"].ToString() : "Unknown";
                    if (userData.ContainsKey("Avatar"))
                    {
                        string avatarKey = userData["Avatar"]?.ToString(); // Lấy avatarKey từ dictionary

                        // Nếu avatarKey có giá trị, truy xuất từ Resources
                        if (!string.IsNullOrEmpty(avatarKey))
                        {
                            var avatarImage = GetAvatarFromResources(avatarKey);
                        }
                        else
                        {
                            // Nếu không có avatarKey, sử dụng ảnh mặc định
                            var avatarImage = Properties.Resources.avatar;
                        }
                    }
                    else
                    {
                        // Nếu không có key "Avatar", sử dụng ảnh mặc định
                        var avatarImage = Properties.Resources.avatar;
                    }

                    var item = new ListViewItem();
                    item.ImageKey = "avatar"; // Nếu muốn dùng hình từ GetAvatarFromResources thì cần thêm logic imageList động

                    item.SubItems.Add(username);
                    item.SubItems.Add(""); item.SubItems[2].Tag = "mic_on";
                    item.SubItems.Add(""); item.SubItems[3].Tag = "cam_off";

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
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt4":
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt5":
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt6":
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt7":
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt8":
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt9":
                    return Properties.Resources.avt2; // Avatar từ Resources
                case "avt10":
                    return Properties.Resources.avt2; // Avatar từ Resources
                default:
                    return Properties.Resources.avatar; // Avatar mặc định nếu không tìm thấy
            }
        }

        private void sbtn_ChangeHost_Click(object sender, EventArgs e)
        {
            Host host = new Host(currentUserId, currentroomId);
            host.ShowDialog();
        }
    }
}
