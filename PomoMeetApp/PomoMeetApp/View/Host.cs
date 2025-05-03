using PomoMeetApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    MessageBox.Show("Phòng không tồn tại!");
                    return;
                }

                var roomData = snapshot.ToDictionary();
                string hostId = roomData["host_id"].ToString(); // Lấy hostId từ Firestore

                // Kiểm tra nếu người hiện tại có phải là host không
                if (currentUserId != hostId)
                {
                    MessageBox.Show("Chỉ host hiện tại mới có quyền chuyển host.");
                    return;
                }

                // Kiểm tra nếu người được chọn đã là host
                if (newHostId == hostId)
                {
                    MessageBox.Show("Thành viên này đã là host.");
                    return;
                }

                // Cập nhật host trong Firestore
                await roomRef.UpdateAsync("host_id", newHostId);  // Cập nhật host_id mới
                MessageBox.Show("Host đã được chuyển thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi chuyển host: {ex.Message}");
            }
        }


        private async void LoadParticipants()
        {
            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").WhereEqualTo("roomId", currentroomId); // Truy vấn chỉ lấy room_id đúng

            var roomDoc = await roomRef.GetSnapshotAsync();

            if (roomDoc.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phòng với room_id: " + currentroomId);
                 return;
            }

            var roomData = roomDoc.Documents[0].ToDictionary(); // Giả sử chỉ có một phòng với room_id
            var members = roomData["members"] as List<object>;

            tlp_ListMembers.Controls.Clear(); // Xóa hết các dòng cũ nếu có

            foreach (string userId in members)
            {
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
                    MessageBox.Show("Phòng không tồn tại!");
                    return;
                }

                var roomData = snapshot.ToDictionary();
                string hostId = roomData["host_id"].ToString(); // Lấy hostId từ Firestore
                var members = roomData["members"] as List<object>;


                // Kiểm tra nếu người hiện tại có phải là host không
                if (currentUserId != hostId)
                {
                    MessageBox.Show("Chỉ host hiện tại mới có quyền kick.");
                    return;
                }

                if (userId == currentUserId)
                {
                    MessageBox.Show("Không thể tự đá chính mình khỏi phòng.");
                    return;
                }

                // Xóa thành viên khỏi danh sách
                members.Remove(userId);

                // Cập nhật lại danh sách thành viên trong Firestore
                await roomRef.UpdateAsync("members", members);

                MessageBox.Show("Thành viên đã bị đá khỏi phòng!");
                LoadParticipants(); // Tải lại danh sách thành viên
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đá thành viên: {ex.Message}");
            }
        }

        private async void tb_FindMembers_Changed(object sender, EventArgs e)
        {
            string searchKeyword = tb_FindMembers.Text.ToLower(); // Lấy từ khóa tìm kiếm và chuyển thành chữ thường

            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                LoadParticipants();
                return;
            }

            var db = FirebaseConfig.database;
            var roomRef = db.Collection("Room").WhereEqualTo("roomId", currentroomId); // Truy vấn chỉ lấy room_id đúng

            var roomDoc = await roomRef.GetSnapshotAsync();

            if (roomDoc.Count == 0)
            {
                MessageBox.Show("Không tìm thấy phòng với room_id: " + currentroomId);
                return;
            }

            var roomData = roomDoc.Documents[0].ToDictionary(); 
            var members = roomData["members"] as List<object>;

            tlp_ListMembers.Controls.Clear(); // Xóa hết các dòng cũ nếu có

            foreach (string userId in members)
            {
                var userRef = db.Collection("User").Document(userId);
                var userDoc = await userRef.GetSnapshotAsync();
                if (!userDoc.Exists) continue;

                var userData = userDoc.ToDictionary();
                string username = userData["Username"].ToString(); // Dữ liệu gốc giữ nguyên
                string compareUsername = username.ToLower();
                string avatarKey = userData.ContainsKey("Avatar") ? userData["Avatar"]?.ToString() : null;

                // Kiểm tra xem tên người dùng có khớp với từ khóa tìm kiếm không
                if (compareUsername.Contains(searchKeyword))
                {
                    // Lấy avatar từ resource
                    Image avatarImage = GetAvatarFromResources(avatarKey);

                    // Gọi AddMemberRow để thêm thành viên vào TableLayoutPanel, truyền cả userId
                    AddMemberRow(userId, username, avatarImage); // Truyền cả userId vào phương thức AddMemberRow
                }
            }
        }
    }
}
