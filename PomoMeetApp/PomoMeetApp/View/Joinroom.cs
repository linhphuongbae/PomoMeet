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
using System.Security.Cryptography;
using Google.Cloud.Firestore;


namespace PomoMeetApp.View
{
    public partial class Joinroom : Form
    {
        private string currentUserId;
        private RoomData joinedRoomData;

        public Joinroom(string userId)
        {
            currentUserId = userId;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Joinroom_Load(object sender, EventArgs e)
        {

        }

        private async void sbtn_JoinRoom_Click(object sender, EventArgs e)
        {
            string roomId = stb_roomId.Text.Trim();

            if (string.IsNullOrEmpty(roomId))
            {
                MessageBox.Show("Vui lòng nhập mã phòng.");
                return;
            }

            var room = await GetRoomByroomId(roomId);
            if (room == null)
            {
                MessageBox.Show("Không tìm thấy phòng.");
                return;
            }

            joinedRoomData = room;

            if (room.Type == "Public")
            {
                // Nếu phòng là Public thì vào luôn
                OpenMeetingRoom(currentUserId, joinedRoomData.RoomId);
            }
            else if (room.Type == "Private")
            {
                lb_Password.Visible = true; // Hiện label mật khẩu
                stb_Password.Visible = true; // Hiện textbox mật khẩu
                btn_TogglePassword.Visible = true; // Hiện nút hiện mật khẩu
                btn_TogglePassword.BringToFront();
                // Nếu phòng là Private, yêu cầu nhập mật khẩu
                string enteredPassword = stb_Password.Text.Trim(); // Nhận mật khẩu từ textbox

                if (string.IsNullOrEmpty(enteredPassword))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu.");
                    return;
                }

                // So sánh mật khẩu đã nhập với mật khẩu trong phòng
                string hashedPassword = HashPassword(enteredPassword);

                if (hashedPassword == joinedRoomData.Password)
                {
                    // Mật khẩu đúng, vào phòng
                    OpenMeetingRoom(currentUserId, joinedRoomData.RoomId);
                }
                else
                {
                    MessageBox.Show("Mật khẩu không chính xác.");
                }
            }

        }

        private async Task<RoomData> GetRoomByroomId(string roomId)
        {
            var db = FirebaseConfig.database;
            var query = db.Collection("Room").WhereEqualTo("roomId", roomId);
            var snapshot = await query.GetSnapshotAsync();

            if (snapshot.Count == 0)
                return null;

            var doc = snapshot.Documents.First();
            var data = doc.ToDictionary();

            MessageBox.Show($"RoomId: {roomId}, Snapshot Count: {snapshot.Count}");


            return new RoomData
            {
                RoomId = doc.Id,
                RoomName = data["room_name"]?.ToString(),
                Type = data["type"]?.ToString(),
                Password = data["password"]?.ToString(),
                HostId = data["host_id"]?.ToString(),
                CurrentImageIndex = Convert.ToInt32(data["currentImageIndex"]),
                Pomodoro = Convert.ToInt32(data["pomodoro"]),
                ShortBreak = Convert.ToInt32(data["short_break"]),
                CurrentIndex = Convert.ToInt32(data["currentIndex"])
            };
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
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
            this.Close();
        }

        bool isPasswordVisible = false;

        private void btn_TogglePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            stb_Password.UseSystemPasswordChar = !isPasswordVisible;

            btn_TogglePassword.BackgroundImage = isPasswordVisible
                ? Properties.Resources.eye_open
                : Properties.Resources.eye_close;
        }
    }

    public class RoomData
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
        public string HostId { get; set; }
        public int CurrentImageIndex { get; set; }
        public int Pomodoro { get; set; }
        public int ShortBreak { get; set; }
        public int CurrentIndex { get; set; }
    }
}
